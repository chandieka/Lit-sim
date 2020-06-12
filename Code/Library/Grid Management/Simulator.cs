using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
	public class Simulator : Grid
	{
		private bool hasFoundFireInPreviousTick = false;
		private bool hasTicked = false;
		private bool isSuccessful = false;
		private EScenario scenario;

		private int personDelayCounter = 0;
		private const int personDelay = 2;

		private readonly List<FireExtinguisher> fireExtinguishers = new List<FireExtinguisher>();
		private readonly List<History> gridHistory = new List<History>();
		private readonly List<Person> persons = new List<Person>();

		public delegate void FinishedHandler(object sender, FinishedEventArgs e);
		public event FinishedHandler Finished;

		public int FireExtinguisherAmount { get { return fireExtinguishers.Count; } }
		public int PersonAmount { get { return persons.Count; } }

		public Simulator(Layout layout)
			: this(layout.Clone()) { }

		private Simulator(Grid grid)
			: base(grid)
		{
			fillLists();
		}

		public System.Drawing.Bitmap Paint((int scaleX, int scaleY) scaleSize, bool shouldPaintPaths = true)
			=> Grid.Paint(this.grid, scaleSize, shouldPaintPaths ? this.persons.ToArray() : null);

		public Simulator DeepCloneSelf()
			=> new Simulator(this.Clone());

		public void Stop()
		{
			Finished = null;
			killAll();
		}

		public void Tick()
		{
			if (hasTicked && !hasFoundFireInPreviousTick)
				return;

			this.hasFoundFireInPreviousTick = false;
			this.hasTicked = true;

			// This is needed to prevent the fire from spreading rapidly
			var gridCopy = this.grid.Clone() as Block[,];
			for (int x = 0; x < gridCopy.GetLength(0); x++)
			{
				for (int y = 0; y < gridCopy.GetLength(1); y++)
				{
					switch (gridCopy[x, y])
					{
						case FunctionalBlock fb:
							if (fb is Fire)
								hasFoundFireInPreviousTick = true;
							else if (fb is Person)
								if (personDelayCounter < personDelay)
									continue;

							fb.Function(this.grid, x, y);
							break;
					}
				}
			}

			personDelayCounter++;
			if (personDelayCounter > personDelay)
				personDelayCounter = 0;

			if (!hasFoundFireInPreviousTick)
			{
                isSuccessful = true;
                scenario = EScenario.ALL_FIRES_EXTINGUISHED;
                Finish(EScenario.ALL_FIRES_EXTINGUISHED, true);
                return;
			}
			else if (persons.TrueForAll(person => person.IsDead))
            {
                isSuccessful = false;
                scenario = EScenario.EVERY_PERSON_DIED;
                Finish(EScenario.EVERY_PERSON_DIED, false);
                return;
            }
        }

		public void TimeLimitReached()
		{
            isSuccessful = false;
            scenario = EScenario.TIME_LIMIT_REACHED;
            Finish(EScenario.TIME_LIMIT_REACHED, false);
        }

        public void SaveSimulationData(SaveItem saveItem, DateTime date, TimeSpan elapsedTime)
		{
			if (!(saveItem.Item is Layout))
				throw new Exception("Cannot save simulation data of SaveItem that does not contain a Layout");

			((Layout)saveItem.Item).AddSimulationData(new SimulationData(GetNrOfDeaths(), PersonAmount, date, elapsedTime, scenario));
			SaveLoadManager.Save(saveItem);
		}

		public int GetNrOfDeaths()
			=> persons.Count(_ => _.IsDead);

		public Action SetupInDifferentThread(Action<bool> callback, Action<int> progress, Action<string> progressReport)
		{
			BackgroundWorker bg = new BackgroundWorker();
			List<Person> persons = new List<Person>();
			List<Task> tasks = new List<Task>();
			bool cancelled = false;

			bg.WorkerSupportsCancellation = true;
			bg.WorkerReportsProgress = true;

			bg.RunWorkerCompleted += (object o, RunWorkerCompletedEventArgs e) => callback(cancelled);
			bg.ProgressChanged += (object o, ProgressChangedEventArgs e) => progress(e.ProgressPercentage);
			bg.DoWork += (object o, DoWorkEventArgs e) =>
			{
				BackgroundWorker worker = o as BackgroundWorker;

				progressReport("Finding all fire extinguishers...");
				var fes = GetFireExtinguishers(worker, e);

				progressReport("Finding all persons...");
				for (int x = 0; x < this.GridWidth; x++)
				{
					for (int y = 0; y < this.GridHeight; y++)
					{
						if (worker.CancellationPending)
							break;
						else
						{
							Block entry = this.grid[x, y];

							if (entry is Person)
							{
								var p = (Person)entry;

								progressReport("Calculating path for person...");
								persons.Add(p);
								var task = p.CalculatePaths(this.grid, new Pair(x, y), fes, (worker, e), () =>
								{
									if (worker.CancellationPending)
										e.Cancel = true;
									else
									{
										var allFinishedTasks = (double)(tasks.FindAll(t => t.IsCompleted).Count + 1);
										worker.ReportProgress((int)Math.Floor(allFinishedTasks / tasks.Count * 100));
									}
								});

								tasks.Add(task);
							}
						}
					}
				}

				progressReport("Waiting for all A* calls to finish...");
				Task.WaitAll(tasks.ToArray());
				progressReport("Done!");
				e.Result = true;
			};

			bg.RunWorkerAsync();
			return () =>
			{
				cancelled = true;
				bg.CancelAsync();
			};
		}

		#region History
		public void AddToHistory(string reason)
		{
			this.gridHistory.Add(new History(reason, (Block[,])this.grid.Clone()));
		}

		public History[] GetHistory()
		{
			return this.gridHistory.ToArray();
		}

		public void ClearHistory()
		{
			this.gridHistory.Clear();
		}
		#endregion

		private void Finish(EScenario scenario, bool isSuccess)
				=> this.Finished?.Invoke(this, new FinishedEventArgs(scenario, isSuccess));

		private void killAll()
		{
			foreach (Person p in this.persons)
				p.Kill();
		}

		private void fillLists()
		{
			this.fireExtinguishers.Clear();
			this.persons.Clear();

			for (int x = 0; x < this.GridWidth; x++)
			{
				for (int y = 0; y < this.GridHeight; y++)
				{
					var val = grid[x, y];

					if (val is Person)
						this.persons.Add((Person)val);
					else if (val is FireExtinguisher)
						this.fireExtinguishers.Add((FireExtinguisher)val);
				}
			}
		}

		private Pair[] GetFireExtinguishers(BackgroundWorker worker, DoWorkEventArgs e)
		{
			List<Pair> extinguishers = new List<Pair>();

			for (int x = 0; x < this.GridWidth; x++)
			{
				for (int y = 0; y < this.GridHeight; y++)
				{
					if (worker.CancellationPending == false)
					{
						if (this.grid[x, y] is FireExtinguisher)
							extinguishers.Add(new Pair(x, y));
					}
					else
					{
						e.Cancel = true;
						break;
					}
				}
			}

			return extinguishers.ToArray();
		}
	}
}