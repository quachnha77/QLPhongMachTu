using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class HoaDonKhamBenhBLL
    {        
        private readonly HoaDonKhamBenhDAL hoaDonKhamBenhDAL;

        public HoaDonKhamBenhBLL()
        {
            hoaDonKhamBenhDAL = new HoaDonKhamBenhDAL();
        }

        public List<HoaDonKhamBenh> GetAll()
        {
            return hoaDonKhamBenhDAL.GetAll();
        }

        public List<HoaDonKhamBenh> GetByMaBN(long MaBN)
        {
            return hoaDonKhamBenhDAL.GetByMaBN(MaBN);
        }
        public HoaDonKhamBenh GetByMaHDKB(long MaHDKB)
        {
            return hoaDonKhamBenhDAL.GetByMaHDKB(MaHDKB);
        }

        public List<HoaDonKhamBenh> GetByMaPK(long MaPK)
        {
            return hoaDonKhamBenhDAL.GetByMaPK(MaPK);
        }

        public List<HoaDonKhamBenh> TimKiemThanhToan(long MaBN, string searchStr, string searchTerm, int TrangThai, DateTime? NgayTao)
        {
            return hoaDonKhamBenhDAL.TimKiemThanhToan(MaBN, searchStr, searchTerm, TrangThai, NgayTao);
        }

        public bool SetThanhToan(long MaHDKB, int TrangThai)
        {
            return hoaDonKhamBenhDAL.SetThanhToan(MaHDKB, TrangThai);
        }
    }
}
