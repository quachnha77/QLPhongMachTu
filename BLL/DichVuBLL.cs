using QLPhongMachTu_DOAN_.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class DichVuBLL
    {
        private readonly DichVuDAL dichVuDAL;

        public DichVuBLL()
        {
            dichVuDAL = new DichVuDAL();
        }

        public DTO.DichVu GetByMaDV(long MaDV)
        {
            return dichVuDAL.GetByMaDV(MaDV);
        }

        // Phương thức để lấy đơn giá dịch vụ dựa trên mã dịch vụ
        public double LayDonGiaDichVu(long maDV)
        {
            return dichVuDAL.LayDonGiaDichVu(maDV);
        }
    }
}