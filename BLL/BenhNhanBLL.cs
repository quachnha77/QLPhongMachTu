using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class BenhNhanBLL
    {
        //************* QuachThanhNha
        private readonly BenhNhanDAL benhNhanDAL;

        public BenhNhanBLL()
        {
            benhNhanDAL = new BenhNhanDAL();
        }

        // Lấy tất cả bệnh nhân
        public List<BenhNhan> GetAll()
        {
            return benhNhanDAL.GetAll();
        }

        public BenhNhan GetBenhNhanByMaBN(long maBN)
        {
            return benhNhanDAL.GetBenhNhanByMaBN(maBN);
        }


        //**************ConKienHuy
        public BenhNhan Create(BenhNhan newBenhNhan)
        {
            var benhNhan = benhNhanDAL.Create(newBenhNhan);
            return benhNhan;
        }

        public BenhNhan GetById(long id)
        {
            return benhNhanDAL.GetById(id);
        }

        public BenhNhan GetByUserID(long userID)
        {
            var user = benhNhanDAL.GetByUserID(userID);
            return user;
        }
    }
}