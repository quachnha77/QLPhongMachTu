using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class DichVuDTO
    {
        [Key]
        public long MaDV { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(255)]
        public string TenDichVu { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(500)]
        public string MoTa { get; set; }

        public double DonGia { get; set; }
    }
}
