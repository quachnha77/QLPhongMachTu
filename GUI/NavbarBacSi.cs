using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class NavbarBacSi : Form
    {
        public NavbarBacSi()
        {
            InitializeComponent();

            // Khởi tạo
            currentPanel = pnKhamBenh;
            currentText = txtKhamBenh;

            ShowControl(new KhamBenh_BS());
            pnKhamBenh.BackColor = Color.CadetBlue; // đổi màu panel
            txtKhamBenh.ForeColor = Color.White; // đổii màu chữ
        }

        private void NavbarBacSi_Load(object sender, EventArgs e)
        {

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

        private Panel currentPanel = null; // Lưu trữ panel hiện tại
        private Control currentText = null; // Lưu trữ text hiện tại
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


        private void KhamBenh_BS_Click(object sender, EventArgs e)
        {
            ShowControl(new KhamBenh_BS());
            ChangePanelColor(pnKhamBenh, txtKhamBenh);
        }

        private void LichLamViec_BS_Click(object sender, EventArgs e)
        {
            ShowControl(new LichLamViec_BS());
            ChangePanelColor(pnLichLamViec, txtLichLamViec);
        }

        private void TaiKhoan_Click(object sender, EventArgs e)
        {
            ShowControl(new TaiKhoan());
            ChangePanelColor(pnTaiKhoan, txtTaiKhoan);
        }

        private void DangXuat_Click(object sender, EventArgs e)
        {   

            // Hiển thị hộp thoại xác nhận đăng xuất
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra kết quả của người dùng
            if (result == DialogResult.Yes)
            {
                // Thực hiện đăng xuất nếu người dùng chọn "Yes"
                this.Close(); // Hoặc thực hiện các hành động đăng xuất cần thiết
            }
        }
    }
}
