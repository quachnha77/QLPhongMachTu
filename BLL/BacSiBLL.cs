using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class BacSiBLL
    {
        private BacSiDAL bsDAL;

        public BacSiBLL()
        {
            this.bsDAL = new BacSiDAL();
        }

        public List<BacSi> GetAllBacSi()
        {
            return bsDAL.GetAllBacSi();
        }

        public bool AddBacSi(BacSi bs)
        {
            return bsDAL.AddBacSi(bs);
        }
    }
}
