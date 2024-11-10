using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class DichVuDAL
    {
        public double LayDonGiaDichVu(long maDV)
        {
            using (var context = new ApplicationDbContext())
            {
                // Tìm dịch vụ có mã dịch vụ tương ứng và lấy giá
                var dichVu = context.DichVu.FirstOrDefault(dv => dv.MaDV == maDV);
                if (dichVu != null)
                {
                    return dichVu.DonGia;
                }
                else
                {
                    // Nếu không tìm thấy dịch vụ, trả về 0 hoặc giá trị mặc định
                    return 0;
                }
            }
        }
    }
}
