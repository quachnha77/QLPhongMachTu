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
                        CCCD = Convert.ToInt64(row["CCCD"]),
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
                string query = "INSERT INTO BacSis (MaKhoa, HoTen, CCCD, NgaySinh, GioiTinh, DiaChi, SDT, MaUser) " +
                               "VALUES (@MaKhoa, @HoTen, @CCCD, @NgaySinh, @GioiTinh, @DiaChi, @SDT, @MaUser)";
                
                SqlParameter[] parameters = {
                    new SqlParameter("@MaKhoa", bs.MaKhoa),
                    new SqlParameter("@HoTen", bs.HoTen),
                    new SqlParameter("@CCCD", bs.CCCD),
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

        // Lấy tên khoa từ mã bác sĩ
        public string GetKhoaByMa(long ma)
        {
            string tenPhongBan = string.Empty;

            // Truy vấn kết hợp để lấy tên khoa ngay từ một lần truy vấn
            string query = @"SELECT pk.TenPhongBan 
                     FROM BacSis bs
                     INNER JOIN PhongKhoas pk ON bs.MaKhoa = pk.MaPK
                     WHERE bs.MaSo = @MaBS";

            SqlParameter[] parameters = {
                new SqlParameter("@MaBS", ma)
            };

            // Sử dụng ExecuteScalar để thực thi truy vấn và lấy kết quả
            var result = ExecuteScalar(query, parameters);

            if (result != null)
            {
                tenPhongBan = result.ToString();
            }

            return tenPhongBan;
        }

        // Lấy Bác sĩ từ mã bác sĩ
        public BacSi GetBacSiByMa(long ma)
        {
            string query = "SELECT * FROM BacSis WHERE MaSo = @Ma";

            SqlParameter[] parameters = {
                new SqlParameter("@Ma", ma)
            };
            DataTable dataTable = ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                return new BacSi
                {
                    MaSo = Convert.ToInt64(row["MaSo"]),
                    HoTen = row["HoTen"].ToString(),
                    CCCD = Convert.ToInt64(row["CCCD"]),
                    SDT = row["SDT"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                    GioiTinh = row["GioiTinh"].ToString(),
                    MaKhoa = Convert.ToInt64(row["MaKhoa"]),
                    MaUser = Convert.ToInt64(row["MaUser"])
                };
            }
            return null;
        }

        // Cập nhật thông tin bác sĩ
        public bool UpdateBacSi(BacSi bs)
        {
            string query = "UPDATE BacSis " +
                           "SET HoTen = @HoTen, CCCD = @CCCD, SDT = @SDT, DiaChi = @DiaChi, " +
                           "NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, MaKhoa = @MaKhoa " +
                           "WHERE MaSo = @MaBS";

            SqlParameter[] parameters = {
                new SqlParameter("@MaBS", bs.MaSo),
                new SqlParameter("@HoTen", bs.HoTen),
                new SqlParameter("@CCCD", bs.CCCD),
                new SqlParameter("@SDT", bs.SDT),
                new SqlParameter("@DiaChi", bs.DiaChi),
                new SqlParameter("@NgaySinh", bs.NgaySinh),
                new SqlParameter("@GioiTinh", bs.GioiTinh),
                new SqlParameter("@MaKhoa", bs.MaKhoa)
            };

            int rowsAffected = ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        //Kiểm tra sự tồn tại của cccd

        public (bool, long) IsCCCDExistAndGetMaUser(long cccd)
        {
            string query = @"
                SELECT u.MaUser
                FROM BacSis bs
                INNER JOIN Users u ON bs.MaUser = u.MaUser
                INNER JOIN PhanQuyens pq ON u.MaPQ = pq.MaPQ
                WHERE bs.CCCD = @CCCD AND pq.TenQuyen = N'Vô hiệu hóa'";

            SqlParameter[] parameters = {
                new SqlParameter("@CCCD", SqlDbType.BigInt)
                {
                    Value = cccd
                }
            };

            object result = ExecuteScalar(query, parameters);

            if (result != null)
            {
                long maUser = Convert.ToInt64(result);
                return (true, maUser);  // Trả về true và MaUser nếu tìm thấy
            }
            else
            {
                return (false, -1);  // Trả về false và -1 nếu không tìm thấy
            }
        }

        //Xóa Bác sĩ
        public bool DeleteBacSi(long ma)
        {
            string query = @"DELETE FROM BacSis WHERE MaSo = @MaBS;
                DELETE FROM Users 
                WHERE MaUser = (SELECT MaUser FROM BacSis WHERE MaSo = @MaBS);";
                    

            SqlParameter[] parameters = {
                new SqlParameter("@MaBS", ma)
                    };
            int rowAffected = ExecuteNonQuery(query, parameters);
            return rowAffected > 0;
        }

        public bool UpdateBacSiByCCCD(BacSi bs)
        {
            string query = "UPDATE BacSis " +
                           "SET HoTen = @HoTen, CCCD = @CCCD, SDT = @SDT, DiaChi = @DiaChi, " +
                           "NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, MaKhoa = @MaKhoa " +
                           "WHERE CCCD = @CCCD";

            SqlParameter[] parameters = {
                new SqlParameter("@MaBS", bs.MaSo),
                new SqlParameter("@HoTen", bs.HoTen),
                new SqlParameter("@CCCD", bs.CCCD),
                new SqlParameter("@SDT", bs.SDT),
                new SqlParameter("@DiaChi", bs.DiaChi),
                new SqlParameter("@NgaySinh", bs.NgaySinh),
                new SqlParameter("@GioiTinh", bs.GioiTinh),
                new SqlParameter("@MaKhoa", bs.MaKhoa)
            };

            int rowsAffected = ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
    }
}
