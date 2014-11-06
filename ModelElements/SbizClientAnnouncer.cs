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
    public delegate void SbizSenderAnnounced_Delegate(object sender, SbizSenderAnnounced_EventArgs args);

    public class SbizSenderAnnounced_EventArgs : EventArgs
    {
        private SbizClientSender _sender;

        public SbizClientSender Sender
        {
            get
            {
                return _sender;
            }
        }

        public SbizSenderAnnounced_EventArgs(SbizClientSender sender)
        {
            _sender = sender;
        }
    }


    public class SbizClientAnnouncer
    {
        private Socket s_announce;
        public const int ANNOUNCE_INTERVAL = 200;
        #region SbizSenderAnnouncedEventRegion
        public event SbizSenderAnnounced_Delegate SbizSenderAnnounced;
        public void OnModelSbizSenderAnnounced(object sender, SbizSenderAnnounced_EventArgs args)
        {
            if (SbizSenderAnnounced != null)
            {
                SbizSenderAnnounced(sender, args);
            }
        }
        #endregion

        public SbizClientAnnouncer()
        {
            s_announce = null;
        }

        public void Start(int UDPPort){
            EndPoint ipe = new IPEndPoint(IPAddress.Any, UDPPort);
            s_announce = new Socket(ipe.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            s_announce.Bind(ipe);
            byte[] buffer = new byte[32];
            RecvFromState state = new RecvFromState(s_announce, buffer, ipe, UDPPort);
            s_announce.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref ipe, BeginRecvFromCallback, state);
        }

        public void Stop()
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

        private void BeginRecvFromCallback(IAsyncResult ar)
        {
            var state = ((RecvFromState)ar.AsyncState);
            var ipe = state._ipe;
            state._s.EndReceiveFrom(ar, ref ipe);

            if (ipe.AddressFamily == AddressFamily.InterNetwork)
            {
                OnModelSbizSenderAnnounced(this, new SbizSenderAnnounced_EventArgs(
                    new SbizClientSender( ((IPEndPoint)ipe).Address, ((IPEndPoint)ipe).Port)
                    ));
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
