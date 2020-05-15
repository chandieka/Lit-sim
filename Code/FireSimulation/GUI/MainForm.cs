using System;
using System.IO;
using System.Windows.Forms;
using Library;

namespace FireSimulator
{
	public partial class MainForm : Form
	{
		private FloorplanController floorplanController;

		public MainForm()
		{
			InitializeComponent();

			floorplanController = new FloorplanController();
			CreateDefaultFloorplan();
			loadFloorplan();
		}

		#region Private Methods

		private void CreateDefaultFloorplan()
			=> floorplanController.Add(new SaveItem(GridController.CreateDefaultFloorplan(), "Default"));

		private void loadFloorplan()
		{
			try
			{
				foreach (string path in Directory.GetFiles(SaveLoadManager.GetSaveFolder()))
				{
					// Check if it is a file
					if (!File.GetAttributes(path).HasFlag(FileAttributes.Directory))
					{
						Console.WriteLine($"Parsing {path}...");
						var itm = SaveLoadManager.Load(path);

						if (itm.Item is Floorplan)
							floorplanController.Add(itm);
					}

					// new Thread(() =>
					// {
					// 	Console.WriteLine($"Parsing {path}...");
					// 	var itm = SaveLoadManager.Load(path);

					// 	if (itm.Item is Floorplan)
					// 	{
					// 		floorplanController.AddFloorPlan((Floorplan)itm.Item);
					// 		lvFloorplan.Invoke(new Action(() =>
					// 		{
					// 			lvFloorplan.Items.Add(itm.Item.Id.ToString(), itm.Name, "");
					// 		}));
					// 	}

					// }).Start();
				}

				UpdateFloorplanGUI();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				MessageBox.Show(
					"There was an error with finding all the saved layouts",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				Application.Exit();
			}
		}

		private void UpdateFloorplanGUI()
		{
			lvFloorplan.Items.Clear();
			foreach (var item in floorplanController.GetAll())
				lvFloorplan.Items.Add(item.Item.Id.ToString(), item.Name, null);
		}
		#endregion
		#region Event Handler
		private void btnFPCopy_Click(object sender, EventArgs e)
		{

		}

		private void btnFPDelete_Click(object sender, EventArgs e)
		{
			// TODO: Add confirmation
			var selected = lvFloorplan.SelectedItems;
			if (selected != null && selected.Count > 0)
			{
				SaveLoadManager.Delete(Guid.Parse(selected[0].Name));
				lvFloorplan.Items.Remove(selected[0]);
				UpdateFloorplanGUI();
			}
		}

		private void btnFPEdit_Click(object sender, EventArgs e)
		{

		}

		private void btnFPCreate_Click(object sender, EventArgs e)
		{
			new DesignerForm(100, 100).ShowDialog(); // TODO: Add popup that lets the user choose the size
		}


		private void btnLEdit_Click(object sender, EventArgs e)
		{
		}

		private void btnLDelete_Click(object sender, EventArgs e)
		{

		}

		private void btnLView_Click(object sender, EventArgs e)
		{

		}

		private void btnLCreate_Click(object sender, EventArgs e)
		{
			var indices = lvFloorplan.SelectedIndices;

			if (indices != null)
			{
				if (indices.Count == 1)
				{
					var i = indices[0];

					Floorplan f = floorplanController.GetFloorplans()[i];
					new DesignerForm(f).ShowDialog();
				}
			}
			else
			{
				MessageBox.Show(
					"Please select 1 floorplan to create a layout",
					"Warning",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
					);
			}
		}
		#endregion
	}
}
