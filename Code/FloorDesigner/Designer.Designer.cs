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
			this.rbFire = new System.Windows.Forms.RadioButton();
			this.rbPerson = new System.Windows.Forms.RadioButton();
			this.pictureBoxGrid = new System.Windows.Forms.PictureBox();
			this.rbFloor = new System.Windows.Forms.RadioButton();
			this.groupBoxItems.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBoxItems
			// 
			this.groupBoxItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBoxItems.Controls.Add(this.rbFloor);
			this.groupBoxItems.Controls.Add(this.rbFire);
			this.groupBoxItems.Controls.Add(this.rbPerson);
			this.groupBoxItems.Location = new System.Drawing.Point(13, 13);
			this.groupBoxItems.Name = "groupBoxItems";
			this.groupBoxItems.Size = new System.Drawing.Size(200, 425);
			this.groupBoxItems.TabIndex = 0;
			this.groupBoxItems.TabStop = false;
			this.groupBoxItems.Text = "Items";
			// 
			// rbFire
			// 
			this.rbFire.AutoSize = true;
			this.rbFire.Location = new System.Drawing.Point(7, 43);
			this.rbFire.Name = "rbFire";
			this.rbFire.Size = new System.Drawing.Size(42, 17);
			this.rbFire.TabIndex = 1;
			this.rbFire.TabStop = true;
			this.rbFire.Text = "Fire";
			this.rbFire.UseVisualStyleBackColor = true;
			// 
			// rbPerson
			// 
			this.rbPerson.AutoSize = true;
			this.rbPerson.Location = new System.Drawing.Point(7, 20);
			this.rbPerson.Name = "rbPerson";
			this.rbPerson.Size = new System.Drawing.Size(58, 17);
			this.rbPerson.TabIndex = 0;
			this.rbPerson.TabStop = true;
			this.rbPerson.Text = "Person";
			this.rbPerson.UseVisualStyleBackColor = true;
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
			// rbFloor
			// 
			this.rbFloor.AutoSize = true;
			this.rbFloor.Location = new System.Drawing.Point(6, 66);
			this.rbFloor.Name = "rbFloor";
			this.rbFloor.Size = new System.Drawing.Size(48, 17);
			this.rbFloor.TabIndex = 2;
			this.rbFloor.TabStop = true;
			this.rbFloor.Text = "Floor";
			this.rbFloor.UseVisualStyleBackColor = true;
			// 
			// Designer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.pictureBoxGrid);
			this.Controls.Add(this.groupBoxItems);
			this.Name = "Designer";
			this.Text = "Lit floor designer";
			this.groupBoxItems.ResumeLayout(false);
			this.groupBoxItems.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxItems;
		private System.Windows.Forms.PictureBox pictureBoxGrid;
		private System.Windows.Forms.RadioButton rbPerson;
		private System.Windows.Forms.RadioButton rbFire;
		private System.Windows.Forms.RadioButton rbFloor;
	}
}

