using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class ToaThuocBLL
    {
        private ToaThuocDAL toaThuocDAL;

        public ToaThuocBLL()
        {
            toaThuocDAL = new ToaThuocDAL();
        }

        // Phương thức để lấy tất cả các toa thuốc (nếu cần sử dụng trong giao diện)
        public List<ToaThuoc> GetAll()
        {
            try
            {
                return toaThuocDAL.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách toa thuốc: {ex.Message}");
                return new List<ToaThuoc>();
            }
        }

        // Phương thức để lưu toa thuốc vào cơ sở dữ liệu
        public bool LuuToaThuoc(ToaThuoc toaThuoc)
        {
            try
            {
                // Gọi phương thức lưu toa thuốc trong DAL
                return toaThuocDAL.UpdateToaThuoc(toaThuoc);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi xảy ra
                Console.WriteLine($"Lỗi khi lưu toa thuốc: {ex.Message}");
                return false;
            }
        }

    }
}