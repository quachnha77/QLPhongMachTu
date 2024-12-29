using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class PhieuKhamDichVu
    {
        [Key]
        [Column(Order = 0)]
        public long MaPK { get; set; }  // Mã phiếu khám, khóa ngoại

        [Key]
        [Column(Order = 1)]
        public long MaDV { get; set; }  // Mã dịch vụ, khóa ngoại

        public int SoLuong { get; set; }  // Mã dịch vụ, khóa ngoại

        public double Gia { get; set; }  // Đơn giá của dịch vụ tại thời điểm khám
    }
}
