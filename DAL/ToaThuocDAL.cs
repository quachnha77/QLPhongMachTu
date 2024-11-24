using System;
using System.Collections.Generic;
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
        public List<ToaThuocDTO> GetAll()
        {
            List<ToaThuocDTO> toaThuocList = new List<ToaThuocDTO>();
            string query = "SELECT * FROM ToaThuocs";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ToaThuocDTO toaThuoc = new ToaThuocDTO
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
        public ToaThuocDTO GetToaThuocById(long maTT)
        {
            ToaThuocDTO toaThuoc = null;
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
                        toaThuoc = new ToaThuocDTO
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

        // Lấy danh sách các dịch vụ theo mã Bệnh nhân
        public List<ToaThuocDTO> GetByMaBN(long maBN)
        {
            List<ToaThuocDTO> toaThuocList = new List<ToaThuocDTO>();
            string query = "SELECT * FROM ToaThuocs WHERE MaBN = @MaBN";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaBN", maBN);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ToaThuocDTO toaThuoc = new ToaThuocDTO
                        {
                            MaTT = reader["MaTT"] != DBNull.Value ? Convert.ToInt64(reader["MaTT"]) : 0,
                            MaBN = reader["MaBN"] != DBNull.Value ? Convert.ToInt64(reader["MaBN"]) : 0,
                            MaBS = reader["MaBS"] != DBNull.Value ? Convert.ToInt64(reader["MaBS"]) : 0,
                            MaLK = reader["MaLK"] != DBNull.Value ? Convert.ToInt64(reader["MaLK"]) : 0,
                            MaPK = reader["MaPK"] != DBNull.Value ? Convert.ToInt64(reader["MaPK"]) : 0,
                            NgayKeToa = reader["NgayKeToa"] != DBNull.Value ? Convert.ToDateTime(reader["NgayKeToa"]) : DateTime.MinValue,
                            LoiDanBacSi = reader["LoiDanBacSi"] != DBNull.Value ? reader["LoiDanBacSi"].ToString() : string.Empty,
                            TongTienThuoc = reader["TongTienThuoc"] != DBNull.Value ? Convert.ToDouble(reader["TongTienThuoc"]) : 0
                        };
                        toaThuocList.Add(toaThuoc);
                    }
                }
            }

            return toaThuocList;
        }

        public ToaThuocDTO GetByMaPK(long maPK)
        {
            ToaThuocDTO toaThuoc = null; // Khởi tạo biến null để kiểm tra sau
            string query = "SELECT * FROM ToaThuocs WHERE MaPK = @MaPK";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaPK", maPK);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read()) // Kiểm tra có dữ liệu trả về hay không
                    {
                        toaThuoc = new ToaThuocDTO
                        {
                            MaTT = reader["MaTT"] != DBNull.Value ? Convert.ToInt64(reader["MaTT"]) : 0,
                            MaBN = reader["MaBN"] != DBNull.Value ? Convert.ToInt64(reader["MaBN"]) : 0,
                            MaBS = reader["MaBS"] != DBNull.Value ? Convert.ToInt64(reader["MaBS"]) : 0,
                            MaLK = reader["MaLK"] != DBNull.Value ? Convert.ToInt64(reader["MaLK"]) : 0,
                            MaPK = reader["MaPK"] != DBNull.Value ? Convert.ToInt64(reader["MaPK"]) : 0,
                            NgayKeToa = reader["NgayKeToa"] != DBNull.Value ? Convert.ToDateTime(reader["NgayKeToa"]) : DateTime.MinValue,
                            LoiDanBacSi = reader["LoiDanBacSi"] != DBNull.Value ? reader["LoiDanBacSi"].ToString() : string.Empty,
                            TongTienThuoc = reader["TongTienThuoc"] != DBNull.Value ? Convert.ToDouble(reader["TongTienThuoc"]) : 0
                        };
                    }
                }
            }

            return toaThuoc; // Trả về null nếu không tìm thấy dữ liệu
        }


        // Thêm toa thuốc
        public long AddToaThuoc(ToaThuocDTO toaThuoc)
        {
            string query = "INSERT INTO ToaThuocs (MaBN, MaBS, MaLK, MaPK, NgayKeToa, LoiDanBacSi, TongTienThuoc) " +
                           "OUTPUT INSERTED.MaTT " +
                           "VALUES (@MaBN, @MaBS, @MaLK, @MaPK, @NgayKeToa, @LoiDanBacSi, @TongTienThuoc)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaBN", toaThuoc.MaBN);
                command.Parameters.AddWithValue("@MaBS", toaThuoc.MaBS);
                command.Parameters.AddWithValue("@MaLK", toaThuoc.MaLK);
                command.Parameters.AddWithValue("@MaPK", toaThuoc.MaPK);
                command.Parameters.AddWithValue("@NgayKeToa", toaThuoc.NgayKeToa);
                command.Parameters.AddWithValue("@LoiDanBacSi", toaThuoc.LoiDanBacSi ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@TongTienThuoc", toaThuoc.TongTienThuoc);

                connection.Open();
                // Trả về MaTT (ID) vừa được thêm
                return (long)command.ExecuteScalar();
            }
        }



        // Cập nhật toa thuốc
        public bool UpdateToaThuoc(ToaThuocDTO toaThuoc)
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
