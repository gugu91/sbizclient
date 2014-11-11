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
        private bool _shift_down = false;
        private bool _control_down = false;
        private bool _alt_down = false;

        public SbizClientKeyHandler()
        {
            new_word = -1;
        }
        #region ViewUpdating
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
        #endregion
        public void KeyDown(Label text_label, KeyEventArgs e)
        {
            if (IsSbizKey(e))
            {
                //Special Key Down
            }
            else
            {
                if (e.Shift && !_shift_down)
                {
                    _shift_down = true;
                    SendKeyDown(Keys.Shift);
                }
                if (e.Control && !_control_down)
                {
                    _control_down = true;
                    SendKeyDown(Keys.Control);
                }
                if (e.Alt && !_alt_down)
                {
                    _alt_down = true;
                    SendKeyDown(Keys.Control);
                }
                if (e.KeyCode == Keys.Menu) SendKeyDown(Keys.LMenu);
                else SendKeyDown(e.KeyCode);
            }
        }

        public void KeyUp(Label text_label, KeyEventArgs e)
        {
            if (IsSbizKey(e))
            {
                //text_label.Text = "SbizKey Pressed";
            }  
            else
            {
                if (!e.Shift && _shift_down)
                {
                    _shift_down = false;
                    SendKeyUp(Keys.Shift);
                }
                if (!e.Control && _control_down)
                {
                    _control_down = false;
                    SendKeyUp(Keys.Control);
                }
                if (!e.Alt && _alt_down)
                {
                    _alt_down = false;
                    SendKeyUp(Keys.Alt);
                }
                if (e.KeyCode == Keys.Menu)
                {
                    SendKeyUp(Keys.LMenu);
                }
                else SendKeyUp(e.KeyCode);
            }
        }

        public bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //switch (keyData)
            //{
            //    case Keys.Alt:
            //        return true;
            //    case Keys.F10:
            //        return true;          
            //}

            if (IsLeftAlt(keyData)) return true;
            if (keyData == Keys.F10) return true;
            return false;
        }

        #region Senders
        public void SendKeyUp(Keys key)
        {
            byte[] data = new byte[0];
            data = SbizNetUtils.EncapsulateInt16inByteArray(data, (Int16)key);//key are int16
            SbizMessage m = new SbizMessage(SbizMessageConst.KEY_UP, data);
            SbizClientController.ModelSetData(m.ToByteArray());
        }
        public void SendKeyDown(Keys key)
        {
            byte[] data = new byte[0];
            data = SbizNetUtils.EncapsulateInt16inByteArray(data, (Int16)key);
            SbizMessage m = new SbizMessage(SbizMessageConst.KEY_DOWN, data);
            SbizClientController.ModelSetData(m.ToByteArray());
        }
        #endregion

        #region SpecificKeysRecognizers
        private static bool IsAltGr(Keys keyData)
        {
            return ((keyData & (Keys.Alt|Keys.Control)) == (Keys.Alt|Keys.Control));
        }
        private static bool IsLeftAlt(Keys keyData)
        {
           if(IsAltGr(keyData)) return false;
           else return ((keyData & Keys.Alt) == Keys.Alt);
        }
        private static bool IsSbizKey(KeyEventArgs e)
        {
            return (e.Shift == Properties.Settings.Default.SbizKeyShift &&
                e.Alt == Properties.Settings.Default.SbizKeyAlt &&
                e.Control == Properties.Settings.Default.SbizKeyCtrl &&
                e.KeyCode == Properties.Settings.Default.SbizKeyValue);
        }
        #endregion
    }
}
