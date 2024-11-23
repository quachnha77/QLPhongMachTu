using DAL;
using DTO;

namespace BLL
{
    public class KhoThuocBLL
    {
        private readonly KhoThuocDAL khoThuocDAL;

        public KhoThuocBLL()
        {
            khoThuocDAL = new KhoThuocDAL();
        }

        public List<KhoThuocDTO> GetAll()
        {
            return khoThuocDAL.GetAll();
        }

        public KhoThuocDTO GetByMaThuoc(long maThuoc)
        {
            return khoThuocDAL.GetByMaThuoc(maThuoc);
        }

        public bool AddOrUpdateThuoc(KhoThuocDTO thuoc)
        {
            // Kiểm tra nếu thuốc đã tồn tại
            var existingMedicine = khoThuocDAL.GetByMaThuoc(thuoc.MaThuoc);
            if (existingMedicine != null)
            {
                // Thuốc đã tồn tại, tiến hành cập nhật
                return khoThuocDAL.UpdateThuoc(thuoc);
            }
            else
            {
                // Thuốc chưa tồn tại, tiến hành thêm mới
                return khoThuocDAL.AddThuoc(thuoc);
            }
        }

        public List<KhoThuocDTO> SearchMedicines(string keyword)
        {
            return khoThuocDAL.Search(keyword);
        }
    }
}

