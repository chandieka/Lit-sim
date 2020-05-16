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
				foreach (string path in Directory.GetFiles(SaveLoadManager.GetSaveFolder(typeof(Floorplan))))
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

				updateFloorplanGUI();
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

		private void updateFloorplanGUI()
		{
			lvFloorplan.Items.Clear();
			foreach (var item in floorplanController.GetAll())
				lvFloorplan.Items.Add(item.Item.Id.ToString(), item.Name, null);
		}

		private void showDesigner(SaveItem item = null)
		{
			DesignerForm form;

			if (item == null)
				form = new DesignerForm(100, 100); // TODO: Add popup that lets the user choose the size
			else
				form = new DesignerForm(item);

			form.ShowDialog();
			// if (form.DialogResult != DialogResult.Cancel)
			updateFloorplanGUI();
		}
		#endregion
		#region Event Handler
		private void btnFPCopy_Click(object sender, EventArgs e)
		{

		}

		private void btnFPDelete_Click(object sender, EventArgs e)
		{
			//return;

			// TODO: Add confirmation
			//var selected = lvFloorplan.SelectedIndices;
			//if (selected != null && selected.Count > 0)
			//{
			//	SaveLoadManager.Delete(floorplanController.GetFloorplanAt(selected[0])); // TODO: Delete all layouts too
			//	lvFloorplan.Items.Remove(lvFloorplan.SelectedItems[0]);
			//	updateFloorplanGUI();
			//}
		}

		private void btnFPEdit_Click(object sender, EventArgs e)
		{

		}

		private void btnFPCreate_Click(object sender, EventArgs e)
			=> showDesigner();


		private void btnLEdit_Click(object sender, EventArgs e)
		{
		}

		private void btnLDelete_Click(object sender, EventArgs e)
		{

		}

		private void btnLRunSimulation_Click(object sender, EventArgs e)
		{
            // Testing
            GridController gc = new GridController(new Block[100, 100]);
            gc.PutDefaultFloorPlan(1);
            gc.RandomizeFire(1);
            gc.RandomizePersons(10);
            gc.RandomizeFireExtinguishers(10);
            Layout testLayout = new Layout(gc.GetGridCopy());
            new FireSimulatorForm(testLayout).ShowDialog();
		}

		private void btnLCreate_Click(object sender, EventArgs e)
		{
			var indices = lvFloorplan.SelectedIndices;

			if (indices != null)
			{
				if (indices.Count == 1)
					showDesigner(floorplanController.GetAt(indices[0]));
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
