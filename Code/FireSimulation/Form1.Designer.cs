﻿namespace FireSimulator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picBoxWall = new System.Windows.Forms.PictureBox();
            this.Placeholder = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.picBoxFireExtinguisher = new System.Windows.Forms.PictureBox();
            this.picBoxFire = new System.Windows.Forms.PictureBox();
            this.picBoxEraser = new System.Windows.Forms.PictureBox();
            this.picBoxPerson = new System.Windows.Forms.PictureBox();
            this.picBoxPlay = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbFireExtinguishers = new System.Windows.Forms.TextBox();
            this.tbPeople = new System.Windows.Forms.TextBox();
            this.lblFireExtinguishers = new System.Windows.Forms.Label();
            this.lblPeople = new System.Windows.Forms.Label();
            this.lblGenerate = new System.Windows.Forms.Label();
            this.lblBuild = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolTipWall = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipFireExtinguisher = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipFire = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipPerson = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipEraser = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipPlay = new System.Windows.Forms.ToolTip(this.components);
            this.tbTimer = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFireExtinguisher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEraser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPlay)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBoxWall
            // 
            this.picBoxWall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxWall.Image = global::FireSimulator.Icons.Wall;
            this.picBoxWall.Location = new System.Drawing.Point(19, 26);
            this.picBoxWall.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picBoxWall.Name = "picBoxWall";
            this.picBoxWall.Size = new System.Drawing.Size(56, 61);
            this.picBoxWall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxWall.TabIndex = 2;
            this.picBoxWall.TabStop = false;
            this.toolTipWall.SetToolTip(this.picBoxWall, "Build wall");
            // 
            // Placeholder
            // 
            this.Placeholder.BackColor = System.Drawing.SystemColors.Control;
            this.Placeholder.FormattingEnabled = true;
            this.Placeholder.Location = new System.Drawing.Point(134, 44);
            this.Placeholder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Placeholder.Name = "Placeholder";
            this.Placeholder.Size = new System.Drawing.Size(644, 420);
            this.Placeholder.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // picBoxFireExtinguisher
            // 
            this.picBoxFireExtinguisher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxFireExtinguisher.Image = global::FireSimulator.Icons.Fire_extinguisher;
            this.picBoxFireExtinguisher.Location = new System.Drawing.Point(19, 92);
            this.picBoxFireExtinguisher.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picBoxFireExtinguisher.Name = "picBoxFireExtinguisher";
            this.picBoxFireExtinguisher.Size = new System.Drawing.Size(56, 61);
            this.picBoxFireExtinguisher.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxFireExtinguisher.TabIndex = 5;
            this.picBoxFireExtinguisher.TabStop = false;
            this.toolTipFireExtinguisher.SetToolTip(this.picBoxFireExtinguisher, "Place fire extinguisher");
            // 
            // picBoxFire
            // 
            this.picBoxFire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxFire.Image = global::FireSimulator.Icons.Fire;
            this.picBoxFire.Location = new System.Drawing.Point(19, 158);
            this.picBoxFire.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picBoxFire.Name = "picBoxFire";
            this.picBoxFire.Size = new System.Drawing.Size(56, 61);
            this.picBoxFire.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxFire.TabIndex = 6;
            this.picBoxFire.TabStop = false;
            this.toolTipFire.SetToolTip(this.picBoxFire, "Place fire");
            // 
            // picBoxEraser
            // 
            this.picBoxEraser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxEraser.Image = global::FireSimulator.Icons.Eraser;
            this.picBoxEraser.Location = new System.Drawing.Point(19, 289);
            this.picBoxEraser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picBoxEraser.Name = "picBoxEraser";
            this.picBoxEraser.Size = new System.Drawing.Size(56, 61);
            this.picBoxEraser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxEraser.TabIndex = 7;
            this.picBoxEraser.TabStop = false;
            this.toolTipEraser.SetToolTip(this.picBoxEraser, "Erase");
            // 
            // picBoxPerson
            // 
            this.picBoxPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxPerson.Image = global::FireSimulator.Icons.Person;
            this.picBoxPerson.Location = new System.Drawing.Point(19, 223);
            this.picBoxPerson.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picBoxPerson.Name = "picBoxPerson";
            this.picBoxPerson.Size = new System.Drawing.Size(56, 61);
            this.picBoxPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxPerson.TabIndex = 8;
            this.picBoxPerson.TabStop = false;
            this.toolTipPerson.SetToolTip(this.picBoxPerson, "Place a person");
            // 
            // picBoxPlay
            // 
            this.picBoxPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxPlay.Image = global::FireSimulator.Icons.Play;
            this.picBoxPlay.Location = new System.Drawing.Point(16, 9);
            this.picBoxPlay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picBoxPlay.Name = "picBoxPlay";
            this.picBoxPlay.Size = new System.Drawing.Size(56, 61);
            this.picBoxPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxPlay.TabIndex = 9;
            this.picBoxPlay.TabStop = false;
            this.toolTipPlay.SetToolTip(this.picBoxPlay, "Play");
            this.picBoxPlay.Click += new System.EventHandler(this.picBoxPlay_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.tbFireExtinguishers);
            this.groupBox1.Controls.Add(this.tbPeople);
            this.groupBox1.Controls.Add(this.lblFireExtinguishers);
            this.groupBox1.Controls.Add(this.lblPeople);
            this.groupBox1.Controls.Add(this.picBoxWall);
            this.groupBox1.Controls.Add(this.picBoxFireExtinguisher);
            this.groupBox1.Controls.Add(this.lblGenerate);
            this.groupBox1.Controls.Add(this.picBoxEraser);
            this.groupBox1.Controls.Add(this.lblBuild);
            this.groupBox1.Controls.Add(this.picBoxPerson);
            this.groupBox1.Controls.Add(this.picBoxFire);
            this.groupBox1.Location = new System.Drawing.Point(20, 21);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(94, 366);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // tbFireExtinguishers
            // 
            this.tbFireExtinguishers.Location = new System.Drawing.Point(7, 223);
            this.tbFireExtinguishers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbFireExtinguishers.Name = "tbFireExtinguishers";
            this.tbFireExtinguishers.Size = new System.Drawing.Size(76, 20);
            this.tbFireExtinguishers.TabIndex = 17;
            this.tbFireExtinguishers.Visible = false;
            // 
            // tbPeople
            // 
            this.tbPeople.Location = new System.Drawing.Point(7, 125);
            this.tbPeople.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbPeople.Name = "tbPeople";
            this.tbPeople.Size = new System.Drawing.Size(76, 20);
            this.tbPeople.TabIndex = 15;
            this.tbPeople.Visible = false;
            // 
            // lblFireExtinguishers
            // 
            this.lblFireExtinguishers.AutoSize = true;
            this.lblFireExtinguishers.Location = new System.Drawing.Point(4, 205);
            this.lblFireExtinguishers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFireExtinguishers.Name = "lblFireExtinguishers";
            this.lblFireExtinguishers.Size = new System.Drawing.Size(88, 13);
            this.lblFireExtinguishers.TabIndex = 16;
            this.lblFireExtinguishers.Text = "Fire extinguishers";
            this.lblFireExtinguishers.Visible = false;
            // 
            // lblPeople
            // 
            this.lblPeople.AutoSize = true;
            this.lblPeople.Location = new System.Drawing.Point(4, 109);
            this.lblPeople.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPeople.Name = "lblPeople";
            this.lblPeople.Size = new System.Drawing.Size(40, 13);
            this.lblPeople.TabIndex = 15;
            this.lblPeople.Text = "People";
            this.lblPeople.Visible = false;
            // 
            // lblGenerate
            // 
            this.lblGenerate.BackColor = System.Drawing.Color.Transparent;
            this.lblGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGenerate.Location = new System.Drawing.Point(42, 7);
            this.lblGenerate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGenerate.Name = "lblGenerate";
            this.lblGenerate.Size = new System.Drawing.Size(52, 16);
            this.lblGenerate.TabIndex = 12;
            this.lblGenerate.Text = "Generate";
            this.lblGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGenerate.Click += new System.EventHandler(this.lblGenerate_Click);
            // 
            // lblBuild
            // 
            this.lblBuild.BackColor = System.Drawing.Color.White;
            this.lblBuild.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBuild.Location = new System.Drawing.Point(4, 7);
            this.lblBuild.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBuild.Name = "lblBuild";
            this.lblBuild.Size = new System.Drawing.Size(42, 16);
            this.lblBuild.TabIndex = 11;
            this.lblBuild.Text = "Build";
            this.lblBuild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBuild.Click += new System.EventHandler(this.lblBuild_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.picBoxPlay);
            this.groupBox2.Location = new System.Drawing.Point(22, 406);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(92, 75);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // tbTimer
            // 
            this.tbTimer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTimer.Location = new System.Drawing.Point(649, 21);
            this.tbTimer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbTimer.Name = "tbTimer";
            this.tbTimer.Size = new System.Drawing.Size(129, 16);
            this.tbTimer.TabIndex = 14;
            this.tbTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 491);
            this.Controls.Add(this.tbTimer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Placeholder);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Fire simulation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFireExtinguisher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEraser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPlay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picBoxWall;
        private System.Windows.Forms.ListBox Placeholder;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox picBoxFireExtinguisher;
        private System.Windows.Forms.PictureBox picBoxFire;
        private System.Windows.Forms.PictureBox picBoxEraser;
        private System.Windows.Forms.PictureBox picBoxPerson;
        private System.Windows.Forms.PictureBox picBoxPlay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBuild;
        private System.Windows.Forms.Label lblGenerate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolTip toolTipWall;
        private System.Windows.Forms.ToolTip toolTipFireExtinguisher;
        private System.Windows.Forms.ToolTip toolTipFire;
        private System.Windows.Forms.ToolTip toolTipPerson;
        private System.Windows.Forms.ToolTip toolTipEraser;
        private System.Windows.Forms.ToolTip toolTipPlay;
        private System.Windows.Forms.TextBox tbTimer;
        private System.Windows.Forms.TextBox tbFireExtinguishers;
        private System.Windows.Forms.TextBox tbPeople;
        private System.Windows.Forms.Label lblFireExtinguishers;
        private System.Windows.Forms.Label lblPeople;
    }
}

