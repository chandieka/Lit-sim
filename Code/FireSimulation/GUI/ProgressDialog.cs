using System;
using System.Threading;
using System.Windows.Forms;

namespace FireSimulator
{
	public partial class ProgressDialog : Form
	{
		private readonly SynchronizationContext syncContext;
		public event EventHandler Cancelled;

		public ProgressDialog()
		{
			InitializeComponent();

			this.StartPosition = FormStartPosition.CenterScreen;

			syncContext = SynchronizationContext.Current;
		}

		public ProgressDialog(string title, string message)
			: this()
		{
			this.lblMessage.Text = message;
			this.Text = title;
		}

		public void SetPercentage(int percentage)
		{
			syncContext.Post(o =>
			{
				this.pbMain.Style = ProgressBarStyle.Blocks;
				this.lblPercentage.Text = percentage + "%";
				this.pbMain.Value = percentage;
			}, null);
		}

		public void SetProgressReport(string report)
		{
			syncContext.Post(o =>
			{
				this.lblMessage.Text = report;
			}, null);
		}

		public void SetType(ProgressBarStyle type)
		{
			syncContext.Post(o =>
			{
				this.lblPercentage.Visible = false;
				this.pbMain.Style = type;
			}, null);
		}

		public new void Close()
        {
			syncContext.Post(o =>
			{
				base.Close();
			}, null);
        }

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.btnCancel.Enabled = false;
			Cancelled?.Invoke(this, new EventArgs());
		}
	}
}
