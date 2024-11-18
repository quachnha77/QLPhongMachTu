using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
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
    public partial class LichLamViec_QL : Form // doi lai thanh usercontrol
    {
        private List<LichPhanCong> ds_lpc;
        private PhanCongBLL phanCongBLL; 
        private BacSiBLL bacSiBLL;

        public LichLamViec_QL()
        {
            InitializeComponent();
            phanCongBLL = new PhanCongBLL();
            bacSiBLL = new BacSiBLL();
            LoadData();

            // Combobox chuc vu
            comboBox1.Items.Add("Bác sĩ");
            comboBox1.Items.Add("Dược sĩ");
            comboBox1.Items.Add("Lễ tân");
            comboBox1.Items.Add("Y Tá");
            comboBox1.SelectedIndex = 0;
        }
        public void LoadData()
        {
            dataGridView1.Rows.Clear();
            List<LichPhanCong> ds_lpc = phanCongBLL.GetAll();
            List<BacSi> ds_bs = bacSiBLL.GetAll();
            int index = 1;

            foreach (var lpc in ds_lpc)
            {
                var bs = ds_bs.FirstOrDefault(_bs => _bs.MaSo == lpc.MaBS);
                if (bs != null)
                {
                    int rowIndex = dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowIndex].Cells[0].Value = index;
                    dataGridView1.Rows[rowIndex].Cells[1].Value = bs.HoTen;
                    dataGridView1.Rows[rowIndex].Cells[2].Value = bs.NgaySinh;
                    dataGridView1.Rows[rowIndex].Cells[3].Value = lpc.NgayThucHien;
                    dataGridView1.Rows[rowIndex].Cells[4].Value = lpc.ThoiGian; // CaLam
                    dataGridView1.Rows[rowIndex].Cells[5].Value = bs.MaKhoa;    // ChuyenKhoa
                    dataGridView1.Rows[rowIndex].Cells[6].Value = lpc.GhiChu;
                    dataGridView1.Rows[rowIndex].Cells[7].Value = "Active";     // TrangThai
                    index++;
                }
            }
        }

        public void LoadComboBox()
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) // them button
        {

        }

        private void button1_Click(object sender, EventArgs e) // chinh sua button
        {

        }
    }
}
