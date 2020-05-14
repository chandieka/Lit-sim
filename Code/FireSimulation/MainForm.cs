using System;
using System.IO;
using System.Windows.Forms;

namespace FireSimulator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            loadLayouts();
        }

        public static string GetSaveFolder(bool shouldCheck = true)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Lit");

            if (shouldCheck)
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }

            return path;
        }

        private void loadLayouts()
        {
            // TODO
        }
    }
}
