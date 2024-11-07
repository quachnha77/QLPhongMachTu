using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLPhongMachTu_DOAN_.DTO
{
    [Table("KhoThuoc")]
    public class KhoThuoc
    {
        [Key]
        public long MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public double DonGia { get; set; }
        public string DonVi { get; set; }
        public string NhaCungCap { get; set; }
        public DateTime NgayNhap { get; set; }
        public DateTime HSD { get; set; }
        public int SoLuongTon { get; set; }
    }
}
