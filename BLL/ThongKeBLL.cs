using QLPhongMachTu_DOAN_.DAL;
using System;
using System.Data;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class ThongKeBLL
    {
        private ThongKeDAL tkdal;

        public ThongKeBLL()
        {
            this.tkdal = new ThongKeDAL();
        }

        public DataTable GetInventoryStatusAndExpiry(string trangThai)
        {
            return tkdal.GetInventoryStatusAndExpiry(trangThai);
        }


        public DataTable GetRevenueDataByFilter(DateTime fromDate, DateTime toDate, string filterType)
        {
            return tkdal.GetRevenueDataByFilter(fromDate, toDate, filterType);
        }
    }
}
