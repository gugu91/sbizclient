using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SbizClient
{
    class SbizClientSocket
    {
        private Socket s_conn;
        private static bool _connected;

        public bool Connected
        {
            get
            {
                return _connected;
            }
        }

        public SbizClientSocket()
        {
            _connected = false;
        }

        public void Connect(String ipaddress, int port)
        {
            IPAddress address = IPAddress.Parse(ipaddress);
            IPEndPoint ipe = new IPEndPoint(address, port);

            s_conn = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            s_conn.Connect(ipe);
           
            if (!s_conn.Connected)
            {
                _connected = false;
                return;
            }
            _connected = true;

        }

        public void ReceiveData()
        {

        }

        public void ShutdownConnection()
        {
            if (_connected)
            {
                s_conn.Close();
                s_conn = null;

                _connected = false;
                ModelChanged_EventArgs args = new ModelChanged_EventArgs();
                SbizClientController.OnModelChanged(this, args);
            }
        }
    }
}
