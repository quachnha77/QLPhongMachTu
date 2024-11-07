using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLPhongMachTu_DOAN_.DTO
{
    [Table("PhanQuyen")]
    public class PhanQuyen
    {
        [Key]
        public long MaPQ { get; set; }
        [Required]
        public string TenQuyen { get; set; }
        [Required]
        public string ChucNang { get; set; }
        public string MoTa { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
