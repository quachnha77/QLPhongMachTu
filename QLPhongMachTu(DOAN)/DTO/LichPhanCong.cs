using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class LichPhanCong
    {
        public long MaLPC { get; set; }
        public long MaLK { get; set; }
        public long MaNV { get; set; }
        public long MaBS { get; set; }
        public DateTime NgayThucHien { get; set; }
        public DateTime ThoiGian { get; set; }
        public string GhiChu { get; set; }
    }
}
