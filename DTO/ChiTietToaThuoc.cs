using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class ChiTietToaThuoc
    {
        public long MaTT { get; set; } // Primary Key
        public long MaThuoc { get; set; } // Primary Key
        public int SoLuong { get; set; }
        public string CachDung { get; set; }

        public ToaThuoc ToaThuoc { get; set; } = new ToaThuoc();
        public KhoThuoc Thuoc { get; set; } = new KhoThuoc();
    }
}
