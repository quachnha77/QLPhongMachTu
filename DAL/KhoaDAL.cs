using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class KhoaDAL : DatabaseHelper
    {
        public List<PhongKhoa> GetAll()
        {
            string query = "SELECT * FROM PhongKhoas";
            DataTable dataTable = ExecuteQuery(query);

            List<PhongKhoa> phongKhoaList = new List<PhongKhoa>();
            foreach (DataRow row in dataTable.Rows)
            {
                phongKhoaList.Add(new PhongKhoa
                {
                    MaPK = Convert.ToInt64(row["MaPK"]),
                    ChuyenKhoa = row["ChuyenKhoa"].ToString(),
                    // Add other properties as needed
                });
            }

            return phongKhoaList;
        }

        public PhongKhoa GetByChuyenKhoa(string chuyenKhoa)
        {
            string query = "SELECT * FROM PhongKhoas WHERE ChuyenKhoa = @ChuyenKhoa";
            SqlParameter[] parameters = { new SqlParameter("@ChuyenKhoa", chuyenKhoa) };
            DataTable dataTable = ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new PhongKhoa
                {
                    MaPK = Convert.ToInt64(row["MaPK"]),
                    ChuyenKhoa = row["ChuyenKhoa"].ToString(),
                    // Add other properties as needed
                };
            }

            return null;
        }

        public PhongKhoa GetById(long id)
        {
            string query = "SELECT * FROM PhongKhoas WHERE MaPK = @Id";
            SqlParameter[] parameters = { new SqlParameter("@Id", id) };
            DataTable dataTable = ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new PhongKhoa
                {
                    MaPK = Convert.ToInt64(row["MaPK"]),
                    ChuyenKhoa = row["ChuyenKhoa"].ToString(),
                    // Add other properties as needed
                };
            }

            return null;
        }
    }
}
