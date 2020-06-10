namespace FireSimulator.GUI
{
	partial class ScenarioDialog
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgvMain = new System.Windows.Forms.DataGridView();
			this.btnClose = new System.Windows.Forms.Button();
			this.lblTotal = new System.Windows.Forms.Label();
			this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.code_string = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvMain
			// 
			this.dgvMain.AllowUserToAddRows = false;
			this.dgvMain.AllowUserToDeleteRows = false;
			this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvMain.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgvMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.code_string,
            this.number});
			this.dgvMain.Location = new System.Drawing.Point(12, 12);
			this.dgvMain.Name = "dgvMain";
			this.dgvMain.ReadOnly = true;
			this.dgvMain.RowHeadersVisible = false;
			this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvMain.Size = new System.Drawing.Size(386, 148);
			this.dgvMain.TabIndex = 0;
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(12, 191);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(378, 23);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// lblTotal
			// 
			this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTotal.Location = new System.Drawing.Point(9, 167);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(389, 21);
			this.lblTotal.TabIndex = 2;
			this.lblTotal.Text = "Total: -";
			this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// code
			// 
			this.code.HeaderText = "Code";
			this.code.Name = "code";
			this.code.ReadOnly = true;
			this.code.ToolTipText = "Internal code";
			// 
			// code_string
			// 
			this.code_string.HeaderText = "Value";
			this.code_string.Name = "code_string";
			this.code_string.ReadOnly = true;
			this.code_string.ToolTipText = "Stringified version of the code";
			// 
			// number
			// 
			this.number.HeaderText = "Amount";
			this.number.Name = "number";
			this.number.ReadOnly = true;
			this.number.ToolTipText = "Amount of times this outcome is reached";
			// 
			// ScenarioDialog
			// 
			this.AcceptButton = this.btnClose;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(402, 226);
			this.Controls.Add(this.lblTotal);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.dgvMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ScenarioDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Lit - Scenario";
			((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvMain;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.DataGridViewTextBoxColumn code;
		private System.Windows.Forms.DataGridViewTextBoxColumn code_string;
		private System.Windows.Forms.DataGridViewTextBoxColumn number;
	}
}