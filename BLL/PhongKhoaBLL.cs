using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class PhongKhoaBLL
    {
        private readonly PhongKhoaDAL _phongKhoaDAL;

        public PhongKhoaBLL()
        {
            _phongKhoaDAL = new PhongKhoaDAL();
        }

        public List<PhongKhoa> GetAll()
        {
            return _phongKhoaDAL.GetAll();
        }
    }
}
