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
        private static SbizMessager _active_sms;
        private static Dictionary<String, SbizMessager> _connected_sms = new Dictionary<String, SbizMessager>();
        #endregion 

        #region Properties
        public static Dictionary<string, bool> ConnectedServers
        {
            get
            {
                Dictionary<string, bool> ret_map = new Dictionary<string, bool>();
                string active_id;
                lock (_connected_sms)
                {
                    List<string> removals = new List<string>();
                    foreach (var element in _connected_sms.Values)
                    {
                        if (!element.Connected) removals.Add(element.Identifier);
                        else ret_map.Add(element.Identifier, false);
                    }

                    foreach (var key in removals) _connected_sms.Remove(key);
                }
                if (_active_sms != null)
                {
                    lock (_active_sms) active_id = _active_sms.Identifier;
                    ret_map[active_id] = true;
                }
                return ret_map;
            }
        }
        #endregion

        #region StaticMethods
        public static void MakeActive(string id)
        {
            SendData(SbizMessage.NotTargetToByteArray());
            if (_connected_sms.ContainsKey(id)) _active_sms = _connected_sms[id];
            SendData(SbizMessage.TargetToByteArray());
        }
        public static void Connect(System.Net.IPAddress ipaddress, int port, IntPtr view_handle)
        {
            SendData(SbizMessage.NotTargetToByteArray());
            SbizMessager tmp_scs = new SbizMessager(ipaddress, port);

            if (!_connected_sms.ContainsKey(tmp_scs.Identifier))
            {
                _connected_sms.Add(tmp_scs.Identifier, tmp_scs);
                tmp_scs.ConnectToServer(SbizClientController.OnModelChanged, view_handle);
                _active_sms = tmp_scs;
            }
            else
            {
                _active_sms = _connected_sms[tmp_scs.Identifier];
            }
        }
        public static void SendData(byte[] m)
        {
            if (_active_sms != null) _active_sms.SendData(m, SbizClientController.OnModelChanged);
        }

        public static void SendMessage(SbizMessage m)
        {
            SendData(m.ToByteArray());
        }
        public static void Stop()
        {
            List<SbizMessager> l;
            lock(_connected_sms) l = _connected_sms.Values.ToList();
            foreach (var element in l) element.ShutdownConnectionWithServer(SbizClientController.OnModelChanged);
            _connected_sms.Clear(); //This should be superflous, elements removed from connection by remove disconnected delegate
        }
        public static void ShutdownConnection()
        {
            if (_active_sms != null)
            {
                _active_sms.ShutdownConnectionWithServer(SbizClientController.OnModelChanged);
            }
            //Removed from the collection by the remove disconnected delegate
        }
        public static void RemoveDisconnected(object sender, SbizModelChanged_EventArgs ea)
        {
            if (ea.Status == SbizModelChanged_EventArgs.NOT_CONNECTED || ea.Status == SbizModelChanged_EventArgs.ERROR)
            {
                string id = (string)ea.ExtraArg;
                lock (_connected_sms)
                {
                    _connected_sms.Remove(id);
                    if (_active_sms != null && _active_sms.Identifier == id) _active_sms = null;
                }
            }
        }

        #endregion
    }
        
}
