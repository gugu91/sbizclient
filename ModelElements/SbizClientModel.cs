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
        public static SbizClientSender sbiz_socket;
        public static Thread background_thread;
        private static AutoResetEvent _model_sync_event;
        private static SbizQueue<byte[]> _tcp_buffer_queue; /*Coda bloccante thread safe.
                                                           * Add = put nella coda, 
                                                           * take = get dalla coda, 
                                                           * completeadding = 
                                                           *     chiude la coda(http://msdn.microsoft.com/en-us/library/dd287086.aspx)*/
        #endregion 

        #region Properties
        public static AutoResetEvent ModelSyncEvent
        {
            get
            {
                return _model_sync_event;
            }
        }
        public static SbizQueue<byte[]> TCPBufferQueue
        {
            get
            {
                return _tcp_buffer_queue;
            }
        }
        #endregion

        #region StaticMethods
        public static void Init()
        {
            sbiz_socket = new SbizClientSender();
            background_thread = null;
            _model_sync_event = new AutoResetEvent(false);
            _tcp_buffer_queue = new SbizQueue<byte[]>();
        }

        public static void Start(System.Net.IPAddress ipaddress, int port)
        {
            if (background_thread == null)
            {
                background_thread = new Thread(() => Task(ipaddress, port));

                background_thread.Start();
            }
        }

        private static void Task(System.Net.IPAddress ipaddress, int port)
        {
            if (sbiz_socket.Connect(ipaddress, port) == -1)
            {
                SbizClientController.OnModelChanged(sbiz_socket, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.ERROR, "There is no server listening on this port"));
                return;
            }
            
            SbizClientController.OnModelChanged(sbiz_socket, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.CONNECTED));

            byte[] tmp_m;
            while (SbizClientController.Running)
            {
                ModelSyncEvent.WaitOne();
                tmp_m = null;
                if(TCPBufferQueue.Dequeue(ref tmp_m)) sbiz_socket.SendData(tmp_m);
            }
            
            tmp_m = null;
            while(TCPBufferQueue.Dequeue(ref tmp_m)) sbiz_socket.SendData(tmp_m);
            sbiz_socket.ShutdownConnection();
        }

        

        public static void Stop()
        {
            ModelSyncEvent.Set();
            if (background_thread != null)
            {
                background_thread.Join();
            }
               
        }
    }
        #endregion
}
