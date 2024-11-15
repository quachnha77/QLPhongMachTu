using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class HoaDonThuocBLL
    {
        private readonly HoaDonThuocDAL hoaDonThuocDAL;
        private readonly ToaThuocBLL toaThuocBLL; // để TimKiemHoaDon 
 
        public HoaDonThuocBLL()
        {
            hoaDonThuocDAL = new HoaDonThuocDAL();
            toaThuocBLL = new ToaThuocBLL();
        }

        public List<HoaDonThuoc> GetAll()
        {
            return hoaDonThuocDAL.GetAll();
        }

        public List<HoaDonThuoc> GetByMaTT(long MaTT)
        {
            return hoaDonThuocDAL.GetByMaTT(MaTT);
        }

        public List<HoaDonThuoc> TimKiemHoaDon(long MaBN, int selectedSearchTerm, string searchStr, int selectedTrangThai, DateTime? ngayTao)
        {
            List<HoaDonThuoc> result = GetAll();

            //result = result.Where(hd => hd.ToaThuoc != null && hd.ToaThuoc.BenhNhan.MaBN == MaBN).ToList();
            List<long> DSMaTT = toaThuocBLL.GetAll().Where(tt => tt.MaBN == MaBN).Select(tt => tt.MaTT).ToList();
            result = result.Where(hd => DSMaTT.Contains(hd.MaTT)).ToList();

            // Lọc theo Mã 
            if (!string.IsNullOrEmpty(searchStr))
            {
                result = result.Where(hd => hd.MaDT.ToString().Contains(searchStr)).ToList();
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
            if (ngayTao.HasValue)
            {
                result = result.Where(hd => hd.NgayMua.Date == ngayTao.Value.Date).ToList();
            }

            return result;
        }
    }
}
