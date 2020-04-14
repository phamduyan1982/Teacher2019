using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lecture
{
    public partial class FrmWatchScreenStudent : Form
    {
        Tool ct = new Tool();
        public FrmWatchScreenStudent()
        {
            InitializeComponent();
        }
        List<string> ListIPUpdate = new List<string>();
        public static bool ReloadScreen = false;
        //Load số cột và hàng
        void LoadtblLayout()
        {
            tlpListComputer.ColumnCount = 7;
            tlpListComputer.RowCount = 5;
            for (int k = 0; k < 7; k++)
            {
                tlpListComputer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            }
            for (int l = 0; l < tlpListComputer.RowCount; l++)
            {
                tlpListComputer.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            }
        }

        // http://dotnet.edu.vn/ChuyenMuc/Bang-cach-nao-de-them-cot-va-hang-trong-DataTable-de-hien-thi-tren-Gridview-846.aspx
        //Creating new instance of DataTable
        public static DataTable dtScan = new DataTable();
        private void FrmWatchScreenStudent_Load(object sender, EventArgs e)
        {            
            int k = 0, j = 0;
            ct.GetIPhongMay(ref k, ref j);  // lấy ra danh sách IP của phòng máy
            dtScan = ct.scan("10.0.0", k, j); // ct.GetIPhongMayonLAN(k, j);    // lọc ra những máy nào đang bật mới nạp vào dt mà thôi
            if (dtScan.Rows.Count == 0)
            {
                MessageBox.Show("Không có máy nào được bật", "thông báo");
                return;
            }            
            LoadtblLayout();

            #region load màn hình sinh viên
            foreach (DataRow row in dtScan.Rows)
            {                
                //Lấy ra tên học sinh ngồi máy
                UCScreenCapture uc = new UCScreenCapture();
                if (row["IP"].ToString() != "0.0.0.0")
                {
                    uc.ComputerNumber = "Máy " + row["ComputerNumber"].ToString();
                    uc.GetIP = row["IP"].ToString();
                }
                else
                {
                    uc.ComputerNumber = "Máy " + row["ComputerNumber"].ToString();
                    uc.GetIP = "0.0.0.0";
                }
                tlpListComputer.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.Start();

            }
            # endregion
        }

        private void UpdateIP_Tick(object sender, EventArgs e)
        {
            if (ReloadScreen)
            {
                ReloadScreen = false;
                #region Load lại màn hình sinh viên

                tlpListComputer.Controls.Clear();

                foreach (DataRow row in dtScan.Rows)
                {                    
                    //Lấy ra tên học sinh ngồi máy
                    UCScreenCapture uc = new UCScreenCapture();
                    if (row["IP"].ToString() != "0.0.0.0")// && TestIPInSesspace(q.ComputerIP))
                    {
                        uc.ComputerNumber = "Máy " + row["ComputerNumber"].ToString();
                        uc.GetIP = row["IP"].ToString();
                    }
                    else
                    {
                        uc.ComputerNumber = "Máy " + row["ComputerNumber"].ToString();
                        uc.GetIP = "0.0.0.0";
                    }
                    tlpListComputer.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                    uc.Start();

                }
                #endregion
            }
            ListIPUpdate.Clear();

            foreach (DataRow row in dtScan.Rows)
            {
                ListIPUpdate.Add(row["ComputerNumber"].ToString() + "," + row["IP"].ToString());
            }
            foreach (UCScreenCapture a in tlpListComputer.Controls)
            {
                //MessageBox.Show(a.ComputerNumber);
                foreach (string item in ListIPUpdate)
                {
                    if (a.ComputerNumber.Trim().ToLower() == "máy ".ToLower() + item.Split(',')[0].Trim().ToLower() && a.GetIP.Trim().ToLower() != item.Split(',')[1].Trim().ToLower() && item.Split(',')[1].Trim().ToLower() != "0.0.0.0".ToLower())
                    {
                        a.GetIP = item.Split(',')[1].Trim();
                        a.Start();
                    }
                    else
                    {
                        if (a.ComputerNumber.Trim().ToLower() == "Máy ".ToLower() + item.Split(',')[0].Trim().ToLower() && a.GetIP.Trim().ToLower() != item.Split(',')[1].Trim().ToLower() && item.Split(',')[1].Trim().ToLower() == "0.0.0.0".ToLower())
                        {

                            a.GetIP = "0.0.0.0";
                            a.ResetPicture();
                            a.Start();

                        }
                    }
                }

            }
        }
    }
}
