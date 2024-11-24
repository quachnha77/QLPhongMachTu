using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class BenhNhanDAL : DatabaseHelper
    {
        //*****ConKienHuy
        public BenhNhan Create(BenhNhan newBenhNhan)
        {
            string query = @"INSERT INTO BenhNhans (CCCD, HoTen, NgaySinh, GioiTinh, DiaChi, SDT, MaUser) 
                            OUTPUT INSERTED.MaSo
                            VALUES (@CCCD, @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @SDT, @MaUser)";

            SqlParameter[] parameters = {
                new SqlParameter("@HoTen", newBenhNhan.HoTen),
                new SqlParameter("@CCCD", newBenhNhan.CCCD),
                new SqlParameter("@NgaySinh", newBenhNhan.NgaySinh),
                new SqlParameter("@GioiTinh", newBenhNhan.GioiTinh),
                new SqlParameter("@DiaChi", newBenhNhan.DiaChi),
                new SqlParameter("@SDT", newBenhNhan.SDT),
                new SqlParameter("@MaUser", newBenhNhan.MaUser)
            };

            using (DataTable result = ExecuteQuery(query, parameters))
            {
                if (result.Rows.Count > 0)
                {
                    newBenhNhan.MaSo = Convert.ToInt64(result.Rows[0]["MaSo"]);
                }
                return newBenhNhan;
            }
            return null;
        }

        public BenhNhan GetByUserID(long userID)
        {
            string query = "SELECT * FROM BenhNhans WHERE MaUser = @MaUser";
            SqlParameter[] parameters = {
                new SqlParameter("@MaUser", userID)
            };

            DataTable result = ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                var bn = new BenhNhan()
                {
                    MaSo = Convert.ToInt64(row[0]),
                    CCCD = Convert.ToString(row[1]),
                    HoTen = (string)row[2],
                    NgaySinh = (DateTime)row[3],
                    GioiTinh = (string)row[4],
                    DiaChi = (string)row[5],
                    SDT = Convert.ToString(row[6]),
                    MaUser = Convert.ToInt64(row[7]),
                };
                return bn;
            }
            return null;
        }

        public BenhNhan GetById(long id)
        {
            string query = "SELECT * FROM BenhNhans WHERE MaSo = @Id";
            SqlParameter[] parameters = {
                new SqlParameter("@Id", id)
            };

            DataTable result = ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                return new BenhNhan
                {
                    MaSo = Convert.ToInt64(row[0]),
                    CCCD = Convert.ToString(row[1]),
                    HoTen = (string)row[2],
                    NgaySinh = (DateTime)row[3],
                    GioiTinh = (string)row[4],
                    DiaChi = (string)row[5],
                    SDT = Convert.ToString(row[6]),
                    MaUser = Convert.ToInt64(row[7]),

                };
            }
            return null;
        }

        public BenhNhan UpdateBenhNhan(long benhNhanId, BenhNhan updatedBenhNhan)
        { // HoTen, DiaChi, SDT, GioiTinh
            string query = @"UPDATE BenhNhans 
                            SET HoTen = @HoTen, DiaChi = @DiaChi, SDT = @SDT, GioiTinh = @GioiTinh
                            WHERE MaSo = @MaSo";
            SqlParameter[] parameters = {
                new SqlParameter("@HoTen", updatedBenhNhan.HoTen),
                new SqlParameter("@DiaChi", updatedBenhNhan.DiaChi),
                new SqlParameter("@SDT", updatedBenhNhan.SDT),
                new SqlParameter("@GioiTinh", updatedBenhNhan.GioiTinh),
                new SqlParameter("@MaSo", benhNhanId),
            };

            int rowAffected = ExecuteNonQuery(query, parameters);
            if (rowAffected > 0)
            {
                return updatedBenhNhan;
            }
            return null;
        }

        //*****QuachThanhNha
        private readonly string _connectionString;

        public BenhNhanDAL()
        {
            // Lấy chuỗi kết nối từ app.config
            _connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        }

        // Phương thức để lấy tất cả bệnh nhân
        public List<BenhNhan> GetAll()
        {
            List<BenhNhan> benhNhanList = new List<BenhNhan>();
            string query = "SELECT * FROM BenhNhans"; // Truy vấn để lấy tất cả bệnh nhân

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Tạo đối tượng BenhNhan và ánh xạ các cột từ cơ sở dữ liệu vào thuộc tính của nó
                        BenhNhan benhNhan = new BenhNhan
                        {
                            MaSo = Convert.ToInt64(reader["MaSo"]),
                            CCCD = Convert.ToString(reader["CCCD"]),
                            HoTen = reader["HoTen"].ToString(),
                            NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                            GioiTinh = reader["GioiTinh"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            SDT = reader["SDT"].ToString(),
                            MaUser = Convert.ToInt64(reader["MaUser"])
                        };
                        benhNhanList.Add(benhNhan); // Thêm đối tượng vào danh sách
                    }
                }
            }

            return benhNhanList; // Trả về danh sách bệnh nhân
        }

        public BenhNhan GetBenhNhanByMaBN(long maBN)
        {
            BenhNhan benhNhan = null;
            string query = "SELECT * FROM BenhNhans WHERE MaSo = @MaSo";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaSo", maBN);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        benhNhan = new BenhNhan
                        {
                            MaSo = Convert.ToInt64(reader["MaSo"]),
                            HoTen = reader["HoTen"].ToString(),
                            NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                            GioiTinh = reader["GioiTinh"].ToString(),
                            CCCD = Convert.ToString(reader["CCCD"]),
                        };
                    }
                }
            }

            return benhNhan;
        }
    }
}
