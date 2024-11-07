using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLPhongMachTu_DOAN_.DTO
{
    [Table("NhanVien")]
    public class NhanVien : BaseConNguoi
    {
        [Key]
        public long MaNV { get; set; }
        public string ChucVu { get; set; }
    }
}
