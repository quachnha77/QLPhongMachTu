using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class HoaDonKhamBenhDAL : DatabaseHelper
    {
        public List<HoaDonKhamBenh> GetAll()
        {
            try
            {
                string query = "SELECT * FROM HoaDonKhamBenh";
                DataTable result = ExecuteQuery(query);

                if (result.Rows.Count == 0)
                {
                    Console.WriteLine("Không tồn tại danh sách HoaDonKhamBenh nào.");
                    return new List<HoaDonKhamBenh>();                 
                }

                List<HoaDonKhamBenh> hoaDonKhamBenhList = new List<HoaDonKhamBenh>();

                foreach (DataRow row in result.Rows)
                {
                    HoaDonKhamBenh hoaDon = new HoaDonKhamBenh
                    {
                        MaHDKB = Convert.ToInt64(row["MaHDKB"]),
                        MaBN = Convert.ToInt64(row["MaBN"]),
                        MaPK = Convert.ToInt64(row["MaPK"]),
                        TongTien = Convert.ToDouble(row["TongTien"]),
                    };
                    hoaDonKhamBenhList.Add(hoaDon);
                }

                return hoaDonKhamBenhList; 

            }
            catch (Exception ex)
            {
                string errorMessage = $"ERROR::HoaDonKhamBenhDAL::GetAll() - Không thể lấy danh sách HoaDonKhamBenh: {ex.Message}";
                Console.WriteLine(errorMessage);
                return new List<HoaDonKhamBenh>();
            }
        }

        public List<HoaDonKhamBenh> GetByMaBN(long MaBN)
        {
            try
            {
                string query = "SELECT * FROM HoaDonKhamBenh WHERE MaBN = @MaBN ORDER BY MaHDKB DESC";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaBN", MaBN)
                };
                DataTable result = ExecuteQuery(query, parameters);

                if(result.Rows.Count == 0)
                {
                    Console.WriteLine($"Không tồn tại HoaDonKhamBenh với MaBN {MaBN}.");
                    return new List<HoaDonKhamBenh>();
                }

                List<HoaDonKhamBenh> hoaDonKhamBenhList = new List<HoaDonKhamBenh>();
                foreach (DataRow row in result.Rows)
                {
                    HoaDonKhamBenh hoaDon = new HoaDonKhamBenh
                    {
                        MaHDKB = Convert.ToInt64(row["MaHDKB"]),
                        MaBN = Convert.ToInt64(row["MaBN"]),
                        MaPK = Convert.ToInt64(row["MaPK"]),
                        TongTien = Convert.ToDouble(row["TongTien"])
                    };
                    hoaDonKhamBenhList.Add(hoaDon);
                }

                return hoaDonKhamBenhList;

            }
            catch (Exception ex)
            {
                string errorMessage = $"ERROR::HoaDonKhamBenhDAL::GetByMaBN() - Không thể lấy danh sách HoaDonKhamBenh bằng MaBN {MaBN}: {ex.Message}";
                return new List<HoaDonKhamBenh>();
            }
        }

    }
}
