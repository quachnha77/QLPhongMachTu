using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class HoaDonThuoc
    {
        [Key]
        public long MaDT { get; set; }

        [ForeignKey("ToaThuoc")]
        public long MaTT { get; set; }

        [ForeignKey("NhanVien")]
        public long MaNV { get; set; }
        public DateTime NgayMua { get; set; }
        public double TongTien { get; set; }

        public ToaThuoc ToaThuoc { get; set; }
        public NhanVien NhanVien { get; set; }

    }
}
