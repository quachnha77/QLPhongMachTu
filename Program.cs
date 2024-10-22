using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //DatabaseConnection dbConnection = new DatabaseConnection();
            //bool isConnected = dbConnection.CheckConnection();

            //if (isConnected)
            //{
            //    Console.WriteLine("Kết nối cơ sở dữ liệu đã được kiểm tra và thành công.");
            //}
            //else
            //{
            //    Console.WriteLine("Không thể kết nối đến cơ sở dữ liệu.");
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NavbarDuocSi());




        }
    }
}
