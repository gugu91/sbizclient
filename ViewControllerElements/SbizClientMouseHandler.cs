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
            BasicMouse(uc, sender, e, SbizMessageConst.MOUSE_MOVE);
        }

        public static void MouseUp(SbizClientRunningUC uc, Control sender, MouseEventArgs e)
        {
            BasicMouse(uc, sender, e, SbizMessageConst.MOUSE_UP);
        }

        public static void MouseDown(SbizClientRunningUC uc, Control sender, MouseEventArgs e)
        {
            BasicMouse(uc, sender, e, SbizMessageConst.MOUSE_DOWN);
        }

        public static void MouseWheel(SbizClientRunningUC uc, Control sender, MouseEventArgs e)
        {
            BasicMouse(uc, sender, e, SbizMessageConst.MOUSE_WHEEL);
        }

        private static void BasicMouse(SbizClientRunningUC uc, Control sender, MouseEventArgs e, int type)
        {
            System.Drawing.Point p = uc.PointToClient(sender.PointToScreen(e.Location));
            SbizMouseEventArgs smea = new SbizMouseEventArgs(e.Button, e.Clicks, e.Delta/SystemInformation.MouseWheelScrollDelta, p.X, p.Y, uc.Bounds.Width, uc.Bounds.Height);
            SbizClientController.ModelSetData(new SbizMessage(type, smea.ToByteArray()));
        }
    }
}
