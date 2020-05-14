using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Library;
using static System.Windows.Forms.ListView;

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
            CreateDefaultFloorplan();
            loadFloorplan();
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
                        {
                            floorplanController.AddFloorPlan((Floorplan)itm.Item);
                        }
                    }
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
            foreach (Floorplan f in floorplanController.GetFloorPlans())
            {
                lvFloorplan.Items.Add(f.ToString());
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
            SelectedIndexCollection indices = lvFloorplan.SelectedIndices;

            if (indices != null)
            {
                if (indices.Count == 1)
                {
                    var i = indices[0];
                    Floorplan f = floorplanController.GetFloorPlans()[i];
                    new DesignerForm(f);
                }
                else
                {
                    MessageBox.Show(
                    "Select 1 floorplan at a time!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
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

        private void btnFPEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnFPCreate_Click(object sender, EventArgs e)
        {
            new DesignerForm(floorplanController).ShowDialog();
        }
        #endregion
    }
}
