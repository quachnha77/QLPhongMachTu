using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class PhanCongDAL
    {
        public LichPhanCong taoLichPhanCong(LichPhanCong lichPhanCong)
        {
            using (var context = new ApplicationDbContext())
            {
                var result = context.LichPhanCong.Add(lichPhanCong);
                context.SaveChanges();
                return result;
            }
            
        }

        public List<LichPhanCong> GetAllByMaBacSi(long MaBacSi)
        {
            using(var context = new ApplicationDbContext())
            {
                return context.LichPhanCong
                    .Include("BacSi")
                    .Include("BacSi.PhongKhoa")
                    .Where(pc => pc.MaBS == MaBacSi)
                    .ToList();
            }
        }

        public LichPhanCong GetById(long id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.LichPhanCong.Find(id);
            }
        }
    }
}
