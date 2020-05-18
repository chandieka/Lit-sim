using Library;
using System;
using System.Windows.Forms;

namespace FireSimulator
{
	public partial class FireSimulatorForm : Form
	{
		private TimeSpan time = new TimeSpan(0, 0, 0);
		private Simulator simStartingPoint;
		private Simulator simulator;
		private TimeSpan timeLimit;

		private readonly SaveItem saveItem;
		private bool running;

		public FireSimulatorForm(SaveItem saveItem)
		{
			InitializeComponent();

			WindowState = FormWindowState.Maximized;
			lblElapsedTime.Text = time.ToString();

			this.Text = "Lit - Simulator";

			if (!(saveItem.Item is Layout))
				throw new Exception("Cannot simulate SaveItem that does not contain a Layout");

			this.saveItem = saveItem;
			this.simulator = new Simulator((Layout)saveItem.Item);
			this.simStartingPoint = simulator.DeepCloneSelf();
			this.simulator.Finished += this.handleFinished;

			// Static Data
			lblFireExTotal.Text = simulator.FireExtinguisherAmount.ToString();
			lblPeopleTotal.Text = simulator.PersonAmount.ToString();
			lblDate.Text = DateTime.Today.ToString("dd/MM/yyyy");

			VisualizeSimulation();
		}

		#region Private Methods
		private void handleFinished(object sender, FinishedEventArgs e)
		{
			picBoxPlayPause_Click(null, null);

			this.simulator.ClearHistory();
			this.UpdateHistory();
			this.simulator.AddToHistory("Simulation finished");

			btnRerunSimulation.Visible = true;
			picBoxPlayPause.Enabled = false;

			if (e.IsSuccess)
				lblResult.Text = "Success";
			else
				lblResult.Text = "Fail";

			if (MessageBox.Show($"The simulation finished \"{e.ToString()}\"\nDo you want to save the simulation data?",
				"Finish", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
				simulator.SaveSimulationData(saveItem, DateTime.Now, time);
		}

		private void SetTimeLimit(int hours = 0, int minutes = 0, int seconds = 0)
		{
			timeLimit = new TimeSpan(hours, minutes, seconds);
		}

		private void LoadStartingLayout()
		{
			if (simStartingPoint != null)
			{
				simulator = simStartingPoint.DeepCloneSelf();
				simulator.Finished += handleFinished;
			}
		}

		public void ReStart()
		{
			running = false;
			time = TimeSpan.Zero;
			btnRerunSimulation.Visible = false;
			lblResult.Text = "<Success/Fail>";
			trackBarSpeed.Value = 50;
			animationLoopTimer.Interval = 60;

			GetStats();
			LoadStartingLayout();
			VisualizeSimulation();
		}

		private void UpdateHistory()
		{
			this.lbHistor.Items.Clear();
			this.lbHistor.Items.AddRange(this.simulator.GetHistory());
		}

		private void GetStats()
		{
			// Dynamic Data
			var deathAmount = simulator.GetNrOfDeaths();

			lblAlive.Text = (simulator.PersonAmount - deathAmount).ToString();
			lblDeaths.Text = deathAmount.ToString();
			lblElapsedTime.Text = time.ToString();
		}

		private void VisualizeSimulation()
		{
			pbSimulator.Image = simulator.Paint((6, 6), !running); // TODO: Check these numbers;
		}
		#endregion Private Methods

		#region EventHandlers
		private void animationLoopTimer_Tick(object sender, EventArgs e)
		{
			TimeSpan second = new TimeSpan(0, 0, 1);
			time = time.Add(second);

			if (time.Ticks != timeLimit.Ticks)
			{
				simulator.Tick();
				GetStats();
				VisualizeSimulation();
			}
			else
			{
				simulator.Tick();
				GetStats();
				VisualizeSimulation();
				simulator.TimeLimitReached();
			}
		}

		private void picBoxPlayPause_Click(object sender, EventArgs e)
		{
			if (!picBoxPlayPause.Enabled)
				return;

			if (!running)
			{
				try
				{
					animationLoopTimer.Start();
					running = true;
					picBoxPlayPause.Image = Icons.Pause;
					toolTipPlay.SetToolTip(picBoxPlayPause, "Pause (Spacebar)");
					this.simulator.AddToHistory("Simulation started");
					UpdateHistory();
					this.lbHistor.Enabled = false;
					btnTerminate.Visible = false;

					// TODO: Timelimit wiil be Change dynamically
					SetTimeLimit(0, 6, 0);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			else
			{
				animationLoopTimer.Stop();
				running = false;
				picBoxPlayPause.Image = Icons.Play;
				toolTipPlay.SetToolTip(picBoxPlayPause, "Resume (Spacebar)");
				this.simulator.AddToHistory("Simulation paused");
				UpdateHistory();
				this.lbHistor.Enabled = true;
				btnTerminate.Visible = true;
			}
		}

		private void btnCloseStatistics_Click(object sender, EventArgs e)
		{
			gBoxStatistics.Visible = false;
		}

		private void btnRerunSimulation_Click(object sender, EventArgs e)
		{
			ReStart();
			btnTerminate.Visible = false;
			// run the simulation
			picBoxPlayPause_Click(null, null);
		}

		private void lbHistor_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.lbHistor.SelectedItem != null)
			{
				// TODO: 
				History grid = (History)this.lbHistor.SelectedItem;
				// this.simulator = new GridController(grid.Grid);
				VisualizeSimulation();
				// Re adjust the Statistic Data 
				GetStats();
			}
		}

		private void btnTerminate_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Are you sure you want to terminate the simulation?", "Terminate Simulation", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				ReStart();
				btnTerminate.Visible = false;
			}
		}

		private void btnCalculatePaths_Click(object sender, EventArgs e)
		{
			if (running)
				return;

			var dialog = new ProgressDialog();
			var cancelMethod = simulator.SetupInDifferentThread(cancelled =>
			{
				if (!cancelled)
					this.picBoxPlayPause.Enabled = true;

				VisualizeSimulation();

				dialog.Close();
				dialog.Dispose();
			}, dialog.SetPercentage, dialog.SetProgressReport);

			dialog.Cancelled += (object s, EventArgs a) => cancelMethod();
			dialog.ShowDialog();
		}

		private void trackBarSpeed_Scroll(object sender, EventArgs e)
		{
			lblSpeed.Text = trackBarSpeed.Value.ToString();
			animationLoopTimer.Interval = 10 + (100 - trackBarSpeed.Value);
		}
		#endregion EventHandlers
	}
}