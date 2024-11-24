using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System.Collections.Generic;

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
        public List<ChiTietToaThuocDTO> GetAll()
        {
            return chiTietToaThuocDAL.GetAll();
        }

        // Lấy theo mã toa thuốc
        public List<ChiTietToaThuocDTO> GetChiTietByMaTT(long maTT)
        {
            // Thực hiện nghiệp vụ hoặc xử lý dữ liệu nếu cần
            return chiTietToaThuocDAL.GetByMaTT(maTT);
        }

        public bool AddChiTietToaThuoc(List<ChiTietToaThuocDTO> danhSachChiTiet)
        {
            foreach (var chiTiet in danhSachChiTiet)
            {
                if (!chiTietToaThuocDAL.AddChiTietToaThuoc(chiTiet))
                {
                    return false; // Nếu một dòng không thành công, trả về false
                }
            }
            return true;
        }
    }
}
