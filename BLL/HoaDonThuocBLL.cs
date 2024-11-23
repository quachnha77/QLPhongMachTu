using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class HoaDonThuocBLL
    {
        private readonly HoaDonThuocDAL hoaDonThuocDAL;
        private readonly ToaThuocBLL toaThuocBLL; // để TimKiemHoaDon 
 
        public HoaDonThuocBLL()
        {
            hoaDonThuocDAL = new HoaDonThuocDAL();
            toaThuocBLL = new ToaThuocBLL();
        }

        public List<HoaDonThuoc> GetAll()
        {
            return hoaDonThuocDAL.GetAll();
        }

        public HoaDonThuoc GetByMaDT(long MaDT)
        {
            return hoaDonThuocDAL.GetByMaDT(MaDT);
        }

        public List<HoaDonThuoc> GetByMaTT(long MaTT)
        {
            return hoaDonThuocDAL.GetByMaTT(MaTT);
        }

        public List<HoaDonThuoc> TimKiemThanhToan(string searchStr, string searchTerm, int TrangThai, DateTime? NgayTao)
        {
            return hoaDonThuocDAL.TimKiemThanhToan(searchStr, searchTerm, TrangThai, NgayTao);
        }

        public bool SetThanhToan(long MaDT, int TrangThai)
        {
            return hoaDonThuocDAL.SetThanhToan(MaDT, TrangThai);
        }
    }
}
