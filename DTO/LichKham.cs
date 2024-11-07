using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class LichKham
    {
        [Key]
        public long MaLK { get; set; }  // Mã Lịch Khám - Khóa chính

        [ForeignKey("BacSi")]
        public long MaBS { get; set; }  // Mã Bác Sĩ - Khóa ngoại liên kết với BacSi

        [ForeignKey("BenhNhan")]
        public long MaBN { get; set; }  // Mã Bệnh Nhân - Khóa ngoại liên kết với BenhNhan

        public DateTime NgayKham { get; set; }  // Ngày Khám

        [ForeignKey("NhanVien")]
        public long MaNV { get; set; }  // Mã Nhân Viên - Khóa ngoại liên kết với NhanVien

        // Liên kết với các đối tượng liên quan
        public BacSi BacSi { get; set; }
        public BenhNhan BenhNhan { get; set; }
        public NhanVien NhanVien { get; set; }

        // Trạng thái của lịch khám
        public enum TrangThaiKham
        {
            ChuaKham = 1,
            DaKham = 2,
            HuyKham = 3,
        }

        public TrangThaiKham TrangThai { get; set; }

    }
}
