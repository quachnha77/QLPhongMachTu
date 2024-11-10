using QLPhongMachTu_DOAN_.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using QLPhongMachTu_DOAN_.DAL;

namespace QLPhongMachTu_DOAN_
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new NavbarBacSi());


            using (DatabaseHelper db = new DatabaseHelper())
            {
                bool isConnected = db.TestConnection();
                if (isConnected)
                {
                    MessageBox.Show("Kết nối đến cơ sở dữ liệu thành công!");
                }
                else
                {
                    MessageBox.Show("Kết nối đến cơ sở dữ liệu thất bại.");
                }
            }


        }
    }
}
