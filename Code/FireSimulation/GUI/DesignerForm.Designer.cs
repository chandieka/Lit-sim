using System;

namespace FireSimulator
{
	partial class DesignerForm
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
            this.gbItems = new System.Windows.Forms.GroupBox();
            this.cbGrid = new System.Windows.Forms.CheckBox();
            this.picBoxReset = new System.Windows.Forms.PictureBox();
            this.picBoxFloor = new System.Windows.Forms.PictureBox();
            this.picBoxWall = new System.Windows.Forms.PictureBox();
            this.picBoxFire = new System.Windows.Forms.PictureBox();
            this.picBoxFireExtinguisher = new System.Windows.Forms.PictureBox();
            this.picBoxEraser = new System.Windows.Forms.PictureBox();
            this.picBoxPerson = new System.Windows.Forms.PictureBox();
            this.lblEscMessage = new System.Windows.Forms.Label();
            this.gbShortcuts = new System.Windows.Forms.GroupBox();
            this.lblSCSave = new System.Windows.Forms.Label();
            this.lblSCSaveDesc = new System.Windows.Forms.Label();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblImportFileLoc = new System.Windows.Forms.Label();
            this.pictureBoxGrid = new System.Windows.Forms.PictureBox();
            this.gbHistory = new System.Windows.Forms.GroupBox();
            this.lbHistory = new System.Windows.Forms.ListBox();
            this.gbGenerate = new System.Windows.Forms.GroupBox();
            this.tbPeople = new System.Windows.Forms.TextBox();
            this.tbFireExtinguishers = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblTools = new System.Windows.Forms.Label();
            this.lblGenerate = new System.Windows.Forms.Label();
            this.gbItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFireExtinguisher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEraser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPerson)).BeginInit();
            this.gbShortcuts.SuspendLayout();
            this.gbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrid)).BeginInit();
            this.gbHistory.SuspendLayout();
            this.gbGenerate.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbItems
            // 
            this.gbItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbItems.Controls.Add(this.cbGrid);
            this.gbItems.Controls.Add(this.picBoxReset);
            this.gbItems.Controls.Add(this.lblGenerate);
            this.gbItems.Controls.Add(this.picBoxFloor);
            this.gbItems.Controls.Add(this.picBoxWall);
            this.gbItems.Controls.Add(this.picBoxFire);
            this.gbItems.Controls.Add(this.picBoxFireExtinguisher);
            this.gbItems.Controls.Add(this.picBoxEraser);
            this.gbItems.Controls.Add(this.picBoxPerson);
            this.gbItems.Location = new System.Drawing.Point(17, 16);
            this.gbItems.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbItems.Name = "gbItems";
            this.gbItems.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbItems.Size = new System.Drawing.Size(175, 662);
            this.gbItems.TabIndex = 0;
            this.gbItems.TabStop = false;
            this.gbItems.Text = "Tools";
            // 
            // cbGrid
            // 
            this.cbGrid.AutoSize = true;
            this.cbGrid.Location = new System.Drawing.Point(35, 622);
            this.cbGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbGrid.Name = "cbGrid";
            this.cbGrid.Size = new System.Drawing.Size(90, 21);
            this.cbGrid.TabIndex = 28;
            this.cbGrid.Text = "Draw grid";
            this.cbGrid.UseVisualStyleBackColor = true;
            this.cbGrid.CheckedChanged += new System.EventHandler(this.cbGrid_CheckedChanged);
            // 
            // picBoxReset
            // 
            this.picBoxReset.BackColor = System.Drawing.Color.Transparent;
            this.picBoxReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxReset.Image = global::FireSimulator.Icons.reset;
            this.picBoxReset.InitialImage = null;
            this.picBoxReset.Location = new System.Drawing.Point(51, 542);
            this.picBoxReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBoxReset.Name = "picBoxReset";
            this.picBoxReset.Size = new System.Drawing.Size(75, 75);
            this.picBoxReset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxReset.TabIndex = 22;
            this.picBoxReset.TabStop = false;
            this.picBoxReset.Click += new System.EventHandler(this.pbReset_Click);
            // 
            // picBoxFloor
            // 
            this.picBoxFloor.BackColor = System.Drawing.Color.Transparent;
            this.picBoxFloor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxFloor.ErrorImage = global::FireSimulator.Icons.Floor_unavailable;
            this.picBoxFloor.Image = global::FireSimulator.Icons.fabric;
            this.picBoxFloor.InitialImage = null;
            this.picBoxFloor.Location = new System.Drawing.Point(51, 22);
            this.picBoxFloor.Margin = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.picBoxFloor.Name = "picBoxFloor";
            this.picBoxFloor.Size = new System.Drawing.Size(75, 75);
            this.picBoxFloor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxFloor.TabIndex = 21;
            this.picBoxFloor.TabStop = false;
            this.picBoxFloor.Click += new System.EventHandler(this.picBoxDesigner_Click);
            // 
            // picBoxWall
            // 
            this.picBoxWall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxWall.ErrorImage = global::FireSimulator.Icons.Wall_unavailable;
            this.picBoxWall.Image = global::FireSimulator.Icons.Wall;
            this.picBoxWall.Location = new System.Drawing.Point(51, 110);
            this.picBoxWall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 10);
            this.picBoxWall.Name = "picBoxWall";
            this.picBoxWall.Size = new System.Drawing.Size(75, 75);
            this.picBoxWall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxWall.TabIndex = 2;
            this.picBoxWall.TabStop = false;
            this.picBoxWall.Click += new System.EventHandler(this.picBoxDesigner_Click);
            // 
            // picBoxFire
            // 
            this.picBoxFire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxFire.ErrorImage = global::FireSimulator.Icons.Fire_unavailable;
            this.picBoxFire.Image = global::FireSimulator.Icons.Fire;
            this.picBoxFire.Location = new System.Drawing.Point(51, 368);
            this.picBoxFire.Margin = new System.Windows.Forms.Padding(3, 2, 3, 10);
            this.picBoxFire.Name = "picBoxFire";
            this.picBoxFire.Size = new System.Drawing.Size(75, 75);
            this.picBoxFire.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxFire.TabIndex = 6;
            this.picBoxFire.TabStop = false;
            this.picBoxFire.Click += new System.EventHandler(this.picBoxDesigner_Click);
            // 
            // picBoxFireExtinguisher
            // 
            this.picBoxFireExtinguisher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxFireExtinguisher.ErrorImage = global::FireSimulator.Icons.Fire_extinguisher_unavailable;
            this.picBoxFireExtinguisher.Image = global::FireSimulator.Icons.Fire_extinguisher;
            this.picBoxFireExtinguisher.Location = new System.Drawing.Point(51, 455);
            this.picBoxFireExtinguisher.Margin = new System.Windows.Forms.Padding(3, 2, 3, 10);
            this.picBoxFireExtinguisher.Name = "picBoxFireExtinguisher";
            this.picBoxFireExtinguisher.Size = new System.Drawing.Size(75, 75);
            this.picBoxFireExtinguisher.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxFireExtinguisher.TabIndex = 5;
            this.picBoxFireExtinguisher.TabStop = false;
            this.picBoxFireExtinguisher.Click += new System.EventHandler(this.picBoxDesigner_Click);
            // 
            // picBoxEraser
            // 
            this.picBoxEraser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxEraser.Image = global::FireSimulator.Icons.Eraser;
            this.picBoxEraser.Location = new System.Drawing.Point(51, 196);
            this.picBoxEraser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 10);
            this.picBoxEraser.Name = "picBoxEraser";
            this.picBoxEraser.Size = new System.Drawing.Size(75, 75);
            this.picBoxEraser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxEraser.TabIndex = 7;
            this.picBoxEraser.TabStop = false;
            this.picBoxEraser.Click += new System.EventHandler(this.picBoxDesigner_Click);
            // 
            // picBoxPerson
            // 
            this.picBoxPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxPerson.ErrorImage = global::FireSimulator.Icons.Person_unavailable;
            this.picBoxPerson.Image = global::FireSimulator.Icons.Person;
            this.picBoxPerson.Location = new System.Drawing.Point(51, 283);
            this.picBoxPerson.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBoxPerson.Name = "picBoxPerson";
            this.picBoxPerson.Size = new System.Drawing.Size(75, 75);
            this.picBoxPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxPerson.TabIndex = 8;
            this.picBoxPerson.TabStop = false;
            this.picBoxPerson.Click += new System.EventHandler(this.picBoxDesigner_Click);
            // 
            // lblEscMessage
            // 
            this.lblEscMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEscMessage.AutoSize = true;
            this.lblEscMessage.Location = new System.Drawing.Point(17, 695);
            this.lblEscMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEscMessage.Name = "lblEscMessage";
            this.lblEscMessage.Size = new System.Drawing.Size(204, 17);
            this.lblEscMessage.TabIndex = 2;
            this.lblEscMessage.Text = "Press the ESC button to cancel";
            this.lblEscMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEscMessage.Visible = false;
            // 
            // gbShortcuts
            // 
            this.gbShortcuts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbShortcuts.Controls.Add(this.lblSCSave);
            this.gbShortcuts.Controls.Add(this.lblSCSaveDesc);
            this.gbShortcuts.Location = new System.Drawing.Point(967, 16);
            this.gbShortcuts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbShortcuts.Name = "gbShortcuts";
            this.gbShortcuts.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbShortcuts.Size = new System.Drawing.Size(267, 170);
            this.gbShortcuts.TabIndex = 22;
            this.gbShortcuts.TabStop = false;
            this.gbShortcuts.Text = "Shortcuts";
            // 
            // lblSCSave
            // 
            this.lblSCSave.AutoSize = true;
            this.lblSCSave.Location = new System.Drawing.Point(179, 76);
            this.lblSCSave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSCSave.Name = "lblSCSave";
            this.lblSCSave.Size = new System.Drawing.Size(69, 17);
            this.lblSCSave.TabIndex = 29;
            this.lblSCSave.Text = "CTRL + S";
            // 
            // lblSCSaveDesc
            // 
            this.lblSCSaveDesc.AutoSize = true;
            this.lblSCSaveDesc.Location = new System.Drawing.Point(9, 76);
            this.lblSCSaveDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSCSaveDesc.Name = "lblSCSaveDesc";
            this.lblSCSaveDesc.Size = new System.Drawing.Size(125, 17);
            this.lblSCSaveDesc.TabIndex = 23;
            this.lblSCSaveDesc.Text = "Save Session Map";
            // 
            // gbOptions
            // 
            this.gbOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOptions.Controls.Add(this.btnCancel);
            this.gbOptions.Controls.Add(this.btnSave);
            this.gbOptions.Location = new System.Drawing.Point(967, 199);
            this.gbOptions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOptions.Size = new System.Drawing.Size(267, 178);
            this.gbOptions.TabIndex = 23;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Options";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(12, 100);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(247, 62);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(13, 30);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(247, 62);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblImportFileLoc
            // 
            this.lblImportFileLoc.Location = new System.Drawing.Point(0, 0);
            this.lblImportFileLoc.Name = "lblImportFileLoc";
            this.lblImportFileLoc.Size = new System.Drawing.Size(100, 23);
            this.lblImportFileLoc.TabIndex = 0;
            // 
            // pictureBoxGrid
            // 
            this.pictureBoxGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxGrid.Location = new System.Drawing.Point(213, 16);
            this.pictureBoxGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxGrid.Name = "pictureBoxGrid";
            this.pictureBoxGrid.Size = new System.Drawing.Size(728, 662);
            this.pictureBoxGrid.TabIndex = 1;
            this.pictureBoxGrid.TabStop = false;
            this.pictureBoxGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxGrid_Paint);
            this.pictureBoxGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGrid_MouseClick);
            this.pictureBoxGrid.Resize += new System.EventHandler(this.pictureBoxGrid_Resize);
            // 
            // gbHistory
            // 
            this.gbHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbHistory.Controls.Add(this.lbHistory);
            this.gbHistory.Location = new System.Drawing.Point(967, 385);
            this.gbHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbHistory.Name = "gbHistory";
            this.gbHistory.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbHistory.Size = new System.Drawing.Size(267, 293);
            this.gbHistory.TabIndex = 24;
            this.gbHistory.TabStop = false;
            this.gbHistory.Text = "History";
            // 
            // lbHistory
            // 
            this.lbHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHistory.FormattingEnabled = true;
            this.lbHistory.ItemHeight = 16;
            this.lbHistory.Location = new System.Drawing.Point(9, 20);
            this.lbHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbHistory.Name = "lbHistory";
            this.lbHistory.Size = new System.Drawing.Size(248, 260);
            this.lbHistory.TabIndex = 19;
            this.lbHistory.SelectedIndexChanged += new System.EventHandler(this.lbHistory_SelectedIndexChanged);
            // 
            // gbGenerate
            // 
            this.gbGenerate.Controls.Add(this.btnGenerate);
            this.gbGenerate.Controls.Add(this.lblTools);
            this.gbGenerate.Controls.Add(this.label2);
            this.gbGenerate.Controls.Add(this.label1);
            this.gbGenerate.Controls.Add(this.tbFireExtinguishers);
            this.gbGenerate.Controls.Add(this.tbPeople);
            this.gbGenerate.Location = new System.Drawing.Point(17, 16);
            this.gbGenerate.Name = "gbGenerate";
            this.gbGenerate.Size = new System.Drawing.Size(175, 302);
            this.gbGenerate.TabIndex = 29;
            this.gbGenerate.TabStop = false;
            this.gbGenerate.Text = "Generate";
            this.gbGenerate.Visible = false;
            // 
            // tbPeople
            // 
            this.tbPeople.Location = new System.Drawing.Point(23, 83);
            this.tbPeople.Name = "tbPeople";
            this.tbPeople.Size = new System.Drawing.Size(130, 22);
            this.tbPeople.TabIndex = 0;
            // 
            // tbFireExtinguishers
            // 
            this.tbFireExtinguishers.Location = new System.Drawing.Point(23, 155);
            this.tbFireExtinguishers.Name = "tbFireExtinguishers";
            this.tbFireExtinguishers.Size = new System.Drawing.Size(130, 22);
            this.tbFireExtinguishers.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "People";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fire extinguishers";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(23, 213);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(130, 41);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblTools
            // 
            this.lblTools.AutoSize = true;
            this.lblTools.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTools.Location = new System.Drawing.Point(110, 0);
            this.lblTools.Name = "lblTools";
            this.lblTools.Size = new System.Drawing.Size(43, 17);
            this.lblTools.TabIndex = 5;
            this.lblTools.Text = "Tools";
            this.lblTools.Visible = false;
            this.lblTools.Click += new System.EventHandler(this.lblTools_Click);
            // 
            // lblGenerate
            // 
            this.lblGenerate.AutoSize = true;
            this.lblGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGenerate.Location = new System.Drawing.Point(100, 0);
            this.lblGenerate.Name = "lblGenerate";
            this.lblGenerate.Size = new System.Drawing.Size(68, 17);
            this.lblGenerate.TabIndex = 6;
            this.lblGenerate.Text = "Generate";
            this.lblGenerate.Click += new System.EventHandler(this.lblGenerate_Click);
            // 
            // DesignerForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1280, 726);
            this.Controls.Add(this.gbGenerate);
            this.Controls.Add(this.gbHistory);
            this.Controls.Add(this.gbOptions);
            this.Controls.Add(this.gbShortcuts);
            this.Controls.Add(this.lblEscMessage);
            this.Controls.Add(this.pictureBoxGrid);
            this.Controls.Add(this.gbItems);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DesignerForm";
            this.Text = "Lit - Designer";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Designer_KeyUp);
            this.gbItems.ResumeLayout(false);
            this.gbItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFireExtinguisher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEraser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPerson)).EndInit();
            this.gbShortcuts.ResumeLayout(false);
            this.gbShortcuts.PerformLayout();
            this.gbOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrid)).EndInit();
            this.gbHistory.ResumeLayout(false);
            this.gbGenerate.ResumeLayout(false);
            this.gbGenerate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox gbItems;
		private System.Windows.Forms.PictureBox pictureBoxGrid;
		private System.Windows.Forms.Label lblEscMessage;
		private System.Windows.Forms.PictureBox picBoxReset;
		private System.Windows.Forms.PictureBox picBoxFloor;
		private System.Windows.Forms.PictureBox picBoxWall;
		private System.Windows.Forms.PictureBox picBoxFireExtinguisher;
		private System.Windows.Forms.PictureBox picBoxEraser;
		private System.Windows.Forms.PictureBox picBoxPerson;
		private System.Windows.Forms.PictureBox picBoxFire;
		private System.Windows.Forms.CheckBox cbGrid;
		private System.Windows.Forms.GroupBox gbShortcuts;
		private System.Windows.Forms.Label lblSCSave;
		private System.Windows.Forms.Label lblSCSaveDesc;
		private System.Windows.Forms.GroupBox gbOptions;
		private System.Windows.Forms.Label lblImportFileLoc;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.GroupBox gbHistory;
		private System.Windows.Forms.ListBox lbHistory;
        private System.Windows.Forms.GroupBox gbGenerate;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFireExtinguishers;
        private System.Windows.Forms.TextBox tbPeople;
        private System.Windows.Forms.Label lblTools;
        private System.Windows.Forms.Label lblGenerate;
    }
}

