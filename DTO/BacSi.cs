using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class BacSi : BaseConNguoi
    {
        [ForeignKey("PhongKhoa")]
        public long MaKhoa { get; set; }
        public virtual PhongKhoa PhongKhoa { get; set; }
    }
}
