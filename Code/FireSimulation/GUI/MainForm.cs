using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Library;

namespace FireSimulator
{
	public partial class MainForm : Form
	{
		private readonly FloorplanController floorplanController;
		private SaveItem[] itemsF;
		private SaveItem[] itemsL;
		private int pageFCount;
		private int pageFNr = 0;
		private int pageLCount;
		private int pageLNr = 0;

		public MainForm()
		{
			InitializeComponent();

			int imageSize = (int)(lvFloorplan.Width / 5);
			Size size = new Size(imageSize, imageSize);
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
			ProgressDialog dialog = new ProgressDialog("Loading", "Loading floorplans and layouts...");
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

				updateFloorplanGUI(dialog);
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

			new Thread(() =>
			{
				bw.RunWorkerAsync();
			}).Start();
			dialog.ShowDialog();
		}

		private void updateFloorplanGUI(ProgressDialog dialog = null)
		{
			dialog?.SetProgressReport("Rendering thumbnails...");
			dialog?.SetType(ProgressBarStyle.Marquee);

			SaveItem[] itemsF = floorplanController.GetAll();
			pageFCount = itemsF.Length / 9;
			if (itemsF.Length % 9 > 0)
			{
				pageFCount++;
			}
			if (pageFCount == 1)
			{
				pbFNext.Enabled = false;
			}

			LoadFPage(pageFNr);

			if (lvFloorplan.Items.Count > 0)
				lvFloorplan.Items[0].Selected = true;
			else
				lvLayout.Items.Clear();

			dialog?.Close();
		}

		private void LoadFPage(int page)
		{
			itemsF = floorplanController.GetAll();
			lvFloorplan.Items.Clear();
			fpImageList.Images.Clear();
			for (int i = page * 9; i < ((page * 9) + 9); i++)
			{
				if (i < itemsF.Length)
				{
					var item = itemsF[i];
                    // cause high ram usage idk why but why?????
					fpImageList.Images.Add(item.Item.Id.ToString(), ((Thumbnailable)item.Item).Render(fpImageList.ImageSize.Width));
					lvFloorplan.Items.Add(item.Item.Id.ToString(), item.Name, item.Item.Id.ToString());
				}
			}
			lvFloorplan_SelectedIndexChanged(null, null);
		}

		private void LoadLPage(int page)
		{
			lvLayout.Items.Clear();
			// lImageList.Images.Clear();

			for (int i = page * 9; i < ((page * 9) + 9); i++)
			{
				if (i < itemsL.Length)
				{
					SaveItem saveItem = itemsL[i];
					var key = saveItem.Item.Id.ToString();

					if (!lImageList.Images.ContainsKey(key))
					{
						new Thread(() =>
						{
							var thumbnail = ((Thumbnailable)saveItem.Item).Render(lImageList.ImageSize.Width);

							if (thumbnail != null)
								lvLayout.Invoke(new Action(() =>
								{
                                    // cause high ram usage idk why but why?????
                                    lImageList.Images.Add(saveItem.Item.Id.ToString(), thumbnail);
								}));
						}).Start();
					}

					lvLayout.Items.Add(key, saveItem.Name, key);
				}
			}
		}

		private void showDesigner(SaveItem saveItem = null, Grid grid = null)
		{
			DesignerForm form;

			if (saveItem == null && grid != null)
				form = new DesignerForm(grid, null);
			else if (saveItem != null && grid != null)
				form = new DesignerForm(grid, saveItem);
			else if (saveItem == null)
				form = new DesignerForm(100, 100); // TODO: Add popup that lets the user choose the size
			else
				form = new DesignerForm(saveItem);

			form.ShowDialog();
			if (form.IsFloorplan)
			{
				if (form.SaveLocation != null)
				{
					var item = SaveLoadManager.Load(form.SaveLocation);
					var key = item.Item.Id.ToString();

					this.floorplanController.Add(item);

					fpImageList.Images.Add(key, ((Thumbnailable)item.Item).Render(fpImageList.ImageSize.Width));
					this.lvFloorplan.Items.Add(key, item.Name, key);
				}
				else if (saveItem != null)
				{
					var key = saveItem.Item.Id.ToString();

					fpImageList.Images.RemoveByKey(key);
					fpImageList.Images.Add(key, ((Thumbnailable)saveItem.Item).Render(fpImageList.ImageSize.Width));
				}
			}
			else
			{
				if (form.SaveLocation != null)
				{
					var item = SaveLoadManager.Load(form.SaveLocation);
					var key = item.Item.Id.ToString();

					lImageList.Images.Add(key, ((Thumbnailable)item.Item).Render(lImageList.ImageSize.Width));
					lvLayout.Items.Add(key, item.Name, key);
				}
				else if (saveItem.Item is Layout)
				{
					var key = saveItem.Item.Id.ToString();

					lImageList.Images.RemoveByKey(key);
					lImageList.Images.Add(key, ((Thumbnailable)saveItem.Item).Render(lImageList.ImageSize.Width));
				}
			}
		}

		private SaveItem getSelectedFloorplan()
		{
			var selectedItems = lvFloorplan.SelectedIndices;
			if (selectedItems != null && selectedItems.Count > 0)
				return floorplanController.GetFloorplanAt(selectedItems[0] + pageFNr * 9);

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

		private void lvFloorplan_SelectedIndexChanged(object sender, EventArgs e)
		{
			lvLayout.Items.Clear();
            pageLNr = 0;

			if (lvFloorplan.SelectedIndices != null && lvFloorplan.SelectedIndices.Count > 0)
			{
				itemsL = ((Floorplan)getSelectedFloorplan().Item).GetAllLayouts(true);
				pageLCount = itemsL.Length / 9;
				if (itemsL.Length % 9 > 0)
				{
					pageLCount++;
				}
				if (pageLCount == 1)
				{
					pbLNext.Enabled = false;
				} else
                {
                    pbLNext.Enabled = true;
                }
				LoadLPage(pageLNr);
			}
		}

		private void pbFPCopy_Click(object sender, EventArgs e)
		{
			var saveItem = getSelectedFloorplan();

			if (saveItem != null)
				showDesigner(null, ((Floorplan)saveItem.Item).Clone());
		}

		private void pbFPDelete_Click(object sender, EventArgs e)
		{
			var saveItem = getSelectedFloorplan();

			if (saveItem != null && (saveItem.Item.IsDeletable || MessageBox.Show(
				"This also removes all layouts and simulation data!\nAre you sure you want to proceed?",
				"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
			{
				var floorplan = (Floorplan)saveItem.Item;

				floorplan.DeleteAllChildren();
				SaveLoadManager.Delete(floorplan);
				this.floorplanController.Remove(floorplan);

				lvFloorplan.Items.RemoveByKey(floorplan.Id.ToString());
				fpImageList.Images.RemoveByKey(floorplan.Id.ToString());
			}
		}

		private void pbFPCreate_Click(object sender, EventArgs e)
			=> showDesigner();

		private void pbLCopy_Click(object sender, EventArgs e)
		{
			var saveItem = getSelectedLayout();

			if (saveItem != null)
				showDesigner(saveItem.Value.Floorplan, ((Layout)saveItem.Value.Layout.Item).Clone());
		}

		private void pbLDelete_Click(object sender, EventArgs e)
		{
			var selected = getSelectedLayout();

			if (selected != null)
			{
				if (selected.Value.Layout.Item.IsDeletable || MessageBox.Show(
				"This also removes all simulation data!\nAre you sure you want to proceed?",
				"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					((Floorplan)selected.Value.Floorplan.Item).RemoveLayout(selected.Value.Layout.Item.Id);
					selected.Value.Layout.Item.DeleteAllChildren();

					SaveLoadManager.Delete(selected.Value.Layout.Item);
					SaveLoadManager.Save(selected.Value.Floorplan);

					lvLayout.Items.RemoveByKey(selected.Value.Layout.Item.Id.ToString());
					lImageList.Images.RemoveByKey(selected.Value.Layout.Item.Id.ToString());
				}
			}
		}

		private void pbLCreate_Click(object sender, EventArgs e)
		{
			var indices = lvFloorplan.SelectedIndices;

			if (indices != null)
			{
				if (indices.Count == 1)
					showDesigner(floorplanController.GetAt(indices[0] + pageFNr * 9));
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

		private void pbLRun_Click(object sender, EventArgs e)
		{
			var selected = getSelectedLayout();

			if (selected != null)
				new FireSimulatorForm(selected.Value.Layout).ShowDialog();
		}

		private void pbFPOpen_Click(object sender, EventArgs e)
		{
			var floorplan = getSelectedFloorplan();

			Statistics form;


			if (floorplan == null)
				MessageBox.Show("Please select a floorplan.");
			else
			{
				form = new Statistics(floorplan);
				form.ShowDialog();
			}
		}
        private void pbFNext_Click(object sender, EventArgs e)
        {
            pageFNr++;
            LoadFPage(pageFNr);
            pbFPrevious.Enabled = true;
            if (pageFNr == pageFCount - 1)
            {
                pbFNext.Enabled = false;
            }

        }

        private void pbFPrevious_Click(object sender, EventArgs e)
        {
            pageFNr--;
            LoadFPage(pageFNr);
            pbFNext.Enabled = true;
            if (pageFNr == 0)
            {
                pbFPrevious.Enabled = false;
            }
        }

        private void pbLPrevious_Click(object sender, EventArgs e)
        {
            pageLNr--;
            LoadLPage(pageLNr);
            pbLNext.Enabled = true;
            if (pageLNr == 0)
            {
                pbLPrevious.Enabled = false;
            }
        }

        private void pbLNext_Click(object sender, EventArgs e)
        {
            pageLNr++;
            LoadLPage(pageLNr);
            pbLPrevious.Enabled = true;
            if (pageLNr == pageLCount - 1)
            {
                pbLNext.Enabled = false;
            }
        }

        #endregion

    }
}
