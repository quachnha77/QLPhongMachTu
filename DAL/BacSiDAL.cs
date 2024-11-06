using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
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
    }
}
