using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class NavbarQuanLi : Form
    {
        public NavbarQuanLi()
        {
            InitializeComponent();

            // Khởi tạo
            currentPanel = pnNhanVien;
            currentText = txtNhanVien;

            ShowControl(new NhanVienGUI());
            pnNhanVien.BackColor = Color.CadetBlue; // Đổi màu panel ban đầu
            txtNhanVien.ForeColor = Color.White;    // Đổi màu chữ ban đầu
        }

        private void ShowControl(Control control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
            panelMain.Refresh();
        }

        private void doiMau(Panel panel, Control text)
        {
            panel.BackColor = Color.CadetBlue; // Đổi màu panel
            text.ForeColor = Color.White;     // Đổi màu chữ
        }

        private Panel currentPanel = null;  // Lưu trữ panel hiện tại
        private Control currentText = null; // Lưu trữ text hiện tại

        private void ChangePanelColor(Panel newPanel, Control newText)
        {
            // Đổi màu panel và text hiện tại về mặc định
            if (currentPanel != null)
            {
                currentPanel.BackColor = SystemColors.Control; // Màu mặc định của panel
                currentText.ForeColor = Color.DarkCyan;        // Màu chữ mặc định
            }

            // Đổi màu cho panel và text mới
            doiMau(newPanel, newText);

            // Cập nhật panel và text hiện tại
            currentPanel = newPanel;
            currentText = newText;
        }

        private void NhanVien_Click(object sender, EventArgs e)
        {
            ShowControl(new NhanVienGUI());
            ChangePanelColor(pnNhanVien, txtNhanVien);
        }

        private void LichLamViec_QL_Click(object sender, EventArgs e)
        {
            ShowControl(new LichLamViec_QL());
            ChangePanelColor(pnLichLamViec, txtLichLamViec);
        }

        private void pnKhamBenh_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Click(object sender, EventArgs e)
        {
            ShowControl(new TaiKhoanGUI());
            ChangePanelColor(pnTaiKhoan, txtTaiKhoan);
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            ShowControl(new ThongKe());
            ChangePanelColor(pnThongKe, txtThongKe);
        }

        private void DangXuat_Click(object sender, EventArgs e)
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
