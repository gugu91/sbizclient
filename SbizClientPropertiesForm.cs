using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SbizClient
{
    public partial class SbizClientPropertiesForm : Form, SbizForm
    {
        private delegate void UpdateViewDelegate(object sender, ModelChanged_EventArgs args);

        public SbizClientPropertiesForm()
        {
            InitializeComponent();
            SbizClientController.Init();
            SbizClientController.RegisterView(this);
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            int port_int;
            string port = Port.Text;
            string ipAddr = IpAddress.Text;
            try
            {
                port_int = Int32.Parse(port);
            }
            catch (Exception data_format)
            {
                MessageBox.Show("Invalid Arguments");
                return;
            }

            SbizClientController.Start(ipAddr, port_int);


        }

        public void UpdateViewOnModelChanged(object sender, ModelChanged_EventArgs args)
        {
            BeginInvoke(new UpdateViewDelegate(UpdateView), new object[] {sender,args});
        }

        public void UpdateView(object sender, ModelChanged_EventArgs args)
        {
            if (sender is SbizClientSocket)
            {
                if (((SbizClientSocket)sender).Connected)
                {
                    SbizClientConnectionStatusLabel.Text = "Connected";
                    SbizClientConnectionStatusLabel.ForeColor = Color.Green;
                    SbizClientPanel.Visible = false;
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                }
                else
                {
                    SbizClientConnectionStatusLabel.Text = "Not Connected";
                    SbizClientConnectionStatusLabel.ForeColor = Color.Red;
                    SbizClientPanel.Visible = true;
                }
            }
        }

        
        //private void SbizClientConnectionStatusLabel_Paint(object sender, PaintEventArgs e)
        //{
        //}
      

      
}
 
}
