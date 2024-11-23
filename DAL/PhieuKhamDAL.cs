using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class PhieuKhamDAL : DatabaseHelper
    {
        public List<PhieuKham> GetAll()
        {
            try
            {
                string query = "SELECT * FROM PhieuKhams";
                DataTable result = ExecuteQuery(query);

                if (result.Rows.Count == 0)
                {
                    Console.WriteLine("Không tồn tại danh sách PhieuKham.");
                    return new List<PhieuKham>();
                }

                List<PhieuKham> phieuKhamList = new List<PhieuKham>();
                foreach (DataRow row in result.Rows)
                {
                    PhieuKham phieuKham = new PhieuKham
                    {
                        MaPK = Convert.ToInt64(row["MaPK"]),
                        MaLK = Convert.ToInt64(row["MaLK"]),
                        MaBN = Convert.ToInt64(row["MaBN"]),
                        MaBS = Convert.ToInt64(row["MaBS"]),
                        NgayKham = Convert.ToDateTime(row["NgayKham"]),
                        SoThuTu = Convert.ToInt32(row["SoThuTu"]),
                        TrieuChung = Convert.ToString(row["TrieuChung"]),
                        TieuSuBenhLy = Convert.ToString(row["TienSuBenhLy"]),
                        ChuanDoan = Convert.ToString(row["ChuanDoan"])
                    };
                    phieuKhamList.Add(phieuKham);
                }

                return phieuKhamList;
            }
            catch (Exception ex)
            {
                string errorMessage = $"ERROR::PhieuKhamDAL::GetAll() - Không thể lấy danh sách PhieuKham: {ex.Message}";
                Console.WriteLine(errorMessage);
                return new List<PhieuKham>();
            }
        }
        public PhieuKham GetByMaPK(long MaPK)
        {
            try
            {
                string query = "SELECT * FROM PhieuKhams WHERE MaPK = @MaPK";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaPK", MaPK)
                };
                DataTable result = ExecuteQuery(query, parameters);

                if (result.Rows.Count == 0)
                {
                    Console.WriteLine($"Không tồn tại PhieuKham với MaPK {MaPK}.");
                    return null;
                }

                DataRow row = result.Rows[0];
                PhieuKham phieuKham = new PhieuKham
                {
                    MaPK = Convert.ToInt64(row["MaPK"]),
                    MaLK = Convert.ToInt64(row["MaLK"]),
                    MaBN = Convert.ToInt64(row["MaBN"]),
                    MaBS = Convert.ToInt64(row["MaBS"]),
                    NgayKham = Convert.ToDateTime(row["NgayKham"]),
                    SoThuTu = Convert.ToInt32(row["SoThuTu"]),
                    TrieuChung = Convert.ToString(row["TrieuChung"]),
                    TieuSuBenhLy = Convert.ToString(row["TieuSuBenhLy"]),
                    ChuanDoan = Convert.ToString(row["ChuanDoan"])
                };

                return phieuKham;
            }
            catch (Exception ex)
            {
                string errorMessage = $"ERROR::PhieuKhamDAL::GetByMaPK() - Không thể lấy PhieuKham bằng MaPK {MaPK}: {ex.Message}";
                Console.WriteLine(errorMessage);
                MessageBox.Show(errorMessage);
                return null;
            }
        }
    }
}
