using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class LichKham
    {
        public long MaLK { get; set; }
        public long MaBS { get; set; }
        public long MaBN { get; set; }
        public DateTime NgayKham { get; set; }
        public long MaNV { get; set; }

        public BacSi BacSi { get; set; } = new BacSi();
        public BenhNhan BenhNhan { get; set; } = new BenhNhan();
        public NhanVien NhanVien { get; set; } = new NhanVien();
    }
}
