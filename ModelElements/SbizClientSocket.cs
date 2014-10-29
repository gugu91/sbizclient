using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Sbiz.Client
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

        public int Connect(IPAddress ipaddress, int port)
        {
            IPEndPoint ipe = new IPEndPoint(ipaddress, port);

            s_conn = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                s_conn.Connect(ipe);
            }
            catch(Exception e)
            {
                _connected = false;
                return -1;
            }
           
            _connected = true;
            return 1;

        }

        public void SendData(byte[] data)
        {
            try
            {
                s_conn.Send(data,data.Length,SocketFlags.None);
            }
            catch(Exception e)
            {
                //TODO capire quale eccezione è stata sollevata
                return;
            }
        }

        public void ShutdownConnection()
        {
            if (_connected)
            {
                s_conn.Close();
                s_conn = null;

                _connected = false;
                ModelChanged_EventArgs args = new ModelChanged_EventArgs(ModelChanged_EventArgs.NOT_CONNECTED);
                SbizClientController.OnModelChanged(this, args);
            }
        }
    }
}
