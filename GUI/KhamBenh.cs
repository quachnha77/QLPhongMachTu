using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        private ApplicationDbContext DbContext= new ApplicationDbContext();

        public KhamBenh(User user, BenhNhan benhNhan)
        {
            this.user = user; this.benhNhan = benhNhan;
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            InserData();
            UpdateData();
            //ShowPhanCongByBacSi();

            hoTenTxt.Text = benhNhan.HoTen;
            SDTTxt.Text = benhNhan.SDT != null? benhNhan.SDT.ToString() : "";

            // Readonly
            hoTenTxt.Enabled = false;
            SDTTxt.Enabled = false;
        }

        // Phần Button đăng ký
        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu chưa chọn chuyên khoa
            if (chuyenKhoaSlt.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Chuyên khoa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra nếu chưa chọn bác sĩ
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Bác sĩ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra nếu người dùng chưa nhập triệu chứng
            if (string.IsNullOrWhiteSpace(trieuChungTxt.Text))
            {
                MessageBox.Show("Vui lòng nhập Triệu chứng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /* Hết Phần check dữ liệu */

            // Lấy bác sĩ để gán vô lịch khám.
            long bacSiId = (long)comboBox1.SelectedValue;
            BacSi existingBacSi = bacSiBLL.GetById(bacSiId);
            long phanCongId = (long)ngayHenCb.SelectedValue;

            var pc = phanCongBLL.GetById(phanCongId);

            // Tạo mới lịch khám
            LichKham lichKham = new LichKham
            {
                MaBN = benhNhan.MaSo,
                MaBS = existingBacSi.MaSo,
                TrieuChung = trieuChungTxt.Text,
                NgayKham = pc.NgayPhanCong,
            };
            var result = lichKhamBLL.TaoLichKham(lichKham);

            UpdateData();
        }

        // Bước 1: Đưa hết các chuyên khoa lên màn hình
        private void InserData()
        {
            List<PhongKhoa> chuyenKhoaList = khoaBLL.GetAll();

            chuyenKhoaSlt.DataSource = chuyenKhoaList;
            chuyenKhoaSlt.DisplayMember = "TenPhongBan"; // Phần sẽ hiển thị lên UI.
            chuyenKhoaSlt.ValueMember = "MaPK"; // Lưu lại khóa chính của từng khoa.

            ShowAvailableDoctor((long)chuyenKhoaSlt.SelectedValue);
        }

        // Bước 2: Sau khi đã chọn chuyên khoa.
        // Truyền chuyên khoa Id vào ShowAvailableDoctor() 
        // Để chọn các bác sĩ thuộc chuyên khoa đó
        private void chuyenKhoaSlt_DropDownClosed(object sender, EventArgs e)
        {
            string chuyenKhoa = chuyenKhoaSlt.Text;
            PhongKhoa khoa = khoaBLL.GetByChuyenKhoa(chuyenKhoa);
            if (khoa != null)
            {
                ShowAvailableDoctor(khoa.MaPK);
            }
        }


        // Chọn các bác sĩ có trong chuyên khoa
        public void ShowAvailableDoctor(long khoaId)
        {
            comboBox1.DataSource = null; // Làm trống danh sách bác sĩ 
            List<BacSi> bacSiList = bacSiBLL.GetAllByChuyenKhoa(khoaId);

            if (bacSiList.Count == 0)
            {
                MessageBox.Show("Không có bác sĩ nào trong chuyên khoa này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            comboBox1.DataSource = bacSiList;
            comboBox1.DisplayMember = "HoTen";
            comboBox1.ValueMember = "MaSo";

            ShowPhanCongByBacSi((long)comboBox1.SelectedValue);
        }

        public void ShowPhanCongByBacSi(long bacSiId)
        {
            List<LichPhanCong> phanCongList = phanCongBLL.GetAllPhanCongByMaBacSi(bacSiId);

            ngayHenCb.DataSource = phanCongList;
            ngayHenCb.DisplayMember = "NgayPhanCong";
            ngayHenCb.ValueMember = "MaLPC";
        }

        // Phần hiển thị data lên gridview
        // Được gọi khi vừa khởi tạo màn hình
        // hoặc khi button1_Click();
        private void UpdateData()
        {
            // Reset dataGrid
            dataGridView1.Rows.Clear();
            // List dữ liệu đổ vào datagridView
            var listOfLichKham = lichKhamBLL.GetByMaBenhNhan(benhNhan.MaSo);

            int STT = 0;
            foreach (var lk in listOfLichKham)
            {
                
                var bacSi = bacSiBLL.GetById(lk.MaBS);
                var phongKhoa = khoaBLL.GetById(bacSi.MaKhoa);
                STT+=1;
                dataGridView1.Rows.Add(STT, phongKhoa.ChuyenKhoa, lk.NgayKham, lk.TrieuChung, "Đang xử lý");
                STT -= 1;
                dataGridView1.Rows[STT].Tag = lk.MaLK; // Lưu lại khóa chính để lấy lịch khám
                STT += 1;
            }
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            long bacSiId = (long)comboBox1.SelectedValue;
            ShowPhanCongByBacSi(bacSiId);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var n = dataGridView1.SelectedRows.Count;
            if (n <= 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để hủy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var xacNhanNguoiDung = MessageBox.Show("Bạn chắc chắn hủy lịch hẹn này không?", "Xác nhân", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (xacNhanNguoiDung != DialogResult.OK) return;
            // Lấy ra dòng đầu tiên
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            long lichKhamId = (long)dataGridView1.Rows[selectedRow.Index].Tag;
            var result = lichKhamBLL.XoaLichKham(lichKhamId);
            if (result != null)
            {
                MessageBox.Show("Hủy lịch hẹn thành công.", "Thông báo");
            }
            else MessageBox.Show("Hủy lịch hẹn thất bại.", "Thông báo");

            UpdateData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var n = dataGridView1.SelectedRows.Count;
            if (n <= 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa", "Thông báo");
                return;
            }
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int Stt = (int) selectedRow.Cells[0].Value;
            string chuyenKhoa = (string)selectedRow.Cells[1].Value;
            DateTime ngayHen = (DateTime)selectedRow.Cells[2].Value;
            string trieuChung = (string)selectedRow.Cells[3].Value;
            InsertData(1, chuyenKhoa, trieuChung);
            UpdateData(1);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            InserData();
            UpdateData();
        }

        private void InsertData(long id, string chuyenKhoa, string trieuChung)
        {
            List<string> ckTemp = new List<string>();
            ckTemp.Add(chuyenKhoa);
            chuyenKhoaSlt.DataSource = ckTemp;
            trieuChungTxt.Text = trieuChung;

            // Cập nhật lịch khám

        }

        private void UpdateData(long id)
        {

        }
    }
}
