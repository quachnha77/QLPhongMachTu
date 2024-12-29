using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class DichVuBLL
    {
        private readonly DichVuDAL dichVuDAL;

        public DichVuBLL()
        {
            dichVuDAL = new DichVuDAL();
        }

        // Phương thức để lấy đơn giá dịch vụ dựa trên mã dịch vụ
        public double LayDonGiaDichVu(long maDV)
        {
            return dichVuDAL.LayDonGiaDichVu(maDV);
        }

        public DichVuDTO GetByMaDV(long maDV)
        {
            return dichVuDAL.GetByMaDV(maDV);
        }
    }
}
