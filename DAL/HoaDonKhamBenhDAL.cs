using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class HoaDonKhamBenhDAL : DatabaseHelper
    {
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
    }
}
