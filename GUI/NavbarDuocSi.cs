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
    public partial class NavbarDuocSi : Form
    {
        public NavbarDuocSi()
        {
            InitializeComponent();
        }

        private void KhoThuoc_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            KhoThuoc khoThuoccontrol = new KhoThuoc();
            khoThuoccontrol.Dock = DockStyle.Fill;
            panelMain.Controls.Add(khoThuoccontrol);
            panelMain.Refresh();
        }

        private void ToaThuocDonThuoc_click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            ToaThuocDonThuoc_DS toaThuocDonThuoccontrol = new ToaThuocDonThuoc_DS();
            toaThuocDonThuoccontrol.Dock = DockStyle.Fill;
            panelMain.Controls.Add(toaThuocDonThuoccontrol);
            panelMain.Refresh();
        }

        private void ThanhToan_click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            ThanhToan_DS thanhToancontrol = new ThanhToan_DS();
            thanhToancontrol.Dock = DockStyle.Fill;
            panelMain.Controls.Add(thanhToancontrol);
            panelMain.Refresh();
        }

        private void TaiKhoan_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            TaiKhoan taiKhoancontrol = new TaiKhoan();
            taiKhoancontrol.Dock = DockStyle.Fill;
            panelMain.Controls.Add(taiKhoancontrol);
            panelMain.Refresh();
        }
    }
}
