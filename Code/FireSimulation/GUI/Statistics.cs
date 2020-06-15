using FireSimulator.GUI;
using Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FireSimulator
{
	public partial class Statistics : Form
	{
		private enum SortingOptions
		{
			None,
			MostDeaths,
			LeastDeaths,
			MostSuccessful,
			LeastSuccessful
		}

		private enum SearchOptions
		{
			Title,
			Duration,
			Deathcount
		}

		private Dictionary<EScenario, int> scenarioCount;
		private SaveItem[] layouts;

		private Dictionary<SaveItem, Image> layoutImages;
		private SaveItem selected;

		public Statistics(SaveItem floorplan)
		{
			InitializeComponent();
			this.layoutImages = new Dictionary<SaveItem, Image>();
			panel_overview.AutoScroll = false;
			panel_overview.VerticalScroll.Enabled = false;
			panel_overview.VerticalScroll.Visible = false;
			panel_overview.VerticalScroll.Maximum = 0;
			panel_overview.AutoScroll = true;

			this.layouts = ((Floorplan)floorplan.Item).GetAllLayouts();
			this.UpdateSearchResults(layouts.ToList());

			this.Text = $"Lit - Statistics for '{floorplan.Name}' floorplan";
			populateLayoutPreview();

			// put options into the drobdown boxes
			this.cbbPreviewOrder.Items.AddRange(Enum.GetNames(typeof(SortingOptions)));
			this.cbbPreviewOrder.SelectedItem = Enum.GetName(typeof(SortingOptions), SortingOptions.None);
			this.cbbSearchOption.Items.AddRange(Enum.GetNames(typeof(SearchOptions)));

			// add eventhandlers to controls
			this.cbbPreviewOrder.SelectedIndexChanged += new EventHandler(SortSimulations);
			this.btReplaySelected.Click += new EventHandler(ReplaySelected);
			this.btSearch.Click += new EventHandler(FilterSimulations);
			this.tbSearchQuery.GotFocus += new EventHandler(AddPlaceholder);
			this.tbSearchQuery.LostFocus += new EventHandler(RemovePlaceholder);
		}

		private void RemovePlaceholder(object sender, EventArgs e)
		{
			if (this.tbSearchQuery.Text == "eg. \"Default\"" || this.tbSearchQuery.Text == "eg. \"120\" (In seconds)" ||
				this.tbSearchQuery.Text == "eg. \"2\"")
			{
				this.tbSearchQuery.Text = "";
			}
		}

		private void AddPlaceholder(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(this.tbSearchQuery.Text))
			{
				if (this.cbbSearchOption.SelectedItem != null)
				{
					SearchOptions option = (SearchOptions)Enum.Parse(typeof(SearchOptions), (string)this.cbbSearchOption.SelectedItem);

					if (option == SearchOptions.Title)
					{
						this.tbSearchQuery.Text = "eg. \"Default\"";
					}
					else if (option == SearchOptions.Duration)
					{
						this.tbSearchQuery.Text = "eg. \"120\" (In seconds)";
					}
					else if (option == SearchOptions.Deathcount)
					{
						this.tbSearchQuery.Text = "eg. \"2\"";
					}
				}
			}
		}

		private void ReplaySelected(object sender, EventArgs e)
		{
			if (this.selected != null)
				new FireSimulatorForm(this.selected).ShowDialog();
			else
				MessageBox.Show("No layout selected");
		}

		private void SortSimulations()
		{
			SortingOptions option = (SortingOptions)Enum.Parse(typeof(SortingOptions), (string)this.cbbPreviewOrder.SelectedItem);
			var sorted = new SaveItem[this.layouts.Length];

			switch (option)
			{
				case SortingOptions.None:
					{
						sorted = this.layouts;
						break;
					}
				case SortingOptions.LeastDeaths:
					{
						sorted = this.layouts.Select(_ => (_, ((Layout)_.Item).GetAverageDeathAmount())).OrderBy(_ => _.Item2).Select(_ => _._).ToArray();
						break;
					}
				case SortingOptions.MostDeaths:
					{
						sorted = this.layouts.Select(_ => (_, ((Layout)_.Item).GetAverageDeathAmount())).OrderByDescending(_ => _.Item2).Select(_ => _._).ToArray();
						break;
					}
				case SortingOptions.MostSuccessful:
					{
						sorted = this.layouts.Select(_ => (_, ((Layout)_.Item).GetAverageElapsedTime())).OrderBy(_ => _.Item2).Select(_ => _._).ToArray();
						break;
					}
				case SortingOptions.LeastSuccessful:
					{
						sorted = this.layouts.Select(_ => (_, ((Layout)_.Item).GetAverageElapsedTime())).OrderByDescending(_ => _.Item2).Select(_ => _._).ToArray();
						break;
					}
			}

			this.layouts = sorted;
			populateLayoutPreview();
		}

		private void SortSimulations(object sender, EventArgs e)
		{
			this.SortSimulations();
		}

		private void FilterLayouts(SearchOptions options, string searchQuery)
		{
			List<SaveItem> filered = new List<SaveItem>();

			foreach (SaveItem layout in this.layouts)
			{
				if (options == SearchOptions.Title)
				{
					string layoutName = layout.Name.ToLower();

					if (layoutName.Contains(searchQuery.ToLower()))
						filered.Add(layout);
				}
				else if (options == SearchOptions.Duration)
				{
					var time = ((Layout)layout.Item).GetAverageElapsedTime();
					int number;

					try
					{
						number = int.Parse(searchQuery);
					}
					catch (Exception)
					{
						MessageBox.Show("Invalid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					if (time != null && time?.TotalSeconds == number)
						filered.Add(layout);
				}
				else if (options == SearchOptions.Deathcount)
				{
					var deathAmount = ((Layout)layout.Item).GetAverageDeathAmount();
					int number;

					try
					{
						number = int.Parse(searchQuery);
					}
					catch (Exception)
					{
						MessageBox.Show("Invalid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					if (deathAmount >= 0 && deathAmount == number)
						filered.Add(layout);
				}
			}

			this.UpdateSearchResults(filered);
		}

		private void UpdateSearchResults(List<SaveItem> layouts)
		{
			this.lbSearchResults.Items.Clear();

			foreach (SaveItem layout in layouts)
			{
				this.lbSearchResults.Items.Add(layout);
			}
		}

		private void FilterSimulations(object sender, EventArgs e)
		{
			if (this.cbbSearchOption.SelectedItem == null)
			{
				MessageBox.Show("Please select a search option", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			SearchOptions options = (SearchOptions)Enum.Parse(typeof(SearchOptions), (string)this.cbbSearchOption.SelectedItem);
			string query = this.tbSearchQuery.Text;

			this.FilterLayouts(options, query);
		}

		private void populateLayoutPreview()
		{
			this.panel_overview.Controls.Clear();

			for (int i = 0; i < layouts.Length; i++)
			{
				PictureBox pb1 = new PictureBox();
				SaveItem l = layouts[i];

				Image image = ((Thumbnailable)l.Item).Render(panel_overview.Height - 10);
				this.layoutImages[l] = image;

				pb1.Image = image;
				pb1.Size = new Size(panel_overview.Height - 10, panel_overview.Height - 10);
				pb1.Location = new Point(pb1.Width * i + 2, 8);
				pb1.SizeMode = PictureBoxSizeMode.Zoom;

				pb1.MouseClick += (sender, e) => showStatistics(sender, l);

				panel_overview.Controls.Add(pb1);
			}
		}

		private void lbSearchResults_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbSearchResults.SelectedItem != null)
			{
				SaveItem l = (SaveItem)lbSearchResults.SelectedItem;
				Image i = this.layoutImages.FirstOrDefault(li => li.Key == l).Value;
				showStatistics(l, i);
			}
		}

		private void showStatistics(object sender, SaveItem l)
			=> showStatistics(l, ((PictureBox)sender).Image);

		private void showStatistics(SaveItem l, Image layoutImage = null)
		{
			var simData = ((Layout)l.Item).GetSimulatioData();
			this.selected = l;
			this.btReplaySelected.Visible = true;


			if (simData.Length > 0)
			{
				float totalDeaths = 0;
				double totalTime = 0;
				int success = 0;

				DateTime end = simData[simData.Length - 1].DateOfSimulation;
				DateTime start = simData[0].DateOfSimulation;
				int people = simData[0].NrOfPeople;

				foreach (var data in simData)
				{
					totalDeaths += data.NrOfDeaths;
					totalTime += data.SimulationTime.TotalSeconds;

					if (data.IsSuccessful)
						success += 1;
				}

				this.scenarioCount = new Dictionary<EScenario, int>();
				foreach (var data in simData)
				{
					var scenario = data.Scenario;

					if (scenarioCount.ContainsKey(scenario))
						scenarioCount[scenario]++;
					else
						scenarioCount[scenario] = 1;
				}
				Tuple<int, EScenario> topScenario = new Tuple<int, EScenario>(-1, 0);
				foreach (var s in scenarioCount)
					if (s.Value > topScenario.Item1)
						topScenario = new Tuple<int, EScenario>(s.Value, s.Key);

				pbSelectedPreview.Image = layoutImage;
				pbSelectedPreview.SizeMode = PictureBoxSizeMode.Zoom;

				lbl_name.Text = l.Name;
				lbl_total_sims.Text = $"{simData.Length}";
				lbl_total_people.Text = $"{people}";
				lbl_start_date.Text = $"{start.ToShortDateString()}";
				lbl_end_date.Text = $"{end.ToShortDateString()}";
				lbl_avg_deaths.Text = $"{Math.Round(totalDeaths / simData.Length, 2)}";
				lbl_avg_time.Text = $"{Math.Round(totalTime / simData.Length, 2)} sec.";
				lbl_ratio.Text = $"{success} : {simData.Length - success}";
				lbl_scenario.Text = FinishedEventArgs.ScenarioMessageList[topScenario.Item2];
				btn_open_graphs.Enabled = true;
			}
			else
			{
				MessageBox.Show($"No simulation data found for {l.Name} layout.");
			}
		}

		private void tbSearchQuery_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				if (this.cbbSearchOption.SelectedItem == null)
				{
					MessageBox.Show("Please select a search option", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				SearchOptions options = (SearchOptions)Enum.Parse(typeof(SearchOptions), (string)this.cbbSearchOption.SelectedItem);
				string query = this.tbSearchQuery.Text;

				this.FilterLayouts(options, query);
			}
		}

		private void btn_open_graphs_Click(object sender, EventArgs e)
			=> new GraphForm(this.selected).ShowDialog();

		private void scenario_Click(object sender, EventArgs e)
		{
			if (this.scenarioCount != null && this.selected != null)
				new ScenarioDialog(this.scenarioCount.ToArray(), this.selected.Name).ShowDialog();
		}
	}
}