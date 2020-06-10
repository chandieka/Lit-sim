using Library;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FireSimulator.GUI
{
	public partial class ScenarioDialog : Form
	{
		public ScenarioDialog(KeyValuePair<EScenario, int>[] data, string name = null)
		{
			InitializeComponent();

			if (name != null)
				this.Text = $"Lit - '{name}' scenarios";

			int total = 0;
			foreach (var d in data)
			{
				total += d.Value;
				dgvMain.Rows.Add(new string[] {
					d.Key.ToString(),
					FinishedEventArgs.ScenarioMessageList[d.Key],
					d.Value.ToString()
				});
			}

			lblTotal.Text = "Total: " + total.ToString();
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
