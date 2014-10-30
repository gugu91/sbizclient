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
    public partial class SbizClientConnectUC : UserControl, SbizControl
    {
        public SbizClientConnectUC()
        {
            InitializeComponent();
            SbizClientController.RegisterView(this);
            this.SbizClientPort.Controls[0].Visible = false;
            this.SbizClientPort.Value = SbizConf.SbizSocketPort;
            this.SbizClientIpAddress.Text = SbizConf.SbizSocketAddress.ToString();
        }

        private void SbizClientConnectButton_Click(object sender, EventArgs e)
        {
            int port;
            decimal port_ascii = SbizClientPort.Value;
            string ipaddr_ascii = SbizClientIpAddress.Text;
            System.Net.IPAddress ipaddr;

            try
            {
                port = Convert.ToInt32(port_ascii);
                if (SbizConf.SbizSocketPort != port) SbizConf.SbizSocketPort = port;
                ipaddr = System.Net.IPAddress.Parse(ipaddr_ascii);
                if (SbizConf.SbizSocketAddress != ipaddr) SbizConf.SbizSocketAddress = ipaddr;
            }
            catch (Exception data_format)
            {
                MessageBox.Show(data_format.Message);
                return;
            }

            SbizClientController.Start(ipaddr, port);
        }
                public void UpdateViewOnModelChanged(object sender, SbizModelChanged_EventArgs args)
        {
            BeginInvoke(new UpdateViewDelegate(UpdateView), new object[] {sender,args});
        }
        public void UpdateView(object sender, SbizModelChanged_EventArgs args)
        {
        }
    }
}
