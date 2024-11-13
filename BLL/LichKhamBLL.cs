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
        private readonly PhanCongDAL pcdal;

        public LichKhamBLL()
        {
            this.dal = new LichKhamDAL();
        }

        public LichKham TaoLichKham(LichKham lk)
        {
            return dal.TaoLichKham(lk);
        }

        public bool SuaLichKham(long maLk, LichKham updateLichKham, long phanCongId)
        {
            LichPhanCong pc = pcdal.GetById(phanCongId);
            if (pc == null)
                return false;
            updateLichKham.NgayKham = pc.NgayPhanCong;
            return dal.SuaLichKham(maLk, updateLichKham);
        }

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

        public List<LichKham> TimKiemTheoNgay(DateTime from, DateTime to)
        {
            List<LichKham> result = dal.TimKiemTheoNgay(from, to);
            return result;
        }

        public List<LichKham> TimKiemTheoChuyenKhoa(string chuyenKhoa)
        {
            List<LichKham> result = dal.TimKiemTheoChuyenKhoa(chuyenKhoa);
            return result;
        }

        public List<LichKham> TimKiem(string str)
        {
            List<LichKham> result = dal.TimKiem(str);
            return result;
        }

        internal List<LichKham> TimKiemTheoNgayVaText(DateTime from, DateTime to, string str)
        {
            List<LichKham> rawList = TimKiem(str);
            List<LichKham> result = rawList
                .Where(lk => lk.NgayKham >= from && lk.NgayKham <= to)
                .ToList();
            return result;
            
        }

        //public bool suaLichKham(long maLK, BenhNhan benhNhan, BacSi bs, DateTime ngayHen, string yeuCau)
        //{
        //    //return dal.suaLichKham(maLK, benhNhan, bs, ngayHen, yeuCau);
        //}
    }
}
