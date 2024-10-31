using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class BenhNhanDAL
    {
        public async Task<List<BenhNhan>> GetAll()
        {
            var benhNhanList = new List<BenhNhan>();
            using(var context = new ApplicationDbContext())
            {
                benhNhanList = await context.BenhNhan.ToListAsync();
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
    }
}
