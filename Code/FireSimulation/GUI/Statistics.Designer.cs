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
			this.gbStatisticsMenu = new System.Windows.Forms.GroupBox();
			this.lbl_scenario = new System.Windows.Forms.Label();
			this.lblScenario = new System.Windows.Forms.Label();
			this.lbl_ratio = new System.Windows.Forms.Label();
			this.lblSuccessRatio = new System.Windows.Forms.Label();
			this.btn_open_graphs = new System.Windows.Forms.Button();
			this.lbl_name = new System.Windows.Forms.Label();
			this.lblLayoutName = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lbl_end_date = new System.Windows.Forms.Label();
			this.lbl_avg_time = new System.Windows.Forms.Label();
			this.lbl_total_people = new System.Windows.Forms.Label();
			this.lbl_start_date = new System.Windows.Forms.Label();
			this.lbl_avg_deaths = new System.Windows.Forms.Label();
			this.lbl_total_sims = new System.Windows.Forms.Label();
			this.lblAvgTime = new System.Windows.Forms.Label();
			this.lblTimePeriod = new System.Windows.Forms.Label();
			this.lblAvgDeaths = new System.Windows.Forms.Label();
			this.lblPeople = new System.Windows.Forms.Label();
			this.lblSimulationsRun = new System.Windows.Forms.Label();
			this.lbStatistics = new System.Windows.Forms.Label();
			this.gbSimulationPreviews = new System.Windows.Forms.GroupBox();
			this.panel_overview = new System.Windows.Forms.Panel();
			this.gbOrderMenu = new System.Windows.Forms.GroupBox();
			this.cbbPreviewOrder = new System.Windows.Forms.ComboBox();
			this.lbSort = new System.Windows.Forms.Label();
			this.pbSelectedPreview = new System.Windows.Forms.PictureBox();
			this.groupBox2.SuspendLayout();
			this.gbSearchMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.btSearch)).BeginInit();
			this.gbStatisticsMenu.SuspendLayout();
			this.gbSimulationPreviews.SuspendLayout();
			this.gbOrderMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbSelectedPreview)).BeginInit();
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
			this.btReplaySelected.Text = "Run new simulation";
			this.btReplaySelected.UseVisualStyleBackColor = true;
			this.btReplaySelected.Visible = false;
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
			this.lbSearchResults.SelectedIndexChanged += new System.EventHandler(this.lbSearchResults_SelectedIndexChanged);
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
			this.tbSearchQuery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearchQuery_KeyPress);
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
			// gbStatisticsMenu
			// 
			this.gbStatisticsMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbStatisticsMenu.Controls.Add(this.lbl_scenario);
			this.gbStatisticsMenu.Controls.Add(this.lblScenario);
			this.gbStatisticsMenu.Controls.Add(this.lbl_ratio);
			this.gbStatisticsMenu.Controls.Add(this.lblSuccessRatio);
			this.gbStatisticsMenu.Controls.Add(this.btn_open_graphs);
			this.gbStatisticsMenu.Controls.Add(this.lbl_name);
			this.gbStatisticsMenu.Controls.Add(this.lblLayoutName);
			this.gbStatisticsMenu.Controls.Add(this.label6);
			this.gbStatisticsMenu.Controls.Add(this.lbl_end_date);
			this.gbStatisticsMenu.Controls.Add(this.lbl_avg_time);
			this.gbStatisticsMenu.Controls.Add(this.lbl_total_people);
			this.gbStatisticsMenu.Controls.Add(this.lbl_start_date);
			this.gbStatisticsMenu.Controls.Add(this.lbl_avg_deaths);
			this.gbStatisticsMenu.Controls.Add(this.lbl_total_sims);
			this.gbStatisticsMenu.Controls.Add(this.lblAvgTime);
			this.gbStatisticsMenu.Controls.Add(this.lblTimePeriod);
			this.gbStatisticsMenu.Controls.Add(this.lblAvgDeaths);
			this.gbStatisticsMenu.Controls.Add(this.lblPeople);
			this.gbStatisticsMenu.Controls.Add(this.lblSimulationsRun);
			this.gbStatisticsMenu.Controls.Add(this.lbStatistics);
			this.gbStatisticsMenu.Location = new System.Drawing.Point(506, 11);
			this.gbStatisticsMenu.Margin = new System.Windows.Forms.Padding(2);
			this.gbStatisticsMenu.Name = "gbStatisticsMenu";
			this.gbStatisticsMenu.Padding = new System.Windows.Forms.Padding(2);
			this.gbStatisticsMenu.Size = new System.Drawing.Size(255, 408);
			this.gbStatisticsMenu.TabIndex = 1;
			this.gbStatisticsMenu.TabStop = false;
			// 
			// lbl_scenario
			// 
			this.lbl_scenario.AutoSize = true;
			this.lbl_scenario.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lbl_scenario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_scenario.Location = new System.Drawing.Point(83, 317);
			this.lbl_scenario.Name = "lbl_scenario";
			this.lbl_scenario.Size = new System.Drawing.Size(0, 15);
			this.lbl_scenario.TabIndex = 19;
			this.lbl_scenario.Click += new System.EventHandler(this.scenario_Click);
			// 
			// lblScenario
			// 
			this.lblScenario.AutoSize = true;
			this.lblScenario.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblScenario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblScenario.Location = new System.Drawing.Point(6, 317);
			this.lblScenario.Name = "lblScenario";
			this.lblScenario.Size = new System.Drawing.Size(81, 15);
			this.lblScenario.TabIndex = 18;
			this.lblScenario.Text = "Top scenario:";
			this.lblScenario.Click += new System.EventHandler(this.scenario_Click);
			// 
			// lbl_ratio
			// 
			this.lbl_ratio.AutoSize = true;
			this.lbl_ratio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_ratio.Location = new System.Drawing.Point(148, 287);
			this.lbl_ratio.Name = "lbl_ratio";
			this.lbl_ratio.Size = new System.Drawing.Size(0, 16);
			this.lbl_ratio.TabIndex = 17;
			// 
			// lblSuccessRatio
			// 
			this.lblSuccessRatio.AutoSize = true;
			this.lblSuccessRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSuccessRatio.Location = new System.Drawing.Point(32, 287);
			this.lblSuccessRatio.Name = "lblSuccessRatio";
			this.lblSuccessRatio.Size = new System.Drawing.Size(92, 16);
			this.lblSuccessRatio.TabIndex = 16;
			this.lblSuccessRatio.Text = "Success ratio:";
			// 
			// btn_open_graphs
			// 
			this.btn_open_graphs.Enabled = false;
			this.btn_open_graphs.Location = new System.Drawing.Point(129, 351);
			this.btn_open_graphs.Name = "btn_open_graphs";
			this.btn_open_graphs.Size = new System.Drawing.Size(105, 28);
			this.btn_open_graphs.TabIndex = 15;
			this.btn_open_graphs.Text = "Graphs";
			this.btn_open_graphs.UseVisualStyleBackColor = true;
			this.btn_open_graphs.Click += new System.EventHandler(this.btn_open_graphs_Click);
			// 
			// lbl_name
			// 
			this.lbl_name.AutoSize = true;
			this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.lbl_name.Location = new System.Drawing.Point(149, 78);
			this.lbl_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbl_name.Name = "lbl_name";
			this.lbl_name.Size = new System.Drawing.Size(0, 16);
			this.lbl_name.TabIndex = 14;
			// 
			// lblLayoutName
			// 
			this.lblLayoutName.AutoSize = true;
			this.lblLayoutName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.lblLayoutName.Location = new System.Drawing.Point(33, 78);
			this.lblLayoutName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblLayoutName.Name = "lblLayoutName";
			this.lblLayoutName.Size = new System.Drawing.Size(88, 16);
			this.lblLayoutName.TabIndex = 2;
			this.lblLayoutName.Text = "Layout name:";
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
			// lbl_end_date
			// 
			this.lbl_end_date.AutoSize = true;
			this.lbl_end_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_end_date.Location = new System.Drawing.Point(149, 259);
			this.lbl_end_date.Name = "lbl_end_date";
			this.lbl_end_date.Size = new System.Drawing.Size(0, 16);
			this.lbl_end_date.TabIndex = 12;
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
			// lbl_total_people
			// 
			this.lbl_total_people.AutoSize = true;
			this.lbl_total_people.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_total_people.Location = new System.Drawing.Point(149, 130);
			this.lbl_total_people.Name = "lbl_total_people";
			this.lbl_total_people.Size = new System.Drawing.Size(0, 16);
			this.lbl_total_people.TabIndex = 10;
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
			// lbl_avg_deaths
			// 
			this.lbl_avg_deaths.AutoSize = true;
			this.lbl_avg_deaths.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_avg_deaths.Location = new System.Drawing.Point(149, 167);
			this.lbl_avg_deaths.Name = "lbl_avg_deaths";
			this.lbl_avg_deaths.Size = new System.Drawing.Size(0, 16);
			this.lbl_avg_deaths.TabIndex = 8;
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
			// lblAvgTime
			// 
			this.lblAvgTime.AutoSize = true;
			this.lblAvgTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAvgTime.Location = new System.Drawing.Point(32, 200);
			this.lblAvgTime.Name = "lblAvgTime";
			this.lblAvgTime.Size = new System.Drawing.Size(67, 16);
			this.lblAvgTime.TabIndex = 6;
			this.lblAvgTime.Text = "AVG time:";
			// 
			// lblTimePeriod
			// 
			this.lblTimePeriod.AutoSize = true;
			this.lblTimePeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTimePeriod.Location = new System.Drawing.Point(32, 227);
			this.lblTimePeriod.Name = "lblTimePeriod";
			this.lblTimePeriod.Size = new System.Drawing.Size(84, 16);
			this.lblTimePeriod.TabIndex = 5;
			this.lblTimePeriod.Text = "Time period:";
			// 
			// lblAvgDeaths
			// 
			this.lblAvgDeaths.AutoSize = true;
			this.lblAvgDeaths.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAvgDeaths.Location = new System.Drawing.Point(32, 167);
			this.lblAvgDeaths.Name = "lblAvgDeaths";
			this.lblAvgDeaths.Size = new System.Drawing.Size(83, 16);
			this.lblAvgDeaths.TabIndex = 4;
			this.lblAvgDeaths.Text = "AVG deaths:";
			// 
			// lblPeople
			// 
			this.lblPeople.AutoSize = true;
			this.lblPeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPeople.Location = new System.Drawing.Point(32, 133);
			this.lblPeople.Name = "lblPeople";
			this.lblPeople.Size = new System.Drawing.Size(55, 16);
			this.lblPeople.TabIndex = 3;
			this.lblPeople.Text = "People:";
			// 
			// lblSimulationsRun
			// 
			this.lblSimulationsRun.AutoSize = true;
			this.lblSimulationsRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSimulationsRun.Location = new System.Drawing.Point(32, 104);
			this.lblSimulationsRun.Name = "lblSimulationsRun";
			this.lblSimulationsRun.Size = new System.Drawing.Size(101, 16);
			this.lblSimulationsRun.TabIndex = 2;
			this.lblSimulationsRun.Text = "Simulations run:";
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
			// panel_overview
			// 
			this.panel_overview.Location = new System.Drawing.Point(5, 8);
			this.panel_overview.Name = "panel_overview";
			this.panel_overview.Size = new System.Drawing.Size(475, 136);
			this.panel_overview.TabIndex = 0;
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
			this.MinimumSize = new System.Drawing.Size(1068, 570);
			this.Name = "Statistics";
			this.Text = "Lit - Statistics";
			this.groupBox2.ResumeLayout(false);
			this.gbSearchMenu.ResumeLayout(false);
			this.gbSearchMenu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.btSearch)).EndInit();
			this.gbStatisticsMenu.ResumeLayout(false);
			this.gbStatisticsMenu.PerformLayout();
			this.gbSimulationPreviews.ResumeLayout(false);
			this.gbOrderMenu.ResumeLayout(false);
			this.gbOrderMenu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbSelectedPreview)).EndInit();
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
        private System.Windows.Forms.Label lblAvgTime;
        private System.Windows.Forms.Label lblTimePeriod;
        private System.Windows.Forms.Label lblAvgDeaths;
        private System.Windows.Forms.Label lblPeople;
        private System.Windows.Forms.Label lblSimulationsRun;
        private System.Windows.Forms.Label lbl_avg_time;
        private System.Windows.Forms.Label lbl_total_people;
        private System.Windows.Forms.Label lbl_start_date;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_end_date;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lblLayoutName;
        private System.Windows.Forms.Panel panel_overview;
        private System.Windows.Forms.Button btn_open_graphs;
		private System.Windows.Forms.Label lbl_ratio;
		private System.Windows.Forms.Label lblSuccessRatio;
		private System.Windows.Forms.Label lblScenario;
		private System.Windows.Forms.Label lbl_scenario;
	}
}