using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sbiz.Library;

namespace Sbiz.Client
{
    public static class SbizClientMouseHandler
    {
        public static void MouseMove(SbizClientRunningUC uc, Control sender, MouseEventArgs e)
        {
            System.Drawing.Point p = uc.PointToClient(sender.PointToScreen(e.Location));

            SbizMouseEventArgs smea = new SbizMouseEventArgs(e.Button, e.Clicks, e.Delta, p.X, p.Y, uc.Bounds.Width, uc.Bounds.Height);
            SbizMessage m = new SbizMessage(SbizMessageConst.MOUSE_MOVE, smea.ToByteArray());
            SbizClientController.ModelSetData(m.ToByteArray());
        }

        public static void MouseUp(SbizClientRunningUC uc, Control sender, MouseEventArgs e)
        {
            System.Drawing.Point p = uc.PointToClient(sender.PointToScreen(e.Location));
            SbizMouseEventArgs smea = new SbizMouseEventArgs(e.Button, e.Clicks, e.Delta, p.X, p.Y, uc.Bounds.Width, uc.Bounds.Height);
            SbizMessage m = new SbizMessage(SbizMessageConst.MOUSE_MOVE, smea.ToByteArray());
            SbizClientController.ModelSetData(m.ToByteArray());
        }
    }
}
