using System;
using System.Collections.Generic;
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

		private FileInfo[] simulations;

		public Statistics()
		{
			InitializeComponent();

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
	}
}