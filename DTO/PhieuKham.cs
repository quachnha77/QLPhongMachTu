using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public LichKham LichKham { get; set; }
        public BenhNhan BenhNhan { get; set; }
        public BacSi BacSi { get; set; }

    }
}
