using Library;
using System;
using System.Windows.Forms;

namespace FireSimulator
{
	public partial class FireSimulatorForm : Form
	{
		private TimeSpan time = new TimeSpan(0, 0, 0);

		private readonly Simulator simulator;
		private bool running;

		public FireSimulatorForm(Layout layout)
		{
			InitializeComponent();

			WindowState = FormWindowState.Maximized;
			lblElapsedTime.Text = time.ToString();

			this.Text = "Lit - Simulator";

			this.simulator = new Simulator(layout);
			this.simulator.Finished += this.handleFinished;

            // Static Data
            lblPeopleTotal.Text = simulator.GetNumberOfPeople().ToString();
            lblFireExTotal.Text = simulator.GetNumberOfFireExtinguisher().ToString();
            lblDate.Text = DateTime.Today.ToString("dd/MM/yyyy");

            VisualizeSimulation();
		}

		#region Private Methods
		private void handleFinished(object sender, EventArgs e)
		{
            if (e.GetType() == typeof(Scenario))
            {
                Scenario s = (Scenario)e;

                picBoxPlayPause_Click(null, null);
                this.simulator.ClearHistory();
                this.UpdateHistory();
                this.simulator.AddToHistory("Simulation finished");
                if (s.isSuccess)
                {
                    lblResult.Text = "Success";
                }
                else
                {
                    lblResult.Text = "Fail";
                }

                btnRerunSimulation.Visible = true;
                picBoxPlayPause.Enabled = false;
                if (MessageBox.Show($"The simulation finished \"{s.scenario.ToString()}\" \n Do you want to save the simulation data?", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    // TODO: Simulation Data save to layout
                }
            }
        }

		private void UpdateHistory()
		{
			this.lbHistor.Items.Clear();
			this.lbHistor.Items.AddRange(this.simulator.GetHistory());
		}

		private void GetStats()
		{
            // Dynamic Data
            lblElapsedTime.Text = time.ToString();
            lblDeaths.Text = simulator.GetNumberOfPeopleDie().ToString();
            lblAlive.Text = simulator.GetNumberOfSurviver().ToString();
        }

        private void VisualizeSimulation()
		{
			pbSimulator.Image = simulator.Paint(6, 6); // TODO: Check these numbers;
		}
		#endregion Private Methods

		#region EventHandlers
		private void animationLoopTimer_Tick(object sender, EventArgs e)
		{
			TimeSpan second = new TimeSpan(0, 0, 10);
			time = time.Add(second);

			simulator.Tick();
			GetStats();

			VisualizeSimulation();
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
            // TODO
            // simulator = gcStartingPosition;
            // SaveStartingLayout();
            VisualizeSimulation();
            running = true;
            time = TimeSpan.Zero;
			btnRerunSimulation.Visible = false;
			btnTerminate.Visible = false;
			lblResult.Text = "<Success/Fail>";
			trackBarSpeed.Value = 50;
			animationLoopTimer.Interval = 60;
			GetStats();
		}

		private void lbHistor_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.lbHistor.SelectedItem != null)
			{
				// TODO
				History grid = (History)this.lbHistor.SelectedItem;
				// this.simulator = new GridController(grid.Grid);
				VisualizeSimulation();
			}
		}

		private void btnTerminate_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Are you sure you want to terminate the simulation?", "Terminate Simulation", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				VisualizeSimulation();
				time = TimeSpan.Zero;
				GetStats();
				btnTerminate.Visible = false;
				trackBarSpeed.Value = 50;
				animationLoopTimer.Interval = 60;
				lblResult.Text = "<Success/Fail>";
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