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
            string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password AND TrangThai = 1";
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
                    TrangThai = Convert.ToBoolean(row["TrangThai"]),
                    MaPQ = Convert.ToInt64(row["MaPQ"])
                };
            }
            return null;
        }

        // Huy
        public User CreateUser2(User user)
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
                }
                return user;
            }
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
            string query = "SELECT * FROM Users WHERE MaUser = @MaUser";
            SqlParameter[] parameters = {
                new SqlParameter("@MaUser", id)
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



        //BichNhung

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
                WHERE u.Email = @Email AND pq.TenQuyen != 'Bệnh nhân';";

            SqlParameter[] parameters = {
                new SqlParameter("@Email", email)
            };

            object result = ExecuteScalar(query, parameters);
            return result != null && Convert.ToInt32(result) > 0; // Trả về true nếu Email đã tồn tại trong NhanViens hoặc BacSis, false nếu không
        }

        // Kích hoạt lại tài khoản
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

        // Khóa tài khoản
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

        // Thêm mới user và lấy mã user 
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

        // Cập nhật password
        public bool UpdatePassword(string username, string newPassword)
        {
            string query = "UPDATE [User] SET Password = @NewPassword WHERE Username = @Username" +
                "";

            SqlParameter[] parameter = new SqlParameter[]
              {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Password", newPassword)
              };

            return ExecuteNonQuery(query, parameter) > 0;
        }

        // Kiểm tra mật khẩu cũ
        public bool CheckOldPassword(long maUser, string oldPassword)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE MaUser = @MaUser AND Password = @Password";

            SqlParameter[] parameter = new SqlParameter[]
               {
                    new SqlParameter("@MaUser", maUser),
                    new SqlParameter("@Password", oldPassword)
               };

            return ExecuteNonQuery(query, parameter) > 0;
        }

        // Cập nhật username mới
        public bool UpdateUsernameByOldUsername(string oldUsername, string newUsername)
        {
            string query = "UPDATE Users SET Username = @NewUsername WHERE Username = @OldUsername";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OldUsername", oldUsername),
                new SqlParameter("@NewUsername", newUsername)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        // Kiểm tra tồn tại username
        public bool IsUsernameExists(string newUsername)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", newUsername)
            };

            // Sử dụng ExecuteScalar để nhận giá trị đầu ra
            int count = (int)ExecuteScalar(query, parameters);
            return count > 0; // Nếu count > 0, username đã tồn tại
        }

        // Update thông tin người dùng
        public bool UpdateUserInfo(long maUser, string username, string hoTen, string gioiTinh, string cccd, DateTime ngaySinh, string sdt, string diaChi, string email)
        {
            try
            {
                // Lấy quyền của người dùng từ bảng PhanQuyens
                string query = @"
                    SELECT pq.TenQuyen 
                    FROM Users u 
                    INNER JOIN PhanQuyens pq ON u.MaPQ = pq.MaPQ 
                    WHERE u.MaUser = @MaUser";

                SqlParameter[] parameterCV = {
                    new SqlParameter("@MaUser", maUser)
                };

                object roleResult = ExecuteScalar(query, parameterCV);
                string tenQuyen = roleResult?.ToString(); // Xử lý null trả về nếu không có kết quả

                if (string.IsNullOrEmpty(tenQuyen))
                {
                    throw new Exception("Không tìm thấy quyền của người dùng.");
                }

                // Cập nhật thông tin trong bảng Users (email)
                string queryUpdateUser = @"
                    UPDATE Users 
                    SET Email = @Email 
                    WHERE Username = @Username";

                SqlParameter[] paramUpdateUser = {
                    new SqlParameter("@Email", email),
                    new SqlParameter("@Username", username)
                };

                bool isUserUpdated = ExecuteNonQuery(queryUpdateUser, paramUpdateUser) > 0;

                // Kiểm tra cập nhật email thành công
                if (!isUserUpdated)
                {
                    throw new Exception("Cập nhật email không thành công.");
                }

                // Xác định bảng cần cập nhật thông tin
                bool isInfoUpdated = false;

                // Cập nhật thông tin vào bảng Bệnh nhân nếu quyền là Bệnh nhân
                if (tenQuyen == "Bệnh nhân")
                {
                    string queryUpdateBenhNhan = @"
                        UPDATE BenhNhans 
                        SET HoTen = @HoTen, GioiTinh = @GioiTinh, CCCD = @CCCD, NgaySinh = @NgaySinh, SDT = @SDT, DiaChi = @DiaChi 
                        WHERE MaUser IN (SELECT MaUser FROM Users WHERE Username = @Username)";

                    SqlParameter[] parametersBenhNhan = new SqlParameter[] {
                        new SqlParameter("@HoTen", hoTen),
                        new SqlParameter("@GioiTinh", gioiTinh),
                        new SqlParameter("@CCCD", cccd),
                        new SqlParameter("@NgaySinh", ngaySinh),
                        new SqlParameter("@SDT", sdt),
                        new SqlParameter("@DiaChi", diaChi),
                        new SqlParameter("@Username", username)
                    };

                    isInfoUpdated = ExecuteNonQuery(queryUpdateBenhNhan, parametersBenhNhan) > 0;
                }
                else
                {
                    // Cập nhật thông tin vào bảng Bác sĩ nếu quyền là Bác sĩ
                    string queryUpdateBacSi = @"
                        UPDATE BacSis 
                        SET HoTen = @HoTen, GioiTinh = @GioiTinh, CCCD = @CCCD, NgaySinh = @NgaySinh, SDT = @SDT, DiaChi = @DiaChi 
                        WHERE MaUser IN (SELECT MaUser FROM Users WHERE Username = @Username)";

                    SqlParameter[] parametersBacSi = new SqlParameter[] {
                        new SqlParameter("@HoTen", hoTen),
                        new SqlParameter("@GioiTinh", gioiTinh),
                        new SqlParameter("@CCCD", cccd),
                        new SqlParameter("@NgaySinh", ngaySinh),
                        new SqlParameter("@SDT", sdt),
                        new SqlParameter("@DiaChi", diaChi),
                        new SqlParameter("@Username", username)
                    };

                    bool isBacSiUpdated = ExecuteNonQuery(queryUpdateBacSi, parametersBacSi) > 0;

                    // Cập nhật thông tin vào bảng Nhân viên nếu quyền là Dược sĩ, Lễ tân, Admin hoặc Y tá
                    string queryUpdateNhanVien = @"
                        UPDATE NhanViens 
                        SET HoTen = @HoTen, GioiTinh = @GioiTinh, CCCD = @CCCD, NgaySinh = @NgaySinh, SDT = @SDT, DiaChi = @DiaChi 
                        WHERE MaUser IN (SELECT MaUser FROM Users WHERE Username = @Username)";

                    SqlParameter[] parametersNhanVien = new SqlParameter[] {
                        new SqlParameter("@HoTen", hoTen),
                        new SqlParameter("@GioiTinh", gioiTinh),
                        new SqlParameter("@CCCD", cccd),
                        new SqlParameter("@NgaySinh", ngaySinh),
                        new SqlParameter("@SDT", sdt),
                        new SqlParameter("@DiaChi", diaChi),
                        new SqlParameter("@Username", username)
                    };

                    bool isNhanVienUpdated = ExecuteNonQuery(queryUpdateNhanVien, parametersNhanVien) > 0;

                    // Nếu quyền là Bác sĩ hoặc Nhân viên, kiểm tra việc cập nhật
                    isInfoUpdated = isBacSiUpdated || isNhanVienUpdated;
                }

                // Trả về kết quả của cả hai cập nhật
                return isUserUpdated && isInfoUpdated;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và ghi log nếu cần
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        // Lấy thông tin người dùng
        public DataTable GetUserDetails(long maUser)
        {
            string query =
                "SELECT u.MaUser, u.Username, u.PassWord, u.Email, " +
                    "ISNULL(nv.CCCD, ISNULL(bs.CCCD, bn.CCCD)) AS CCCD, " +
                    "ISNULL(nv.HoTen, ISNULL(bs.HoTen, bn.HoTen)) AS HoTen, " +
                    "ISNULL(nv.NgaySinh, ISNULL(bs.NgaySinh, bn.NgaySinh)) AS NgaySinh, " +
                    "ISNULL(nv.GioiTinh, ISNULL(bs.GioiTinh, bn.GioiTinh)) AS GioiTinh, " +
                    "ISNULL(nv.DiaChi, ISNULL(bs.DiaChi, bn.DiaChi)) AS DiaChi, " +
                    "ISNULL(nv.SDT, ISNULL(bs.SDT, bn.SDT)) AS SDT " +
                "FROM Users u " +
                "LEFT JOIN NhanViens nv ON u.MaUser = nv.MaUser " +
                "LEFT JOIN BacSis bs ON u.MaUser = bs.MaUser " +
                "LEFT JOIN BenhNhans bn ON u.MaUser = bn.MaUser " +
                "WHERE u.MaUser = @MaUser";

            SqlParameter[] parameter = {
                new SqlParameter("MaUser", maUser),
            };

            return ExecuteQuery(query, parameter);
        }

        //Kiểm tra Email tồn tại
        public bool IsEmailExist2(string email)
        {
            string query = @"SELECT COUNT(*) FROM Users u WHERE u.Email = @Email";

            SqlParameter[] parameters = {
                new SqlParameter("@Email", email)
            };

            object result = ExecuteScalar(query, parameters);
            return result != null && Convert.ToInt32(result) > 0; // Trả về true nếu Email đã tồn tại trong NhanViens hoặc BacSis, false nếu không
        }

        // Cập nhật mật khẩu bởi email
        public bool UpdatePasswordByEmail(string email, string newPassword)
        {
            string query = "UPDATE Users SET Password = @NewPassword WHERE Email = @Email" +
                "";

            SqlParameter[] parameter = new SqlParameter[]
              {
                    new SqlParameter("@NewPassword", newPassword),
                    new SqlParameter("@Email", email) 
              };

            return ExecuteNonQuery(query, parameter) > 0;
        }
    }
}
