using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Sbiz.Library;

namespace Sbiz.Client
{
    
    static class SbizClientModel
    {
        #region Attributes
        private static List<string> _buffer_list = new List<string>();
        private static SbizClientSender _active_scs;
        private static SbizClientAnnouncer _sca_listener;
        private static Dictionary<String, SbizClientSender> _all_scs= new Dictionary<String, SbizClientSender>();//TODO give possibility of multiple connections
        #endregion 

        #region Properties
        #endregion

        #region StaticMethods

        public static void Start(int port)
        {
            _sca_listener = new SbizClientAnnouncer();
            _sca_listener.SbizSenderAnnounced += AddSbizSender;
            _sca_listener.Start(port);
        }

        private static void AddSbizSender(object sender, SbizSenderAnnounced_EventArgs args)
        {
            SbizClientSender n_scs = (SbizClientSender)args.Sender;

            lock (_all_scs)
            {
                if (_all_scs.ContainsKey(n_scs.Identifier))
                {
                    _all_scs[n_scs.Identifier].LastSeen = DateTime.Now;
                }
                else
                {
                    _all_scs.Add(n_scs.Identifier, n_scs);
                }
            }

        }
        public static void Connect(System.Net.IPAddress ipaddress, int port)
        {
            _active_scs = new SbizClientSender(ipaddress, port);
            _active_scs.Connect();
        }

        public static void Connect(String identifier)
        {
            lock (_all_scs)
            {
                if (_all_scs.ContainsKey(identifier))
                {
                    _active_scs = _all_scs[identifier];
                    _active_scs.Connect();
                }
            }
        }

        public static void SendData(byte[] m)
        {
            _active_scs.SendData(m);
        }     

        public static void Stop()
        {
            if (_active_scs != null) _active_scs.ShutdownConnection();   
        }
        public static List<String> GetConnectedServersName()
        {
            //Mutex needed??
            List<String> names = new List<String>();

            lock (_all_scs)
            {
                foreach (var element in _all_scs)
                {
                    if(element.Value.Connected)names.Add(element.Value.Identifier);
                    else _buffer_list.Add(element.Value.Identifier);
                }
            }

            return names;
        }

        public static List<String> GetOtherServersName()
        {
            //Mutex needed??
            return _buffer_list;
        }

        public static String GetSctiveServerName()
        {
            lock (_active_scs) return _active_scs.Identifier;
        }
    }
        #endregion
}
