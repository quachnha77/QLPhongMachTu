using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class PhongKhoa
    {
        [Key]
        public long MaPK { get; set; }
        public string TenPhongBan { get; set;}
        public string ChuyenKhoa { get; set; }
    }
}
