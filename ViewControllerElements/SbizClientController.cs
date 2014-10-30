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

        public static void Init()
        {
            SbizClientModel.Init();
        }

        public static void Start(System.Net.IPAddress ipaddress, int port)
        {
            SbizClientModel.Start(ipaddress,port);
        }

        public static void Stop()
        {
            SbizClientModel.Stop();
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
            SbizClientModel.message_queue.Add(data);
        }
    }
}
