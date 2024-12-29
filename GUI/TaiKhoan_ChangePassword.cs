using QLPhongMachTu_DOAN_.BLL;
using System;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class TaiKhoan_ChangePassword : Form
    {
        private UserBLL userBLL;
        private long currentUser;
        private string oldusername;
        public TaiKhoan_ChangePassword()
        {
            InitializeComponent();
            userBLL = new UserBLL();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mkCu = txtCu.Text;
            string mkMoi = txtMoi.Text;
            string xacNhan = txtXacNhan.Text;

            // Kiểm tra các textbox không được để trống
            if (string.IsNullOrEmpty(mkCu) || string.IsNullOrEmpty(mkMoi) || string.IsNullOrEmpty(xacNhan))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra mật khẩu mới và xác nhận mật khẩu có trùng khớp
            if (mkMoi != xacNhan)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra mật khẩu cũ trong cơ sở dữ liệu
            if (userBLL.CheckOldPassword(currentUser, mkCu))
            {
                // Cập nhật mật khẩu mới
                if (userBLL.UpdatePassword(oldusername, mkMoi))
                {
                    MessageBox.Show("Thay đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form sau khi đổi mật khẩu
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra. Vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không chính xác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Hiển thị/ẩn mật khẩu
            bool isChecked = checkBox1.Checked;
            txtCu.UseSystemPasswordChar = !isChecked;
            txtMoi.UseSystemPasswordChar = !isChecked;
            txtXacNhan.UseSystemPasswordChar = !isChecked;
        }

        public void SetData(string username)
        {
            oldusername = username;
        }

    }
}
