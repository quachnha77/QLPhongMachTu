using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    internal class PhieuKhamDAL
    {
        public List<PhieuKham> GetAll()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.PhieuKham.ToList();
            }
        }
        public PhieuKham GetByMaLK(long maLK)
        {
            using (var context = new ApplicationDbContext())
            {
                // Tìm kiếm LichKham theo MaLK
                return context.PhieuKham.FirstOrDefault(pk => pk.MaLK == maLK);
            }
        }
    }
}
