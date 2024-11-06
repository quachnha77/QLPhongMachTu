using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class LichKhamDAL
    {
        public LichKham TaoLichKham(LichKham lk)
        {
            using(var context = new ApplicationDbContext())
            {
                var result = context.LichKham.Add(lk);
                context.SaveChanges();
                return result;
            }
        }

        public List<LichKham> GetByMaBenhNhan(long id)
        {
            using(var context = new ApplicationDbContext())
            {
                return context.LichKham
                    .Where(lk => lk.MaBN == id)
                    .ToList();
            }
        }
    }
}
