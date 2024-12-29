using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.DAL
{
    internal class PhieuKhamDichVuDAL
    {
        private readonly string _connectionString;

        public PhieuKhamDichVuDAL()
        {
            // Lấy chuỗi kết nối từ app.config
            _connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        }

        // Phương thức để lấy tất cả các dịch vụ của phiếu khám
        public List<PhieuKhamDichVu> GetAll()
        {
            List<PhieuKhamDichVu> phieuKhamDichVuList = new List<PhieuKhamDichVu>();
            string query = "SELECT * FROM PhieuKhamDichVus";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PhieuKhamDichVu phieuKhamDichVu = new PhieuKhamDichVu
                        {
                            MaPK = Convert.ToInt64(reader["MaPK"]),
                            MaDV = Convert.ToInt64(reader["MaDV"]),
                            Gia = Convert.ToDouble(reader["Gia"])
                        };
                        phieuKhamDichVuList.Add(phieuKhamDichVu);
                    }
                }
            }

            return phieuKhamDichVuList;
        }

        // Lấy danh sách các dịch vụ theo mã phiếu khám
        public List<PhieuKhamDichVu> GetByMaPK(long maPK)
        {
            List<PhieuKhamDichVu> phieuKhamDichVuList = new List<PhieuKhamDichVu>();
            string query = "SELECT * FROM PhieuKhamDichVus WHERE MaPK = @MaPK";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaPK", maPK);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PhieuKhamDichVu phieuKhamDichVu = new PhieuKhamDichVu
                        {
                            MaPK = Convert.ToInt64(reader["MaPK"]),
                            MaDV = Convert.ToInt64(reader["MaDV"]),
                            Gia = Convert.ToDouble(reader["Gia"]),
                            SoLuong = Convert.ToInt32(reader["SoLuong"])
                        };
                        phieuKhamDichVuList.Add(phieuKhamDichVu);
                    }
                }
            }

            return phieuKhamDichVuList;
        }

        // Thêm dịch vụ vào phiếu khám
        public void Add(PhieuKhamDichVu phieuKhamDichVu)
        {
            string queryCheck = "SELECT COUNT(*) FROM PhieuKhamDichVus WHERE MaPK = @MaPK AND MaDV = @MaDV";
            string queryInsert = "INSERT INTO PhieuKhamDichVus (MaPK, MaDV, Gia) VALUES (@MaPK, @MaDV, @Gia)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Kiểm tra nếu bản ghi đã tồn tại
                SqlCommand checkCommand = new SqlCommand(queryCheck, connection);
                checkCommand.Parameters.AddWithValue("@MaPK", phieuKhamDichVu.MaPK);
                checkCommand.Parameters.AddWithValue("@MaDV", phieuKhamDichVu.MaDV);

                int recordCount = (int)checkCommand.ExecuteScalar();
                if (recordCount == 0)
                {
                    // Nếu bản ghi chưa tồn tại, thêm mới vào cơ sở dữ liệu
                    SqlCommand insertCommand = new SqlCommand(queryInsert, connection);
                    insertCommand.Parameters.AddWithValue("@MaPK", phieuKhamDichVu.MaPK);
                    insertCommand.Parameters.AddWithValue("@MaDV", phieuKhamDichVu.MaDV);
                    insertCommand.Parameters.AddWithValue("@Gia", phieuKhamDichVu.Gia);
                    insertCommand.ExecuteNonQuery();
                }
                else
                {
                    Console.WriteLine("Dịch vụ đã tồn tại trong phiếu khám.");
                }
            }
        }
    }
}
