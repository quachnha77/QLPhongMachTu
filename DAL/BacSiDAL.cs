using QLPhongMachTu_DOAN_.DTO;
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
        public BacSiDAL() : base() { }

        public List<BacSi> GetAllByChuyenKhoa(long maKhoa)
        {
            List<BacSi> bacSiList = new List<BacSi>();
            string sql = "SELECT * FROM BacSis WHERE MaKhoa = @MaKhoa";
            SqlParameter[] parameters = {
                new SqlParameter("@MaKhoa", maKhoa)
            };

            DataTable result = ExecuteQuery(sql, parameters);

            foreach(DataRow row in result.Rows) { 
                BacSi bs = new BacSi{
                    MaSo = Convert.ToInt64(row[0]),
                    MaKhoa = Convert.ToInt64(row[1]),
                    CCCD = Convert.ToString(row[2]),
                    HoTen = Convert.ToString(row[3]),
                    NgaySinh = (DateTime)row[4],
                    GioiTinh = Convert.ToString(row[5]),
                    DiaChi = Convert.ToString(row[6]),
                    SDT  = Convert.ToString(row[7]),
                    MaUser = (long)row[8],
                };
             bacSiList.Add(bs);
            }

            return bacSiList;
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
    }
}
