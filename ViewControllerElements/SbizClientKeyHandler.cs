using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }
    }
}
