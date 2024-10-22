using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using System.Configuration;


namespace QLPhongMachTu_DOAN_.DAL
{
    public class DatabaseConnection
    {
        // Chuỗi kết nối sử dụng Windows Authentication
        private string connectionString = "Data Source=DESKTOP-C805L15\\SQLEXPRESS;Initial Catalog=dbQLPKT;Integrated Security=True";

        // Mở kết nối
        public SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        // Kiểm tra kết nối cơ sở dữ liệu
        public bool CheckConnection()
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();  // Mở kết nối
                    return true;  // Nếu kết nối thành công
                }
                catch (Exception)
                {
                    return false;  // Nếu có lỗi xảy ra
                }
            }
        }
    }

}




