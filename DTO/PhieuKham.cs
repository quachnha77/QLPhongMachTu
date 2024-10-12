using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class PhieuKham
    {
        public long MaPK { get; set; } // Key
        public long MaLK { get; set; } // Foreign Key
        public long MaBN { get; set; }
        public long MaBS { get; set; }
        public DateTime NgayKham { get; set; }
        public int SoThuTu { get; set; }
        public string TrieuChung { get; set; }
        public string TieuSuBenhLy { get; set; }
        public string ChuanDoan { get; set; }

        public LichKham LichKham { get; set; }
        public BenhNhan BenhNhan { get; set; }
        public BacSi BacSi { get; set; }

    }
}
