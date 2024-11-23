using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class DuocSi_ToaDon : Form
    {
        public DuocSi_ToaDon()
        {
            InitializeComponent();
        }

        private void DuocSiToaDon_Load(object sender, EventArgs e)
        {

        }

        private void TaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void ThanhToan_Click(object sender, EventArgs e)
        {

        }

        private void ToaThuocDonThuoc_Click(object sender, EventArgs e)
        {

        }

        private void KhoThuoc_Click(object sender, EventArgs e)
        {
            DuocSi_KhoThuoc form1 = new DuocSi_KhoThuoc();
            form1.Show();

            this.Close();
        }


    }
}
