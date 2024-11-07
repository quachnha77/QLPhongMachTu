using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLPhongMachTu_DOAN_.DTO
{
    [Table("NhapThuoc")]
    public class NhapThuoc
    {
        [Key]
        public long MaPN { get; set; }
        public long MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public string NhaCungCap { get; set; }
        public DateTime NgayNhap { get; set; }
        public DateTime HSD { get; set; }
        public string LoaiThuoc { get; set; }
        public int SoLuong { get; set; }
        public double GiaNhap { get; set; }
    }
}
