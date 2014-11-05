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
        #region RunningRegion
        private int _connected; //NB never refer to this object as it is not thread safe
        private const int YES = 1;
        private const int NO = 0;
        public bool Connected
        {
            get
            {
                if (_connected == YES) return true;
                else return false;
            }
            set
            {
                if (value)
                {
                    System.Threading.Interlocked.Exchange(ref _connected, YES);
                }
                else
                {
                    System.Threading.Interlocked.Exchange(ref _connected, NO);
                }
            }
        }
        public string Name
        {
            get
            {
                if (Connected) return s_conn.RemoteEndPoint.ToString();
                return null;
            }
        }
        #endregion

        public SbizClientSender()
        {
            Connected = false;
        }

        public void Connect(IPAddress ipaddress, int port)
        {
            IPEndPoint ipe = new IPEndPoint(ipaddress, port);

            s_conn = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            SbizClientController.OnModelChanged(this, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.TRYING));
            try
            {
                s_conn.BeginConnect(ipe, ConnectCallback, s_conn);
            }
            catch(SocketException)
            {
                Connected = false;
                SbizClientController.OnModelChanged(this, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.ERROR, "There is no server listening on this port"));
            }
        }

        public void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                ((Socket)ar.AsyncState).EndConnect(ar);
                ((Socket)ar.AsyncState).NoDelay = true;
                Connected = true;
                SbizClientController.OnModelChanged(this, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.CONNECTED));
            }
            catch (SocketException)
            {
                Connected = false;
                SbizClientController.OnModelChanged(this, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.ERROR, "There is no server listening on this port"));
            }
            catch (ObjectDisposedException)
            {
                Connected = false;
                //User shutdown connection, do nothing
            }
        }

        public void SendData(byte[] data)
        {
            try
            {
                /* NB there was previously a protocol error as size of the data buffer was not sent, causing
                 * some data to not be processed by server.
                 */
                byte[] buffer = SbizNetUtils.EncapsulateInt32inByteArray(data, data.Length);
                s_conn.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, SendCallback, s_conn);
                //s_conn.Send(buffer, 0, buffer.Length, SocketFlags.None);
            }
            catch (SocketException)
            {
                if (Connected)
                {
                    Connected = false;
                    SbizClientController.OnModelChanged(this, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.ERROR, "Server disconnected"));
                }
            }
        }
        
        private void SendCallback(IAsyncResult ar)
        {
            if (Connected)
            {
                Socket handler = (Socket)ar.AsyncState;
                int nbyte;
                try
                {
                    nbyte = handler.EndSend(ar);
                }
                catch (SocketException)
                {
                    nbyte = -1;
                }

                if (nbyte < 0 && Connected)
                {
                    Connected = false;
                    SbizClientController.OnModelChanged(this, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.ERROR, "Server disconnected"));
                }
            }
        }

        public void ShutdownConnection()
        {
            if (Connected)
            {
                s_conn.Close();

                Connected = false;
                SbizClientController.OnModelChanged(this, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.NOT_CONNECTED));
            }
        }
    }
}
