using QLPhongMachTu_DOAN_.BLL;
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
                string query = "SELECT * FROM HoaDonThuocs";
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
                        TrangThai = Convert.ToInt32(row["TrangThai"])
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

        public HoaDonThuoc GetByMaDT(long MaDT)
        {
            try
            {
                string query = "SELECT * FROM HoaDonThuocs WHERE MaDT = @MaDT ORDER BY MaDT DESC";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaDT", MaDT)
                };
                DataTable result = ExecuteQuery(query, parameters);

                if (result.Rows.Count == 0)
                {
                    Console.WriteLine($"Không tồn tại HoaDonThuoc với MaDT {MaDT}.");
                    return null;
                }

                DataRow row = result.Rows[0];
                HoaDonThuoc hoaDon = new HoaDonThuoc
                {
                    MaDT = Convert.ToInt64(row["MaDT"]),
                    MaTT = Convert.ToInt64(row["MaTT"]),
                    MaNV = Convert.ToInt64(row["MaNV"]),
                    NgayMua = Convert.ToDateTime(row["NgayMua"]),
                    TongTien = Convert.ToDouble(row["TongTien"]),
                    TrangThai = Convert.ToInt32(row["TrangThai"])
                };

                return hoaDon;
            }
            catch (Exception ex)
            {
                string errorMessage = $"ERROR::HoaDonThuocDAL::GetByMaDT() - Không thể lấy HoaDonThuoc bằng MaDT {MaDT}: {ex.Message}";
                Console.WriteLine(errorMessage);
                return null;
            }
        }

        public List<HoaDonThuoc> GetByMaTT(long MaTT)
        {
            try
            {
                string query = "SELECT * FROM HoaDonThuocs WHERE MaTT = @MaTT ORDER BY MaDT DESC";
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
                        TrangThai = Convert.ToInt32(row["TrangThai"])
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

        public List<HoaDonThuoc> TimKiemThanhToan(string searchStr, string searchTerm, int TrangThai, DateTime? NgayTao)
        {
            string query = "SELECT * FROM HoaDonThuocs WHERE 1=1 ";

            List<SqlParameter> parameters = new List<SqlParameter>();

            // Tìm kiếm theo Mã đơn thuốc hoặc Mã toa thuốc 
            if (searchTerm == "Mã đơn thuốc" && !string.IsNullOrEmpty(searchStr))
            {
                query += " AND MaDT = @MaDT";
                parameters.Add(new SqlParameter("@MaDT", searchStr));
            }
            else if (searchTerm == "Mã toa thuốc" && !string.IsNullOrEmpty(searchStr))
            {
                query += " AND MaTT = @MaTT";
                parameters.Add(new SqlParameter("@MaTT", searchStr));
            }

            // Tìm kiếm theo trạng thái
            if (TrangThai != 2) // 2 là mặc định, tức là tìm tất cả trạng thái
            {
                query += " AND TrangThai = @TrangThai";
                parameters.Add(new SqlParameter("@TrangThai", TrangThai));
            }

            // Tìm kiếm theo Ngày tạo
            if (NgayTao.HasValue)
            {
                query += " AND CONVERT(date, NgayMua) = @NgayMua";
                parameters.Add(new SqlParameter("@NgayMua", NgayTao.Value.Date));
            }

            DataTable result = ExecuteQuery(query, parameters.ToArray());

            List<HoaDonThuoc> hoaDonThuocList = new List<HoaDonThuoc>();
            foreach (DataRow row in result.Rows)
            {
                HoaDonThuoc hoaDonThuoc = new HoaDonThuoc
                {
                    MaDT = Convert.ToInt64(row["MaDT"]),
                    MaTT = Convert.ToInt64(row["MaTT"]),
                    MaNV = Convert.ToInt64(row["MaNV"]),
                    NgayMua = Convert.ToDateTime(row["NgayMua"]),
                    TongTien = (float)Convert.ToDouble(row["TongTien"]),
                    TrangThai = Convert.ToInt32(row["TrangThai"])
                };
                hoaDonThuocList.Add(hoaDonThuoc);
            }

            return hoaDonThuocList;
        }

        public bool SetThanhToan(long MaDT, int TrangThai)
        {
            string query = @"UPDATE HoaDonThuocs
                            SET TrangThai = @TrangThai
                            WHERE MaDT = @MaDT";
            SqlParameter[] parameters = {
                    new SqlParameter("@TrangThai", TrangThai),
                    new SqlParameter("@MaDT", MaDT)
                };

            int success = ExecuteNonQuery(query, parameters);
            return success > 0;
        }
    }
}
