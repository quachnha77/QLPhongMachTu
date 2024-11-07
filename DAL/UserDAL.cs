using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class UserDAL
    {
        public User CheckLogin(string userName, string matKhau)
        {
            var userLogin = GetAllUser()
                .FirstOrDefault(user => user.Username == userName && user.Password == matKhau && user.TrangThai);
            return userLogin;
        }

        public bool CreateUser(User user)
        {
            using (var context = new ApplicationDbContext())
            {
                // Mã hóa mật khẩu trước khi lưu trữ
                user.Password = HashPassword(user.Password);
                context.User.Add(user);
                context.SaveChanges();
                return true;
            }
        }

        public void UpdateUser(User updatedUser, long id)
        {
            using (var context = new ApplicationDbContext())
            {
                var existedUser = context.User.Find(id);
                context.User.Attach(existedUser);
                if (existedUser != null)
                {
                    existedUser.Username = updatedUser.Username;
                    if (!string.IsNullOrEmpty(updatedUser.Password))
                    {
                        existedUser.Password = HashPassword(updatedUser.Password);
                    }
                    existedUser.Email = updatedUser.Email;
                    existedUser.TrangThai = updatedUser.TrangThai;
                    existedUser.PhanQuyen = context.PhanQuyen.Find(updatedUser.MaPQ);
                    existedUser.MaPQ = updatedUser.MaPQ;

                    context.SaveChanges();
                }
            }
        }

        public void DeleteUser(long id)
        {
            using (var context = new ApplicationDbContext())
            {
                var existedUser = context.User.Find(id);
                Console.WriteLine("\n ==> Remove User with id " + id);
                context.User.Attach(existedUser);
                context.User.Remove(existedUser);
                context.SaveChanges();
            }
        }

        public List<User> GetAllUser()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.User.ToList();
            }
        }

        public User GetById(long id)
        {
            var userList = this.GetAllUser();
            return userList.FirstOrDefault(u => u.MaUser == id);
        }

        private string HashPassword(string password)
        {
            // Sử dụng BCrypt để băm mật khẩu
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
