using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Net;
using System.IO;
using System.Threading;
using System.Net.Sockets;

namespace Lecture
{
    public partial class UCScreenCapture : UserControl
    {
        public UCScreenCapture()
        {
            InitializeComponent();
        }

        string ip;
        string Config = "";
        int alowString = 1;
        Size getSize;
        public string ComputerNumber
        {
            get { return labComputerName.Text; }
            set { labComputerName.Text = value; }
        }
        public string GetIP
        {
            get { return ip; }
            set { ip = value; }
        }

        void Stop()
        {
            try
            {
                runtime.Enabled = false;
                ChannelServices.UnregisterChannel(channel);
                runtime.Dispose();

            }
            catch (Exception ex) { runtime.Enabled = false; ResetPicture(); };
        }
        public void ResetPicture()
        {
            pteScreenCapture.Image = Teacher.Properties.Resources.Internet_Disconnect;
        }
        ScreenCapture.ScreenCapture obj;
        TcpChannel channel;
        public void Start()
        {

            if (GetIP != "0.0.0.0")
            {
                try
                {
                    channel = new TcpChannel();
                    ChannelServices.RegisterChannel(channel, false);
                    string URI = "Tcp://" + this.GetIP + ":6600/MyCaptureScreenServer";
                    obj = (ScreenCapture.ScreenCapture)Activator.GetObject(typeof(ScreenCapture.ScreenCapture), URI);
                    byte[] buff = obj.UCGetDesktopBitmapBytes();
                    if (alowString == 1)
                    {
                        Config = obj.GetConfig(); getSize = obj.GetDesktopBitmapSize();
                    }
                    byte[] tmp = ScreenCapture.QuickLZ.decompress(buff);
                    MemoryStream ms = new MemoryStream(tmp);
                    pteScreenCapture.Image = Image.FromStream(ms);
                    ChannelServices.UnregisterChannel(channel);
                    runtime.Enabled = true;
                }
                catch
                {
                    ResetPicture();
                }
            }
            else
            {
                runtime.Enabled = false;
                runtime.Dispose();

            }
            //Stop(); }
        }

        private void runtime_Tick(object sender, EventArgs e)
        {
            try
            {
                Start();
            }
            catch
            {
                Stop();
            }

        }

        private void pteScreenCapture_DoubleClick(object sender, EventArgs e)
        {
            if (this.GetIP != "0.0.0.0")
            {
                runtime.Enabled = false;
                //devMain frm = new devMain();
                frmRemoting t = new frmRemoting(getSize);
                t.IP = this.GetIP;
                t.StartPosition = FormStartPosition.CenterScreen;
                t.ShowDialog();

            }
            else
            {
                MessageBox.Show("Bạn chưa kết nối được với máy này", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
