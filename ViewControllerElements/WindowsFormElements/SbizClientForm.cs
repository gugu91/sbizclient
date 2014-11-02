using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Sbiz.Library;

namespace Sbiz.Client
{
    public partial class SbizClientForm : Form, SbizControl
    {
        public SbizClientForm()
        {
            InitializeComponent();
            SbizClientController.RegisterView(this);
        }

        public void UpdateViewOnModelChanged(object sender, SbizModelChanged_EventArgs args)
        {
            BeginInvoke(new SbizUpdateView_Delegate(UpdateView), new object[] {sender,args});
        }

        public void UpdateView(object sender, SbizModelChanged_EventArgs args)
        {
            if (sender is SbizClientSender)
            {
                if (args.Status == SbizModelChanged_EventArgs.CONNECTED)
                {
                    SbizClientConnectView.Visible = false;
                    SbizClientConnectView.Enabled = false;
                    SbizClientRunningView.Enabled = true;
                    SbizClientRunningView.Visible = true;
                    SbizClientRunningView.Focus();//otherwise won't get the input
                    SbizClientConnectionStatusLabel.Text = "Connected";
                    SbizClientConnectionStatusLabel.ForeColor = Color.Green;
                    SbizClientToggleFullscreenToolStrip.Enabled = true;
                    FormBorderStyle = FormBorderStyle.None;
                    //WindowState = FormWindowState.Maximized;
                }
                else if(args.Status == SbizModelChanged_EventArgs.NOT_CONNECTED)
                {
                    SbizClientRunningView.Visible = false;
                    SbizClientRunningView.Enabled = false;
                    SbizClientConnectView.Enabled = true;
                    SbizClientConnectView.Visible = true;
                    SbizClientConnectView.Focus();
                    SbizClientConnectionStatusLabel.Text = "Not Connected";
                    SbizClientConnectionStatusLabel.ForeColor = Color.Red;
                }
                else if (args.Status == SbizModelChanged_EventArgs.TRYING)
                {
                    SbizClientRunningView.Visible = false;
                    SbizClientRunningView.Enabled = false;
                    SbizClientConnectView.Enabled = true;
                    SbizClientConnectView.Visible = true;
                    SbizClientConnectView.Focus();
                    SbizClientConnectionStatusLabel.Text = "Connecting...";
                    SbizClientConnectionStatusLabel.ForeColor = Color.Orange;
                }
                else if(args.Status == SbizModelChanged_EventArgs.ERROR)
                {
                    SbizClientRunningView.Visible = false;
                    SbizClientRunningView.Enabled = false;
                    SbizClientConnectView.Enabled = true;
                    SbizClientConnectView.Visible = true;
                    SbizClientConnectView.Focus();
                    SbizClientConnectionStatusLabel.Text = "Not Connected";
                    SbizClientConnectionStatusLabel.ForeColor = Color.Red;
                    MessageBox.Show(args.Error_message);
                }
            }
        }

        private void SbizClientExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); //questo chiama implicitamente formclosing, il quale chiama cleanup
        }

        private void SbizClientToggleFullscreen_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                FormBorderStyle = FormBorderStyle.Fixed3D;
                WindowState = FormWindowState.Normal;
            }
        }

        private void SbizClientFormClosing(object sender, FormClosingEventArgs e)
        {
            this.SbizClientCleanup();
        }
        
        private void SbizClientCleanup()
        {
            SbizClientController.Stop();
        }
      

      
}
 
}
