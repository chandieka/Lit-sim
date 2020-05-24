namespace FireSimulator
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
            this.btnFPCreate = new System.Windows.Forms.Button();
            this.btnFPDelete = new System.Windows.Forms.Button();
            this.btnFPCopy = new System.Windows.Forms.Button();
            this.lvFloorplan = new System.Windows.Forms.ListView();
            this.fpImageList = new System.Windows.Forms.ImageList(this.components);
            this.gbLayout = new System.Windows.Forms.GroupBox();
            this.btnLRunSimulation = new System.Windows.Forms.Button();
            this.btnLCreate = new System.Windows.Forms.Button();
            this.btnLDelete = new System.Windows.Forms.Button();
            this.btnLCopy = new System.Windows.Forms.Button();
            this.lvLayout = new System.Windows.Forms.ListView();
            this.lImageList = new System.Windows.Forms.ImageList(this.components);
            this.btn_open = new System.Windows.Forms.Button();
            this.gbFloorplan.SuspendLayout();
            this.gbLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFloorplan
            // 
            this.gbFloorplan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbFloorplan.Controls.Add(this.btn_open);
            this.gbFloorplan.Controls.Add(this.btnFPCreate);
            this.gbFloorplan.Controls.Add(this.btnFPDelete);
            this.gbFloorplan.Controls.Add(this.btnFPCopy);
            this.gbFloorplan.Controls.Add(this.lvFloorplan);
            this.gbFloorplan.Location = new System.Drawing.Point(17, 16);
            this.gbFloorplan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbFloorplan.Name = "gbFloorplan";
            this.gbFloorplan.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbFloorplan.Size = new System.Drawing.Size(267, 538);
            this.gbFloorplan.TabIndex = 0;
            this.gbFloorplan.TabStop = false;
            this.gbFloorplan.Text = "Floorplan";
            // 
            // btnFPCreate
            // 
            this.btnFPCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFPCreate.Location = new System.Drawing.Point(9, 505);
            this.btnFPCreate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFPCreate.Name = "btnFPCreate";
            this.btnFPCreate.Size = new System.Drawing.Size(122, 28);
            this.btnFPCreate.TabIndex = 3;
            this.btnFPCreate.Text = "Create";
            this.btnFPCreate.UseVisualStyleBackColor = true;
            this.btnFPCreate.Click += new System.EventHandler(this.btnFPCreate_Click);
            // 
            // btnFPDelete
            // 
            this.btnFPDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFPDelete.Location = new System.Drawing.Point(139, 469);
            this.btnFPDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFPDelete.Name = "btnFPDelete";
            this.btnFPDelete.Size = new System.Drawing.Size(120, 28);
            this.btnFPDelete.TabIndex = 2;
            this.btnFPDelete.Text = "Delete";
            this.btnFPDelete.UseVisualStyleBackColor = true;
            this.btnFPDelete.Click += new System.EventHandler(this.btnFPDelete_Click);
            // 
            // btnFPCopy
            // 
            this.btnFPCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFPCopy.Location = new System.Drawing.Point(8, 469);
            this.btnFPCopy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFPCopy.Name = "btnFPCopy";
            this.btnFPCopy.Size = new System.Drawing.Size(123, 28);
            this.btnFPCopy.TabIndex = 1;
            this.btnFPCopy.Text = "Copy";
            this.btnFPCopy.UseVisualStyleBackColor = true;
            this.btnFPCopy.Click += new System.EventHandler(this.btnFPCopy_Click);
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
            this.lvFloorplan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvFloorplan.MultiSelect = false;
            this.lvFloorplan.Name = "lvFloorplan";
            this.lvFloorplan.Size = new System.Drawing.Size(248, 436);
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
            this.gbLayout.Controls.Add(this.btnLRunSimulation);
            this.gbLayout.Controls.Add(this.btnLCreate);
            this.gbLayout.Controls.Add(this.btnLDelete);
            this.gbLayout.Controls.Add(this.btnLCopy);
            this.gbLayout.Controls.Add(this.lvLayout);
            this.gbLayout.Location = new System.Drawing.Point(293, 16);
            this.gbLayout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbLayout.Name = "gbLayout";
            this.gbLayout.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbLayout.Size = new System.Drawing.Size(267, 538);
            this.gbLayout.TabIndex = 1;
            this.gbLayout.TabStop = false;
            this.gbLayout.Text = "Layout";
            // 
            // btnLRunSimulation
            // 
            this.btnLRunSimulation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLRunSimulation.Location = new System.Drawing.Point(117, 502);
            this.btnLRunSimulation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLRunSimulation.Name = "btnLRunSimulation";
            this.btnLRunSimulation.Size = new System.Drawing.Size(141, 28);
            this.btnLRunSimulation.TabIndex = 5;
            this.btnLRunSimulation.Text = "Run Simulation";
            this.btnLRunSimulation.UseVisualStyleBackColor = true;
            this.btnLRunSimulation.Click += new System.EventHandler(this.btnLRunSimulation_Click);
            // 
            // btnLCreate
            // 
            this.btnLCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLCreate.Location = new System.Drawing.Point(9, 502);
            this.btnLCreate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLCreate.Name = "btnLCreate";
            this.btnLCreate.Size = new System.Drawing.Size(100, 28);
            this.btnLCreate.TabIndex = 4;
            this.btnLCreate.Text = "Create";
            this.btnLCreate.UseVisualStyleBackColor = true;
            this.btnLCreate.Click += new System.EventHandler(this.btnLCreate_Click);
            // 
            // btnLDelete
            // 
            this.btnLDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLDelete.Location = new System.Drawing.Point(117, 469);
            this.btnLDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLDelete.Name = "btnLDelete";
            this.btnLDelete.Size = new System.Drawing.Size(141, 28);
            this.btnLDelete.TabIndex = 3;
            this.btnLDelete.Text = "Delete";
            this.btnLDelete.UseVisualStyleBackColor = true;
            this.btnLDelete.Click += new System.EventHandler(this.btnLDelete_Click);
            // 
            // btnLCopy
            // 
            this.btnLCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLCopy.Location = new System.Drawing.Point(9, 470);
            this.btnLCopy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLCopy.Name = "btnLCopy";
            this.btnLCopy.Size = new System.Drawing.Size(100, 28);
            this.btnLCopy.TabIndex = 1;
            this.btnLCopy.Text = "Copy";
            this.btnLCopy.UseVisualStyleBackColor = true;
            this.btnLCopy.Click += new System.EventHandler(this.btnLCopy_Click);
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
            this.lvLayout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvLayout.MultiSelect = false;
            this.lvLayout.Name = "lvLayout";
            this.lvLayout.Size = new System.Drawing.Size(248, 436);
            this.lvLayout.TabIndex = 0;
            this.lvLayout.UseCompatibleStateImageBehavior = false;
            // 
            // lImageList
            // 
            this.lImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.lImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.lImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(139, 505);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(118, 28);
            this.btn_open.TabIndex = 4;
            this.btn_open.Text = "Open";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 569);
            this.Controls.Add(this.gbLayout);
            this.Controls.Add(this.gbFloorplan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Lit - Main";
            this.gbFloorplan.ResumeLayout(false);
            this.gbLayout.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbFloorplan;
		private System.Windows.Forms.Button btnFPCreate;
		private System.Windows.Forms.Button btnFPDelete;
		private System.Windows.Forms.Button btnFPCopy;
		private System.Windows.Forms.ListView lvFloorplan;
		private System.Windows.Forms.GroupBox gbLayout;
		private System.Windows.Forms.ListView lvLayout;
		private System.Windows.Forms.Button btnLRunSimulation;
		private System.Windows.Forms.Button btnLCreate;
		private System.Windows.Forms.Button btnLDelete;
		private System.Windows.Forms.Button btnLCopy;
		private System.Windows.Forms.ImageList fpImageList;
		private System.Windows.Forms.ImageList lImageList;
        private System.Windows.Forms.Button btn_open;
    }
}