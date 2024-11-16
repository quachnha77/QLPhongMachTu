using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.DAL
{
    internal class ToaThuocDAL
    {
        private readonly string _connectionString;

        public ToaThuocDAL()
        {
            // Lấy chuỗi kết nối từ file cấu hình
            _connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        }

        // Lấy tất cả các toa thuốc
        public List<ToaThuoc> GetAll()
        {
            List<ToaThuoc> toaThuocList = new List<ToaThuoc>();
            string query = "SELECT * FROM ToaThuocs";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ToaThuoc toaThuoc = new ToaThuoc
                        {
                            MaTT = Convert.ToInt64(reader["MaTT"]),
                            MaBN = Convert.ToInt64(reader["MaBN"]),
                            MaBS = Convert.ToInt64(reader["MaBS"]),
                            MaLK = Convert.ToInt64(reader["MaLK"]),
                            MaPK = Convert.ToInt64(reader["MaPK"]),
                            NgayKeToa = Convert.ToDateTime(reader["NgayKeToa"])
                        };
                        toaThuocList.Add(toaThuoc);
                    }
                }
            }

            return toaThuocList;
        }

        // Lấy toa thuốc theo mã
        public ToaThuoc GetToaThuocById(long maTT)
        {
            ToaThuoc toaThuoc = null;
            string query = "SELECT * FROM ToaThuocs WHERE MaTT = @MaTT";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaTT", maTT);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        toaThuoc = new ToaThuoc
                        {
                            MaTT = Convert.ToInt64(reader["MaTT"]),
                            MaBN = Convert.ToInt64(reader["MaBN"]),
                            MaBS = Convert.ToInt64(reader["MaBS"]),
                            MaLK = Convert.ToInt64(reader["MaLK"]),
                            MaPK = Convert.ToInt64(reader["MaPK"]),
                            NgayKeToa = Convert.ToDateTime(reader["NgayKeToa"])
                        };
                    }
                }
            }

            return toaThuoc;
        }

        // Thêm toa thuốc
        public bool AddToaThuoc(ToaThuoc toaThuoc)
        {
            string query = "INSERT INTO ToaThuocs (MaBN, MaBS, MaLK, MaPK, NgayKeToa) VALUES (@MaBN, @MaBS, @MaLK, @MaPK, @NgayKeToa)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaBN", toaThuoc.MaBN);
                command.Parameters.AddWithValue("@MaBS", toaThuoc.MaBS);
                command.Parameters.AddWithValue("@MaLK", toaThuoc.MaLK);
                command.Parameters.AddWithValue("@MaPK", toaThuoc.MaPK);
                command.Parameters.AddWithValue("@NgayKeToa", toaThuoc.NgayKeToa);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Cập nhật toa thuốc
        public bool UpdateToaThuoc(ToaThuoc toaThuoc)
        {
            string query = "UPDATE ToaThuocs SET MaBN = @MaBN, MaBS = @MaBS, MaLK = @MaLK, MaPK = @MaPK, NgayKeToa = @NgayKeToa WHERE MaTT = @MaTT";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaBN", toaThuoc.MaBN);
                command.Parameters.AddWithValue("@MaBS", toaThuoc.MaBS);
                command.Parameters.AddWithValue("@MaLK", toaThuoc.MaLK);
                command.Parameters.AddWithValue("@MaPK", toaThuoc.MaPK);
                command.Parameters.AddWithValue("@NgayKeToa", toaThuoc.NgayKeToa);
                command.Parameters.AddWithValue("@MaTT", toaThuoc.MaTT);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Xóa toa thuốc
        public bool DeleteToaThuoc(long maTT)
        {
            string query = "DELETE FROM ToaThuocs WHERE MaTT = @MaTT";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaTT", maTT);
                connection.Open();

                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }
    }
}
