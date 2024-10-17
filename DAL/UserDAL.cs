using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{ // Truy cập database
    public class UserDAL
    {
        // Đổ dữ liệu mẫu
        private List<User> userList = new List<User>
        {
            new User{MaUser = 1,  MaQuyen = 1, Username="Dummy", Email="DM@example.com", Password="123" },
            new User{MaUser = 2,  MaQuyen = 3, Username="admin", Email="admin@example.com", Password="123" },
            new User{MaUser = 3,  MaQuyen = 2, Username="Dummy2", Email="DM@example.com", Password="123" },
            new User{MaUser = 4,  MaQuyen = 4, Username="Dummy3", Email="DM@example.com", Password="123" }
        };
        public bool CheckLogin(string userName, string matKhau)
        {
            foreach(var user in userList){
                if(user.Username == userName && user.Password == matKhau)
                    return true;
            }
            return false;
        }

        public void Create(User user)
        {
            userList.Add(user);
        }

        internal List<User> GetAll()
        {
            return userList;
        }

        internal User GetById(long id)
        {
            return userList.FirstOrDefault(u => u.MaUser == id);
        }
    }
}
