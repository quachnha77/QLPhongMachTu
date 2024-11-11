using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class BacSiDAL
    {
        public List<BacSi> GetAllBacSi()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.BacSi.ToList();
            }
        }

        // Thêm bác sĩ vào cơ sở dữ liệu
        public bool AddBacSi(BacSi bs)
        {
            using (var context = new ApplicationDbContext())
            {
                // Thêm đối tượng NhanVien vào bảng BacSi
                context.BacSi.Add(bs);

                // Lưu thay đổi vào cơ sở dữ liệu
                context.SaveChanges();
            }
            return true;
        }
    }
}