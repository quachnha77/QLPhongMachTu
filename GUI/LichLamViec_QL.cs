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
        private PhanQuyenBLL phanquyenBLL;
        private PhongKhoaBLL phongKhoaBLL;
        private BacSiBLL bacSiBLL;
        private KhoaBLL khoaBLL;
        private UserBLL userBLL;
        private LichKhamBLL lichkhamBLL;
        private NhanVienBLL nhanvienBLL;

        private long selectedMaLPC;
        public LichLamViec_QL()
        {
            InitializeComponent();
            phanCongBLL = new PhanCongBLL();
            bacSiBLL = new BacSiBLL();
            phanquyenBLL = new PhanQuyenBLL();
            khoaBLL = new KhoaBLL();
            userBLL = new UserBLL();
            phongKhoaBLL = new PhongKhoaBLL();
            lichkhamBLL = new LichKhamBLL();
            nhanvienBLL = new NhanVienBLL();

            LoadData();
            LoadComboBoxChucVu();
            LoadComboBoxChuyenKhoa();
            LoadComboBoxHoTen();
            LoadComboBoxLichKham();
            LoadComboBoxNhanVien();

            comboBox4.SelectedIndex = 0;
        }
        public void LoadData()
        {
            dataGridView1.Rows.Clear();
            List<LichPhanCong> ds_lpc = phanCongBLL.GetAll();
            List<BacSi> ds_bs = bacSiBLL.GetAll();
            List<User> ds_user = userBLL.GetAll();
            List<PhanQuyen> ds_pq = phanquyenBLL.GetAll();
            List<PhongKhoa> ds_pk = phongKhoaBLL.GetAll();
            //List<LichKham> ds_lk = lichkhamBLL.GetAll();
            //List<NhanVien> ds_nv = nhanvienBLL.GetAll();
            int index = 1;

            foreach (var lpc in ds_lpc)
            {
                var bs = ds_bs.FirstOrDefault(_bs => _bs.MaSo == lpc.MaBS); // bac si
                var us = ds_user.FirstOrDefault(_us => _us.MaUser == bs.MaSo); // user
                var pq = ds_pq.FirstOrDefault(_pq => _pq.MaPQ == bs.MaUser); // phan quyen
                var pk = ds_pk.FirstOrDefault(_pk => _pk.MaPK == bs.MaKhoa); // phong khoa
                if (bs != null && us != null)
                {
                    int rowIndex = dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowIndex].Cells[0].Value = lpc.MaLPC;
                    dataGridView1.Rows[rowIndex].Cells[1].Value = bs.HoTen;
                    dataGridView1.Rows[rowIndex].Cells[2].Value = pq.TenQuyen;  // Chuc vu
                    dataGridView1.Rows[rowIndex].Cells[3].Value = lpc.ThoiGian.ToString("HH:mm"); // CaLam
                    dataGridView1.Rows[rowIndex].Cells[4].Value = pk.ChuyenKhoa;    // ChuyenKhoa, doi thanh TenPhongBan neu muon
                    dataGridView1.Rows[rowIndex].Cells[5].Value = lpc.NgayThucHien.ToString("dd-MM-yyyy");
                    dataGridView1.Rows[rowIndex].Cells[6].Value = lpc.GhiChu;
                    dataGridView1.Rows[rowIndex].Cells[7].Value = "Working";     // TrangThai
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

        public void LoadComboBoxLichKham()
        {
            foreach (var lk in lichkhamBLL.GetAll())
            {
                comboBox5.Items.Add(lk.MaLK);
            }
            comboBox5.SelectedIndex = 0;
        }
        public void LoadComboBoxNhanVien()
        {
            foreach (var nv in nhanvienBLL.GetAll())
            {
                comboBox6.Items.Add(nv.HoTen);
            }
            comboBox6.SelectedIndex = 0;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) // them button 
        {
            LichPhanCong lpc = new LichPhanCong();
            //lpc.MaLK = 1; // ko biet lichkham o dau ra ca...
            //lpc.MaNV = 1; // what nhan vien

            var bs = bacSiBLL.GetAll().FirstOrDefault(_bs => _bs.HoTen == comboBox3.Text);
            lpc.MaBS = bs.MaSo;

            var lk = lichkhamBLL.GetAll().FirstOrDefault(_lk => _lk.MaLK == Convert.ToInt64(comboBox5.Text));
            lpc.MaLK = lk.MaLK;

            var nv = nhanvienBLL.GetAll().FirstOrDefault(_nv => _nv.HoTen == comboBox6.Text);
            lpc.MaNV = nv.MaSo;


            lpc.NgayThucHien = DateTime.Parse(dateTimePicker1.Text);
            lpc.ThoiGian = DateTime.Parse(comboBox4.Text);
            lpc.GhiChu = textBox1.Text;
            phanCongBLL.CreateLichPhanCong(lpc);
            MessageBox.Show("OK", "OK", MessageBoxButtons.OK);
            LoadData();
        }
        private void button1_Click(object sender, EventArgs e) // chi chinh sua dc ghi chu/ngay thuc hien/ca lam
        {
            LichPhanCong lpc = new LichPhanCong();
            var lk = lichkhamBLL.GetAll().FirstOrDefault(_lk => _lk.MaLK == Convert.ToInt64(comboBox5.Text));
            lpc.MaLK = lk.MaLK;

            var bs = bacSiBLL.GetAll().FirstOrDefault(_bs => _bs.HoTen == comboBox3.Text);
            lpc.MaBS = bs.MaSo;

            var nv = nhanvienBLL.GetAll().FirstOrDefault(_nv => _nv.HoTen == comboBox6.Text);
            lpc.MaNV = nv.MaSo;

            lpc.MaLPC = selectedMaLPC;

            lpc.NgayThucHien = DateTime.Parse(dateTimePicker1.Text);
            lpc.ThoiGian = DateTime.Parse(comboBox4.Text);
            lpc.GhiChu = textBox1.Text;
            phanCongBLL.EditLichPhanCong(lpc);
            MessageBox.Show("Edit OK", "OK Edit", MessageBoxButtons.OK);
            LoadData();
        }
        private void TimChucVuChuyenKhoaCuaHoTen(object sender, EventArgs e)
        {
            var bs = bacSiBLL.GetAll().FirstOrDefault(_bs => _bs.HoTen == comboBox3.Text);
            var user = userBLL.GetAll().FirstOrDefault(_user => _user.MaUser == bs.MaSo);
            var pk = phongKhoaBLL.GetAll().FirstOrDefault(_pk => _pk.MaPK == bs.MaKhoa);
            var cv = phanquyenBLL.GetAll().FirstOrDefault(_cv => _cv.MaPQ == user.MaUser);

            comboBox1.Text = cv.TenQuyen;
            comboBox2.Text = pk.TenPhongBan;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // click vao 1 cell se click vao ca dong
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && e.RowIndex >= 0)
            {
                dataGridView1.CurrentRow.Selected = true;
                comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); // ho ten
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(); // chuc vu
                comboBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(); // ca lam
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(); // chuyen khoa
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(); // ngay thuc hien
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(); // ghi chu

                // Lay gia tri MaLPC
                selectedMaLPC = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            }
        }

        private void button2_Click(object sender, EventArgs e) // xoa button
        {
            phanCongBLL.DeleteLichPhanCong((int)selectedMaLPC);
            MessageBox.Show("Delete OK", "OK Delete", MessageBoxButtons.OK);
            LoadData();
        }
    }
}

// TODO: redo the UI