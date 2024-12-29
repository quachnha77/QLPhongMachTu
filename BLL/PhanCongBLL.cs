using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class PhanCongBLL
    {
        private readonly PhanCongDAL dal;

        public PhanCongBLL()
        {
            this.dal = new PhanCongDAL();
        }

        //public LichPhanCong TaoLichPhanCong(LichPhanCong pc)
        //{
        //    ////workingDays = 2 + 3 + 4 + 5;
        //    //pc.workingDays = Day.T2 | Day.T3 | Day.T4 | Day.T5;
        //    return dal.taoLichPhanCong(pc);
        //}

        public List<LichPhanCong> GetAllPhanCongByMaBacSi(long MaBS)
        {
            return dal.GetAllByMaBacSi(MaBS);
        }

        public LichPhanCong GetById(long id)
        {
            return dal.GetById(id);
        }

        public List<LichPhanCong> GetAllByNgayPhanCong(DateTime ngayThucHien)
        {
            return dal.GetAllByNgayPhanCong(ngayThucHien);
        }


        //Khoa

        public List<LichPhanCong> GetAll()
        {
            return dal.GetAll();
        }

        public void CreateLichPhanCong(LichPhanCong lpc)
        {
            dal.CreateLichPhanCong(lpc);
        }

        public void EditLichPhanCong(LichPhanCong lpc)
        {
            dal.EditLichPhanCong(lpc);
        }

        public void DeleteLichPhanCong(int ma_lpc)
        {
            dal.DeleteLichPhanCong(ma_lpc);
        }
    }
}
