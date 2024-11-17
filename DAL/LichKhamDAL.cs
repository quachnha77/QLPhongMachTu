using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using static QLPhongMachTu_DOAN_.DTO.LichKham;
using QLPhongMachTu_DOAN_.Enums;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class LichKhamDAL : DatabaseHelper
    {
        private readonly string _connectionString;

        ///****************** ConKienHuy <summary>

        public LichKham TaoLichKham(LichKham lk)
        {
            string query = "INSERT INTO LichKhams (MaBS, MaBN, NgayKham, TrieuChung, TrangThai) OUTPUT INSERTED.MaLK VALUES (@MaBS, @MaBN, @NgayKham, @TrieuChung, @TrangThai)";
            SqlParameter[] parameters = {
        new SqlParameter("@MaBS", lk.MaBS),
        new SqlParameter("@MaBN", lk.MaBN),
        new SqlParameter("@NgayKham", lk.NgayKham),
        new SqlParameter("@TrieuChung", lk.TrieuChung),
        new SqlParameter("@TrangThai", (int)ETrangThaiKham.ChuaKham) // Sử dụng giá trị số từ enum
    };

            using (DataTable result = ExecuteQuery(query, parameters))
            {
                if (result.Rows.Count > 0)
                {
                    lk.MaLK = Convert.ToInt64(result.Rows[0]["MaLK"]);
                }
                return lk;
            }
        }


        public bool XoaLichKham(long id)
        {
            string query = "DELETE FROM LichKhams WHERE MaLK = @MaLK";
            SqlParameter[] parameters = { new SqlParameter("@MaLK", id) };

            int rowsAffected = ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public List<LichKham> GetByMaBenhNhan(long maBN)
        {
            string query = @"
                SELECT lk.*, bs.*, bn.*
                FROM LichKhams lk
                INNER JOIN BacSis bs ON lk.MaBS = bs.MaSo
                INNER JOIN BenhNhans bn ON lk.MaBN = bn.MaSo
                WHERE lk.MaBN = @MaBN";
            SqlParameter[] parameters = { new SqlParameter("@MaBN", maBN) };

            DataTable result = ExecuteQuery(query, parameters);
            return MapLichKhamList(result);
        }

        public List<LichKham> GetAll1() // Kiến Huy
        {
            string query = @"
                SELECT lk.*, bs.HoTen, bn.HoTen
                FROM LichKhams lk
                INNER JOIN BacSis bs ON lk.MaBS = bs.MaSo
                INNER JOIN BenhNhans bn ON lk.MaBN = bn.MaSo";

            DataTable result = ExecuteQuery(query);
            return MapLichKhamList(result);
        }

        public List<LichKham> GetByTrangThai(ETrangThaiKham trangThai)
        {
            string query = @"
                SELECT lk.*, bs.HoTen, bn.HoTen
                FROM LichKhams lk
                INNER JOIN BacSis bs ON lk.MaBS = bs.MaSo
                INNER JOIN BenhNhans bn ON lk.MaBN = bn.MaSo
                WHERE lk.TrangThai = @TrangThai";

            // Chuyển enum thành giá trị số
            SqlParameter[] parameters = { new SqlParameter("@TrangThai", (int)trangThai) };

            DataTable result = ExecuteQuery(query, parameters);
            return MapLichKhamList(result);
        }


        public List<LichKham> TimKiemTheoNgay(DateTime from, DateTime to)
        {
            string query = @"SELECT *
                            FROM LichKhams lk
                            INNER JOIN BacSis bs on bs.Maso = lk.MaBS
                            WHERE NgayKham BETWEEN @FromDate AND @ToDate";
            SqlParameter[] parameters = {
                new SqlParameter("@FromDate", from),
                new SqlParameter("@ToDate", to)
            };

            DataTable result = ExecuteQuery(query, parameters);
            return MapLichKhamList(result);
        }

        public bool SuaLichKham(long maLK, LichKham updateLichKham)
        {
            string query = @"UPDATE LichKhams
                            SET MaBS = @MaBS, NgayKham = @NgayKham, TrieuChung = @TrieuChung
                            WHERE MaLK = @MaLK";
            SqlParameter[] parameters = {
                new SqlParameter("@MaBS", updateLichKham.MaBS),
                new SqlParameter("@NgayKham", updateLichKham.NgayKham),
                new SqlParameter("@TrieuChung", updateLichKham.TrieuChung),
                new SqlParameter("@MaLK", maLK)
            }; /*  Không sửa mã bệnh nhân.
                   Do mỗi lịch khám chỉ có 1 bệnh nhân */
            int rowsAffected = ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public LichKham GetById(long maLK)
        {
            string query = @"
                SELECT lk.*, bs.TenBacSi, bn.TenBenhNhan
                FROM LichKhams lk
                INNER JOIN BacSi bs ON lk.MaBS = bs.MaSo
                INNER JOIN BenhNhan bn ON lk.MaBN = bn.MaSo
                WHERE lk.MaLK = @MaLK";
            SqlParameter[] parameters = { new SqlParameter("@MaLK", maLK) };

            DataTable result = ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                // Trả về dòng đầu tiên
                return MapLichKham(result.Rows[0]);
            }
            return null;
        }

        public List<LichKham> TimKiemTheoChuyenKhoa(string chuyenKhoa)
        {
            //    string query = @"SELECT * FROM LichKham lk
            //                    INNER JOIN BacSis bs ON bs.MaSo = lk.MaBS
            //                    INNER JOIN PhongKhoas pk ON bs.MaKhoa = lk.MaKhoa
            //                    WHERE bs.MaKhoa = @";
            string queryChuyenKhoa = @"SELECT * FROM PhongKhoas pk WHERE ChuyenKhoa = @ChuyenKhoa";
            SqlParameter[] parametersCK = { new SqlParameter("@ChuyenKhoa", chuyenKhoa) };

            DataTable chuyenKhoaTbl = ExecuteQuery(queryChuyenKhoa, parametersCK);
            if (chuyenKhoaTbl.Rows.Count > 0)
            {
                long khoaId = Convert.ToInt64(chuyenKhoaTbl.Rows[0][0]);
                string query = @"SELECT lk.*, bs.*
                                FROM LichKhams lk
                                INNER JOIN BacSis bs ON bs.MaSo = lk.MaBS
                                WHERE bs.MaKhoa = @MaPK";
                SqlParameter[] parameters = { new SqlParameter("@MaPK", khoaId) };
                DataTable result = ExecuteQuery(query, parameters);
                return MapLichKhamList(result);
            }

            return null;
        }

        public List<LichKham> TimKiem(string str)
        {
            string query = @"SELECT lk.*, bs.*
                            FROM LichKhams lk
                            INNER JOIN BacSis bs ON bs.MaSo = lk.MaBS
                            INNER JOIN BenhNhans bn ON bn.Maso = lk.MaBN
                            WHERE lk.TrieuChung LIKE '%' + @str + '%' 
                            OR lk.TrangThai LIKE '%' + @str + '%' 
                            OR bn.HoTen LIKE '%' + @str + '%'
                            OR bs.HoTen LIKE '%' + @str + '%'";
            SqlParameter[] parameters = { new SqlParameter("@str", str) };

            DataTable result = ExecuteQuery(query, parameters);
            return MapLichKhamList(result);
        }

        private List<LichKham> MapLichKhamList(DataTable dataTable)
        {
            var list = new List<LichKham>();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(MapLichKham(row));
            }
            return list;
        }

        private LichKham MapLichKham(DataRow row)
        {
            return new LichKham
            {
                MaLK = Convert.ToInt64(row["MaLK"]),
                MaBS = Convert.ToInt64(row["MaBS"]),
                MaBN = Convert.ToInt64(row["MaBN"]),
                NgayKham = Convert.ToDateTime(row["NgayKham"]),
                 TrieuChung = row["TrieuChung"].ToString(), // Bỏ ghi chú nếu cần lấy Triệu Chứng
                TrangThai = (ETrangThaiKham)Convert.ToInt32(row["TrangThai"]), // Chuyển đổi từ số sang enum

                // Đối tượng BacSi
                BacSi = new BacSi
                {
                    MaSo = Convert.ToInt64(row["MaBS"]),
                    HoTen = row["HoTen"].ToString(),
                    MaKhoa = Convert.ToInt64(row["MaKhoa"])
                },

                // Đối tượng BenhNhan
                BenhNhan = new BenhNhan
                {
                    MaSo = Convert.ToInt64(row["MaBN"]),
                    HoTen = row["HoTen"].ToString() 
                }
            };
        }



        //******************************* QuachThanhNha
        public LichKhamDAL()
        {
            // Lấy chuỗi kết nối từ app.config
            _connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        }

        // Phương thức để lấy tất cả các lịch khám
        public List<LichKham> GetAll()
        {
            List<LichKham> lichKhamList = new List<LichKham>();
            string query = "SELECT * FROM LichKhams"; // Truy vấn để lấy tất cả lịch khám

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LichKham lichKham = new LichKham
                        {
                            MaLK = Convert.ToInt64(reader["MaLK"]),
                            MaBS = Convert.ToInt64(reader["MaBS"]),
                            MaBN = Convert.ToInt64(reader["MaBN"]),
                            NgayKham = Convert.ToDateTime(reader["NgayKham"]),
                            //MaNV = Convert.ToInt64(reader["MaNV"]),
                            TrieuChung = Convert.ToString(reader["TrieuChung"]),
                            TrangThai = (ETrangThaiKham)Convert.ToInt32(reader["TrangThai"])
                        };
                        lichKhamList.Add(lichKham);
                    }
                }
            }

            return lichKhamList;
        }

        public LichKham GetByMaLK(long maLK)
        {
            LichKham lichKham = null;
            string query = "SELECT * FROM LichKhams WHERE MaLK = @MaLK";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaLK", maLK);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lichKham = new LichKham
                        {
                            MaLK = Convert.ToInt64(reader["MaLK"]),
                            MaBS = Convert.ToInt64(reader["MaBS"]),
                            MaBN = Convert.ToInt64(reader["MaBN"]),
                            NgayKham = Convert.ToDateTime(reader["NgayKham"]),
                            MaNV = Convert.ToInt64(reader["MaNV"]),
                            TrangThai = (ETrangThaiKham)Convert.ToInt32(reader["TrangThai"]) // Chuyển đổi từ số sang enum
                        };
                    }
                }
            }

            return lichKham;
        }


        public bool UpdateTrangThai(LichKham lichKham)
        {
            string query = "UPDATE LichKhams SET TrangThai = @TrangThai WHERE MaLK = @MaLK";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TrangThai", (int)lichKham.TrangThai); // Sử dụng giá trị số từ enum
                command.Parameters.AddWithValue("@MaLK", lichKham.MaLK);
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

    }
}
