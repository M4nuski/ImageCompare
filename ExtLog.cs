using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageComparer
{
    delegate void AddLineDelegate(string text);

    static class ExtLog
    {
        public static Logger Logger;

        static public void AddLine(string Text)
        {
            if (Logger != null)
            {
                if (Logger.InvokeRequired)
                {
                    Logger.Invoke((AddLineDelegate)AddLine, new object[] { Text });
                }
                else
                {
                    Logger.AddLine(Text);
                }
            }
        }
    }
}
