using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TunnelPaste
{
    public partial class Form1 : Form
    {
        private KeyHandler hotKey;
        private KeyHandler vKey;
       
        public Form1()
        {
            InitializeComponent();


      
        }
        //Overrides
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == KeyHandler.WM_HOTKEY_MSG_ID)
                HandleHotkey(m);
           else
            base.WndProc(ref m);
        }
        //Internal Functions
        private void HandleHotkey(Message m)
        {
            int id = m.WParam.ToInt32();
            if (hotKey != null  && id == hotKey.id)
            {
                Console.WriteLine("hotkey pressed");
                TunnelPaste.pasteClipboard();
            }
            else if (vKey != null && id == vKey.id)
            {
                Console.WriteLine("ctrl+v pressed");
                KeyHandler.releaseControl();
                TunnelPaste.pasteClipboard();
            }

        }
        void setHotKey(Keys key)
        {
            hotKey = new KeyHandler(key, this, 1);
            hotKey.Register();

        }
        //Form Events

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                vKey = new KeyHandler(Keys.V, this, 2);
                vKey.Register(KeyHandler.MOD_CONTROL);
            }
            else if(vKey != null)
            {
                vKey.Unregister();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(hotKey != null)
            {
                hotKey.Unregister();
            }
        }
        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
