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

        public bool AddOrUpdateThuoc(KhoThuocDTO thuoc)
        {
            // Kiểm tra nếu thuốc đã tồn tại
            var existingMedicine = khoThuocDAL.GetByMaThuoc(thuoc.MaThuoc);
            if (existingMedicine != null)
            {
                return khoThuocDAL.UpdateThuoc(thuoc);
            }
            else
            {
                return khoThuocDAL.AddThuoc(thuoc);
            }
        }

        public List<KhoThuocDTO> SearchMedicines(string keyword)
        {
            return khoThuocDAL.SearchKhoThuoc(keyword);
        }
    }
}
