using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sbiz.Library;

namespace Sbiz.Client
{
    public interface SbizControl //Extend the interface of Form to support the event for any IView object
    {
        void UpdateViewOnModelChanged(object sender, SbizModelChanged_EventArgs args);
    }

    static class SbizClientController
    {
        #region RunningRegion
        private static int _running; //NB never refer to this object as it is not thread safe
        private const int YES = 1;
        private const int NO = 0;
        public static bool Running
        {
            get
            {
                if (_running == YES) return true;
                else return false;
            }
            set
            {
                if (value)
                {
                    System.Threading.Interlocked.Exchange(ref _running, YES);
                }
                else
                {
                    System.Threading.Interlocked.Exchange(ref _running, NO);
                }
            }
        }
        #endregion

        #region ModelChangedEventRegion
        public static event SbizModelChanged_Delegate ModelChanged;
        public static void OnModelChanged(object sender, SbizModelChanged_EventArgs args)
        {
            if (ModelChanged != null)
            {
                ModelChanged(sender, args);
            }
        }
        #endregion

        private static Dictionary<string, SbizAnnouncerInfo> _announced_servers = new Dictionary<string, SbizAnnouncerInfo>();
        public static Dictionary<string, string> AnnouncedServers
        {
            get
            {
                Dictionary<string, string> ret_map = new Dictionary<string,string>();
                lock (_announced_servers)
                {

                    List<string> removals = new List<string>();
                    foreach (var element in _announced_servers.Values)
                    {
                        if (DateTime.Now.Subtract(element.LastSeen) > SbizClientAnnounceReceivingModel.ServerTimeout)
                        {
                            removals.Add(element.Identifier);
                        }
                        else
                        {
                            ret_map.Add(element.Identifier, element.Name);
                        }
                    }

                    foreach (var key in removals) _announced_servers.Remove(key);
                    if(_announced_servers.Count > 20) _announced_servers.Clear();//NB this is to avoid an attack
                }
                return ret_map;
            }
        }
        public static void Start()
        {
            Running = true;
            ModelChanged += AddAnnouncedServer;
            ModelChanged += SbizClientMessageSendingModel.RemoveDisconnected;
            SbizClientAnnounceReceivingModel.Start(15001);//TODO add configuration for port
        }
        public static void Connect(System.Net.IPAddress ipaddress, int port)
        {
            Running = true;
            SbizClientMessageSendingModel.Connect(ipaddress,port);
        }
        public static void Connect(string identifier)
        {
            Running = true;
            System.Net.IPAddress ipaddress = null;
            Int32 port = -1;
            lock (_announced_servers)
            {
                if (_announced_servers.ContainsKey(identifier))
                {
                    ipaddress = _announced_servers[identifier].IpAdd;
                    port = _announced_servers[identifier].TCPPort;
                }
            }
            SbizClientMessageSendingModel.Connect(ipaddress, port);
        }
        public static void MakeActive(string id)
        {
            SbizClientMessageSendingModel.MakeActive(id);
        }
        public static void Disconnect()
        {
            Running = true;
            SbizClientMessageSendingModel.ShutdownConnection();
        }
        public static void Stop()
        {
            Running = false;
            SbizClientMessageSendingModel.Stop();
            SbizClientAnnounceReceivingModel.Stop();
        }

        public static void RegisterView(SbizControl view) //Call this from a view to subscribe the event
        {
            ModelChanged += new SbizModelChanged_Delegate(view.UpdateViewOnModelChanged);
        }
        public static void UnregisterView(SbizControl view) //Call this from a view to unsubscribe events
        {
            ModelChanged -= new SbizModelChanged_Delegate(view.UpdateViewOnModelChanged);
        }

        public static void ModelSetData(byte[] data)
        {
            SbizClientMessageSendingModel.SendData(data);
        }
        public static void AddAnnouncedServer(object sender, SbizModelChanged_EventArgs args)
        {
            if (args.Status == SbizModelChanged_EventArgs.DISCOVERED_SERVER)
            {
                SbizAnnouncerInfo serv = (SbizAnnouncerInfo)args.ExtraArg;

                lock (_announced_servers)
                {
                    if (_announced_servers.ContainsKey(serv.Identifier))
                    {
                        _announced_servers[serv.Identifier].LastSeen = DateTime.Now;
                    }
                    else
                    {
                        _announced_servers.Add(serv.Identifier, serv);
                    }
                }
            }
        }
    }
}
