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
        public static SbizClientSender active_scs;
        //public static List<SbizClientSender> all_scs= new List<SbizClientSender>();//TODO give possibility of multiple connections
        #endregion 

        #region Properties
        #endregion

        #region StaticMethods
        public static void Connect(System.Net.IPAddress ipaddress, int port)
        {
            active_scs = new SbizClientSender();
            active_scs.Connect(ipaddress, port);
        }

        public static void SendData(byte[] m)
        {
            active_scs.SendData(m);
        }     

        public static void Stop()
        {
            active_scs.ShutdownConnection();   
        }
        public static Dictionary<string, bool> RemoteServerNameMap()
        {
            //Mutex needed??
            if(active_scs == null || !active_scs.Connected) return null;
            else
            {
                Dictionary<string, bool> map = new Dictionary<string, bool>();
                map.Add(active_scs.Name, true);
                return map;
            }
        }
    }
        #endregion
}
