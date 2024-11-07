using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLPhongMachTu_DOAN_.DTO
{
    [Table("HoaDonKhamBenh")]
    public class HoaDonKhamBenh
    {
        [Key]
        public long MaHDKB { get; set; }

        [ForeignKey("BenhNhan")]
        public long MaBN { get; set; }

        [ForeignKey("BacSi")]
        public long MaBS { get; set; }

        [ForeignKey("PhieuKham")]
        public long MaPK { get; set; }

        public double TongTien { get; set; }

        public BenhNhan BenhNhan { get; set; }
        public BacSi BacSi { get; set; }
        public PhieuKham PhieuKham { get; set; }
    }
}
