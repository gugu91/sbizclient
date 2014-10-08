using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SbizClientForms
{
    public class KeyboardListener
    {
        private volatile bool _stop;

        public KeyboardListener()
        {
            _stop = false;
        }

        public Thread StartThread(string ipaddress, int port)
        {
            var t = new Thread(() => Task(ipaddress, port));
            t.Start();
            return t;
        }

        public void Task(string ipaddress, int port)
        {
            //ConsoleKeyInfo cki;

            IPAddress address = IPAddress.Parse(ipaddress);
            IPEndPoint ipe = new IPEndPoint(address, port);
            Socket s =
               new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            s.Connect(ipe);
            if (!s.Connected)
            {
                
                // Console.WriteLine("Server Unreachable");
                return;
            }

            while (!_stop)
            {
                //cki = Console.ReadKey();
                //byte[] msg = Encoding.UTF8.GetBytes(cki.KeyChar.ToString());
                //int i = s.Send(msg);
            }

            s.Close();
        }

        public void Stop()
        {
            _stop = true;
        }
    
    }
}
