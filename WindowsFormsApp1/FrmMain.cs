using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using Microsoft.Win32;
using System.Net.NetworkInformation;

namespace Lecture
{
    public partial class FrmMain : Form
    {
        Tool ct = new Tool();
        public FrmMain()
        {
            InitializeComponent();
            //this.ShowInTaskbar = false;  // Khong cho di chuyen From
            this.ControlBox = false;   // khoa nut thoat Form
        }
        //   https://nosomovo.xyz/2017/09/26/khoi-dong-ung-dung-cung-windows-trong-c/
        RegistryKey My_app_key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);   // khởi động cùng win           
        /// <summary>
        /// Tạo một socket để kết nối đến server;
        /// </summary>
        public static Socket client;
        public static List<string> lst = new List<string>();
        public static ScreenCapture.ScreenCapture myScreen = null;
        public static ObjRef objServer = null;
        public static TcpChannel Channel = null;
        public static void StopListen()
        {
            try
            {
                if (objServer != null)
                { RemotingServices.Unmarshal(objServer); }
                if (myScreen != null)
                    RemotingServices.Disconnect(myScreen);
                if (Channel != null)
                    ChannelServices.UnregisterChannel(Channel);
                myScreen = null;
                Channel = null;
                objServer = null;
            }
            catch { }
        }
        public static void startListen()
        {
            StopListen();
            try
            {
                Channel = new TcpChannel(6601);
                ChannelServices.RegisterChannel(Channel, false);
                myScreen = new ScreenCapture.ScreenCapture();
                objServer = RemotingServices.Marshal(myScreen, "MyCaptureScreenServer");
            }
            catch { }
        }


        string s = "";
        string host;
        Thread trSendMessage;
        /// <summary>
        /// Gửi thông tin sang máy khác
        /// </summary>
        public void SendMessage()
        {
            int port = 63000;
            try
            {
                TcpClient tcpCli = new TcpClient(host, port);
                NetworkStream ns = tcpCli.GetStream();
                // Gửi thông tin tới các thành viên trong nhóm
                StreamWriter sw = new StreamWriter(ns);
                sw.WriteLine(s);
                sw.Flush();
                sw.Close();
                ns.Close();
                trSendMessage.Abort();
            }
            catch
            { trSendMessage.Abort(); }
        }
        private void BtnDone_Click(object sender, EventArgs e)
        {
            Stop.Enabled = true;
            timer2.Start();
            startListen();
            tsmiStopTeach.Text = "Ngừng giảng";
            notifyIcon1.BalloonTipText = "Hệ thống đã mở chức năng giảng bài";
            notifyIcon1.BalloonTipTitle = "PTMS Teacher ";
            //notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ShowBalloonTip(1000);
            this.WindowState = FormWindowState.Minimized;
            BtnDone.Enabled = false;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    host = txtIP.Text.Trim();   //host = "172.169.1.91";
            //    s = "172.169.1.34" + " " + "##giangbai##";  // "172.169.1.34"    GetLocalIPAddress().Trim()
            //    trSendMessage = new Thread(SendMessage);
            //    trSendMessage.Start();
            //    Thread.Sleep(150);
            //}
            //catch
            //{ }

            int k = 0, l = 0;
            ct.GetIPhongMay(ref k, ref l);  // lấy danh sách IP phòng máy
            for (int i = k; i < l; i++)
            {
                try
                {
                    host = "10.0.0." + i.ToString().Trim();
                    s = ct.GetLocalIPAddress().Trim() + " " + "##giangbai##";   // "172.169.1.34"
                    trSendMessage = new Thread(SendMessage);
                    trSendMessage.Start();        // thông báo lỗi tại dòng này  26/04/2019
                    Thread.Sleep(150); // 150           // he code bellow put your application sleep in some times     
                }
                catch
                {
                    continue;
                }
            }
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            //this.Hide();
            Stop.Enabled = false;
            // https://nosomovo.xyz/2017/09/26/khoi-dong-ung-dung-cung-windows-trong-c/
            My_app_key.SetValue("Teacher.exe", "\"" + Application.ExecutablePath.ToString() + "\"");   // khởi động cùng win
        }

        //
        private void Stop_Click(object sender, EventArgs e)
        {
            BtnDone.Enabled = true;
            timer2.Enabled = false;
            timer2.Dispose();
            StopListen();
            Stop.Enabled = false;
        }
        public static string ipPC = "";
        private void btnRemote_Click(object sender, EventArgs e)
        {
            //ipPC = txtIP.Text.Trim(); 
            FrmWatchScreenStudent frm = new FrmWatchScreenStudent();
            frm.Show();
        }

        //
        #region Nhận dữ liệu
        NetworkStream myns;
        TcpListener mytcpl;
        Socket mysocket;
        Thread myth;
        BinaryReader bb;
        /// <summary>
        /// Kiểm tra xem thư mục này đã tồn tại hay chưa
        /// Nếu chưa tồn tại thì tạo một thư mục mới
        /// </summary>
        /// <param name="strPath"></param>
        public void CreateFolder(string strPath)
        {

            try
            {
                if (Directory.Exists(strPath) == false)
                {

                    Directory.CreateDirectory(strPath);
                }
            }
            catch { }
        }

        /// <summary>
        /// Nhận dữ liệu
        /// </summary>
        void File_Receiver()
        {
            mytcpl = new TcpListener(7000);
            mytcpl.Start();
            mysocket = mytcpl.AcceptSocket();
            myns = new NetworkStream(mysocket);
            BinaryFormatter br = new BinaryFormatter();
            object op;

            op = br.Deserialize(myns); // Deserialize the Object from Stream
            bb = new BinaryReader(myns);
            byte[] buffer = bb.ReadBytes(150000000);
            //Kiểm tra file đã tồn tại chưa, nếu tồn tại rồi thì xóa file đó đi

            if (File.Exists(@"E:\PTMS\DuLieu\" + (string)op))
            {
                File.Delete(@"E:\PTMS\DuLieu\" + (string)op);
            }
            CreateFolder(@"E:\PTMS");
            CreateFolder(@"E:\PTMS\DuLieu");
            FileStream fss = new FileStream(@"E:\PTMS\DuLieu\" + (string)op, FileMode.CreateNew, FileAccess.Write);
            //Lưu file mới nhận vào ổ C 

            fss.Write(buffer, 0, buffer.Length);

            fss.Close();
            mytcpl.Stop();
            notifyIcon1.BalloonTipText = "Bạn vừa nhận được một file dữ liệu từ sinh viên";
            notifyIcon1.BalloonTipTitle = "PTMS";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ShowBalloonTip(100);

            //XtraMessageBox.Show("Bạn vừa nhận được một file dữ liệu từ máy khác gửi tới !", "Hệ thống hỗ trợ giảng dạy thực hành và quản lý phòng máy", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (mysocket.Connected == true)
            {
                while (true)
                {
                    File_Receiver();
                }
            }
        }
        #endregion

        #region Nhận yêu cầu chat
        Thread trlisten;
        TcpListener tcpList;
        public static string xau = "";
        private void ListenToServer()
        {
            bool LISTENING = false;

            int port = 6400;
            //' PORT ADDRESS
            ///'''''''' making socket tcpList ''''''''''''''''
            tcpList = new TcpListener(port);
            try
            {
                tcpList.Start();
                LISTENING = true;

                while (LISTENING)
                {
                    while (tcpList.Pending() == false & LISTENING == true)
                    {
                        // Yield the CPU for a while.
                        Thread.Sleep(10);
                    }
                    if (!LISTENING)
                        break; // TODO: might not be correct. Was : Exit Do

                    TcpClient tcpCli = tcpList.AcceptTcpClient();
                    //ListBox1.Items.Add("Data from " & "128.10.20.63")
                    NetworkStream ns = tcpCli.GetStream();
                    StreamReader sr = new StreamReader(ns);
                    ///'''''' get data from client '''''''''''''''
                    string receivedData = sr.ReadLine();
                    bool kt = false;
                    if (receivedData.IndexOf("chatlan") >= 0)
                    {
                        string[] mang = receivedData.Split(',');
                        if (ct.GetworkgroupPC() == mang[2].ToString())    //  frmJoinGroup.RoomName // Biến p604 nhập thủ công   // những máy nào cùng phòng thực hành mới chát với nhau được
                        {
                            foreach (string item in lst)
                            {
                                if (item == mang[1].ToString())
                                { kt = true; }
                            }
                            if (kt == false)
                            {
                                Program.iPClient = mang[1];
                                lst.Add(Program.iPClient);
                                xau = mang[3] + ": " + mang[4];
                                Program.FullNameStudent = mang[3];
                            }
                        }
                    }
                    sr.Close();
                    ns.Close();
                    tcpCli.Close();
                }
                tcpList.Stop();
            }
            catch (Exception ex)
            {
                //error
                LISTENING = false;
            }
        }
        #endregion

        #region Thực thi tắt hoặc reset toàn bộ phòng máy
        private void btnShutdownAll_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn tắt tất cả máy tính của phòng không? ", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                GetStudent("###SHUTDOWN###");
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
                return;
            }

        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn khởi động tất cả máy tính của phòng không? ", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                GetStudent("###REBOOT###");
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
                return;
            }

        }
        #endregion

        #region Lấy về danh sách sinh viên
        void GetStudent(string style)
        {
            int i = 0, j = 0, l = 0;
            ct.GetIPhongMay(ref j, ref l);
            for (i = j; i < l; i++)
            {
                try
                {
                    host = "10.0.0." + i.ToString();
                    s = style;
                    trSendMessage = new Thread(SendMessage);
                    trSendMessage.Start();
                    Thread.Sleep(150);
                }
                catch
                {
                    continue;
                }
            }
            MessageBox.Show("Đã tắt", "Quản lý phòng máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region kiểm tra và gửi file cho sinh viên
        /// <summary>
        /// Kiểm tra xem file cần gửi có đang được mở hay không???
        /// </summary>

        public bool IsFileUsedbyAnotherProcess(string fileName)
        {
            bool kt = false;
            try
            {
                FileStream fs1 = new FileStream(txtFile.Text, FileMode.Open, FileAccess.Read, FileShare.None);
                fs1.Close();
            }
            catch
            {

                kt = true;
            }
            return kt;

        }
        /// <summary>
        /// Lấy về dung lượng của một file;
        /// </summary>
        /// <param name="parth"></param>
        /// <returns></returns>
        long size = 0;
        void FileSize(string parth)
        {
            try
            {
                string fileName = parth;
                FileInfo f2 = new FileInfo(fileName);
                size = f2.Length;
            }
            catch
            {
                MessageBox.Show("Đường dẫn không đúng", "Quản lý phòng máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Tìm file cần gửi sau đó gửi dữ liệu tới máy sinh viên đã được chọn
        /// </summary>
        string FileName;
        private void btnSend_Click(object sender, EventArgs e)
        {
            int count = 50, i = 0, j = 0, k = 0;
            ct.GetIPhongMay(ref k, ref j);  // lấy địa chỉ IP của phòng máy
            DataTable dt = new DataTable();
            dt = ct.GetIPhongMayonLAN(k, j);    // chỉ lấy những máy đang bật ạ
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có máy nào được bật", "thông báo");
                return;
            }
            onPC.Text = "PC on: " + dt.Rows.Count.ToString();
            prgFile.Maximum = count;
            prgFile.Minimum = 0;
            prgFile.Value = 0;
            //openFileDialog1.ShowDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog1.FileName;
                FileInfo TheFile = new FileInfo(txtFile.Text); // Get The File Name
                FileName = TheFile.Name;
                FileSize(txtFile.Text);
                if (size > 0)
                {
                    if (count > 0)
                    {
                        if (size <= 100000000)
                        {
                            if (IsFileUsedbyAnotherProcess(txtFile.Text) == false)
                            {
                                for (i = 0; i < dt.Rows.Count; i++)
                                {
                                    try
                                    {
                                        FileStream fs = new FileStream(txtFile.Text, FileMode.Open);
                                        byte[] buffer = new byte[fs.Length];
                                        int len = (int)fs.Length;
                                        fs.Read(buffer, 0, len);
                                        fs.Close();
                                        BinaryFormatter br = new BinaryFormatter();
                                        TcpClient myclient = new TcpClient(dt.Rows[i]["IP"].ToString().Trim(), 3047);   //  "10.0.0." + i.ToString()    
                                        NetworkStream myns = myclient.GetStream();
                                        br.Serialize(myns, FileName);
                                        BinaryWriter mysw = new BinaryWriter(myns);
                                        mysw.Write(buffer);
                                        mysw.Close();
                                        myns.Close();
                                        myclient.Close();
                                    }
                                    catch
                                    {
                                        continue; // nếu gặp lỗi gì thì vẫn chạy tiếp
                                    }
                                    prgFile.Value++;
                                }
                            }
                            else
                            {
                                MessageBox.Show("File bạn cần gửi đang được mở bởi một chương trình khác", "Quản lý phòng máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Quá dung lượng cho phép (100Mb)", "Quản lý phòng máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa chọn sinh viên nào để gửi", "Quản lý phòng máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        #endregion
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (notifyIcon1.BalloonTipText == "Bạn vừa nhận được một file dữ liệu từ sinh viên")
            {
                Process.Start(@"e:\PTMS\DuLieu\");
            }
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            if (notifyIcon1.BalloonTipText == "Bạn vừa nhận được một file dữ liệu từ sinh viên")
            {
                Process.Start(@"e:\PTMS\DuLieu\");
            }
        }

        /// <summary>
        /// Luôn cập nhật từ server xem có sinh viên nào kết nối đến;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //lắng nghe yêu cầu gửi tài liệu
            myth = new Thread(new System.Threading.ThreadStart(File_Receiver)); // Start Thread Session
            myth.Start();
            //Lắng nghe yêu cầu chat
            trlisten = new Thread(ListenToServer);
            trlisten.Start();
            timer1.Enabled = false;
            timer1.Dispose();
        }

        private void tsmiShow_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void tsmiStopTeach_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            timer2.Dispose();
            StopListen();
        }

        private void Exit_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }       

        private void tsmiRunWithWin_Click(object sender, EventArgs e)
        {
            // https://nosomovo.xyz/2017/09/26/khoi-dong-ung-dung-cung-windows-trong-c/
            My_app_key.SetValue("Teacher.exe", "\"" + Application.ExecutablePath.ToString() + "\"");   // khởi động cùng win

        }
        private void TeachShow_Click(object sender, EventArgs e)
        {
            Stop.Enabled = true;
            timer2.Start();
            startListen();
            tsmiStopTeach.Text = "Ngừng giảng";
            notifyIcon1.BalloonTipText = "Hệ thống đã mở chức năng giảng bài";
            notifyIcon1.BalloonTipTitle = "PTMS Teacher ";
            //notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ShowBalloonTip(1000);
            this.WindowState = FormWindowState.Minimized;
            BtnDone.Enabled = false;
        }
        private void tsmiStopTeach_CheckedChanged(object sender, EventArgs e)
        {
            if (tsmiStopTeach.Checked == true && tsmiStopTeach.Text == "Ngừng giảng")
            {
                timer2.Enabled = false;
                timer2.Dispose();
                notifyIcon1.BalloonTipText = "Hệ thống đã tắt chế độ giảng bài!";
                notifyIcon1.BalloonTipTitle = "PTMS Teacher";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.ShowBalloonTip(1000);
                tsmiStopTeach.Checked = false;
                StopListen();
                tsmiStopTeach.Text = "Giảng bài";
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                if (tsmiStopTeach.Checked == true && tsmiStopTeach.Text == "Giảng bài")
                {

                    notifyIcon1.BalloonTipText = "Hệ thống đã mở chức năng giảng bài!";
                    notifyIcon1.BalloonTipTitle = "PTMS";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.ShowBalloonTip(1000);
                    tsmiStopTeach.Checked = false;
                    tsmiStopTeach.Text = "Ngừng giảng";
                    timer2.Start();
                    startListen();
                    this.WindowState = FormWindowState.Minimized;
                }
            }
        }

        /*
         * là chạy thử tính năng có nhiều dòng chú thích
         * xem nó như thế nào thôi mà
         * cũng được nhiều dòng
         */
        private void btnChatClient_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chờ tín hiệu máy con gửi tin nhắn đến", "Thông báo");
            return;
        }
        /// <summary>
        /// timer3 luôn chạy để lắng nghe chát từ sinh viên,
        /// nếu có chát thì mới hiện form lên ạ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (Program.iPClient != "")
            {
                Program.loadForm = false;
                frmClient a = new frmClient();
                a.Show();
            }
        }
        private void btnListPC_Click(object sender, EventArgs e)
        {
            frmSubnet a = new frmSubnet();
            a.Show();
        }
    }
}
