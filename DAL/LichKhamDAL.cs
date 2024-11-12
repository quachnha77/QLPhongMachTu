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
                new SqlParameter("@TrangThai", "Chưa khám")
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
                SELECT lk.*, bs.HoTen, bn.HoTen
                FROM LichKhams lk
                INNER JOIN BacSis bs ON lk.MaBS = bs.MaSo
                INNER JOIN BenhNhans bn ON lk.MaBN = bn.MaSo";

            DataTable result = ExecuteQuery(query);
            return MapLichKhamList(result);
        }

        public List<LichKham> GetByTrangThai(string trangThai)
        {
            string query = @"
                SELECT lk.*, bs.HoTen, bn.HoTen
                FROM LichKhams lk
                INNER JOIN BacSis bs ON lk.MaBS = bs.MaSo
                INNER JOIN BenhNhans bn ON lk.MaBN = bn.MaSo
                WHERE lk.TrangThai = @TrangThai";
            SqlParameter[] parameters = { new SqlParameter("@TrangThai", trangThai) };

            DataTable result = ExecuteQuery(query, parameters);
            return MapLichKhamList(result);
        }

        public List<LichKham> TimKiemTheoNgay(DateTime from, DateTime to)
        {
            string query = @"SELECT *
                            FROM LichKhams lk
                            INNER JOIN BacSis bs on bs.Maso = lk.MaBS
                            WHERE NgayKham BETWEEN @FromDate AND @ToDate";
            SqlParameter[] parameters = {
                new SqlParameter("@FromDate", from),
                new SqlParameter("@ToDate", to)
            };

            DataTable result = ExecuteQuery(query, parameters);
            return MapLichKhamList(result);
        }

        public bool SuaLichKham(long maLK, LichKham updateLichKham)
        {
            string query = "UPDATE LichKhams SET MaBS = @MaBS, NgayKham = @NgayKham, TrieuChung = @TrieuChung" +
                " WHERE MaLK = @MaLK";
            SqlParameter[] parameters = {
                new SqlParameter("@MaBS", updateLichKham.MaBS),
                new SqlParameter("@NgayKham", updateLichKham.NgayKham),
                new SqlParameter("@TrieuChung", updateLichKham.TrieuChung),
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
                INNER JOIN BacSi bs ON lk.MaBS = bs.MaSo
                INNER JOIN BenhNhan bn ON lk.MaBN = bn.MaSo
                WHERE lk.MaLK = @MaLK";
            SqlParameter[] parameters = { new SqlParameter("@MaLK", maLK) };

            DataTable result = ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                // Trả về dòng đầu tiên
                return MapLichKham(result.Rows[0]);
            }
            return null;
        }

        public List<LichKham> TimKiemTheoChuyenKhoa(string chuyenKhoa)
        {
            //    string query = @"SELECT * FROM LichKham lk
            //                    INNER JOIN BacSis bs ON bs.MaSo = lk.MaBS
            //                    INNER JOIN PhongKhoas pk ON bs.MaKhoa = lk.MaKhoa
            //                    WHERE bs.MaKhoa = @";
            string queryChuyenKhoa = @"SELECT * FROM PhongKhoas pk WHERE ChuyenKhoa = @ChuyenKhoa";
            SqlParameter[] parametersCK = { new SqlParameter("@ChuyenKhoa", chuyenKhoa) };

            DataTable chuyenKhoaTbl = ExecuteQuery(queryChuyenKhoa, parametersCK);
            if(chuyenKhoaTbl.Rows.Count > 0)
            {
                long khoaId = Convert.ToInt64(chuyenKhoaTbl.Rows[0][0]);
                string query = @"SELECT lk.*, bs.*
                                FROM LichKhams lk
                                INNER JOIN BacSis bs ON bs.MaSo = lk.MaBS
                                WHERE bs.MaKhoa = @MaPK";
                SqlParameter[] parameters = { new SqlParameter("@MaPK", khoaId) };
                DataTable result = ExecuteQuery(query, parameters);
                return MapLichKhamList(result);
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
                BacSi = new BacSi
                {
                    MaSo = Convert.ToInt64(row["MaBS"]),
                    HoTen = row["HoTen"].ToString()
                },
                //BenhNhan = new BenhNhan
                //{
                //    Id = Convert.ToInt64(row["MaBN"]),
                //    TenBenhNhan = row["TenBenhNhan"].ToString()
                //}
            };
        }
    }
}
