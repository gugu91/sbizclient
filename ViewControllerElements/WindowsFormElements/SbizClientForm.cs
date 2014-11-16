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
        #region Attributes
        private string _target_id;
        private bool _connected;
        #endregion

        public SbizClientForm()
        {
            InitializeComponent();
            _connected = false;
            SbizClientRunningView.parent_key_handler += this.SbizKeyHandler;
            SbizClientController.RegisterView(this);
            SbizClientController.Start(this.SbizClientRunningView.Handle);
        }

        public void UpdateViewOnModelChanged(object sender, SbizModelChanged_EventArgs args)
        {
            BeginInvoke(new SbizUpdateView_Delegate(UpdateView), new object[] {sender,args});
        }

        public void UpdateView(object sender, SbizModelChanged_EventArgs args)
        {
            if (sender is SbizMessager)
            {
                if (args.Status == SbizModelChanged_EventArgs.CONNECTED)
                {
                    SbizClientRunningView.Enabled = true;
                    SbizClientRunningView.Focus();//otherwise won't get the input
                    string name = "Connected";
                    if (args.ExtraArg != null)
                    {
                        var announced = SbizClientController.AnnouncedServers;
                        if(announced.ContainsKey((string)args.ExtraArg))
                            name = "Connected to " + announced[(string)args.ExtraArg];
                    }
                    SbizClientConnectionStatusLabel.Text = name;
                    SbizClientConnectionStatusLabel.ForeColor = Color.Green;
                    SbizClientToggleFullscreenToolStrip.Enabled = true;
                    _connected = true;
                    //FormBorderStyle = FormBorderStyle.None;
                    //WindowState = FormWindowState.Maximized;
                }
                else if(args.Status == SbizModelChanged_EventArgs.NOT_CONNECTED)
                {
                    SbizClientRunningView.Enabled = false;
                    SbizClientConnectionStatusLabel.Text = "Not Connected";
                    SbizClientConnectionStatusLabel.ForeColor = Color.Red;
                    _connected = false;
                }
                else if (args.Status == SbizModelChanged_EventArgs.TRYING)
                {
                    SbizClientRunningView.Enabled = false;
                    SbizClientConnectionStatusLabel.Text = "Connecting...";
                    SbizClientConnectionStatusLabel.ForeColor = Color.Orange;
                }
                else if(args.Status < 0) //errors
                {
                    SbizClientRunningView.Enabled = false;
                    SbizClientConnectionStatusLabel.Text = "Not Connected";
                    SbizClientConnectionStatusLabel.ForeColor = Color.Red;
                    if (args.Status != SbizModelChanged_EventArgs.PEER_SHUTDOWN || _connected) MessageBox.Show(args.Error_message);
                    
                }
                else if (args.Status == SbizModelChanged_EventArgs.DISCOVERED_SERVER)
                {

                }
            }
        }

        private void SbizClientExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); //questo chiama implicitamente formclosing, il quale chiama cleanup
        }

        public void SbizClientToggleFullscreen_Click(object sender, EventArgs e)
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
            NativeImport.RemoveClipboardFormatListener(this.SbizClientRunningView.Handle);
        }

        private void SbizClientServersToolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {
            var announced = SbizClientController.AnnouncedServers;
            var connected = SbizClientMessageSendingModel.ConnectedServers;

            #region ConnectToNewTooolstrip
            SbizClientConnectToNewToolStripMenuItem.DropDownItems.Clear();
            int cnt = 0;
            if (announced != null || announced.Count != 0)
            {
                foreach (var element in announced)
                {
                    if (!connected.ContainsKey(element.Key))
                    {
                        var item = new ToolStripMenuItem();
                        item.Name = element.Key;
                        item.Text = element.Value;
                        item.Click += Connect;
                        SbizClientConnectToNewToolStripMenuItem.DropDownItems.Add(item);
                        cnt++;
                    }
                }
            }
            if (cnt == 0) SbizClientConnectToNewToolStripMenuItem.DropDownItems.Add(this.noOtherServerOnThisNetworkToolStripMenuItem);
            #endregion

            #region ServersToolstrip
            int index = SbizClientServersToolStripMenuItem.DropDownItems.IndexOf(toolStripSeparator2);
            for (int i = SbizClientServersToolStripMenuItem.DropDownItems.Count-1; i  > index ; i--) //NB devi rimuovere a partire dal fondo in ste collezioni
                SbizClientServersToolStripMenuItem.DropDownItems.RemoveAt(i);
            cnt = 0;
            if (connected != null || connected.Count != 0)
            {
                foreach (var element in connected)
                {
                    if (announced.ContainsKey(element.Key))
                    {
                        var item = new ToolStripMenuItem();
                        item.Name = element.Key;
                        item.Text = announced[item.Name];
                        if (element.Value)
                        {
                            item.Checked = true;
                            _target_id = element.Key;
                        }
                        item.Click += ActiveChange;
                        index++;
                        SbizClientServersToolStripMenuItem.DropDownItems.Insert(index, item);
                        cnt++;
                    }
                }
            }
            if(cnt == 0) {
                noActiveConnectionToolStripMenuItem.Text = "No active connection";
                noActiveConnectionToolStripMenuItem.Enabled = false;
            }
            else
            {
                noActiveConnectionToolStripMenuItem.Text = "Disconnect from target";
                noActiveConnectionToolStripMenuItem.Enabled = true;
                SbizClientServersToolStripMenuItem.DropDownItems.Add(toolStripSeparator3);
            }
            
            SbizClientServersToolStripMenuItem.DropDownItems.Add(noActiveConnectionToolStripMenuItem);
            #endregion
        }

        private void ActiveChange(object sender, EventArgs e)
        {
            SbizClientRunningView.Enabled = false;
            ToolStripMenuItem t = (ToolStripMenuItem)sender;
            SbizClientController.MakeActive(t.Name);
        }

        private void Connect(object sender, EventArgs e)
        {
            _connected = false;
            SbizClientRunningView.Enabled = false;
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            SbizClientPasswordBox.Enabled = true;
            SbizClientPasswordBox.Visible = true;
            SbizClientPasswordBox.SetConnectParam(item.Name, item.Text, SbizClientRunningView);
        }

        //This is actually used to disconnect from target
        private void noActiveConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SbizClientController.Disconnect();
        }

        private void SbizClientForm_Deactivate(object sender, EventArgs e)
        {
            SbizClientKeyHandler.ResetServerKeyboard();
            NativeImport.UnhookSpecialKeys();
        }

        private void SbizClientForm_Activated(object sender, EventArgs e)
        {
            NativeImport.HookSpecialKeys(SbizClientKeyHandler.SpecialKeysHandler);
        }

        private void SbizKeyHandler(int n, object sender, EventArgs e)
        {
            if (n > 0)//Special keys
            {
                if (n == SbizKey.FULLSCREEN) SbizClientToggleFullscreen_Click(sender, e);
                if (n == SbizKey.NEXT_SERVER) SelectNextServer();
            }
        }

        private void SelectNextServer()
        {
            int first = SbizClientServersToolStripMenuItem.DropDownItems.IndexOf(toolStripSeparator2) +1;
            int last = SbizClientServersToolStripMenuItem.DropDownItems.IndexOf(toolStripSeparator3) -1;

            if(last == first) //just one server
            {
                SbizClientRunningView.SbizClientRunningTextLabel.Text = "No other server connected";
                SbizClientKeyHandler.NewWord();
                return;
            }

            int current = -1;

            for (int i = first; i <= last;  i++)
            {
                if (((ToolStripMenuItem)SbizClientServersToolStripMenuItem.DropDownItems[i]).Checked)
                {
                    current = i;
                    ((ToolStripMenuItem)SbizClientServersToolStripMenuItem.DropDownItems[i]).Checked = false;
                }
            }

            current++;
            if(current < first || current > last) current = first;
            var target = SbizClientServersToolStripMenuItem.DropDownItems[current];
            ActiveChange(target, new EventArgs());
            ((ToolStripMenuItem)SbizClientServersToolStripMenuItem.DropDownItems[current]).Checked = true;
            SbizClientRunningView.SbizClientRunningTextLabel.Text = "Targeting " + target.Text;
            SbizClientKeyHandler.NewWord();
        }
    }
 
}
