using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TunnelPaste
{
    static class TunnelPaste
    {

        public static void pasteClipboard()
        {
            string data = Clipboard.GetText();
            data = escapeSpecialChars(data);
            SendKeys.Send(data);
            Console.WriteLine("send:"+data);
        }
        static string escapeSpecialChars(string data)
        {
            string escapedData = Regex.Replace(data, "[{+^%~()0}]", "{$0}");
            return escapedData;
        }
    }
}
