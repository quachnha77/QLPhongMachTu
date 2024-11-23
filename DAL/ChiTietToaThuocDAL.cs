using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class ChiTietToaThuocDAL : DatabaseHelper
    {
        public List<ChiTietToaThuoc> GetAll()
        {
            try
            {
                string query = "SELECT * FROM ChiTietToaThuocs";
                DataTable result = ExecuteQuery(query);

                if (result.Rows.Count == 0)
                {
                    Console.WriteLine($"Không tồn tại các Chi tiết toa thuốc nào.");
                    return new List<ChiTietToaThuoc>();
                }

                List<ChiTietToaThuoc> chiTietToaThuocList = new List<ChiTietToaThuoc>();
                foreach (DataRow row in result.Rows)
                {
                    ChiTietToaThuoc hoaDon = new ChiTietToaThuoc
                    {
                        MaThuoc = Convert.ToInt64(row["MaThuoc"]),
                        MaTT = Convert.ToInt64(row["MaTT"]),
                        SoLuong = Convert.ToInt32(row["SoLuong"]),
                        CachDung = Convert.ToString(row["CachDung"])
                    };
                    chiTietToaThuocList.Add(hoaDon);
                }

                return chiTietToaThuocList;

            }
            catch (Exception ex)
            {
                string errorMessage = $"ERROR::ChiTietToaThuocDAL::GetAll() - Không thể lấy danh sách ChiTietToaThuoc: {ex.Message}";
                return new List<ChiTietToaThuoc>();
            }
        }

        public List<ChiTietToaThuoc> GetByMaTT(long MaTT)
        {
            try
            {
                string query = "SELECT * FROM ChiTietToaThuocs WHERE MaTT = @MaTT ORDER BY MaThuoc DESC";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaTT", MaTT)
                };
                DataTable result = ExecuteQuery(query, parameters);

                if (result.Rows.Count == 0)
                {
                    Console.WriteLine($"Không tồn tại các Chi tiết toa thuốc với MaTT {MaTT}.");
                    return new List<ChiTietToaThuoc>();
                }

                List<ChiTietToaThuoc> chiTietToaThuocList = new List<ChiTietToaThuoc>();
                foreach (DataRow row in result.Rows)
                {
                    ChiTietToaThuoc hoaDon = new ChiTietToaThuoc
                    {
                        MaThuoc = Convert.ToInt64(row["MaThuoc"]),
                        MaTT = Convert.ToInt64(row["MaTT"]),
                        SoLuong = Convert.ToInt32(row["SoLuong"]),
                        CachDung = Convert.ToString(row["CachDung"])
                    };
                    chiTietToaThuocList.Add(hoaDon);
                }

                return chiTietToaThuocList;

            }
            catch (Exception ex)
            {
                string errorMessage = $"ERROR::ChiTietToaThuocDAL::GetByMaTT() - Không thể lấy danh sách ChiTietToaThuoc bằng MaTT {MaTT}: {ex.Message}";
                return new List<ChiTietToaThuoc>();
            }
        }
    }
}
