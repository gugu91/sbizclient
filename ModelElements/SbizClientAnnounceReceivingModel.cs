using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Sbiz.Library;

namespace Sbiz.Client
{
    public static class SbizClientAnnounceReceivingModel
    {
        private static Socket s_announce;
        public const int ANNOUNCE_INTERVAL = 200; // milliseconds
        public const int PACKET_LOSS_ACCEPTANCE = 5;

        public static TimeSpan ServerTimeout
        {
            get
            {
                return new TimeSpan(0, 0, 0, 0, PACKET_LOSS_ACCEPTANCE * ANNOUNCE_INTERVAL);
            }
        }

        public static void Start(int UDPPort){
            EndPoint ipe = new IPEndPoint(IPAddress.Any, UDPPort);
            s_announce = new Socket(ipe.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            s_announce.Bind(ipe); //TODO Handle bind exception
            byte[] buffer = new byte[256];
            RecvFromState state = new RecvFromState(s_announce, buffer, ipe, UDPPort);
            s_announce.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref ipe, BeginRecvFromCallback, state);
        }

        public static void Stop()//TODO verify this
        {
            try
            {
                s_announce.Close();
            }
            catch (Exception)
            {
                //Already closed
            }

        }

        private static void BeginRecvFromCallback(IAsyncResult ar)
        {
            var state = ((RecvFromState)ar.AsyncState);
            var ipe = state._ipe;
            int bytesRead;
            try
            {
                bytesRead = state._s.EndReceiveFrom(ar, ref ipe);
            }
            catch(Exception)
            {
                //Client Closed app, return
                return;
            }

            if (bytesRead > 0)
            {
                /* NB there was previously a protocol error as size of the data buffer was not sent, causing
                    * some data to not be processed by server.
                    */
                int seek=0;
                while (seek < bytesRead)
                {
                    //First four bytes are the size of the subsequent databuffer
                    byte[] datasize_byte = new byte[sizeof(Int32)];
                    Array.Copy(state._buffer, seek, datasize_byte, 0, sizeof(Int32));
                    seek += sizeof(Int32);
                    Int32 datasize = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(datasize_byte, 0));

                    //Databuffer handled here
                    byte[] data = new byte[datasize];
                    Array.Copy(state._buffer, seek, data, 0, datasize);
                    seek += datasize;
                    if (ipe.AddressFamily == AddressFamily.InterNetwork)
                    {
                        SbizAnnounce m = new SbizAnnounce(data);
                        SbizAnnouncerInfo serv = new SbizAnnouncerInfo(m.Name, ((IPEndPoint)ipe).Address, m.TCPPort);
                        SbizClientController.OnModelChanged(state._s, new SbizModelChanged_EventArgs(
                            SbizModelChanged_EventArgs.DISCOVERED_SERVER, "Discovered Server", serv));
                    }
                }
            }

            state._ipe = new IPEndPoint(IPAddress.Any, state._udp_port);
            state._s.BeginReceiveFrom(state._buffer, 0, state._buffer.Length, SocketFlags.None, ref state._ipe, BeginRecvFromCallback, state);
            
        }

        private class RecvFromState
        {
            public Socket _s;
            public byte[] _buffer;
            public EndPoint _ipe;
            public int _udp_port;

            public RecvFromState(Socket s, byte[] buffer, EndPoint ipe, int udp_port)
            {
                _s = s;
                _buffer = buffer;
                _ipe = ipe;
                _udp_port = udp_port;
            }
        }
    }
}
