using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DTO
{
    public class BenhNhan : BaseConNguoi
    {
        [Key]
        public long MaBN { get; set; }
    }
}
