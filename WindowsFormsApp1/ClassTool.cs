using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using System.IO;
//using DevExpress.XtraEditors;
using System.Management;
using System.Net.Sockets;
using System.Data;
using System.Net.NetworkInformation;

namespace Lecture
{
    class Tool
    {

        #region Hiển thị các Form trong MdiChildren
        //static frmDepartment frmDepart = null;
        //static frmSubject frmSubject = null;
        //static frmWatchScreen frmWatchScreen = null;
        //static frmGroupStudent frmGroupStudent = null;
        //static frmSesionPractice frmSession = null;
        //static frmStudentPractic_ frmStudent = null;
        //public void ShowFormStudent()
        //{

        //    if (frmStudent == null || frmStudent.IsDisposed)
        //    {
        //        frmStudent = new frmStudentPractic_();
        //        frmStudent.MdiParent = devMain.ActiveForm;
        //        frmStudent.WindowState = FormWindowState.Maximized;
        //        frmStudent.Show();
        //        frmStudent.Focus();
        //    }
        //    else
        //    {
        //        frmStudent.Activate();
        //        frmStudent.Focus();
        //    }

        //}
        //public void ShowFormSession()
        //{

        //    if (frmSession == null || frmSession.IsDisposed)
        //    {
        //        frmSession = new frmSesionPractice();
        //        frmSession.MdiParent = devMain.ActiveForm;
        //        frmSession.WindowState = FormWindowState.Maximized;
        //        frmSession.Show();
        //        frmSession.Focus();
        //    }
        //    else
        //    {
        //        frmSession.Activate();
        //        frmSession.Focus();
        //    }

        //}
        //public void ShowFormDepart()
        //{

        //    if (frmDepart == null || frmDepart.IsDisposed)
        //    {
        //        frmDepart = new frmDepartment();
        //        frmDepart.MdiParent = devMain.ActiveForm;
        //        frmDepart.WindowState = FormWindowState.Maximized;
        //        frmDepart.Show();
        //        frmDepart.Focus();
        //    }
        //    else
        //    {
        //        frmDepart.Activate();
        //        frmDepart.Focus();
        //    }

        //}
        //public void ShowFormGroupStudent()
        //{

        //    if (frmGroupStudent == null || frmGroupStudent.IsDisposed)
        //    {
        //        frmGroupStudent = new frmGroupStudent();
        //        frmGroupStudent.MdiParent = devMain.ActiveForm;
        //        frmGroupStudent.WindowState = FormWindowState.Maximized;
        //        frmGroupStudent.Show();
        //        frmGroupStudent.Focus();
        //    }
        //    else
        //    {
        //        frmGroupStudent.Activate();
        //        frmGroupStudent.Focus();
        //    }

        //}
        //public void ShowFormSubject()
        //{

        //    if (frmSubject == null || frmSubject.IsDisposed)
        //    {
        //        frmSubject = new frmSubject();
        //        frmSubject.MdiParent = devMain.ActiveForm;
        //        frmSubject.WindowState = FormWindowState.Maximized;
        //        frmSubject.Show();
        //        frmSubject.Focus();
        //    }
        //    else
        //        frmSubject.Activate();

        //}
        //public void ShowFormWatchScreen()
        //{

        //    if (frmWatchScreen== null || frmWatchScreen.IsDisposed)
        //    {
        //        frmWatchScreen = new frmWatchScreen();
        //        frmWatchScreen.MdiParent = devMain.ActiveForm;
        //        frmWatchScreen.WindowState = FormWindowState.Maximized;
        //        frmWatchScreen.Show();
        //        frmWatchScreen.Focus();
        //    }
        //    else
        //        frmWatchScreen.Activate();

        //}
        public void ShowFormClass()
        {
            //if (frmClass == null || frmClass.IsDisposed)
            //{
            //    frmClass = new frmClass();
            //    frmClass.MdiParent = devMain.ActiveForm;
            //    frmClass.WindowState = FormWindowState.Maximized;
            //    frmClass.Show();
            //    frmClass.Focus();
            //}
            //else
            //    frmSubject.Activate();
        }
        #endregion

        /// <summary>
        /// lấy ra Work group của máy tính
        /// </summary>
        /// <returns></returns>
        public string GetworkgroupPC()
        {
            string Gr = "";
            // Getting information about worke group of computer
            ManagementObjectSearcher mosComputer = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            foreach (ManagementObject moComputer in mosComputer.Get())
            {
                if (moComputer["Workgroup"] != null)
                    //MessageBox.Show(moComputer["Workgroup"].ToString());
                    Gr = moComputer["Workgroup"].ToString();
            }
            return Gr;
        }

        // https://stackoverflow.com/questions/6803073/get-local-ip-address
        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public void GetIPhongMay(ref int j, ref int l)
        {
            string pGV = GetLocalIPAddress().Trim();
            if (pGV == "10.0.0.160")   // P604
            {
                j = 161; l = 198;
            }
            else if (pGV == "10.0.0.120")   //P603
            {
                j = 121; l = 156;
            }
            else if (pGV == "10.0.0.70")   //P602
            {
                j = 71; l = 119;
            }
            else if (pGV == "10.0.0.9")  //P601
            {
                j = 11; l = 59;
            }
            else
                return;
        }

        public DataTable GetIPhongMayonLAN(int k, int j)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IP", typeof(string));
            dt.Columns.Add("ComputerNumber", typeof(string));
            Ping p = new Ping();
            PingReply r;
            string s;
            for (int i = k; i < j; i++)
            {
                s = "10.0.0." + i.ToString();
                r = p.Send(s, 500);
                if (r.Status == IPStatus.Success)
                {
                    DataRow _ravi = dt.NewRow();
                    _ravi["IP"] = "10.0.0." + i.ToString().Trim();
                    _ravi["ComputerNumber"] = "MÁY: " + i.ToString().Trim();
                    dt.Rows.Add(_ravi);
                }
            }
            return dt;
        }

        // https://www.youtube.com/watch?v=WCC_JwL3ovw&feature=share
        public DataTable scan(string subnet, int ipS, int ipE)   //  string ipS, string ipE
        {
            Ping myPing;
            PingReply reply;
            IPAddress addr;
            IPHostEntry host;

            DataTable dt = new DataTable();
            dt.Columns.Add("IP");
            dt.Columns.Add("ComputerNumber");

            //progressBar1.Maximum = 254;
            //progressBar1.Value = 0;
            //listVAddr.Items.Clear();

            for (int i = ipS; i < ipE; i++)   //  (int i = 1; i < 255; i++)
            {
                string subnetn = "." + i.ToString();
                myPing = new Ping();
                reply = myPing.Send(subnet + subnetn, 500);  //  900

                //lblStatus.ForeColor = System.Drawing.Color.Green;
                //lblStatus.Text = "Scanning: " + subnet + subnetn;

                if (reply.Status == IPStatus.Success)
                {
                    try
                    {
                        addr = IPAddress.Parse(subnet + subnetn);
                        host = Dns.GetHostEntry(addr);

                        //listVAddr.Items.Add(new ListViewItem(new String[] { subnet + subnetn, host.HostName, "Up" }));

                        DataRow _ravi = dt.NewRow();
                        _ravi["IP"] = subnet + subnetn;
                        _ravi["ComputerNumber"] = host.HostName.ToString();
                        dt.Rows.Add(_ravi);
                    }
                    catch
                    {
                        MessageBox.Show("Couldnt retrieve hostname for " + subnet + subnetn, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //progressBar1.Value += 1;
            }
            //cmdScan.Enabled = true;
            //cmdStop.Enabled = false;
            //txtIP.Enabled = true;
            //lblStatus.Text = "Done!";
            //int count = listVAddr.Items.Count;
            //MessageBox.Show("Scanning done!\nFound " + count.ToString() + " hosts.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //MessageBox.Show("Scanning done: " + dt.Rows.Count.ToString() + " PC");
            return dt;
        }
        /// <summary>
        /// Kiểm tra sinh viên đã tồn tại trong nhóm
        /// </summary>
        /// <returns></returns>
        //public bool TestIsAvailable(string name,List<string> lst,string number)
        //{
        //    bool kt = false;
        //    foreach (string item in lst)
        //    {
        //        if (item == name || item==number) { kt = true; }
        //    }
        //    return kt;
        //}
        public void AppendText(RichTextBox box, string text, Color color, string font, float size, ToolStripButton B, ToolStripButton I, ToolStripButton U)
        {

            int start = box.TextLength;
            box.AppendText(text);
            int end = box.TextLength;

            // Textbox may transform chars, so (end-start) != text.Length
            box.Select(start, end - start);
            {


                box.SelectionFont = new Font(font, size, KieuFont(B, I, U));
                box.SelectionColor = color;
                // could set box.SelectionBackColor, box.SelectionFont too.
            }
            box.SelectionLength = 0; // clea
        }
        /// <summary>
        /// Trả lại trạng thái rỗng của các điều khiển
        /// </summary>

        //public bool CheckEmptyTxt1(TextEdit txt, string report, ErrorProvider err)
        //{
        //    //Trả lại gia tri false neu o Text co du lieu
        //    if (txt.Text == "")
        //    {
        //        txt.Focus();
        //        err.SetError(txt, report);
        //        return true;
        //    }
        //    else return false;
        //}
        //public bool CheckLookupEdit(LookUpEdit txt, string report, ErrorProvider err)
        //{
        //    //Trả lại gia tri false neu o Text co du lieu
        //    if (txt.Text == "")
        //    {
        //        txt.Focus();
        //        err.SetError(txt, report);
        //        return true;
        //    }
        //    else return false;
        //}
        //public bool CheckEmptyCbo(ComboBoxEdit com, string report, ErrorProvider err)
        //{
        //    if (com.Text == "")
        //    {
        //        err.SetError(com, report);
        //        com.Focus();
        //        return true;
        //    }
        //    else return false;
        //}
        //public bool CheckEmptyDateEdit(DateEdit dtp, string report, ErrorProvider err)
        //{
        //    if (dtp.Text == "")
        //    {
        //        err.SetError(dtp, report);
        //        dtp.Focus();
        //        return true;
        //    }
        //    else
        //        return false;
        //}
        /// <summary>
        /// Chuẩn xâu họ tên (viết hoa ,giãn cách giữa các chữ)
        /// </summary>
        /// <param name="xau"></param>
        /// <returns></returns>
        public string StandardStringName(string xau)
        {
            if (xau != "")
            {
                StringBuilder s = new StringBuilder(xau.Trim());
                while (s.ToString().IndexOf("  ") >= 0)
                {
                    s.Replace("  ", " ");
                }
                s[0] = s[0].ToString().ToUpper()[0];
                for (int i = 1; i < s.Length; i++)
                {
                    if ((s[i - 1] == ' ') && (s[i] != ' '))
                    {
                        s[i] = s[i].ToString().ToUpper()[0];
                    }
                    else
                        s[i] = s[i].ToString().ToLower()[0];
                }
                return s.ToString();
            }
            else
                return "";
        }

        /// <summary>
        /// Chuẩn xâu thường (viết hoa chữ đầu dòng ,giãn cách giữa các chữ)
        /// </summary>
        /// <param name="xau"></param>
        /// <returns></returns>
        public string StandardStringNormal(string xau)
        {
            //if (xau != "")
            //{
            //    StringBuilder s = new StringBuilder(xau.Trim());
            //    while (s.ToString().IndexOf("  ") >= 0)
            //    {
            //        s.Replace("  ", " ");
            //    }
            //    s[0] = s[0].ToString().ToUpper()[0];
            //    for (int i = 1; i < s.Length; i++)
            //    {
            //        s[i] = s[i].ToString().ToLower()[0];
            //    }
            //    return s.ToString();
            //}
            //else
            return "";
        }

        public FontStyle KieuFont(ToolStripButton ttbB, ToolStripButton ttbI, ToolStripButton ttbU)
        {


            FontStyle item = new FontStyle();
            if (ttbB.Checked)
            {
                item = item | FontStyle.Bold;
            }
            if (ttbU.Checked)
            {
                item = item | FontStyle.Underline;
            }
            if (ttbI.Checked)
            {
                item = item | FontStyle.Italic;
            }
            return item;
        }
        #region Gửi file


        FileStream fs1;
        public bool IsFileUsedbyAnotherProcess(string fileName)
        {
            bool kt = false;

            try
            {
                fs1 = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch
            {

                kt = true;
            }
            fs1.Close();
            return kt;

        }
        /// <summary>
        /// Lấy về dung lượng của một file;
        /// </summary>
        /// <param name="parth"></param>
        /// <returns></returns>
        public long size = 0;
        public void FileSize(string parth)
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
        #endregion
    }
}
