using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lecture
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static bool loadForm = false;
        public static string iPClient = "";
        public static string FullNameStudent = "";
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
