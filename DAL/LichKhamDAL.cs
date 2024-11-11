using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class LichKhamDAL : DatabaseHelper
    {
        public LichKham TaoLichKham(LichKham lk)
        {
            string query = "INSERT INTO LichKhams (MaBS, MaBN, NgayKham, TrieuChung, TrangThai) OUTPUT INSERTED.MaLK VALUES (@MaBS, @MaBN, @NgayKham, @TrieuChung, @TrangThai)";
            SqlParameter[] parameters = {
                new SqlParameter("@MaBS", lk.MaBS),
                new SqlParameter("@MaBN", lk.MaBN),
                new SqlParameter("@NgayKham", lk.NgayKham),
                new SqlParameter("@TrieuChung", lk.TrieuChung),
                new SqlParameter("@TrangThai", lk.TrangThai)
            };

            using (DataTable result = ExecuteQuery(query, parameters))
            {
                if (result.Rows.Count > 0)
                {
                    lk.MaLK = Convert.ToInt64(result.Rows[0]["MaLK"]);
                }
                return lk;
            }
        }

        public bool XoaLichKham(long id)
        {
            string query = "DELETE FROM LichKhams WHERE MaLK = @MaLK";
            SqlParameter[] parameters = { new SqlParameter("@MaLK", id) };

            int rowsAffected = ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public List<LichKham> GetByMaBenhNhan(long maBN)
        {
            string query = @"
                SELECT lk.*, bs.HoTen
                FROM LichKhams lk
                INNER JOIN BacSis bs ON lk.MaBS = bs.MaSo
                WHERE lk.MaBN = @MaBN";
            SqlParameter[] parameters = { new SqlParameter("@MaBN", maBN) };

            DataTable result = ExecuteQuery(query, parameters);
            return MapLichKhamList(result);
        }

        public List<LichKham> GetAll()
        {
            string query = @"
                SELECT lk.*, bs.TenBacSi, bn.TenBenhNhan
                FROM LichKhams lk
                INNER JOIN BacSi bs ON lk.MaBS = bs.MaBS
                INNER JOIN BenhNhan bn ON lk.MaBN = bn.MaBN";

            DataTable result = ExecuteQuery(query);
            return MapLichKhamList(result);
        }

        public List<LichKham> GetByTrangThai(string trangThai)
        {
            string query = @"
                SELECT lk.*, bs.TenBacSi, bn.TenBenhNhan
                FROM LichKhams lk
                INNER JOIN BacSi bs ON lk.MaBS = bs.MaBS
                INNER JOIN BenhNhan bn ON lk.MaBN = bn.MaBN
                WHERE lk.TrangThai = @TrangThai";
            SqlParameter[] parameters = { new SqlParameter("@TrangThai", trangThai) };

            DataTable result = ExecuteQuery(query, parameters);
            return MapLichKhamList(result);
        }

        public bool SuaLichKham(long maLK, DateTime ngayHen, string yeuCau)
        {
            string query = "UPDATE LichKhams SET NgayKham = @NgayKham, TrieuChung = @TrieuChung WHERE MaLK = @MaLK";
            SqlParameter[] parameters = {
                new SqlParameter("@NgayKham", ngayHen),
                new SqlParameter("@TrieuChung", yeuCau),
                new SqlParameter("@MaLK", maLK)
            };

            int rowsAffected = ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public LichKham GetById(long maLK)
        {
            string query = @"
                SELECT lk.*, bs.TenBacSi, bn.TenBenhNhan
                FROM LichKhams lk
                INNER JOIN BacSi bs ON lk.MaBS = bs.MaBS
                INNER JOIN BenhNhan bn ON lk.MaBN = bn.MaBN
                WHERE lk.MaLK = @MaLK";
            SqlParameter[] parameters = { new SqlParameter("@MaLK", maLK) };

            DataTable result = ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                return MapLichKham(result.Rows[0]);
            }
            return null;
        }

        private List<LichKham> MapLichKhamList(DataTable dataTable)
        {
            var list = new List<LichKham>();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(MapLichKham(row));
            }
            return list;
        }

        private LichKham MapLichKham(DataRow row)
        {
            return new LichKham
            {
                MaLK = Convert.ToInt64(row["MaLK"]),
                MaBS = Convert.ToInt64(row["MaBS"]),
                MaBN = Convert.ToInt64(row["MaBN"]),
                NgayKham = Convert.ToDateTime(row["NgayKham"]),
                TrieuChung = row["TrieuChung"].ToString(),
                TrangThai = row["TrangThai"].ToString(),
                //BacSi = new BacSi
                //{
                //    Id = Convert.ToInt64(row["MaBS"]),
                //    TenBacSi = row["TenBacSi"].ToString()
                //},
                //BenhNhan = new BenhNhan
                //{
                //    Id = Convert.ToInt64(row["MaBN"]),
                //    TenBenhNhan = row["TenBenhNhan"].ToString()
                //}
            };
        }
    }
}
