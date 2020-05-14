using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Library;
using Library.Saving;

namespace FireSimulator
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			loadLayouts();
		}

		private void loadLayouts()
		{
			try
			{
				foreach (string path in Directory.GetFiles(SaveLoadManager.GetSaveFolder()))
				{
					if (path.StartsWith(SaveLoadManager.FilePrefix))
					{
						// Check if it is a file
						if (!File.GetAttributes(path).HasFlag(FileAttributes.Directory))
						{
							new Thread(() =>
							{
								var itm = SaveLoadManager.Load(path);

								if (itm.Item is Layout)
									lvLayout.Invoke(new Action(() =>
									{
										lvLayout.Items.Add(itm.Name);
									}));
							}).Start();
						}
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
	}
}
