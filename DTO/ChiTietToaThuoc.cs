using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLPhongMachTu_DOAN_.DTO
{
    [Table("ChiTietToaThuoc")]
    public class ChiTietToaThuoc
    {
        public long MaTT { get; set; } // Primary Key
        public long MaThuoc { get; set; } // Primary Key
        public int SoLuong { get; set; }
        public string CachDung { get; set; }

        public ToaThuoc ToaThuoc { get; set; }
        public KhoThuoc Thuoc { get; set; }
    }
}
