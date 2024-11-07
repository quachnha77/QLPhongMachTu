using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class PhanQuyenDAL
    {
        private readonly ApplicationDbContext context;

        public PhanQuyenDAL()
        {
            this.context = new ApplicationDbContext();
        }

        public PhanQuyen GetByMaQP(long MaQP)
        {
            var result = context.PhanQuyen.FirstOrDefault(pq => pq.MaPQ == MaQP);
            return result;
        }

        public List<string> GetPhanQuyenByName()
        {
            return context.PhanQuyen
                .Where(pq => pq.TenQuyen != "Bệnh nhân")
                .Select(pq => pq.TenQuyen).ToList();
        }

        public long GetMaPQByName(string name)
        {
            var result = context.PhanQuyen.FirstOrDefault(pq => pq.TenQuyen == name);

            // Nếu tìm thấy phân quyền, trả về MaPQ, nếu không thì trả về giá trị mặc định 0
            return result != null ? result.MaPQ : 0;
        }

    }
}
