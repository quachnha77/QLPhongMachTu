using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class ToaThuoc
    {
        public long MaTT { get; set; }
        public long MaBN { get; set; }
        public long MaBS { get; set; }
        public long MaLK { get; set; }
        public long MaPK { get; set; }
        public DateTime NgayKeToa { get; set; }

        public BenhNhan BenhNhan { get; set; } = new BenhNhan();
        public BacSi BacSi { get; set; } = new BacSi();
        public PhieuKham PhieuKham { get; set; } = new PhieuKham();
        public LichKham LichKham { get; set; } = new LichKham();
    }
}
