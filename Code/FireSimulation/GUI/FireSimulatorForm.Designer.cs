namespace FireSimulator
{
	partial class FireSimulatorForm
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
			this.animationLoopTimer = new System.Windows.Forms.Timer(this.components);
			this.gbControls = new System.Windows.Forms.GroupBox();
			this.btnLegend = new System.Windows.Forms.Button();
			this.picBoxPlayPause = new System.Windows.Forms.PictureBox();
			this.btnCalculatePaths = new System.Windows.Forms.Button();
			this.btnTerminate = new System.Windows.Forms.Button();
			this.toolTipWall = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipFireExtinguisher = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipFire = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipPerson = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipEraser = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipPlay = new System.Windows.Forms.ToolTip(this.components);
			this.gbStatistics = new System.Windows.Forms.GroupBox();
			this.lblAlive = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblSpeed = new System.Windows.Forms.Label();
			this.lblResult = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lblDeaths = new System.Windows.Forms.Label();
			this.lblPeopleTotal = new System.Windows.Forms.Label();
			this.lblFireExTotal = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.lblDate = new System.Windows.Forms.Label();
			this.lblElapsedTime = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnRerunSimulation = new System.Windows.Forms.Button();
			this.btnCloseStatistics = new System.Windows.Forms.Button();
			this.toolTipImport = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipSave = new System.Windows.Forms.ToolTip(this.components);
			this.trackBarSpeed = new System.Windows.Forms.TrackBar();
			this.gbShortcuts = new System.Windows.Forms.GroupBox();
			this.label23 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.gbHistory = new System.Windows.Forms.GroupBox();
			this.lbHistory = new System.Windows.Forms.ListBox();
			this.label32 = new System.Windows.Forms.Label();
			this.pbSimulator = new System.Windows.Forms.PictureBox();
			this.gbAutoSimulation = new System.Windows.Forms.GroupBox();
			this.gbControls.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picBoxPlayPause)).BeginInit();
			this.gbStatistics.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
			this.gbShortcuts.SuspendLayout();
			this.gbHistory.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbSimulator)).BeginInit();
			this.SuspendLayout();
			// 
			// animationLoopTimer
			// 
			this.animationLoopTimer.Interval = 60;
			this.animationLoopTimer.Tick += new System.EventHandler(this.animationLoopTimer_Tick);
			// 
			// gbControls
			// 
			this.gbControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbControls.BackColor = System.Drawing.Color.White;
			this.gbControls.Controls.Add(this.btnLegend);
			this.gbControls.Controls.Add(this.picBoxPlayPause);
			this.gbControls.Controls.Add(this.btnCalculatePaths);
			this.gbControls.Controls.Add(this.btnTerminate);
			this.gbControls.Location = new System.Drawing.Point(218, 665);
			this.gbControls.Margin = new System.Windows.Forms.Padding(2);
			this.gbControls.Name = "gbControls";
			this.gbControls.Padding = new System.Windows.Forms.Padding(2);
			this.gbControls.Size = new System.Drawing.Size(600, 82);
			this.gbControls.TabIndex = 13;
			this.gbControls.TabStop = false;
			// 
			// btnLegend
			// 
			this.btnLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLegend.Location = new System.Drawing.Point(520, 13);
			this.btnLegend.Name = "btnLegend";
			this.btnLegend.Size = new System.Drawing.Size(75, 61);
			this.btnLegend.TabIndex = 19;
			this.btnLegend.Text = "Color Legend";
			this.btnLegend.UseVisualStyleBackColor = true;
			this.btnLegend.Click += new System.EventHandler(this.btnLegend_Click);
			// 
			// picBoxPlayPause
			// 
			this.picBoxPlayPause.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.picBoxPlayPause.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picBoxPlayPause.Enabled = false;
			this.picBoxPlayPause.Image = global::FireSimulator.Icons.Play;
			this.picBoxPlayPause.Location = new System.Drawing.Point(272, 13);
			this.picBoxPlayPause.Margin = new System.Windows.Forms.Padding(2);
			this.picBoxPlayPause.Name = "picBoxPlayPause";
			this.picBoxPlayPause.Size = new System.Drawing.Size(56, 61);
			this.picBoxPlayPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picBoxPlayPause.TabIndex = 9;
			this.picBoxPlayPause.TabStop = false;
			this.toolTipPlay.SetToolTip(this.picBoxPlayPause, "Play/pause (Spacebar)");
			this.picBoxPlayPause.Click += new System.EventHandler(this.picBoxPlayPause_Click);
			// 
			// btnCalculatePaths
			// 
			this.btnCalculatePaths.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnCalculatePaths.Location = new System.Drawing.Point(166, 13);
			this.btnCalculatePaths.Margin = new System.Windows.Forms.Padding(2);
			this.btnCalculatePaths.Name = "btnCalculatePaths";
			this.btnCalculatePaths.Size = new System.Drawing.Size(102, 61);
			this.btnCalculatePaths.TabIndex = 18;
			this.btnCalculatePaths.Text = "Calculate paths";
			this.btnCalculatePaths.UseVisualStyleBackColor = true;
			this.btnCalculatePaths.Click += new System.EventHandler(this.btnCalculatePaths_Click);
			// 
			// btnTerminate
			// 
			this.btnTerminate.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnTerminate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnTerminate.Location = new System.Drawing.Point(333, 13);
			this.btnTerminate.Name = "btnTerminate";
			this.btnTerminate.Size = new System.Drawing.Size(112, 61);
			this.btnTerminate.TabIndex = 18;
			this.btnTerminate.Text = "Terminate Simulation";
			this.btnTerminate.UseVisualStyleBackColor = true;
			this.btnTerminate.Visible = false;
			this.btnTerminate.Click += new System.EventHandler(this.btnTerminate_Click);
			// 
			// gbStatistics
			// 
			this.gbStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbStatistics.Controls.Add(this.lblAlive);
			this.gbStatistics.Controls.Add(this.label2);
			this.gbStatistics.Controls.Add(this.lblSpeed);
			this.gbStatistics.Controls.Add(this.lblResult);
			this.gbStatistics.Controls.Add(this.label8);
			this.gbStatistics.Controls.Add(this.lblDeaths);
			this.gbStatistics.Controls.Add(this.lblPeopleTotal);
			this.gbStatistics.Controls.Add(this.lblFireExTotal);
			this.gbStatistics.Controls.Add(this.label10);
			this.gbStatistics.Controls.Add(this.lblDate);
			this.gbStatistics.Controls.Add(this.lblElapsedTime);
			this.gbStatistics.Controls.Add(this.label7);
			this.gbStatistics.Controls.Add(this.label6);
			this.gbStatistics.Controls.Add(this.label5);
			this.gbStatistics.Controls.Add(this.label4);
			this.gbStatistics.Controls.Add(this.btnRerunSimulation);
			this.gbStatistics.Controls.Add(this.btnCloseStatistics);
			this.gbStatistics.Location = new System.Drawing.Point(833, 205);
			this.gbStatistics.Name = "gbStatistics";
			this.gbStatistics.Size = new System.Drawing.Size(200, 450);
			this.gbStatistics.TabIndex = 16;
			this.gbStatistics.TabStop = false;
			this.gbStatistics.Text = "Session statistics";
			// 
			// lblAlive
			// 
			this.lblAlive.AutoSize = true;
			this.lblAlive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAlive.Location = new System.Drawing.Point(124, 163);
			this.lblAlive.Name = "lblAlive";
			this.lblAlive.Size = new System.Drawing.Size(46, 15);
			this.lblAlive.TabIndex = 15;
			this.lblAlive.Text = "<alive>";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(7, 163);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 15);
			this.label2.TabIndex = 14;
			this.label2.Text = "Alive:";
			// 
			// lblSpeed
			// 
			this.lblSpeed.AutoSize = true;
			this.lblSpeed.Location = new System.Drawing.Point(124, 188);
			this.lblSpeed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblSpeed.Name = "lblSpeed";
			this.lblSpeed.Size = new System.Drawing.Size(19, 13);
			this.lblSpeed.TabIndex = 20;
			this.lblSpeed.Text = "50";
			// 
			// lblResult
			// 
			this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblResult.Location = new System.Drawing.Point(45, 19);
			this.lblResult.Name = "lblResult";
			this.lblResult.Size = new System.Drawing.Size(124, 20);
			this.lblResult.TabIndex = 13;
			this.lblResult.Text = "<Success/Fail>";
			this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(7, 188);
			this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(41, 13);
			this.label8.TabIndex = 19;
			this.label8.Text = "Speed:";
			// 
			// lblDeaths
			// 
			this.lblDeaths.AutoSize = true;
			this.lblDeaths.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDeaths.Location = new System.Drawing.Point(124, 144);
			this.lblDeaths.Name = "lblDeaths";
			this.lblDeaths.Size = new System.Drawing.Size(58, 15);
			this.lblDeaths.TabIndex = 12;
			this.lblDeaths.Text = "<deaths>";
			// 
			// lblPeopleTotal
			// 
			this.lblPeopleTotal.AutoSize = true;
			this.lblPeopleTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPeopleTotal.Location = new System.Drawing.Point(124, 99);
			this.lblPeopleTotal.Name = "lblPeopleTotal";
			this.lblPeopleTotal.Size = new System.Drawing.Size(59, 15);
			this.lblPeopleTotal.TabIndex = 11;
			this.lblPeopleTotal.Text = "<people>";
			// 
			// lblFireExTotal
			// 
			this.lblFireExTotal.AutoSize = true;
			this.lblFireExTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFireExTotal.Location = new System.Drawing.Point(124, 120);
			this.lblFireExTotal.Name = "lblFireExTotal";
			this.lblFireExTotal.Size = new System.Drawing.Size(54, 15);
			this.lblFireExTotal.TabIndex = 10;
			this.lblFireExTotal.Text = "<fire ex>";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(6, 120);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(104, 15);
			this.label10.TabIndex = 9;
			this.label10.Text = "Number of fire ex:";
			// 
			// lblDate
			// 
			this.lblDate.AutoSize = true;
			this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDate.Location = new System.Drawing.Point(124, 57);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(45, 15);
			this.lblDate.TabIndex = 8;
			this.lblDate.Text = "<date>";
			// 
			// lblElapsedTime
			// 
			this.lblElapsedTime.AutoSize = true;
			this.lblElapsedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblElapsedTime.Location = new System.Drawing.Point(124, 78);
			this.lblElapsedTime.Name = "lblElapsedTime";
			this.lblElapsedTime.Size = new System.Drawing.Size(45, 15);
			this.lblElapsedTime.TabIndex = 7;
			this.lblElapsedTime.Text = "<time>";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(7, 144);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(49, 15);
			this.label7.TabIndex = 6;
			this.label7.Text = "Deaths:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(6, 99);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(109, 15);
			this.label6.TabIndex = 5;
			this.label6.Text = "Number of people:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(7, 78);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(86, 15);
			this.label5.TabIndex = 4;
			this.label5.Text = "Elapsed Time:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(7, 57);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(36, 15);
			this.label4.TabIndex = 3;
			this.label4.Text = "Date:";
			// 
			// btnRerunSimulation
			// 
			this.btnRerunSimulation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRerunSimulation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRerunSimulation.Location = new System.Drawing.Point(10, 389);
			this.btnRerunSimulation.Name = "btnRerunSimulation";
			this.btnRerunSimulation.Size = new System.Drawing.Size(178, 44);
			this.btnRerunSimulation.TabIndex = 2;
			this.btnRerunSimulation.Text = "Rerun Simulation";
			this.btnRerunSimulation.UseVisualStyleBackColor = true;
			this.btnRerunSimulation.Visible = false;
			this.btnRerunSimulation.Click += new System.EventHandler(this.btnRerunSimulation_Click);
			// 
			// btnCloseStatistics
			// 
			this.btnCloseStatistics.Location = new System.Drawing.Point(352, 18);
			this.btnCloseStatistics.Name = "btnCloseStatistics";
			this.btnCloseStatistics.Size = new System.Drawing.Size(24, 21);
			this.btnCloseStatistics.TabIndex = 1;
			this.btnCloseStatistics.Text = "x";
			this.btnCloseStatistics.UseVisualStyleBackColor = true;
			this.btnCloseStatistics.Click += new System.EventHandler(this.btnCloseStatistics_Click);
			// 
			// trackBarSpeed
			// 
			this.trackBarSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trackBarSpeed.Location = new System.Drawing.Point(222, 10);
			this.trackBarSpeed.Margin = new System.Windows.Forms.Padding(2);
			this.trackBarSpeed.Maximum = 100;
			this.trackBarSpeed.Minimum = 1;
			this.trackBarSpeed.Name = "trackBarSpeed";
			this.trackBarSpeed.Size = new System.Drawing.Size(600, 45);
			this.trackBarSpeed.TabIndex = 1;
			this.trackBarSpeed.Value = 50;
			this.trackBarSpeed.Scroll += new System.EventHandler(this.trackBarSpeed_Scroll);
			// 
			// gbShortcuts
			// 
			this.gbShortcuts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.gbShortcuts.Controls.Add(this.label23);
			this.gbShortcuts.Controls.Add(this.label12);
			this.gbShortcuts.Controls.Add(this.label9);
			this.gbShortcuts.Location = new System.Drawing.Point(833, 61);
			this.gbShortcuts.Name = "gbShortcuts";
			this.gbShortcuts.Size = new System.Drawing.Size(200, 138);
			this.gbShortcuts.TabIndex = 21;
			this.gbShortcuts.TabStop = false;
			this.gbShortcuts.Text = "Shortcuts";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(152, 30);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(42, 13);
			this.label23.TabIndex = 26;
			this.label23.Text = "SPACE";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(6, 30);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(64, 13);
			this.label12.TabIndex = 19;
			this.label12.Text = "Start/Pause";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(6, 133);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(0, 13);
			this.label9.TabIndex = 18;
			// 
			// gbHistory
			// 
			this.gbHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.gbHistory.Controls.Add(this.lbHistory);
			this.gbHistory.Controls.Add(this.label32);
			this.gbHistory.Location = new System.Drawing.Point(12, 58);
			this.gbHistory.Name = "gbHistory";
			this.gbHistory.Size = new System.Drawing.Size(200, 382);
			this.gbHistory.TabIndex = 28;
			this.gbHistory.TabStop = false;
			this.gbHistory.Text = "Step history";
			// 
			// lbHistory
			// 
			this.lbHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbHistory.FormattingEnabled = true;
			this.lbHistory.Location = new System.Drawing.Point(9, 21);
			this.lbHistory.Name = "lbHistory";
			this.lbHistory.Size = new System.Drawing.Size(185, 355);
			this.lbHistory.TabIndex = 19;
			this.lbHistory.SelectedIndexChanged += new System.EventHandler(this.lbHistory_SelectedIndexChanged);
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label32.Location = new System.Drawing.Point(6, 133);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(0, 13);
			this.label32.TabIndex = 18;
			// 
			// pbSimulator
			// 
			this.pbSimulator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbSimulator.Location = new System.Drawing.Point(218, 61);
			this.pbSimulator.Name = "pbSimulator";
			this.pbSimulator.Size = new System.Drawing.Size(600, 600);
			this.pbSimulator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pbSimulator.TabIndex = 17;
			this.pbSimulator.TabStop = false;
			// 
			// gbAutoSimulation
			// 
			this.gbAutoSimulation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.gbAutoSimulation.Location = new System.Drawing.Point(12, 446);
			this.gbAutoSimulation.Name = "gbAutoSimulation";
			this.gbAutoSimulation.Size = new System.Drawing.Size(199, 214);
			this.gbAutoSimulation.TabIndex = 29;
			this.gbAutoSimulation.TabStop = false;
			this.gbAutoSimulation.Text = "Auto Simulation";
			// 
			// FireSimulatorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1049, 760);
			this.Controls.Add(this.gbAutoSimulation);
			this.Controls.Add(this.gbHistory);
			this.Controls.Add(this.gbShortcuts);
			this.Controls.Add(this.trackBarSpeed);
			this.Controls.Add(this.gbStatistics);
			this.Controls.Add(this.pbSimulator);
			this.Controls.Add(this.gbControls);
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "FireSimulatorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Lit - Simulator";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FireSimulatorForm_FormClosing);
			this.gbControls.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picBoxPlayPause)).EndInit();
			this.gbStatistics.ResumeLayout(false);
			this.gbStatistics.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
			this.gbShortcuts.ResumeLayout(false);
			this.gbShortcuts.PerformLayout();
			this.gbHistory.ResumeLayout(false);
			this.gbHistory.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbSimulator)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Timer animationLoopTimer;
		private System.Windows.Forms.PictureBox picBoxPlayPause;
		private System.Windows.Forms.GroupBox gbControls;
		private System.Windows.Forms.ToolTip toolTipWall;
		private System.Windows.Forms.ToolTip toolTipFireExtinguisher;
		private System.Windows.Forms.ToolTip toolTipFire;
		private System.Windows.Forms.ToolTip toolTipPerson;
		private System.Windows.Forms.ToolTip toolTipEraser;
		private System.Windows.Forms.ToolTip toolTipPlay;
		private System.Windows.Forms.GroupBox gbStatistics;
		private System.Windows.Forms.Label lblResult;
		private System.Windows.Forms.Label lblDeaths;
		private System.Windows.Forms.Label lblPeopleTotal;
		private System.Windows.Forms.Label lblFireExTotal;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label lblDate;
		private System.Windows.Forms.Label lblElapsedTime;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnRerunSimulation;
		private System.Windows.Forms.Button btnCloseStatistics;
		private System.Windows.Forms.PictureBox pbSimulator;
		private System.Windows.Forms.ToolTip toolTipImport;
		private System.Windows.Forms.ToolTip toolTipSave;
		private System.Windows.Forms.Label lblAlive;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnTerminate;
		private System.Windows.Forms.Button btnCalculatePaths;
		private System.Windows.Forms.TrackBar trackBarSpeed;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblSpeed;
		private System.Windows.Forms.GroupBox gbShortcuts;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.GroupBox gbHistory;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.ListBox lbHistory;
		private System.Windows.Forms.GroupBox gbAutoSimulation;
		private System.Windows.Forms.Button btnLegend;
	}
}

