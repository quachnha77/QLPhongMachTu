using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class KhoThuocDAL
    {
        private readonly string _connectionString;

        public KhoThuocDAL()
        {
            // Lấy chuỗi kết nối từ file cấu hình
            _connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        }

        // Phương thức để lấy tất cả thuốc trong kho
        public List<KhoThuoc> GetAll()
        {
            List<KhoThuoc> khoThuocList = new List<KhoThuoc>();
            string query = "SELECT * FROM KhoThuocs";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        KhoThuoc thuoc = new KhoThuoc
                        {
                            MaThuoc = Convert.ToInt64(reader["MaThuoc"]),
                            TenThuoc = reader["TenThuoc"].ToString(),
                            DonGia = Convert.ToDouble(reader["DonGia"]),  // Chuyển đổi đơn giá thành kiểu double
                            DonVi = reader["DonVi"].ToString(),
                            NhaCungCap = reader["NhaCungCap"].ToString(),
                            NgayNhap = Convert.ToDateTime(reader["NgayNhap"]),
                            HSD = Convert.ToDateTime(reader["HSD"]),
                            SoLuongTon = Convert.ToInt32(reader["SoLuongTon"])
                        };
                        khoThuocList.Add(thuoc);
                    }
                }
            }

            return khoThuocList;
        }

        // Phương thức để lấy thông tin thuốc theo MaThuoc
        public KhoThuoc GetByMaThuoc(long maThuoc)
        {
            KhoThuoc thuoc = null;
            string query = "SELECT * FROM KhoThuocs WHERE MaThuoc = @MaThuoc";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaThuoc", maThuoc);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        thuoc = new KhoThuoc
                        {
                            MaThuoc = Convert.ToInt64(reader["MaThuoc"]),
                            TenThuoc = reader["TenThuoc"].ToString(),
                            DonGia = Convert.ToDouble(reader["DonGia"]),
                            DonVi = reader["DonVi"].ToString(),
                            NhaCungCap = reader["NhaCungCap"].ToString(),
                            NgayNhap = Convert.ToDateTime(reader["NgayNhap"]),
                            HSD = Convert.ToDateTime(reader["HSD"]),
                            SoLuongTon = Convert.ToInt32(reader["SoLuongTon"])
                        };
                    }
                }
            }

            return thuoc;
        }


    }
}
