using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.DAL
{
    internal class PhieuKhamDAL
    {
        private readonly string _connectionString;

        public PhieuKhamDAL()
        {
            // Lấy chuỗi kết nối từ app.config
            _connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        }

        // Phương thức để lấy tất cả các phiếu khám
        public List<PhieuKham> GetAll()
        {
            List<PhieuKham> phieuKhamList = new List<PhieuKham>();
            string query = "SELECT * FROM PhieuKhams";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PhieuKham phieuKham = new PhieuKham
                        {
                            MaPK = Convert.ToInt64(reader["MaPK"]),
                            MaLK = Convert.ToInt64(reader["MaLK"]),
                            MaBN = Convert.ToInt64(reader["MaBN"]),
                            MaBS = Convert.ToInt64(reader["MaBS"]),
                            NgayKham = Convert.ToDateTime(reader["NgayKham"]),
                            SoThuTu = Convert.ToInt32(reader["SoThuTu"]),
                            TrieuChung = reader["TrieuChung"].ToString(),
                            TieuSuBenhLy = reader["TieuSuBenhLy"].ToString(),
                            ChuanDoan = reader["ChuanDoan"].ToString(),
                            LoiDanBacSi = reader["LoiDanBacSi"]?.ToString() // Lấy dữ liệu từ cột mới
                        };
                        phieuKhamList.Add(phieuKham);
                    }
                }
            }

            return phieuKhamList;
        }

        // Phương thức để lấy phiếu khám theo mã lịch khám (MaLK)
        public PhieuKham GetByMaLK(long maLK)
        {
            PhieuKham phieuKham = null;
            string query = "SELECT * FROM PhieuKhams WHERE MaLK = @MaLK";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaLK", maLK);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        phieuKham = new PhieuKham
                        {
                            MaPK = Convert.ToInt64(reader["MaPK"]),
                            MaLK = Convert.ToInt64(reader["MaLK"]),
                            MaBN = Convert.ToInt64(reader["MaBN"]),
                            MaBS = Convert.ToInt64(reader["MaBS"]),
                            NgayKham = Convert.ToDateTime(reader["NgayKham"]),
                            SoThuTu = Convert.ToInt32(reader["SoThuTu"]),
                            TrieuChung = reader["TrieuChung"].ToString(),
                            TieuSuBenhLy = reader["TieuSuBenhLy"].ToString(),
                            ChuanDoan = reader["ChuanDoan"].ToString(),
                            LoiDanBacSi = reader["LoiDanBacSi"]?.ToString() // Lấy dữ liệu từ cột mới
                        };
                    }
                }
            }

            return phieuKham;
        }

        public PhieuKham GetByMaBN(long maBN) {
            PhieuKham phieuKham = null;
            string query = "SELECT * FROM PhieuKhams WHERE MaBN = @MaBN";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaBN", maBN);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        phieuKham = new PhieuKham
                        {
                            MaPK = Convert.ToInt64(reader["MaPK"]),
                            MaLK = Convert.ToInt64(reader["MaLK"]),
                            MaBN = Convert.ToInt64(reader["MaBN"]),
                            MaBS = Convert.ToInt64(reader["MaBS"]),
                            NgayKham = Convert.ToDateTime(reader["NgayKham"]),
                            SoThuTu = Convert.ToInt32(reader["SoThuTu"]),
                            TrieuChung = reader["TrieuChung"].ToString(),
                            TieuSuBenhLy = reader["TieuSuBenhLy"].ToString(),
                            ChuanDoan = reader["ChuanDoan"].ToString(),
                            LoiDanBacSi = reader["LoiDanBacSi"]?.ToString()
                        };
                    }
                }
            }
            return phieuKham;
        }


        public bool UpdatePhieuKham(PhieuKham phieuKham)
        {
            string query = @"UPDATE PhieuKhams
                             SET TrieuChung = @TrieuChung, 
                                 TieuSuBenhLy = @TieuSuBenhLy, 
                                 ChuanDoan = @ChuanDoan, 
                                 LoiDanBacSi = @LoiDanBacSi 
                             WHERE MaPK = @MaPK";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TrieuChung", phieuKham.TrieuChung);
                command.Parameters.AddWithValue("@TieuSuBenhLy", phieuKham.TieuSuBenhLy);
                command.Parameters.AddWithValue("@ChuanDoan", phieuKham.ChuanDoan);
                command.Parameters.AddWithValue("@LoiDanBacSi", phieuKham.LoiDanBacSi ?? (object)DBNull.Value); // Null check
                command.Parameters.AddWithValue("@MaPK", phieuKham.MaPK);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0; // Trả về true nếu cập nhật thành công
            }
        }


    }
}
