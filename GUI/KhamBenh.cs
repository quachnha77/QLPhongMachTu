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
            // Tạo bảng hiển thị dữ liệu với các cột mong muốn
            var lichKhams = lichKhamBLL.GetByMaBenhNhan(benhNhan.MaSo);
            var displayData = new List<dynamic>();
            foreach (var lichKham in lichKhams)
            {
                displayData.Add(new
                {
                    //ChuyenKhoa = lichKham.ChuyenKhoa,
                    NgayHen = lichKham.NgayKham,
                    TrieuChung = lichKham.TrieuChung,
                    //TrangThai = lichKham.TrangThai
                });
            }

            // Gán dữ liệu vào DataGridView
            dataGridView1.DataSource = displayData;

            hoTenTxt.Text = benhNhan.HoTen;
            SDTTxt.Text = benhNhan.SDT != null? benhNhan.SDT.ToString() : "";

            // Readonly
            hoTenTxt.Enabled = false;
            SDTTxt.Enabled = false;
        }

        // Đăng ký lich khám
        private void button1_Click(object sender, EventArgs e)
        {
            LichKham lichKham = new LichKham();
            lichKham.MaBN = benhNhan.MaSo;
            lichKham.MaBS = (long)comboBox1.SelectedValue;
            lichKham.TrieuChung = trieuChungTxt.Text;
            lichKham.NgayKham = new DateTime(1990, 1, 1);
            lichKhamBLL.TaoLichKham(lichKham);

            dataGridView1.DataSource = lichKhamBLL.GetByMaBenhNhan(benhNhan.MaSo);
            //dataB
            return;
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
        }

        // Bước 1: Đưa hết các chuyên khoa lên màn hình
        private void InserData()
        {
            List<PhongKhoa> chuyenKhoaList = khoaBLL.GetAll();

            chuyenKhoaSlt.DataSource = chuyenKhoaList;
            chuyenKhoaSlt.DisplayMember = "TenPhongBan";
            chuyenKhoaSlt.ValueMember = "MaPK";
        }

    }
}
