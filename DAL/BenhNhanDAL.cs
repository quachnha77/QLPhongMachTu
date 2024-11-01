using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class BenhNhanDAL
    {
        public List<BenhNhan> GetAll()
        {
            var benhNhanList = new List<BenhNhan>();
            using(var context = new ApplicationDbContext())
            {
                benhNhanList = context.BenhNhan.ToList();
            }
            return benhNhanList;
        }

        public BenhNhan Create(BenhNhan newBenhNhan)
        {
            using (var context = new ApplicationDbContext())
            {
                var result = context.BenhNhan.Add(newBenhNhan);
                context.SaveChanges();
                return result;
            }
        }

        public BenhNhan GetByUserID(long userID)
        {
            using(var context = new ApplicationDbContext())
            {
                var benhNhan = context.BenhNhan
                    .FirstOrDefault(bn => bn.MaUser == userID);
                return benhNhan;
            }
        }
    }
}
