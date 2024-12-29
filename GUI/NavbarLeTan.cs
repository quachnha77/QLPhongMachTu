using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class NavbarLeTan : Form
    {
        private NhanVien nhanVien;
        public NavbarLeTan(NhanVien nhanVien)
        {
            InitializeComponent();
            this.nhanVien = nhanVien;

        }

        private void pnKhamBenh_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            KhamBenh_LT khamBenhLT = new KhamBenh_LT(nhanVien);
            khamBenhLT.Dock = DockStyle.Fill;
            panelMain.Controls.Add(khamBenhLT);
            panelMain.Refresh();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            ShowControl(new ThanhToan(new User(), new BenhNhan(), 1));
        }

        private void ShowControl(Control control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
            panelMain.Refresh();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            ShowControl(new TaiKhoanGUI());
            //ChangePanelColor(pnTaiKhoan, txtTaiKhoan);
        }

        private void panel4_Click_1(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận đăng xuất
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra kết quả của người dùng
            if (result == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                // Thực hiện đăng xuất nếu người dùng chọn "Yes"
                this.Close(); // Hoặc thực hiện các hành động đăng xuất cần thiết
            }
        }
    }
}
