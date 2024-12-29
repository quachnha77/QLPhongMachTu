using QLPhongMachTu_DOAN_.DTO;
using QLPhongMachTu_DOAN_.GUI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_
{
    public partial class NavbarBenhNhan : Form
    {
        private User userLogin;
        private BenhNhan benhNhanLogin;

        private Panel currentPanel = null; // Lưu trữ panel hiện tại
        private Control currentText = null; // Lưu trữ text hiện tại

        public NavbarBenhNhan(User userLogin, BenhNhan benhNhanLogin)
        {
            InitializeComponent();
            this.userLogin = userLogin;
            this.benhNhanLogin = benhNhanLogin;

            //// Khởi tạo
            currentPanel = pnKhamBenh;
            currentText = txtKhamBenh;

            ShowControl(new KhamBenh(userLogin, benhNhanLogin));
            pnKhamBenh.BackColor = Color.CadetBlue; // đổi màu panel
            txtKhamBenh.ForeColor = Color.White; // đổi màu chữ
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pnKhamBenh_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtToaThuocDonThuoc_Click(object sender, EventArgs e)
        {

        }

        private void pnToaThuocDonThuoc_Click(object sender, EventArgs e)
        {

        }

        private void KhamBenh_Click(object sender, EventArgs e)
        {
            ShowControl(new KhamBenh(userLogin, benhNhanLogin));
            ChangePanelColor(pnKhamBenh, txtKhamBenh);
        }

        private void ToaThuocDonThuoc_Click_1(object sender, EventArgs e)
        {
            ShowControl(new ToaThuocDonThuoc(userLogin, benhNhanLogin));
            ChangePanelColor(pnToaThuocDonThuoc, txtToaThuocDonThuoc);
        }

        private void ThanhToan_Click(object sender, EventArgs e)
        {
            ShowControl(new ThanhToan(userLogin, benhNhanLogin, 2));
            ChangePanelColor(pnThanhToan, txtThanhToan);
        }

        private void TaiKhoan_Click(object sender, EventArgs e)
        {
            ShowControl(new TaiKhoanGUI());
            ChangePanelColor(pnTaiKhoan, txtTaiKhoan);
        }

        private void NavbarBenhNhan_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            ChangePanelColor(pnDangXuat, txtDangXuat);
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
