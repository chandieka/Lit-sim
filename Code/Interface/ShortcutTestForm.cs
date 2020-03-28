﻿using System.Windows.Forms;

namespace Interface
{
	public partial class ShortcutTestForm : Form
	{
		private static System.Drawing.Color[] colors = new System.Drawing.Color[] { System.Drawing.Color.Red, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orange, System.Drawing.Color.Yellow, System.Drawing.Color.GreenYellow, System.Drawing.Color.Green, System.Drawing.Color.LightBlue, System.Drawing.Color.Blue, System.Drawing.Color.MediumPurple, System.Drawing.Color.Purple };
		private int colorIndex = 0;

		public ShortcutTestForm()
		{
			InitializeComponent();
		}

		private void CTRL_O()
		{
			using (OpenFileDialog dialog = new OpenFileDialog())
			{
				dialog.Filter = "All|*";
				dialog.Title = "Just do something";

				if (dialog.ShowDialog() == DialogResult.Cancel)
					MessageBox.Show("You cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else
					MessageBox.Show("You selected " + dialog.FileName, "Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void CTRL_ALT_T()
		{
			if (colorIndex >= colors.Length)
				colorIndex = 0;

			this.BackColor = colors[colorIndex++];
		}

		private void ShortcutTestForm_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Control)
			{
				if (e.Alt && e.KeyCode == Keys.T)
					this.CTRL_ALT_T();
				else if (e.KeyCode == Keys.O)
					this.CTRL_O();
			}
		}
	}
}