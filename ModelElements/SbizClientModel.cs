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
        public static SbizClientSocket sbiz_socket;
        public static Thread background_thread;
        private static Int32 _stop;
        public static BlockingCollection<byte[]> message_queue; /*Coda bloccante thread safe.
                                                           * Add = put nella coda, 
                                                           * take = get dalla coda, 
                                                           * completeadding = 
                                                           *     chiude la coda(http://msdn.microsoft.com/en-us/library/dd287086.aspx)*/

        public static void Init()
        {
            sbiz_socket = new SbizClientSocket();
            background_thread = null;
            Interlocked.Exchange(ref _stop, 0);
            message_queue = new BlockingCollection<byte[]>();
        }

        public static void Start(System.Net.IPAddress ipaddress, int port)
        {
            if (background_thread == null)
            {
                if (sbiz_socket.Connect(ipaddress, port) == 1)
                {
                    SbizModelChanged_EventArgs args = new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.CONNECTED);
                    SbizClientController.OnModelChanged(sbiz_socket, args);

                    background_thread = new Thread(() => Task());

                    background_thread.Start();
                   
                }
                else
                {
                    SbizModelChanged_EventArgs args = new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.ERROR, "There is no server listening on this port");
                    SbizClientController.OnModelChanged(sbiz_socket, args);
                }
                
            }

        }

        private static void Task()
        {
            while (_stop == 0)
            {
                byte[] tmp_m;
                if(message_queue.TryTake(out tmp_m, 200))
                {
                    sbiz_socket.SendData(tmp_m);
                }
                else
                {
                    sbiz_socket.SendData(SbizMessage.KeepAliveMessage());
                }
            }

            sbiz_socket.ShutdownConnection();
            Interlocked.Exchange(ref _stop, 0);
        }

        

        public static void Stop()
        {
            Interlocked.Exchange(ref _stop, 1);
            if (background_thread != null)
            {
                background_thread.Join();
            }
               
        }
    }
}
