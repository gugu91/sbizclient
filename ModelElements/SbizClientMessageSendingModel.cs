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
    static class SbizClientMessageSendingModel
    {
        #region Attributes
        private static List<string> _buffer_list = new List<string>();
        private static SbizMessageSender _active_scs;
        private static Dictionary<String, SbizMessageSender> _connected_scs = new Dictionary<String, SbizMessageSender>();
        #endregion 

        #region Properties
        public static Dictionary<string, bool> ConnectedServers
        {
            get
            {
                Dictionary<string, bool> ret_map = new Dictionary<string, bool>();
                string active_id;
                lock (_connected_scs)
                {
                    List<string> removals = new List<string>();
                    foreach (var element in _connected_scs.Values)
                    {
                        if (!element.Connected) removals.Add(element.Identifier);
                        else ret_map.Add(element.Identifier, false);
                    }

                    foreach (var key in removals) _connected_scs.Remove(key);
                }
                if (_active_scs != null)
                {
                    lock (_active_scs) active_id = _active_scs.Identifier;
                    ret_map[active_id] = true;
                }
                return ret_map;
            }
        }
        #endregion

        #region StaticMethods
        public static void Connect(System.Net.IPAddress ipaddress, int port)
        {
            SbizMessageSender tmp_scs = new SbizMessageSender(ipaddress, port);

            if (!_connected_scs.ContainsKey(tmp_scs.Identifier))
            {
                _connected_scs.Add(tmp_scs.Identifier, tmp_scs);
                tmp_scs.Connect();
                _active_scs = tmp_scs;
            }
            else
            {
                _active_scs = _connected_scs[tmp_scs.Identifier];
            }
                
        }
        public static void SendData(byte[] m)
        {
            if (_active_scs != null) _active_scs.SendData(m);
        }     

        public static void Stop()
        {
            if (_active_scs != null) _active_scs.ShutdownConnection();
        }

        public static void RemoveDisconnected(object sender, SbizModelChanged_EventArgs ea)
        {
            if (ea.Status == SbizModelChanged_EventArgs.NOT_CONNECTED || ea.Status == SbizModelChanged_EventArgs.ERROR)
            {
                string id = (string)ea.ExtraArg;
                lock (_connected_scs)
                {
                    _connected_scs.Remove(id);
                    if (_active_scs.Identifier == id) _active_scs = null;
                }
            }
        }

        #endregion
    }
        
}
