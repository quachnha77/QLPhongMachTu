using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.DAL
{
    internal class ChiTietToaThuocDAL
    {
        private readonly string _connectionString;

        public ChiTietToaThuocDAL()
        {
            // Lấy chuỗi kết nối từ file cấu hình
            _connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        }

        // Phương thức lấy toàn bộ danh sách chi tiết toa thuốc
        public List<ChiTietToaThuocDTO> GetAll()
        {
            List<ChiTietToaThuocDTO> chiTietList = new List<ChiTietToaThuocDTO>();
            string query = "SELECT * FROM ChiTietToaThuocs";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ChiTietToaThuocDTO chiTiet = new ChiTietToaThuocDTO
                        {
                            MaThuoc = Convert.ToInt64(reader["MaThuoc"]),
                            MaTT = Convert.ToInt64(reader["MaTT"]),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            CachDung = reader["CachDung"].ToString(),
                            DonGia = Convert.ToDouble(reader["DonGia"])
                        };
                        chiTietList.Add(chiTiet);
                    }
                }
            }

            return chiTietList;
        }

        // Phương thức lấy danh sách chi tiết toa thuốc theo MaTT
        public List<ChiTietToaThuocDTO> GetByMaTT(long maTT)
        {
            List<ChiTietToaThuocDTO> chiTietList = new List<ChiTietToaThuocDTO>();
            string query = "SELECT * FROM ChiTietToaThuocs WHERE MaTT = @MaTT";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaTT", maTT);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ChiTietToaThuocDTO chiTiet = new ChiTietToaThuocDTO
                        {
                            MaThuoc = Convert.ToInt64(reader["MaThuoc"]),
                            MaTT = Convert.ToInt64(reader["MaTT"]),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            CachDung = reader["CachDung"].ToString(),
                            DonGia = Convert.ToDouble(reader["DonGia"])
                        };
                        chiTietList.Add(chiTiet);
                    }
                }
            }

            return chiTietList;
        }

        // Phương thức thêm chi tiết toa thuốc
        public bool AddChiTietToaThuoc(ChiTietToaThuocDTO chiTiet)
        {
            string query = "INSERT INTO ChiTietToaThuocs (MaThuoc, MaTT, SoLuong, CachDung, DonGia) " +
                           "VALUES (@MaThuoc, @MaTT, @SoLuong, @CachDung, @DonGia)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaThuoc", chiTiet.MaThuoc);
                command.Parameters.AddWithValue("@MaTT", chiTiet.MaTT);
                command.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                command.Parameters.AddWithValue("@CachDung", chiTiet.CachDung);
                command.Parameters.AddWithValue("@DonGia", chiTiet.DonGia); // Thêm đơn giá
                connection.Open();

                int result = command.ExecuteNonQuery();
                return result > 0; // Trả về true nếu thêm thành công
            }
        }


        //// Phương thức xóa chi tiết toa thuốc theo MaTT
        //public bool DeleteByMaTT(long maTT)
        //{
        //    string query = "DELETE FROM ChiTietToaThuocs WHERE MaTT = @MaTT";

        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("@MaTT", maTT);
        //        connection.Open();

        //        int result = command.ExecuteNonQuery();
        //        return result > 0; // Trả về true nếu xóa thành công
        //    }
        //}
    }
}
