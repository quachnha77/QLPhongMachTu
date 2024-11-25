using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace QLPhongMachTu_DOAN_.BLL
{ // Quản lý logic nghiệp vụ
    public class UserBLL
    {
        private UserDAL dal;

        public UserBLL() => this.dal = new UserDAL();

        public bool CreateUser(User user)
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

        public User CheckLogin(string userName, string matKhau)
        {
            var user = dal.CheckLogin(userName, matKhau);
            return user;
        }



        //BichNhung

        public string GetEmailByMa(long ma, string type)
        {
            return dal.GetEmailByMa(ma, type);
        }

        public bool UpdateEmailandMaPQ(long ma, string newEmail)
        {
            return dal.UpdateEmailandMaPQ(ma, newEmail);
        }

        public bool UpdateTrangThaiAndQuyen(long maUser, string tenquyen, bool trangThai)
        {
            return dal.UpdateTrangThaiAndQuyen(maUser, tenquyen, trangThai);
        }

        public bool ActivateAccount(long ma)
        {
            return dal.ActivateAccount(ma);
        }

        public bool LockAccount(long ma)
        {
            return dal.LockAccount(ma);
        }

        public long AddUserAndGetId(User user)
        {
            return dal.AddUserAndGetId(user);
        }

        //Kiểm tra tồn tại CCCD trong NhanViens và BacSis
        public bool IsCCCDExist(long cccd)
        {
            return dal.IsCCCDExist(cccd);
        }

        //Kiểm tra Email tồn tại trong NhanViens và BacSis 
        public bool IsEmailExist(string email)
        {
            return dal.IsEmailExist(email);
        }

}
