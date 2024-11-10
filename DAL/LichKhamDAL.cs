using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class LichKhamDAL
    {
        public List<LichKham> GetAll()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.LichKham.ToList();
            }
        }

        public LichKham GetByMaLK(long maLK)
        {
            using (var context = new ApplicationDbContext())
            {
                // Tìm kiếm LichKham theo MaLK
                return context.LichKham.FirstOrDefault(lk => lk.MaLK == maLK);
            }
        }

        public bool UpdateTrangThai(LichKham lichKham)
        {
            using (var context = new ApplicationDbContext())
            {
                // Tìm phiếu khám theo MaLK
                var existingLichKham = context.LichKham.FirstOrDefault(lk => lk.MaLK == lichKham.MaLK);
                if (existingLichKham != null)
                {
                    // Cập nhật trạng thái
                    existingLichKham.TrangThai = lichKham.TrangThai;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}