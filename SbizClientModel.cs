using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SbizClient
{
    static class SbizClientModel
    {
        public static SbizClientSocket sbiz_socket;
        public static Thread background_thread;
        private static Int32 _stop;

        public static void Init()
        {
            sbiz_socket = new SbizClientSocket();
            background_thread = null;
            Interlocked.Exchange(ref _stop, 0);
        }

        public static void Start(string ipaddress, int port)
        {
            if (background_thread == null)
            {
                background_thread = new Thread(() => Task(ipaddress, port));
                background_thread.Start();
            }

        }

        private static void Task(string ipaddress, int port)
        {
            sbiz_socket.Connect(ipaddress,port);
            ModelChanged_EventArgs args = new ModelChanged_EventArgs();
            SbizClientController.OnModelChanged(sbiz_socket, args);

            while (_stop == 0)
            {
                sbiz_socket.ReceiveData();
            }

            sbiz_socket.ShutdownConnection();
            Interlocked.Exchange(ref _stop, 0);
        }

        

        public static void Stop()
        {
            Interlocked.Exchange(ref _stop, 1);
            background_thread.Join();
        }
    }
}
