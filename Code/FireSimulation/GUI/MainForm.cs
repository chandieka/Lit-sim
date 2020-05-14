using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Library;

namespace FireSimulator
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

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

		private void BtnFPCreate_Click(object sender, EventArgs e)
		{
			// TODO: Size
			new DesignerForm(100, 100).ShowDialog();
		}
	}
}
