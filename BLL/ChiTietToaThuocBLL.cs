using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class ChiTietToaThuocBLL
    {
        private readonly ChiTietToaThuocDAL chiTietToaThuocDAL;

        public ChiTietToaThuocBLL()
        {
            chiTietToaThuocDAL = new ChiTietToaThuocDAL();
        }
        
        public List<ChiTietToaThuoc> GetAll()
        {
            return chiTietToaThuocDAL.GetAll();
        }

        public List<ChiTietToaThuoc> GetByMaTT(long MaTT)
        {
            return chiTietToaThuocDAL.GetByMaTT(MaTT);
        }
    }
}
