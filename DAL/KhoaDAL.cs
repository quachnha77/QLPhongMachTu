using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class KhoaDAL
    {
        public List<PhongKhoa> GetAll()
        {
            using(var context = new ApplicationDbContext())
            {
                return context.PhongKhoa.ToList();
            }
        }

        public PhongKhoa GetByChuyenKhoa(string chuyenKhoa)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.PhongKhoa
                    .FirstOrDefault(k => k.ChuyenKhoa == chuyenKhoa);
            }
        }
    }
}
