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
            this.gbFloorplan = new System.Windows.Forms.GroupBox();
            this.btnFPCreate = new System.Windows.Forms.Button();
            this.btnFPDelete = new System.Windows.Forms.Button();
            this.btnFPEdit = new System.Windows.Forms.Button();
            this.lvFloorplan = new System.Windows.Forms.ListView();
            this.gbLayout = new System.Windows.Forms.GroupBox();
            this.btnLRunSimulation = new System.Windows.Forms.Button();
            this.btnLCreate = new System.Windows.Forms.Button();
            this.btnLDelete = new System.Windows.Forms.Button();
            this.btnLEdit = new System.Windows.Forms.Button();
            this.lvLayout = new System.Windows.Forms.ListView();
            this.gbFloorplan.SuspendLayout();
            this.gbLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFloorplan
            // 
            this.gbFloorplan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbFloorplan.Controls.Add(this.btnFPCreate);
            this.gbFloorplan.Controls.Add(this.btnFPDelete);
            this.gbFloorplan.Controls.Add(this.btnFPEdit);
            this.gbFloorplan.Controls.Add(this.lvFloorplan);
            this.gbFloorplan.Location = new System.Drawing.Point(13, 13);
            this.gbFloorplan.Name = "gbFloorplan";
            this.gbFloorplan.Size = new System.Drawing.Size(200, 437);
            this.gbFloorplan.TabIndex = 0;
            this.gbFloorplan.TabStop = false;
            this.gbFloorplan.Text = "Floorplan";
            // 
            // btnFPCreate
            // 
            this.btnFPCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFPCreate.Location = new System.Drawing.Point(7, 410);
            this.btnFPCreate.Name = "btnFPCreate";
            this.btnFPCreate.Size = new System.Drawing.Size(187, 23);
            this.btnFPCreate.TabIndex = 3;
            this.btnFPCreate.Text = "Create";
            this.btnFPCreate.UseVisualStyleBackColor = true;
            this.btnFPCreate.Click += new System.EventHandler(this.btnFPCreate_Click);
            // 
            // btnFPDelete
            // 
            this.btnFPDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFPDelete.Location = new System.Drawing.Point(104, 381);
            this.btnFPDelete.Name = "btnFPDelete";
            this.btnFPDelete.Size = new System.Drawing.Size(90, 23);
            this.btnFPDelete.TabIndex = 2;
            this.btnFPDelete.Text = "Delete";
            this.btnFPDelete.UseVisualStyleBackColor = true;
            this.btnFPDelete.Click += new System.EventHandler(this.btnFPDelete_Click);
            // 
            // btnFPEdit
            // 
            this.btnFPEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFPEdit.Location = new System.Drawing.Point(6, 381);
            this.btnFPEdit.Name = "btnFPEdit";
            this.btnFPEdit.Size = new System.Drawing.Size(92, 23);
            this.btnFPEdit.TabIndex = 1;
            this.btnFPEdit.Text = "Copy";
            this.btnFPEdit.UseVisualStyleBackColor = true;
            this.btnFPEdit.Click += new System.EventHandler(this.btnFPEdit_Click);
            // 
            // lvFloorplan
            // 
            this.lvFloorplan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFloorplan.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvFloorplan.HideSelection = false;
            this.lvFloorplan.Location = new System.Drawing.Point(7, 20);
            this.lvFloorplan.MultiSelect = false;
            this.lvFloorplan.Name = "lvFloorplan";
            this.lvFloorplan.Size = new System.Drawing.Size(187, 355);
            this.lvFloorplan.TabIndex = 0;
            this.lvFloorplan.UseCompatibleStateImageBehavior = false;
            this.lvFloorplan.View = System.Windows.Forms.View.List;
            // 
            // gbLayout
            // 
            this.gbLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.gbLayout.Controls.Add(this.btnLRunSimulation);
            this.gbLayout.Controls.Add(this.btnLCreate);
            this.gbLayout.Controls.Add(this.btnLDelete);
            this.gbLayout.Controls.Add(this.btnLEdit);
            this.gbLayout.Controls.Add(this.lvLayout);
            this.gbLayout.Location = new System.Drawing.Point(220, 13);
            this.gbLayout.Name = "gbLayout";
            this.gbLayout.Size = new System.Drawing.Size(200, 437);
            this.gbLayout.TabIndex = 1;
            this.gbLayout.TabStop = false;
            this.gbLayout.Text = "Layout";
            // 
            // btnLRunSimulation
            // 
            this.btnLRunSimulation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLRunSimulation.Location = new System.Drawing.Point(88, 410);
            this.btnLRunSimulation.Name = "btnLRunSimulation";
            this.btnLRunSimulation.Size = new System.Drawing.Size(106, 23);
            this.btnLRunSimulation.TabIndex = 5;
            this.btnLRunSimulation.Text = "Run Simulation";
            this.btnLRunSimulation.UseVisualStyleBackColor = true;
            this.btnLRunSimulation.Click += new System.EventHandler(this.btnLRunSimulation_Click);
            // 
            // btnLCreate
            // 
            this.btnLCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLCreate.Location = new System.Drawing.Point(7, 408);
            this.btnLCreate.Name = "btnLCreate";
            this.btnLCreate.Size = new System.Drawing.Size(75, 23);
            this.btnLCreate.TabIndex = 4;
            this.btnLCreate.Text = "Create";
            this.btnLCreate.UseVisualStyleBackColor = true;
            this.btnLCreate.Click += new System.EventHandler(this.btnLCreate_Click);
            // 
            // btnLDelete
            // 
            this.btnLDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLDelete.Location = new System.Drawing.Point(88, 381);
            this.btnLDelete.Name = "btnLDelete";
            this.btnLDelete.Size = new System.Drawing.Size(106, 23);
            this.btnLDelete.TabIndex = 3;
            this.btnLDelete.Text = "Delete";
            this.btnLDelete.UseVisualStyleBackColor = true;
            this.btnLDelete.Click += new System.EventHandler(this.btnLDelete_Click);
            // 
            // btnLEdit
            // 
            this.btnLEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLEdit.Location = new System.Drawing.Point(7, 382);
            this.btnLEdit.Name = "btnLEdit";
            this.btnLEdit.Size = new System.Drawing.Size(75, 23);
            this.btnLEdit.TabIndex = 1;
            this.btnLEdit.Text = "Edit";
            this.btnLEdit.UseVisualStyleBackColor = true;
            this.btnLEdit.Click += new System.EventHandler(this.btnLEdit_Click);
            // 
            // lvLayout
            // 
            this.lvLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLayout.HideSelection = false;
            this.lvLayout.Location = new System.Drawing.Point(7, 20);
            this.lvLayout.MultiSelect = false;
            this.lvLayout.Name = "lvLayout";
            this.lvLayout.Size = new System.Drawing.Size(187, 355);
            this.lvLayout.TabIndex = 0;
            this.lvLayout.UseCompatibleStateImageBehavior = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 462);
            this.Controls.Add(this.gbLayout);
            this.Controls.Add(this.gbFloorplan);
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
		private System.Windows.Forms.Button btnFPEdit;
		private System.Windows.Forms.ListView lvFloorplan;
		private System.Windows.Forms.GroupBox gbLayout;
		private System.Windows.Forms.ListView lvLayout;
		private System.Windows.Forms.Button btnLRunSimulation;
		private System.Windows.Forms.Button btnLCreate;
		private System.Windows.Forms.Button btnLDelete;
		private System.Windows.Forms.Button btnLEdit;
	}
}