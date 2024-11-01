using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class TaiKhoan
    {
<<<<<<< HEAD:DTO/TaiKhoan.cs
        public long MaTK { get; set; }
        public long MaQuyen { get; set; }
=======
        [Key]
        public long MaUser { get; set; }

        [ForeignKey("PhanQuyen")]
        public long MaPQ { get; set; }
>>>>>>> ConKienHuy:DTO/User.cs
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual PhanQuyen PhanQuyen { get; set; }
    }
}
