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
        public SbizClientRunningUC()
        {
            InitializeComponent();
            this.MouseWheel += SbizClientRunningUC_MouseWheel;
            //SbizClientController.RegisterView(this);
            Focus();
        }

        #region Overrides
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (SbizClientKeyHandler.ProcessCmdKey(ref msg, keyData))
            {
                if (msg.Msg == NativeImport.WM_KEYDOWN || msg.Msg == NativeImport.WM_SYSKEYDOWN)
                {
                    this.OnKeyDown(new KeyEventArgs(keyData));
                }
                //Apparently key up never passes here no idea why
                //if (msg.Msg == WM_KEYUP || msg.Msg == WM_SYSKEYUP){}
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            SbizClientController.WndProcOverride(m);
        }
        #endregion

        #region Update View
        public void UpdateViewOnModelChanged(object sender, SbizModelChanged_EventArgs args)
        {
            BeginInvoke(new SbizUpdateView_Delegate(UpdateView), new object[] { sender, args });
        }
        public void UpdateView(object sender, SbizModelChanged_EventArgs args)
        {
        }
        #endregion

        #region MouseEvents
        #region Mouse Move
        private void SbizClientRunningUC_MouseMove(object sender, MouseEventArgs e)
        {
            SbizClientMouseHandler.MouseMove(this, ((Control)sender), e);
        }

        private void SbizClientRunningTextLabel_MouseMove(object sender, MouseEventArgs e)
        {
            SbizClientMouseHandler.MouseMove(this, ((Control)sender), e);
        }

        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            SbizClientMouseHandler.MouseMove(this, ((Control)sender), e);
        }
        #endregion

        #region Mouse Up
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
        #endregion

        private void SbizClientRunningUC_MouseWheel(object sender, MouseEventArgs e)
        {
            SbizClientMouseHandler.MouseWheel(this, (Control)sender, e);
        }

        #region Mouse Down
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

        #endregion

        #region Mouse Hover
        private void SbizClientRunningTextLabel_MouseHover(object sender, EventArgs e)
        {
            this.Focus();
        }
        private void MainPanel_MouseHover(object sender, EventArgs e)
        {
            this.Focus();
        }
        #endregion
        private void SbizClientRunningTextLabel_MouseLeave(object sender, EventArgs e)
        {

        }
        #endregion

        #region Keyboard Events
        private void SbizClientRunningUC_KeyDown(object sender, KeyEventArgs e)
        {
            SbizClientKeyHandler.KeyDown(e);
        }
        private void SbizClientRunningUC_KeyUp(object sender, KeyEventArgs e)
        {
            SbizClientKeyHandler.KeyUp(e);
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
        private void SbizClientRunningUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            SbizClientKeyHandler.KeyPress(e);
        }
        #endregion

        private void SbizClientRunningUC_EnabledChanged(object sender, EventArgs e)
        {
            if (((SbizClientRunningUC)sender).Enabled)
            {
                SbizClientKeyHandler.RegisterLabel(SbizClientRunningTextLabel);
            }
            else
            {
                SbizClientKeyHandler.UnregisterLabel();
            }
        }

        //Following are not implemented

        #region HorizontalScrolling
        //protected override void WndProc(ref Message m)
        //{
        //    base.WndProc(ref m);
        //    if (m.HWnd != this.Handle)
        //    {
        //        return;
        //    }
        //    SbizClientRunningTextLabel.Text = m.Msg.ToString("X") +" " + m.GetHashCode();
        //}
        #endregion


    }
}
