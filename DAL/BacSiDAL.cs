using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class BacSiDAL
    {
        public List<BacSi> GetAllByChuyenKhoa(long MaKhoa)
        {
            using(var context = new ApplicationDbContext())
            {
                return context.BacSi
                    .Where(bs => bs.MaKhoa == MaKhoa)
                    .ToList();
            }
        }

        public BacSi GetById(long id)
        {
            using(var context = new ApplicationDbContext())
            {
                var result= context.BacSi.Find(id);
                context.Entry(result).State = EntityState.Unchanged;
                return result;
            }
        }
    }
}
