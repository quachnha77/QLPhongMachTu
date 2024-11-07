using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.BLL
{
    internal class LichKhamBLL
    {
        private readonly LichKhamDAL lichKhamDAL = new LichKhamDAL();

        public LichKhamBLL()
        {
            lichKhamDAL = new LichKhamDAL();
        }

        // Lấy tất cả các lịch khám
        public List<LichKham> GetAll()
        {
            return lichKhamDAL.GetAll();
        }

        public LichKham GetByMaLK(long maLK)
        {
            return lichKhamDAL.GetByMaLK(maLK);
        }

        //// Tạo mới một lịch khám
        //public LichKham Create(LichKham newLichKham)
        //{
        //    // Kiểm tra các điều kiện hợp lệ của lịch khám nếu cần
        //    if (newLichKham.NgayKham < System.DateTime.Now)
        //    {
        //        throw new System.ArgumentException("Ngày khám không được nhỏ hơn ngày hiện tại.");
        //    }

        //    return _lichKhamDAL.Create(newLichKham);
        //}

        //// Lấy thông tin lịch khám theo MaLK
        //public LichKham GetByMaLK(long maLK)
        //{
        //    return _lichKhamDAL.GetByMaLK(maLK);
        //}

        //// Lấy danh sách lịch khám theo trạng thái
        //public List<LichKham> GetByTrangThai(int trangThai)
        //{
        //    return _lichKhamDAL.GetByTrangThai(trangThai);
        //}

        //// Cập nhật một lịch khám
        //public LichKham Update(LichKham updatedLichKham)
        //{
        //    // Kiểm tra điều kiện hợp lệ trước khi cập nhật
        //    if (updatedLichKham.NgayKham < System.DateTime.Now)
        //    {
        //        throw new System.ArgumentException("Ngày khám không được nhỏ hơn ngày hiện tại.");
        //    }

        //    return _lichKhamDAL.Update(updatedLichKham);
        //}

        //// Xóa một lịch khám
        //public bool Delete(long maLK)
        //{
        //    return _lichKhamDAL.Delete(maLK);
        //}
    }
}