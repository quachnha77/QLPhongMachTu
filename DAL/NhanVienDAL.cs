using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class NhanVienDAL
    {
        // Lấy tất cả nhân viên từ cơ sở dữ liệu
        public List<NhanVien> GetAllNhanVien()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.NhanVien.ToList();
            }
        }

        // Thêm nhân viên vào cơ sở dữ liệu
        public bool AddNhanVien(NhanVien nv)
        {
            using (var context = new ApplicationDbContext())
            {
                // Thêm đối tượng NhanVien vào bảng NhanVien
                context.NhanVien.Add(nv);

                // Lưu thay đổi vào cơ sở dữ liệu
                context.SaveChanges();
            }
            return true;
        }
    }
}
