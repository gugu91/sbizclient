using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SbizClient
{
    class SbizClientKeyHandler
    {
        private bool new_word;

        public SbizClientKeyHandler()
        {
            new_word = true;
        }

        public void KeyPress(Label text_label, KeyPressEventArgs e)
        {
            var c = e.KeyChar;
            if (c == ' ')
            {
                new_word = true;
                text_label.Text += c.ToString();
            }
            else
            {
                if (new_word)
                {
                    text_label.Text = c.ToString();
                    new_word = false;
                }
                else
                {
                    text_label.Text += c.ToString();
                }
            }
        }
    }
}
