using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sbiz.Library;

namespace Sbiz.Client
{
    class SbizClientKeyHandler
    {
        private int new_word;

        public SbizClientKeyHandler()
        {
            new_word = -1;
        }

        public void KeyPress(Label text_label, KeyPressEventArgs e)
        {
            var c = e.KeyChar;
            if (char.IsSeparator(c))
            {
                new_word--;
                text_label.Text += c.ToString();
            }
            else if (c == '\u000D') //unicode for carriage return
            {
                text_label.Text = c.ToString();
                new_word = 2;
            }
            else if (char.IsControl(c)) 
            {
                if (c == '\u0008') //unicode for backspace
                {
                    if (text_label.Text.Length > 0) text_label.Text = text_label.Text.Substring(0, text_label.Text.Length - 1);
                }
                else if (c == '\u007f') //unicode for delete
                {
                    text_label.Text = "{canc}";
                }
            }
            else
            {
                if (new_word < 0)
                {
                    text_label.Text = c.ToString();
                    new_word = 2;
                }
                else
                {
                    text_label.Text += c.ToString();
                }
            }
        }

        public void KeyDown(Label text_label, KeyEventArgs e)
        {
            if (e.Shift == Properties.Settings.Default.SbizKeyShift &&
                e.Alt == Properties.Settings.Default.SbizKeyAlt &&
                e.Control == Properties.Settings.Default.SbizKeyCtrl &&
                e.KeyCode == Properties.Settings.Default.SbizKeyValue)
            {
                //Special Key Down
            }
            else
            {
                SendKeyDown(e.KeyCode);
            }
        }

        public void KeyUp(Label text_label, KeyEventArgs e)
        {
            if (e.Shift == Properties.Settings.Default.SbizKeyShift &&
                e.Alt == Properties.Settings.Default.SbizKeyAlt &&
                e.Control == Properties.Settings.Default.SbizKeyCtrl &&
                e.KeyCode == Properties.Settings.Default.SbizKeyValue)
            {
                //text_label.Text = "SbizKey Pressed";
            }  
            else
            {
                SendKeyUp(e.KeyCode);
            }
        }

        public bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            SbizMessage m;
            switch (keyData)
            {
                case Keys.Alt:
                    return true;
                case Keys.F10:
                    return true;          
            }
            return false;
        }

        #region Senders
        public void SendKeyUp(Keys key)
        {
            byte[] data = new byte[0];
            data = SbizNetUtils.EncapsulateInt32inByteArray(data, (int)key);
            SbizMessage m = new SbizMessage(SbizMessageConst.KEY_UP, data);
            SbizClientController.ModelSetData(m.ToByteArray());
        }
        public void SendKeyDown(Keys key)
        {
            byte[] data = new byte[0];
            data = SbizNetUtils.EncapsulateInt32inByteArray(data, (int)key);
            SbizMessage m = new SbizMessage(SbizMessageConst.KEY_DOWN, data);
            SbizClientController.ModelSetData(m.ToByteArray());
        }
        #endregion
    }
}
