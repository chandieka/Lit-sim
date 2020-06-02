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

		private SaveItem floorplan;
		private SimulationData[] simData;
		private SaveItem[] layouts;

		private SaveItem selected;

		public Statistics(SaveItem floorplan)
		{
			InitializeComponent();
			panel_overview.AutoScroll = false;
			panel_overview.VerticalScroll.Enabled = false;
			panel_overview.VerticalScroll.Visible = false;
			panel_overview.VerticalScroll.Maximum = 0;
			panel_overview.AutoScroll = true;

			this.floorplan = floorplan;
			layouts = ((Floorplan)floorplan.Item).GetAllLayouts();
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

		public void SetSimulations(SaveItem[] simulations)
		{
			this.layouts = simulations;
		}

		private void ReplaySelected(object sender, EventArgs e)
		{
			// TODO
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

		private void btReplaySelected_Click(object sender, EventArgs e)
		{
		}

		private void populateLayoutPreview()
		{
			this.panel_overview.Controls.Clear();

			if (layouts.Length > 0)
			{
				for (int i = 0; i < layouts.Length; i += 1)
				{
					PictureBox pb1 = new PictureBox();

					var l = layouts[i];

					pb1.Image = ((Thumbnailable)l.Item).Render(panel_overview.Height - 10);
					pb1.Size = new Size(panel_overview.Height - 10, panel_overview.Height - 10);
					pb1.Location = new Point(pb1.Width * i + 2, 8);
					pb1.SizeMode = PictureBoxSizeMode.Zoom;

					pb1.MouseClick += (sender, e) => showStatistics(sender, l);

					panel_overview.Controls.Add(pb1);
				}
			}
		}

		private void lbSearchResults_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbSearchResults.SelectedItem != null)
			{
				showStatistics((SaveItem)lbSearchResults.SelectedItem);
			}
		}

		private void showStatistics(object sender, SaveItem l)
			=> showStatistics(l, (PictureBox)sender);

		private void showStatistics(SaveItem l, PictureBox pb = null)
		{
			var simData = ((Layout)l.Item).GetSimulatioData();
			this.selected = l;

			float totalDeaths = 0;
			DateTime start, end;
			int people = 0;

			if (pb == null)
				pb = this.pbSelectedPreview;

			if (simData.Length > 0)
			{
				start = simData[0].DateOfSimulation;
				people = simData[0].NrOfPeople;
				end = simData[simData.Length - 1].DateOfSimulation;

				foreach (var data in simData)
				{
					totalDeaths += data.NrOfDeaths;
				}

				pbSelectedPreview.Image = pb.Image;
				pbSelectedPreview.SizeMode = PictureBoxSizeMode.Zoom;

				lbl_name.Text = l.Name;
				lbl_total_sims.Text = $"{simData.Length}";
				lbl_total_people.Text = $"{people}";
				lbl_start_date.Text = $"{start.ToShortDateString()}";
				lbl_end_date.Text = $"{end.ToShortDateString()}";
				lbl_avg_deaths.Text = $"{totalDeaths / simData.Length}";
				btn_open_graphs.Enabled = true;
			}
			else
			{
				MessageBox.Show($"No simulation data found for {l.Name} layout.");
			}
		}

		private void vsbPreviewScroller_Scroll(object sender, ScrollEventArgs e)
		{
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
		{
			GraphForm form = new GraphForm(this.selected);
			form.ShowDialog();
		}
	}
}