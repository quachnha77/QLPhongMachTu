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
    public partial class NavbarLeTan : Form
    {
        public NavbarLeTan()
        {
            InitializeComponent();
        }

        private void pnKhamBenh_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            KhamBenh_LT khamBenhLT = new KhamBenh_LT();
            khamBenhLT.Dock = DockStyle.Fill;
            panelMain.Controls.Add(khamBenhLT);
            panelMain.Refresh();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            ThanhToan thanhToanLT = new ThanhToan();
            thanhToanLT.Dock = DockStyle.Fill;
            panelMain.Controls.Add(thanhToanLT);
            panelMain.Refresh();
        }
    }
}
