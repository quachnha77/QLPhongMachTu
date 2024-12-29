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
                    TenPhongBan = Convert.ToString(row["TenPhongBan"]),
                    ChuyenKhoa = Convert.ToString(row["ChuyenKhoa"]),

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



        //BichNhung

        // Lấy tên phòng ban
        public List<string> GetName()
        {
            List<string> names = new List<string>();

            string query = "SELECT TenPhongBan FROM PhongKhoas";
            DataTable dataTable = ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                names.Add(row["TenPhongBan"].ToString());
            }
            return names;
        }

        //Lấy mã khoa theo tên phòng ban
        public long GetMaKhoaByName(string name)
        {
            string query = "SELECT MaPK FROM PhongKhoas WHERE TenPhongBan = @name";
            SqlParameter[] parameters = { new SqlParameter("@name", name) };

            DataTable dataTable = ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return Convert.ToInt64(row["MaPK"]);
            }

            return 0;
        }

        // Lấy tên chuyên khoa
        public string GetChuyenKhoaByMaBS(long maBS)
        {
            List<string> names = new List<string>();

            string query = @"
                SELECT pk.ChuyenKhoa
                FROM BacSis bs
                INNER JOIN PhongKhoas pk ON bs.MaKhoa = pk.MaPK
                WHERE bs.MaSo = @MaBacSi";

            SqlParameter[] parameters = {
                new SqlParameter("@MaBacSi", maBS)
            };

            DataTable result = ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                return Convert.ToString(row["ChuyenKhoa"]);
            }
            return null;
        }
    }
}
