using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Sbiz.Library;

namespace Sbiz.Client
{
    class SbizClientSender
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

        public SbizClientSender()
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
            s_conn.BeginSend(data, 0, data.Length,SocketFlags.None, SendCallback, s_conn);
        }

        private void SendCallback(IAsyncResult ar)
        {
            Socket handler = (Socket)ar.AsyncState;

            if (handler.EndSend(ar) < 0)
            {
                SbizClientModel.ModelSyncEvent.Set();
            }
        }

        public void ShutdownConnection()
        {
            if (_connected)
            {
                s_conn.Close();
                s_conn = null;

                _connected = false;
                SbizClientController.OnModelChanged(this, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.NOT_CONNECTED));
            }
        }
    }
}
