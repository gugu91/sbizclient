using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbizClient
{
    public class ModelChanged_EventArgs : EventArgs
    {
        private int _status;
        private string _error_message;

        public const int CONNECTED = 1;
        public const int NOT_CONNECTED = 0;
        public const int ERROR = -1;

        public int Status
        {
            get
            {
                return _status;
            }
        }

        public string Error_message
        {
            get
            {
                return _error_message;
            }
        }

        public ModelChanged_EventArgs(int status)
        {
            this._status = status;
        }

        public ModelChanged_EventArgs(int status, string error_message)
        {
            //TODO: logger
            this._status = status;
            this._error_message = error_message;
        }
    }
}
