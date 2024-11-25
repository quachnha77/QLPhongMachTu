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
                string query = "SELECT * FROM PhanQuyens WHERE MaPQ = @MaPQ";
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

        // Lấy danh sách tên các phân quyền (ngoại trừ "Bệnh nhân", "Admin" và "Vô hiệu hóa")
        public List<string> GetPhanQuyenByName()
        {
            var phanQuyenNames = new List<string>();
            string query = "SELECT TenQuyen FROM PhanQuyens WHERE TenQuyen NOT IN (N'Bệnh nhân', 'Admin', N'Vô hiệu hóa')";

            DataTable dataTable = ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                phanQuyenNames.Add(row["TenQuyen"].ToString());
            }

            return phanQuyenNames;
        }

        // Lấy mã phân quyền theo tên phân quyền
        public long GetMaPQByName(string name)
        {
            string query = "SELECT MaPQ FROM PhanQuyens WHERE TenQuyen = @TenQuyen";

            SqlParameter[] parameters = {
                new SqlParameter("@TenQuyen", SqlDbType.NVarChar)
                {
                    Value = name
                }
            };

            object result = ExecuteScalar(query, parameters);

            return result != null ? Convert.ToInt64(result) : 0;
        }
    }
}
