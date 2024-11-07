using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLPhongMachTu_DOAN_.DTO
{
    // Định nghĩa lớp cha là abstract 
    // Ko khởi tạo trực tiếp 
    // Mà cần lớp con để khởi tạo
    public abstract class BaseConNguoi
    {
        public long CCCD { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; } = new DateTime(2001, 1, 1);
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }

        [ForeignKey("User")]
        public long MaUser { get; set; }
        public User User { get; set; }
    }
}
