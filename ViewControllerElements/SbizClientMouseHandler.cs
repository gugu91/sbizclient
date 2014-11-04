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
        public static void MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.Point screen_p = ((Control)sender).PointToScreen(e.Location);//this must be relative to SbizrunningUC, not screen
            SbizLogger.Logger = Cursor.Position.X + " - " + screen_p.X + ", " + Cursor.Position.Y + " - " + screen_p.Y;
            SbizMouseEventArgs smea = new SbizMouseEventArgs(e.Button, e.Clicks, e.Delta, screen_p);
            SbizMessage m = new SbizMessage(SbizMessageConst.MOUSE_MOVE, smea.ToByteArray());
            SbizClientController.ModelSetData(m.ToByteArray());
        }
    }
}
