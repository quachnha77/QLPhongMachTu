using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class UserDAL
    {
        public bool CheckLogin(string userName, string matKhau)
        {
            List<User> userList = GetAllUser();
            foreach(var user in userList){
                if(user.Username == userName && user.Password == matKhau)
                    return true;
            }
            return false;
        }

        public User CreateUser(User user)
        {
            using(var context = new ApplicationDbContext())
            {
                var newUser = context.User.Add(user);
                context.SaveChanges();
                return newUser;
            }
        }

        public void UpdateUser(User updatedUser, long id)
        {
            using(var context = new ApplicationDbContext())
            {
                var existedUser = context.User.Find(id);
                context.User.Attach(existedUser);
                if(existedUser != null)
                {
                    existedUser.Username = updatedUser.Username;
                    existedUser.Password = updatedUser.Password;
                    existedUser.Email = updatedUser.Email;
                    existedUser.PhanQuyen = context.PhanQuyen.Find(updatedUser.MaPQ);
                    existedUser.MaPQ = updatedUser.MaPQ;
                }
                context.SaveChanges();
            }
        }

        public void DeleteUser(long id)
        {
            using(var context = new ApplicationDbContext())
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
            using(var context = new ApplicationDbContext())
            {
                return context.User.ToList();
            }
        }

        public User GetById(long id)
        {
            var userList = this.GetAllUser();
            return userList.FirstOrDefault(u => u.MaUser == id);
        }
    }
}
