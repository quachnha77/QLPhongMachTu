using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class UserDAL : DatabaseHelper
    {
        public User CheckLogin(string nameOrEmail, string password)
        {
            string query = @"SELECT * FROM Users
                            WHERE (Username = @nameOrEmail OR Email = @nameOrEmail)
                            AND Password = @Password";
            SqlParameter[] parameters = {
                new SqlParameter("@nameOrEmail", nameOrEmail),
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

        public User CreateUser(User user)
        {
            string query = "INSERT INTO Users (Username, Password, Email, MaPQ) OUTPUT INSERTED.Id VALUES (@Username, @Password, @Email, @MaPQ)";
            SqlParameter[] parameters = {
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@Email", user.Email),
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
    }
}
