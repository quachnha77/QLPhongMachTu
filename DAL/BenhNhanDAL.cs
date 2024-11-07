using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class BenhNhanDAL
    {
        public List<BenhNhan> GetAll()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.BenhNhan.ToList();
            }
        }

        //public BenhNhan Create(BenhNhan newBenhNhan)
        //{
        //    using (var context = new ApplicationDbContext())
        //    {
        //        var result = context.BenhNhan.Add(newBenhNhan);
        //        context.SaveChanges();
        //        return result;
        //    }
        //}

        //public BenhNhan GetByUserID(long userID)
        //{
        //    using (var context = new ApplicationDbContext())
        //    {
        //        var benhNhan = context.BenhNhan
        //            .FirstOrDefault(bn => bn.MaUser == userID);
        //        return benhNhan;
        //    }
        //}
    }
}