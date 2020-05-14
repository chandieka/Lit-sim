using System;
using System.Windows.Forms;

namespace FireSimulator
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FireSimulatorForm());

            Application.Run(new MainForm());
            //Application.Run(new DesignerForm(100, 100));
        }
    }
}
