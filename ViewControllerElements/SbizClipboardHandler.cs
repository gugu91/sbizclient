using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sbiz.Client
{
    public static class SbizClipboardHandler
    {
        public static void HandleClipboardData(Label label, IDataObject data)
        {
            /* Depending on the clipboard's current data format we can process the data differently.*/

            if (data.GetDataPresent(DataFormats.Text))
            {
                string text = (string)data.GetData(DataFormats.Text);
                label.Text = "Updating Clipboard";
                // do something with it
            }
            /*
        else if (iData.GetDataPresent(DataFormats.Bitmap))
        {
            Bitmap image = (Bitmap)iData.GetData(DataFormats.Bitmap);
            // do something with it
        }*/
        }
    }
}
