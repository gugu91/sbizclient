using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sbiz.Client
{
    public partial class SbizClientPasswordUC : UserControl
    {
        string _identifier;
        Control _view;


        public SbizClientPasswordUC()
        {
            InitializeComponent();
        }

        public void SetConnectParam(string identifier, string name, Control view)
        {
            _identifier = identifier;
            label1.Text = "Please enter password for " + name;
            _view = view;
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            SbizClientController.Connect(_identifier, _view.Handle, textBox1.Text);
            CancelButton_Click(sender, e);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            this.Enabled = false;
            this.Visible = false;
        }

        private void SbizClientPasswordUC_EnabledChanged(object sender, EventArgs e)
        {
            if (Enabled) textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            EnterButton.Enabled = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) EnterButton_Click(sender, e);
        }

        private void SbizClientPasswordUC_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible) textBox1.Focus();
        }
    }
}
