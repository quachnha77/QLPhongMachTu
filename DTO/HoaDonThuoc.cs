using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class HoaDonThuoc
    {
        public long MaDT { get; set; }
        public long MaNV { get; set; }
        public DateTime NgayMua { get; set; }
        public double TongTien { get; set; }

        public ToaThuoc ToaThuoc { get; set; } = new ToaThuoc();
        public NhanVien NhanVien { get; set; } = new NhanVien();

    }
}
