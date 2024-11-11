using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class HoaDonThuocBLL
    {
        private readonly HoaDonThuocDAL hoaDonThuocDAL;

        public HoaDonThuocBLL()
        {
            hoaDonThuocDAL = new HoaDonThuocDAL();
        }

        public List<HoaDonThuoc> GetAll()
        {
            return hoaDonThuocDAL.GetAll();
        }

        public List<HoaDonThuoc> GetByMaTT(long MaTT)
        {
            return hoaDonThuocDAL.GetByMaTT(MaTT);
        }
    }
}
