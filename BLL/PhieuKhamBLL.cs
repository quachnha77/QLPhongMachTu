using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class PhieuKhamBLL
    {
        private readonly PhieuKhamDAL dal;

        public PhieuKhamBLL() => this.dal = new PhieuKhamDAL();
        
        public List<PhieuKham> GetAll()
        {
            return dal.GetAll();
        }

        public PhieuKham Create(PhieuKham newPhieuKham)
        {
            return dal.Create(newPhieuKham);
        }
    }
}
