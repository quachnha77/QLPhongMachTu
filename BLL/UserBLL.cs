using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QLPhongMachTu_DOAN_.BLL
{ // Quản lý logic nghiệp vụ
    public class UserBLL
    {
        private UserDAL dal;

        public UserBLL() => this.dal = new UserDAL();

        // ConKienHuy ->
        public User CreateUser2(User user)
        {
            return dal.CreateUser2(user);
        }

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
        public bool IsCCCDExist(long cccd)
        {
            return dal.IsCCCDExist(cccd);
        }

        public bool IsEmailExist(string email)
        {
            return dal.IsEmailExist(email);
        }
        public bool ActivateAccount(long ma)
        {
            return dal.ActivateAccount(ma);
        }
        public bool LockAccount(long ma)
        {
            return dal.LockAccount(ma);
        }

        public string GetEmailByMa(long ma, string type)
        {
            return dal.GetEmailByMa(ma, type);
        }

        public bool UpdateTrangThaiAndQuyen(long maUser, string tenquyen, bool trangThai)
        {
            return dal.UpdateTrangThaiAndQuyen(maUser, tenquyen, trangThai);
        }

        public long AddUserAndGetId(User user)
        {
            return dal.AddUserAndGetId(user);
        }

        public bool UpdateEmailandMaPQ(long ma, string newEmail)
        {
            return dal.UpdateEmailandMaPQ(ma, newEmail);
        }

        public bool UpdatePassword(string username, string newPassword)
        {
            return dal.UpdatePassword(username, newPassword);
        }

        public bool CheckOldPassword(long maUser, string oldPassword)
        {
            return dal.CheckOldPassword(maUser, oldPassword);
        }

        public bool UpdateUsernameByOldUsername(string oldUsername, string newUsername)
        {
            return dal.UpdateUsernameByOldUsername(oldUsername, newUsername);
        }

        public bool IsUsernameExists(string newUsername)
        {
            return dal.IsUsernameExists(newUsername);
        }

        public bool UpdateUserInfo(long maUser, string username, string hoTen, string gioiTinh, string cccd, DateTime ngaySinh, string sdt, string diaChi, string email)
        {
            return dal.UpdateUserInfo(maUser, username, hoTen, gioiTinh, cccd, ngaySinh, sdt, diaChi, email);
        }

        public DataTable GetUserDetails(long maUser)
        {
            return dal.GetUserDetails(maUser);
        }

        public bool IsEmailExist2(string email)
        {
            return dal.IsEmailExist2(email);
        }

        public bool UpdatePasswordByEmail(string email, string newPassword)
        {
            return dal.UpdatePasswordByEmail(email, newPassword);
        }
    }
}
