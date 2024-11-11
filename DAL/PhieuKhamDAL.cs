using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class PhieuKhamDAL : DatabaseHelper
    {
        public List<PhieuKham> GetAll()
        {
            string query = @"
                SELECT pk.*, lk.NgayKham AS NgayKhamLichKham, bn.TenBenhNhan, bs.TenBacSi
                FROM PhieuKham pk
                INNER JOIN LichKham lk ON pk.MaLK = lk.MaLK
                INNER JOIN BenhNhan bn ON pk.MaBN = bn.MaBN
                INNER JOIN BacSi bs ON pk.MaBS = bs.MaBS";

            DataTable result = ExecuteQuery(query);
            var list = new List<PhieuKham>();

            foreach (DataRow row in result.Rows)
            {
                list.Add(new PhieuKham
                {
                    MaPK = Convert.ToInt64(row[1]),
                    MaLK = Convert.ToInt64(row[2]),
                    MaBN = Convert.ToInt64(row[3]),
                    MaBS = Convert.ToInt64(row[4]),
                    NgayKham = Convert.ToDateTime(row[5]),
                    SoThuTu = Convert.ToInt32(row[6]),
                    TrieuChung = row[7].ToString(),
                    TieuSuBenhLy = row[8]?.ToString(),
                    ChuanDoan = row[9]?.ToString(),
                    //LichKham = new LichKham
                    //{
                    //    MaLK = Convert.ToInt64(row["MaLK"]),
                    //    NgayKham = Convert.ToDateTime(row["NgayKhamLichKham"]),
                    //    // Map other LichKham properties if necessary
                    //},
                    //BenhNhan = new BenhNhan
                    //{
                    //    MaBN = Convert.ToInt64(row["MaBN"]),
                    //    // Map other BenhNhan properties if necessary
                    //},
                    //BacSi = new BacSi
                    //{
                    //    Id = Convert.ToInt64(row["MaBS"]),
                    //    // Map other BacSi properties if necessary
                    //}
                });
            }
            return list;
        }

        public PhieuKham Create(PhieuKham newPhieuKham)
        {
            string query = @"
                INSERT INTO PhieuKham (MaLK, MaBN, MaBS, NgayKham, SoThuTu, TrieuChung, TieuSuBenhLy, ChuanDoan) 
                OUTPUT INSERTED.MaPK
                VALUES (@MaLK, @MaBN, @MaBS, @NgayKham, @SoThuTu, @TrieuChung, @TieuSuBenhLy, @ChuanDoan)";

            SqlParameter[] parameters = {
                new SqlParameter("@MaLK", newPhieuKham.MaLK),
                new SqlParameter("@MaBN", newPhieuKham.MaBN),
                new SqlParameter("@MaBS", newPhieuKham.MaBS),
                new SqlParameter("@NgayKham", newPhieuKham.NgayKham),
                new SqlParameter("@SoThuTu", newPhieuKham.SoThuTu),
                new SqlParameter("@TrieuChung", newPhieuKham.TrieuChung),
                new SqlParameter("@TieuSuBenhLy", newPhieuKham.TieuSuBenhLy ?? (object)DBNull.Value),
                new SqlParameter("@ChuanDoan", newPhieuKham.ChuanDoan ?? (object)DBNull.Value)
            };

            using (DataTable result = ExecuteQuery(query, parameters))
            {
                if (result.Rows.Count > 0)
                {
                    newPhieuKham.MaPK = Convert.ToInt64(result.Rows[0]["MaPK"]);
                }
                return newPhieuKham;
            }
        }
    }
}
