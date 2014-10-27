﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbizClient
{
    public interface SbizForm //Extend the interface of Form to support the event for any IView object
    {
        void UpdateViewOnModelChanged(object sender, ModelChanged_EventArgs args);
    }

    static class SbizClientController
    {
        #region ModelChangedRegion
        public delegate void ModelChanged_Delegate(object sender, ModelChanged_EventArgs args);
        public static event ModelChanged_Delegate ModelChanged;
        public static void OnModelChanged(object sender, ModelChanged_EventArgs args)
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

        public static void Start(string ipaddress, int port)
        {
            SbizClientModel.Start(ipaddress,port);
        }

        public static void Stop()
        {
            SbizClientModel.Stop();
        }

        public static void RegisterView(SbizForm view) //Call this from a view to subscribe the event
        {
            ModelChanged += new ModelChanged_Delegate(view.UpdateViewOnModelChanged);
        }

        public static void UnregisterView(SbizForm view) //Call this from a view to unsubscribe events
        {
            ModelChanged -= new ModelChanged_Delegate(view.UpdateViewOnModelChanged);
        }

        public static void ModelSetData(string data)
        {
            SbizClientModel.message_queue.Add(data);
        }
    }
}
