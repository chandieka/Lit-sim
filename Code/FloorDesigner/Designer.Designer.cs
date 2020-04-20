namespace FloorDesigner
{
	partial class Designer
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
			this.rbErase = new System.Windows.Forms.RadioButton();
			this.rbWall = new System.Windows.Forms.RadioButton();
			this.rbFloor = new System.Windows.Forms.RadioButton();
			this.rbFire = new System.Windows.Forms.RadioButton();
			this.rbPerson = new System.Windows.Forms.RadioButton();
			this.pictureBoxGrid = new System.Windows.Forms.PictureBox();
			this.lblEscMessage = new System.Windows.Forms.Label();
			this.rbFireExtinguisher = new System.Windows.Forms.RadioButton();
			this.groupBoxItems.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBoxItems
			// 
			this.groupBoxItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBoxItems.Controls.Add(this.rbFireExtinguisher);
			this.groupBoxItems.Controls.Add(this.rbErase);
			this.groupBoxItems.Controls.Add(this.rbWall);
			this.groupBoxItems.Controls.Add(this.rbFloor);
			this.groupBoxItems.Controls.Add(this.rbFire);
			this.groupBoxItems.Controls.Add(this.rbPerson);
			this.groupBoxItems.Location = new System.Drawing.Point(13, 13);
			this.groupBoxItems.Name = "groupBoxItems";
			this.groupBoxItems.Size = new System.Drawing.Size(200, 398);
			this.groupBoxItems.TabIndex = 0;
			this.groupBoxItems.TabStop = false;
			this.groupBoxItems.Text = "Items";
			// 
			// rbErase
			// 
			this.rbErase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.rbErase.AutoSize = true;
			this.rbErase.Location = new System.Drawing.Point(7, 375);
			this.rbErase.Name = "rbErase";
			this.rbErase.Size = new System.Drawing.Size(52, 17);
			this.rbErase.TabIndex = 9;
			this.rbErase.Text = "Erase";
			this.rbErase.UseVisualStyleBackColor = true;
			// 
			// rbWall
			// 
			this.rbWall.AutoSize = true;
			this.rbWall.Location = new System.Drawing.Point(6, 42);
			this.rbWall.Name = "rbWall";
			this.rbWall.Size = new System.Drawing.Size(46, 17);
			this.rbWall.TabIndex = 1;
			this.rbWall.TabStop = true;
			this.rbWall.Text = "Wall";
			this.rbWall.UseVisualStyleBackColor = true;
			this.rbWall.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged_Reset);
			// 
			// rbFloor
			// 
			this.rbFloor.AutoSize = true;
			this.rbFloor.Checked = true;
			this.rbFloor.Location = new System.Drawing.Point(7, 19);
			this.rbFloor.Name = "rbFloor";
			this.rbFloor.Size = new System.Drawing.Size(48, 17);
			this.rbFloor.TabIndex = 0;
			this.rbFloor.TabStop = true;
			this.rbFloor.Text = "Floor";
			this.rbFloor.UseVisualStyleBackColor = true;
			this.rbFloor.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged_Reset);
			// 
			// rbFire
			// 
			this.rbFire.AutoSize = true;
			this.rbFire.Location = new System.Drawing.Point(6, 65);
			this.rbFire.Name = "rbFire";
			this.rbFire.Size = new System.Drawing.Size(42, 17);
			this.rbFire.TabIndex = 2;
			this.rbFire.Text = "Fire";
			this.rbFire.UseVisualStyleBackColor = true;
			this.rbFire.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged_Reset);
			// 
			// rbPerson
			// 
			this.rbPerson.AutoSize = true;
			this.rbPerson.Location = new System.Drawing.Point(6, 88);
			this.rbPerson.Name = "rbPerson";
			this.rbPerson.Size = new System.Drawing.Size(58, 17);
			this.rbPerson.TabIndex = 3;
			this.rbPerson.Text = "Person";
			this.rbPerson.UseVisualStyleBackColor = true;
			this.rbPerson.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged_Reset);
			// 
			// pictureBoxGrid
			// 
			this.pictureBoxGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxGrid.Location = new System.Drawing.Point(219, 13);
			this.pictureBoxGrid.Name = "pictureBoxGrid";
			this.pictureBoxGrid.Size = new System.Drawing.Size(569, 425);
			this.pictureBoxGrid.TabIndex = 1;
			this.pictureBoxGrid.TabStop = false;
			this.pictureBoxGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxGrid_Paint);
			this.pictureBoxGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGrid_MouseClick);
			this.pictureBoxGrid.Resize += new System.EventHandler(this.pictureBoxGrid_Resize);
			// 
			// lblEscMessage
			// 
			this.lblEscMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblEscMessage.AutoSize = true;
			this.lblEscMessage.Location = new System.Drawing.Point(13, 425);
			this.lblEscMessage.Name = "lblEscMessage";
			this.lblEscMessage.Size = new System.Drawing.Size(155, 13);
			this.lblEscMessage.TabIndex = 2;
			this.lblEscMessage.Text = "Press the ESC button to cancel";
			this.lblEscMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblEscMessage.Visible = false;
			// 
			// rbFireExtinguisher
			// 
			this.rbFireExtinguisher.AutoSize = true;
			this.rbFireExtinguisher.Location = new System.Drawing.Point(6, 111);
			this.rbFireExtinguisher.Name = "rbFireExtinguisher";
			this.rbFireExtinguisher.Size = new System.Drawing.Size(101, 17);
			this.rbFireExtinguisher.TabIndex = 4;
			this.rbFireExtinguisher.Text = "Fire extinguisher";
			this.rbFireExtinguisher.UseVisualStyleBackColor = true;
			// 
			// Designer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.lblEscMessage);
			this.Controls.Add(this.pictureBoxGrid);
			this.Controls.Add(this.groupBoxItems);
			this.KeyPreview = true;
			this.Name = "Designer";
			this.Text = "Lit floor designer";
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Designer_KeyUp);
			this.groupBoxItems.ResumeLayout(false);
			this.groupBoxItems.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxItems;
		private System.Windows.Forms.PictureBox pictureBoxGrid;
		private System.Windows.Forms.RadioButton rbPerson;
		private System.Windows.Forms.RadioButton rbFire;
		private System.Windows.Forms.RadioButton rbFloor;
		private System.Windows.Forms.RadioButton rbWall;
		private System.Windows.Forms.Label lblEscMessage;
		private System.Windows.Forms.RadioButton rbErase;
		private System.Windows.Forms.RadioButton rbFireExtinguisher;
	}
}

