using QLPhongMachTu_DOAN_.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_
{
    public partial class NavbarBenhNhan : Form
    {
        public NavbarBenhNhan()
        {
            InitializeComponent();
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
            panelMain.Controls.Clear();
            KhamBenh khamBenhControl = new KhamBenh();
            khamBenhControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(khamBenhControl);
            panelMain.Refresh();
        }

        private void ToaThuocDonThuoc_Click_1(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            ToaThuocDonThuoc toaThuocDonThuocControl = new ToaThuocDonThuoc();
            toaThuocDonThuocControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(toaThuocDonThuocControl);
            panelMain.Refresh();
        }

        private void ThanhToan_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            ThanhToan thanhToanControl = new ThanhToan();
            thanhToanControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(thanhToanControl);
            panelMain.Refresh();
        }

        private void TaiKhoan_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            TaiKhoan taiKhoanControl = new TaiKhoan();
            taiKhoanControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(taiKhoanControl);
            panelMain.Refresh();
        }

        private void NavbarBenhNhan_Load(object sender, EventArgs e)
        {

        }
    }
}
