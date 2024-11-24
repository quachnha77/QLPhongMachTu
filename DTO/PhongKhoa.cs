using System.ComponentModel.DataAnnotations;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class PhongKhoa
    {
        [Key]
        public long MaPK { get; set; }
        public string TenPhongBan { get; set; }
        public string ChuyenKhoa { get; set; }
    }
}
