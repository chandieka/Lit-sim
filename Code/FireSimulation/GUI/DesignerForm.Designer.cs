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
            this.groupBoxItems = new System.Windows.Forms.GroupBox();
            this.cbGrid = new System.Windows.Forms.CheckBox();
            this.lblEscMessage = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.gBoxSettings = new System.Windows.Forms.GroupBox();
            this.lblImportFileLoc = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBoxGrid = new System.Windows.Forms.PictureBox();
            this.picBoxReset = new System.Windows.Forms.PictureBox();
            this.picBoxFloor = new System.Windows.Forms.PictureBox();
            this.picBoxWall = new System.Windows.Forms.PictureBox();
            this.picBoxFire = new System.Windows.Forms.PictureBox();
            this.picBoxFireExtinguisher = new System.Windows.Forms.PictureBox();
            this.picBoxEraser = new System.Windows.Forms.PictureBox();
            this.picBoxPerson = new System.Windows.Forms.PictureBox();
            this.groupBoxItems.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFireExtinguisher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEraser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxItems
            // 
            this.groupBoxItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxItems.Controls.Add(this.cbGrid);
            this.groupBoxItems.Controls.Add(this.picBoxReset);
            this.groupBoxItems.Controls.Add(this.picBoxFloor);
            this.groupBoxItems.Controls.Add(this.picBoxWall);
            this.groupBoxItems.Controls.Add(this.picBoxFire);
            this.groupBoxItems.Controls.Add(this.picBoxFireExtinguisher);
            this.groupBoxItems.Controls.Add(this.picBoxEraser);
            this.groupBoxItems.Controls.Add(this.picBoxPerson);
            this.groupBoxItems.Location = new System.Drawing.Point(17, 16);
            this.groupBoxItems.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxItems.Name = "groupBoxItems";
            this.groupBoxItems.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxItems.Size = new System.Drawing.Size(175, 662);
            this.groupBoxItems.TabIndex = 0;
            this.groupBoxItems.TabStop = false;
            this.groupBoxItems.Text = "Items";
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(967, 16);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(267, 170);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(179, 76);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 17);
            this.label20.TabIndex = 29;
            this.label20.Text = "CTRL + S";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 76);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(125, 17);
            this.label17.TabIndex = 23;
            this.label17.Text = "Save Session Map";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 164);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 17);
            this.label9.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 21);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Shortcuts";
            // 
            // gBoxSettings
            // 
            this.gBoxSettings.Controls.Add(this.lblImportFileLoc);
            this.gBoxSettings.Controls.Add(this.btnCancel);
            this.gBoxSettings.Controls.Add(this.label1);
            this.gBoxSettings.Controls.Add(this.btnSave);
            this.gBoxSettings.Location = new System.Drawing.Point(967, 199);
            this.gBoxSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBoxSettings.Name = "gBoxSettings";
            this.gBoxSettings.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBoxSettings.Size = new System.Drawing.Size(267, 238);
            this.gBoxSettings.TabIndex = 23;
            this.gBoxSettings.TabStop = false;
            // 
            // lblImportFileLoc
            // 
            this.lblImportFileLoc.AutoSize = true;
            this.lblImportFileLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportFileLoc.Location = new System.Drawing.Point(8, 164);
            this.lblImportFileLoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImportFileLoc.Name = "lblImportFileLoc";
            this.lblImportFileLoc.Size = new System.Drawing.Size(0, 17);
            this.lblImportFileLoc.TabIndex = 18;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(12, 150);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(247, 62);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Options";
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(13, 70);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(247, 60);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBoxGrid
            // 
            this.pictureBoxGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxGrid.Location = new System.Drawing.Point(213, 16);
            this.pictureBoxGrid.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxGrid.Name = "pictureBoxGrid";
            this.pictureBoxGrid.Size = new System.Drawing.Size(728, 662);
            this.pictureBoxGrid.TabIndex = 1;
            this.pictureBoxGrid.TabStop = false;
            this.pictureBoxGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxGrid_Paint);
            this.pictureBoxGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGrid_MouseClick);
            this.pictureBoxGrid.Resize += new System.EventHandler(this.pictureBoxGrid_Resize);
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
            // DesignerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 726);
            this.Controls.Add(this.gBoxSettings);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblEscMessage);
            this.Controls.Add(this.pictureBoxGrid);
            this.Controls.Add(this.groupBoxItems);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DesignerForm";
            this.Text = "Lit - Designer";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Designer_KeyUp);
            this.groupBoxItems.ResumeLayout(false);
            this.groupBoxItems.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gBoxSettings.ResumeLayout(false);
            this.gBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFireExtinguisher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEraser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPerson)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxItems;
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
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox gBoxSettings;
		private System.Windows.Forms.Label lblImportFileLoc;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSave;
	}
}

