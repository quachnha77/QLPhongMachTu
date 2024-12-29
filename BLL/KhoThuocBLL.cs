using System.Collections.Generic;
using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class KhoThuocBLL
    {
        // Quách Thanh Nhã
        private readonly KhoThuocDAL khoThuocDAL;

        public KhoThuocBLL()
        {
            khoThuocDAL = new KhoThuocDAL();
        }

        // Phương thức lấy tất cả thuốc từ DAL
        public List<KhoThuocDTO> GetAll()
        {
            return khoThuocDAL.GetAll();
        }

        // Lấy thuốc theo mã thuốc
        public KhoThuocDTO GetByMaThuoc(long maThuoc)
        {
            return khoThuocDAL.GetByMaThuoc(maThuoc);
        }

        // Tìm kiếm thuốc
        public List<KhoThuocDTO> TimKiemThuoc(string keyword)
        {
            return khoThuocDAL.TimKiemThuoc(keyword);
        }

        // Hoàng Khanh *********************
        public bool NhapThuoc(KhoThuocDTO thuoc)
        {
            return khoThuocDAL.NhapThuoc(thuoc);
        }

        public List<KhoThuocDTO> SearchMedicines(string keyword)
        {
            return khoThuocDAL.Search(keyword);
        }

        public bool UpdateThuoc(KhoThuocDTO thuoc)
        {
            return khoThuocDAL.UpdateThuoc(thuoc);
        }
    }
}
