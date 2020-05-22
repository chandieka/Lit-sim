using System.Windows.Forms;

namespace FireSimulator
{
	public static class Prompt
	{
		public static (DialogResult DialogResult, string Value) ShowDialog(string message, string title)
		{
			Form prompt = new Form
			{
				Width = 400,
				Height = 150,
				FormBorderStyle = FormBorderStyle.FixedDialog,
				Text = title,
				StartPosition = FormStartPosition.CenterParent
			};

			Label textLabel = new Label { Left = 50, Top = 20, Width = 300, Text = message };
			TextBox textBox = new TextBox { Left = 50, Top = 50, Width = 300 };
			Button confirmation = new Button { Text = "Ok", Left = 270, Width = 100, Top = 80, DialogResult = DialogResult.OK };
			Button cancel = new Button { Text = "Cancel", Left = 15, Width = 100, Top = 80, DialogResult = DialogResult.Cancel };

			confirmation.Click += (sender, e) => { prompt.Close(); };

			prompt.Controls.Add(textBox);
			prompt.Controls.Add(confirmation);
			prompt.Controls.Add(textLabel);
			prompt.Controls.Add(cancel);

			prompt.AcceptButton = confirmation;
			prompt.CancelButton = cancel;
			prompt.ActiveControl = textBox;

			return (prompt.ShowDialog(), textBox.Text);
		}
	}
}
