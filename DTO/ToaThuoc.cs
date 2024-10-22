using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class ToaThuoc
    {
        [Key]
        public long MaTT { get; set; }

        [ForeignKey("BenhNhan")]
        public long MaBN { get; set; }
        
        [ForeignKey("BacSi")]
        public long MaBS { get; set; }
        
        [ForeignKey("LichKham")]
        public long MaLK { get; set; }
        
        [ForeignKey("PhieuKham")]
        public long MaPK { get; set; }
        
        public DateTime NgayKeToa { get; set; }

        public BenhNhan BenhNhan { get; set; }
        public BacSi BacSi { get; set; }
        public PhieuKham PhieuKham { get; set; }
        public LichKham LichKham { get; set; }
    }
}
