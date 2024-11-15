using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class HoaDonThuocDAL : DatabaseHelper
    {
        public List<HoaDonThuoc> GetAll()
        {
            try
            {
                string query = "SELECT * FROM HoaDonThuoc";
                DataTable result = ExecuteQuery(query);

                if (result.Rows.Count == 0)
                {
                    Console.WriteLine("Không tồn tại danh sách HoaDonThuoc nào.");
                    return new List<HoaDonThuoc>();
                }

                List<HoaDonThuoc> hoaDonThuocList = new List<HoaDonThuoc>();
                foreach (DataRow row in result.Rows)
                {
                    HoaDonThuoc hoaDon = new HoaDonThuoc
                    {
                        MaDT = Convert.ToInt64(row["MaDT"]),
                        MaTT = Convert.ToInt64(row["MaTT"]),
                        MaNV = Convert.ToInt64(row["MaNV"]),
                        NgayMua = Convert.ToDateTime(row["NgayMua"]),
                        TongTien = Convert.ToDouble(row["TongTien"]),
                        // Thêm trạng thái thanh toán
                        TrangThai = Convert.ToBoolean(row["TrangThai"])
                    };
                    hoaDonThuocList.Add(hoaDon);
                }

                return hoaDonThuocList;
            }
            catch (Exception ex)
            {
                string errorMessage = $"ERROR::HoaDonThuocDAL::GetAll() - Không thể lấy danh sách HoaDonThuoc: {ex.Message}";
                Console.WriteLine(errorMessage);
                return new List<HoaDonThuoc>();
            }
        }

        public List<HoaDonThuoc> GetByMaTT(long MaTT)
        {
            try
            {
                string query = "SELECT * FROM HoaDonThuoc WHERE MaTT = @MaTT ORDER BY MaDT DESC";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaTT", MaTT)
                };
                DataTable result = ExecuteQuery(query, parameters);

                if (result.Rows.Count == 0)
                {
                    Console.WriteLine($"Không tồn tại HoaDonThuoc với MaTT {MaTT}.");
                    return new List<HoaDonThuoc>();
                }

                List<HoaDonThuoc> hoaDonThuocList = new List<HoaDonThuoc>();
                foreach (DataRow row in result.Rows)
                {
                    HoaDonThuoc hoaDon = new HoaDonThuoc
                    {
                        MaDT = Convert.ToInt64(row["MaDT"]),
                        MaTT = Convert.ToInt64(row["MaTT"]),
                        MaNV = Convert.ToInt64(row["MaNV"]),
                        NgayMua = Convert.ToDateTime(row["NgayMua"]),
                        TongTien = Convert.ToDouble(row["TongTien"]),
                        // Thêm trạng thái thanh toán
                        TrangThai = Convert.ToBoolean(row["TrangThai"])
                    };
                    hoaDonThuocList.Add(hoaDon);
                }

                return hoaDonThuocList;
            }
            catch (Exception ex)
            {
                string errorMessage = $"ERROR::HoaDonThuocDAL::GetByMaTT() - Không thể lấy danh sách HoaDonThuoc bằng MaTT {MaTT}: {ex.Message}";
                Console.WriteLine(errorMessage);
                return new List<HoaDonThuoc>();
            }
        }
    }
}
