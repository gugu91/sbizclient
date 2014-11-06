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
            SbizClientModel.Start(15001);
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

        private void SbizClientServersToolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {
            List<string> name_list = SbizClientController.GetConnectedServersName();
            if (name_list == null)
            {
                SbizClientServersToolStripMenuItem.DropDownItems.Clear();
                this.SbizClientServersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                     this.SbizClientConnectToNewToolStripMenuItem,
                     this.toolStripSeparator2,
                     this.noActiveConnectionToolStripMenuItem});
                noActiveConnectionToolStripMenuItem.Visible = true;
            }
            else
            {
                SbizClientServersToolStripMenuItem.DropDownItems.Clear();
                this.SbizClientServersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                     this.SbizClientConnectToNewToolStripMenuItem,
                     this.toolStripSeparator2});
                foreach (var name in name_list)
                {
                    var item = new ToolStripMenuItem();
                    item.Text = name;
                    item.Click += ActiveChange;
                    //Add method to change item;
                    SbizClientServersToolStripMenuItem.DropDownItems.Add(item);
                }

            }

            name_list = SbizClientController.GetOtherServersName();
            if (name_list == null)
            {
                SbizClientConnectToNewToolStripMenuItem.DropDownItems.Clear();
            }
            else
            {
                SbizClientConnectToNewToolStripMenuItem.DropDownItems.Clear();
                foreach (var name in name_list)
                {
                    var item = new ToolStripMenuItem();
                    item.Text = name;
                    item.Click += ActiveChange;
                    //Add method to change item;
                    SbizClientConnectToNewToolStripMenuItem.DropDownItems.Add(item);
                }

            }

        }

        private void ActiveChange(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            SbizClientController.Connect(item.Text);
        }
            

      
}
 
}
