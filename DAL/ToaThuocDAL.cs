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
    public class ToaThuocDAL : DatabaseHelper
    {
        public List<ToaThuoc> GetAll()
        {
            try
            {
                string query = "SELECT * FROM ToaThuoc";
                DataTable result = ExecuteQuery(query);

                if (result.Rows.Count == 0)
                {
                    Console.WriteLine("Không tồn tại danh sách ToaThuoc nào.");
                    return new List<ToaThuoc>();
                }

                List<ToaThuoc> toaThuocList = new List<ToaThuoc>();
                foreach (DataRow row in result.Rows)
                {
                    ToaThuoc toaThuoc = new ToaThuoc
                    {
                        MaTT = Convert.ToInt64(row["MaTT"]),
                        MaBN = Convert.ToInt64(row["MaBN"]),
                        MaBS = Convert.ToInt64(row["MaBS"]),
                        MaLK = Convert.ToInt64(row["MaLK"]),
                        MaPK = Convert.ToInt64(row["MaPK"]),
                        NgayKeToa = Convert.ToDateTime(row["NgayKeToa"])
                    };
                    toaThuocList.Add(toaThuoc);
                }

                return toaThuocList;
            }
            catch (Exception ex)
            {
                string errorMessage = $"ERROR::ToaThuocDAL::GetAll() - Không thể lấy danh sách ToaThuoc: {ex.Message}";
                Console.WriteLine(errorMessage);
                return new List<ToaThuoc>();
            }
        }

        public ToaThuoc GetByMaTT(long MaTT)
        {
            try
            {
                string query = "SELECT * FROM ToaThuoc WHERE MaTT = @MaTT";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaTT", MaTT)
                };
                DataTable result = ExecuteQuery(query, parameters);

                if (result.Rows.Count == 0)
                {
                    Console.WriteLine($"Không tồn tại ToaThuoc với MaTT {MaTT}.");
                    return null;
                }

                DataRow row = result.Rows[0];
                ToaThuoc toaThuoc = new ToaThuoc
                {
                    MaTT = Convert.ToInt64(row["MaTT"]),
                    MaBN = Convert.ToInt64(row["MaBN"]),
                    MaBS = Convert.ToInt64(row["MaBS"]),
                    MaLK = Convert.ToInt64(row["MaLK"]),
                    MaPK = Convert.ToInt64(row["MaPK"]),
                    NgayKeToa = Convert.ToDateTime(row["NgayKeToa"])
                };

                return toaThuoc;
            }
            catch (Exception ex)
            {
                string errorMessage = $"ERROR::ToaThuocDAL::GetByMaTT() - Không thể lấy ToaThuoc bằng MaTT {MaTT}: {ex.Message}";
                Console.WriteLine(errorMessage);
                return null;
            }
        }

        public List<ToaThuoc> GetByMaBN(long MaBN)
        {
            try
            {
                string query = "SELECT * FROM ToaThuoc WHERE MaBN = @MaBN";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaBN", MaBN)
                };
                DataTable result = ExecuteQuery(query, parameters);

                if (result.Rows.Count == 0)
                {
                    Console.WriteLine($"Không tồn tại danh sách ToaThuoc với MaBN {MaBN}.");
                    return new List<ToaThuoc>();
                }

                List<ToaThuoc> toaThuocList = new List<ToaThuoc>();
                foreach (DataRow row in result.Rows)
                {
                    ToaThuoc toaThuoc = new ToaThuoc
                    {
                        MaTT = Convert.ToInt64(row["MaTT"]),
                        MaBN = Convert.ToInt64(row["MaBN"]),
                        MaBS = Convert.ToInt64(row["MaBS"]),
                        MaLK = Convert.ToInt64(row["MaLK"]),
                        MaPK = Convert.ToInt64(row["MaPK"]),
                        NgayKeToa = Convert.ToDateTime(row["NgayKeToa"])
                    };
                    toaThuocList.Add(toaThuoc);
                }

                return toaThuocList;
            }
            catch (Exception ex)
            {
                string errorMessage = $"ERROR::ToaThuocDAL::GetByMaBN() - Không thể lấy danh sách ToaThuoc bằng MaBN {MaBN}: {ex.Message}";
                Console.WriteLine(errorMessage);
                return new List<ToaThuoc>();
            }
        }

    }
}
