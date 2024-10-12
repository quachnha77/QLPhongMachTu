using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class BacSi : BaseConNguoi
    {
        public long MaKhoa { get; set; }
        public PhongKhoa Khoa { get; set; } = new PhongKhoa();
    }
}
