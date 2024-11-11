using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class ToaThuocBLL
    {
        private ToaThuocDAL toaThuocDAL;

        public ToaThuocBLL()
        {
            toaThuocDAL = new ToaThuocDAL();
        }

        public List<ToaThuoc> GetAll()
        {
            return toaThuocDAL.GetAll();
        }

        public ToaThuoc GetByMaTT(long MaTT)
        {
            return toaThuocDAL.GetByMaTT(MaTT);
        }

        public List<ToaThuoc> GetByMaBN(long MaBN)
        {
            return toaThuocDAL.GetByMaBN(MaBN);
        }

    }
}
