using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.BLL
{ // Quản lý logic nghiệp vụ
    public class UserBLL
    {
        private UserDAL dal;

        public UserBLL() => this.dal = new UserDAL();

        public User CreateUser(User user)
        {
            return dal.CreateUser(user);
        }

        public void Update(long id, User updatedUser)
        {
            dal.UpdateUser(updatedUser, id);
        }

        public void Delete(long id)
        {
            dal.DeleteUser(id);
        }

        public List<User> GetAll()
        {
            return dal.GetAllUser();
        }

        public User GetById(long id)
        {
            return dal.GetById(id);
        }

        public long CheckLogin(string userName, string matKhau)
        {   // Trả về mã quyền của User
            var user = dal.CheckLogin(userName, matKhau);
            if (user != null)
                return user.MaPQ;
            else
                return -1;
        }
    }
}
