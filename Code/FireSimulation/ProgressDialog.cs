using System;
using System.Windows.Forms;

namespace FireSimulator
{
	public partial class ProgressDialog : Form
	{
		public ProgressDialog()
		{
			InitializeComponent();
		}

		public void SetPercentage(int percentage)
		{
			this.pbMain.Style = ProgressBarStyle.Blocks;
			this.lblPercentage.Text = percentage + "%";
			this.pbMain.Value = percentage;
		}
	}
}
