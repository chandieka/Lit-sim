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
            this.btn_open_graphs = new System.Windows.Forms.Button();
            this.lbl_name = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_end_date = new System.Windows.Forms.Label();
            this.lbl_avg_time = new System.Windows.Forms.Label();
            this.lbl_total_people = new System.Windows.Forms.Label();
            this.lbl_start_date = new System.Windows.Forms.Label();
            this.lbl_avg_deaths = new System.Windows.Forms.Label();
            this.lbl_total_sims = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbStatistics = new System.Windows.Forms.Label();
            this.gbSimulationPreviews = new System.Windows.Forms.GroupBox();
            this.panel_overview = new System.Windows.Forms.Panel();
            this.gbOrderMenu = new System.Windows.Forms.GroupBox();
            this.cbbPreviewOrder = new System.Windows.Forms.ComboBox();
            this.lbSort = new System.Windows.Forms.Label();
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
            this.groupBox2.Location = new System.Drawing.Point(1056, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(356, 199);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btReplaySelected
            // 
            this.btReplaySelected.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btReplaySelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReplaySelected.Location = new System.Drawing.Point(23, 66);
            this.btReplaySelected.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btReplaySelected.Name = "btReplaySelected";
            this.btReplaySelected.Size = new System.Drawing.Size(299, 70);
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
            this.gbSearchMenu.Location = new System.Drawing.Point(1056, 219);
            this.gbSearchMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbSearchMenu.Name = "gbSearchMenu";
            this.gbSearchMenu.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbSearchMenu.Size = new System.Drawing.Size(356, 497);
            this.gbSearchMenu.TabIndex = 2;
            this.gbSearchMenu.TabStop = false;
            // 
            // cbbSearchOption
            // 
            this.cbbSearchOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbSearchOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSearchOption.FormattingEnabled = true;
            this.cbbSearchOption.Location = new System.Drawing.Point(33, 102);
            this.cbbSearchOption.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbSearchOption.Name = "cbbSearchOption";
            this.cbbSearchOption.Size = new System.Drawing.Size(277, 24);
            this.cbbSearchOption.TabIndex = 6;
            // 
            // lbSearchResults
            // 
            this.lbSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSearchResults.FormattingEnabled = true;
            this.lbSearchResults.IntegralHeight = false;
            this.lbSearchResults.ItemHeight = 16;
            this.lbSearchResults.Location = new System.Drawing.Point(33, 135);
            this.lbSearchResults.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.lbSearchResults.Name = "lbSearchResults";
            this.lbSearchResults.Size = new System.Drawing.Size(277, 346);
            this.lbSearchResults.TabIndex = 5;
            this.lbSearchResults.SelectedIndexChanged += new System.EventHandler(this.lbSearchResults_SelectedIndexChanged);
            // 
            // btSearch
            // 
            this.btSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSearch.Image = global::FireSimulator.Icons.search_Icon;
            this.btSearch.ImageLocation = "";
            this.btSearch.Location = new System.Drawing.Point(299, 74);
            this.btSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(13, 22);
            this.btSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btSearch.TabIndex = 4;
            this.btSearch.TabStop = false;
            // 
            // tbSearchQuery
            // 
            this.tbSearchQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearchQuery.Location = new System.Drawing.Point(33, 71);
            this.tbSearchQuery.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSearchQuery.Name = "tbSearchQuery";
            this.tbSearchQuery.Size = new System.Drawing.Size(249, 22);
            this.tbSearchQuery.TabIndex = 3;
            this.tbSearchQuery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearchQuery_KeyPress);
            // 
            // lbSearch
            // 
            this.lbSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbSearch.AutoSize = true;
            this.lbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSearch.Location = new System.Drawing.Point(133, 20);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(89, 29);
            this.lbSearch.TabIndex = 2;
            this.lbSearch.Text = "Search";
            // 
            // pbSelectedPreview
            // 
            this.pbSelectedPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSelectedPreview.Location = new System.Drawing.Point(36, 14);
            this.pbSelectedPreview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbSelectedPreview.Name = "pbSelectedPreview";
            this.pbSelectedPreview.Size = new System.Drawing.Size(588, 512);
            this.pbSelectedPreview.TabIndex = 0;
            this.pbSelectedPreview.TabStop = false;
            // 
            // gbStatisticsMenu
            // 
            this.gbStatisticsMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStatisticsMenu.Controls.Add(this.btn_open_graphs);
            this.gbStatisticsMenu.Controls.Add(this.lbl_name);
            this.gbStatisticsMenu.Controls.Add(this.label7);
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
            this.gbStatisticsMenu.Location = new System.Drawing.Point(675, 14);
            this.gbStatisticsMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbStatisticsMenu.Name = "gbStatisticsMenu";
            this.gbStatisticsMenu.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbStatisticsMenu.Size = new System.Drawing.Size(340, 502);
            this.gbStatisticsMenu.TabIndex = 1;
            this.gbStatisticsMenu.TabStop = false;
            // 
            // btn_open_graphs
            // 
            this.btn_open_graphs.Enabled = false;
            this.btn_open_graphs.Location = new System.Drawing.Point(172, 432);
            this.btn_open_graphs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_open_graphs.Name = "btn_open_graphs";
            this.btn_open_graphs.Size = new System.Drawing.Size(140, 34);
            this.btn_open_graphs.TabIndex = 15;
            this.btn_open_graphs.Text = "Graphs";
            this.btn_open_graphs.UseVisualStyleBackColor = true;
            this.btn_open_graphs.Click += new System.EventHandler(this.btn_open_graphs_Click);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lbl_name.Location = new System.Drawing.Point(199, 96);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(0, 20);
            this.lbl_name.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label7.Location = new System.Drawing.Point(44, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Layout Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(221, 299);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "-";
            // 
            // lbl_end_date
            // 
            this.lbl_end_date.AutoSize = true;
            this.lbl_end_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_end_date.Location = new System.Drawing.Point(199, 319);
            this.lbl_end_date.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_end_date.Name = "lbl_end_date";
            this.lbl_end_date.Size = new System.Drawing.Size(0, 20);
            this.lbl_end_date.TabIndex = 12;
            // 
            // lbl_avg_time
            // 
            this.lbl_avg_time.AutoSize = true;
            this.lbl_avg_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_avg_time.Location = new System.Drawing.Point(199, 246);
            this.lbl_avg_time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_avg_time.Name = "lbl_avg_time";
            this.lbl_avg_time.Size = new System.Drawing.Size(0, 20);
            this.lbl_avg_time.TabIndex = 11;
            // 
            // lbl_total_people
            // 
            this.lbl_total_people.AutoSize = true;
            this.lbl_total_people.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_people.Location = new System.Drawing.Point(199, 160);
            this.lbl_total_people.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_total_people.Name = "lbl_total_people";
            this.lbl_total_people.Size = new System.Drawing.Size(0, 20);
            this.lbl_total_people.TabIndex = 10;
            // 
            // lbl_start_date
            // 
            this.lbl_start_date.AutoSize = true;
            this.lbl_start_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_start_date.Location = new System.Drawing.Point(199, 279);
            this.lbl_start_date.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_start_date.Name = "lbl_start_date";
            this.lbl_start_date.Size = new System.Drawing.Size(0, 20);
            this.lbl_start_date.TabIndex = 9;
            // 
            // lbl_avg_deaths
            // 
            this.lbl_avg_deaths.AutoSize = true;
            this.lbl_avg_deaths.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_avg_deaths.Location = new System.Drawing.Point(199, 206);
            this.lbl_avg_deaths.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_avg_deaths.Name = "lbl_avg_deaths";
            this.lbl_avg_deaths.Size = new System.Drawing.Size(0, 20);
            this.lbl_avg_deaths.TabIndex = 8;
            // 
            // lbl_total_sims
            // 
            this.lbl_total_sims.AutoSize = true;
            this.lbl_total_sims.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_sims.Location = new System.Drawing.Point(199, 128);
            this.lbl_total_sims.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_total_sims.Name = "lbl_total_sims";
            this.lbl_total_sims.Size = new System.Drawing.Size(0, 20);
            this.lbl_total_sims.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 246);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "AVG Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 279);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Time Period:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 206);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "AVG Deaths:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 164);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "People:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Simulations Ran:";
            // 
            // lbStatistics
            // 
            this.lbStatistics.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbStatistics.AutoSize = true;
            this.lbStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatistics.Location = new System.Drawing.Point(119, 18);
            this.lbStatistics.Name = "lbStatistics";
            this.lbStatistics.Size = new System.Drawing.Size(108, 29);
            this.lbStatistics.TabIndex = 1;
            this.lbStatistics.Text = "Statistics";
            // 
            // gbSimulationPreviews
            // 
            this.gbSimulationPreviews.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSimulationPreviews.Controls.Add(this.panel_overview);
            this.gbSimulationPreviews.Location = new System.Drawing.Point(12, 530);
            this.gbSimulationPreviews.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbSimulationPreviews.Name = "gbSimulationPreviews";
            this.gbSimulationPreviews.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbSimulationPreviews.Size = new System.Drawing.Size(647, 183);
            this.gbSimulationPreviews.TabIndex = 2;
            this.gbSimulationPreviews.TabStop = false;
            // 
            // panel_overview
            // 
            this.panel_overview.Location = new System.Drawing.Point(7, 10);
            this.panel_overview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_overview.Name = "panel_overview";
            this.panel_overview.Size = new System.Drawing.Size(633, 167);
            this.panel_overview.TabIndex = 0;
            // 
            // gbOrderMenu
            // 
            this.gbOrderMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOrderMenu.Controls.Add(this.cbbPreviewOrder);
            this.gbOrderMenu.Controls.Add(this.lbSort);
            this.gbOrderMenu.Location = new System.Drawing.Point(675, 530);
            this.gbOrderMenu.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.gbOrderMenu.Name = "gbOrderMenu";
            this.gbOrderMenu.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbOrderMenu.Size = new System.Drawing.Size(340, 186);
            this.gbOrderMenu.TabIndex = 2;
            this.gbOrderMenu.TabStop = false;
            // 
            // cbbPreviewOrder
            // 
            this.cbbPreviewOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbPreviewOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPreviewOrder.FormattingEnabled = true;
            this.cbbPreviewOrder.Location = new System.Drawing.Point(31, 107);
            this.cbbPreviewOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbPreviewOrder.Name = "cbbPreviewOrder";
            this.cbbPreviewOrder.Size = new System.Drawing.Size(280, 24);
            this.cbbPreviewOrder.TabIndex = 5;
            // 
            // lbSort
            // 
            this.lbSort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSort.AutoSize = true;
            this.lbSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSort.Location = new System.Drawing.Point(145, 50);
            this.lbSort.Name = "lbSort";
            this.lbSort.Size = new System.Drawing.Size(57, 29);
            this.lbSort.TabIndex = 4;
            this.lbSort.Text = "Sort";
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 727);
            this.Controls.Add(this.gbSimulationPreviews);
            this.Controls.Add(this.gbSearchMenu);
            this.Controls.Add(this.pbSelectedPreview);
            this.Controls.Add(this.gbStatisticsMenu);
            this.Controls.Add(this.gbOrderMenu);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1418, 691);
            this.Name = "Statistics";
            this.Text = "Lit - Statistics";
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
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel_overview;
        private System.Windows.Forms.Button btn_open_graphs;
    }
}