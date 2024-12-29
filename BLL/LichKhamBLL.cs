using System;
using System.Collections.Generic;
using System.Linq;

using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
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
            phanCongDAL = new PhanCongDAL();
        }

        // Lấy tất cả các lịch khám
        public List<DTO.LichKhamDTO> GetAll()
        {
            return lichKhamDAL.GetAll();
        }

        public DTO.LichKhamDTO TaoLichKham(DTO.LichKhamDTO lk, long MaNV)
        {
            return lichKhamDAL.TaoLichKham(lk, MaNV);
        }

        public bool SuaLichKham(long maLk, DTO.LichKhamDTO updateLichKham, long phanCongId)
        {
            LichPhanCong pc = phanCongDAL.GetById(phanCongId);
            if (pc == null)
                return false;
            updateLichKham.NgayKham = pc.NgayThucHien;
            return lichKhamDAL.SuaLichKham(maLk, updateLichKham);
        }

        public bool UpdateTrangThai(long id)
        {
            LichKhamDTO lk = lichKhamDAL.GetByMaLK(id);
            lk.TrangThai = ETrangThaiKham.HuyKham;
            return lichKhamDAL.UpdateTrangThai(lk);
        }

        public DTO.LichKhamDTO GetByMaLK(long maLK)
        {
            return lichKhamDAL.GetByMaLK(maLK);
        }


        public List<DTO.LichKhamDTO> GetByMaBenhNhan(long id)
        {
            return lichKhamDAL.GetByMaBenhNhan(id);
        }

        public List<DTO.LichKhamDTO> GetByTrangThai(ETrangThaiKham trangThai)
        {
            // Truyền giá trị int của enum vào câu truy vấn SQL
            return lichKhamDAL.GetByTrangThai(trangThai);
        }


        public List<DTO.LichKhamDTO> TimKiemTheoNgay(DateTime from, DateTime to)
        {
            List<DTO.LichKhamDTO> result = lichKhamDAL.TimKiemTheoNgay(from, to);
            return result;
        }

        public List<DTO.LichKhamDTO> TimKiemTheoChuyenKhoa(string chuyenKhoa, long benhNhanId)
        {
            List<DTO.LichKhamDTO> result = lichKhamDAL.TimKiemTheoChuyenKhoa(chuyenKhoa, benhNhanId);
            return result;
        }

        public List<DTO.LichKhamDTO> TimKiem(string str)
        {
            List<DTO.LichKhamDTO> result = lichKhamDAL.TimKiem(str);
            return result;
        }

        internal List<DTO.LichKhamDTO> TimKiemTheoNgayVaText(DateTime from, DateTime to, string str)
        {
            List<DTO.LichKhamDTO> rawList = TimKiem(str);
            List<DTO.LichKhamDTO> result = rawList
                .Where(lk => lk.NgayKham >= from && lk.NgayKham <= to)
                .ToList();
            return result;

        }

        public bool UpdateTrangThai(DTO.LichKhamDTO lichKham)
        {
            return lichKhamDAL.UpdateTrangThai(lichKham);
        }

        // Huy
        public List<DTO.LichKhamDTO> TimKiemTheoBacSi(string tenBacSi, long benhNhanId)
        {
            // Truyền giá trị int của enum vào câu truy vấn SQL
            return lichKhamDAL.GetByMaBenhNhan(benhNhanId)
                .Where(lk => lk.BacSi.HoTen.ToLower().Contains(tenBacSi.ToLower()))
                .ToList();
        }
    }
}