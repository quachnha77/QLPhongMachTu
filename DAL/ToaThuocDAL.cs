using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DTO;

namespace DAL
{
    public class ToaThuocDAL
    {
        private readonly string _connectionString;

        public ToaThuocDAL()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            _connectionString = configuration.GetConnectionString("MyDatabase");
        }

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
                return command.ExecuteNonQuery() > 0;
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
                return command.ExecuteNonQuery() > 0;

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

        // Cập nhật trạng thái toa thuốc
        public bool UpdateTrangThaiToaThuoc(long maToaThuoc, string trangThai)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE ToaThuocs SET TrangThai = 'Đã phát' WHERE MaTT = @MaTT";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaTT", maToaThuoc);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // Cập nhật thanh toán bệnh nhân
        public bool UpdateThanhToanBenhNhan(long maBenhNhan, decimal tongTien)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE ToaThuocs SET TrangThai = 'Đã thanh toán', TongTien = @TongTien WHERE MaBN = @MaBN";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaBN", maBenhNhan);
                    command.Parameters.AddWithValue("@TongTien", tongTien);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // Lấy toa thuốc theo mã
        public List<ToaThuoc> SearchToaThuoc(string keyword)
        {
            List<ToaThuoc> toaThuocList = new List<ToaThuoc>();
            string query = "SELECT * FROM ToaThuocs WHERE MaTT LIKE @Keyword OR MaBN LIKE @Keyword OR MaBS LIKE @Keyword";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%"); // Tìm kiếm theo từ khóa (sử dụng dấu % cho LIKE)
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
        public ToaThuoc GetToaThuocById(long maToa)
        {
            ToaThuoc toaThuoc = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM ToaThuoc WHERE MaTT = @MaTT";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaTT", maToa);

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
            }

            return toaThuoc;
        }

    }
}
