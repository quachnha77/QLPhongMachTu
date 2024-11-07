using System;
using System.Collections.Generic;
using System.Linq;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class PhongKhoaDAL
    {
        private readonly ApplicationDbContext context;

        public PhongKhoaDAL()
        {
            this.context = new ApplicationDbContext();
        }

        public List<string> GetName()
        {
            return context.PhongKhoa.Select(pk => pk.TenPhongBan).ToList();
        }

        public long GetMaKhoaByName(string name)
        {
            var result = context.PhongKhoa.FirstOrDefault(pk => pk.TenPhongBan == name);

            // Nếu tìm thấy phân quyền, trả về MaPK, nếu không thì trả về giá trị mặc định 0
            return result != null ? result.MaPK : 0;
        }
    }
}
