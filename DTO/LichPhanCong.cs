using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class LichPhanCong
    {
        [Key]
        public long MaLPC { get; set; }

        [ForeignKey("LichKham")]
        public long MaLK { get; set; }

        [ForeignKey("NhanVien")]
        public long MaNV { get; set; }

        [ForeignKey("BacSi")]
        public long MaBS { get; set; }
        public DateTime NgayThucHien { get; set; }
        public DateTime ThoiGian { get; set; }
        public string GhiChu { get; set; }

        //public string TrangThai { get; set; }

        public LichKhamDTO LichKham { get; set; }
        public NhanVien NhanVien { get; set; }
        public BacSi BacSi { get; set; }
    }
}
