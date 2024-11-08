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
            this.user = user; this.benhNhan = benhNhan;
            InitializeComponent();
            InserData();
            UpdateData();

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

            // Tạo mới lịch khám
            LichKham lichKham = new LichKham
            {
                MaBN = benhNhan.MaSo,
                MaBS = (long)comboBox1.SelectedValue,
                TrieuChung = trieuChungTxt.Text,
                NgayKham = new DateTime(1990, 1, 1)
            };
            lichKhamBLL.TaoLichKham(lichKham);

<<<<<<< HEAD
            UpdateData();
        }

        // Chọn các bác sĩ có trong chuyên khoa
        public void ShowAvailableDoctor(long khoaId)
        {
            List<BacSi> bacSiList = bacSiBLL.GetAllByChuyenKhoa(khoaId);

            comboBox1.DataSource = bacSiList;
            comboBox1.DisplayMember = "HoTen";
            comboBox1.ValueMember = "MaSo";
        }

        // Bước 2: Chọn các bác sĩ thuộc chuyên khoa vừa được chọn
        private void chuyenKhoaSlt_DropDownClosed(object sender, EventArgs e)
        {
            string chuyenKhoa = chuyenKhoaSlt.SelectedText;
            if (chuyenKhoa != null)
            {
                // Lấy phòng khoa theo chuyên khoa
                PhongKhoa khoa = khoaBLL.GetByChuyenKhoa(chuyenKhoa);
                ShowAvailableDoctor(khoa.MaPK);
            }
=======
            // Cập nhật lại dữ liệu
            UpdateData();
>>>>>>> 280ab2de26987c0a275201e8ff344fa5ab0ee6b5
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

<<<<<<< HEAD
        private void UpdateData()
        {
=======
        // Bước 2: Sau khi đã chọn chuyên khoa.
        // Truyền chuyên khoa Id vào ShowAvailableDoctor() 
        // Để chọn các bác sĩ thuộc chuyên khoa đó
        private void chuyenKhoaSlt_DropDownClosed(object sender, EventArgs e)
        {
            if (chuyenKhoaSlt.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Chuyên khoa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string chuyenKhoa = chuyenKhoaSlt.Text;
            PhongKhoa khoa = khoaBLL.GetByChuyenKhoa(chuyenKhoa);
            if (khoa != null)
            {
                ShowAvailableDoctor(khoa.MaPK);
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin chuyên khoa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // Chọn các bác sĩ có trong chuyên khoa
        public void ShowAvailableDoctor(long khoaId)
        {
            List<BacSi> bacSiList = bacSiBLL.GetAllByChuyenKhoa(khoaId);

            if (bacSiList.Count == 0)
            {
                MessageBox.Show("Không có bác sĩ nào trong chuyên khoa này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox1.DataSource = null; // Làm trống danh sách bác sĩ nếu không có
                return;
            }

            comboBox1.DataSource = bacSiList;
            comboBox1.DisplayMember = "HoTen";
            comboBox1.ValueMember = "MaSo";
        }

        // Phần hiển thị data lên gridview
        // Được gọi khi vừa khởi tạo màn hình
        // hoặc khi button1_Click();
        private void UpdateData()
        {
            // Reset dataGrid
            dataGridView1.Rows.Clear();
>>>>>>> 280ab2de26987c0a275201e8ff344fa5ab0ee6b5
            // List dữ liệu đổ vào datagridView
            var listOfLichKham = lichKhamBLL.GetByMaBenhNhan(benhNhan.MaSo);

            int STT = 0;
            foreach (var lk in listOfLichKham)
            {
                STT += 1;
                dataGridView1.Rows.Add(STT, "Thông báo sau", "Thông báo sau", lk.TrieuChung, "Đang xử lý");
            }
        }
    }
}
