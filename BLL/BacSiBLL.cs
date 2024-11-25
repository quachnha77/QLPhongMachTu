using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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

        public string GetKhoaByMa(long ma)
        {
            return dal.GetKhoaByMa(ma);
        }

        public BacSi GetBacSiByMa(long ma)
        {
            return dal.GetBacSiByMa(ma);
        }

        public bool UpdateBacSi(BacSi bs)
        {
            return dal.UpdateBacSi(bs);
        }

        public (bool, long) IsCCCDExistAndGetMaUser(long cccd)
        {
            return dal.IsCCCDExistAndGetMaUser(cccd);
        }

        public bool DeleteBacSi(long ma)
        {
            return dal.DeleteBacSi(ma);
        }

        public bool UpdateBacSiByCCCD(BacSi bs)
        {
            return dal.UpdateBacSiByCCCD(bs);
        }
    }
}
