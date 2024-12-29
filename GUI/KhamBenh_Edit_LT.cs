using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class KhamBenh_Edit_LT : UserControl
    {
        private DTO.LichKhamDTO LichKham = new DTO.LichKhamDTO();
        private BenhNhan BenhNhan = new BenhNhan();
        private BacSi BacSi = new BacSi();

        private KhoaBLL khoaBll = new KhoaBLL();
        private BacSiBLL bacSiBll = new BacSiBLL();
        private PhanCongBLL phanCongBll = new PhanCongBLL();
        private LichKhamBLL lichKhamBll = new LichKhamBLL();

        public KhamBenh_Edit_LT(DTO.LichKhamDTO lk, BenhNhan bn, BacSi bs)
        {
            InitializeComponent();
            LichKham = lk; BenhNhan = bn; BacSi = bs;
            ShowInformation();
        }

        // Show các thông tin bệnh nhân lên màn hình
        private void ShowInformation()
        {
            textBox1.Text = BenhNhan.HoTen;
            textBox2.Text = BenhNhan.DiaChi;
            textBox3.Text = BenhNhan.SDT;
            textBox4.Text = BenhNhan.GioiTinh;
            //textBox5.Text = LichKham.TrieuChung;

            // Selected Index Change
            List<PhongKhoa> khoaList = khoaBll.GetAll();
            comboBox1.DataSource = khoaList;
            comboBox1.DisplayMember = "ChuyenKhoa";
            comboBox1.ValueMember = "MaPK";

            PhongKhoa kh = khoaList.Find(k => k.MaPK == BacSi.MaKhoa);
            var index = comboBox1.FindStringExact(kh.ChuyenKhoa);
            comboBox1.SelectedIndex = index;

            long maKhoa = (long)comboBox1.SelectedValue;
            ShowBacSiByKhoa(maKhoa);

            long maBacSi = (long)comboBox2.SelectedValue;
            ShowPhanCongByBacSi(maBacSi);
        }

        private void ShowBacSiByKhoa(long maKhoa)
        {
            List<BacSi> bacSi = bacSiBll.GetAllByChuyenKhoa(maKhoa);
            comboBox2.DataSource = bacSi;
            comboBox2.DisplayMember = "HoTen";
            comboBox2.ValueMember = "MaSo";
        }

        private void ShowPhanCongByBacSi(long maBacSi)
        {
            List<LichPhanCong> lpc = phanCongBll.GetAllPhanCongByMaBacSi(maBacSi);
            comboBox3.DataSource = lpc;
            comboBox3.DisplayMember = "NgayPhanCong";
            comboBox3.ValueMember = "MaLPC";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var maKhoa = comboBox1.SelectedValue;

            if (maKhoa.GetType() != typeof(long)) return;
            ShowBacSiByKhoa(Convert.ToInt64(maKhoa));
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var maBacSi = comboBox2.SelectedValue;
            if (maBacSi.GetType() != typeof(long)) return;
            ShowPhanCongByBacSi(Convert.ToInt64(maBacSi));
        }

        private void button1_Click(object sender, EventArgs e)
        {// Trở về
            KhamBenh_LT khamBenhLT = new KhamBenh_LT();
            var mainForm = this.FindForm();
            mainForm.Controls.Clear();
            mainForm.Dock = DockStyle.Fill;
            mainForm.Controls.Add(khamBenhLT);
            mainForm.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {// Lưu
            long maLK = LichKham.MaLK;
            long bacSiId = Convert.ToInt64(comboBox2.SelectedValue);
            long phanCongId = Convert.ToInt64(comboBox3.SelectedValue);

            DTO.LichKhamDTO updateLichKham = new DTO.LichKhamDTO()
            {
                MaBS = bacSiId,
                //TrieuChung = textBox5.Text
            };

            var result = lichKhamBll.SuaLichKham(maLK, updateLichKham, phanCongId);
            if (result)
            {
                MessageBox.Show("Chỉnh sửa lịch khám thành công!");
                KhamBenh_LT khamBenhLT = new KhamBenh_LT();
                var mainForm = this.FindForm();
                mainForm.Dock = DockStyle.Fill;
                mainForm.Controls.Add(khamBenhLT);
                mainForm.Refresh();
            }

            else
                MessageBox.Show("Có lỗi xảy ra!");
        }
    }
}
