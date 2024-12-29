using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using QLPhongMachTu_DOAN_.Enums;
using QLPhongMachTu_DOAN_.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class Login : Form
    {
        private readonly UserBLL userBLL;
        private readonly BenhNhanBLL benhNhanBLL;
        private readonly BacSiBLL bacSiBLL;
        private readonly NhanVienBLL nhanVienBLL;

        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            userBLL = new UserBLL();
            benhNhanBLL = new BenhNhanBLL();
            bacSiBLL = new BacSiBLL();
            nhanVienBLL = new NhanVienBLL();
        }

        private void lbBanChuaCoTaiKhoan_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpGUI signUpControl = new SignUpGUI();
            signUpControl.Show();
        }

        private void dangNhapbtn_Click_1(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void DangNhap()
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

            User user = userBLL.CheckLogin(userName, matKhau);

            if (user == null)
            {
                MessageBox.Show("Sai thông tin đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoginSession.MaUser = user.MaUser;
            var benhNhan = TimTheoUserID(user.MaUser);
            switch (user.MaPQ)
            {
                case (long)EQuyen.ADMIN:
                    NavbarQuanLi navQuanLi = new NavbarQuanLi();
                    navQuanLi.Show();
                    this.Hide();
                    break;
                case (long)EQuyen.BACSI:
                    BacSi bacSi = bacSiBLL.GetByUserId(user.MaUser);
                    NavbarBacSi navBacSi = new NavbarBacSi(bacSi);
                    navBacSi.Show();
                    this.Hide();
                    break;
                case (long)EQuyen.DUOCSI:
                    NavbarDuocSi naDuocSi = new NavbarDuocSi();
                    naDuocSi.Show();
                    this.Hide();
                    break;
                case (long)EQuyen.LETAN:
                    List<NhanVien> nhanVienList = nhanVienBLL.GetAllNhanVien();
                    NhanVien nhanVien = nhanVienList.FirstOrDefault(nv => nv.MaUser == user.MaUser);
                    NavbarLeTan navLeTan = new NavbarLeTan(nhanVien);
                    navLeTan.Show();
                    this.Hide();
                    break;
                case (long)EQuyen.BENHNHAN:
                    NavbarBenhNhan navBenhNhan = new NavbarBenhNhan(user, benhNhan);
                    navBenhNhan.Show();
                    this.Hide();
                    break;
                case -1:
                default:
                    MessageBox.Show("Đăng nhập thất bại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private BenhNhan TimTheoUserID(long userId)
        {
            return benhNhanBLL.GetByUserID(userId);
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                matkhauTxt.UseSystemPasswordChar = false;
            }
            else
            {
                matkhauTxt.UseSystemPasswordChar = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgotPasswordGUI forgotPassword = new ForgotPasswordGUI();
            forgotPassword.Show();
        }
    }
}
