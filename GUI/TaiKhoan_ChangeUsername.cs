using QLPhongMachTu_DOAN_.BLL;
using System;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class TaiKhoan_ChangeUsername : Form
    {
        private UserBLL userBLL;
        private string olderusername;
        public TaiKhoan_ChangeUsername()
        {
            InitializeComponent();
            userBLL = new UserBLL();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string newUsername = txtTenDangNhap.Text;

            // Kiểm tra các textbox không được để trống
            if (string.IsNullOrEmpty(newUsername))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra trùng lặp tên đăng nhập
            if (userBLL.IsUsernameExists(newUsername))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cập nhật tên đăng nhập mới
            bool updateSuccess = userBLL.UpdateUsernameByOldUsername(olderusername, newUsername);

            if (updateSuccess)
            {
                MessageBox.Show("Thay đổi tên đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form sau khi đổi thành công
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra. Vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetData(string username)
        {
            olderusername = username;
        }
    }
}
