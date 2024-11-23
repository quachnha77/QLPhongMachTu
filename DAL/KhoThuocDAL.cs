using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class KhoThuocDAL
    {
        private readonly string _connectionString;

        public KhoThuocDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        }

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

        public bool AddThuoc(KhoThuocDTO thuoc)
        {
            string query = "INSERT INTO KhoThuocs (MaThuoc, TenThuoc, DonGia, DonVi, NhaCungCap, NgayNhap, HSD, SoLuongTon) " +
                           "VALUES (@MaThuoc, @TenThuoc, @DonGia, @DonVi, @NhaCungCap, @NgayNhap, @HSD, @SoLuongTon)";
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

        public bool UpdateThuoc(KhoThuocDTO thuoc)
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

