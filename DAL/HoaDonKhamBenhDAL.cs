using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class HoaDonKhamBenhDAL : DatabaseHelper
    {
        // Quách Thanh Nhã
        private readonly string _connectionString;

        public HoaDonKhamBenhDAL()
        {
            // Lấy chuỗi kết nối từ file cấu hình
            _connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("Chuỗi kết nối không được cấu hình đúng hoặc bị thiếu.");
            }
        }

        public long AddHoaDonKhamBenh(HoaDonKhamBenhDTO hoaDon)
        {
            string query = "INSERT INTO HoaDonKhamBenhs (MaBN, MaBS, MaPK, TongTien, TrangThai) " +
                           "OUTPUT INSERTED.MaHDKB " + // Lấy mã hóa đơn vừa được thêm
                           "VALUES (@MaBN, @MaBS, @MaPK, @TongTien, @TrangThai)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaBN", hoaDon.MaBN);
                command.Parameters.AddWithValue("@MaBS", hoaDon.MaBS);
                command.Parameters.AddWithValue("@MaPK", hoaDon.MaPK);
                command.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);
                command.Parameters.AddWithValue("@TrangThai", hoaDon.TrangThai ?? "Chờ xử lý");

                connection.Open();

                // Thực thi lệnh và lấy mã hóa đơn vừa thêm
                long maHDKB = Convert.ToInt64(command.ExecuteScalar());

                return maHDKB; // Trả về mã hóa đơn vừa được thêm
            }
        }


        public bool UpdateTrangThaiHoaDon(long maHDKB, string trangThai)
        {
            string query = "UPDATE HoaDonKhamBenhs SET TrangThai = @TrangThai WHERE MaHDKB = @MaHDKB";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TrangThai", trangThai);
                command.Parameters.AddWithValue("@MaHDKB", maHDKB);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0; // Trả về true nếu cập nhật thành công
            }
        }

        // *** ConKienHuy <---
        public List<HoaDonKhamBenhDTO> GetAllByMaBN(long MaBN)
        {
            List<HoaDonKhamBenhDTO> listH = new List<HoaDonKhamBenhDTO>();
            string query = @"SELECT *
                            FROM HoaDonKhamBenhs
                            WHERE MaBN = @MaSo";

            // Mo connection
            using (SqlConnection conection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, conection);
                command.Parameters.AddWithValue("@MaSo", MaBN);
                conection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HoaDonKhamBenhDTO hd = new HoaDonKhamBenhDTO();
                        hd.MaHDKB = Convert.ToInt64(reader[0]);
                        hd.MaBN = Convert.ToInt64(reader[1]);
                        hd.MaBS = Convert.ToInt64(reader[2]);
                        hd.MaPK = Convert.ToInt64(reader[3]);
                        hd.TongTien = Convert.ToDecimal(reader[4]);
                        hd.TrangThai = Convert.ToString(reader[5]);

                        listH.Add(hd);
                    }
                }
            }

            return listH;
        }

        public bool ThanhToanHoaDon(long maHDKB, string trangThaiHoaDon)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE HoaDonKhamBenhs
                                SET TrangThai = @TrangThai
                                WHERE MaHDKB = @MaHDKB";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TrangThai", maHDKB); //**********
                command.Parameters.AddWithValue("@MaHDKB", trangThaiHoaDon);
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0; // Trả về true nếu cập nhật thành công
            }
        }

        public List<HoaDonKhamBenhDTO> TimKiemByTongSoTien(double tongSoTien)
        {
            List<HoaDonKhamBenhDTO> resultList = new List<HoaDonKhamBenhDTO>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"SELECT *
                                FROM HoaDonKhamBenhs
                                WHERE TongTien = @TongTien";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TongTien", tongSoTien);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HoaDonKhamBenhDTO hd = new HoaDonKhamBenhDTO();
                        hd.MaHDKB = Convert.ToInt64(reader[0]);
                        hd.MaBN = Convert.ToInt64(reader[1]);
                        hd.MaBS = Convert.ToInt64(reader[2]);
                        hd.MaPK = Convert.ToInt64(reader[3]);
                        hd.TongTien = Convert.ToDecimal(reader[4]);
                        hd.TrangThai = Convert.ToString(reader[5]);

                        resultList.Add(hd);
                    }
                }

                return resultList;
            }
        }

        public List<HoaDonKhamBenhDTO> TimKiemByTrangThai(int trangThai)
        {
            List<HoaDonKhamBenhDTO> resultList = new List<HoaDonKhamBenhDTO>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"SELECT *
                                FROM HoaDonKhamBenhs
                                WHERE TrangThai = @TrangThai";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TrangThai", trangThai);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HoaDonKhamBenhDTO hd = new HoaDonKhamBenhDTO();
                        hd.MaHDKB = Convert.ToInt64(reader[0]);
                        hd.MaBN = Convert.ToInt64(reader[1]);
                        hd.MaBS = Convert.ToInt64(reader[2]);
                        hd.MaPK = Convert.ToInt64(reader[3]);
                        hd.TongTien = Convert.ToDecimal(reader[4]);
                        hd.TrangThai = Convert.ToString(reader[5]);

                        resultList.Add(hd);
                    }
                }

                return resultList;
            }
        }

        // *** ConKienHuy <---



        // Minh Thắng
        public List<HoaDonKhamBenhDTO> GetAll()
        {
            try
            {
                string query = "SELECT * FROM HoaDonKhamBenhs";
                DataTable result = ExecuteQuery(query);

                if (result.Rows.Count == 0)
                {
                    Debug.WriteLine("Không tồn tại danh sách HoaDonKhamBenh nào.");
                    return new List<HoaDonKhamBenhDTO>();
                }

                List<HoaDonKhamBenhDTO> hoaDonKhamBenhList = new List<HoaDonKhamBenhDTO>();

                foreach (DataRow row in result.Rows)
                {
                    HoaDonKhamBenhDTO hoaDon = new HoaDonKhamBenhDTO
                    {
                        MaHDKB = Convert.ToInt64(row["MaHDKB"]),
                        MaBN = Convert.ToInt64(row["MaBN"]),
                        MaBS = Convert.ToInt64(row["MaBS"]),
                        MaPK = Convert.ToInt64(row["MaPK"]),
                        TongTien = Convert.ToDecimal(row["TongTien"]),
                        TrangThai = Convert.ToString(row["TrangThai"]),
                        // SỬA
                        NgayThanhToan = Convert.ToDateTime(row["NgayThanhToan"])
                    };
                    hoaDonKhamBenhList.Add(hoaDon);
                }

                return hoaDonKhamBenhList;

            }
            catch (Exception ex)
            {
                string errorMessage = $"ERROR::HoaDonKhamBenhDAL::GetAll() - Không thể lấy danh sách HoaDonKhamBenh: {ex.Message}";
                Debug.WriteLine(errorMessage);
                return new List<HoaDonKhamBenhDTO>();
            }
        }

        public List<HoaDonKhamBenhDTO> GetByMaBN(long MaBN)
        {
            try
            {
                string query = "SELECT * FROM HoaDonKhamBenhs WHERE MaBN = @MaBN ORDER BY MaHDKB DESC";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaBN", MaBN)
                };
                DataTable result = ExecuteQuery(query, parameters);

                if (result.Rows.Count == 0)
                {
                    Debug.WriteLine($"Không tồn tại HoaDonKhamBenh với MaBN {MaBN}.");
                    return new List<HoaDonKhamBenhDTO>();
                }

                List<HoaDonKhamBenhDTO> hoaDonKhamBenhList = new List<HoaDonKhamBenhDTO>();
                foreach (DataRow row in result.Rows)
                {
                    HoaDonKhamBenhDTO hoaDon = new HoaDonKhamBenhDTO
                    {
                        MaHDKB = Convert.ToInt64(row["MaHDKB"]),
                        MaBN = Convert.ToInt64(row["MaBN"]),
                        MaBS = Convert.ToInt64(row["MaBS"]),
                        MaPK = Convert.ToInt64(row["MaPK"]),
                        TongTien = Convert.ToDecimal(row["TongTien"]),
                        TrangThai = Convert.ToString(row["TrangThai"]),
                        // SỬA
                        NgayThanhToan = Convert.ToDateTime(row["NgayThanhToan"])
                    };
                    hoaDonKhamBenhList.Add(hoaDon);
                }

                return hoaDonKhamBenhList;

            }
            catch (Exception ex)
            {
                string errorMessage = $"ERROR::HoaDonKhamBenhDAL::GetByMaBN() - Không thể lấy danh sách HoaDonKhamBenh bằng MaBN {MaBN}: {ex.Message}";
                return new List<HoaDonKhamBenhDTO>();
            }
        }

        public HoaDonKhamBenhDTO GetByMaHDKB(long MaHDKB)
        {
            try
            {
                string query = "SELECT * FROM HoaDonKhamBenhs WHERE MaHDKB = @MaHDKB ORDER BY MaHDKB DESC";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaHDKB", MaHDKB)
                };
                DataTable result = ExecuteQuery(query, parameters);

                if (result.Rows.Count == 0)
                {
                    Debug.WriteLine($"Không tồn tại HoaDonKhamBenh với MaHDKB {MaHDKB}.");
                    return null;
                }

                DataRow row = result.Rows[0];
                HoaDonKhamBenhDTO hoaDon = new HoaDonKhamBenhDTO
                {
                    MaHDKB = Convert.ToInt64(row["MaHDKB"]),
                    MaBN = Convert.ToInt64(row["MaBN"]),
                    MaBS = Convert.ToInt64(row["MaBS"]),
                    MaPK = Convert.ToInt64(row["MaPK"]),
                    TongTien = Convert.ToDecimal(row["TongTien"]),
                    TrangThai = Convert.ToString(row["TrangThai"]),
                    // SỬA
                    NgayThanhToan = Convert.ToDateTime(row["NgayThanhToan"])
                };

                return hoaDon;

            }
            catch (Exception ex)
            {
                string errorMessage = $"ERROR::HoaDonKhamBenhDAL::GetByMaHDKB() - Không thể lấy HoaDonKhamBenh bằng MaHDKB {MaHDKB}: {ex.Message}";
                return null;
            }
        }

        public List<HoaDonKhamBenhDTO> GetByMaPK(long MaPK)
        {
            try
            {
                string query = "SELECT * FROM HoaDonKhamBenhs WHERE MaPK = @MaPK ORDER BY MaHDKB DESC";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaPK", MaPK)
                };
                DataTable result = ExecuteQuery(query, parameters);

                if (result.Rows.Count == 0)
                {
                    Debug.WriteLine($"Không tồn tại HoaDonKhamBenh với MaPK {MaPK}.");
                    return new List<HoaDonKhamBenhDTO>();
                }

                List<HoaDonKhamBenhDTO> hoaDonKhamBenhList = new List<HoaDonKhamBenhDTO>();
                foreach (DataRow row in result.Rows)
                {
                    HoaDonKhamBenhDTO hoaDon = new HoaDonKhamBenhDTO
                    {
                        MaHDKB = Convert.ToInt64(row["MaHDKB"]),
                        MaBN = Convert.ToInt64(row["MaBN"]),
                        MaBS = Convert.ToInt64(row["MaBS"]),
                        MaPK = Convert.ToInt64(row["MaPK"]),
                        TongTien = Convert.ToDecimal(row["TongTien"]),
                        TrangThai = Convert.ToString(row["TrangThai"]),
                        // SỬA
                        NgayThanhToan = Convert.ToDateTime(row["NgayThanhToan"])
                    };
                    hoaDonKhamBenhList.Add(hoaDon);
                }

                return hoaDonKhamBenhList;

            }
            catch (Exception ex)
            {
                string errorMessage = $"ERROR::HoaDonKhamBenhDAL::GetByMaPK() - Không thể lấy danh sách HoaDonKhamBenh bằng MaPK {MaPK}: {ex.Message}";
                return new List<HoaDonKhamBenhDTO>();
            }
        }

        public List<HoaDonKhamBenhDTO> TimKiemThanhToan(long MaBN, string searchStr, string searchTerm, int TrangThai, DateTime? NgayTao)
        {
            string query = "SELECT * FROM HoaDonKhamBenhs WHERE MaBN = @MaBN";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MaBN", MaBN));

            // Tìm kiếm theo Mã hóa đơn hoặc Mã phiếu khám
            if (searchTerm == "Mã hóa đơn" && !string.IsNullOrEmpty(searchStr))
            {
                query += " AND MaHDKB = @MaHDKB";
                parameters.Add(new SqlParameter("@MaHDKB", searchStr));
            }
            else if (searchTerm == "Mã phiếu khám" && !string.IsNullOrEmpty(searchStr))
            {
                query += " AND MaPK = @MaPK";
                parameters.Add(new SqlParameter("@MaPK", searchStr));
            }

            // Tìm kiếm theo trạng thái
            // SỬA
            if (TrangThai != 3) // 2 là mặc định, tức là tìm tất cả trạng thái
            {
                if(TrangThai == 0)
                {
                    query += " AND TrangThai = @TrangThai";
                    parameters.Add(new SqlParameter("@TrangThai", "Chờ xử lý"));
                }
                else if(TrangThai == 1) { 
                    query += " AND TrangThai = @TrangThai";
                    parameters.Add(new SqlParameter("@TrangThai", "Chưa thanh toán"));
                }
                else if(TrangThai == 2)
                {
                    query += " AND TrangThai = @TrangThai";
                    parameters.Add(new SqlParameter("@TrangThai", "Đã thanh toán"));
                }
            }

            // Tìm kiếm theo Ngày thanh toán
            // SỬA
            if (NgayTao.HasValue)
            {
                query += " AND NgayThanhToan >= @StartOfDay AND NgayThanhToan < @EndOfDay";
                parameters.Add(new SqlParameter("@StartOfDay", NgayTao.Value.Date));
                parameters.Add(new SqlParameter("@EndOfDay", NgayTao.Value.Date.AddDays(1)));
            }

            DataTable result = ExecuteQuery(query, parameters.ToArray());

            List<HoaDonKhamBenhDTO> hoaDonKBList = new List<HoaDonKhamBenhDTO>();
            foreach (DataRow row in result.Rows)
            {
                HoaDonKhamBenhDTO hoaDonKB = new HoaDonKhamBenhDTO
                {
                    MaHDKB = Convert.ToInt64(row["MaHDKB"]),
                    MaBN = Convert.ToInt64(row["MaBN"]),
                    MaBS = Convert.ToInt64(row["MaBS"]),
                    MaPK = Convert.ToInt64(row["MaPK"]),
                    TongTien = Convert.ToDecimal(row["TongTien"]),
                    TrangThai = Convert.ToString(row["TrangThai"]),
                    // SỬA
                    NgayThanhToan = Convert.ToDateTime(row["NgayThanhToan"])
                };
                hoaDonKBList.Add(hoaDonKB);
            }

            return hoaDonKBList;
        }


        //public bool SetThanhToan(long MaHDKB, int TrangThai)
        //{
        //    string query = @"UPDATE HoaDonKhamBenhs
        //                    SET TrangThai = @TrangThai
        //                    WHERE MaHDKB = @MaHDKB";
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@TrangThai", TrangThai),
        //            new SqlParameter("@MaHDKB", MaHDKB)
        //        };

        //    int success = ExecuteNonQuery(query, parameters);
        //    return success > 0;
        //}

    }
}
