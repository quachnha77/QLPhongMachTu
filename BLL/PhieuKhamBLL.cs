using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System.Collections.Generic;
using System.Linq;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class PhieuKhamBLL
    {
        private readonly PhieuKhamDAL phieuKhamDAL;

        public PhieuKhamBLL()
        {
            phieuKhamDAL = new PhieuKhamDAL();
        }

        // Lấy tất cả các lịch khám
        public List<PhieuKham> GetAll()
        {
            return phieuKhamDAL.GetAll();
        }

        public PhieuKham GetByMaLK(long maLK)
        {
            return phieuKhamDAL.GetByMaLK(maLK);
        }

        public PhieuKham GetByMaPK(long maPK)
        {
            return phieuKhamDAL.GetByMaPK(maPK);
        }

        public PhieuKham GetByMaBN(long maBN)
        {
            return phieuKhamDAL.GetByMaBN(maBN);
        }

        public bool CapNhatPhieuKham(PhieuKham phieuKham)
        {
            // Gọi hàm cập nhật từ lớp PhieuKhamDAL và trả về kết quả
            return new PhieuKhamDAL().UpdatePhieuKham(phieuKham);
        }

        // Huy
        public List<PhieuKham> GetAllByMaBN(long maBN)
        {
            return phieuKhamDAL.GetAll().Where(pk => pk.MaBN == maBN).ToList();
        }
    }
}
