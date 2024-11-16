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

        // Phương thức lấy tất cả thuốc từ DAL
        public List<ChiTietToaThuoc> GetAll()
        {
            return chiTietToaThuocDAL.GetAll();
        }

        //// Lấy thuốc theo mã thuốc
        //public KhoThuoc GetByMaThuoc(long maThuoc)
        //{
        //    return chiTietToaThuocDAL.GetByMaThuoc(maThuoc);
        //}
    }
}
