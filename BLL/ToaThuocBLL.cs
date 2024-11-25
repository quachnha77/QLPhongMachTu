using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class ToaThuocBLL
    {
        private readonly ToaThuocDAL toaThuocDAL;

        public ToaThuocBLL()
        {
            toaThuocDAL = new ToaThuocDAL();
        }

        public List<ToaThuoc> GetAll()
        {
            try
            {
                return toaThuocDAL.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách toa thuốc: {ex.Message}");
                return new List<ToaThuoc>();
            }
        }

        public bool AddOrUpdateToaThuoc(ToaThuoc toaThuoc)
        {
            try
            {
                if (toaThuoc.MaTT > 0)
                {
                    return toaThuocDAL.UpdateToaThuoc(toaThuoc);
                }
                else
                {
                    return toaThuocDAL.AddToaThuoc(toaThuoc);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm hoặc cập nhật toa thuốc: {ex.Message}");
                return false;
            }
        }

        public List<ToaThuoc> SearchToaThuoc(string keyword)
        {
            var allToaThuoc = toaThuocDAL.GetAll();

            return allToaThuoc
                .Where(tt =>
                    tt.MaTT.ToString().Contains(keyword, StringComparison.OrdinalIgnoreCase) || // Chuyển đổi MaTT sang string
                    tt.MaBN.ToString().Contains(keyword, StringComparison.OrdinalIgnoreCase))   // Chuyển đổi MaBN sang string
                .ToList();
        }

        public bool ThanhToan(long maBenhNhan, decimal tongTien)
        {
            return toaThuocDAL.UpdateThanhToanBenhNhan(maBenhNhan, tongTien);
        }

        public bool PhatThuoc(long maToaThuoc)
        {
            return toaThuocDAL.UpdateTrangThaiToaThuoc(maToaThuoc, "Đã phát");
        }

        public ToaThuoc GetByMaToa(long maToa)
        {
            ToaThuoc toaThuoc = toaThuocDAL.GetToaThuocById(maToa);

            if (toaThuoc == null)
            {
                Console.WriteLine($"Không tìm thấy toa thuốc với mã: {maToa}");
                return null; 
            }

            return toaThuoc;
        }

    }
}
