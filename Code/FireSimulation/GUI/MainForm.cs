using System;
using System.IO;
using System.Threading;
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
			loadFloorplans();
		}

		private void loadFloorplans()
		{
			try
			{
				foreach (string path in Directory.GetFiles(SaveLoadManager.GetSaveFolder()))
				{
					// Check if it is a file
					if (!File.GetAttributes(path).HasFlag(FileAttributes.Directory))
					{
						new Thread(() =>
						{
							Console.WriteLine($"Parsing {path}...");
							var itm = SaveLoadManager.Load(path);

							if (itm.Item is Floorplan)
							{
								floorplanController.AddFloorPlan((Floorplan)itm.Item);
								lvFloorplan.Invoke(new Action(() =>
								{
									lvFloorplan.Items.Add(itm.Item.Id.ToString(), itm.Name, "");
								}));
							}

						}).Start();
					}
				}
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

		#region Event Handler
		private void btnFPCopy_Click(object sender, EventArgs e)
		{

		}

		private void btnFPDelete_Click(object sender, EventArgs e)
		{
			var selected = lvFloorplan.SelectedItems[0];

			if (selected != null)
			{
				SaveLoadManager.Delete(Guid.Parse(selected.Name));
				lvFloorplan.Items.Remove(selected);
			}
		}

		private void btnFPCreate_Click(object sender, EventArgs e)
		{
			// TODO: Size
			new DesignerForm(100, 100).ShowDialog();
		}
		#endregion
	}
}
