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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMaxFireEx = new System.Windows.Forms.Label();
            this.lblMaxPeople = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.tbFireExtinguishers = new System.Windows.Forms.TextBox();
            this.tbPeople = new System.Windows.Forms.TextBox();
            this.lblFireExtinguishers = new System.Windows.Forms.Label();
            this.lblPeople = new System.Windows.Forms.Label();
            this.picBoxWall = new System.Windows.Forms.PictureBox();
            this.picBoxFireExtinguisher = new System.Windows.Forms.PictureBox();
            this.lblGenerate = new System.Windows.Forms.Label();
            this.picBoxEraser = new System.Windows.Forms.PictureBox();
            this.lblBuild = new System.Windows.Forms.Label();
            this.picBoxPerson = new System.Windows.Forms.PictureBox();
            this.picBoxFire = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picBoxPlayPause = new System.Windows.Forms.PictureBox();
            this.toolTipWall = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipFireExtinguisher = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipFire = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipPerson = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipEraser = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipPlay = new System.Windows.Forms.ToolTip(this.components);
            this.tbTimer = new System.Windows.Forms.TextBox();
            this.gBoxSettings = new System.Windows.Forms.GroupBox();
            this.lblImportFileLoc = new System.Windows.Forms.Label();
            this.btnUploadFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveLayout = new System.Windows.Forms.Button();
            this.gBoxStatistics = new System.Windows.Forms.GroupBox();
            this.lblAlive = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
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
            this.pbSimulation = new System.Windows.Forms.PictureBox();
            this.toolTipImport = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipSave = new System.Windows.Forms.ToolTip(this.components);
            this.btnTerminate = new System.Windows.Forms.Button();
            this.btnCalculatePaths = new System.Windows.Forms.Button();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFireExtinguisher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEraser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFire)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPlayPause)).BeginInit();
            this.gBoxSettings.SuspendLayout();
            this.gBoxStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSimulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // animationLoopTimer
            // 
            this.animationLoopTimer.Interval = 1000;
            this.animationLoopTimer.Tick += new System.EventHandler(this.animationLoopTimer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.lblMaxFireEx);
            this.groupBox1.Controls.Add(this.lblMaxPeople);
            this.groupBox1.Controls.Add(this.btnGenerate);
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
            this.groupBox1.Location = new System.Drawing.Point(23, 56);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(112, 387);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // lblMaxFireEx
            // 
            this.lblMaxFireEx.AutoSize = true;
            this.lblMaxFireEx.Location = new System.Drawing.Point(11, 268);
            this.lblMaxFireEx.Name = "lblMaxFireEx";
            this.lblMaxFireEx.Size = new System.Drawing.Size(30, 13);
            this.lblMaxFireEx.TabIndex = 19;
            this.lblMaxFireEx.Text = "Max:";
            this.lblMaxFireEx.Visible = false;
            // 
            // lblMaxPeople
            // 
            this.lblMaxPeople.AutoSize = true;
            this.lblMaxPeople.Location = new System.Drawing.Point(11, 174);
            this.lblMaxPeople.Name = "lblMaxPeople";
            this.lblMaxPeople.Size = new System.Drawing.Size(30, 13);
            this.lblMaxPeople.TabIndex = 18;
            this.lblMaxPeople.Text = "Max:";
            this.lblMaxPeople.Visible = false;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(14, 333);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(76, 36);
            this.btnGenerate.TabIndex = 14;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Visible = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // tbFireExtinguishers
            // 
            this.tbFireExtinguishers.Location = new System.Drawing.Point(14, 242);
            this.tbFireExtinguishers.Margin = new System.Windows.Forms.Padding(2);
            this.tbFireExtinguishers.Name = "tbFireExtinguishers";
            this.tbFireExtinguishers.Size = new System.Drawing.Size(76, 20);
            this.tbFireExtinguishers.TabIndex = 17;
            this.tbFireExtinguishers.Visible = false;
            // 
            // tbPeople
            // 
            this.tbPeople.Location = new System.Drawing.Point(14, 144);
            this.tbPeople.Margin = new System.Windows.Forms.Padding(2);
            this.tbPeople.Name = "tbPeople";
            this.tbPeople.Size = new System.Drawing.Size(76, 20);
            this.tbPeople.TabIndex = 15;
            this.tbPeople.Visible = false;
            // 
            // lblFireExtinguishers
            // 
            this.lblFireExtinguishers.AutoSize = true;
            this.lblFireExtinguishers.Location = new System.Drawing.Point(11, 224);
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
            this.lblPeople.Location = new System.Drawing.Point(11, 128);
            this.lblPeople.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPeople.Name = "lblPeople";
            this.lblPeople.Size = new System.Drawing.Size(40, 13);
            this.lblPeople.TabIndex = 15;
            this.lblPeople.Text = "People";
            this.lblPeople.Visible = false;
            // 
            // picBoxWall
            // 
            this.picBoxWall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxWall.Image = global::FireSimulator.Icons.Wall;
            this.picBoxWall.Location = new System.Drawing.Point(26, 45);
            this.picBoxWall.Margin = new System.Windows.Forms.Padding(2);
            this.picBoxWall.Name = "picBoxWall";
            this.picBoxWall.Size = new System.Drawing.Size(56, 61);
            this.picBoxWall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxWall.TabIndex = 2;
            this.picBoxWall.TabStop = false;
            this.toolTipWall.SetToolTip(this.picBoxWall, "Build wall");
            // 
            // picBoxFireExtinguisher
            // 
            this.picBoxFireExtinguisher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxFireExtinguisher.Image = global::FireSimulator.Icons.Fire_extinguisher;
            this.picBoxFireExtinguisher.Location = new System.Drawing.Point(26, 111);
            this.picBoxFireExtinguisher.Margin = new System.Windows.Forms.Padding(2);
            this.picBoxFireExtinguisher.Name = "picBoxFireExtinguisher";
            this.picBoxFireExtinguisher.Size = new System.Drawing.Size(56, 61);
            this.picBoxFireExtinguisher.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxFireExtinguisher.TabIndex = 5;
            this.picBoxFireExtinguisher.TabStop = false;
            this.toolTipFireExtinguisher.SetToolTip(this.picBoxFireExtinguisher, "Place fire extinguisher");
            // 
            // lblGenerate
            // 
            this.lblGenerate.BackColor = System.Drawing.Color.Transparent;
            this.lblGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenerate.Location = new System.Drawing.Point(41, 15);
            this.lblGenerate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGenerate.Name = "lblGenerate";
            this.lblGenerate.Size = new System.Drawing.Size(67, 16);
            this.lblGenerate.TabIndex = 12;
            this.lblGenerate.Text = "Generate";
            this.lblGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGenerate.Click += new System.EventHandler(this.lblGenerate_Click);
            // 
            // picBoxEraser
            // 
            this.picBoxEraser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxEraser.Image = global::FireSimulator.Icons.Eraser;
            this.picBoxEraser.Location = new System.Drawing.Point(26, 308);
            this.picBoxEraser.Margin = new System.Windows.Forms.Padding(2);
            this.picBoxEraser.Name = "picBoxEraser";
            this.picBoxEraser.Size = new System.Drawing.Size(56, 61);
            this.picBoxEraser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxEraser.TabIndex = 7;
            this.picBoxEraser.TabStop = false;
            this.toolTipEraser.SetToolTip(this.picBoxEraser, "Erase");
            // 
            // lblBuild
            // 
            this.lblBuild.BackColor = System.Drawing.Color.White;
            this.lblBuild.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuild.Location = new System.Drawing.Point(3, 15);
            this.lblBuild.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBuild.Name = "lblBuild";
            this.lblBuild.Size = new System.Drawing.Size(42, 16);
            this.lblBuild.TabIndex = 11;
            this.lblBuild.Text = "Build";
            this.lblBuild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBuild.Click += new System.EventHandler(this.lblBuild_Click);
            // 
            // picBoxPerson
            // 
            this.picBoxPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxPerson.Image = global::FireSimulator.Icons.Person;
            this.picBoxPerson.Location = new System.Drawing.Point(26, 242);
            this.picBoxPerson.Margin = new System.Windows.Forms.Padding(2);
            this.picBoxPerson.Name = "picBoxPerson";
            this.picBoxPerson.Size = new System.Drawing.Size(56, 61);
            this.picBoxPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxPerson.TabIndex = 8;
            this.picBoxPerson.TabStop = false;
            this.toolTipPerson.SetToolTip(this.picBoxPerson, "Place a person");
            // 
            // picBoxFire
            // 
            this.picBoxFire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxFire.Image = global::FireSimulator.Icons.Fire;
            this.picBoxFire.Location = new System.Drawing.Point(26, 177);
            this.picBoxFire.Margin = new System.Windows.Forms.Padding(2);
            this.picBoxFire.Name = "picBoxFire";
            this.picBoxFire.Size = new System.Drawing.Size(56, 61);
            this.picBoxFire.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxFire.TabIndex = 6;
            this.picBoxFire.TabStop = false;
            this.toolTipFire.SetToolTip(this.picBoxFire, "Place fire");
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.picBoxPlayPause);
            this.groupBox2.Location = new System.Drawing.Point(193, 661);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(600, 82);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // picBoxPlayPause
            // 
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
            // tbTimer
            // 
            this.tbTimer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTimer.Location = new System.Drawing.Point(882, 29);
            this.tbTimer.Margin = new System.Windows.Forms.Padding(2);
            this.tbTimer.Name = "tbTimer";
            this.tbTimer.ReadOnly = true;
            this.tbTimer.Size = new System.Drawing.Size(129, 16);
            this.tbTimer.TabIndex = 14;
            this.tbTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gBoxSettings
            // 
            this.gBoxSettings.Controls.Add(this.lblImportFileLoc);
            this.gBoxSettings.Controls.Add(this.btnUploadFile);
            this.gBoxSettings.Controls.Add(this.label1);
            this.gBoxSettings.Controls.Add(this.btnSaveLayout);
            this.gBoxSettings.Location = new System.Drawing.Point(811, 50);
            this.gBoxSettings.Name = "gBoxSettings";
            this.gBoxSettings.Size = new System.Drawing.Size(200, 234);
            this.gBoxSettings.TabIndex = 15;
            this.gBoxSettings.TabStop = false;
            // 
            // lblImportFileLoc
            // 
            this.lblImportFileLoc.AutoSize = true;
            this.lblImportFileLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportFileLoc.Location = new System.Drawing.Point(6, 133);
            this.lblImportFileLoc.Name = "lblImportFileLoc";
            this.lblImportFileLoc.Size = new System.Drawing.Size(0, 13);
            this.lblImportFileLoc.TabIndex = 18;
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUploadFile.Location = new System.Drawing.Point(6, 149);
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.Size = new System.Drawing.Size(185, 36);
            this.btnUploadFile.TabIndex = 17;
            this.btnUploadFile.Text = "Import Session File";
            this.toolTipImport.SetToolTip(this.btnUploadFile, "Import file (CTRL+O)");
            this.btnUploadFile.UseVisualStyleBackColor = true;
            this.btnUploadFile.Click += new System.EventHandler(this.btnUploadFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings";
            // 
            // btnSaveLayout
            // 
            this.btnSaveLayout.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSaveLayout.Location = new System.Drawing.Point(9, 63);
            this.btnSaveLayout.Name = "btnSaveLayout";
            this.btnSaveLayout.Size = new System.Drawing.Size(185, 36);
            this.btnSaveLayout.TabIndex = 16;
            this.btnSaveLayout.Text = "Save Session Layout";
            this.toolTipSave.SetToolTip(this.btnSaveLayout, "Save (CTRL+S)");
            this.btnSaveLayout.UseVisualStyleBackColor = true;
            this.btnSaveLayout.Click += new System.EventHandler(this.btnSaveLayout_Click);
            // 
            // gBoxStatistics
            // 
            this.gBoxStatistics.Controls.Add(this.lblAlive);
            this.gBoxStatistics.Controls.Add(this.label2);
            this.gBoxStatistics.Controls.Add(this.lblResult);
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
            this.gBoxStatistics.Location = new System.Drawing.Point(811, 298);
            this.gBoxStatistics.Name = "gBoxStatistics";
            this.gBoxStatistics.Size = new System.Drawing.Size(200, 302);
            this.gBoxStatistics.TabIndex = 16;
            this.gBoxStatistics.TabStop = false;
            // 
            // lblAlive
            // 
            this.lblAlive.AutoSize = true;
            this.lblAlive.Location = new System.Drawing.Point(124, 216);
            this.lblAlive.Name = "lblAlive";
            this.lblAlive.Size = new System.Drawing.Size(41, 13);
            this.lblAlive.TabIndex = 15;
            this.lblAlive.Text = "<alive>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Alive:";
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
            // lblDeaths
            // 
            this.lblDeaths.AutoSize = true;
            this.lblDeaths.Location = new System.Drawing.Point(124, 197);
            this.lblDeaths.Name = "lblDeaths";
            this.lblDeaths.Size = new System.Drawing.Size(51, 13);
            this.lblDeaths.TabIndex = 12;
            this.lblDeaths.Text = "<deaths>";
            // 
            // lblPeopleTotal
            // 
            this.lblPeopleTotal.AutoSize = true;
            this.lblPeopleTotal.Location = new System.Drawing.Point(124, 152);
            this.lblPeopleTotal.Name = "lblPeopleTotal";
            this.lblPeopleTotal.Size = new System.Drawing.Size(51, 13);
            this.lblPeopleTotal.TabIndex = 11;
            this.lblPeopleTotal.Text = "<people>";
            // 
            // lblFireExTotal
            // 
            this.lblFireExTotal.AutoSize = true;
            this.lblFireExTotal.Location = new System.Drawing.Point(124, 173);
            this.lblFireExTotal.Name = "lblFireExTotal";
            this.lblFireExTotal.Size = new System.Drawing.Size(47, 13);
            this.lblFireExTotal.TabIndex = 10;
            this.lblFireExTotal.Text = "<fire ex>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Number of fire ex:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(124, 110);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(40, 13);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "<date>";
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.AutoSize = true;
            this.lblElapsedTime.Location = new System.Drawing.Point(124, 131);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(38, 13);
            this.lblElapsedTime.TabIndex = 7;
            this.lblElapsedTime.Text = "<time>";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Deaths:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Number of people:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Elapsed Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date:";
            // 
            // btnRerunSimulation
            // 
            this.btnRerunSimulation.Location = new System.Drawing.Point(43, 247);
            this.btnRerunSimulation.Name = "btnRerunSimulation";
            this.btnRerunSimulation.Size = new System.Drawing.Size(113, 36);
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
            // pbSimulation
            // 
            this.pbSimulation.Location = new System.Drawing.Point(193, 56);
            this.pbSimulation.Name = "pbSimulation";
            this.pbSimulation.Size = new System.Drawing.Size(600, 600);
            this.pbSimulation.TabIndex = 17;
            this.pbSimulation.TabStop = false;
            // 
            // btnTerminate
            // 
            this.btnTerminate.Location = new System.Drawing.Point(23, 499);
            this.btnTerminate.Name = "btnTerminate";
            this.btnTerminate.Size = new System.Drawing.Size(112, 42);
            this.btnTerminate.TabIndex = 18;
            this.btnTerminate.Text = "Terminate Simulation";
            this.btnTerminate.UseVisualStyleBackColor = true;
            this.btnTerminate.Visible = false;
            this.btnTerminate.Click += new System.EventHandler(this.btnTerminate_Click);
            // 
            // btnCalculatePaths
            // 
            this.btnCalculatePaths.Location = new System.Drawing.Point(23, 450);
            this.btnCalculatePaths.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalculatePaths.Name = "btnCalculatePaths";
            this.btnCalculatePaths.Size = new System.Drawing.Size(112, 44);
            this.btnCalculatePaths.TabIndex = 18;
            this.btnCalculatePaths.Text = "Calculate paths";
            this.btnCalculatePaths.UseVisualStyleBackColor = true;
            this.btnCalculatePaths.Click += new System.EventHandler(this.btnCalculatePaths_Click);
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Location = new System.Drawing.Point(193, 10);
            this.trackBarSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarSpeed.Maximum = 100;
            this.trackBarSpeed.Minimum = 1;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(600, 45);
            this.trackBarSpeed.TabIndex = 1;
            this.trackBarSpeed.Value = 50;
            this.trackBarSpeed.Scroll += new System.EventHandler(this.trackBarSpeed_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 11);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Speed:";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(112, 11);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(19, 13);
            this.lblSpeed.TabIndex = 20;
            this.lblSpeed.Text = "50";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(1017, 50);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 234);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(134, 172);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 13);
            this.label18.TabIndex = 31;
            this.label18.Text = "label18";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(134, 148);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 13);
            this.label19.TabIndex = 30;
            this.label19.Text = "CTRL + L";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(134, 124);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 13);
            this.label20.TabIndex = 29;
            this.label20.Text = "CTRL + S";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(134, 99);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 13);
            this.label21.TabIndex = 28;
            this.label21.Text = "label21";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(134, 75);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 13);
            this.label22.TabIndex = 27;
            this.label22.Text = "label22";
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
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 172);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "label15";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 148);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "Load Session Map";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 124);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "Save Session Map";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "Go Back";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Go Forward";
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
            // FireSimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1232, 746);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCalculatePaths);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.trackBarSpeed);
            this.Controls.Add(this.btnTerminate);
            this.Controls.Add(this.gBoxStatistics);
            this.Controls.Add(this.pbSimulation);
            this.Controls.Add(this.gBoxSettings);
            this.Controls.Add(this.tbTimer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FireSimulatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fire simulation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FireSimulatorForm_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFireExtinguisher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEraser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFire)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPlayPause)).EndInit();
            this.gBoxSettings.ResumeLayout(false);
            this.gBoxSettings.PerformLayout();
            this.gBoxStatistics.ResumeLayout(false);
            this.gBoxStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSimulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picBoxWall;
        private System.Windows.Forms.Timer animationLoopTimer;
        private System.Windows.Forms.PictureBox picBoxFireExtinguisher;
        private System.Windows.Forms.PictureBox picBoxFire;
        private System.Windows.Forms.PictureBox picBoxEraser;
        private System.Windows.Forms.PictureBox picBoxPerson;
        private System.Windows.Forms.PictureBox picBoxPlayPause;
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
        private System.Windows.Forms.GroupBox gBoxSettings;
        private System.Windows.Forms.Label lblImportFileLoc;
        private System.Windows.Forms.Button btnUploadFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveLayout;
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
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.PictureBox pbSimulation;
		private System.Windows.Forms.ToolTip toolTipImport;
		private System.Windows.Forms.ToolTip toolTipSave;
        private System.Windows.Forms.Label lblAlive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTerminate;
        private System.Windows.Forms.Button btnCalculatePaths;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblMaxFireEx;
        private System.Windows.Forms.Label lblMaxPeople;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
    }
}

