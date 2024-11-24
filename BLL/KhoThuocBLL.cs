using System.Collections.Generic;
using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class KhoThuocBLL
    {
        private readonly KhoThuocDAL khoThuocDAL;

        public KhoThuocBLL()
        {
            khoThuocDAL = new KhoThuocDAL();
        }

        // Phương thức lấy tất cả thuốc từ DAL
        public List<KhoThuoc> GetAll()
        {
            return khoThuocDAL.GetAll();
        }

        // Lấy thuốc theo mã thuốc
        public KhoThuoc GetByMaThuoc(long maThuoc)
        {
            return khoThuocDAL.GetByMaThuoc(maThuoc);
        }

        // Tìm kiếm thuốc
        public List<KhoThuoc> TimKiemThuoc(string keyword)
        {
            return khoThuocDAL.TimKiemThuoc(keyword);
        }
    }
}
