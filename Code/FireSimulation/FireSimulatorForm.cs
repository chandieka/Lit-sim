using Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireSimulator
{
    public partial class FireSimulatorForm : Form
    {
        TimeSpan time = new TimeSpan(0, 0, 0);
        bool running;
        bool building = true;
        GridController gridController;

        public FireSimulatorForm()
        {
            InitializeComponent();
            tbTimer.Text = time.ToString();
            this.Text = "Fire Escape Simulator";

            this.gridController = new GridController((100, 100));

            gridController.PutDefaultFloorPlan(1);

            // paint the grid to the picturebox
            VisualizeSimulation();


            ////if (this.gridController.IsLoadable())
            ////{
            ////    //Add a messagebox or some other form of asking the user if he wants to load the last auto saved verion
            ////    //if (yes)
            ////    //{
            ////    //  this.gridController.Load(string.Empty);
            ////    //}
            ////}
        }

        #region Private Methods 

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            tbTimer.Text = time.ToString();
            TimeSpan second = new TimeSpan(0, 0, 10);
            time = time.Add(second);

            // Testing purpose
            gridController.Clear();

            gridController.PutDefaultFloorPlan(1);
            gridController.PutPersons(20);
            gridController.PutFireExtinguishers(20);

            VisualizeSimulation();
        }

        private void picBoxPlayPause_Click(object sender, EventArgs e)
        {
            if (running == false)
            {
                timer1.Start();
                running = true;
                picBoxPlayPause.Image = Icons.Pause;
                toolTipPlay.SetToolTip(picBoxPlayPause, "Pause");
            }
            else
            {
                timer1.Stop();
                running = false;
                picBoxPlayPause.Image = Icons.Play;
                toolTipPlay.SetToolTip(picBoxPlayPause, "Resume");
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
                //Ask the user if he wants to autosave
                //if (yes)
                //{
                //  gridController.Save(string.Empty);
                //}
            }
        }

        #endregion

        private void btnCloseStatistics_Click(object sender, EventArgs e)
        {
            gBoxSettings.Visible = false;
        }

        private void btnSaveLayout_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog myDialog = new SaveFileDialog())
            {
                if (myDialog.ShowDialog() == DialogResult.OK)
                {
                    string name = myDialog.FileName;
                    
                        FileStream fs = new FileStream(name, FileMode.CreateNew, FileAccess.Write);
                       
                                        
                }
            }
        }

        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog myDialog = new OpenFileDialog())
            {
                if (myDialog.ShowDialog() == DialogResult.OK)
                {
                    string name = myDialog.FileName;
                    FileStream fs = null;
                   
                    fs = new FileStream(name, FileMode.Open, FileAccess.Read);                   
                    
                    if (fs != null)
                    fs.Close();
                    
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            
            // clear the map
            gridController.Clear();
            gridController.PutDefaultFloorPlan(1);

            if (int.TryParse(tbPeople.Text, out int amountPeople))
            {
                if (int.TryParse(tbFireExtinguishers.Text, out int amountFireEx))
                {
                    if (gridController.TotalNoOfFloorAvailableOnTheWall() >= amountFireEx)
                    {
                        // put the fire ex on the grid
                        gridController.PutFireExtinguishers(amountFireEx);

                        if (gridController.TotalNoOfFloor() - gridController.TotalNoOfFloorAvailableOnTheWall() >= amountPeople)
                        {
                            gridController.PutPersons(amountPeople);
                            isSuccess = true;
                        }
                        else
                        {
                            // TODO
                            // Show Warning Message for the no of fire ex is exceeding the capacity
                        }
                    }
                    else
                    {
                        // TODO
                        // Show Warning Message for the no of fire ex is exceeding the capacity
                    }
                }
                else
                {
                    // TODO
                    // show notification that the input for the fire ex is not a number
                }
            }
            else
            {
                // TODO
                // show notification that the input for the person is not a number
            }

            // visualize the map
            // not wasting computing power if its not success full
            if (isSuccess)
            {
                VisualizeSimulation();
            }
        }
    }
}
