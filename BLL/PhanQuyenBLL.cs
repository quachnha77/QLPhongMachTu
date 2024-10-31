using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class PhanQuyenBLL
    {
        private readonly PhanQuyenDAL dal;

        public PhanQuyenBLL()
        {
            this.dal = new PhanQuyenDAL();
        }

        public PhanQuyen GetByMaPQ(long maPQ)
        {
            return dal.GetByMaQP(maPQ);
        }
    }
}
