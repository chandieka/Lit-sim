namespace FireSimulator
{
    partial class Statistics
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btReplaySelected = new System.Windows.Forms.Button();
            this.gbSearchMenu = new System.Windows.Forms.GroupBox();
            this.cbbSearchOption = new System.Windows.Forms.ComboBox();
            this.lbSearchResults = new System.Windows.Forms.ListBox();
            this.btSearch = new System.Windows.Forms.PictureBox();
            this.tbSearchQuery = new System.Windows.Forms.TextBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.pbSelectedPreview = new System.Windows.Forms.PictureBox();
            this.gbStatisticsMenu = new System.Windows.Forms.GroupBox();
            this.lbStatistics = new System.Windows.Forms.Label();
            this.gbSimulationPreviews = new System.Windows.Forms.GroupBox();
            this.gbOrderMenu = new System.Windows.Forms.GroupBox();
            this.cbbPreviewOrder = new System.Windows.Forms.ComboBox();
            this.lbSort = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_total_sims = new System.Windows.Forms.Label();
            this.lbl_avg_deaths = new System.Windows.Forms.Label();
            this.lbl_start_date = new System.Windows.Forms.Label();
            this.lbl_total_people = new System.Windows.Forms.Label();
            this.lbl_avg_time = new System.Windows.Forms.Label();
            this.lbl_end_date = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel_overview = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            this.gbSearchMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedPreview)).BeginInit();
            this.gbStatisticsMenu.SuspendLayout();
            this.gbSimulationPreviews.SuspendLayout();
            this.gbOrderMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btReplaySelected);
            this.groupBox2.Location = new System.Drawing.Point(792, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(267, 162);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btReplaySelected
            // 
            this.btReplaySelected.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btReplaySelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReplaySelected.Location = new System.Drawing.Point(17, 54);
            this.btReplaySelected.Margin = new System.Windows.Forms.Padding(2);
            this.btReplaySelected.Name = "btReplaySelected";
            this.btReplaySelected.Size = new System.Drawing.Size(224, 57);
            this.btReplaySelected.TabIndex = 0;
            this.btReplaySelected.Text = "Replay selected simulation";
            this.btReplaySelected.UseVisualStyleBackColor = true;
            this.btReplaySelected.Click += new System.EventHandler(this.btReplaySelected_Click);
            // 
            // gbSearchMenu
            // 
            this.gbSearchMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSearchMenu.Controls.Add(this.cbbSearchOption);
            this.gbSearchMenu.Controls.Add(this.lbSearchResults);
            this.gbSearchMenu.Controls.Add(this.btSearch);
            this.gbSearchMenu.Controls.Add(this.tbSearchQuery);
            this.gbSearchMenu.Controls.Add(this.lbSearch);
            this.gbSearchMenu.Location = new System.Drawing.Point(792, 178);
            this.gbSearchMenu.Name = "gbSearchMenu";
            this.gbSearchMenu.Padding = new System.Windows.Forms.Padding(2);
            this.gbSearchMenu.Size = new System.Drawing.Size(267, 404);
            this.gbSearchMenu.TabIndex = 2;
            this.gbSearchMenu.TabStop = false;
            // 
            // cbbSearchOption
            // 
            this.cbbSearchOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbSearchOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSearchOption.FormattingEnabled = true;
            this.cbbSearchOption.Location = new System.Drawing.Point(25, 83);
            this.cbbSearchOption.Name = "cbbSearchOption";
            this.cbbSearchOption.Size = new System.Drawing.Size(209, 21);
            this.cbbSearchOption.TabIndex = 6;
            // 
            // lbSearchResults
            // 
            this.lbSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSearchResults.FormattingEnabled = true;
            this.lbSearchResults.IntegralHeight = false;
            this.lbSearchResults.Location = new System.Drawing.Point(25, 110);
            this.lbSearchResults.Margin = new System.Windows.Forms.Padding(10);
            this.lbSearchResults.Name = "lbSearchResults";
            this.lbSearchResults.Size = new System.Drawing.Size(209, 282);
            this.lbSearchResults.TabIndex = 5;
            // 
            // btSearch
            // 
            this.btSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSearch.Image = global::FireSimulator.Icons.search_Icon;
            this.btSearch.ImageLocation = "";
            this.btSearch.Location = new System.Drawing.Point(224, 60);
            this.btSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(10, 18);
            this.btSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btSearch.TabIndex = 4;
            this.btSearch.TabStop = false;
            // 
            // tbSearchQuery
            // 
            this.tbSearchQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearchQuery.Location = new System.Drawing.Point(25, 58);
            this.tbSearchQuery.Margin = new System.Windows.Forms.Padding(2);
            this.tbSearchQuery.Name = "tbSearchQuery";
            this.tbSearchQuery.Size = new System.Drawing.Size(188, 20);
            this.tbSearchQuery.TabIndex = 3;
            // 
            // lbSearch
            // 
            this.lbSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbSearch.AutoSize = true;
            this.lbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSearch.Location = new System.Drawing.Point(100, 16);
            this.lbSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(70, 24);
            this.lbSearch.TabIndex = 2;
            this.lbSearch.Text = "Search";
            // 
            // pbSelectedPreview
            // 
            this.pbSelectedPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSelectedPreview.Location = new System.Drawing.Point(27, 11);
            this.pbSelectedPreview.Margin = new System.Windows.Forms.Padding(2);
            this.pbSelectedPreview.Name = "pbSelectedPreview";
            this.pbSelectedPreview.Size = new System.Drawing.Size(441, 416);
            this.pbSelectedPreview.TabIndex = 0;
            this.pbSelectedPreview.TabStop = false;
            // 
            // gbStatisticsMenu
            // 
            this.gbStatisticsMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStatisticsMenu.Controls.Add(this.label6);
            this.gbStatisticsMenu.Controls.Add(this.lbl_end_date);
            this.gbStatisticsMenu.Controls.Add(this.lbl_avg_time);
            this.gbStatisticsMenu.Controls.Add(this.lbl_total_people);
            this.gbStatisticsMenu.Controls.Add(this.lbl_start_date);
            this.gbStatisticsMenu.Controls.Add(this.lbl_avg_deaths);
            this.gbStatisticsMenu.Controls.Add(this.lbl_total_sims);
            this.gbStatisticsMenu.Controls.Add(this.label5);
            this.gbStatisticsMenu.Controls.Add(this.label4);
            this.gbStatisticsMenu.Controls.Add(this.label3);
            this.gbStatisticsMenu.Controls.Add(this.label2);
            this.gbStatisticsMenu.Controls.Add(this.label1);
            this.gbStatisticsMenu.Controls.Add(this.lbStatistics);
            this.gbStatisticsMenu.Location = new System.Drawing.Point(506, 11);
            this.gbStatisticsMenu.Margin = new System.Windows.Forms.Padding(2);
            this.gbStatisticsMenu.Name = "gbStatisticsMenu";
            this.gbStatisticsMenu.Padding = new System.Windows.Forms.Padding(2);
            this.gbStatisticsMenu.Size = new System.Drawing.Size(255, 408);
            this.gbStatisticsMenu.TabIndex = 1;
            this.gbStatisticsMenu.TabStop = false;
            // 
            // lbStatistics
            // 
            this.lbStatistics.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbStatistics.AutoSize = true;
            this.lbStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatistics.Location = new System.Drawing.Point(89, 15);
            this.lbStatistics.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStatistics.Name = "lbStatistics";
            this.lbStatistics.Size = new System.Drawing.Size(80, 24);
            this.lbStatistics.TabIndex = 1;
            this.lbStatistics.Text = "Statistics";
            // 
            // gbSimulationPreviews
            // 
            this.gbSimulationPreviews.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSimulationPreviews.Controls.Add(this.panel_overview);
            this.gbSimulationPreviews.Location = new System.Drawing.Point(9, 431);
            this.gbSimulationPreviews.Margin = new System.Windows.Forms.Padding(2);
            this.gbSimulationPreviews.Name = "gbSimulationPreviews";
            this.gbSimulationPreviews.Padding = new System.Windows.Forms.Padding(2);
            this.gbSimulationPreviews.Size = new System.Drawing.Size(485, 149);
            this.gbSimulationPreviews.TabIndex = 2;
            this.gbSimulationPreviews.TabStop = false;
            // 
            // gbOrderMenu
            // 
            this.gbOrderMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOrderMenu.Controls.Add(this.cbbPreviewOrder);
            this.gbOrderMenu.Controls.Add(this.lbSort);
            this.gbOrderMenu.Location = new System.Drawing.Point(506, 431);
            this.gbOrderMenu.Margin = new System.Windows.Forms.Padding(10);
            this.gbOrderMenu.Name = "gbOrderMenu";
            this.gbOrderMenu.Padding = new System.Windows.Forms.Padding(2);
            this.gbOrderMenu.Size = new System.Drawing.Size(255, 151);
            this.gbOrderMenu.TabIndex = 2;
            this.gbOrderMenu.TabStop = false;
            // 
            // cbbPreviewOrder
            // 
            this.cbbPreviewOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbPreviewOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPreviewOrder.FormattingEnabled = true;
            this.cbbPreviewOrder.Location = new System.Drawing.Point(23, 87);
            this.cbbPreviewOrder.Name = "cbbPreviewOrder";
            this.cbbPreviewOrder.Size = new System.Drawing.Size(211, 21);
            this.cbbPreviewOrder.TabIndex = 5;
            // 
            // lbSort
            // 
            this.lbSort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSort.AutoSize = true;
            this.lbSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSort.Location = new System.Drawing.Point(109, 41);
            this.lbSort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSort.Name = "lbSort";
            this.lbSort.Size = new System.Drawing.Size(43, 24);
            this.lbSort.TabIndex = 4;
            this.lbSort.Text = "Sort";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Simulations Ran:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "People:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "AVG Deaths:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Time Period:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "AVG Time:";
            // 
            // lbl_total_sims
            // 
            this.lbl_total_sims.AutoSize = true;
            this.lbl_total_sims.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_sims.Location = new System.Drawing.Point(149, 104);
            this.lbl_total_sims.Name = "lbl_total_sims";
            this.lbl_total_sims.Size = new System.Drawing.Size(0, 16);
            this.lbl_total_sims.TabIndex = 7;
            // 
            // lbl_avg_deaths
            // 
            this.lbl_avg_deaths.AutoSize = true;
            this.lbl_avg_deaths.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_avg_deaths.Location = new System.Drawing.Point(149, 167);
            this.lbl_avg_deaths.Name = "lbl_avg_deaths";
            this.lbl_avg_deaths.Size = new System.Drawing.Size(0, 16);
            this.lbl_avg_deaths.TabIndex = 8;
            // 
            // lbl_start_date
            // 
            this.lbl_start_date.AutoSize = true;
            this.lbl_start_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_start_date.Location = new System.Drawing.Point(149, 227);
            this.lbl_start_date.Name = "lbl_start_date";
            this.lbl_start_date.Size = new System.Drawing.Size(0, 16);
            this.lbl_start_date.TabIndex = 9;
            // 
            // lbl_total_people
            // 
            this.lbl_total_people.AutoSize = true;
            this.lbl_total_people.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_people.Location = new System.Drawing.Point(149, 130);
            this.lbl_total_people.Name = "lbl_total_people";
            this.lbl_total_people.Size = new System.Drawing.Size(0, 16);
            this.lbl_total_people.TabIndex = 10;
            // 
            // lbl_avg_time
            // 
            this.lbl_avg_time.AutoSize = true;
            this.lbl_avg_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_avg_time.Location = new System.Drawing.Point(149, 200);
            this.lbl_avg_time.Name = "lbl_avg_time";
            this.lbl_avg_time.Size = new System.Drawing.Size(0, 16);
            this.lbl_avg_time.TabIndex = 11;
            // 
            // lbl_end_date
            // 
            this.lbl_end_date.AutoSize = true;
            this.lbl_end_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_end_date.Location = new System.Drawing.Point(149, 259);
            this.lbl_end_date.Name = "lbl_end_date";
            this.lbl_end_date.Size = new System.Drawing.Size(0, 16);
            this.lbl_end_date.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(166, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "-";
            // 
            // panel_overview
            // 
            this.panel_overview.Location = new System.Drawing.Point(5, 8);
            this.panel_overview.Name = "panel_overview";
            this.panel_overview.Size = new System.Drawing.Size(475, 136);
            this.panel_overview.TabIndex = 0;
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 591);
            this.Controls.Add(this.gbSimulationPreviews);
            this.Controls.Add(this.gbSearchMenu);
            this.Controls.Add(this.pbSelectedPreview);
            this.Controls.Add(this.gbStatisticsMenu);
            this.Controls.Add(this.gbOrderMenu);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1068, 572);
            this.Name = "Statistics";
            this.Text = "Statistics";
            this.groupBox2.ResumeLayout(false);
            this.gbSearchMenu.ResumeLayout(false);
            this.gbSearchMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedPreview)).EndInit();
            this.gbStatisticsMenu.ResumeLayout(false);
            this.gbStatisticsMenu.PerformLayout();
            this.gbSimulationPreviews.ResumeLayout(false);
            this.gbOrderMenu.ResumeLayout(false);
            this.gbOrderMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btReplaySelected;
        private System.Windows.Forms.GroupBox gbSearchMenu;
        private System.Windows.Forms.ComboBox cbbSearchOption;
        private System.Windows.Forms.ListBox lbSearchResults;
        private System.Windows.Forms.PictureBox btSearch;
        private System.Windows.Forms.TextBox tbSearchQuery;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.PictureBox pbSelectedPreview;
        private System.Windows.Forms.GroupBox gbStatisticsMenu;
        private System.Windows.Forms.Label lbStatistics;
        private System.Windows.Forms.GroupBox gbSimulationPreviews;
        private System.Windows.Forms.GroupBox gbOrderMenu;
        private System.Windows.Forms.ComboBox cbbPreviewOrder;
        private System.Windows.Forms.Label lbSort;
        private System.Windows.Forms.Label lbl_avg_deaths;
        private System.Windows.Forms.Label lbl_total_sims;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_avg_time;
        private System.Windows.Forms.Label lbl_total_people;
        private System.Windows.Forms.Label lbl_start_date;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_end_date;
        private System.Windows.Forms.Panel panel_overview;
    }
}