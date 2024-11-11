using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class KhamBenh : UserControl
    {
        private User user;
        private BenhNhan benhNhan;

        private PhanCongBLL phanCongBLL = new PhanCongBLL();
        private KhoaBLL khoaBLL = new KhoaBLL();
        private BacSiBLL bacSiBLL = new BacSiBLL();
        private PhieuKhamBLL phieuKhamBLL = new PhieuKhamBLL();
        private LichKhamBLL lichKhamBLL = new LichKhamBLL();

        public KhamBenh(User user, BenhNhan benhNhan)
        {
            this.user = user;
            this.benhNhan = benhNhan;
            InitializeComponent();

            InitializeUI();
            LoadInitialData();
        }

        private void InitializeUI()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            hoTenTxt.Text = benhNhan.HoTen;
            SDTTxt.Text = benhNhan.SDT ?? string.Empty;
            hoTenTxt.Enabled = false;
            SDTTxt.Enabled = false;
        }

        private void LoadInitialData()
        {
            LoadChuyenKhoaList();
            UpdateDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateFormData()) return;

            long bacSiId = (long)comboBox1.SelectedValue;
            long phanCongId = (long)ngayHenCb.SelectedValue;
            BacSi selectedBacSi = bacSiBLL.GetById(bacSiId);
            LichPhanCong selectedPhanCong = phanCongBLL.GetById(phanCongId);

            LichKham lichKham = new LichKham
            {
                MaBN = benhNhan.MaSo,
                MaBS = selectedBacSi.MaSo,
                TrieuChung = trieuChungTxt.Text,
                NgayKham = selectedPhanCong.NgayPhanCong,
            };

            lichKhamBLL.TaoLichKham(lichKham);
            UpdateDataGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để hủy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmCancel = MessageBox.Show("Bạn chắc chắn hủy lịch hẹn này không?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirmCancel != DialogResult.OK) return;

            long lichKhamId = (long)dataGridView1.SelectedRows[0].Tag;
            var result = lichKhamBLL.XoaLichKham(lichKhamId);

            MessageBox.Show(result != null ? "Hủy lịch hẹn thành công." : "Hủy lịch hẹn thất bại.", "Thông báo");
            UpdateDataGrid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadChuyenKhoaList();
            UpdateDataGrid();
            dataGridView1.ClearSelection();
        }

        private void LoadChuyenKhoaList()
        {
            List<PhongKhoa> chuyenKhoaList = khoaBLL.GetAll();
            chuyenKhoaSlt.DataSource = chuyenKhoaList;
            chuyenKhoaSlt.DisplayMember = "TenPhongBan";
            chuyenKhoaSlt.ValueMember = "MaPK";
            LoadDoctorsByChuyenKhoa((long)chuyenKhoaSlt.SelectedValue);
        }

        private void LoadDoctorsByChuyenKhoa(long khoaId)
        {
            List<BacSi> bacSiList = bacSiBLL.GetAllByChuyenKhoa(khoaId);
            comboBox1.DataSource = bacSiList.Count > 0 ? bacSiList : null;

            if (bacSiList.Count == 0)
            {
                MessageBox.Show("Không có bác sĩ nào trong chuyên khoa này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            comboBox1.DisplayMember = "HoTen";
            comboBox1.ValueMember = "MaSo";
            LoadPhanCongByDoctor((long)comboBox1.SelectedValue);
        }

        private void LoadPhanCongByDoctor(long bacSiId)
        {
            List<LichPhanCong> phanCongList = phanCongBLL.GetAllPhanCongByMaBacSi(bacSiId);
            ngayHenCb.DataSource = phanCongList;
            ngayHenCb.DisplayMember = "NgayPhanCong";
            ngayHenCb.ValueMember = "MaLPC";
        }

        private void UpdateDataGrid()
        {
            dataGridView1.Rows.Clear();
            List<LichKham> listOfLichKham = lichKhamBLL.GetByMaBenhNhan(benhNhan.MaSo);

            int stt = 1;
            foreach (var lichKham in listOfLichKham)
            {
                var bacSi = bacSiBLL.GetById(lichKham.MaBS);
                var phongKhoa = khoaBLL.GetById(bacSi.MaKhoa);

                var row = new object[] { stt, phongKhoa.ChuyenKhoa, lichKham.NgayKham, lichKham.TrieuChung, bacSi.HoTen };
                dataGridView1.Rows.Add(row);
                dataGridView1.Rows[stt - 1].Tag = lichKham.MaLK;
                stt++;
            }
        }


        #region UI Event Handlers

        //private void chuyenKhoaSlt_DropDownClosed(object sender, EventArgs e)
        //{
        //    long khoaId = ((PhongKhoa)chuyenKhoaSlt.SelectedItem).MaPK;
        //    LoadDoctorsByChuyenKhoa(khoaId);
        //}

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            long bacSiId = (long)comboBox1.SelectedValue;
            LoadPhanCongByDoctor(bacSiId);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var selectedRow = dataGridView1.SelectedRows[0];
            chuyenKhoaSlt.SelectedIndex = chuyenKhoaSlt.FindStringExact((string)selectedRow.Cells[1].Value);
            ngayHenCb.SelectedIndex = ngayHenCb.FindStringExact(selectedRow.Cells[2].Value.ToString());
            comboBox1.SelectedIndex = comboBox1.FindStringExact(selectedRow.Cells[4].Value.ToString());
            trieuChungTxt.Text = (string)selectedRow.Cells[3].Value;
        }

        #endregion

        #region Validation

        private bool ValidateFormData()
        {
            if (chuyenKhoaSlt.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Chuyên khoa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Bác sĩ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(trieuChungTxt.Text))
            {
                MessageBox.Show("Vui lòng nhập Triệu chứng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion
    }
}
