using System;
using System.Threading;
using System.Windows.Forms;

namespace FireSimulator
{
	public partial class ProgressDialog : Form
	{
		private readonly SynchronizationContext syncContext;
		public event EventHandler Cancelled;

		public ProgressDialog(string message = null)
		{
			InitializeComponent();

			syncContext = SynchronizationContext.Current;

			if (message != null)
				this.lblMessage.Text = message;
		}

		public void SetPercentage(int percentage)
		{
			this.pbMain.Style = ProgressBarStyle.Blocks;
			this.lblPercentage.Text = percentage + "%";
			this.pbMain.Value = percentage;
		}

		public void SetProgressReport(string report)
		{
			syncContext.Post(o =>
			{
				this.lblMessage.Text = report;
			}, null);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.btnCancel.Enabled = false;
			Cancelled?.Invoke(this, new EventArgs());
		}
	}
}
