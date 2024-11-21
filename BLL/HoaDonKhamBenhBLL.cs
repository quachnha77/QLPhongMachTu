using System;
using System.Collections.Generic;
using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class HoaDonKhamBenhBLL
    {
        private HoaDonKhamBenhDAL dal;

        public HoaDonKhamBenhBLL()
        {
            this.dal = new HoaDonKhamBenhDAL();
        }

        public List<HoaDonKhamBenh> GetAllByMaBN(long MaBN)
        {
            var listHoaDon = dal.GetAllByMaBN(MaBN);
            return listHoaDon;
        }

        public bool ThanhToanHoaDon(long maHDKB)
        { /* BLL xử lý phần trạng thái hóa đơn,
             và truyền 2 tham số vào dal để truy vấn Update */
            int trangThai = Convert.ToInt32(Enums.ETrangThaiHoaDon.DaThanhToan);
            
            var result = dal.ThanhToanHoaDon(maHDKB, trangThai);
            return result; // Null hoặc khác null
        }

        public List<HoaDonKhamBenh> TimKiemByTongTien(string tongSoTienStr)
        {
            double tongSoTien = Convert.ToDouble(tongSoTienStr);
            return dal.TimKiemByTongSoTien(tongSoTien);
        }
        
        public List<HoaDonKhamBenh> TimKiemByTrangThai(string trangThaiStr)
        {
            // int trangThai = (Enums.ETrangThaiHoaDon)trangThaiStr;
            // return dal.TimKiemByTrangThai(tongSoTien);
            return null;
        }

    }
}