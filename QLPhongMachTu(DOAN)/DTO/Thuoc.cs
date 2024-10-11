using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class KhoThuoc
    {
        public long MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public double DonGia { get; set; }
        public string DonVi { get; set; }
        public string NhaCungCap { get; set; }
        public DateTime NgayNhap { get; set; }
        public DateTime HSD { get; set; }
        public int SoLuongTon { get; set; }
    }
}
