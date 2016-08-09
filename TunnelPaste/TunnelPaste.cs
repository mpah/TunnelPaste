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

        public static void pasteClipboard(bool doRemoveSpaces = false)
        {
            string data = Clipboard.GetText();
            if(doRemoveSpaces)
                data = removeSpaces(data);
            data = escapeSpecialChars(data);
            SendKeys.Send(data);
            Console.WriteLine("send:"+data);
        }
        static string escapeSpecialChars(string data)
        {
            string escapedData = Regex.Replace(data, "[{+^%~()0}]", "{$0}");
            return escapedData;
        }
        static string removeSpaces(string data)
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(@"[ ]{4,}", options);
            string escapedData = regex.Replace(data, @"");

            return escapedData;
        }
    }
}
