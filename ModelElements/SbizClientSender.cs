﻿using System;
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
        private static int _connected; //NB never refer to this object as it is not thread safe
        private const int YES = 1;
        private const int NO = 0;
        public static bool Connected
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
        #endregion

        public SbizClientSender()
        {
            Connected = false;
        }

        public int Connect(IPAddress ipaddress, int port)
        {
            IPEndPoint ipe = new IPEndPoint(ipaddress, port);

            s_conn = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            SbizClientController.OnModelChanged(this, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.TRYING));
            try
            {
                s_conn.Connect(ipe);
            }
            catch(Exception e)
            {
                Connected = false;
                SbizClientController.OnModelChanged(this, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.ERROR, "There is no server listening on this port"));
                return -1;
            }

            SbizClientController.OnModelChanged(this, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.CONNECTED));
           
            Connected = true;
            return 1;

        }

        public void SendData(byte[] data)
        {
            try
            {
                /* NB there was previously a protocol error as size of the data buffer was not sent, causing
                 * some data to not be processed by server.
                 */
                byte[] datasize = BitConverter.GetBytes(data.Length);//size of the message is sent
                byte[] buffer = new byte[datasize.Length+data.Length];
                datasize.CopyTo(buffer, 0);
                data.CopyTo(buffer, datasize.Length);
                //s_conn.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, SendCallback, s_conn);
                s_conn.Send(buffer, 0, buffer.Length, SocketFlags.None);
            }
            catch (SocketException se)
            {
                if (Connected)
                {
                    Connected = false;
                    SbizClientModel.ModelSyncEvent.Set();
                    SbizClientController.OnModelChanged(this, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.ERROR, "Server disconnected"));
                }
            }
        }
        /*
        private void SendCallback(IAsyncResult ar)
        {
            Socket handler = (Socket)ar.AsyncState;

            if (handler.EndSend(ar) < 0 && Connected)
            {
                Connected = false;
                SbizClientModel.ModelSyncEvent.Set();
                SbizClientController.OnModelChanged(this, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.ERROR, "Server disconnected"));
            }
        }*/

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
