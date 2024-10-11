using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class HoaDonKhamBenh
    {
        public long MaHDKB { get; set; }
        public long MaBN { get; set; }
        public long MaBS { get; set; }
        public long MaPK { get; set; }
        public double TongTien { get; set; }

        public BenhNhan BenhNhan { get; set; }
        public BacSi BacSi { get; set; }
        public PhieuKham PhieuKham { get; set;s }
    }
}
