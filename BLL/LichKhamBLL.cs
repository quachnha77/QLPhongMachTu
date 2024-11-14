using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System.Windows.Forms;
using QLPhongMachTu_DOAN_.Enums;

namespace QLPhongMachTu_DOAN_.BLL
{
    internal class LichKhamBLL
    {
        private readonly LichKhamDAL lichKhamDAL;
        private readonly PhanCongDAL phanCongDAL;

        public LichKhamBLL()
        {
            lichKhamDAL = new LichKhamDAL();
        }

        // Lấy tất cả các lịch khám
        public List<LichKham> GetAll()
        {
            return lichKhamDAL.GetAll();
        }

        public LichKham TaoLichKham(LichKham lk)
        {
            return lichKhamDAL.TaoLichKham(lk);
        }

        public bool SuaLichKham(long maLk, LichKham updateLichKham, long phanCongId)
        {
            LichPhanCong pc = phanCongDAL.GetById(phanCongId);
            if (pc == null)
                return false;
            updateLichKham.NgayKham = pc.NgayThucHien;
            return lichKhamDAL.SuaLichKham(maLk, updateLichKham);
        }

        public bool XoaLichKham(long id)
        {
            return lichKhamDAL.XoaLichKham(id);
        }

        public LichKham GetByMaLK(long maLK)
        {
            return lichKhamDAL.GetByMaLK(maLK);
        }


        public List<LichKham> GetByMaBenhNhan(long id)
        {
            return lichKhamDAL.GetByMaBenhNhan(id);
        }

        public List<LichKham> GetByTrangThai(ETrangThaiKham trangThai)
        {
            // Truyền giá trị int của enum vào câu truy vấn SQL
            return lichKhamDAL.GetByTrangThai(trangThai);
        }


        public List<LichKham> TimKiemTheoNgay(DateTime from, DateTime to)
        {
            List<LichKham> result = lichKhamDAL.TimKiemTheoNgay(from, to);
            return result;
        }

        public List<LichKham> TimKiemTheoChuyenKhoa(string chuyenKhoa)
        {
            List<LichKham> result = lichKhamDAL.TimKiemTheoChuyenKhoa(chuyenKhoa);
            return result;
        }

        public List<LichKham> TimKiem(string str)
        {
            List<LichKham> result = lichKhamDAL.TimKiem(str);
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


        public bool UpdateTrangThai(LichKham lichKham)
        {
            return lichKhamDAL.UpdateTrangThai(lichKham);
        }
    }
}