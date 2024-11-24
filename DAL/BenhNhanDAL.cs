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
            //string query = "INSERT INTO BenhNhan (MaUser, Ten) OUTPUT INSERTED.Id VALUES (@MaUser, @Ten)";
            //SqlParameter[] parameters = {
            //    new SqlParameter("@MaUser", newBenhNhan.MaUser),
            //    new SqlParameter("@Ten", newBenhNhan.Ten)
            //    // Add other parameters as needed
            //};

            //using (DataTable result = ExecuteQuery(query, parameters))
            //{
            //    if (result.Rows.Count > 0)
            //    {
            //        newBenhNhan.Id = Convert.ToInt64(result.Rows[0]["Id"]);
            //    }
            //    return newBenhNhan;
            //}
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
                    //CCCD = Convert.ToString(row[1]),
                    HoTen = (string)row[2],
                    NgaySinh = (DateTime)row[3],
                    GioiTinh = (string)row[4],
                    DiaChi = (string)row[5],
                    MaUser = Convert.ToInt64(row[6]),
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
                    //CCCD = Convert.ToString(row[1]),
                    HoTen = (string)row[2],
                    NgaySinh = (DateTime)row[3],
                    GioiTinh = (string)row[4],
                    DiaChi = (string)row[5],
                    MaUser = Convert.ToInt64(row[6]),

                };
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
                            CCCD = Convert.ToInt64(reader["CCCD"]),
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
                            CCCD = reader["CCCD"] != DBNull.Value ? Convert.ToInt64(reader["CCCD"]) : 0,
                            HoTen = reader["HoTen"]?.ToString(),
                            NgaySinh = reader["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["NgaySinh"]) : DateTime.MinValue,
                            GioiTinh = reader["GioiTinh"]?.ToString(),
                            DiaChi = reader["DiaChi"]?.ToString(),
                            SDT = reader["SDT"]?.ToString(),
                            MaUser = reader["MaUser"] != DBNull.Value ? Convert.ToInt64(reader["MaUser"]) : 0
                        };
                    }
                }
            }

            return benhNhan;
        }
    }
}
