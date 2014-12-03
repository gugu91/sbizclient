using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sbiz.Client
{
    public partial class SbizSettingsForm : Form
    {
        private int _options_checked; //non dev'essere minore di due per non creare casini con le shortcut utili sul server
        private int _prev_fullscreen_index;
        private int _prev_next_index;
        private int _prev_hotkey_index;
        public SbizSettingsForm()
        {
            InitializeComponent();
            _options_checked = 0;

            if(Properties.Settings.Default.SbizKeyAlt==true)
            {
                SbizClientAltCheckBox.Checked = true;
            }
            if(Properties.Settings.Default.SbizKeyCtrl==true)
            {
                SbizClientCtrlCheckBox.Checked = true;
            }
            if (Properties.Settings.Default.SbizKeyShift==true)
            {
                SbizClientShiftCheckBox.Checked = true;
            }
            SbizClientHotKeyComboBox.Text = Properties.Settings.Default.SbizKey.ToString();
            SbizClientFullscreenComboBox.Text = Properties.Settings.Default.SbizKeyFullscreen.ToString();
            SbizClientNextComboBox.Text = Properties.Settings.Default.SbizKeyNext.ToString();
        }

        

        private void SbizClientCtrlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SbizClientCtrlCheckBox.Checked==true)
            {
                _options_checked++;
                Properties.Settings.Default.SbizKeyCtrl = true;
            }
            else
            {
                _options_checked--;
                if (_options_checked < 2)
                {
                    MessageBox.Show("You cannot select less than two modifiers!", "Error");
                    SbizClientCtrlCheckBox.Checked = true;
                }
                else
                {
                    Properties.Settings.Default.SbizKeyCtrl = false;
                }
            }

        }

        private void SbizClientShiftCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SbizClientShiftCheckBox.Checked==true)
            {
                _options_checked++;
                Properties.Settings.Default.SbizKeyShift = true;
            }
            else
            {
                _options_checked--;
                if (_options_checked < 2)
                {
                    MessageBox.Show("You cannot select less than two modifiers!", "Error");
                    SbizClientShiftCheckBox.Checked = true;
                }
                else
                {
                    Properties.Settings.Default.SbizKeyShift = false;
                }
            }
        }

        private void SbizClientAltCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SbizClientAltCheckBox.Checked==true)
            {
                _options_checked++;
                Properties.Settings.Default.SbizKeyAlt = true;
            }
            else
            {
                _options_checked--;
                if (_options_checked < 2)
                {
                    MessageBox.Show("You cannot select less than two modifiers!", "Error");
                    SbizClientAltCheckBox.Checked = true;
                }
                else
                {
                    Properties.Settings.Default.SbizKeyAlt = false;
                }
            }
        }

        private void SbizClientFullscreenComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = SbizClientFullscreenComboBox.SelectedItem.ToString();
            if (selected == Properties.Settings.Default.SbizKey.ToString() ||
                selected == Properties.Settings.Default.SbizKeyNext.ToString())
            {
                MessageBox.Show("Key already binded to another function ", "Error");
                SbizClientFullscreenComboBox.SelectedIndex = _prev_fullscreen_index;
            }
            else
            {
                Properties.Settings.Default.SbizKeyFullscreen = (Keys)Enum.Parse(typeof(Keys), selected);
            }
        }

        private void SbizClientFullscreenComboBox_Enter(object sender, EventArgs e)
        {
            _prev_fullscreen_index = SbizClientFullscreenComboBox.SelectedIndex;
        }
       
        private void SbizClientNextComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = SbizClientNextComboBox.SelectedItem.ToString();
            if (selected == Properties.Settings.Default.SbizKey.ToString() ||
                selected == Properties.Settings.Default.SbizKeyFullscreen.ToString())
            {
                MessageBox.Show("Key already binded to another function ", "Error");
                SbizClientFullscreenComboBox.SelectedIndex = _prev_next_index;
            }
            else
            {
                Properties.Settings.Default.SbizKeyNext= (Keys)Enum.Parse(typeof(Keys), selected);
            }
        }
      
        private void SbizClientNextComboBox_Enter(object sender, EventArgs e)
        {
            _prev_next_index = SbizClientNextComboBox.SelectedIndex;
        }

        private void SbizClientHotKeyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = SbizClientHotKeyComboBox.SelectedItem.ToString();
            if (selected == Properties.Settings.Default.SbizKeyFullscreen.ToString() ||
                selected == Properties.Settings.Default.SbizKeyNext.ToString())
            {
                MessageBox.Show("Key already binded to another function ", "Error");
                SbizClientHotKeyComboBox.SelectedIndex = _prev_hotkey_index;
            }
            else
            {
                Properties.Settings.Default.SbizKey= (Keys)Enum.Parse(typeof(Keys), selected);
            }
        }

        private void SbizClientHotKeyComboBox_Enter(object sender, EventArgs e)
        {
            _prev_hotkey_index = SbizClientHotKeyComboBox.SelectedIndex;
        }



    }
}
