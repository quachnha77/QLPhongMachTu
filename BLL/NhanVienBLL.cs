using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class NhanVienBLL
    {
        private readonly NhanVienDAL dal;
        public NhanVienBLL()
        {
            this.dal = new NhanVienDAL();
        }

        public List<NhanVien> GetAll()
        {
            return dal.GetAll();
        }
    }
}
