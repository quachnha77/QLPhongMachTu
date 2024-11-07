using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class NavbarQuanLi : Form
    {
        public NavbarQuanLi()
        {
            InitializeComponent();
        }

        private void NhanVien_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            NhanVien nhanVienControl = new NhanVien();
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

        private void pnKhamBenh_Paint(object sender, PaintEventArgs e)
        {

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
