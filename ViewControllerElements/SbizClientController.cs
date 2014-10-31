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

        public static void Init()
        {
            Running = true;
            SbizClientModel.Init();
        }

        public static void Start(System.Net.IPAddress ipaddress, int port)
        {
            Running = true;
            SbizClientModel.Start(ipaddress,port);
        }

        public static void Stop()
        {
            Running = false;
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
            SbizClientModel.TCPBufferQueue.Enqueue(data);
            SbizClientModel.ModelSyncEvent.Set();
        }
    }
}
