using Library;
using System;
using System.Windows.Forms;

namespace FireSimulator
{
	public partial class FireSimulatorForm : Form
	{
		private TimeSpan time = new TimeSpan(0, 0, 0);
        private TimeSpan timeLimit;
		private Simulator simulator;
        private Simulator simStartingPoint;
		private bool running;
        private Layout currentLayout;
		public FireSimulatorForm(Layout layout)
		{
			InitializeComponent();

            currentLayout = layout;
			//WindowState = FormWindowState.Maximized;
			lblElapsedTime.Text = time.ToString();

			this.Text = "Lit - Simulator";

			this.simulator = new Simulator(layout);
            simStartingPoint = simulator.DeepCloneSelf();
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

                btnRerunSimulation.Visible = true;
                picBoxPlayPause.Enabled = false;

                if (s.isSuccess)
                {
                    lblResult.Text = "Success";
                }
                else
                {
                    lblResult.Text = "Fail";
                }

                if (MessageBox.Show($"The simulation finished \"{s.scenario.ToString()}\" \n Do you want to save the simulation data?", 
                    "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    int nrOfSurviver = simulator.GetNumberOfSurviver();
                    int nrOfDeaths = simulator.GetNumberOfPeopleDie();
                    int nrOfPeople = simulator.GetNumberOfPeople();
                    TimeSpan elapseTime = time;
                    DateTime date = DateTime.Now;

                    SimulationData simData = new SimulationData(nrOfSurviver, nrOfDeaths, nrOfPeople, date, elapseTime);

                    currentLayout.AddSimulationData(simData);
                    // TODO: Overwrite the save file
                }
            }
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
                simulator.TimeLimitReachScenario();
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