using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdleTimer
{
    public partial class Form1 : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct LASTINPUTINFO
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public uint dwTime;
        }

        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        private static System.Timers.Timer t = new System.Timers.Timer();
        private static DateTime startTime = DateTime.Now;

        public Form1()
        {
            t.Elapsed += TickHandler;
            t.Enabled = true;
            t.Interval = 1000;
            InitializeComponent();
        }

        delegate void SetLableCallback(string text);

        private void setLabel(string text)
        {
            if (this.label1.InvokeRequired)
            {
                SetLableCallback setLabelCallBack = new SetLableCallback(setLabel);
                this.label1.Invoke(setLabelCallBack, text);
            }
            else
            {
                this.label1.Text = text;
            }
        }

        private void TickHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            long ms = 0;
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = Marshal.SizeOf(lastInputInfo);
            if (!GetLastInputInfo(ref lastInputInfo))
            {
            }
            else
            {
                ms = Environment.TickCount - lastInputInfo.dwTime;
            }
            setLabel(string.Format("{0:00}:{1:00}:{2:00}", ms / (60 * 60 * 1000), ms / (60 * 1000), ms / 1000 - (ms / (60 * 1000)) * 60));
        }
    }
}
