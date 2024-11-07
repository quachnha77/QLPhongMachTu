using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLPhongMachTu_DOAN_.DTO
{
    [Table("BacSi")]
    public class BacSi : BaseConNguoi
    {
        [Key]
        public long MaBS { get; set; }

        [ForeignKey("PhongKhoa")]
        public long MaKhoa { get; set; }
        public virtual PhongKhoa PhongKhoa { get; set; }
    }
}
