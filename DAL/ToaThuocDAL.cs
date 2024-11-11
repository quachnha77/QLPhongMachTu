using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class ToaThuocDAL
    {
        public List<ToaThuoc> GetAll()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    return context.ToaThuoc.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR - Khong the lay DS toa thuoc: " + ex.Message);
                return new List<ToaThuoc>();
            }
        }

        public ToaThuoc GetByMaTT(long MaTT)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    ToaThuoc result = context.ToaThuoc.FirstOrDefault(tt => tt.MaTT == MaTT);
                    if (result == null)
                    {
                        Console.WriteLine("Khong ton tai ToaThuoc voi MaTT " + MaTT.ToString() + ".");
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR - Khong the lay ToaThuoc bang MaTT: " + ex.Message);
                return null;
            }
        }

        public List<ToaThuoc> GetByMaBN(long MaBN)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    return context.ToaThuoc.Where(tt => tt.MaBN == MaBN).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR - Khong the lay DS toa thuoc bang MaBN: " + ex.Message);
                return new List<ToaThuoc>();
            }
        }

    }
}
