using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            ShowInformation();
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

        private void ShowInformation()
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

            var xacNhan = MessageBox.Show("Bạn chắc chắn hủy lịch hẹn này không?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (xacNhan != DialogResult.OK) return;

            long lichKhamId = (long)dataGridView1.SelectedRows[0].Tag;
            bool result = lichKhamBLL.XoaLichKham(lichKhamId);

            if (result)
            {
                MessageBox.Show("Hủy lịch hẹn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateDataGrid();
            }
            else MessageBox.Show("Hủy lịch hẹn thất bại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            chuyenKhoaSlt.DisplayMember = "ChuyenKhoa";
            chuyenKhoaSlt.ValueMember = "MaPK";
            LoadDoctorsByChuyenKhoa((long)chuyenKhoaSlt.SelectedValue);
        }

        private void LoadDoctorsByChuyenKhoa(long khoaId)
        {
            List<BacSi> bacSiList = bacSiBLL.GetAllByChuyenKhoa(khoaId);
            if (bacSiList.Count == 0)
            {
                comboBox1.DataSource = null;
                ngayHenCb.DataSource = null;
                MessageBox.Show("Không có bác sĩ nào trong chuyên khoa này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            comboBox1.DataSource = bacSiList;
            comboBox1.DisplayMember = "HoTen";
            comboBox1.ValueMember = "MaSo";
            LoadPhanCongByDoctor((long)comboBox1.SelectedValue);
        }

        private void LoadPhanCongByDoctor(long bacSiId)
        {
            List<LichPhanCong> phanCongList = phanCongBLL.GetAllPhanCongByMaBacSi(bacSiId);
            if (phanCongList.Count == 0)
            {
                ngayHenCb.DataSource = null;
                MessageBox.Show("Bác sĩ này chưa được phân công lịch khám.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ngayHenCb.DataSource = phanCongList;
            ngayHenCb.DisplayMember = "NgayPhanCong";
            ngayHenCb.ValueMember = "MaLPC";
        }

        private void UpdateDataGrid()
        {
            dataGridView1.Rows.Clear();
            List<LichKham> listOfLichKham = lichKhamBLL.GetByMaBenhNhan(benhNhan.MaSo);

            int STT = 1;
            foreach (var lk in listOfLichKham)
            {
                var bacSi = bacSiBLL.GetById(lk.MaBS);
                var khoa = khoaBLL.GetById(bacSi.MaKhoa);
                var index = dataGridView1.Rows.Add();

                dataGridView1.Rows[index].Cells[0].Value = STT;
                dataGridView1.Rows[index].Cells[1].Value = khoa.ChuyenKhoa;
                dataGridView1.Rows[index].Cells[2].Value = lk.BacSi.HoTen;
                dataGridView1.Rows[index].Cells[3].Value = lk.NgayKham;
                dataGridView1.Rows[index].Cells[4].Value = lk.TrieuChung;
                dataGridView1.Rows[index].Cells[5].Value = lk.TrangThai;

                dataGridView1.Rows[index].Cells[0].Tag = lk;
                dataGridView1.Rows[index].Cells[1].Tag = khoa;
                STT += 1;
            }
        }

        private void chuyenKhoaSlt_DropDownClosed(object sender, EventArgs e)
        {
            var khoaId = chuyenKhoaSlt.SelectedValue;

            if (khoaId.GetType() != typeof(long)) return;
            LoadDoctorsByChuyenKhoa(Convert.ToInt64(khoaId));
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            var bacSiId = comboBox1.SelectedValue;

            if (bacSiId == null) return;
            if (bacSiId.GetType() != typeof(long)) return;
            LoadPhanCongByDoctor(Convert.ToInt64(bacSiId));
        }

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
    }
}
