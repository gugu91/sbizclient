using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sbiz.Client.ViewControllerElements.WindowsFormElements
{
    public partial class SbizClientDisconnectedUC : UserControl
    {
        public SbizClientDisconnectedUC()
        {
            InitializeComponent();
        }

        public void Alert(string message)
        {
            label1.Text = message;
            this.Enabled = true;
            this.Visible = true;
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.Visible = false;
        }
    }
}
