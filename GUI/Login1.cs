﻿using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using QLPhongMachTu_DOAN_.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class Login1 : UserControl
    {
        private readonly UserBLL userBLL;
        private readonly BenhNhanBLL benhNhanBLL;
        public Login1()
        {
            userBLL = new UserBLL();
            benhNhanBLL = new BenhNhanBLL();
            InitializeComponent();
        }

        private void lbBanChuaCoTaiKhoan_Click(object sender, EventArgs e)
        {
            // Clear existing controls in panel1
            panel1.Controls.Clear();

            // Create a new instance of the LoginControl (UserControl)
            SignUp signUpControl = new SignUp();

            // Set the DockStyle to Fill so it takes up the entire panel
            signUpControl.Dock = DockStyle.Fill;

            // Add the UserControl to panel1
            panel1.Controls.Add(signUpControl);

            // Optionally refresh the panel to ensure everything is rendered
            panel1.Refresh();
        }

        private void dangnhapBtn_Click(object sender, EventArgs e)
        {
            // Loại bỏ khoảng trắng ở đầu và cuối trước khi kiểm tra
            string userName = userNameTxt.Text.Trim();
            string matKhau = matkhauTxt.Text.Trim();

            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Vui lòng nhập Email/Username!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var user = LoginHandle(userName, matKhau);
            var benhNhan = TimTheoUserID(user.MaUser);
            switch (user.MaPQ)
            {
                case (long)EQuyen.ADMIN:
                    NavbarQuanLi navQuanLi = new NavbarQuanLi();
                    navQuanLi.Show();
                    this.Dispose();
                    break;
                case (long)EQuyen.BACSI:
                    NavbarBacSi navBacSi = new NavbarBacSi();
                    navBacSi.Show();
                    this.Dispose();
                    break;
                case (long)EQuyen.DUOCSI:
                    NavbarDuocSi naDuocSi = new NavbarDuocSi();
                    naDuocSi.Show();
                    this.Dispose();
                    break;
                case (long)EQuyen.LETAN:
                    NavbarLeTan navLeTan = new NavbarLeTan();
                    navLeTan.Show();
                    this.Dispose();
                    break;
                case (long)EQuyen.BENHNHAN:
                    NavbarBenhNhan navBenhNhan = new NavbarBenhNhan(user, benhNhan);
                    navBenhNhan.Show();
                    this.Dispose();
                    break;
                case -1: default:
                    MessageBox.Show("Đăng nhập thất bại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private User LoginHandle(string userName, string matKhau)
        {
            return userBLL.CheckLogin(userName, matKhau);
        }

        private BenhNhan TimTheoUserID(long userId)
        {
            return benhNhanBLL.GetByUserID(userId);
        }
    }
}
