﻿namespace Interface
{
	partial class ShortcutTestForm
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
			this.lblCtrlO = new System.Windows.Forms.Label();
			this.lblCtrlAltT = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// lblCtrlO
			// 
			this.lblCtrlO.AutoSize = true;
			this.lblCtrlO.Location = new System.Drawing.Point(13, 13);
			this.lblCtrlO.Name = "lblCtrlO";
			this.lblCtrlO.Size = new System.Drawing.Size(173, 13);
			this.lblCtrlO.TabIndex = 0;
			this.lblCtrlO.Text = "Press CTRL+O to open a file dialog";
			// 
			// lblCtrlAltT
			// 
			this.lblCtrlAltT.AutoSize = true;
			this.lblCtrlAltT.Location = new System.Drawing.Point(13, 36);
			this.lblCtrlAltT.Name = "lblCtrlAltT";
			this.lblCtrlAltT.Size = new System.Drawing.Size(213, 13);
			this.lblCtrlAltT.TabIndex = 1;
			this.lblCtrlAltT.Text = "Press CTRL+ALT+T to cycle through colors";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Location = new System.Drawing.Point(12, 53);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(251, 321);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 381);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Start";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// ShortcutTestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(276, 407);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lblCtrlAltT);
			this.Controls.Add(this.lblCtrlO);
			this.KeyPreview = true;
			this.Name = "ShortcutTestForm";
			this.Text = "ShortcutTestForm";
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ShortcutTestForm_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblCtrlO;
		private System.Windows.Forms.Label lblCtrlAltT;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button1;
	}
}