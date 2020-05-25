using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireSimulator.GUI
{
    public partial class SessionSettingsForm : Form
    {
        private readonly FireSimulatorForm fireSimulatorForm;

        public SessionSettingsForm(FireSimulatorForm fireSimulatorForm)
        {
            InitializeComponent();

            this.fireSimulatorForm = fireSimulatorForm;

            this.DisplayPreviousSettings();

            this.btCancel.Click += new EventHandler((s, e) => this.Close());
            this.btSave.Click += new EventHandler((s, e) => this.SaveEnteredSettings());
        }

        private void DisplayPreviousSettings()
        {
            // var timeLimit = this.fireSimulatorForm.GetTimeLimit();

            //this.tbTimeLimitHours.Text = timeLimit.Hours.ToString();
            //this.tbTimeLimitMinutes.Text = timeLimit.Minutes.ToString();
            //this.tbTimeLimitSeconds.Text = timeLimit.Seconds.ToString();
        }

        private bool ValidateEnteredSettings()
        {
            bool ValidateNumber(Control control)
            {
                var result = int.TryParse(control.Text, out int _);

                if (result == false) control.BackColor = Color.DarkRed;
                else control.BackColor = DefaultBackColor;

                return result;
            }

            var results = new[]
            {
                ValidateNumber(this.tbTimeLimitHours),
                ValidateNumber(this.tbTimeLimitMinutes),
                ValidateNumber(this.tbTimeLimitSeconds),
            };

            return results.All(_ => _);
        }

        private void SaveEnteredSettings()
        {
            if (!this.ValidateEnteredSettings())
            {
                MessageBox.Show("Some settings are invalid");
                return;
            }

            // this.fireSimulatorForm.SetTimeLimit(Convert.ToInt32(this.tbTimeLimitHours.Text), Convert.ToInt32(this.tbTimeLimitMinutes.Text), Convert.ToInt32(this.tbTimeLimitSeconds.Text));
            MessageBox.Show("Settings saved");
            this.Close();
        }
    }
}