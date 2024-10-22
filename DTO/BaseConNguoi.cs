using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    // Định nghĩa lớp cha là abstract 
    // Ko khởi tạo trực tiếp 
    // Mà cần lớp con để khởi tạo
    public abstract class BaseConNguoi
    {
        [Key]
        public long MaSo { get; set; }
        public long CCCD { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }

        [ForeignKey("User")]
        public long MaUser { get; set; }
        public TaiKhoan User { get; set; }
    }
}
