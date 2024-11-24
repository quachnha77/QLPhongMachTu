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
                string query = "SELECT * FROM NhanViens";
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

    }
}
