using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Library;

namespace FireSimulator
{
	public partial class MainForm : Form
	{
		private readonly FloorplanController floorplanController;

		public MainForm()
		{
			InitializeComponent();

			int imageSize = (int)(lvFloorplan.Width / 2.5);
			System.Drawing.Size size = new System.Drawing.Size(imageSize, imageSize);
			lImageList.ImageSize = size;
			fpImageList.ImageSize = size;

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
			ProgressDialog dialog = new ProgressDialog("Loading...", "Loading floorplans and layouts");
			BackgroundWorker bw = new BackgroundWorker();
			SaveItem hasFoundDefault = null;

			bw.WorkerReportsProgress = true;
			bw.WorkerSupportsCancellation = true;
			bw.ProgressChanged += (sender, e)
				=> dialog.SetPercentage(e.ProgressPercentage);
			bw.RunWorkerCompleted += (sender, e) =>
			{
				if (hasFoundDefault == null)
					createDefaultFloorplan();
				else
					floorplanController.MoveToTop(hasFoundDefault);

				updateFloorplanGUI();
				dialog.Close();
			};
			bw.DoWork += (object sender, DoWorkEventArgs e) =>
			{
				var worker = (BackgroundWorker)sender;

				try
				{
					var fileInfo = new DirectoryInfo(SaveLoadManager.GetSaveFolder(typeof(Floorplan)));
					var files = fileInfo.GetFiles().OrderBy(_ => _.CreationTime).Reverse().ToArray();

					for (int i = 0; i < files.Length; i++)
					{
						if (worker.CancellationPending)
							break;

						var path = files[i].FullName;

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

						worker.ReportProgress(i / files.Length * 100);
					}
				}
				catch (Exception exc)
				{
					Console.WriteLine(exc.Message);
					MessageBox.Show(
						"There was an error with finding all the saved layouts",
						"Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error
					);
					Application.Exit();
				}

				worker.ReportProgress(100);
				e.Result = true;
			};

			dialog.Cancelled += (object s, EventArgs a) => bw.CancelAsync();

			bw.RunWorkerAsync();
			dialog.ShowDialog();
		}

		private void updateFloorplanGUI()
		{
			lvFloorplan.Items.Clear();
			fpImageList.Images.Clear();

			foreach (var item in floorplanController.GetAll())
			{
				fpImageList.Images.Add(((Thumbnailable)item.Item).Render(fpImageList.ImageSize.Width));
				lvFloorplan.Items.Add(item.Item.Id.ToString(), item.Name, fpImageList.Images.Count - 1);
			}

			if (lvFloorplan.Items.Count > 0)
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

		private SaveItem getSelectedFloorplan()
		{
			var selectedItems = lvFloorplan.SelectedIndices;
			if (selectedItems != null && selectedItems.Count > 0)
				return floorplanController.GetFloorplanAt(selectedItems[0]);

			return null;
		}

		private (SaveItem Layout, SaveItem Floorplan)? getSelectedLayout()
		{
			var selected = lvLayout.SelectedIndices;

			if (selected != null && selected.Count > 0)
			{
				var floorplan = getSelectedFloorplan();

				if (floorplan != null)
					return (((Floorplan)floorplan.Item).GetLayoutAt(selected[0]), floorplan);
			}

			return null;
		}
		#endregion
		#region Event Handler
		private void btnFPCopy_Click(object sender, EventArgs e)
		{

		}

		private void btnFPDelete_Click(object sender, EventArgs e)
		{
			var saveItem = getSelectedFloorplan();

			if (saveItem != null)
			{
				var floorplan = (Floorplan)saveItem.Item;

				if (floorplan.LayoutAmount <= 0 || MessageBox.Show(
				"This also removes all layouts and simulation data!\nAre you sure you want to proceed?",
				"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					floorplan.DeleteAllChildren();
					SaveLoadManager.Delete(floorplan);
					this.floorplanController.Remove(floorplan);
					updateFloorplanGUI();
				}
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
			var selected = getSelectedLayout();

			if (selected != null)
			{
				((Floorplan)selected.Value.Floorplan.Item).RemoveLayout(selected.Value.Layout.Item.Id);
				SaveLoadManager.Delete(selected.Value.Layout.Item);
				SaveLoadManager.Save(selected.Value.Floorplan);
				updateFloorplanGUI();
			}
		}

		private void btnLRunSimulation_Click(object sender, EventArgs e)
		{
			var selected = getSelectedLayout();

			if (selected != null)
				new FireSimulatorForm(selected.Value.Layout).ShowDialog();
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
			lImageList.Images.Clear();
			lvLayout.Items.Clear();

			if (lvFloorplan.SelectedIndices != null && lvFloorplan.SelectedIndices.Count > 0)
				foreach (SaveItem saveItem in ((Floorplan)getSelectedFloorplan().Item).GetAllLayouts(true))
				{
					lImageList.Images.Add(((Thumbnailable)saveItem.Item).Render(lImageList.ImageSize.Width));
					lvLayout.Items.Add(saveItem.Item.Id.ToString(), saveItem.Name, lImageList.Images.Count - 1);
				}
		}
		#endregion
	}
}
