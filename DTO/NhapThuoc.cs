using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class NhapThuoc
    {
        public long MaPN { get; set; }
        public long MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public string NhaCungCap { get; set; }
        public DateTime NgayNhap { get; set; }
        public DateTime HSD { get; set; }
        public string LoaiThuoc { get; set; }
        public int SoLuong { get; set; }
        public double GiaNhap { get; set; }
    }
}
