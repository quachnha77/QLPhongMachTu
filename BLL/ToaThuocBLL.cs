using System;
using System.Collections.Generic;
using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
namespace QLPhongMachTu_DOAN_.BLL
{
    public class ToaThuocBLL
    {
        // Quách Thanh Nhã
        private ToaThuocDAL toaThuocDAL;

        public ToaThuocBLL()
        {
            toaThuocDAL = new ToaThuocDAL();
        }

        // Phương thức để lấy tất cả các toa thuốc (nếu cần sử dụng trong giao diện)
        public List<ToaThuocDTO> GetAll()
        {
            try
            {
                return toaThuocDAL.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách toa thuốc: {ex.Message}");
                return new List<ToaThuocDTO>();
            }
        }

        // Lấy theo mã bệnh nhân
        public List<ToaThuocDTO> GetByMaBN(long maBN)
        {
            return toaThuocDAL.GetByMaBN(maBN);
        }


        // Lấy theo mã PK
        public ToaThuocDTO GetByMaPK(long maPK)
        {
            return toaThuocDAL.GetByMaPK(maPK);
        }

        public List<ToaThuocDTO> GetByMaBNAndMaLK(long maPK, long maLK)
        {
            return toaThuocDAL.GetByMaBNAndMaLK(maPK, maLK);
        }

        // Phương thức để lưu toa thuốc vào cơ sở dữ liệu
        public bool UpdateToaThuoc(ToaThuocDTO toaThuoc)
        {
            try
            {
                // Gọi phương thức lưu toa thuốc trong DAL
                return toaThuocDAL.UpdateToaThuoc(toaThuoc);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi xảy ra
                Console.WriteLine($"Lỗi khi lưu toa thuốc: {ex.Message}");
                return false;
            }
        }

        public long AddToaThuoc(ToaThuocDTO toaThuoc)
        {
            // Kiểm tra tính hợp lệ của dữ liệu nếu cần
            if (toaThuoc == null)
                throw new ArgumentNullException(nameof(toaThuoc), "Toa thuốc không được để trống.");

            return toaThuocDAL.AddToaThuoc(toaThuoc);
        }

        // Minh Thắng
        public ToaThuocDTO GetByMaTT(long MaTT)
        {
            return toaThuocDAL.GetByMaTT(MaTT);
        }

        public bool PhatThuoc(long MaTT)
        {
            return toaThuocDAL.PhatThuoc(MaTT);
        }

    }
}
