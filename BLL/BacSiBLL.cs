using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public BacSi GetByMaBS(long MaBS)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    BacSi result = context.BacSi.FirstOrDefault(bs => bs.MaSo == MaBS);
                    if (result == null)
                    {
                        Console.WriteLine("Khong ton tai BacSi voi MaBS " + MaBS.ToString() + ".\n");
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR - Khong the lay BacSi bang MaBS: " + ex.Message);
                return null;
            }
        }

    }
}