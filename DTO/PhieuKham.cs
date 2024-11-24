using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class PhieuKham
    {
        [Key]
        public long MaPK { get; set; }

        [ForeignKey("LichKham")]
        public long MaLK { get; set; }

        [ForeignKey("BenhNhan")]
        public long MaBN { get; set; }

        [ForeignKey("BacSi")]
        public long MaBS { get; set; }

        public DateTime NgayKham { get; set; }
        public int SoThuTu { get; set; }
        [Required]
        public string TrieuChung { get; set; }
        [Required]
        public string TieuSuBenhLy { get; set; }
        [Required]
        public string ChuanDoan { get; set; }

        // Thuộc tính mới cho "Lời dặn bác sĩ"
        public string LoiDanBacSi { get; set; }

        public LichKham LichKham { get; set; }
        public BenhNhan BenhNhan { get; set; }
        public BacSi BacSi { get; set; }

    }
}
