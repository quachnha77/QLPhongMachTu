using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
