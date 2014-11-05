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
        public SbizClientRunningUC()
        {
            InitializeComponent();
            this.MainPanel.MouseWheel += MainPanel_MouseWheel;
            //SbizClientController.RegisterView(this);
            key_handler = new SbizClientKeyHandler();
            MainPanel.Focus();
        }

        private void SbizClientRunningUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_handler.KeyPress(SbizClientRunningTextLabel, e);
        }

        private void SbizClientRunningUC_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            key_handler.PreviewKeyDown(SbizClientRunningTextLabel, e);
        }

        private void SbizClientRunningUC_KeyDown(object sender, KeyEventArgs e)
        {
            key_handler.KeyDown(SbizClientRunningTextLabel, e);
        }

        public void UpdateViewOnModelChanged(object sender, SbizModelChanged_EventArgs args)
        {
            BeginInvoke(new SbizUpdateView_Delegate(UpdateView), new object[] { sender, args });
        }
        public void UpdateView(object sender, SbizModelChanged_EventArgs args)
        {
        }

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

        private void MainPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            SbizClientRunningTextLabel.Text = "Rotellina";
        }

        private void SbizClientRunningTextLabel_MouseHover(object sender, EventArgs e)
        {
            this.MainPanel.Focus();
        }
    }
}
