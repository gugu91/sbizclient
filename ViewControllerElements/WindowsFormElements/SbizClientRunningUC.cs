using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sbiz.Library;

namespace Sbiz.Client
{
    public partial class SbizClientRunningUC : UserControl, SbizControl
    {
        private SbizClientKeyHandler key_handler;
        public SbizClientRunningUC()
        {
            InitializeComponent();
            SbizClientController.RegisterView(this);
            key_handler = new SbizClientKeyHandler();
        }

        private void SbizClientRunningUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_handler.KeyPress(SbizClientRunningTextLabel, e);
            SbizMessage m = new SbizMessage(SbizMessageConst.KEY_PRESS, Encoding.UTF8.GetBytes(e.KeyChar.ToString()));
            SbizClientController.ModelSetData(m.ToByteArray());
        }

        public void UpdateViewOnModelChanged(object sender, SbizModelChanged_EventArgs args)
        {
            BeginInvoke(new UpdateViewDelegate(UpdateView), new object[] { sender, args });
        }
        public void UpdateView(object sender, SbizModelChanged_EventArgs args)
        {
        }
    }
}
