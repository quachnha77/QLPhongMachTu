using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    internal class DichVu
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
