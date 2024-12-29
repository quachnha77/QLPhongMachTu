using QLPhongMachTu_DOAN_.BLL;
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
            benhNhan.User = user;
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

            LichKhamDTO lichKham = (LichKhamDTO)dataGridView1.SelectedRows[0].Cells[0].Tag;
            bool result = lichKhamBLL.UpdateTrangThai(lichKham.MaLK);

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
                //MessageBox.Show("Bác sĩ này chưa được phân công lịch khám.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ngayHenCb.DataSource = phanCongList;
            ngayHenCb.DisplayMember = "NgayThucHien";
            ngayHenCb.ValueMember = "MaLPC";
        }
        /* Hàm ComBoBox Load */

        public enum ETrangThaiKham
        {
            [System.ComponentModel.Description("Chưa khám")]
            ChuaKham = 1,
            [System.ComponentModel.Description("Đã khám")]
            DaKham = 2,
            [System.ComponentModel.Description("Hủy khám")]
            HuyKham = 3
        }

        private void UpdateDataGrid()
        {
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.Rows.Clear();

            // Lấy danh sách LichKham theo bệnh nhân
            List<DTO.LichKhamDTO> listOfLichKham = lichKhamBLL.GetByMaBenhNhan(benhNhan.MaSo);

            int STT = 1;
            foreach (var lk in listOfLichKham)
            {
                // Lấy thông tin bác sĩ và khoa
                var bacSi = bacSiBLL.GetById(lk.MaBS);
                var khoa = khoaBLL.GetById(bacSi.MaKhoa);

                // Lấy thông tin PhieuKham liên quan
                var phieuKham = phieuKhamBLL.GetByMaLK(lk.MaLK); // Phương thức giả định

                // Thêm dòng mới vào DataGridView
                var index = dataGridView1.Rows.Add();

                // Gán giá trị vào các ô
                Enums.ETrangThaiKham trangThai = lk.TrangThai;
                dataGridView1.Rows[index].Cells[0].Value = STT; // Số thứ tự
                dataGridView1.Rows[index].Cells[1].Value = khoa?.ChuyenKhoa ?? "Không xác định"; // Chuyên khoa
                dataGridView1.Rows[index].Cells[2].Value = bacSi?.HoTen ?? "Không xác định"; // Họ tên bác sĩ
                dataGridView1.Rows[index].Cells[3].Value = lk.NgayKham.ToString("dd/MM/yyyy"); // Ngày khám
                dataGridView1.Rows[index].Cells[4].Value = phieuKham?.TrieuChung ?? "Chưa có thông tin"; // Triệu chứng từ PhieuKham
                dataGridView1.Rows[index].Cells[5].Value = trangThai == Enums.ETrangThaiKham.ChuaKham ? "Chưa khám" : trangThai == Enums.ETrangThaiKham.DaKham ? "Đã khám" : "Hủy khám";   // Trạng thái

                // Gán Tag nếu cần
                dataGridView1.Rows[index].Cells[0].Tag = lk;
                dataGridView1.Rows[index].Cells[1].Tag = khoa;

                // Tăng số thứ tự
                STT += 1;
            }
        }


        //private void insertHelper(List<DTO.LichKhamDTO> lkList)
        //{
        //    int STT = 1;
        //    foreach (var lk in lkList)
        //    { // Chuyen khoa, bac si, ngay hen, trieu chung, trang thái
        //        var bacSi = bacSiBLL.GetById(lk.MaBS);
        //        var khoa = khoaBLL.GetById(bacSi.MaKhoa);
        //        //var benhNhan = benhNhanBll.GetById(lk.MaBN);

        //        // Lấy thông tin PhieuKham liên quan
        //        var phieuKham = phieuKhamBLL.GetByMaLK(lk.MaLK); // Phương thức giả định

        //        var index = dataGridView1.Rows.Add();
        //        dataGridView1.Rows[index].Cells[0].Value = STT;
        //        dataGridView1.Rows[index].Cells[1].Value = khoa.ChuyenKhoa;
        //        dataGridView1.Rows[index].Cells[2].Value = bacSi.HoTen;
        //        dataGridView1.Rows[index].Cells[3].Value = lk.NgayKham.ToShortDateString(); // khoa theo bac si
        //        dataGridView1.Rows[index].Cells[4].Value = phieuKham?.TrieuChung ?? "Không có triệu chứng"; // Triệu chứng từ PhieuKham
        //        dataGridView1.Rows[index].Cells[5].Value = lk.TrangThai;

        //        dataGridView1.Rows[index].Cells[0].Tag = lk;
        //        dataGridView1.Rows[index].Cells[1].Tag = khoa;
        //        dataGridView1.Rows[index].Cells[2].Tag = bacSi;
        //        STT++;
        //    }
        //}

        private void insertHelper(List<LichKhamDTO> listLichKham)
        {
            int STT = 1;
            foreach (var lk in listLichKham)
            {
                // Lấy thông tin bác sĩ và khoa
                var bacSi = bacSiBLL.GetById(lk.MaBS);
                var khoa = khoaBLL.GetById(bacSi.MaKhoa);

                // Lấy thông tin PhieuKham liên quan
                var phieuKham = phieuKhamBLL.GetByMaLK(lk.MaLK); // Phương thức giả định

                // Thêm dòng mới vào DataGridView
                var index = dataGridView1.Rows.Add();

                // Gán giá trị vào các ô
                Enums.ETrangThaiKham trangThai = lk.TrangThai;
                dataGridView1.Rows[index].Cells[0].Value = STT; // Số thứ tự
                dataGridView1.Rows[index].Cells[1].Value = khoa?.ChuyenKhoa ?? "Không xác định"; // Chuyên khoa
                dataGridView1.Rows[index].Cells[2].Value = bacSi?.HoTen ?? "Không xác định"; // Họ tên bác sĩ
                dataGridView1.Rows[index].Cells[3].Value = lk.NgayKham.ToString("dd/MM/yyyy"); // Ngày khám
                dataGridView1.Rows[index].Cells[4].Value = phieuKham?.TrieuChung ?? "Chưa có thông tin"; // Triệu chứng từ PhieuKham
                dataGridView1.Rows[index].Cells[5].Value = trangThai == Enums.ETrangThaiKham.ChuaKham ? "Chưa khám" : trangThai == Enums.ETrangThaiKham.DaKham ? "Đã khám" : "Hủy khám";   // Trạng thái

                // Gán Tag nếu cần
                dataGridView1.Rows[index].Cells[0].Tag = lk;
                dataGridView1.Rows[index].Cells[1].Tag = khoa;

                // Tăng số thứ tự
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

            //if (string.IsNullOrWhiteSpace(trieuChungTxt.Text))
            //{
            //    MessageBox.Show("Vui lòng nhập Triệu chứng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (string.IsNullOrEmpty(SDTTxt.Text))
            //{
            //    MessageBox.Show("Vui lòng nhập điện thoại trước khi đăng ký lịch khám.", "Thông báo",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            return true;
        }

        private void button6_Click(object sender, EventArgs e)
        {

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

            List<LichKhamDTO> resultList = lichKhamBLL.TimKiemTheoChuyenKhoa(chuyenKhoa, benhNhan.MaSo);

            if (resultList == null)
            {
                MessageBox.Show("Không có kết quả phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataGridView1.Rows.Clear();
            insertHelper(resultList);

        }

        private void TimKiemTheoTrangThai(string str)
        {
            // Kiểm tra nếu dữ liệu trong textBox5 hợp lệ
            if (string.IsNullOrEmpty(str))
            {
                MessageBox.Show("Chưa nhập thông tin tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Enums.ETrangThaiKham trangThai = Enums.ETrangThaiKham.ChuaKham;
            if (str.ToLower().Contains("đã khám") || str.ToLower().Contains("da kham"))
                trangThai = Enums.ETrangThaiKham.DaKham;
            else if (str.ToLower().Contains("chưa khám") || str.ToLower().Contains("chua kham"))
                trangThai = Enums.ETrangThaiKham.ChuaKham;
            else if (str.ToLower().Contains("hủy khám") || str.ToLower().Contains("huy kham"))
                trangThai = Enums.ETrangThaiKham.HuyKham;
            else
            { // Khong nhap dung 
                MessageBox.Show("Không có kết quả phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<LichKhamDTO> resultList = lichKhamBLL.GetByTrangThai(trangThai);

            if (resultList == null)
            {
                MessageBox.Show("Không có kết quả phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataGridView1.Rows.Clear();
            insertHelper(resultList);

        }

        private void TimKiemTheoBacSi(string chuyenKhoa)
        {
            // Kiểm tra nếu dữ liệu trong textBox5 hợp lệ
            if (string.IsNullOrEmpty(chuyenKhoa))
            {
                MessageBox.Show("Chưa nhập thông tin tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<LichKhamDTO> resultList = lichKhamBLL.TimKiemTheoBacSi(chuyenKhoa, benhNhan.MaSo);

            if (resultList == null)
            {
                MessageBox.Show("Không có kết quả phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataGridView1.Rows.Clear();
            insertHelper(resultList);

        }

        private void PhieuKham_click(object sender, EventArgs e)
        {
            // Tạo phiếu khám
            // Bệnh nhân có thể xem phiếu khám của những lịch khám đã khám
            // Trạng thái lịch khám: Chưa khám, Đã khám, Đã hủy
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn một lịch khám", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            DTO.LichKhamDTO lk = (DTO.LichKhamDTO)selectedRow.Cells[0].Tag;
            // Chưa khám hoặc đã hủy khám
            if (lk.TrangThai != Enums.ETrangThaiKham.DaKham)
            {
                MessageBox.Show("Bạn không thể xem các lịch khám với trạng thái chưa khám.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            PhieuKham_Edit chinhSuaPnl = new PhieuKham_Edit(lk, benhNhan, user);
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

        private void ChinhSua_click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lịch hẹn để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var selectedRow = dataGridView1.SelectedRows[0];

            LichKhamDTO lk = (LichKhamDTO)selectedRow.Cells[0].Tag;
            PhongKhoa khoa = (PhongKhoa)selectedRow.Cells[2].Tag;
            //BacSi bs = (BacSi)selectedRow.Cells[3].Tag;

            KhamBenh_Edit chinhSuaPnl = new KhamBenh_Edit(lk, benhNhan, lk.BacSi, 1);
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

        private void DangKy_Click(object sender, EventArgs e)
        {
            if (!ValidateFormData()) return;

            long bacSiId = (long)comboBox1.SelectedValue;
            var phanCongId = ngayHenCb.SelectedValue;
            if (phanCongId == null)
            {
                MessageBox.Show("Bác sĩ này chưa được phân công lịch khám", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            BacSi selectedBacSi = bacSiBLL.GetById(bacSiId);
            LichPhanCong selectedPhanCong = phanCongBLL.GetById((long)phanCongId);

            LichKhamDTO lichKham = new LichKhamDTO
            {
                MaBN = benhNhan.MaSo,
                MaBS = selectedBacSi.MaSo,
                //TrieuChung = trieuChungTxt.Text,
                NgayKham = selectedPhanCong.NgayThucHien,
            };
            // tìm nhân viên và  có lịch phân công ngày đó
            long selectedNhanVienID = selectedPhanCong.MaNV;
            List<LichPhanCong> PC = phanCongBLL.GetAllPhanCongByMaBacSi(lichKham.MaBS);


            lichKhamBLL.TaoLichKham(lichKham, selectedNhanVienID);
            UpdateDataGrid();
        }

        private void TimKiem_click(object sender, EventArgs e)
        {
            string chuoi = textBox5.Text;
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    TimKiemTheoChuyenKhoa(chuoi);
                    return;
                case 1:
                    TimKiemTheoBacSi(chuoi);
                    return;
                case 2:
                    TimKiemTheoTrangThai(chuoi);
                    return;

            }
        }
    }
}
