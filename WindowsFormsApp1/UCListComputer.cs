using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;
namespace Lecture
{
    public partial class UCListComputer : UserControl
    {
        public UCListComputer()
        {
            InitializeComponent();
        }
        List<string> ListIPUpdate = new List<string>();
        public static bool ReloadScreen = false;

        // http://dotnet.edu.vn/ChuyenMuc/Bang-cach-nao-de-them-cot-va-hang-trong-DataTable-de-hien-thi-tren-Gridview-846.aspx
        //Creating new instance of DataTable
        DataTable dt = new DataTable();
        private void UCListComputer_Load(object sender, EventArgs e)
        {
            ////Adding columns to datatable
            //dt.Columns.Add("IP", typeof(string));
            //dt.Columns.Add("ComputerNumber", typeof(string));
            ////Adding Dummy data to datatable
            //for (int k = 0; k < 1; k++)
            //{
            //    DataRow row;
            //    row = dt.NewRow();
            //    row["IP"] = "172.169.1.117";
            //    row["ComputerNumber"] = "01";
            //    dt.Rows.Add(row);
            //}

            dt = FrmWatchScreenStudent.dtScan;   //  13/05/2019 gán bảng dt IP từ FrmWatchScreenStudent

            #region chỉnh sửa giao diện
            int i = 30;
            int sl = 0;                       
            for (int j = 0; j < 1; j++)
            {
                sl++;
            }

            if (i <= 6)
            {
                tlpListComputer.ColumnCount = i;
                tlpListComputer.RowCount = 1;

                for (int j = 0; j < 6; j++)
                {
                    tlpListComputer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                }
                tlpListComputer.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            }
            else
            {
                tlpListComputer.ColumnCount = 6;
                tlpListComputer.RowCount = i / 6;
                for (int k = 0; k < 8; k++)
                {
                    tlpListComputer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                }
                for (int l = 0; l < tlpListComputer.RowCount; l++)
                {
                    tlpListComputer.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                }
            }
            #endregion
            #region load màn hình sinh viên

            foreach (DataRow row in dt.Rows)
            {
                //Nếu máy đã có học sinh ngồi 

                //Lấy ra tên học sinh ngồi máy
                UCScreenCapture uc = new UCScreenCapture();
                if (row["IP"].ToString() != "0.0.0.0") //&&TestIPInSesspace(q.ComputerIP))
                {
                    uc.ComputerNumber = "Máy " + row["ComputerNumber"].ToString() + " UCListComputer";
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

        private void tlpListComputer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = true;
        }

        private void UpdateIP_Tick(object sender, EventArgs e)
        {
            if (ReloadScreen)
            {
                ReloadScreen = false;
                #region Load lại màn hình sinh viên

                tlpListComputer.Controls.Clear();

                foreach (DataRow row in dt.Rows)
                {                    
                    //Lấy ra tên học sinh ngồi máy
                    UCScreenCapture uc = new UCScreenCapture();
                    if (row["IP"].ToString() != "0.0.0.0") 
                    {
                        uc.ComputerNumber = "Máy " + row["ComputerNumber"].ToString() + " UCListComputer";
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

            foreach (DataRow row in dt.Rows)
            {
                ListIPUpdate.Add(row["ComputerNumber"].ToString() + "," + row["IP"].ToString());
            }

            foreach (UCScreenCapture a in tlpListComputer.Controls)
            {
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
