using QLPhongMachTu_DOAN_.BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class TaiKhoanGUI : UserControl
    {
        private UserBLL userBLL;
        private long maUserCurrent;
        public TaiKhoanGUI()
        {
            InitializeComponent();
            userBLL = new UserBLL();

            maUserCurrent = LoginSession.MaUser;

            LoadUserInfo(maUserCurrent);
        }

        public void LoadUserInfo(long maUser)
        {
            DataTable userDetail = userBLL.GetUserDetails(maUser);

            if (userDetail.Rows.Count > 0)
            {
                DataRow row = userDetail.Rows[0];

                txtHoTen.Text = row["HoTen"].ToString();
                if (row["GioiTinh"].ToString() == "Nam")
                {
                    rdbNam.Checked = true;
                    rdbNu.Checked = false;
                }
                else if (row["GioiTinh"].ToString() == "Nữ")
                {
                    rdbNu.Checked = true;
                    rdbNam.Checked = false;
                }
                else
                {
                    rdbNu.Checked = false;
                    rdbNam.Checked = false;
                }
                txtCCCD.Text = row["CCCD"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row["NgaySinh"]);
                txtSDT.Text = row["SDT"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtDiaChi.Text = row["DiaChi"].ToString();
                txtUsername.Text = row["Username"].ToString();
                txtPassword.Text = row["Password"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Update();
        }

        public void Update()
        {
            string hoTen = txtHoTen.Text;
            string gioiTinh = rdbNam.Checked ? "Nam" : "Nữ";
            string cccd = txtCCCD.Text;
            DateTime ngaySinh = dateTimePicker1.Value;
            string sdt = txtSDT.Text;
            string diaChi = txtDiaChi.Text;
            string email = txtEmail.Text;
            string username = txtUsername.Text;

            bool success = userBLL.UpdateUserInfo(maUserCurrent, username, hoTen, gioiTinh, cccd, ngaySinh, sdt, diaChi, email);

            if (success)
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            TaiKhoan_ChangeUsername changeUsername = new TaiKhoan_ChangeUsername();
            changeUsername.SetData(txtUsername.Text);
            changeUsername.ShowDialog();
            LoadUserInfo(maUserCurrent);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TaiKhoan_ChangePassword changePassword = new TaiKhoan_ChangePassword();
            changePassword.SetData(txtUsername.Text);
            changePassword.ShowDialog();
            LoadUserInfo(maUserCurrent);
        }
    }
}
