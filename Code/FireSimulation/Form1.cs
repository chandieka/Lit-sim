﻿using Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireSimulator
{
    public partial class Form1 : Form
    {
        TimeSpan time = new TimeSpan(0, 0, 0);
        bool running;
        bool building = true;
        GridController gridController;

        public Form1()
        {
            InitializeComponent();
            tbTimer.Text = time.ToString();

            this.gridController = new GridController((100, 100));
            if (this.gridController.IsLoadable())
            {
                //Add a messagebox or some other form of asking the user if he wants to load the last auto saved verion
                //if (yes)
                //{
                //  this.gridController.Load(string.Empty);
                //}
            }
        }

        #region Private Methods 

        private void switchInput()
        {
            if (building == true)
            {
                picBoxWall.Visible = false;
                picBoxFireExtinguisher.Visible = false;
                picBoxFire.Visible = false;
                picBoxPerson.Visible = false;
                picBoxEraser.Visible = false;
                tbPeople.Visible = true;
                tbFireExtinguishers.Visible = true;
                lblPeople.Visible = true;
                lblFireExtinguishers.Visible = true;
                building = false;
            }
            else
            {
                picBoxWall.Visible = true;
                picBoxFireExtinguisher.Visible = true;
                picBoxFire.Visible = true;
                picBoxPerson.Visible = true;
                picBoxEraser.Visible = true;
                tbPeople.Visible = false;
                tbFireExtinguishers.Visible = false;
                lblPeople.Visible = false;
                lblFireExtinguishers.Visible = false;
                building = true;
            }
        }

        #endregion

        #region Private EventHandlers

        private void timer1_Tick(object sender, EventArgs e)
        {
            tbTimer.Text = time.ToString();
            TimeSpan second = new TimeSpan(0, 0, 1);
            time = time.Add(second);
        }

        private void picBoxPlay_Click(object sender, EventArgs e)
        {
            if (running == false)
            {
                timer1.Start();
                running = true;
                toolTipPlay.SetToolTip(picBoxPlay, "Pause");
            }
            else
            {
                timer1.Stop();
                running = false;
                toolTipPlay.SetToolTip(picBoxPlay, "Resume");
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
    }
}
