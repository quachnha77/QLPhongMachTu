using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
