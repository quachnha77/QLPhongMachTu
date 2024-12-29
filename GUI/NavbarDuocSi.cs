using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class NavbarDuocSi : Form
    {
        private Panel currentPanel = null; // Lưu trữ panel hiện tại
        private Control currentText = null; // Lưu trữ text hiện tại

        public NavbarDuocSi()
        {
            InitializeComponent();

            //// Khởi tạo
            currentPanel = pnKhoThuoc;
            currentText = txtKhoThuoc;

            ShowControl(new KhoThuocGUI());
            pnKhoThuoc.BackColor = Color.CadetBlue; // đổi màu panel
            txtKhoThuoc.ForeColor = Color.White; // đổi màu chữ
        }

        private void ShowControl(Control control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
            panelMain.Refresh();
        }

        private void doiMau(Panel p, Control text)
        {
            p.BackColor = Color.CadetBlue; // đổi màu panel
            text.ForeColor = Color.White; // đổi màu chữ
        }

        private void ChangePanelColor(Panel newPanel, Control newText)
        {
            // Nếu có panel hiện hành, đổi nó về màu mặc định
            if (currentPanel != null)
            {
                currentPanel.BackColor = SystemColors.InactiveBorder; // đổi màu panel
                currentText.ForeColor = Color.DarkCyan; // đổi màu chữ
            }

            doiMau(newPanel, newText);

            // Cập nhật panel hiện hành
            currentPanel = newPanel;
            //cập nhật text hiện hành
            currentText = newText;
        }

        private void KhoThuoc_Click(object sender, EventArgs e)
        {
            ShowControl(new KhoThuocGUI());
            ChangePanelColor(pnKhoThuoc, txtKhoThuoc);
        }

        private void ToaThuocDonThuoc_click(object sender, EventArgs e)
        {
            ShowControl(new ToaThuocDonThuoc_DS());
            ChangePanelColor(pnToaThuocDonThuoc, txtToaThuocDonThuoc);
        }

        private void ThanhToan_click(object sender, EventArgs e)
        {
            ShowControl(new ThanhToanDS());
            ChangePanelColor(pnThanhToan, txtThanhToan);
        }

        private void TaiKhoan_Click(object sender, EventArgs e)
        {
            ShowControl(new TaiKhoanGUI());
            ChangePanelColor(pnTaiKhoan, txtTaiKhoan);
        }

        private void pnDangXuat_Click(object sender, EventArgs e)
        {
            //Login login = new Login();
            //login.Show();
            //this.Close();
        }

        private void pnDangXuat_Click_1(object sender, EventArgs e)
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
