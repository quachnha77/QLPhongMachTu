using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class DichVuDAL
    {
        private readonly string _connectionString;

        public DichVuDAL()
        {
            // Lấy chuỗi kết nối từ app.config
            _connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        }

        // Phương thức để lấy đơn giá dịch vụ theo mã dịch vụ
        public double LayDonGiaDichVu(long maDV)
        {
            double donGia = 0;
            string query = "SELECT DonGia FROM DichVus WHERE MaDV = @MaDV";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaDV", maDV);
                connection.Open();

                // Sử dụng SqlDataReader để lấy kết quả từ truy vấn
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        donGia = Convert.ToDouble(reader["DonGia"]);
                    }
                }
            }

            return donGia; // Trả về đơn giá hoặc 0 nếu không tìm thấy dịch vụ
        }
    }
}
