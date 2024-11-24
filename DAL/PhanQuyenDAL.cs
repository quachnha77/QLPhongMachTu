using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class PhanQuyenDAL : DatabaseHelper
    {
        public PhanQuyenDAL() : base() { }

        // Lấy phân quyền theo mã phân quyền
        public PhanQuyen GetByMaQP(long MaQP)
        {
            PhanQuyen phanQuyen = null;

            try
            {
                string query = "SELECT * FROM PhanQuyen WHERE MaPQ = @MaPQ";
                SqlParameter[] parameters = { new SqlParameter("@MaPQ", MaQP) };

                DataTable result = ExecuteQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    DataRow row = result.Rows[0];
                    phanQuyen = new PhanQuyen
                    {
                        MaPQ = Convert.ToInt64(row["MaPQ"]),
                        TenQuyen = row["TenQuyen"].ToString(),
                        MoTa = row["MoTa"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy phân quyền theo mã: {ex.Message}");
            }

            return phanQuyen;
        }

        // Lấy danh sách tên các phân quyền (ngoại trừ "Bệnh nhân")
        public List<string> GetPhanQuyenByName()
        {
            List<string> phanQuyenList = new List<string>();

            try
            {
                string query = "SELECT TenQuyen FROM PhanQuyen WHERE TenQuyen != @ExcludedRole";
                SqlParameter[] parameters = { new SqlParameter("@ExcludedRole", "Bệnh nhân") };

                DataTable result = ExecuteQuery(query, parameters);

                foreach (DataRow row in result.Rows)
                {
                    phanQuyenList.Add(row["TenQuyen"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách phân quyền: {ex.Message}");
            }

            return phanQuyenList;
        }

        // Lấy mã phân quyền theo tên phân quyền
        public long GetMaPQByName(string name)
        {
            long maPQ = 0;

            try
            {
                string query = "SELECT MaPQ FROM PhanQuyen WHERE TenQuyen = @TenQuyen";
                SqlParameter[] parameters = { new SqlParameter("@TenQuyen", name) };

                DataTable result = ExecuteQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    maPQ = Convert.ToInt64(result.Rows[0]["MaPQ"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy mã phân quyền theo tên: {ex.Message}");
            }

            return maPQ;
        }
    }
}
