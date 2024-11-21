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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class LichLamViec_QL : Form // doi lai thanh usercontrol
    {
        private List<LichPhanCong> ds_lpc;

        private PhanCongBLL phanCongBLL;
        private BacSiBLL bacSiBLL;
        private PhanQuyenBLL phanquyenBLL;
        private KhoaBLL khoaBLL;

        public LichLamViec_QL()
        {
            InitializeComponent();
            phanCongBLL = new PhanCongBLL();
            bacSiBLL = new BacSiBLL();
            phanquyenBLL = new PhanQuyenBLL();
            khoaBLL = new KhoaBLL();

            LoadData();
            LoadComboBoxChucVu();
            LoadComboBoxChuyenKhoa();
            LoadComboBoxHoTen();

            comboBox4.Items.Add("Sáng");
            comboBox4.Items.Add("Chiều");
            comboBox4.Items.Add("Tối");
            comboBox4.Items.Add("Đêm");
            comboBox4.SelectedIndex = 0;
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

        public void LoadComboBoxChucVu()
        {
            foreach (var pq in phanquyenBLL.GetAllTenQuyen())
            {
                comboBox1.Items.Add(pq.TenQuyen);
            }
            comboBox1.SelectedIndex = 0;
        }
        public void LoadComboBoxChuyenKhoa()
        {
            foreach (var ck in khoaBLL.GetAll())
            {
                comboBox2.Items.Add(ck.ChuyenKhoa);
            }
            comboBox2.SelectedIndex = 0;
        }
        public void LoadComboBoxHoTen()
        {
            foreach (var bs in bacSiBLL.GetAll())
            {
                comboBox3.Items.Add(bs.HoTen);
            }
            comboBox3.SelectedIndex = 0;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) // them button (tam hoat dong) (for now)
        {
            LichPhanCong lpc = new LichPhanCong();
            lpc.MaLK = 1;
            lpc.MaNV = 1;
            lpc.MaBS = 1;
            
            lpc.NgayThucHien = DateTime.Parse(dateTimePicker1.Text);
            lpc.ThoiGian = DateTime.Parse("00:00");
            lpc.GhiChu = textBox1.Text;
            phanCongBLL.CreateLichPhanCong(lpc);
            MessageBox.Show("OK", "OK", MessageBoxButtons.OK);
            LoadData();
        }
        private void button1_Click(object sender, EventArgs e) // chinh sua button (ko hoat dong) (chua biet cach tim MaLPC)
        {
            LichPhanCong lpc = new LichPhanCong();
            lpc.MaLK = 2;
            lpc.MaNV = 2;
            lpc.MaBS = 2;

            lpc.NgayThucHien = DateTime.Parse(dateTimePicker1.Text);
            lpc.ThoiGian = DateTime.Parse("06:00");
            lpc.GhiChu = textBox1.Text;
            phanCongBLL.EditLichPhanCong(lpc);
            MessageBox.Show("Edit OK", "OK Edit", MessageBoxButtons.OK);
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // click vao 1 cell se click vao ca dong
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && e.RowIndex >= 0)
            {
                dataGridView1.CurrentRow.Selected = true;
                comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); // ho ten
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(); // ngay sinh
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(); // ngay thuc hien
                comboBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(); // ca lam
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(); // chuyen khoa
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(); // ghi chu
            }
            
        }
    }
}

// TODO: redo the UI