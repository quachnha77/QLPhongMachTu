using QLPhongMachTu_DOAN_.DTO;
using System.Collections.Generic;
using System.Linq;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class PhieuKhamDAL
    {
        public List<PhieuKham> GetAll()
        {
            using(var context = new ApplicationDbContext())
            {
                return context.PhieuKham.AsNoTracking().ToList();
            }
        }

        public PhieuKham Create(PhieuKham newPhieuKham)
        {
            using(var context = new ApplicationDbContext())
            {
                var result = context.PhieuKham.Add(newPhieuKham);
                context.SaveChanges();
                return result;
            }
        }
    }
}
