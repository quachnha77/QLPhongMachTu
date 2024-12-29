using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class NhanVienDAL : DatabaseHelper
    {
        // Lấy tất cả nhân viên từ cơ sở dữ liệu
        public List<NhanVien> GetAllNhanVien()
        {
            List<NhanVien> danhSachNhanVien = new List<NhanVien>();

            try
            {
                string query = @"
                    SELECT 
                        NV.MaSo, NV.CCCD, NV.HoTen, NV.ChucVu, NV.NgaySinh, NV.GioiTinh, 
                        NV.DiaChi, NV.SDT, NV.MaUser
                    FROM 
                        NhanViens NV
                    JOIN 
                        Users U ON NV.MaUser = U.MaUser
                    JOIN 
                        PhanQuyens PQ ON U.MaPQ = PQ.MaPQ
                    WHERE 
                        PQ.TenQuyen NOT IN ('Admin', N'Vô hiệu hóa')";

                DataTable result = ExecuteQuery(query);

                foreach (DataRow row in result.Rows)
                {
                    NhanVien nv = new NhanVien
                    {
                        MaSo = Convert.ToInt64(row["MaSo"]),
                        CCCD = Convert.ToInt64(row["CCCD"]),
                        HoTen = row["HoTen"].ToString(),
                        NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                        GioiTinh = row["GioiTinh"].ToString(),
                        DiaChi = row["DiaChi"].ToString(),
                        SDT = row["SDT"].ToString(),
                        MaUser = Convert.ToInt64(row["MaUser"]),
                        ChucVu = row["ChucVu"] != DBNull.Value ? row["ChucVu"].ToString() : "Không xác định" // Lấy giá trị Chức Vụ
                    };

                    danhSachNhanVien.Add(nv);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách nhân viên: {ex.Message}");
            }

            return danhSachNhanVien;
        }


        // Thêm nhân viên vào cơ sở dữ liệu
        public bool AddNhanVien(NhanVien nv)
        {
            try
            {
                string query = "INSERT INTO NhanViens (CCCD, HoTen, NgaySinh, GioiTinh, DiaChi, SDT, MaUser, ChucVu) " +
                               "VALUES (@CCCD, @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @SDT, @MaUser, @ChucVu)";
                SqlParameter[] parameters = {
                    new SqlParameter("@CCCD", nv.CCCD),
                    new SqlParameter("@HoTen", nv.HoTen),
                    new SqlParameter("@NgaySinh", nv.NgaySinh),
                    new SqlParameter("@GioiTinh", nv.GioiTinh),
                    new SqlParameter("@DiaChi", nv.DiaChi),
                    new SqlParameter("@SDT", nv.SDT),
                    new SqlParameter("@MaUser", nv.MaUser),
                    new SqlParameter("@ChucVu", nv.ChucVu)
                };

                int rowsAffected = ExecuteNonQuery(query, parameters);
                return rowsAffected > 0; // Trả về true nếu thêm thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm nhân viên: {ex.Message}");
                return false;
            }
        }



        //BichNhung

        //Xóa Nhân viên
        public bool DeleteNhanVien(long ma)
        {
            string query = @"DELETE FROM NhanViens WHERE MaSo = @MaNV;
                DELETE FROM Users 
                WHERE MaUser = (SELECT MaUser FROM NhanViens WHERE MaSo = @MaNV);";

            SqlParameter[] parameters = {
                new SqlParameter("@MaNV", ma)
                    };
            int rowAffected = ExecuteNonQuery(query, parameters);
            return rowAffected > 0;
        }

        // Lấy Nhân niên theo mã
        public NhanVien GetNhanVienByMa(long ma)
        {
            string query = "SELECT * FROM NhanViens WHERE MaSo = @Ma";

            SqlParameter[] parameters = {
                new SqlParameter("@Ma", ma)
            };

            DataTable dataTable = ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                return new NhanVien
                {
                    MaSo = Convert.ToInt64(row["MaSo"]),
                    HoTen = row["HoTen"].ToString(),
                    CCCD = Convert.ToInt64(row["CCCD"]),
                    SDT = row["SDT"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                    ChucVu = row["ChucVu"].ToString(),
                    GioiTinh = row["GioiTinh"].ToString(),
                    MaUser = Convert.ToInt64(row["MaUser"])
                };
            }
            return null;
        }

        // Cập nhật thông tin nhân viên
        public bool UpdateNhanVienByCCCD(NhanVien nv)
        {
            string query = "UPDATE NhanViens " +
                           "SET HoTen = @HoTen, SDT = @SDT, DiaChi = @DiaChi, " +
                           "NgaySinh = @NgaySinh, ChucVu = @ChucVu, GioiTinh = @GioiTinh " +
                           "WHERE CCCD = @CCCD";

            SqlParameter[] parameters = {
                new SqlParameter("@HoTen", nv.HoTen),
                new SqlParameter("@CCCD", nv.CCCD),
                new SqlParameter("@SDT", nv.SDT),
                new SqlParameter("@DiaChi", nv.DiaChi),
                new SqlParameter("@NgaySinh", nv.NgaySinh),
                new SqlParameter("@ChucVu", nv.ChucVu),
                new SqlParameter("@GioiTinh", nv.GioiTinh)
            };

            int rowsAffected = ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        // Kiểm tra xem CCCD đã tồn tại và có quyền 'Vô hiệu hóa' hay không
        public (bool, long) IsCCCDExistAndGetMaUser(long cccd)
        {
            string query = @"
                SELECT u.MaUser
                FROM NhanViens nv
                INNER JOIN Users u ON nv.MaUser = u.MaUser
                INNER JOIN PhanQuyens pq ON u.MaPQ = pq.MaPQ
                WHERE nv.CCCD = @CCCD AND pq.TenQuyen = N'Vô hiệu hóa'";

            SqlParameter[] parameters = {
                new SqlParameter("@CCCD", SqlDbType.BigInt)
                {
                    Value = cccd
                }
            };

            object result = ExecuteScalar(query, parameters);

            if (result != null)
            {
                long maUser = Convert.ToInt64(result);
                return (true, maUser);  // Trả về true và MaUser nếu tìm thấy
            }
            else
            {
                return (false, -1);  // Trả về false và -1 nếu không tìm thấy
            }
        }

        // Cập nhật thông tin nhân viên
        public bool UpdateNhanVien(NhanVien nv)
        {
            string query = "UPDATE NhanViens " +
                           "SET HoTen = @HoTen, CCCD = @CCCD, SDT = @SDT, DiaChi = @DiaChi, " +
                           "NgaySinh = @NgaySinh, ChucVu = @ChucVu, GioiTinh = @GioiTinh " +
                           "WHERE MaSo = @MaNV";

            SqlParameter[] parameters = {
                new SqlParameter("@HoTen", nv.HoTen),
                new SqlParameter("@CCCD", nv.CCCD),
                new SqlParameter("@SDT", nv.SDT),
                new SqlParameter("@DiaChi", nv.DiaChi),
                new SqlParameter("@NgaySinh", nv.NgaySinh),
                new SqlParameter("@ChucVu", nv.ChucVu),
                new SqlParameter("@GioiTinh", nv.GioiTinh),
                new SqlParameter("@MaNV", nv.MaSo)
            };

            int rowsAffected = ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

    }
}
