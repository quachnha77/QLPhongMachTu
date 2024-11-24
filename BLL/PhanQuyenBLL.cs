using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System.Collections.Generic;

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

        public List<string> GetPhanQuyenByName()
        {
            return dal.GetPhanQuyenByName();
        }

        public long GetMaPQByName(string name)
        {
            return dal.GetMaPQByName(name);
        }
    }
}
