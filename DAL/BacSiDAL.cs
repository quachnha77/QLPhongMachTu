using QLPhongMachTu_DOAN_.DTO;
using QLPhongMachTu_DOAN_.GUI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class BacSiDAL : DatabaseHelper
    {
        private readonly string _connectionString;
        public BacSiDAL() : base() { }

        public List<BacSi> GetAllByChuyenKhoa(long maKhoa)
        {
            List<BacSi> bacSiList = new List<BacSi>();
            string sql = "SELECT * FROM BacSis WHERE MaKhoa = @MaKhoa";
            SqlParameter[] parameters = {
                new SqlParameter("@MaKhoa", maKhoa)
            };

            DataTable result = ExecuteQuery(sql, parameters);

            foreach (DataRow row in result.Rows)
            {
                BacSi bs = new BacSi
                {
                    MaSo = Convert.ToInt64(row[0]),
                    MaKhoa = Convert.ToInt64(row[1]),
                    //CCCD = Convert.ToString(row[2]),
                    HoTen = Convert.ToString(row[3]),
                    NgaySinh = (DateTime)row[4],
                    GioiTinh = Convert.ToString(row[5]),
                    DiaChi = Convert.ToString(row[6]),
                    SDT = Convert.ToString(row[7]),
                    MaUser = (long)row[8],
                };
                bacSiList.Add(bs);
            }

            return bacSiList;
        }
        public List<BacSi> GetAll()
        {
            string query = "SELECT * FROM BacSis";
            DataTable result = ExecuteQuery(query);
            var list = new List<BacSi>();

            foreach (DataRow row in result.Rows)
            {
                list.Add(new BacSi
                {
                    MaSo = Convert.ToInt64(row[0]),
                    MaKhoa = Convert.ToInt64(row[1]),
                    CCCD = Convert.ToInt64(row[2]),
                    HoTen = Convert.ToString(row[3]),
                    NgaySinh = Convert.ToDateTime(row[4]),
                    GioiTinh = Convert.ToString(row[5]),
                    DiaChi = Convert.ToString(row[6]),
                    SDT = Convert.ToString(row[7]),
                    MaUser = Convert.ToInt64(row[8]),
                });
            }
            return list;

        }
        public BacSi GetById(long id)
        {
            BacSi bacSi = null;
            string query = "SELECT * FROM BacSis WHERE MaSo = @Id";
            SqlParameter[] parameters = { new SqlParameter("@Id", id) };

            DataTable result = ExecuteQuery(query, parameters);
            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                bacSi = new BacSi
                {
                    MaSo = Convert.ToInt64(row["MaSo"]),
                    HoTen = row["HoTen"].ToString(),
                    MaKhoa = Convert.ToInt64(row["MaKhoa"]),
                };
            }

            return bacSi;
        }
        public BacSi GetByName(string name)
        {
            BacSi bacSi = null;
            string query = "SELECT * FROM BacSis WHERE HoTen = @HoTen";
            SqlParameter[] parameters = {
                new SqlParameter("@HoTen", name)
            };
            DataTable result = ExecuteQuery(query, parameters);
            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                bacSi = new BacSi
                {
                    MaSo = Convert.ToInt64(row["MaSo"]),
                    HoTen = row["HoTen"].ToString(),
                    MaKhoa = Convert.ToInt64(row["MaKhoa"]),
                };
            }
            return bacSi;
        }
        public bool ThemBacSi(BacSi bs)
        {
            string query = "INSERT INTO BacSis (MaBS, MaKhoa, CCCD, HoTen, NgaySinh, GioiTinh, DiaChi, SDT, MaUser) VALUES" +
                " (@MaBS, @MaKhoa, @CCCD, @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @SDT, @MaUser)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaKhoa", bs.MaKhoa);
                command.Parameters.AddWithValue("@CCCD", bs.CCCD);
                command.Parameters.AddWithValue("@HoTen", bs.HoTen);
                command.Parameters.AddWithValue("@NgaySinh", bs.NgaySinh);
                command.Parameters.AddWithValue("@GioiTinh", bs.GioiTinh);
                command.Parameters.AddWithValue("@DiaChi", bs.DiaChi);
                command.Parameters.AddWithValue("@SDT", bs.SDT);
                command.Parameters.AddWithValue("@MaUser", bs.MaUser);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

    }
}
