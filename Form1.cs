using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SbizClientForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

            //MessageBox.Show("Sono qui");
            ConnectionStatus.Text = "Connected";

            //KeyboardListener kbd_list = new KeyboardListener();

            //Thread kbd_thread = kbd_list.StartThread(ipAddr, port_int);


        }

       

      
}
 
}
