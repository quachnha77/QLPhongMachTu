using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using QLPhongMachTu_DOAN_.BLL;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class HoaDonKhamBenhDAL : DatabaseHelper
    {

        public List<HoaDonKhamBenh> GetAll()
        {
            try
            {
                string query = "SELECT * FROM HoaDonKhamBenhs";
                DataTable result = ExecuteQuery(query);

                if (result.Rows.Count == 0)
                {
                    Debug.WriteLine("Không tồn tại danh sách HoaDonKhamBenh nào.");
                    return new List<HoaDonKhamBenh>();                 
                }

                List<HoaDonKhamBenh> hoaDonKhamBenhList = new List<HoaDonKhamBenh>();

                foreach (DataRow row in result.Rows)
                {
                    HoaDonKhamBenh hoaDon = new HoaDonKhamBenh
                    {
                        MaHDKB = Convert.ToInt64(row["MaHDKB"]),
                        MaBN = Convert.ToInt64(row["MaBN"]),
                        MaBS = Convert.ToInt64(row["MaBS"]),
                        MaPK = Convert.ToInt64(row["MaPK"]),
                        TongTien = (float)Convert.ToDouble(row["TongTien"]),
                        TrangThai = Convert.ToInt32(row["TrangThai"])
                    };
                    hoaDonKhamBenhList.Add(hoaDon);
                }

                return hoaDonKhamBenhList; 

            }
            catch (Exception ex)
            {
                string errorMessage = $"ERROR::HoaDonKhamBenhDAL::GetAll() - Không thể lấy danh sách HoaDonKhamBenh: {ex.Message}";
                Debug.WriteLine(errorMessage);
                return new List<HoaDonKhamBenh>();
            }
        }

        public List<HoaDonKhamBenh> GetByMaBN(long MaBN)
        {
            try
            {
                string query = "SELECT * FROM HoaDonKhamBenhs WHERE MaBN = @MaBN ORDER BY MaHDKB DESC";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaBN", MaBN)
                };
                DataTable result = ExecuteQuery(query, parameters);

                if(result.Rows.Count == 0)
                {
                    Debug.WriteLine($"Không tồn tại HoaDonKhamBenh với MaBN {MaBN}.");
                    return new List<HoaDonKhamBenh>();
                }

                List<HoaDonKhamBenh> hoaDonKhamBenhList = new List<HoaDonKhamBenh>();
                foreach (DataRow row in result.Rows)
                {
                    HoaDonKhamBenh hoaDon = new HoaDonKhamBenh
                    {
                        MaHDKB = Convert.ToInt64(row["MaHDKB"]),
                        MaBN = Convert.ToInt64(row["MaBN"]),
                        MaBS = Convert.ToInt64(row["MaBS"]),
                        MaPK = Convert.ToInt64(row["MaPK"]),
                        TongTien = (float)Convert.ToDouble(row["TongTien"]),
                        TrangThai = Convert.ToInt32(row["TrangThai"])
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

        public HoaDonKhamBenh GetByMaHDKB(long MaHDKB)
        {
            try
            {
                string query = "SELECT * FROM HoaDonKhamBenhs WHERE MaHDKB = @MaHDKB ORDER BY MaHDKB DESC";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaHDKB", MaHDKB)
                };
                DataTable result = ExecuteQuery(query, parameters);

                if (result.Rows.Count == 0)
                {
                    Debug.WriteLine($"Không tồn tại HoaDonKhamBenh với MaHDKB {MaHDKB}.");
                    return null;
                }

                DataRow row = result.Rows[0];
                HoaDonKhamBenh hoaDon = new HoaDonKhamBenh
                {
                    MaHDKB = Convert.ToInt64(row["MaHDKB"]),
                    MaBN = Convert.ToInt64(row["MaBN"]),
                    MaBS = Convert.ToInt64(row["MaBS"]),
                    MaPK = Convert.ToInt64(row["MaPK"]),
                    TongTien = (float)Convert.ToDouble(row["TongTien"]),
                    TrangThai = Convert.ToInt32(row["TrangThai"])
                };
 
                return hoaDon;

            }
            catch (Exception ex)
            {
                string errorMessage = $"ERROR::HoaDonKhamBenhDAL::GetByMaHDKB() - Không thể lấy HoaDonKhamBenh bằng MaHDKB {MaHDKB}: {ex.Message}";
                return null;
            }
        }

        public List<HoaDonKhamBenh> GetByMaPK(long MaPK)
        {
            try
            {
                string query = "SELECT * FROM HoaDonKhamBenhs WHERE MaPK = @MaPK ORDER BY MaHDKB DESC";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaPK", MaPK)
                };
                DataTable result = ExecuteQuery(query, parameters);

                if (result.Rows.Count == 0)
                {
                    Debug.WriteLine($"Không tồn tại HoaDonKhamBenh với MaPK {MaPK}.");
                    return new List<HoaDonKhamBenh>();
                }

                List<HoaDonKhamBenh> hoaDonKhamBenhList = new List<HoaDonKhamBenh>();
                foreach (DataRow row in result.Rows)
                {
                    HoaDonKhamBenh hoaDon = new HoaDonKhamBenh
                    {
                        MaHDKB = Convert.ToInt64(row["MaHDKB"]),
                        MaBN = Convert.ToInt64(row["MaBN"]),
                        MaBS = Convert.ToInt64(row["MaBS"]),
                        MaPK = Convert.ToInt64(row["MaPK"]),
                        TongTien = (float)Convert.ToDouble(row["TongTien"]),
                        TrangThai = Convert.ToInt32(row["TrangThai"])
                    };
                    hoaDonKhamBenhList.Add(hoaDon);
                }

                return hoaDonKhamBenhList;

            }
            catch (Exception ex)
            {
                string errorMessage = $"ERROR::HoaDonKhamBenhDAL::GetByMaPK() - Không thể lấy danh sách HoaDonKhamBenh bằng MaPK {MaPK}: {ex.Message}";
                return new List<HoaDonKhamBenh>();
            }
        }

        public List<HoaDonKhamBenh> TimKiemThanhToan(long MaBN, string searchStr, string searchTerm, int TrangThai, DateTime? NgayTao)
        {
            string query = "SELECT * FROM HoaDonKhamBenhs WHERE MaBN = @MaBN"; 

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MaBN", MaBN));

            // Tìm kiếm theo Mã hóa đơn hoặc Mã phiếu khám
            if (searchTerm == "Mã hóa đơn" && !string.IsNullOrEmpty(searchStr))
            {
                query += " AND MaHDKB = @MaHDKB";
                parameters.Add(new SqlParameter("@MaHDKB", searchStr));
            }
            else if (searchTerm == "Mã phiếu khám" && !string.IsNullOrEmpty(searchStr))
            {
                query += " AND MaPK = @MaPK";
                parameters.Add(new SqlParameter("@MaPK", searchStr));
            }

            // Tìm kiếm theo trạng thái
            if (TrangThai != 2) // 2 là mặc định, tức là tìm tất cả trạng thái
            {
                query += " AND TrangThai = @TrangThai";
                parameters.Add(new SqlParameter("@TrangThai", TrangThai));
            }

            // Tìm kiếm theo Ngày tạo (?)
            //if (NgayTao.HasValue)
            //{
            //    query += " AND CONVERT(date, NgayTao) = @NgayTao";
            //    parameters.Add(new SqlParameter("@NgayTao", NgayTao.Value.Date));
            //}

            DataTable result = ExecuteQuery(query, parameters.ToArray());

            List<HoaDonKhamBenh> hoaDonKBList = new List<HoaDonKhamBenh>();
            foreach (DataRow row in result.Rows)
            {
                HoaDonKhamBenh hoaDonKB = new HoaDonKhamBenh
                {
                    MaHDKB = Convert.ToInt64(row["MaHDKB"]),
                    MaBN = Convert.ToInt64(row["MaBN"]),
                    MaBS = Convert.ToInt64(row["MaBS"]),
                    MaPK = Convert.ToInt64(row["MaPK"]),
                    TongTien = (float)Convert.ToDouble(row["TongTien"]),
                    TrangThai = Convert.ToInt32(row["TrangThai"])
                };
                hoaDonKBList.Add(hoaDonKB);
            }

            return hoaDonKBList;
        }


        public bool SetThanhToan(long MaHDKB, int TrangThai)
        {
            string query = @"UPDATE HoaDonKhamBenhs
                            SET TrangThai = @TrangThai
                            WHERE MaHDKB = @MaHDKB";
            SqlParameter[] parameters = {
                    new SqlParameter("@TrangThai", TrangThai),
                    new SqlParameter("@MaHDKB", MaHDKB)
                };

            int success = ExecuteNonQuery(query, parameters);
            return success > 0; 
        }

    }
}
