using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using QLPhongMachTu_DOAN_.Enums;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class KhamBenh_LT : UserControl
    {
        private LichKhamBLL lichKhamBll = new LichKhamBLL();
        private BacSiBLL bacSiBll = new BacSiBLL();
        private KhoaBLL khoaBll = new KhoaBLL();
        private BenhNhanBLL benhNhanBll = new BenhNhanBLL();
        private UserBLL userBll = new UserBLL();
        private PhanCongBLL phanCongBll = new PhanCongBLL();
        private NhanVien nhanVien = new NhanVien();
        private bool check = false;

        public KhamBenh_LT(NhanVien nv)
        {
            InitializeComponent();
            Innit();
            this.nhanVien = new NhanVien();
                nhanVien.MaNV = 20;
            tatCaRd.Checked = true;
        }

        private void Innit()
        {
            gridView.ClearSelection();
            InsertAllDataGridView();
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.MultiSelect = false;

            LoadChuyenKhoaList();
        }

        private void InsertAllDataGridView()
        {
            List<LichKhamDTO> lkList = lichKhamBll.GetAll();
            insertHelper(lkList);
        }

        private void insertHelper(List<LichKhamDTO> lkList)
        {
            int STT = 1; // Để STT bắt đầu từ 1
            foreach (var lk in lkList)
            {
                var bacSi = bacSiBll.GetById(lk.MaBS);
                var khoa = khoaBll.GetById(bacSi.MaKhoa);
                var benhNhan = benhNhanBll.GetById(lk.MaBN);
                var index = gridView.Rows.Add();

                gridView.Rows[index].Cells[0].Value = STT;
                gridView.Rows[index].Cells[1].Value = benhNhan.HoTen;
                gridView.Rows[index].Cells[2].Value = khoa.ChuyenKhoa;
                gridView.Rows[index].Cells[3].Value = bacSi.HoTen;
                gridView.Rows[index].Cells[4].Value = lk.NgayKham.ToString("dd/MM/yyyy");
                // gridView.Rows[index].Cells[5].Value = lk.TrieuChung;
                gridView.Rows[index].Cells[6].Value = lk.TrangThai.ToString(); // Hiển thị tên của enum

                // Gán đối tượng vào Tag cho việc sử dụng sau này
                gridView.Rows[index].Cells[0].Tag = lk;
                gridView.Rows[index].Cells[1].Tag = benhNhan;
                gridView.Rows[index].Cells[2].Tag = khoa;
                gridView.Rows[index].Cells[3].Tag = bacSi;

                STT++;
            }
        }

        /* Hàm ComBoBox Load */
        private void LoadChuyenKhoaList()
        {
            List<PhongKhoa> chuyenKhoaList = khoaBll.GetAll();
            comboBox1.DataSource = chuyenKhoaList;
            comboBox1.DisplayMember = "ChuyenKhoa";
            comboBox1.ValueMember = "MaPK";
            LoadDoctorsByChuyenKhoa((long)comboBox1.SelectedValue);
        }

        private void LoadDoctorsByChuyenKhoa(long khoaId)
        {
            List<BacSi> bacSiList = bacSiBll.GetAllByChuyenKhoa(khoaId);
            if (bacSiList.Count == 0)
            {
                comboBox2.DataSource = null;
                comboBox3.DataSource = null;
                MessageBox.Show("Không có bác sĩ nào trong chuyên khoa này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            comboBox2.DataSource = bacSiList;
            comboBox2.DisplayMember = "HoTen";
            comboBox2.ValueMember = "MaSo";
            LoadPhanCongByDoctor((long)comboBox2.SelectedValue);
        }

        private void LoadPhanCongByDoctor(long bacSiId)
        {
            List<LichPhanCong> phanCongList = phanCongBll.GetAllPhanCongByMaBacSi(bacSiId);
            if (phanCongList.Count == 0)
            {
                comboBox3.DataSource = null;
                MessageBox.Show("Bác sĩ này chưa được phân công lịch khám.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            comboBox3.DataSource = phanCongList;
            comboBox3.DisplayMember = "NgayPhanCong";
            comboBox3.ValueMember = "MaLPC";
        }
        /* Hàm ComBoBox Load */

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            var khoaId = comboBox1.SelectedValue;

            if (khoaId.GetType() != typeof(long)) return;
            LoadDoctorsByChuyenKhoa(Convert.ToInt64(khoaId));
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            var bacSiId = comboBox2.SelectedValue;

            if (bacSiId == null) return;
            if (bacSiId.GetType() != typeof(long)) return;
            LoadPhanCongByDoctor(Convert.ToInt64(bacSiId));
        }

        private void chinhSuaBtn_Click(object sender, System.EventArgs e)
        {
            if (gridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = gridView.SelectedRows[0];

            LichKhamDTO lk = (LichKhamDTO)selectedRow.Cells[0].Tag;
            BenhNhan benhNhan = (BenhNhan)selectedRow.Cells[1].Tag;
            PhongKhoa khoa = (PhongKhoa)selectedRow.Cells[2].Tag;
            BacSi bs = (BacSi)selectedRow.Cells[3].Tag;
            // Mã số, ngày khám, triệu chứng, trạng thái, BN, BS

            KhamBenh_Edit chinhSuaPnl = new KhamBenh_Edit(lk, benhNhan, bs, 2);
            var panelContent = this.FindForm().Controls["panelMain"] as Panel;

            if (panelContent != null)
            {
                // Xóa các control cũ trong panelContent
                panelContent.Controls.Clear();

                // Thêm UserControl mới vào panelContent
                chinhSuaPnl.Dock = DockStyle.Fill;
                panelContent.Controls.Add(chinhSuaPnl);
                panelContent.Refresh();
            }

        }

        private void InsertChuaKhamGridView()
        {
            List<LichKhamDTO> lkList = lichKhamBll.GetByTrangThai(ETrangThaiKham.ChuaKham);
            insertHelper(lkList);
        }

        private void InsertDaKhamGridView()
        {
            List<LichKhamDTO> lkList = lichKhamBll.GetByTrangThai(ETrangThaiKham.DaKham);
            insertHelper(lkList);
        }

        private void chuaKhamRd_Click(object sender, System.EventArgs e)
        {
            gridView.Rows.Clear();
            InsertChuaKhamGridView();
        }

        private void daKhamRd_Click(object sender, System.EventArgs e)
        {
            gridView.Rows.Clear();
            InsertDaKhamGridView();
        }

        private void tatCaRd_Click(object sender, System.EventArgs e)
        {
            gridView.Rows.Clear();
            InsertAllDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Tìm theo ngày
            DateTime from = dateTimePicker1.Value;
            DateTime to = dateTimePicker2.Value;

            // Gọi BLL để tìm kiếm lịch khám
            List<LichKhamDTO> resultList = lichKhamBll.TimKiemTheoNgay(from, to);
            gridView.Rows.Clear();
            insertHelper(resultList);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            if (string.IsNullOrEmpty(str)) return;
            var result = lichKhamBll.TimKiem(str);
            gridView.Rows.Clear();
            insertHelper(result);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Tìm theo kết hợp
            DateTime from = dateTimePicker1.Value;
            DateTime to = dateTimePicker2.Value;
            string str = textBox1.Text;
            if (string.IsNullOrEmpty(str)) return;

            List<LichKhamDTO> result = lichKhamBll.TimKiemTheoNgayVaText(from, to, str);
            gridView.Rows.Clear();
            insertHelper(result);
        }

        private void luuBtn_Click(object sender, EventArgs e)
        {
            // 
            // MaBn, CCCD, HoTen, NgaySinh, GioiTinh, DiaChi, SDT, ChuyenKhoa, NgayHen, YeuCauKham
            if (string.IsNullOrEmpty(CCCDTxt.Text) ||
                string.IsNullOrEmpty(gioiTinhTxt.Text) || string.IsNullOrEmpty(diaChiTxt.Text) ||
                string.IsNullOrEmpty(sdt2Txt.Text) || string.IsNullOrEmpty(yeuCauTxt.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (dateTimePicker3.Value > DateTime.Today)
            {
                MessageBox.Show("Ngày sinh không phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BenhNhan benhNhan = new BenhNhan();
            // benhNhan.MaSo = Convert.ToInt64(hoTenTxt.Text);
            benhNhan.HoTen = hoTenTxt.Text;
            benhNhan.CCCD = Convert.ToInt64(CCCDTxt.Text);
            benhNhan.GioiTinh = gioiTinhTxt.Text;
            benhNhan.DiaChi = diaChiTxt.Text;
            benhNhan.SDT = sdtTxt.Text;
            benhNhan.NgaySinh = dateTimePicker3.Value;

            User userBenhNhanTemp = new User();
            userBenhNhanTemp.Username = benhNhan.HoTen + benhNhan.CCCD;
            userBenhNhanTemp.Email = "";
            userBenhNhanTemp.Password = "123";
            userBenhNhanTemp.MaPQ = Convert.ToInt64(Enums.EQuyen.BENHNHAN);

            User newUser = userBll.CreateUser2(userBenhNhanTemp);
            benhNhan.MaUser = newUser.MaUser;

            BenhNhan newBenhNhan = benhNhanBll.Create(benhNhan);

            BacSi bacSi = bacSiBll.GetById(Convert.ToInt64(comboBox2.SelectedValue));
            LichKhamDTO lichKham = new LichKhamDTO();
            //lichKham.TrieuChung = yeuCauTxt.Text; // Cột triệu chứng mới thêm
            lichKham.TrangThai = ETrangThaiKham.ChuaKham;
            lichKham.NgayKham = dateTimePicker3.Value;
            lichKham.MaBN = newBenhNhan.MaSo;
            lichKham.MaBS = bacSi.MaSo;
            lichKham.MaNV = 9;

            var result = lichKhamBll.TaoLichKham(lichKham, nhanVien.MaNV);
            if (result != null)
            {
                MessageBox.Show("Tạo lịch khám thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InsertAllDataGridView();
                return;
            }
            MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
