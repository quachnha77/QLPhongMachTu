using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class KhoThuocDAL
    {
        // Thanh Nhã
        private readonly string _connectionString;

        public KhoThuocDAL()
        {
            // Lấy chuỗi kết nối từ file cấu hình
            _connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        }

        // Phương thức để lấy tất cả thuốc trong kho
        public List<KhoThuocDTO> GetAll()
        {
            List<KhoThuocDTO> khoThuocList = new List<KhoThuocDTO>();
            string query = "SELECT * FROM KhoThuocs";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        KhoThuocDTO thuoc = new KhoThuocDTO
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
        public KhoThuocDTO GetByMaThuoc(long maThuoc)
        {
            KhoThuocDTO thuoc = null;
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
                        thuoc = new KhoThuocDTO
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

        // Tìm kiếm thuốc
        public List<KhoThuocDTO> TimKiemThuoc(string keyword)
        {
            List<KhoThuocDTO> khoThuocList = new List<KhoThuocDTO>();
            string query = @"SELECT * FROM KhoThuocs
                             WHERE TenThuoc LIKE @Keyword 
                               OR NhaCungCap LIKE @Keyword
                               OR CONVERT(VARCHAR, NgayNhap, 103) LIKE @Keyword
                               OR CONVERT(VARCHAR, HSD, 103) LIKE @Keyword";



            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Keyword", $"%{keyword}%");
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        KhoThuocDTO thuoc = new KhoThuocDTO
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
                        khoThuocList.Add(thuoc);
                    }
                }
            }

            return khoThuocList;
        }


        // Hoàng Khanh
        public bool NhapThuoc(KhoThuocDTO medicine)
        {
            string query = "INSERT INTO KhoThuocs (TenThuoc, DonGia, DonVi, NhaCungCap, NgayNhap, HSD, SoLuongTon) " +
                           "VALUES (@TenThuoc, @DonGia, @DonVi, @NhaCungCap, @NgayNhap, @HSD, @SoLuongTon)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //command.Parameters.AddWithValue("@MaThuoc", medicine.MaThuoc);
                command.Parameters.AddWithValue("@TenThuoc", medicine.TenThuoc);
                command.Parameters.AddWithValue("@DonGia", medicine.DonGia);
                command.Parameters.AddWithValue("@DonVi", medicine.DonVi);
                command.Parameters.AddWithValue("@NhaCungCap", medicine.NhaCungCap);
                command.Parameters.AddWithValue("@NgayNhap", medicine.NgayNhap);
                command.Parameters.AddWithValue("@HSD", medicine.HSD);
                command.Parameters.AddWithValue("@SoLuongTon", medicine.SoLuongTon);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateThuoc(KhoThuocDTO medicine)
        {
            string query = "UPDATE KhoThuocs SET TenThuoc = @TenThuoc, DonGia = @DonGia, DonVi = @DonVi, " +
                           "NhaCungCap = @NhaCungCap, NgayNhap = @NgayNhap, HSD = @HSD, SoLuongTon = @SoLuongTon " +
                           "WHERE MaThuoc = @MaThuoc";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaThuoc", medicine.MaThuoc);
                command.Parameters.AddWithValue("@TenThuoc", medicine.TenThuoc);
                command.Parameters.AddWithValue("@DonGia", medicine.DonGia);
                command.Parameters.AddWithValue("@DonVi", medicine.DonVi);
                command.Parameters.AddWithValue("@NhaCungCap", medicine.NhaCungCap);
                command.Parameters.AddWithValue("@NgayNhap", medicine.NgayNhap);
                command.Parameters.AddWithValue("@HSD", medicine.HSD);
                command.Parameters.AddWithValue("@SoLuongTon", medicine.SoLuongTon);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<KhoThuocDTO> Search(string keyword)
        {
            var thuocList = new List<KhoThuocDTO>();
            string query = "SELECT * FROM KhoThuocs WHERE TenThuoc LIKE @Keyword OR CONVERT(VARCHAR, MaThuoc) LIKE @Keyword";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Keyword", $"%{keyword}%");
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        thuocList.Add(new KhoThuocDTO
                        {
                            MaThuoc = Convert.ToInt64(reader["MaThuoc"]),
                            TenThuoc = reader["TenThuoc"].ToString(),
                            DonGia = Convert.ToDouble(reader["DonGia"]),
                            DonVi = reader["DonVi"].ToString(),
                            NhaCungCap = reader["NhaCungCap"].ToString(),
                            NgayNhap = Convert.ToDateTime(reader["NgayNhap"]),
                            HSD = Convert.ToDateTime(reader["HSD"]),
                            SoLuongTon = Convert.ToInt32(reader["SoLuongTon"])
                        });
                    }
                }
            }
            return thuocList;
        }
    }
}
