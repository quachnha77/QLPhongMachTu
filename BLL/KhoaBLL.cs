using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System.Collections.Generic;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class KhoaBLL
    {
        private readonly KhoaDAL dal;

        public KhoaBLL()
        {
            this.dal = new KhoaDAL();
        }

        public List<PhongKhoa> GetAll()
        {
            return dal.GetAll();
        }

        public PhongKhoa GetById(long id)
        {
            return dal.GetById(id);
        }

        public PhongKhoa GetByChuyenKhoa(string chuyenKhoa)
        {
            return dal.GetByChuyenKhoa(chuyenKhoa);
        }
    }
}
