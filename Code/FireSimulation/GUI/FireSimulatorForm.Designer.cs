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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picBoxPlayPause = new System.Windows.Forms.PictureBox();
            this.btnCalculatePaths = new System.Windows.Forms.Button();
            this.btnTerminate = new System.Windows.Forms.Button();
            this.toolTipWall = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipFireExtinguisher = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipFire = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipPerson = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipEraser = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipPlay = new System.Windows.Forms.ToolTip(this.components);
            this.gBoxStatistics = new System.Windows.Forms.GroupBox();
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
            this.label3 = new System.Windows.Forms.Label();
            this.toolTipImport = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipSave = new System.Windows.Forms.ToolTip(this.components);
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbHistor = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.pbSimulator = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPlayPause)).BeginInit();
            this.gBoxStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSimulator)).BeginInit();
            this.SuspendLayout();
            // 
            // animationLoopTimer
            // 
            this.animationLoopTimer.Interval = 60;
            this.animationLoopTimer.Tick += new System.EventHandler(this.animationLoopTimer_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.picBoxPlayPause);
            this.groupBox2.Controls.Add(this.btnCalculatePaths);
            this.groupBox2.Controls.Add(this.btnTerminate);
            this.groupBox2.Location = new System.Drawing.Point(218, 665);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(600, 82);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // picBoxPlayPause
            // 
            this.picBoxPlayPause.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.btnCalculatePaths.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.btnTerminate.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            // gBoxStatistics
            // 
            this.gBoxStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxStatistics.Controls.Add(this.lblAlive);
            this.gBoxStatistics.Controls.Add(this.label2);
            this.gBoxStatistics.Controls.Add(this.lblSpeed);
            this.gBoxStatistics.Controls.Add(this.lblResult);
            this.gBoxStatistics.Controls.Add(this.label8);
            this.gBoxStatistics.Controls.Add(this.lblDeaths);
            this.gBoxStatistics.Controls.Add(this.lblPeopleTotal);
            this.gBoxStatistics.Controls.Add(this.lblFireExTotal);
            this.gBoxStatistics.Controls.Add(this.label10);
            this.gBoxStatistics.Controls.Add(this.lblDate);
            this.gBoxStatistics.Controls.Add(this.lblElapsedTime);
            this.gBoxStatistics.Controls.Add(this.label7);
            this.gBoxStatistics.Controls.Add(this.label6);
            this.gBoxStatistics.Controls.Add(this.label5);
            this.gBoxStatistics.Controls.Add(this.label4);
            this.gBoxStatistics.Controls.Add(this.btnRerunSimulation);
            this.gBoxStatistics.Controls.Add(this.btnCloseStatistics);
            this.gBoxStatistics.Controls.Add(this.label3);
            this.gBoxStatistics.Location = new System.Drawing.Point(833, 205);
            this.gBoxStatistics.Name = "gBoxStatistics";
            this.gBoxStatistics.Size = new System.Drawing.Size(200, 450);
            this.gBoxStatistics.TabIndex = 16;
            this.gBoxStatistics.TabStop = false;
            // 
            // lblAlive
            // 
            this.lblAlive.AutoSize = true;
            this.lblAlive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlive.Location = new System.Drawing.Point(124, 216);
            this.lblAlive.Name = "lblAlive";
            this.lblAlive.Size = new System.Drawing.Size(46, 15);
            this.lblAlive.TabIndex = 15;
            this.lblAlive.Text = "<alive>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Alive:";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(124, 241);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(19, 13);
            this.lblSpeed.TabIndex = 20;
            this.lblSpeed.Text = "50";
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(40, 52);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(124, 20);
            this.lblResult.TabIndex = 13;
            this.lblResult.Text = "<Success/Fail>";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 241);
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
            this.lblDeaths.Location = new System.Drawing.Point(124, 197);
            this.lblDeaths.Name = "lblDeaths";
            this.lblDeaths.Size = new System.Drawing.Size(58, 15);
            this.lblDeaths.TabIndex = 12;
            this.lblDeaths.Text = "<deaths>";
            // 
            // lblPeopleTotal
            // 
            this.lblPeopleTotal.AutoSize = true;
            this.lblPeopleTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeopleTotal.Location = new System.Drawing.Point(124, 152);
            this.lblPeopleTotal.Name = "lblPeopleTotal";
            this.lblPeopleTotal.Size = new System.Drawing.Size(59, 15);
            this.lblPeopleTotal.TabIndex = 11;
            this.lblPeopleTotal.Text = "<people>";
            // 
            // lblFireExTotal
            // 
            this.lblFireExTotal.AutoSize = true;
            this.lblFireExTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFireExTotal.Location = new System.Drawing.Point(124, 173);
            this.lblFireExTotal.Name = "lblFireExTotal";
            this.lblFireExTotal.Size = new System.Drawing.Size(54, 15);
            this.lblFireExTotal.TabIndex = 10;
            this.lblFireExTotal.Text = "<fire ex>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Number of fire ex:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(124, 110);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(45, 15);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "<date>";
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.AutoSize = true;
            this.lblElapsedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElapsedTime.Location = new System.Drawing.Point(124, 131);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(45, 15);
            this.lblElapsedTime.TabIndex = 7;
            this.lblElapsedTime.Text = "<time>";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Deaths:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Number of people:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Elapsed Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date:";
            // 
            // btnRerunSimulation
            // 
            this.btnRerunSimulation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Session Statistics";
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
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(833, 61);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 138);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(134, 51);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 13);
            this.label23.TabIndex = 26;
            this.label23.Text = "SPACE";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 51);
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Shortcuts";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox4.Controls.Add(this.lbHistor);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label32);
            this.groupBox4.Location = new System.Drawing.Point(12, 58);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 382);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            // 
            // lbHistor
            // 
            this.lbHistor.FormattingEnabled = true;
            this.lbHistor.Location = new System.Drawing.Point(9, 34);
            this.lbHistor.Name = "lbHistor";
            this.lbHistor.Size = new System.Drawing.Size(185, 342);
            this.lbHistor.TabIndex = 19;
            this.lbHistor.SelectedIndexChanged += new System.EventHandler(this.lbHistor_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(49, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 20);
            this.label15.TabIndex = 16;
            this.label15.Text = "Step History";
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
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox1.Location = new System.Drawing.Point(12, 446);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 214);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto Simulation";
            // 
            // FireSimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1049, 760);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.trackBarSpeed);
            this.Controls.Add(this.gBoxStatistics);
            this.Controls.Add(this.pbSimulator);
            this.Controls.Add(this.groupBox2);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1065, 799);
            this.Name = "FireSimulatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fire simulation";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPlayPause)).EndInit();
            this.gBoxStatistics.ResumeLayout(false);
            this.gBoxStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSimulator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Timer animationLoopTimer;
		private System.Windows.Forms.PictureBox picBoxPlayPause;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ToolTip toolTipWall;
		private System.Windows.Forms.ToolTip toolTipFireExtinguisher;
		private System.Windows.Forms.ToolTip toolTipFire;
		private System.Windows.Forms.ToolTip toolTipPerson;
		private System.Windows.Forms.ToolTip toolTipEraser;
		private System.Windows.Forms.ToolTip toolTipPlay;
		private System.Windows.Forms.GroupBox gBoxStatistics;
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
		private System.Windows.Forms.Label label3;
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
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.ListBox lbHistor;
		private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

