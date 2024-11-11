using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class HoaDonThuocDAL
    {
        public List<HoaDonThuoc> GetAll()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    return context.HoaDonThuoc.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR - Khong the lay DS HoaDonThuoc: " + ex.Message);
                return new List<HoaDonThuoc>();
            }
        }

        public List<HoaDonThuoc> GetByMaTT(long MaTT)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    List<HoaDonThuoc> result = context.HoaDonThuoc.Where(ct => ct.MaTT == MaTT).OrderByDescending(ct => ct.MaDT).ToList();
                    if (result == null || result.Count == 0)
                    {
                        Console.WriteLine("Khong ton tai danh sach HoaDonThuoc voi MaTT " + MaTT.ToString() + ".");
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR - Khong the lay danh sach HoaDonThuoc bang MaTT: " + ex.Message);
                return new List<HoaDonThuoc>();
            }
        }
    }
}
