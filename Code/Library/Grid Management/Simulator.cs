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
		private bool timeLimitReached = false;

		private int personDelayCounter = 0;
		private const int personDelay = 2;

		private readonly List<History> gridHistory = new List<History>();
		private readonly List<FireExtinguisher> fireExtinguishers = new List<FireExtinguisher>();
		private readonly List<Person> persons = new List<Person>();

		public event EventHandler Finished;

		public Simulator(Block[,] grid, Person[] persons, FireExtinguisher[] fireExtinguishers)
			: base(grid)
		{
			this.fireExtinguishers = fireExtinguishers.ToList();
			this.persons = persons.ToList();
		}

		public Simulator(Block[,] grid)
			: base(grid)
		{
			fillLists();
		}

		public Simulator(Layout layout)
			: this(layout.DeepCloneBlock()) { }

		public System.Drawing.Bitmap Paint(int scaleX, int scaleY)
			=> Grid.Paint(this.grid, (scaleX, scaleY), this.persons.ToArray());

		public Simulator DeepCloneSelf()
		{
			return new Simulator(DeepCloneBlock(grid));
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

			// Discuss which scenario should be priotize and check first
			if (!hasFoundFireInPreviousTick)
			{
				Finish(EScenario.ALLFIREEXTINGUISH, true);
				return;
			}
			if (AllPeopleHadDieScenario())
			{
				Finish(EScenario.AllPEOPLEDIE, false);
				return;
			}
			if (timeLimitReached)
			{
				Finish(EScenario.TIMELIMITREACH, false);
				return;
			}
		}

		public void KillAll()
		{
			foreach (Person p in this.persons)
				p.Kill();
		}

		private void Finish(EScenario scenario, bool isSuccess)
		{
			this.Finished?.Invoke(this, new Scenario(scenario, isSuccess));
			Console.WriteLine($"{this.GetNumberOfPeopleDie()} {this.GetNumberOfPeople()}");
		}
		private bool AllPeopleHadDieScenario()
		{
			return persons.TrueForAll(person => person.IsDead);
		}

		public void TimeLimitReachScenario()
		{
			timeLimitReached = true;
		}

		public SimulationData GetSimulationData()
		{
			return new SimulationData();
		}

		public Action SetupInDifferentThread(Action<bool> callback, Action<int> progress, Action<string> progressReport)
		{
			BackgroundWorker bg = new BackgroundWorker();
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
								progressReport("Calculating path for person...");
								var task = ((Person)entry).CalculatePaths(this.grid, new Pair(x, y), fes, (worker, e), () =>
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

		public int GetNumberOfPeopleDie()
		{
			int count = 0;
			for (int i = 0; i < persons.Count; i++)
			{
				if (persons[i].IsDead)
				{
					count += 1;
				}
			}
			return count;
		}

		public int GetNumberOfSurviver()
		{
			int count = 0;
			for (int i = 0; i < persons.Count; i++)
			{
				if (!persons[i].IsDead)
				{
					count += 1;
				}
			}
			return count;
		}

		public int GetNumberOfPeople()
		{
			return persons.Count();
		}

		public int GetNumberOfFireExtinguisher()
		{
			return fireExtinguishers.Count;
		}
	}
}