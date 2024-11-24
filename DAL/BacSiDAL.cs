using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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

        // Bích Nhung
        // Lấy danh sách tất cả bác sĩ
        public List<BacSi> GetAllBacSi()
        {
            List<BacSi> bacSiList = new List<BacSi>();
            try
            {
                string sql = "SELECT * FROM BacSis";
                DataTable result = ExecuteQuery(sql);

                foreach (DataRow row in result.Rows)
                {
                    BacSi bs = new BacSi
                    {
                        MaSo = Convert.ToInt64(row["MaSo"]),
                        MaKhoa = Convert.ToInt64(row["MaKhoa"]),
                        HoTen = Convert.ToString(row["HoTen"]),
                        NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                        GioiTinh = Convert.ToString(row["GioiTinh"]),
                        DiaChi = Convert.ToString(row["DiaChi"]),
                        SDT = Convert.ToString(row["SDT"]),
                        MaUser = Convert.ToInt64(row["MaUser"]),
                    };
                    bacSiList.Add(bs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách bác sĩ: {ex.Message}");
            }

            return bacSiList;
        }

        // Thêm bác sĩ vào cơ sở dữ liệu
        public bool AddBacSi(BacSi bs)
        {
            try
            {
                string query = "INSERT INTO BacSis (MaKhoa, HoTen, NgaySinh, GioiTinh, DiaChi, SDT, MaUser) " +
                               "VALUES (@MaKhoa, @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @SDT, @MaUser)";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaKhoa", bs.MaKhoa),
                    new SqlParameter("@HoTen", bs.HoTen),
                    new SqlParameter("@NgaySinh", bs.NgaySinh),
                    new SqlParameter("@GioiTinh", bs.GioiTinh),
                    new SqlParameter("@DiaChi", bs.DiaChi),
                    new SqlParameter("@SDT", bs.SDT),
                    new SqlParameter("@MaUser", bs.MaUser)
                };

                int rowsAffected = ExecuteNonQuery(query, parameters);
                return rowsAffected > 0; // Trả về true nếu thêm thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm bác sĩ vào cơ sở dữ liệu: {ex.Message}");
                return false;
            }
        }
    }
}
