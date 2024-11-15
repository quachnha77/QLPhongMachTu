using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class HoaDonKhamBenhBLL
    {        
        private readonly HoaDonKhamBenhDAL hoaDonKhamBenhDAL;
        private readonly PhieuKhamBLL phieuKhamBLL; // để TimKiemHoaDon

        public HoaDonKhamBenhBLL()
        {
            hoaDonKhamBenhDAL = new HoaDonKhamBenhDAL();
            phieuKhamBLL = new PhieuKhamBLL();
        }

        public List<HoaDonKhamBenh> GetAll()
        {
            return hoaDonKhamBenhDAL.GetAll();
        }

        public List<HoaDonKhamBenh> GetByMaBN(long MaBN)
        {
            return hoaDonKhamBenhDAL.GetByMaBN(MaBN);
        }

        public List<HoaDonKhamBenh> TimKiemHoaDon(long MaBN, int selectedSearchTerm, string searchStr, int selectedTrangThai, DateTime? ngayTao)
        {
            List<HoaDonKhamBenh> result = GetByMaBN(MaBN);

            // Lọc theo Mã
            if (!string.IsNullOrEmpty(searchStr))
            {
                result = result.Where(hd => hd.MaHDKB.ToString().Contains(searchStr)).ToList();
            }

            // Lọc theo Trạng thái (Đã thanh toán, Chưa thanh toán)
            if (selectedTrangThai == 0) 
            {
                result = result.Where(hd => hd.TrangThai == true).ToList();
            }
            else if (selectedTrangThai == 1) 
            {
                result = result.Where(hd => hd.TrangThai == false).ToList();
            }

            // Lọc theo Ngày tạo
            // Lấy đại NgayKham
            if (ngayTao.HasValue)
            {
                List<PhieuKham> DSPhieuKham = new List<PhieuKham>();
                foreach(var hoaDon in result)
                {
                    var phieuKham = phieuKhamBLL.GetByMaPK(hoaDon.MaPK);
                    if (!DSPhieuKham.Any(pk => pk.MaPK == phieuKham.MaPK))
                    {
                        DSPhieuKham.Add(phieuKham);
                    }
                }

                result = result.Where(hd =>
                {
                    var phieuKham = DSPhieuKham.FirstOrDefault(pk => pk.MaPK == hd.MaPK);
                    return phieuKham != null && phieuKham.NgayKham.Date == ngayTao.Value.Date;
                }).ToList();
            }

            return result;
        }
    }
}
