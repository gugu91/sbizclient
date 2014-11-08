using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbiz.Client
{
    public class SbizAnnouncerInfo
    {
        private string _name;
        private System.Net.IPAddress _ip_add;
        private Int32 _tcp_port;
        private Int64 _last_seen; //NB this object is not thread safe

        public string Name
        {
            get
            {
                return _name;
            }
        }
        public System.Net.IPAddress IpAdd
        {
            get
            {
                return _ip_add;
            }
        }
        public Int32 TCPPort
        {
            get
            {
                return _tcp_port;
            }
        }
        public string Identifier
        {
            get
            {
                return _ip_add.ToString() + ":" + _tcp_port.ToString();
            }
        }
        public DateTime LastSeen
        {
            get
            {
                return new DateTime(_last_seen);
            }
            set
            {
                _last_seen = value.Ticks;
            }
        } //NB this property is not thread safe

        public SbizAnnouncerInfo(string name, System.Net.IPAddress ip_add, int tcp_port)
        {
            _name = name;
            _ip_add = ip_add;
            _tcp_port = tcp_port;
            _last_seen = DateTime.Now.Ticks;
        }
    }
}
