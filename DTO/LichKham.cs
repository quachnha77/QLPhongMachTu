using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class LichKham
    {
        [Key]
        public long MaLK { get; set; }
        
        [ForeignKey("BacSi")]
        public long MaBS { get; set; }

        [ForeignKey("BenhNhan")]
        public long MaBN { get; set; }
        public DateTime NgayKham { get; set; }
        
        [ForeignKey("NhanVien")]
        public long MaNV { get; set; }

        public BacSi BacSi { get; set; }
        public BenhNhan BenhNhan { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
