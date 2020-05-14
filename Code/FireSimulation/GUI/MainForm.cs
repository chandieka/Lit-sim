using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Library;

namespace FireSimulator
{
	public partial class MainForm : Form
	{
        // Floorplan = > wall + floor
        // Layout => Floorplan + all the people, fire, and fire extinguisher 

        private FloorplanController floorplanController;

		public MainForm()
		{
			InitializeComponent();
            floorplanController = new FloorplanController();
            CreateDefaultFloorplan()
            loadLayouts();
		}

        #region Private Methods

        private void CreateDefaultFloorplan()
        {
            // TODO: Check if a default floorplan is already save
            if (floorplanController != null)
            {
                GridController gc = new GridController((100, 100));
                gc.PutDefaultFloorPlan(1);
                floorplanController.AddFloorPlan(new Floorplan(gc.DeepCloneBlock()));
            }
        }

        // TODO change name
        private void loadLayouts()
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
								lvFloorplan.Invoke(new Action(() =>
								{
									lvFloorplan.Items.Add(itm.Name);
								}));
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
        #endregion

        #region Event Handler
        private void btnFPCopy_Click(object sender, EventArgs e)
        {

        }
        private void btnFPDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnFPCreate_Click(object sender, EventArgs e)
        {

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

        }
        #endregion
    }
}
