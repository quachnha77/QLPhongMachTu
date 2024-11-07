using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLPhongMachTu_DOAN_.DTO
{
    [Table("BenhNhan")]
    public class BenhNhan : BaseConNguoi
    {
        [Key]
        public long MaBN { get; set; }

    }
}
