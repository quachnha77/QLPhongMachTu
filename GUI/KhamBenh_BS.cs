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
    public partial class KhamBenh_BS : UserControl
    {
        public KhamBenh_BS()
        {
            InitializeComponent();
        }

        private void KhamBenh_BS_Load(object sender, EventArgs e)
        {

        }

        private void KeToaThuoc_Click(object sender, EventArgs e)
        {
            ToaThuoc toaThuocFrom = new ToaThuoc();
            toaThuocFrom.StartPosition = FormStartPosition.CenterScreen;
            toaThuocFrom.Show();
        }

        private void KhamBenh_Click(object sender, EventArgs e)
        {

        }

        private void HoaDonKhamBenh_Click(object sender, EventArgs e)
        {
            HoaDonKhamBenh hoaDonKBFrom = new HoaDonKhamBenh();
            hoaDonKBFrom.StartPosition = FormStartPosition.CenterScreen;
            hoaDonKBFrom.Show();
        }
    }
}
