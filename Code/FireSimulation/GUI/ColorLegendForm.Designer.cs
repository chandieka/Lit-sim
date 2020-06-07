namespace FireSimulator.GUI
{
	partial class ColorLegendForm
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
			this.gbFloorplan = new System.Windows.Forms.GroupBox();
			this.lblWall = new System.Windows.Forms.Label();
			this.lblFloor = new System.Windows.Forms.Label();
			this.lblWallDesc = new System.Windows.Forms.Label();
			this.lblFloorDesc = new System.Windows.Forms.Label();
			this.lblVoid = new System.Windows.Forms.Label();
			this.lblVoidDesc = new System.Windows.Forms.Label();
			this.gbLayout = new System.Windows.Forms.GroupBox();
			this.gbPerson = new System.Windows.Forms.GroupBox();
			this.lblPersonCalculating = new System.Windows.Forms.Label();
			this.lblPersonCalculatingDesc = new System.Windows.Forms.Label();
			this.lblPersonFETaken = new System.Windows.Forms.Label();
			this.lblPersonFETakenDesc = new System.Windows.Forms.Label();
			this.lblPersonHasFE = new System.Windows.Forms.Label();
			this.lblPersonHasFEDesc = new System.Windows.Forms.Label();
			this.lblPersonDead = new System.Windows.Forms.Label();
			this.lblPersonDeadDesc = new System.Windows.Forms.Label();
			this.lblPersonDefault = new System.Windows.Forms.Label();
			this.lblPersonDefaultDesc = new System.Windows.Forms.Label();
			this.lblFE = new System.Windows.Forms.Label();
			this.lblFEDesc = new System.Windows.Forms.Label();
			this.lblFire = new System.Windows.Forms.Label();
			this.lblFireDesc = new System.Windows.Forms.Label();
			this.gbFloorplan.SuspendLayout();
			this.gbLayout.SuspendLayout();
			this.gbPerson.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbFloorplan
			// 
			this.gbFloorplan.Controls.Add(this.lblWall);
			this.gbFloorplan.Controls.Add(this.lblFloor);
			this.gbFloorplan.Controls.Add(this.lblWallDesc);
			this.gbFloorplan.Controls.Add(this.lblFloorDesc);
			this.gbFloorplan.Controls.Add(this.lblVoid);
			this.gbFloorplan.Controls.Add(this.lblVoidDesc);
			this.gbFloorplan.Location = new System.Drawing.Point(13, 13);
			this.gbFloorplan.Name = "gbFloorplan";
			this.gbFloorplan.Size = new System.Drawing.Size(79, 100);
			this.gbFloorplan.TabIndex = 0;
			this.gbFloorplan.TabStop = false;
			this.gbFloorplan.Text = "Floorplan";
			// 
			// lblWall
			// 
			this.lblWall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblWall.BackColor = System.Drawing.Color.Black;
			this.lblWall.Location = new System.Drawing.Point(6, 69);
			this.lblWall.Name = "lblWall";
			this.lblWall.Size = new System.Drawing.Size(30, 10);
			this.lblWall.TabIndex = 3;
			// 
			// lblFloor
			// 
			this.lblFloor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFloor.BackColor = System.Drawing.Color.White;
			this.lblFloor.Location = new System.Drawing.Point(6, 47);
			this.lblFloor.Name = "lblFloor";
			this.lblFloor.Size = new System.Drawing.Size(30, 10);
			this.lblFloor.TabIndex = 3;
			// 
			// lblWallDesc
			// 
			this.lblWallDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblWallDesc.AutoSize = true;
			this.lblWallDesc.Location = new System.Drawing.Point(45, 66);
			this.lblWallDesc.Name = "lblWallDesc";
			this.lblWallDesc.Size = new System.Drawing.Size(28, 13);
			this.lblWallDesc.TabIndex = 2;
			this.lblWallDesc.Text = "Wall";
			this.lblWallDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblFloorDesc
			// 
			this.lblFloorDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFloorDesc.AutoSize = true;
			this.lblFloorDesc.Location = new System.Drawing.Point(43, 44);
			this.lblFloorDesc.Name = "lblFloorDesc";
			this.lblFloorDesc.Size = new System.Drawing.Size(30, 13);
			this.lblFloorDesc.TabIndex = 2;
			this.lblFloorDesc.Text = "Floor";
			this.lblFloorDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblVoid
			// 
			this.lblVoid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblVoid.BackColor = System.Drawing.Color.DarkGray;
			this.lblVoid.Location = new System.Drawing.Point(6, 23);
			this.lblVoid.Name = "lblVoid";
			this.lblVoid.Size = new System.Drawing.Size(30, 10);
			this.lblVoid.TabIndex = 1;
			// 
			// lblVoidDesc
			// 
			this.lblVoidDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblVoidDesc.AutoSize = true;
			this.lblVoidDesc.Location = new System.Drawing.Point(45, 20);
			this.lblVoidDesc.Name = "lblVoidDesc";
			this.lblVoidDesc.Size = new System.Drawing.Size(28, 13);
			this.lblVoidDesc.TabIndex = 0;
			this.lblVoidDesc.Text = "Void";
			this.lblVoidDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// gbLayout
			// 
			this.gbLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.gbLayout.Controls.Add(this.gbPerson);
			this.gbLayout.Controls.Add(this.lblFE);
			this.gbLayout.Controls.Add(this.lblFEDesc);
			this.gbLayout.Controls.Add(this.lblFire);
			this.gbLayout.Controls.Add(this.lblFireDesc);
			this.gbLayout.Location = new System.Drawing.Point(98, 13);
			this.gbLayout.Name = "gbLayout";
			this.gbLayout.Size = new System.Drawing.Size(126, 204);
			this.gbLayout.TabIndex = 4;
			this.gbLayout.TabStop = false;
			this.gbLayout.Text = "Layout";
			// 
			// gbPerson
			// 
			this.gbPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbPerson.Controls.Add(this.lblPersonCalculating);
			this.gbPerson.Controls.Add(this.lblPersonCalculatingDesc);
			this.gbPerson.Controls.Add(this.lblPersonFETaken);
			this.gbPerson.Controls.Add(this.lblPersonFETakenDesc);
			this.gbPerson.Controls.Add(this.lblPersonHasFE);
			this.gbPerson.Controls.Add(this.lblPersonHasFEDesc);
			this.gbPerson.Controls.Add(this.lblPersonDead);
			this.gbPerson.Controls.Add(this.lblPersonDeadDesc);
			this.gbPerson.Controls.Add(this.lblPersonDefault);
			this.gbPerson.Controls.Add(this.lblPersonDefaultDesc);
			this.gbPerson.Location = new System.Drawing.Point(6, 69);
			this.gbPerson.Name = "gbPerson";
			this.gbPerson.Size = new System.Drawing.Size(113, 129);
			this.gbPerson.TabIndex = 4;
			this.gbPerson.TabStop = false;
			this.gbPerson.Text = "Person";
			// 
			// lblPersonCalculating
			// 
			this.lblPersonCalculating.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPersonCalculating.BackColor = System.Drawing.Color.MediumPurple;
			this.lblPersonCalculating.Location = new System.Drawing.Point(6, 109);
			this.lblPersonCalculating.Name = "lblPersonCalculating";
			this.lblPersonCalculating.Size = new System.Drawing.Size(35, 10);
			this.lblPersonCalculating.TabIndex = 13;
			// 
			// lblPersonCalculatingDesc
			// 
			this.lblPersonCalculatingDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPersonCalculatingDesc.AutoSize = true;
			this.lblPersonCalculatingDesc.Location = new System.Drawing.Point(48, 106);
			this.lblPersonCalculatingDesc.Name = "lblPersonCalculatingDesc";
			this.lblPersonCalculatingDesc.Size = new System.Drawing.Size(59, 13);
			this.lblPersonCalculatingDesc.TabIndex = 12;
			this.lblPersonCalculatingDesc.Text = "Calculating";
			this.lblPersonCalculatingDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblPersonFETaken
			// 
			this.lblPersonFETaken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPersonFETaken.BackColor = System.Drawing.Color.BurlyWood;
			this.lblPersonFETaken.Location = new System.Drawing.Point(6, 86);
			this.lblPersonFETaken.Name = "lblPersonFETaken";
			this.lblPersonFETaken.Size = new System.Drawing.Size(35, 10);
			this.lblPersonFETaken.TabIndex = 11;
			// 
			// lblPersonFETakenDesc
			// 
			this.lblPersonFETakenDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPersonFETakenDesc.AutoSize = true;
			this.lblPersonFETakenDesc.Location = new System.Drawing.Point(57, 83);
			this.lblPersonFETakenDesc.Name = "lblPersonFETakenDesc";
			this.lblPersonFETakenDesc.Size = new System.Drawing.Size(50, 13);
			this.lblPersonFETakenDesc.TabIndex = 10;
			this.lblPersonFETakenDesc.Text = "FE taken";
			this.lblPersonFETakenDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblPersonHasFE
			// 
			this.lblPersonHasFE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPersonHasFE.BackColor = System.Drawing.Color.DeepPink;
			this.lblPersonHasFE.Location = new System.Drawing.Point(6, 63);
			this.lblPersonHasFE.Name = "lblPersonHasFE";
			this.lblPersonHasFE.Size = new System.Drawing.Size(35, 10);
			this.lblPersonHasFE.TabIndex = 9;
			// 
			// lblPersonHasFEDesc
			// 
			this.lblPersonHasFEDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPersonHasFEDesc.AutoSize = true;
			this.lblPersonHasFEDesc.Location = new System.Drawing.Point(65, 60);
			this.lblPersonHasFEDesc.Name = "lblPersonHasFEDesc";
			this.lblPersonHasFEDesc.Size = new System.Drawing.Size(42, 13);
			this.lblPersonHasFEDesc.TabIndex = 8;
			this.lblPersonHasFEDesc.Text = "Has FE";
			this.lblPersonHasFEDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblPersonDead
			// 
			this.lblPersonDead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPersonDead.BackColor = System.Drawing.Color.Orange;
			this.lblPersonDead.Location = new System.Drawing.Point(6, 40);
			this.lblPersonDead.Name = "lblPersonDead";
			this.lblPersonDead.Size = new System.Drawing.Size(35, 10);
			this.lblPersonDead.TabIndex = 7;
			// 
			// lblPersonDeadDesc
			// 
			this.lblPersonDeadDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPersonDeadDesc.AutoSize = true;
			this.lblPersonDeadDesc.Location = new System.Drawing.Point(74, 37);
			this.lblPersonDeadDesc.Name = "lblPersonDeadDesc";
			this.lblPersonDeadDesc.Size = new System.Drawing.Size(33, 13);
			this.lblPersonDeadDesc.TabIndex = 6;
			this.lblPersonDeadDesc.Text = "Dead";
			this.lblPersonDeadDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblPersonDefault
			// 
			this.lblPersonDefault.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPersonDefault.BackColor = System.Drawing.Color.Blue;
			this.lblPersonDefault.Location = new System.Drawing.Point(6, 19);
			this.lblPersonDefault.Name = "lblPersonDefault";
			this.lblPersonDefault.Size = new System.Drawing.Size(35, 10);
			this.lblPersonDefault.TabIndex = 5;
			// 
			// lblPersonDefaultDesc
			// 
			this.lblPersonDefaultDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPersonDefaultDesc.AutoSize = true;
			this.lblPersonDefaultDesc.Location = new System.Drawing.Point(66, 16);
			this.lblPersonDefaultDesc.Name = "lblPersonDefaultDesc";
			this.lblPersonDefaultDesc.Size = new System.Drawing.Size(41, 13);
			this.lblPersonDefaultDesc.TabIndex = 4;
			this.lblPersonDefaultDesc.Text = "Default";
			this.lblPersonDefaultDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblFE
			// 
			this.lblFE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFE.BackColor = System.Drawing.Color.Green;
			this.lblFE.Location = new System.Drawing.Point(6, 47);
			this.lblFE.Name = "lblFE";
			this.lblFE.Size = new System.Drawing.Size(67, 10);
			this.lblFE.TabIndex = 3;
			// 
			// lblFEDesc
			// 
			this.lblFEDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFEDesc.AutoSize = true;
			this.lblFEDesc.Location = new System.Drawing.Point(76, 44);
			this.lblFEDesc.Name = "lblFEDesc";
			this.lblFEDesc.Size = new System.Drawing.Size(44, 13);
			this.lblFEDesc.TabIndex = 2;
			this.lblFEDesc.Text = "Fire ext.";
			this.lblFEDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblFire
			// 
			this.lblFire.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFire.BackColor = System.Drawing.Color.Red;
			this.lblFire.Location = new System.Drawing.Point(6, 23);
			this.lblFire.Name = "lblFire";
			this.lblFire.Size = new System.Drawing.Size(67, 10);
			this.lblFire.TabIndex = 1;
			// 
			// lblFireDesc
			// 
			this.lblFireDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFireDesc.AutoSize = true;
			this.lblFireDesc.Location = new System.Drawing.Point(96, 20);
			this.lblFireDesc.Name = "lblFireDesc";
			this.lblFireDesc.Size = new System.Drawing.Size(24, 13);
			this.lblFireDesc.TabIndex = 0;
			this.lblFireDesc.Text = "Fire";
			this.lblFireDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ColorLegendForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(236, 224);
			this.Controls.Add(this.gbLayout);
			this.Controls.Add(this.gbFloorplan);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ColorLegendForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Lit - Legend";
			this.gbFloorplan.ResumeLayout(false);
			this.gbFloorplan.PerformLayout();
			this.gbLayout.ResumeLayout(false);
			this.gbLayout.PerformLayout();
			this.gbPerson.ResumeLayout(false);
			this.gbPerson.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbFloorplan;
		private System.Windows.Forms.Label lblWall;
		private System.Windows.Forms.Label lblFloor;
		private System.Windows.Forms.Label lblWallDesc;
		private System.Windows.Forms.Label lblFloorDesc;
		private System.Windows.Forms.Label lblVoid;
		private System.Windows.Forms.Label lblVoidDesc;
		private System.Windows.Forms.GroupBox gbLayout;
		private System.Windows.Forms.Label lblFE;
		private System.Windows.Forms.Label lblFEDesc;
		private System.Windows.Forms.Label lblFire;
		private System.Windows.Forms.Label lblFireDesc;
		private System.Windows.Forms.GroupBox gbPerson;
		private System.Windows.Forms.Label lblPersonDefault;
		private System.Windows.Forms.Label lblPersonDefaultDesc;
		private System.Windows.Forms.Label lblPersonDead;
		private System.Windows.Forms.Label lblPersonDeadDesc;
		private System.Windows.Forms.Label lblPersonHasFE;
		private System.Windows.Forms.Label lblPersonHasFEDesc;
		private System.Windows.Forms.Label lblPersonFETaken;
		private System.Windows.Forms.Label lblPersonFETakenDesc;
		private System.Windows.Forms.Label lblPersonCalculating;
		private System.Windows.Forms.Label lblPersonCalculatingDesc;
	}
}