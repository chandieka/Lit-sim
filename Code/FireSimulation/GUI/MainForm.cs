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
			loadFloorplan();
		}

		#region Private Methods

		private void createDefaultFloorplan()
		{
			var floorplan = GridController.CreateDefaultFloorplan();
			var floorplanSaveitem = new SaveItem(floorplan, "Default");

			SaveLoadManager.Save(floorplanSaveitem);

			var layoutController = floorplan.ToGridController();
			var random = new Random();

			layoutController.RandomizeFireExtinguishers(5, random.Next());
			layoutController.RandomizePersons(2, random.Next());
			layoutController.RandomizeFire(1, random.Next());

			layoutController.SaveAsLayout("Default", floorplanSaveitem);
			floorplanController.AddToTop(floorplanSaveitem);
		}

		private void loadFloorplan()
		{
			try
			{
				SaveItem hasFoundDefault = null;

				// TODO: Sort items by creation date
				foreach (string path in Directory.GetFiles(SaveLoadManager.GetSaveFolder(typeof(Floorplan))))
				{
					// Check if it is a file
					if (!File.GetAttributes(path).HasFlag(FileAttributes.Directory))
					{
						Console.WriteLine($"Parsing {path}...");
						var itm = SaveLoadManager.Load(path);

						if (itm.Item is Floorplan)
						{
							floorplanController.Add(itm);

							if (itm.Name == "Default")
								hasFoundDefault = itm;
						}
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

				if (hasFoundDefault == null)
					createDefaultFloorplan();
				else
					floorplanController.MoveToTop(hasFoundDefault);

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

			lvFloorplan.Items[0].Selected = true;
		}

		private void showDesigner(SaveItem item = null)
		{
			DesignerForm form;

			if (item == null)
				form = new DesignerForm(100, 100); // TODO: Add popup that lets the user choose the size
			else
				form = new DesignerForm(item);

			form.ShowDialog();
			if (form.IsFloorplan && form.SaveLocation != null)
				this.floorplanController.Add(SaveLoadManager.Load(form.SaveLocation));

			updateFloorplanGUI();
		}
		#endregion
		#region Event Handler
		private void btnFPCopy_Click(object sender, EventArgs e)
		{

		}

		private void btnFPDelete_Click(object sender, EventArgs e)
		{
			// TODO: Add confirmation
			var selectedItems = lvFloorplan.SelectedIndices;
			if (selectedItems != null && selectedItems.Count > 0)
			{
				var floorplan = floorplanController.GetFloorplanAt(selectedItems[0]);

				SaveLoadManager.Delete(floorplan); // TODO: Delete all layouts too
				this.floorplanController.Remove(floorplan);
				updateFloorplanGUI();
			}
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

		private void lvFloorplan_SelectedIndexChanged(object sender, EventArgs e)
		{
			lvLayout.Items.Clear();

			if (lvFloorplan.SelectedIndices != null && lvFloorplan.SelectedIndices.Count > 0)
				foreach (SaveItem saveItem in ((Floorplan)floorplanController.GetAt(lvFloorplan.SelectedIndices[0]).Item).GetAllLayouts())
					lvLayout.Items.Add(saveItem.Item.Id.ToString(), saveItem.Name, null);
		}
		#endregion
	}
}
