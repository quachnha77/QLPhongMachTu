using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class UserDAL : DatabaseHelper
    {
        public User CheckLogin(string userName, string password)
        {
            string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
            SqlParameter[] parameters = {
                new SqlParameter("@Username", userName),
                new SqlParameter("@Password", password)
            };

            DataTable result = ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                return new User
                {
                    MaUser = Convert.ToInt64(row["MaUser"]),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    Email = row["Email"].ToString(),
                    MaPQ = Convert.ToInt64(row["MaPQ"])
                };
            }
            return null;
        }

        public bool CreateUser(User user)
        {
            string query = "INSERT INTO Users (Username, Password, Email, TrangThai, MaPQ) OUTPUT INSERTED.MaUser VALUES (@Username, @Password, @Email, @TrangThai, @MaPQ)";
            SqlParameter[] parameters = {
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@TrangThai", true), // Mặc định trạng thái là true
                new SqlParameter("@MaPQ", user.MaPQ)
            };

            using (DataTable result = ExecuteQuery(query, parameters))
            {
                if (result.Rows.Count > 0)
                {
                    user.MaUser = Convert.ToInt64(result.Rows[0]["MaUser"]);
                    return true;
                }
                return false;
            }
        }

        public void UpdateUser(User updatedUser, long id)
        {
            string query = "UPDATE Users SET Username = @Username, Password = @Password, Email = @Email, MaPQ = @MaPQ WHERE MaUser = @Id";
            SqlParameter[] parameters = {
                new SqlParameter("@Username", updatedUser.Username),
                new SqlParameter("@Password", updatedUser.Password),
                new SqlParameter("@Email", updatedUser.Email),
                new SqlParameter("@MaPQ", updatedUser.MaPQ),
                new SqlParameter("@Id", id)
            };

            ExecuteNonQuery(query, parameters);
        }

        public void DeleteUser(long id)
        {
            string query = "DELETE FROM Users WHERE MaUser = @Id";
            SqlParameter[] parameters = {
                new SqlParameter("@Id", id)
            };

            ExecuteNonQuery(query, parameters);
        }

        public List<User> GetAllUser()
        {
            string query = "SELECT * FROM Users";
            DataTable result = ExecuteQuery(query);

            return (from DataRow row in result.Rows
                    select new User
                    {
                        MaUser = Convert.ToInt64(row["MaUser"]),
                        Username = row["Username"].ToString(),
                        Password = row["Password"].ToString(),
                        Email = row["Email"].ToString(),
                        TrangThai = Convert.ToBoolean(row["TrangThai"]),
                        MaPQ = Convert.ToInt64(row["MaPQ"])
                    }).ToList();
        }

        public User GetById(long id)
        {
            string query = "SELECT * FROM Users WHERE MaUser = @Id";
            SqlParameter[] parameters = {
                new SqlParameter("@Id", id)
            };

            DataTable result = ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                return new User
                {
                    MaUser = Convert.ToInt64(row["MaUser"]),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    Email = row["Email"].ToString(),
                    TrangThai = Convert.ToBoolean(row["TrangThai"]),
                    MaPQ = Convert.ToInt64(row["MaPQ"])
                };
            }
            return null;
        }



        //BichNhung


        // Lấy email dựa trên MaNV hoặc MaBS
        public string GetEmailByMa(long ma, string type)
        {
            if (string.IsNullOrEmpty(type) || (type != "NhanVien" && type != "BacSi"))
            {
                throw new ArgumentException("Loại không hợp lệ. Vui lòng chọn 'NhanVien' hoặc 'BacSi'.");
            }

            string query = string.Empty;

            // Xác định câu lệnh truy vấn dựa trên loại
            if (type == "NhanVien")
            {
                query = "SELECT u.Email FROM NhanViens nv JOIN Users u ON nv.MaUser = u.MaUser WHERE nv.MaSo = @Ma";
            }
            else if (type == "BacSi")
            {
                query = "SELECT u.Email FROM BacSis bs JOIN Users u ON bs.MaUser = u.MaUser WHERE bs.MaSo = @Ma";
            }

            SqlParameter[] parameters = { new SqlParameter("@Ma", ma) };
            DataTable result = ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                return result.Rows[0]["Email"].ToString();
            }

            return string.Empty;  // Trả về chuỗi rỗng nếu không tìm thấy email
        }

        // Cập nhật email và mã quyền
        public bool UpdateEmailandMaPQ(long ma, string newEmail)
        {
            string query = @"DECLARE @MaUser INT, @ChucVu NVARCHAR(50);

                SELECT TOP 1 @MaUser = COALESCE(nv.MaUser, bs.MaUser),
                    @ChucVu = COALESCE(nv.ChucVu, 'Bác sĩ')
                FROM NhanViens nv
                FULL OUTER JOIN BacSis bs ON nv.MaUser = bs.MaUser
                WHERE nv.MaSo = @Ma OR bs.MaSo = @Ma;

                UPDATE Users
                SET Email = @Email,
                    MaPQ = (SELECT TOP 1 pq.MaPQ FROM PhanQuyens pq WHERE pq.TenQuyen = @ChucVu)
                WHERE MaUser = @MaUser;";

            SqlParameter[] parameters = {
                new SqlParameter("@Ma", ma),
                new SqlParameter("@Email", newEmail)
            };
            int rowsAffected = ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        //Cập nhật trạng thái và quyền
        public bool UpdateTrangThaiAndQuyen(long maUser, string tenquyen, bool trangThai)
        {
            string query = @"
                UPDATE Users
                SET TrangThai = @TrangThai,
                MaPQ = (SELECT MaPQ FROM PhanQuyens WHERE TenQuyen = @TenQuyen)
                WHERE MaUser = @MaUser";


            SqlParameter[] parameters = {
                new SqlParameter("@MaUser", maUser),
                new SqlParameter("@TenQuyen", SqlDbType.NVarChar)
                {
                    Value = tenquyen
                },
                new SqlParameter("@TrangThai", trangThai)

            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        // Kích hoạt lại tài khoản bác sĩ
        public bool ActivateAccount(long ma)
        {
            string query = @"
                UPDATE Users 
                SET TrangThai = 1 
                WHERE MaUser = (
                    SELECT TOP 1 MaUser 
                    FROM (
                        SELECT MaUser FROM NhanViens WHERE MaSo = @MaNV
                        UNION ALL 
                        SELECT MaUser FROM BacSis WHERE MaSo = @MaBS
                    ) AS Combined
                );";

            SqlParameter[] parameters = {
                new SqlParameter("@MaNV", ma),
                new SqlParameter("@MaBS", ma)
            };

            int rowsAffected = ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        // Khóa tài khoản bác sĩ
        public bool LockAccount(long ma)
        {
            string query = @"
                UPDATE Users 
                SET TrangThai = 0 
                WHERE MaUser = (
                    SELECT TOP 1 MaUser 
                    FROM (
                        SELECT MaUser FROM NhanViens WHERE MaSo = @MaNV
                        UNION ALL 
                        SELECT MaUser FROM BacSis WHERE MaSo = @MaBS
                    ) AS Combined
                );";

            SqlParameter[] parameters = {
                new SqlParameter("@MaNV", ma),
                new SqlParameter("@MaBS", ma)
            };

            int rowsAffected = ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        // Thêm nhân viên vào cơ sở dữ liệu
        public long AddUserAndGetId(User user)
        {
            string query = "INSERT INTO Users (MaPQ, Username, Password, Email, TrangThai) " +
                           "VALUES (@MaPQ, @Username, @Password, @Email, @TrangThai); " +
                           "SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = {
        new SqlParameter("@MaPQ", user.MaPQ),
        new SqlParameter("@Username", user.Username),
        new SqlParameter("@Password", user.Password),
        new SqlParameter("@Email", user.Email),
        new SqlParameter("@TrangThai", true)
    };

            object result = ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt64(result) : -1; // Trả về ID nếu thêm thành công, hoặc -1 nếu có lỗi
        }

        //Kiểm tra tồn tại CCCD trong NhanViens và BacSis
        public bool IsCCCDExist(long cccd)
        {
            string query = "SELECT COUNT(*) " +
                "FROM (SELECT CCCD FROM NhanViens " +
                "UNION SELECT CCCD FROM BacSis) AS CCCDList " +
                "WHERE CCCD = @CCCD";

            SqlParameter[] parameters = {
                new SqlParameter("@CCCD", SqlDbType.BigInt)
                {
                    Value = cccd
                }
            };

            object result = ExecuteScalar(query, parameters);
            return result != null && Convert.ToInt32(result) > 0;
        }

        //Kiểm tra Email tồn tại trong NhanViens và BacSis 
        public bool IsEmailExist(string email)
        {
            string query = @"SELECT COUNT(*) 
                FROM Users u
                INNER JOIN PhanQuyens pq ON u.MaPQ = pq.MaPQ
                WHERE u.Email = @Email AND pq.TenQuyen != 'Bệnh nhân';
    ";

            SqlParameter[] parameters = {
                new SqlParameter("@Email", email)
            };

            object result = ExecuteScalar(query, parameters);
            return result != null && Convert.ToInt32(result) > 0; // Trả về true nếu Email đã tồn tại trong NhanViens hoặc BacSis, false nếu không
        }
    }
}
