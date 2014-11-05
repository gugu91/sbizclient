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
            if (c == ' ')
            {
                new_word--;
                text_label.Text += c.ToString();
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
            SbizMessage m = new SbizMessage(SbizMessageConst.KEY_PRESS, Encoding.UTF8.GetBytes(e.KeyChar.ToString()));
            SbizClientController.ModelSetData(m.ToByteArray());
        }

        public void PreviewKeyDown(Label text_label, PreviewKeyDownEventArgs e)
        {

        }

        public void KeyDown(Label text_label, KeyEventArgs e)
        {

        }
    }
}
