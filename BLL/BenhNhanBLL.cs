using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class BenhNhanBLL
    {
        private readonly BenhNhanDAL dal;

        public BenhNhanBLL()
        {
            this.dal = new BenhNhanDAL();
        }

        public BenhNhan Create(BenhNhan newBenhNhan)
        {
            var benhNhan = dal.Create(newBenhNhan);
            return benhNhan;
        }

        public BenhNhan GetById(long id)
        {
            return dal.GetById(id);
        }

        public BenhNhan GetByUserID(long userID)
        {
            var user = dal.GetByUserID(userID);
            return user;
        }
    }
}
