using QLPhongMachTu_DOAN_.BLL;
using System;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class ResetPassword : Form
    {
        private readonly UserBLL userBLL;
        private string email;
        public ResetPassword()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            userBLL = new UserBLL();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string newPassword = txtMKMoi.Text.Trim();
            string confirmPassword = txtXNMK.Text.Trim();

            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng xác nhận mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool result = userBLL.UpdatePasswordByEmail(email, newPassword);

            if (result)
            {
                MessageBox.Show("Mật khẩu đã được thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login login = new Login();
                login.Show();
                this.Close(); // Đóng form sau khi cập nhật thành công
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật mật khẩu. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetData(string email)
        {
            this.email = email;
        }
    }
}
