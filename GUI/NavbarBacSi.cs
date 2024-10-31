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
    public partial class NavbarBacSi : Form
    {
        public NavbarBacSi()
        {
            InitializeComponent();
        }

        private void NavbarBacSi_Load(object sender, EventArgs e)
        {

        }

        private void KhamBenh_BS_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            KhamBenh_BS khamBenhControl = new KhamBenh_BS();
            khamBenhControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(khamBenhControl);
            panelMain.Refresh();
        }

        private void LichLamViec_BS_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            LichLamViec_BS lichLVControl = new LichLamViec_BS();
            lichLVControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(lichLVControl);
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
