using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class User
    {
        [Key]
        public long MaUser { get; set; }

        [ForeignKey("PhanQuyen")]
        public long MaPQ { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public PhanQuyen PhanQuyen { get; set; }
    }
}
