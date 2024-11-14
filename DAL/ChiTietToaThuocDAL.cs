using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        public List<ChiTietToaThuoc> GetAll()
        {
            List<ChiTietToaThuoc> chiTietList = new List<ChiTietToaThuoc>();
            string query = "SELECT * FROM ChiTietToaThuocs";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ChiTietToaThuoc chiTiet = new ChiTietToaThuoc
                        {
                            MaThuoc = Convert.ToInt64(reader["MaThuoc"]),
                            MaTT = Convert.ToInt64(reader["MaTT"]),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            CachDung = reader["CachDung"].ToString()
                        };
                        chiTietList.Add(chiTiet);
                    }
                }
            }

            return chiTietList;
        }

        //// Phương thức lấy danh sách chi tiết toa thuốc theo MaTT
        //public List<ChiTietToaThuoc> GetByMaTT(long maTT)
        //{
        //    List<ChiTietToaThuoc> chiTietList = new List<ChiTietToaThuoc>();
        //    string query = "SELECT * FROM ChiTietToaThuocs WHERE MaTT = @MaTT";

        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("@MaTT", maTT);
        //        connection.Open();

        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                ChiTietToaThuoc chiTiet = new ChiTietToaThuoc
        //                {
        //                    MaThuoc = Convert.ToInt64(reader["MaThuoc"]),
        //                    MaTT = Convert.ToInt64(reader["MaTT"]),
        //                    SoLuong = Convert.ToInt32(reader["SoLuong"]),
        //                    CachDung = reader["CachDung"].ToString()
        //                };
        //                chiTietList.Add(chiTiet);
        //            }
        //        }
        //    }

        //    return chiTietList;
        //}

        //// Phương thức thêm chi tiết toa thuốc
        //public bool AddChiTietToaThuoc(ChiTietToaThuoc chiTiet)
        //{
        //    string query = "INSERT INTO ChiTietToaThuocs (MaThuoc, MaTT, SoLuong, CachDung) VALUES (@MaThuoc, @MaTT, @SoLuong, @CachDung)";

        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("@MaThuoc", chiTiet.MaThuoc);
        //        command.Parameters.AddWithValue("@MaTT", chiTiet.MaTT);
        //        command.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
        //        command.Parameters.AddWithValue("@CachDung", chiTiet.CachDung);
        //        connection.Open();

        //        int result = command.ExecuteNonQuery();
        //        return result > 0; // Trả về true nếu thêm thành công
        //    }
        //}

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
