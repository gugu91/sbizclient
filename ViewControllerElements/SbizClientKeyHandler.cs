using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sbiz.Library;

namespace Sbiz.Client
{
    static class SbizClientKeyHandler //TODO Add Keyboard shortcuts
    {
        #region Attributes
        private static int new_word = -1;
        private static bool _shift_down = false;
        private static bool _control_down = false;
        private static bool _alt_down = false;
        private static Label _text_label;
        #endregion

        #region View Updating Methods
        public static void RegisterLabel(Label l)
        {
            _text_label = l;
        }
        public static void UnregisterLabel()
        {
            _text_label = null;
        }
        public static void KeyPress(KeyPressEventArgs e)
        {
            if (_text_label == null) return;

            var c = e.KeyChar;
            if (char.IsSeparator(c))
            {
                new_word--;
                _text_label.Text += c.ToString();
            }
            else if (c == '\u000D') //unicode for carriage return
            {
                _text_label.Text = c.ToString();
                new_word = 2;
            }
            else if (char.IsControl(c))
            {
                if (c == '\u0008') //unicode for backspace
                {
                    if (_text_label.Text.Length > 0) _text_label.Text = _text_label.Text.Substring(0, _text_label.Text.Length - 1);
                }
                else if (c == '\u007f') //unicode for delete
                {
                    _text_label.Text = "{canc}";
                }
            }
            else
            {
                if (new_word < 0)
                {
                    _text_label.Text = c.ToString();
                    new_word = 2;
                }
                else
                {
                    _text_label.Text += c.ToString();
                }
            }
        }
        #endregion

        #region Special Keys (Alt, Alt+Tab, Etc)
        private static HandleSpecialKeys _del = SpecialKeysHandlerMethod;
        public static HandleSpecialKeys SpecialKeysHandler
        {
            get
            {
                if (_del == null)
                {
                    _del = SpecialKeysHandlerMethod;
                }
                return _del;    
            }
        }
        private static void SpecialKeysHandlerMethod(KeyEventArgs e, int up_or_down)
        {
            if (_text_label != null)
            {
                if (up_or_down == NativeImport.WM_SYSKEYDOWN ||
                    up_or_down == NativeImport.WM_KEYDOWN)
                {
                    KeyDown(e);
                }
                if (up_or_down == NativeImport.WM_SYSKEYUP ||
                    up_or_down == NativeImport.WM_KEYUP)
                {
                    KeyUp(e);
                }
            }
        }
        public static bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (IsLeftAlt(keyData)) return true;
            if (keyData == Keys.F10) return true;
            return false;
        }
        #endregion

        public static void ResetServerKeyboard()
        {
            foreach (var key in (Keys[]) Enum.GetValues(typeof(Keys)))
            {
                SendKeyUp(key);
            }
        }
        public static  void KeyDown(KeyEventArgs e)
        {
            if (IsSbizKey(e))
            {
                //Special Key Down
            }
            else
            {
                if (e.KeyCode == Keys.Menu) SendKeyDown(Keys.LMenu);
                else SendKeyDown(e.KeyCode);
            }
        }
        public static void KeyUp(KeyEventArgs e)
        {
            if (IsSbizKey(e))
            {
                //text_label.Text = "SbizKey Pressed";
            }  
            else
            {
                if (e.KeyCode == Keys.Menu)
                {
                    SendKeyUp(Keys.LMenu);
                }
                else SendKeyUp(e.KeyCode);
            }
        }

        #region Senders
        public static void SendKeyUp(Keys key)
        {
            byte[] data = new byte[0];
            data = SbizNetUtils.EncapsulateInt16inByteArray(data, (Int16)key);//key are int16
            SbizClientController.ModelSetData(new SbizMessage(SbizMessageConst.KEY_UP, data));
        }
        public static void SendKeyDown(Keys key)
        {
            byte[] data = new byte[0];
            data = SbizNetUtils.EncapsulateInt16inByteArray(data, (Int16)key);
            SbizClientController.ModelSetData(new SbizMessage(SbizMessageConst.KEY_DOWN, data));
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
