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

        //public LichKham SuaLichKham(long maLk, DateTime ngayHen, string trieuChung)
        //{
        //    //return dal.suaLichKham(lk);
        //}

        public bool XoaLichKham(long id)
        {
            return dal.XoaLichKham(id);
        }

        public List<LichKham> GetByMaBenhNhan(long id)
        {
            return dal.GetByMaBenhNhan(id);
        }

        public List<LichKham> GetAll()
        {
            return dal.GetAll();
        }

        public List<LichKham> GetByTrangThai(string trangThai)
        {
            return dal.GetByTrangThai(trangThai);
        }

        //public bool suaLichKham(long maLK, BenhNhan benhNhan, BacSi bs, DateTime ngayHen, string yeuCau)
        //{
        //    //return dal.suaLichKham(maLK, benhNhan, bs, ngayHen, yeuCau);
        //}
    }
}
