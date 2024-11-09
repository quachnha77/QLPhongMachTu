using QLPhongMachTu_DOAN_.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    // Lưu trữ các ngày làm việc của 1 bác sĩ
    public class LichPhanCong
    {
        [Key]
        public long MaLPC { get; set; }

        [ForeignKey("NhanVien")]
        public long MaNV { get; set; }

        [ForeignKey("BacSi")]
        public long MaBS { get; set; }
        public int gioBatDau { get; set; }
        public int gioKetThuc { get; set; }
        
        public DateTime NgayPhanCong { get; set; }

        public string GhiChu { get; set; }

        public NhanVien NhanVien { get; set; }
        public BacSi BacSi { get; set; }
    }
}
