using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using QLPhongMachTu_DOAN_.Enums;
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

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox2.Items.Add("Chuyên khoa");
            comboBox2.Items.Add("Bác sĩ");
            comboBox2.Items.Add("Trạng thái");
            comboBox2.SelectedIndex = 0;
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
                MessageBox.Show("Vui lòng chọn một lịch hẹn để hủy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


        /* Hàm ComBoBox Load */
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
        /* Hàm ComBoBox Load */

        private void UpdateDataGrid()
        {
            if(dataGridView1.Rows.Count > 0)
                dataGridView1.Rows.Clear();
            List<LichKham> listOfLichKham = lichKhamBLL.GetByMaBenhNhan(benhNhan.MaSo);

            insertHelper(listOfLichKham);
        }

        private void insertHelper(List<LichKham> listLichKham)
        {
            int STT = 1;
            foreach (var lk in listLichKham)
            {
                PhongKhoa khoa = khoaBLL.GetById(lk.BacSi.MaKhoa);
                int index = dataGridView1.Rows.Add();

                dataGridView1.Rows[index].Cells[0].Value = STT;
                dataGridView1.Rows[index].Cells[1].Value = khoa.ChuyenKhoa;
                dataGridView1.Rows[index].Cells[2].Value = lk.BacSi.HoTen;
                dataGridView1.Rows[index].Cells[3].Value = lk.NgayKham.ToString("dd/MM/yyyy");
                dataGridView1.Rows[index].Cells[4].Value = lk.TrieuChung;
                dataGridView1.Rows[index].Cells[5].Value = lk.TrangThai;

                dataGridView1.Rows[index].Cells[0].Tag = lk;
                dataGridView1.Rows[index].Cells[1].Tag = khoa;
                dataGridView1.Rows[index].Cells[1].Tag = lk.BacSi;
                STT += 1;
            }
            dataGridView1.ClearSelection();
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

            if (string.IsNullOrEmpty(SDTTxt.Text))
            {
                MessageBox.Show("Vui lòng nhập điện thoại trước khi đăng ký lịch khám.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    string chuoi = textBox5.Text;
                    TimKiemTheoChuyenKhoa(chuoi);
                    return;
            }
        }

        // CHỨC NĂNG TÌM KIẾM
        private void TimKiemTheoChuyenKhoa(string chuyenKhoa)
        {
            // Kiểm tra nếu dữ liệu trong textBox5 hợp lệ
            if (string.IsNullOrEmpty(chuyenKhoa))
            {
                MessageBox.Show("Chưa nhập thông tin tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<LichKham> resultList = lichKhamBLL.TimKiemTheoChuyenKhoa(chuyenKhoa);

            if (resultList == null)
            {
                MessageBox.Show("Không có kết quả phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataGridView1.Rows.Clear();
            insertHelper(resultList);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lịch hẹn để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var selectedRow = dataGridView1.SelectedRows[0];

            LichKham lk = (LichKham)selectedRow.Cells[0].Tag;
            PhongKhoa khoa = (PhongKhoa)selectedRow.Cells[2].Tag;
            //BacSi bs = (BacSi)selectedRow.Cells[3].Tag;

            KhamBenh_Edit chinhSuaPnl = new KhamBenh_Edit(lk, benhNhan, lk.BacSi, 1);
            var panelMain = this.FindForm();
            panelMain.Controls.Clear();
            chinhSuaPnl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(chinhSuaPnl);
            panelMain.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {// Tạo phiếu khám
            // Bệnh nhân có thể xem phiếu khám của những lịch khám đã khám
            // Trạng thái lịch khám: Chưa khám, Đã khám, Đã hủy
            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn một lịch khám", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            LichKham lk = (LichKham)selectedRow.Cells[0].Tag;
            // Chưa khám hoặc đã hủy khám
            if (lk.TrangThai != ETrangThaiKham.DaKham)
            {
                MessageBox.Show("Bạn không thể xem các lịch khám với trạng thái chưa khám.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            
            PhieuKham_Edit chinhSuaPnl = new PhieuKham_Edit(lk,benhNhan, user);
            var panelMain = this.FindForm();
            panelMain.Controls.Clear();
            chinhSuaPnl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(chinhSuaPnl);
            panelMain.Refresh();
            
        }
    }    
}
