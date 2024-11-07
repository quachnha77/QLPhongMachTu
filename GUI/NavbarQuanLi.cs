using System;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class NavbarQuanLi : Form
    {
        public NavbarQuanLi()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            NhanVien_Click(null, null);
        }

        private void NhanVien_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            NhanVienGUI nhanVienControl = new NhanVienGUI();
            nhanVienControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(nhanVienControl);
            panelMain.Refresh();
        }

        private void LichLamViec_QL_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            LichLamViec_QL lichLamViecControl = new LichLamViec_QL();
            lichLamViecControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(lichLamViecControl);
            panelMain.Refresh();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            TaiKhoan taiKhoancControl = new TaiKhoan();
            taiKhoancControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(taiKhoancControl);
            panelMain.Refresh();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            ThongKe thongKeControl = new ThongKe();
            thongKeControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(thongKeControl);
            panelMain.Refresh();
        }
    }
}
