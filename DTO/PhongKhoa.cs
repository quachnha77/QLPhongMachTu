using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLPhongMachTu_DOAN_.DTO
{
    [Table("PhongKhoa")]
    public class PhongKhoa
    {
        [Key]
        public long MaPK { get; set; }
        public string TenPhongBan { get; set; }
        public string ChuyenKhoa { get; set; }
    }
}
