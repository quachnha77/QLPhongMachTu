using QLPhongMachTu_DOAN_.DAL;
using System;
using System.Collections.Generic;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class PhongKhoaBLL
    {
        private readonly PhongKhoaDAL pkDAL;

        public PhongKhoaBLL()
        {
            this.pkDAL = new PhongKhoaDAL();
        }

        public List<string> GetName()
        {
            return pkDAL.GetName();
        }

        public long GetMaKhoaByName(string name)
        {
            return pkDAL.GetMaKhoaByName(name);
        }
    }
}
