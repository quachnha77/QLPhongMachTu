using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using QLPhongMachTu_DOAN_.GUI;
using System;
using System.Collections.Generic;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class HoaDonKhamBenhBLL
    {
        // Quách Thanh Nhã
        private HoaDonKhamBenhDAL _hoaDonKhamBenhDAL;

        public HoaDonKhamBenhBLL()
        {
            this._hoaDonKhamBenhDAL = new HoaDonKhamBenhDAL();
        }

        // Thêm mới hóa đơn khám bệnh
        public long AddHoaDonKhamBenh(HoaDonKhamBenhDTO hoaDon)
        {
            // Thêm hóa đơn vào cơ sở dữ liệu
            return _hoaDonKhamBenhDAL.AddHoaDonKhamBenh(hoaDon);
        }

        public bool CapNhatTrangThaiHoaDon(long maHDKB, string trangThai)
        {
            return _hoaDonKhamBenhDAL.UpdateTrangThaiHoaDon(maHDKB, trangThai);
        }

        // Minh Thắng
        public List<HoaDonKhamBenhDTO> GetAll()
        {
            return _hoaDonKhamBenhDAL.GetAll();
        }

        public List<HoaDonKhamBenhDTO> GetByMaBN(long MaBN)
        {
            return _hoaDonKhamBenhDAL.GetByMaBN(MaBN);
        }
        public HoaDonKhamBenhDTO GetByMaHDKB(long MaHDKB)
        {
            return _hoaDonKhamBenhDAL.GetByMaHDKB(MaHDKB);
        }

        public List<HoaDonKhamBenhDTO> GetByMaPK(long MaPK)
        {
            return _hoaDonKhamBenhDAL.GetByMaPK(MaPK);
        }

        public List<HoaDonKhamBenhDTO> TimKiemThanhToan(long MaBN, string searchStr, string searchTerm, int TrangThai, DateTime? NgayTao)
        {
            return _hoaDonKhamBenhDAL.TimKiemThanhToan(MaBN, searchStr, searchTerm, TrangThai, NgayTao);
        }

        //public bool SetThanhToan(long MaHDKB, int TrangThai)
        //{
        //    return hoaDonKhamBenhDAL.SetThanhToan(MaHDKB, TrangThai);
        //}

        // *** Huy --->
        //public List<HoaDonKhamBenh> GetAllByMaBN(long MaBN)
        //{
        //    var listHoaDon = _hoaDonKhamBenhDAL.GetAllByMaBN(MaBN);
        //    return listHoaDon;
        //}

        public bool ThanhToanHoaDon(long maHDKB)
        { /* BLL xử lý phần trạng thái hóa đơn,
             và truyền 2 tham số vào _hoaDonKhamBenhDAL để truy vấn Update */
            string trangThai = "Đã thanh toán";

            var result = _hoaDonKhamBenhDAL.ThanhToanHoaDon(maHDKB, trangThai);
            return result; // Null hoặc khác null
        }

        public List<HoaDonKhamBenhDTO> TimKiemByTongTien(string tongSoTienStr)
        {
            double tongSoTien = Convert.ToDouble(tongSoTienStr);
            return _hoaDonKhamBenhDAL.TimKiemByTongSoTien(tongSoTien);
        }

        public List<HoaDonKhamBenh> TimKiemByTrangThai(string trangThaiStr)
        {
            // int trangThai = (Enums.ETrangThaiHoaDon)trangThaiStr;
            // return _hoaDonKhamBenhDAL.TimKiemByTrangThai(tongSoTien);
            return null;
        }
        //*** Huy <---

    }
}
