﻿namespace FireSimulator
{
	partial class MainForm
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
            this.gbFloorplan = new System.Windows.Forms.GroupBox();
            this.pbFPOpen = new System.Windows.Forms.PictureBox();
            this.pbFPDelete = new System.Windows.Forms.PictureBox();
            this.pbFPCreate = new System.Windows.Forms.PictureBox();
            this.pbFPCopy = new System.Windows.Forms.PictureBox();
            this.lvFloorplan = new System.Windows.Forms.ListView();
            this.fpImageList = new System.Windows.Forms.ImageList(this.components);
            this.gbLayout = new System.Windows.Forms.GroupBox();
            this.pbLRun = new System.Windows.Forms.PictureBox();
            this.pbLDelete = new System.Windows.Forms.PictureBox();
            this.pbLCreate = new System.Windows.Forms.PictureBox();
            this.pbLCopy = new System.Windows.Forms.PictureBox();
            this.lvLayout = new System.Windows.Forms.ListView();
            this.lImageList = new System.Windows.Forms.ImageList(this.components);
            this.gbFloorplan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFPOpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFPDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFPCreate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFPCopy)).BeginInit();
            this.gbLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLCreate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLCopy)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFloorplan
            // 
            this.gbFloorplan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbFloorplan.Controls.Add(this.pbFPOpen);
            this.gbFloorplan.Controls.Add(this.pbFPDelete);
            this.gbFloorplan.Controls.Add(this.pbFPCreate);
            this.gbFloorplan.Controls.Add(this.pbFPCopy);
            this.gbFloorplan.Controls.Add(this.lvFloorplan);
            this.gbFloorplan.Location = new System.Drawing.Point(17, 16);
            this.gbFloorplan.Margin = new System.Windows.Forms.Padding(4);
            this.gbFloorplan.Name = "gbFloorplan";
            this.gbFloorplan.Padding = new System.Windows.Forms.Padding(4);
            this.gbFloorplan.Size = new System.Drawing.Size(532, 636);
            this.gbFloorplan.TabIndex = 0;
            this.gbFloorplan.TabStop = false;
            this.gbFloorplan.Text = "Floorplan";
            // 
            // pbFPOpen
            // 
            this.pbFPOpen.Image = global::FireSimulator.Icons.open;
            this.pbFPOpen.Location = new System.Drawing.Point(240, 571);
            this.pbFPOpen.Name = "pbFPOpen";
            this.pbFPOpen.Size = new System.Drawing.Size(100, 50);
            this.pbFPOpen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFPOpen.TabIndex = 9;
            this.pbFPOpen.TabStop = false;
            this.pbFPOpen.Click += new System.EventHandler(this.pbFPOpen_Click);
            // 
            // pbFPDelete
            // 
            this.pbFPDelete.Image = global::FireSimulator.Icons.trash;
            this.pbFPDelete.Location = new System.Drawing.Point(240, 502);
            this.pbFPDelete.Name = "pbFPDelete";
            this.pbFPDelete.Size = new System.Drawing.Size(100, 50);
            this.pbFPDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFPDelete.TabIndex = 8;
            this.pbFPDelete.TabStop = false;
            this.pbFPDelete.Click += new System.EventHandler(this.pbFPDelete_Click);
            // 
            // pbFPCreate
            // 
            this.pbFPCreate.Image = global::FireSimulator.Icons.plus;
            this.pbFPCreate.Location = new System.Drawing.Point(134, 571);
            this.pbFPCreate.Name = "pbFPCreate";
            this.pbFPCreate.Size = new System.Drawing.Size(100, 50);
            this.pbFPCreate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFPCreate.TabIndex = 7;
            this.pbFPCreate.TabStop = false;
            this.pbFPCreate.Click += new System.EventHandler(this.pbFPCreate_Click);
            // 
            // pbFPCopy
            // 
            this.pbFPCopy.BackColor = System.Drawing.SystemColors.Control;
            this.pbFPCopy.Image = global::FireSimulator.Icons.copy;
            this.pbFPCopy.Location = new System.Drawing.Point(134, 502);
            this.pbFPCopy.Name = "pbFPCopy";
            this.pbFPCopy.Size = new System.Drawing.Size(100, 50);
            this.pbFPCopy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFPCopy.TabIndex = 6;
            this.pbFPCopy.TabStop = false;
            this.pbFPCopy.Click += new System.EventHandler(this.pbFPCopy_Click);
            // 
            // lvFloorplan
            // 
            this.lvFloorplan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFloorplan.GridLines = true;
            this.lvFloorplan.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvFloorplan.HideSelection = false;
            this.lvFloorplan.LargeImageList = this.fpImageList;
            this.lvFloorplan.Location = new System.Drawing.Point(9, 25);
            this.lvFloorplan.Margin = new System.Windows.Forms.Padding(4);
            this.lvFloorplan.MultiSelect = false;
            this.lvFloorplan.Name = "lvFloorplan";
            this.lvFloorplan.Size = new System.Drawing.Size(513, 454);
            this.lvFloorplan.TabIndex = 0;
            this.lvFloorplan.UseCompatibleStateImageBehavior = false;
            this.lvFloorplan.SelectedIndexChanged += new System.EventHandler(this.lvFloorplan_SelectedIndexChanged);
            // 
            // fpImageList
            // 
            this.fpImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.fpImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.fpImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // gbLayout
            // 
            this.gbLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLayout.Controls.Add(this.pbLRun);
            this.gbLayout.Controls.Add(this.pbLDelete);
            this.gbLayout.Controls.Add(this.pbLCreate);
            this.gbLayout.Controls.Add(this.pbLCopy);
            this.gbLayout.Controls.Add(this.lvLayout);
            this.gbLayout.Location = new System.Drawing.Point(623, 16);
            this.gbLayout.Margin = new System.Windows.Forms.Padding(4);
            this.gbLayout.Name = "gbLayout";
            this.gbLayout.Padding = new System.Windows.Forms.Padding(4);
            this.gbLayout.Size = new System.Drawing.Size(532, 636);
            this.gbLayout.TabIndex = 1;
            this.gbLayout.TabStop = false;
            this.gbLayout.Text = "Layout";
            // 
            // pbLRun
            // 
            this.pbLRun.Image = global::FireSimulator.Icons.play_button;
            this.pbLRun.Location = new System.Drawing.Point(285, 571);
            this.pbLRun.Name = "pbLRun";
            this.pbLRun.Size = new System.Drawing.Size(100, 50);
            this.pbLRun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLRun.TabIndex = 13;
            this.pbLRun.TabStop = false;
            this.pbLRun.Click += new System.EventHandler(this.pbLRun_Click);
            // 
            // pbLDelete
            // 
            this.pbLDelete.Image = global::FireSimulator.Icons.trash;
            this.pbLDelete.Location = new System.Drawing.Point(285, 502);
            this.pbLDelete.Name = "pbLDelete";
            this.pbLDelete.Size = new System.Drawing.Size(100, 50);
            this.pbLDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLDelete.TabIndex = 12;
            this.pbLDelete.TabStop = false;
            this.pbLDelete.Click += new System.EventHandler(this.pbLDelete_Click);
            // 
            // pbLCreate
            // 
            this.pbLCreate.Image = global::FireSimulator.Icons.plus;
            this.pbLCreate.Location = new System.Drawing.Point(179, 571);
            this.pbLCreate.Name = "pbLCreate";
            this.pbLCreate.Size = new System.Drawing.Size(100, 50);
            this.pbLCreate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLCreate.TabIndex = 11;
            this.pbLCreate.TabStop = false;
            this.pbLCreate.Click += new System.EventHandler(this.pbLCreate_Click);
            // 
            // pbLCopy
            // 
            this.pbLCopy.BackColor = System.Drawing.SystemColors.Control;
            this.pbLCopy.Image = global::FireSimulator.Icons.copy;
            this.pbLCopy.Location = new System.Drawing.Point(179, 502);
            this.pbLCopy.Name = "pbLCopy";
            this.pbLCopy.Size = new System.Drawing.Size(100, 50);
            this.pbLCopy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLCopy.TabIndex = 10;
            this.pbLCopy.TabStop = false;
            this.pbLCopy.Click += new System.EventHandler(this.pbLCopy_Click);
            // 
            // lvLayout
            // 
            this.lvLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLayout.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvLayout.HideSelection = false;
            this.lvLayout.LargeImageList = this.lImageList;
            this.lvLayout.Location = new System.Drawing.Point(9, 25);
            this.lvLayout.Margin = new System.Windows.Forms.Padding(4);
            this.lvLayout.MultiSelect = false;
            this.lvLayout.Name = "lvLayout";
            this.lvLayout.Size = new System.Drawing.Size(513, 454);
            this.lvLayout.TabIndex = 0;
            this.lvLayout.UseCompatibleStateImageBehavior = false;
            // 
            // lImageList
            // 
            this.lImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.lImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.lImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 667);
            this.Controls.Add(this.gbLayout);
            this.Controls.Add(this.gbFloorplan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Lit - Main";
            this.gbFloorplan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFPOpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFPDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFPCreate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFPCopy)).EndInit();
            this.gbLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLCreate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLCopy)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbFloorplan;
		private System.Windows.Forms.ListView lvFloorplan;
		private System.Windows.Forms.GroupBox gbLayout;
		private System.Windows.Forms.ListView lvLayout;
		private System.Windows.Forms.ImageList fpImageList;
		private System.Windows.Forms.ImageList lImageList;
        private System.Windows.Forms.PictureBox pbFPOpen;
        private System.Windows.Forms.PictureBox pbFPDelete;
        private System.Windows.Forms.PictureBox pbFPCreate;
        private System.Windows.Forms.PictureBox pbFPCopy;
        private System.Windows.Forms.PictureBox pbLRun;
        private System.Windows.Forms.PictureBox pbLDelete;
        private System.Windows.Forms.PictureBox pbLCreate;
        private System.Windows.Forms.PictureBox pbLCopy;
    }
}