using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class PhanCongDAL : DatabaseHelper
    {
        public LichPhanCong taoLichPhanCong(LichPhanCong lichPhanCong)
        {
            string query = "INSERT INTO LichPhanCongs (MaNV ,MaBS, GhiChu, gioBatDau, gioKetThuc, NgayPhanCong, CaLam) OUTPUT INSERTED.Id VALUES (@MaBS, @NgayPhanCong, @CaLam)";
            SqlParameter[] parameters = {
                new SqlParameter("@MaNV", lichPhanCong.MaNV),
                new SqlParameter("@MaBS", lichPhanCong.MaBS),
                new SqlParameter("@GhiChu", lichPhanCong.GhiChu),
                new SqlParameter("@gioBatDau", lichPhanCong.gioBatDau),
                new SqlParameter("@gioKetThuc", lichPhanCong.gioKetThuc),
                new SqlParameter("@NgayPhanCong", lichPhanCong.NgayPhanCong),
            };

            using (DataTable result = ExecuteQuery(query, parameters))
            {
                if (result.Rows.Count > 0)
                {// Gán ID
                    lichPhanCong.MaLPC = Convert.ToInt64(result.Rows[0][0]);
                }
                return lichPhanCong;
            }
        }

        public List<LichPhanCong> GetAllByMaBacSi(long maBacSi)
        {
            string query = @"
                SELECT lp.*
                FROM LichPhanCongs lp
                WHERE lp.MaBS = @MaBacSi";

            SqlParameter[] parameters = {
                new SqlParameter("@MaBacSi", maBacSi)
            };

            DataTable result = ExecuteQuery(query, parameters);
            var list = new List<LichPhanCong>();

            foreach (DataRow row in result.Rows)
            {
                list.Add(new LichPhanCong
                {
                    MaLPC = Convert.ToInt64(row[0]),
                    MaNV = Convert.ToInt64(row[1]),
                    MaBS = Convert.ToInt64(row[2]), // long 64 bit
                    GhiChu = Convert.ToString(row[3]),
                    gioBatDau = Convert.ToInt32(row[4]),
                    gioKetThuc = Convert.ToInt32(row[5]),
                    NgayPhanCong = Convert.ToDateTime(row["NgayPhanCong"]),
                    
                    //BacSi = new BacSi
                    //{
                    //    Ma = Convert.ToInt64(row["MaBS"]),
                    //    TenBacSi = row["TenBacSi"].ToString(),
                    //    PhongKhoa = new PhongKhoa
                    //    {
                    //        Id = Convert.ToInt64(row["MaPK"]),
                    //        TenPhongKhoa = row["TenPhongKhoa"].ToString()
                    //    }
                    //}
                });
            }
            return list;
        }

        public LichPhanCong GetById(long id)
        {
            string query = @"
                SELECT lp.*, bs.TenBacSi, pk.TenPhongKhoa
                FROM LichPhanCongs lp
                INNER JOIN BacSi bs ON lp.MaBS = bs.Id
                INNER JOIN PhongKhoa pk ON bs.MaPK = pk.Id
                WHERE lp.Id = @Id";

            SqlParameter[] parameters = {
                new SqlParameter("@Id", id)
            };

            DataTable result = ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                return new LichPhanCong
                {
                    MaLPC = Convert.ToInt64(row[1]),
                    MaNV = Convert.ToInt64(row[2]),
                    MaBS = Convert.ToInt64(row[3]), // long 64 bit
                    GhiChu = Convert.ToString(row[4]),
                    gioBatDau = Convert.ToInt32(row[5]),
                    gioKetThuc = Convert.ToInt32(row[6]),
                    NgayPhanCong = Convert.ToDateTime(row["NgayPhanCong"]),
                    //BacSi = new BacSi
                    //{
                    //    MaBS = Convert.ToInt64(row["MaBS"]),
                    //    TenBacSi = row["TenBacSi"].ToString(),
                    //    PhongKhoa = new PhongKhoa
                    //    {
                    //        Id = Convert.ToInt64(row["MaPK"]),
                    //        TenPhongKhoa = row["TenPhongKhoa"].ToString()
                    //    }
                    //}
                };
            }
            return null;
        }
    }
}
