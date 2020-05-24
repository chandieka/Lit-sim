using Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FireSimulator
{
	public partial class Statistics : Form
	{
		private enum SortingOptions
		{
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
		private FileInfo[] simulations;
        private SimulationData[] simData;
		private SaveItem[] layouts;

		public Statistics(SaveItem floorplan)
		{
			InitializeComponent();
			this.floorplan = floorplan;
			layouts = ((Floorplan)floorplan.Item).GetAllLayouts();

			this.Text = $"Statistics for {floorplan.Name} Floorplan";
			populateLayoutPreview();

			// put options into the drobdown boxes
			this.cbbPreviewOrder.Items.AddRange(Enum.GetNames(typeof(SortingOptions)));
			this.cbbSearchOption.Items.AddRange(Enum.GetNames(typeof(SearchOptions)));

			// add eventhandlers to controls
			this.cbbPreviewOrder.SelectedValueChanged += new EventHandler(SortSimulations);
			this.btReplaySelected.Click += new EventHandler(ReplaySelected);
			this.btSearch.Click += new EventHandler(FilterSimulations);
		}

		public void SetSimulations(FileInfo[] simulations)
		{
			this.simulations = simulations;
		}

		private void ShowSimulations(FileInfo[] simulations)
		{
			// TODO
			this.gbSimulationPreviews.Controls.Clear();

			for (int i = 0; i < simulations.Length; i++)
			{
				// create a display
				// add the display to this.gbSimulationPreviews.Controls
			}
		}

		private void ReplaySelected(object sender, EventArgs e)
		{
			// TODO
		}

		private void SortSimulations(FileInfo[] filtered)
		{
			SortingOptions options = (SortingOptions)Enum.Parse(typeof(SortingOptions), (string)this.cbbPreviewOrder.SelectedItem);
			FileInfo[] sorted = new FileInfo[filtered.Length];

			for (int i = 0; i < filtered.Length; i++)
			{
			}

			this.ShowSimulations(sorted.ToArray());
		}

		private void SortSimulations(object sender, EventArgs e)
		{
			this.FilterSimulations(sender, e);
		}

		private void FilterSimulations(SearchOptions options, string searchQuery)
		{
			List<FileInfo> filtered = new List<FileInfo>();

			for (int i = 0; i < this.simulations.Length; i++)
			{
			}

			this.SortSimulations(filtered.ToArray());
		}

		private void FilterSimulations(object sender, EventArgs e)
		{
			SearchOptions options = (SearchOptions)Enum.Parse(typeof(SearchOptions), (string)this.cbbSearchOption.SelectedItem);
			string query = this.tbSearchQuery.Text;

			this.FilterSimulations(options, query);
		}

		private void btReplaySelected_Click(object sender, EventArgs e)
		{

		}

		private void populateLayoutPreview()
		{
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

                    pb1.MouseClick += new MouseEventHandler(showPreview);
                    pb1.MouseClick += (sender, e) => showStatistics(sender, e, l);

                    panel_overview.Controls.Add(pb1);
                }
            }
        }

        private void showStatistics(object sender, MouseEventArgs e, SaveItem l)
        {
            simData = ((Layout)l.Item).GetSimulatioData();
			

			float totalDeaths = 0;
			int people = 0;
			DateTime start, end;

			if (simData.Length > 0)
			{
				start = simData[0].DateOfSimulation;
				people = simData[0].NrOfPeople;
				end = simData[simData.Length - 1].DateOfSimulation;

				foreach (var data in simData)
				{
					totalDeaths += data.NrOfDeaths;
				}

				lbl_total_sims.Text = $"{simData.Length}";
				lbl_start_date.Text = $"{start}";
				lbl_end_date.Text = $"{end}";
				lbl_avg_deaths.Text = $"{totalDeaths/ simData.Length}";
			}
			else
			{
				MessageBox.Show($"No simulation data found for {l.Name} layout.");
			}

		}

        private void showPreview(object sender, MouseEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pbSelectedPreview.Image = pb.Image;
            pbSelectedPreview.SizeMode = PictureBoxSizeMode.Zoom;
        }

		private void vsbPreviewScroller_Scroll(object sender, ScrollEventArgs e)
		{

		}
	}
}