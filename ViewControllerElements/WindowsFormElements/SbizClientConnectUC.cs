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
    public partial class SbizClientConnectUC : UserControl, SbizControl
    {
        public SbizClientConnectUC()
        {
            InitializeComponent();
            SbizClientController.RegisterView(this);
            this.SbizClientPort.Controls[0].Visible = false;
        }

        private void SbizClientConnectButton_Click(object sender, EventArgs e)
        {
            int port_int;
            decimal port = SbizClientPort.Value;
            string ipAddr = SbizClientIpAddress.Text;

            try
            {
                port_int = Convert.ToInt32(port);
            }
            catch (Exception data_format)
            {
                MessageBox.Show(data_format.Message);
                return;
            }

            SbizClientController.Start(ipAddr, port_int);
        }
        private void SbizClientConnectPanel_Paint(object sender, PaintEventArgs e)
        {

        }
                public void UpdateViewOnModelChanged(object sender, ModelChanged_EventArgs args)
        {
            BeginInvoke(new UpdateViewDelegate(UpdateView), new object[] {sender,args});
        }
        public void UpdateView(object sender, ModelChanged_EventArgs args)
        {
        }
    }
}
