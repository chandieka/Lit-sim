using Library;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FireSimulator
{
    public partial class FireSimulatorForm : Form
    {
        private TimeSpan time = new TimeSpan(0, 0, 0);
        private bool running;
        private bool building = true;
        private readonly GridController gridController;

        private bool testingTicks = true;

        public FireSimulatorForm()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;
            tbTimer.Text = time.ToString();
            this.Text = "Fire Escape Simulator";

            this.gridController = new GridController((100, 100));

            gridController.PutDefaultFloorPlan(1);

            if (testingTicks)
                FillDefault();

            // paint the grid to the picturebox
            VisualizeSimulation();


            if (this.gridController.IsLoadable())
            {
                using (AutoSaveLoadDialog autoLoadDialog = new AutoSaveLoadDialog(false))
                {
                    autoLoadDialog.ShowDialog();
                    if (autoLoadDialog.DialogResult == DialogResult.Yes)
                    {
                        this.gridController.Load(GridController.defaultPath);
                        VisualizeSimulation();
                    }
                }
            }
        }

        #region Private Methods

        private void FillDefault()
        {
            animationLoopTimer.Interval = 1;
            gridController.RandomizeFire(1);
            gridController.RandomizePersons(10);
            gridController.RandomizeFireExtinguishers(20);
            GetStats();
        }

        private void GetStats()
        {
            int people = gridController.GetNrOfPeople();
            int deaths = gridController.GetTotalDeaths();
            int fireExtinguishers = gridController.GetNrOfFireExtinguishers();
            int alive = people - deaths;

            if (people == deaths)
            {
                lblResult.Text = "Fail";
            }

            lblDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            lblElapsedTime.Text = time.ToString();
            lblPeopleTotal.Text = people.ToString();
            lblFireExTotal.Text = fireExtinguishers.ToString();
            lblDeaths.Text = deaths.ToString();
            lblAlive.Text = alive.ToString();
        }

        private void switchInput()
        {
            if (building == true)
            {
                lblGenerate.Font = new Font(lblGenerate.Font, FontStyle.Underline);
                lblBuild.Font = new Font(lblBuild.Font, FontStyle.Regular);
                picBoxWall.Visible = false;
                picBoxFireExtinguisher.Visible = false;
                picBoxFire.Visible = false;
                picBoxPerson.Visible = false;
                picBoxEraser.Visible = false;
                tbPeople.Visible = true;
                tbFireExtinguishers.Visible = true;
                lblPeople.Visible = true;
                lblFireExtinguishers.Visible = true;
                btnGenerate.Visible = true;
                building = false;
            }
            else
            {
                lblGenerate.Font = new Font(lblGenerate.Font, FontStyle.Regular);
                lblBuild.Font = new Font(lblBuild.Font, FontStyle.Underline);
                picBoxWall.Visible = true;
                picBoxFireExtinguisher.Visible = true;
                picBoxFire.Visible = true;
                picBoxPerson.Visible = true;
                picBoxEraser.Visible = true;
                tbPeople.Visible = false;
                tbFireExtinguishers.Visible = false;
                lblPeople.Visible = false;
                lblFireExtinguishers.Visible = false;
                btnGenerate.Visible = false;
                building = true;
            }
        }

        private void VisualizeSimulation()
        {
            Bitmap bmp = gridController.Paint((6, 6));
            pbSimulation.Image = bmp;
        }

        #endregion

        #region Private EventHandlers

        private void animationLoopTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan second = new TimeSpan(0, 0, 10);
            time = time.Add(second);
            tbTimer.Text = time.ToString();


            // Testing purpose
            if (testingTicks)
            {
                gridController.Tick();
                GetStats();
            }
            else
            {
                gridController.Clear();
                gridController.PutDefaultFloorPlan(1);
                gridController.RandomizePersons(20);
                gridController.RandomizeFireExtinguishers(20);
            }

            VisualizeSimulation();

            if (gridController.Ended())
            {
                picBoxPlayPause_Click(null, null);
                GetStats();
                btnRerunSimulation.Visible = true;
            }
        }

        private void picBoxPlayPause_Click(object sender, EventArgs e)
        {
            if (!picBoxPlayPause.Enabled)
                return;

            if (running == false)
            {
                animationLoopTimer.Start();
                running = true;
                picBoxPlayPause.Image = Icons.Pause;
                toolTipPlay.SetToolTip(picBoxPlayPause, "Pause (Spacebar)");
                btnTerminate.Visible = false;
            }
            else
            {
                animationLoopTimer.Stop();
                running = false;
                picBoxPlayPause.Image = Icons.Play;
                toolTipPlay.SetToolTip(picBoxPlayPause, "Resume (Spacebar)");
                btnTerminate.Visible = true;
            }
        }


        private void lblGenerate_Click(object sender, EventArgs e)
        {
            switchInput();
        }

        private void lblBuild_Click(object sender, EventArgs e)
        {
            switchInput();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gridController.IsSavable())
            {
                using (AutoSaveLoadDialog autoSaveDialog = new AutoSaveLoadDialog(true))
                {
                    autoSaveDialog.ShowDialog();
                    if (autoSaveDialog.DialogResult == DialogResult.Yes)
                    {
                        this.gridController.Save(GridController.defaultPath);
                    }
                    else if (autoSaveDialog.DialogResult == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        #endregion

        private void btnCloseStatistics_Click(object sender, EventArgs e)
        {
            gBoxStatistics.Visible = false;
        }

        private void btnSaveLayout_Click(object sender, EventArgs e)
        {
            string fomatNum(int number)
            {
                if (number < 10)
                    return "0" + number;
                else
                    return number.ToString();
            }

            using (SaveFileDialog myDialog = new SaveFileDialog())
            {
                DateTime time = DateTime.Now;

                myDialog.DefaultExt = "bin";
                myDialog.AddExtension = true;
                myDialog.Filter = "Binary|.bin";
                myDialog.CheckPathExists = true;
                myDialog.FileName = $"Lit export [{fomatNum(time.Hour)}.{fomatNum(time.Minute)}.{fomatNum(time.Second)} {time.Year}-{fomatNum(time.Month)}-{fomatNum(time.Day)}].bin";

                if (myDialog.ShowDialog() == DialogResult.OK)
                {
                    this.gridController.Save(myDialog.FileName);
                }
            }
        }

        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog myDialog = new OpenFileDialog())
            {
                myDialog.Filter = "Binary|*.bin|All|*";
                myDialog.DefaultExt = "bin";

                if (myDialog.ShowDialog() == DialogResult.OK)
                {
                    this.gridController.Load(myDialog.FileName);
                    VisualizeSimulation();
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            bool isSuccess = true;

            // clear the map
            gridController.Clear();
            // get the basic floor plan
            gridController.PutDefaultFloorPlan(1);
            // add fire to the map
            gridController.RandomizeFire(1);

            if (!int.TryParse(tbPeople.Text, out int amountPeople))
                isSuccess &= false; // TODO: show error message

            if (!int.TryParse(tbFireExtinguishers.Text, out int amountFireEx))
                isSuccess &= false; // TODO: show error message

            if (!this.gridController.RandomizePersons(amountPeople))
                isSuccess &= false; // TODO: show error message

            if (!this.gridController.RandomizeFireExtinguishers(amountFireEx))
                isSuccess &= false; // TODO: show error message

            // visualize the map
            // not wasting computing power if its not successfull
            if (isSuccess)
            {
                VisualizeSimulation();
            }
        }

        private void btnRerunSimulation_Click(object sender, EventArgs e)
        {
            gridController.Clear();
            gridController.PutDefaultFloorPlan(1);
            FillDefault();
            time = TimeSpan.Zero;
            tbTimer.Text = time.ToString();
            VisualizeSimulation();
            btnRerunSimulation.Visible = false;
            lblResult.Text = "<Success/Fail>";
        }

        // For shortcuts
        private void FireSimulatorForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                picBoxPlayPause_Click(null, null);
            else if (e.Control)
            {
                if (e.KeyCode == Keys.O)
                    btnUploadFile_Click(null, null);
                else if (e.KeyCode == Keys.S)
                    btnSaveLayout_Click(null, null);
            }
        }

        private void btnTerminate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to terminate the simulation?", "Terminate Simulation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                gridController.Clear();
                gridController.PutDefaultFloorPlan(1);
                FillDefault();
                time = TimeSpan.Zero;
                tbTimer.Text = time.ToString();
                VisualizeSimulation();
                GetStats();
                btnTerminate.Visible = false;
            }
            else if (dialogResult == DialogResult.No)
            {
                //does nothing
            }

        }
        private void btnCalculatePaths_Click(object sender, EventArgs e)
        {
            var dialog = new ProgressDialog();
            var cancelMethod = gridController.SetupInDifferentThread(cancelled =>
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
    }
}
