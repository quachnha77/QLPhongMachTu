using System.Collections.Generic;
using System.Linq;

using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class PhieuKhamDichVuBLL
    {
        private readonly PhieuKhamDichVuDAL phieuKhamDVDAL;

        public PhieuKhamDichVuBLL()
        {
            phieuKhamDVDAL = new PhieuKhamDichVuDAL();
        }

        // Lấy tất cả các lịch khám
        public List<PhieuKhamDichVu> GetAll()
        {
            return phieuKhamDVDAL.GetAll();
        }

        public List<long> GetDichVuByMaPK(long maPK)
        {
            // Lấy danh sách PhieuKhamDichVu theo maPK
            var phieuKhamDichVus = phieuKhamDVDAL.GetByMaPK(maPK);

            // Trả về danh sách các mã dịch vụ
            return phieuKhamDichVus.Select(pkdv => pkdv.MaDV).ToList();
        }

        public List<PhieuKhamDichVu> GetByMaPK(long maPK)
        {
            // Lấy danh sách PhieuKhamDichVu theo maPK
            return phieuKhamDVDAL.GetByMaPK(maPK);
        }

        public void LuuDichVu(PhieuKhamDichVu phieuKhamDichVu)
        {
            var phieuKhamDichVuDAL = new PhieuKhamDichVuDAL();
            phieuKhamDichVuDAL.Add(phieuKhamDichVu); // Thực hiện lưu vào cơ sở dữ liệu
        }


    }
}
