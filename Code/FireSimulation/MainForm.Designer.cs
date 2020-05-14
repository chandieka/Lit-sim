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
			this.gbLayout = new System.Windows.Forms.GroupBox();
			this.lvFloorplan = new System.Windows.Forms.ListView();
			this.btnFPEdit = new System.Windows.Forms.Button();
			this.btnFPDelete = new System.Windows.Forms.Button();
			this.btnFPCreate = new System.Windows.Forms.Button();
			this.lvLayout = new System.Windows.Forms.ListView();
			this.btnLEdit = new System.Windows.Forms.Button();
			this.btnLDelete = new System.Windows.Forms.Button();
			this.btnLCreate = new System.Windows.Forms.Button();
			this.btnLView = new System.Windows.Forms.Button();
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
			this.gbFloorplan.Size = new System.Drawing.Size(200, 390);
			this.gbFloorplan.TabIndex = 0;
			this.gbFloorplan.TabStop = false;
			this.gbFloorplan.Text = "Floorplan";
			// 
			// gbLayout
			// 
			this.gbLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.gbLayout.Controls.Add(this.btnLView);
			this.gbLayout.Controls.Add(this.btnLCreate);
			this.gbLayout.Controls.Add(this.btnLDelete);
			this.gbLayout.Controls.Add(this.btnLEdit);
			this.gbLayout.Controls.Add(this.lvLayout);
			this.gbLayout.Location = new System.Drawing.Point(219, 13);
			this.gbLayout.Name = "gbLayout";
			this.gbLayout.Size = new System.Drawing.Size(200, 390);
			this.gbLayout.TabIndex = 1;
			this.gbLayout.TabStop = false;
			this.gbLayout.Text = "Layout";
			// 
			// lvFloorplan
			// 
			this.lvFloorplan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.lvFloorplan.HideSelection = false;
			this.lvFloorplan.Location = new System.Drawing.Point(7, 20);
			this.lvFloorplan.Name = "lvFloorplan";
			this.lvFloorplan.Size = new System.Drawing.Size(187, 308);
			this.lvFloorplan.TabIndex = 0;
			this.lvFloorplan.UseCompatibleStateImageBehavior = false;
			// 
			// btnFPEdit
			// 
			this.btnFPEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnFPEdit.Location = new System.Drawing.Point(6, 334);
			this.btnFPEdit.Name = "btnFPEdit";
			this.btnFPEdit.Size = new System.Drawing.Size(75, 23);
			this.btnFPEdit.TabIndex = 1;
			this.btnFPEdit.Text = "Copy";
			this.btnFPEdit.UseVisualStyleBackColor = true;
			// 
			// btnFPDelete
			// 
			this.btnFPDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFPDelete.Location = new System.Drawing.Point(119, 334);
			this.btnFPDelete.Name = "btnFPDelete";
			this.btnFPDelete.Size = new System.Drawing.Size(75, 23);
			this.btnFPDelete.TabIndex = 2;
			this.btnFPDelete.Text = "Delete";
			this.btnFPDelete.UseVisualStyleBackColor = true;
			// 
			// btnFPCreate
			// 
			this.btnFPCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.btnFPCreate.Location = new System.Drawing.Point(7, 363);
			this.btnFPCreate.Name = "btnFPCreate";
			this.btnFPCreate.Size = new System.Drawing.Size(187, 23);
			this.btnFPCreate.TabIndex = 3;
			this.btnFPCreate.Text = "Create";
			this.btnFPCreate.UseVisualStyleBackColor = true;
			// 
			// lvLayout
			// 
			this.lvLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.lvLayout.HideSelection = false;
			this.lvLayout.Location = new System.Drawing.Point(7, 20);
			this.lvLayout.Name = "lvLayout";
			this.lvLayout.Size = new System.Drawing.Size(187, 308);
			this.lvLayout.TabIndex = 0;
			this.lvLayout.UseCompatibleStateImageBehavior = false;
			// 
			// btnLEdit
			// 
			this.btnLEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnLEdit.Location = new System.Drawing.Point(7, 335);
			this.btnLEdit.Name = "btnLEdit";
			this.btnLEdit.Size = new System.Drawing.Size(75, 23);
			this.btnLEdit.TabIndex = 1;
			this.btnLEdit.Text = "Edit";
			this.btnLEdit.UseVisualStyleBackColor = true;
			// 
			// btnLDelete
			// 
			this.btnLDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLDelete.Location = new System.Drawing.Point(119, 334);
			this.btnLDelete.Name = "btnLDelete";
			this.btnLDelete.Size = new System.Drawing.Size(75, 23);
			this.btnLDelete.TabIndex = 3;
			this.btnLDelete.Text = "Delete";
			this.btnLDelete.UseVisualStyleBackColor = true;
			// 
			// btnLCreate
			// 
			this.btnLCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnLCreate.Location = new System.Drawing.Point(7, 361);
			this.btnLCreate.Name = "btnLCreate";
			this.btnLCreate.Size = new System.Drawing.Size(75, 23);
			this.btnLCreate.TabIndex = 4;
			this.btnLCreate.Text = "Create";
			this.btnLCreate.UseVisualStyleBackColor = true;
			// 
			// btnLView
			// 
			this.btnLView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLView.Location = new System.Drawing.Point(119, 363);
			this.btnLView.Name = "btnLView";
			this.btnLView.Size = new System.Drawing.Size(75, 23);
			this.btnLView.TabIndex = 5;
			this.btnLView.Text = "View";
			this.btnLView.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(431, 415);
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
		private System.Windows.Forms.Button btnLView;
		private System.Windows.Forms.Button btnLCreate;
		private System.Windows.Forms.Button btnLDelete;
		private System.Windows.Forms.Button btnLEdit;
	}
}