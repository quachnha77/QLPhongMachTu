using System.ComponentModel.DataAnnotations.Schema;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class BacSi : BaseConNguoi
    {
        [ForeignKey("PhongKhoa")]
        public long MaKhoa { get; set; }
        public virtual PhongKhoa PhongKhoa { get; set; }
    }
}
