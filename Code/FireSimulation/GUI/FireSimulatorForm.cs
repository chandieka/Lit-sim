using FireSimulator.GUI;
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
		private bool hasRun;

		public FireSimulatorForm(SaveItem saveItem)
		{
			InitializeComponent();

			lblElapsedTime.Text = time.ToString();

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
			VisualizeSimulation();

			btnCalculatePaths.Enabled = false;

			this.simulator.ClearHistory();
			this.UpdateHistory();
			this.simulator.AddToHistory("Simulation finished");

			if (e.IsSuccess)
				lblResult.Text = "Success";
			else
				lblResult.Text = "Fail";

			if (MessageBox.Show($"The simulation finished \"{e.ToString()}\"\nDo you want to save the simulation data?",
				"Finish", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
				simulator.SaveSimulationData(saveItem, DateTime.Now, time);

			btnRerunSimulation.Visible = true;
			picBoxPlayPause.Enabled = false;
            btnTerminate.Visible = false;
		}

		private void SetTimeLimit(int hours = 0, int minutes = 0, int seconds = 0)
		{
			timeLimit = new TimeSpan(hours, minutes, seconds);
		}

		private void LoadStartingLayout()
		{
			if (simStartingPoint != null)
			{
				simulator.Finished -= handleFinished;
				simulator = simStartingPoint.DeepCloneSelf();
				simulator.Finished += handleFinished;
			}
		}

		public void ReStart()
		{
			hasRun = false;
			running = false;
			time = TimeSpan.Zero;
			btnCalculatePaths.Enabled = true;
			btnRerunSimulation.Visible = false;
			lblResult.Text = "<Success/Fail>";
			trackBarSpeed.Value = 50;
			animationLoopTimer.Interval = 60;

			// TODO: Paths shouldn't have to be recalculated...

			GetStats();
			LoadStartingLayout();
			VisualizeSimulation();
		}

		private void UpdateHistory()
		{
			this.lbHistory.Items.Clear();
			this.lbHistory.Items.AddRange(this.simulator.GetHistory());
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
			pbSimulator.Image = simulator.Paint((6, 6), !hasRun); // TODO: Check these numbers
		}
		#endregion Private Methods

		#region Event Handlers
		private void animationLoopTimer_Tick(object sender, EventArgs e)
		{
			TimeSpan second = new TimeSpan(0, 0, 1);
			time = time.Add(second);

			simulator.Tick();
			GetStats();
			VisualizeSimulation();

			// TODO: User should be able to allow the limit
			if (time.Ticks == timeLimit.Ticks)
				simulator.TimeLimitReached();
		}

		private void picBoxPlayPause_Click(object sender, EventArgs e)
		{
			if (!picBoxPlayPause.Enabled)
				return;

			if (!running)
			{
				hasRun = true;

				try
				{
					animationLoopTimer.Start();
					running = true;
					picBoxPlayPause.Image = Icons.Pause;
					toolTipPlay.SetToolTip(picBoxPlayPause, "Pause (Spacebar)");
					this.simulator.AddToHistory("Simulation started");
					UpdateHistory();
					this.lbHistory.Enabled = false;
					btnTerminate.Visible = false;

					// TODO: Make the time limit change dynamically
					SetTimeLimit(0, 10, 0);
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
				this.lbHistory.Enabled = true;
				btnTerminate.Visible = true;
			}
		}

		private void btnCloseStatistics_Click(object sender, EventArgs e)
		{
			gbStatistics.Visible = false;
		}

		private void btnRerunSimulation_Click(object sender, EventArgs e)
		{
			ReStart();
			btnTerminate.Visible = false;
			// run the simulation
			picBoxPlayPause_Click(null, null);
		}

		private void lbHistory_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.lbHistory.SelectedItem != null)
			{
				History grid = (History)this.lbHistory.SelectedItem;
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

		private void FireSimulatorForm_FormClosing(object sender, FormClosingEventArgs e)
			=> this.simulator.Stop();

		private void btnLegend_Click(object sender, EventArgs e)
		{
			var form = new ColorLegendForm();
			void formMoveHandler(object s, EventArgs ea)
			{
				form.Location = new System.Drawing.Point(this.Left - form.Width, this.Top);
			}

			form.Owner = this;

			form.FormClosed += (o, ea) => this.Move -= formMoveHandler;
			this.Move += formMoveHandler;

			form.Show();
			formMoveHandler(null, null);
		}
		#endregion
	}
}