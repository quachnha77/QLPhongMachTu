using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System.Collections.Generic;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class BacSiBLL
    {
        private readonly BacSiDAL dal;

        public BacSiBLL()
        {
            this.dal = new BacSiDAL();
        }

        public List<BacSi> GetAllByChuyenKhoa(long Makhoa)
        {
            return dal.GetAllByChuyenKhoa(Makhoa);
        }

        public BacSi GetById(long id)
        {
            return dal.GetById(id);
        }


        // Bích Nhung
        public List<BacSi> GetAllBacSi()
        {
            return dal.GetAllBacSi();
        }

        public bool AddBacSi(BacSi bs)
        {
            return dal.AddBacSi(bs);
        }
    }
}
