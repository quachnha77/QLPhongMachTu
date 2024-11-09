using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class LichKhamBLL
    {
        private readonly LichKhamDAL dal;

        public LichKhamBLL()
        {
            this.dal = new LichKhamDAL();
        }

        public LichKham TaoLichKham(LichKham lk)
        {
            return dal.TaoLichKham(lk);
        }

        public LichKham XoaLichKham(long id)
        {
            return dal.XoaLichKham(id);
        }

        public List<LichKham> GetByMaBenhNhan(long id)
        {
            return dal.GetByMaBenhNhan(id);
        }
    }
}
