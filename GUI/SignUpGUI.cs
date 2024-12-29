using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using QLPhongMachTu_DOAN_.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class SignUpGUI : Form
    {
        private readonly UserBLL userBLL;
        private readonly BenhNhanBLL benhNhanBLL;
        private readonly PhanQuyenBLL phanQuyenBLL;

        public SignUpGUI()
        {
            InitializeComponent();
            userBLL = new UserBLL();
            benhNhanBLL = new BenhNhanBLL();
            phanQuyenBLL = new PhanQuyenBLL();
        }

        private void txtBanDaCoTaiKhoan_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login lg = new Login();
            lg.Show();
        }

        private void btnDangKy_click(object sender, EventArgs e)
        {
            string userName = "";
            string matKhau = "";
            string email = "";
            string hoTen = "";
            long cccd;
            long maQuyenBenhNhan = -1;

            try
            {
                if (!ValidateFormData())
                    return;

                userName = txtTenDangNhap.Text;
                matKhau = txtMatKhau.Text;
                email = txtEmail.Text;
                hoTen = txtHoTen.Text;
                cccd = long.Parse(txtCCCD.Text);
                maQuyenBenhNhan = (long)EQuyen.BENHNHAN;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CCCD Sai định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            User temp = new User()
            {
                Username = userName,
                Password = matKhau,
                Email = email,
                MaPQ = maQuyenBenhNhan
            };

            User newUser = userBLL.CreateUser2(temp);

            BenhNhan benhNhan = new BenhNhan()
            {
                HoTen = hoTen,
                CCCD = cccd,
                MaUser = newUser.MaUser,
                GioiTinh = "nam",
                DiaChi = " ",
                SDT = " ",
                NgaySinh = new DateTime(1900, 1, 1)
            };

            var result = benhNhanBLL.Create(benhNhan);
            if (result != null)
            {
                MessageBox.Show("Tạo User thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ShowLoginPanel();
            }
            else
            {
                MessageBox.Show("Tạo User thất bại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidateFormData()
        {
            try
            {
                if (string.IsNullOrEmpty(txtTenDangNhap.Text) ||
                string.IsNullOrEmpty(txtMatKhau.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtHoTen.Text) ||
                string.IsNullOrEmpty(txtCCCD.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Kiểm tra userName
                string userName = txtTenDangNhap.Text;
                if (userName.Length < 3)
                {
                    MessageBox.Show("Username từ 3 ký tự trở lên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                // Kiểm tra email nhập vào có hợp lệ
                string email = txtEmail.Text;
                string pattern = "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$";
                if (!Regex.IsMatch(email, pattern))
                {
                    MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                } /* 
               * chưa có gửi mã xác nhận
               **/

                List<User> userList = userBLL.GetAll();

                // Kiểm tra trùng userName
                User isUsernameExist = userList.FirstOrDefault(user => user.Username.Equals(txtTenDangNhap.Text));
                if (isUsernameExist != null)
                {
                    MessageBox.Show("Username đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Kiểm tra trùng email
                User isEmailExsit = userList.FirstOrDefault(user => user.Email.Equals(txtEmail.Text));
                if (isEmailExsit != null)
                {
                    MessageBox.Show("Email đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                return true;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Lỗi nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new FormatException(ex.Message);
            }
        }

        private void ShowLoginPanel()
        {
            this.Hide();

            Login lg = new Login();
            lg.Show();

            //// Clear existing controls in panel1
            //panel12.Controls.Clear();

            //// Create a new instance of the LoginControl (UserControl)
            //Login loginControl = new Login();

            //// Set the DockStyle to Fill so it takes up the entire panel
            //loginControl.Dock = DockStyle.Fill;

            //// Add the UserControl to panel1
            //panel12.Controls.Add(loginControl);

            //// Optionally refresh the panel to ensure everything is rendered
            //panel12.Refresh();
        }
    }
}
