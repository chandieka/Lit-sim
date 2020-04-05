using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireSimulator
{
    public partial class AutoSaveLoadDialog : Form
    {
        public AutoSaveLoadDialog(bool save)
        {
            InitializeComponent();

            lblMessage.Text = save ? "You have unsaved settings. Do you wish to save them?" : "Do you wish to open your last saved file?";
        }
    }
}
