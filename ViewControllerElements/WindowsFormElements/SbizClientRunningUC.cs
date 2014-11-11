using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sbiz.Library;

namespace Sbiz.Client
{
    public partial class SbizClientRunningUC : UserControl, SbizControl
    {
        private SbizClientKeyHandler key_handler;
        private const int WM_KEYDOWN = 0X100;
        private const int WM_KEYUP = 0X101;
        private const int WM_SYSKEYDOWN = 0X104;
        private const int WM_SYSKEYUP = 0X105;

        public SbizClientRunningUC()
        {
            InitializeComponent();
            this.MouseWheel += SbizClientRunningUC_MouseWheel;
            //SbizClientController.RegisterView(this);
            key_handler = new SbizClientKeyHandler();
            Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (key_handler.ProcessCmdKey(ref msg, keyData))
            {
                if(msg.Msg == WM_KEYDOWN)
                {
                    this.OnKeyDown(new KeyEventArgs(keyData));
                }
                else if(msg.Msg == WM_KEYUP)
                {
                    this.OnKeyUp(new KeyEventArgs(keyData));
                }
                else if(msg.Msg == WM_SYSKEYDOWN)
                {
                    this.OnKeyDown(new KeyEventArgs(keyData));
                }
                else if(msg.Msg == WM_SYSKEYUP)
                {
                    this.OnKeyUp(new KeyEventArgs(keyData));
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SbizClientRunningUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_handler.KeyPress(SbizClientRunningTextLabel, e);
        }

        public void UpdateViewOnModelChanged(object sender, SbizModelChanged_EventArgs args)
        {
            BeginInvoke(new SbizUpdateView_Delegate(UpdateView), new object[] { sender, args });
        }
        public void UpdateView(object sender, SbizModelChanged_EventArgs args)
        {
        }

        #region MouseEvents
        private void SbizClientRunningUC_MouseMove(object sender, MouseEventArgs e)
        {
            SbizClientMouseHandler.MouseMove(this, ((Control)sender), e);
        }

        private void SbizClientRunningTextLabel_MouseMove(object sender, MouseEventArgs e)
        {
            /*System.Drawing.Point np = this.PointToClient(((Control)sender).PointToScreen(e.Location));
            MouseEventArgs ne = new MouseEventArgs(e.Button, e.Clicks, np.X, np.Y, e.Delta);
            this.OnMouseMove(ne);*/
            SbizClientMouseHandler.MouseMove(this, ((Control)sender), e);
        }

        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            SbizClientMouseHandler.MouseMove(this, ((Control)sender), e);
        }

        private void SbizClientRunningTextLabel_MouseUp(object sender, MouseEventArgs e)
        {
            SbizClientMouseHandler.MouseUp(this, (Control)sender, e);
        }

        private void MainPanel_MouseUp(object sender, MouseEventArgs e)
        {
            SbizClientMouseHandler.MouseUp(this, (Control)sender, e);
        }

        private void SbizClientRunningUC_MouseUp(object sender, MouseEventArgs e)
        {
            SbizClientMouseHandler.MouseUp(this, (Control)sender, e);
        }

        private void SbizClientRunningUC_MouseWheel(object sender, MouseEventArgs e)
        {
            SbizClientMouseHandler.MouseWheel(this, (Control)sender, e);
        }

        private void SbizClientRunningTextLabel_MouseDown(object sender, MouseEventArgs e)
        {
            SbizClientMouseHandler.MouseDown(this, (Control)sender, e);
        }

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            SbizClientMouseHandler.MouseDown(this, (Control)sender, e);
        }

        private void SbizClientRunningUC_MouseDown(object sender, MouseEventArgs e)
        {
            SbizClientMouseHandler.MouseDown(this, (Control)sender, e);
        }

        private void SbizClientRunningTextLabel_MouseHover(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void MainPanel_MouseHover(object sender, EventArgs e)
        {
            this.Focus();
        }
        #endregion
        private void SbizClientRunningUC_KeyDown(object sender, KeyEventArgs e)
        {
            key_handler.KeyDown(SbizClientRunningTextLabel, e);
        }

        private void SbizClientRunningUC_KeyUp(object sender, KeyEventArgs e)
        {
            key_handler.KeyUp(SbizClientRunningTextLabel, e);
        }

        private void SbizClientRunningUC_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    this.SbizClientRunningTextLabel.Text = "\u2193"; //Unicode for ↓
                    e.IsInputKey = true;
                    break;
                case Keys.Up:
                    this.SbizClientRunningTextLabel.Text = "\u2191"; //Unicode for ↑
                    e.IsInputKey = true;
                    break;
                case Keys.Left:
                    this.SbizClientRunningTextLabel.Text = "\u2190"; //Unicode for ←
                    e.IsInputKey = true;
                    break;
                case Keys.Right:
                    this.SbizClientRunningTextLabel.Text = "\u2192"; //Unicode for →
                    e.IsInputKey = true;
                    break;
            }
        }
        /*
        #region HorizontalScrolling
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.HWnd != this.Handle)
            {
                return;
            }
            SbizClientRunningTextLabel.Text = m.Msg.ToString("X") +" " + m.GetHashCode();
        }
        #endregion
         * */
    }
}
