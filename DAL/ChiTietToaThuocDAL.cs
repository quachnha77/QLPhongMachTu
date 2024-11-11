using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class ChiTietToaThuocDAL
    {
        public List<ChiTietToaThuoc> GetAll()
        {
            try
            {
                using(var context = new ApplicationDbContext())
                {
                    return context.ChiTietToaThuoc.ToList();
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("ERROR - Khong the lay DS chi tiet toa thuoc: " + ex.Message);
                return new List<ChiTietToaThuoc>();
            }
        }

        public List<ChiTietToaThuoc> GetByMaTT(long MaTT)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    List<ChiTietToaThuoc> result = context.ChiTietToaThuoc.Where(ct => ct.MaTT == MaTT).OrderByDescending(ct => ct.MaThuoc).ToList();
                    if (result == null || result.Count == 0)
                    {
                        Console.WriteLine("Khong ton tai danh sach ChiTietToaThuoc voi MaTT " + MaTT.ToString() + ".");
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR - Khong the lay danh sach ChiTietToaThuoc bang MaTT: " + ex.Message);
                return new List<ChiTietToaThuoc>();
            }
        }
    }
}
