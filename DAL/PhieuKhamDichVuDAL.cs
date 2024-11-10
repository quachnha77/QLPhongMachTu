using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.DAL
{
    internal class PhieuKhamDichVuDAL
    {
        public List<PhieuKhamDichVu> GetAll()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.PhieuKhamDichVu.ToList();
            }
        }

        // Trả về danh sách các dịch vụ theo mã phiếu khám
        public List<PhieuKhamDichVu> GetByMaPK(long maPK)
        {
            using (var context = new ApplicationDbContext())
            {
                // Tìm kiếm tất cả các dịch vụ liên quan đến MaPK
                return context.PhieuKhamDichVu
                    .Where(pkdv => pkdv.MaPK == maPK)
                    .ToList();
            }
        }

        public void Add(PhieuKhamDichVu phieuKhamDichVu)
        {
            using (var context = new ApplicationDbContext())
            {
                // Kiểm tra xem bản ghi đã tồn tại chưa
                var existingRecord = context.PhieuKhamDichVu
                    .FirstOrDefault(pkdv => pkdv.MaPK == phieuKhamDichVu.MaPK && pkdv.MaDV == phieuKhamDichVu.MaDV);

                if (existingRecord == null)
                {
                    // Nếu không tồn tại, thêm mới bản ghi
                    context.PhieuKhamDichVu.Add(phieuKhamDichVu);
                    context.SaveChanges();
                }
                else
                {
                    // Thực hiện hành động khác nếu bản ghi đã tồn tại (nếu cần)
                    Console.WriteLine("Dịch vụ đã tồn tại trong phiếu khám.");
                }
            }
        }

    }
}

