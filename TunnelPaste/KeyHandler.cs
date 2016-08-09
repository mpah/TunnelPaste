using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TunnelPaste
{
    public class KeyHandler
    {
        public const int WM_HOTKEY_MSG_ID = 0x0312;
        public const int MOD_CONTROL = 0x0002;

        public const int KEYEVENTF_KEYUP = 0x02;
        public const byte VK_CONTROL = 0x11;


        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        private int key;
        private IntPtr hWnd;
        public int id { get; set; }

        public KeyHandler(Keys key, Form form, int id)
        {
            this.key = (int)key;
            this.hWnd = form.Handle;
            this.id = id;
        }

        public override int GetHashCode()
        {
            return key ^ hWnd.ToInt32();
        }
         
        public bool Register(int mod = 0)
        {
            return RegisterHotKey(hWnd, id, mod, key);
        }

        public bool Unregister()
        {
            return UnregisterHotKey(hWnd, id);
        } 
        public static void ReleaseControl()
        {
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, 0);
        }

    }
}
