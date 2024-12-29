using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class PhanCongDAL : DatabaseHelper
    {
        //public LichPhanCong taoLichPhanCong(LichPhanCong lichPhanCong)
        //{
        //    string query = "INSERT INTO LichPhanCongs (MaNV ,MaBS, GhiChu, gioBatDau, gioKetThuc, NgayPhanCong, CaLam) OUTPUT INSERTED.Id VALUES (@MaBS, @NgayPhanCong, @CaLam)";
        //    SqlParameter[] parameters = {
        //        new SqlParameter("@MaNV", lichPhanCong.MaNV),
        //        new SqlParameter("@MaBS", lichPhanCong.MaBS),
        //        new SqlParameter("@GhiChu", lichPhanCong.GhiChu),
        //        //new SqlParameter("@gioBatDau", lichPhanCong.gioBatDau),
        //        //new SqlParameter("@gioKetThuc", lichPhanCong.gioKetThuc),
        //        //new SqlParameter("@NgayPhanCong", lichPhanCong.NgayPhanCong),
        //    };

        //    using (DataTable result = ExecuteQuery(query, parameters))
        //    {
        //        if (result.Rows.Count > 0)
        //        {// Gán ID
        //            lichPhanCong.MaLPC = Convert.ToInt64(result.Rows[0][0]);
        //        }
        //        return lichPhanCong;
        //    }
        //}

        public List<LichPhanCong> GetAllByMaBacSi(long maBacSi)
        {
            string query = @"
                SELECT lp.MaLPC, lp.MaNV, lp.MaBS, lp.GhiChu, lp.NgayThucHien, pk.ChuyenKhoa
                FROM LichPhanCongs lp
                JOIN BacSis bs ON lp.MaBS = bs.MaSo 
                JOIN PhongKhoas pk ON bs.MaKhoa = pk.MaPK
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
                    MaLPC = Convert.ToInt64(row["MaLPC"]),
                    MaNV = Convert.ToInt64(row["MaNV"]),
                    MaBS = Convert.ToInt64(row["MaBS"]),
                    GhiChu = Convert.ToString(row["GhiChu"]),
                    NgayThucHien = Convert.ToDateTime(row["NgayThucHien"]),
                });
            }
            return list;
        }

        public LichPhanCong GetById(long id)
        {
            string query = @"
                SELECT lp.*, bs.HoTen, pk.TenPhongBan
                FROM LichPhanCongs lp
                INNER JOIN BacSis bs ON lp.MaBS = bs.MaSo
                INNER JOIN PhongKhoas pk ON bs.MaKhoa = pk.MaPK
                WHERE lp.MaLPC = @Id";

            SqlParameter[] parameters = {
                new SqlParameter("@Id", id)
            };

            DataTable result = ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                return new LichPhanCong
                {
                    MaLPC = Convert.ToInt64(row[0]),
                    MaNV = Convert.ToInt64(row[1]),
                    MaBS = Convert.ToInt64(row[2]), // long 64 bit
                    GhiChu = Convert.ToString(row[3]),
                    //gioBatDau = Convert.ToInt32(row[4]),
                    //gioKetThuc = Convert.ToInt32(row[5]),
                    NgayThucHien = Convert.ToDateTime(row["NgayThucHien"]),
                    
                };
            }
            return null;
        }

        public List<LichPhanCong> GetAllByNgayPhanCong(DateTime ngayThucHien)
        {
            // Câu lệnh SQL với tham số @NgayThucHien
            string query = @"
                SELECT MaLPC, MaNV, MaBS, GhiChu, NgayThucHien
                FROM LichPhanCongs
                WHERE NgayThucHien = @NgayThucHien
            ";

            // Khai báo tham số SQL
            SqlParameter[] parameters = {
                new SqlParameter("@NgayThucHien", SqlDbType.DateTime) { Value = ngayThucHien }
            };

            // Thực hiện truy vấn và lấy dữ liệu trả về
            DataTable result = ExecuteQuery(query, parameters);

            // Khởi tạo danh sách để lưu kết quả
            var list = new List<LichPhanCong>();

            // Chuyển đổi dữ liệu từ DataTable sang danh sách các đối tượng LichPhanCong
            foreach (DataRow row in result.Rows)
            {
                list.Add(new LichPhanCong
                {
                    MaLPC = Convert.ToInt64(row["MaLPC"]),
                    MaNV = Convert.ToInt64(row["MaNV"]),
                    MaBS = Convert.ToInt64(row["MaBS"]),
                    GhiChu = Convert.ToString(row["GhiChu"]),
                    NgayThucHien = Convert.ToDateTime(row["NgayThucHien"]),
                });
            }

            // Trả về danh sách kết quả
            return list;
        }

        //Khoa


        public List<LichPhanCong> GetAll()
        {
            string query = "SELECT * FROM LichPhanCongs";

            DataTable result = ExecuteQuery(query);
            var list = new List<LichPhanCong>();

            foreach (DataRow row in result.Rows)
            {
                list.Add(new LichPhanCong
                {
                    MaLPC = Convert.ToInt64(row[0]),
                    MaLK = Convert.ToInt64(row[1]),
                    MaNV = Convert.ToInt64(row[2]),
                    MaBS = Convert.ToInt64(row[3]),
                    NgayThucHien = Convert.ToDateTime(row[4]),
                    GhiChu = Convert.ToString(row[5]),
                    //TrangThai = Convert.ToString(row[6]),
                    //ThoiGian = Convert.ToDateTime(row[5]),
                    //GhiChu = Convert.ToString(row[6]),

                });
            }
            return list;
        }

        public void CreateLichPhanCong(LichPhanCong lpc)
        {
            string query = "INSERT INTO LichPhanCongs (MaLK, MaNV, MaBS, NgayThucHien, GhiChu) VALUES (@MaLK, @MaNV, @MaBS, @NgayThucHien, @GhiChu)";
            SqlParameter[] parameters = {
                new SqlParameter("@MaLK", lpc.MaLK),
                new SqlParameter("@MaNV", lpc.MaNV),
                new SqlParameter("@MaBS", lpc.MaBS),
                new SqlParameter("@NgayThucHien", lpc.NgayThucHien),
                //new SqlParameter("@ThoiGian", lpc.ThoiGian),
                new SqlParameter("@GhiChu", lpc.GhiChu),
            };
            try
            {
                ExecuteNonQuery(query, parameters);
            }
            catch (SqlException ex)
            {
                // Ghi log hoặc thông báo lỗi
                throw new Exception("Lỗi khi tạo lịch phân công: " + ex.Message);
            }
        }

        public void EditLichPhanCong(LichPhanCong lpc)
        {
            string query = "UPDATE LichPhanCongs SET MaNV = @MaNV, MaBS = @MaBS, NgayThucHien = @NgayThucHien, GhiChu = @GhiChu WHERE MaLPC = @MaLPC";
            SqlParameter[] parameters = {
                new SqlParameter("@MaNV", lpc.MaNV),
                new SqlParameter("@MaBS", lpc.MaBS),
                new SqlParameter("@NgayThucHien", lpc.NgayThucHien),
                //new SqlParameter("@ThoiGian", lpc.ThoiGian),
                new SqlParameter("@GhiChu", lpc.GhiChu),
                new SqlParameter("@MaLPC", lpc.MaLPC),
            };

            ExecuteNonQuery(query, parameters);
        }

        public void DeleteLichPhanCong(int ma_lpc)
        {
            string query = "DELETE FROM LichPhanCongs WHERE MaLPC = @MaLPC";
            SqlParameter[] parameters = {
                new SqlParameter("@MaLPC", ma_lpc)
            };

            ExecuteNonQuery(query, parameters);
        }
    }
}
