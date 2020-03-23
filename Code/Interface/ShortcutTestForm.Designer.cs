namespace Interface
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
			// ShortcutTestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(276, 69);
			this.Controls.Add(this.lblCtrlAltT);
			this.Controls.Add(this.lblCtrlO);
			this.KeyPreview = true;
			this.Name = "ShortcutTestForm";
			this.Text = "ShortcutTestForm";
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ShortcutTestForm_KeyUp);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblCtrlO;
		private System.Windows.Forms.Label lblCtrlAltT;
	}
}