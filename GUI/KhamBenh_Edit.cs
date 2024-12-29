using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class KhamBenh_Edit : UserControl
    {
        // ConKienHuy
        private LichKhamDTO LichKham = new LichKhamDTO();
        private BenhNhan BenhNhan = new BenhNhan();
        private BacSi BacSi = new BacSi();
        private int controlNumber;

        private KhoaBLL khoaBll = new KhoaBLL();
        private BacSiBLL bacSiBll = new BacSiBLL();
        private BenhNhanBLL benhNhanBll = new BenhNhanBLL();
        private PhanCongBLL phanCongBll = new PhanCongBLL();
        private LichKhamBLL lichKhamBll = new LichKhamBLL();
        private UserBLL userBll = new UserBLL();
        private PhieuKhamBLL phieuKhamBll = new PhieuKhamBLL();

        public KhamBenh_Edit(LichKhamDTO lk, BenhNhan bn, BacSi bs, int controlNumber)
        {
            InitializeComponent();
            LichKham = lk; BenhNhan = bn; BacSi = bs;
            this.controlNumber = controlNumber;
            ShowInformation();
        }

        // Show các thông tin bệnh nhân lên màn hình
        private void ShowInformation()
        {
            var pk = phieuKhamBll.GetByMaLK(LichKham.MaLK);
            textBox1.Text = BenhNhan.HoTen;
            textBox2.Text = BenhNhan.DiaChi;
            textBox3.Text = BenhNhan.SDT;
            textBox4.Text = BenhNhan.GioiTinh;
            textBox5.Text = pk?.TrieuChung ?? "Chưa có thông tin.";

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
            comboBox3.DisplayMember = "NgayThucHien"; // Hiện thông tin theo ngày
            comboBox3.ValueMember = "MaLPC"; // Lấy theo MaLPC
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
            if (controlNumber == 1)
                TroVeKhamBenh();
            else
                TroVeKhamBenh_LT();
        }

        private void button2_Click(object sender, EventArgs e)
        {// Lưu
            long maLK = LichKham.MaLK;
            long bacSiId = Convert.ToInt64(comboBox2.SelectedValue);
            long phanCongId = Convert.ToInt64(comboBox3.SelectedValue);

            LichKhamDTO updateLichKham = new LichKhamDTO()
            {
                MaBS = bacSiId,
                MaBN = BenhNhan.MaSo,
                //TrieuChung = textBox5.Text
            };

            // Check người dùng có sửa thông tin bệnh nhân không.
            bool ifBenhNhanUpdated = true;
            if (textBox1.Text != BenhNhan.HoTen || textBox2.Text != BenhNhan.DiaChi
                || textBox3.Text != BenhNhan.SDT || textBox4.Text != BenhNhan.GioiTinh)
            {
                BenhNhan updateBenhNhan = new BenhNhan()
                {
                    HoTen = textBox1.Text,
                    DiaChi = textBox2.Text,
                    SDT = textBox3.Text,
                    GioiTinh = textBox4.Text,
                    //NgaySinh = textBox6.Text
                };
                ifBenhNhanUpdated = benhNhanBll.UpdateBenhNhan(BenhNhan.MaSo, updateBenhNhan);
            }

            var result = lichKhamBll.SuaLichKham(maLK, updateLichKham, phanCongId);
            if (result && ifBenhNhanUpdated)
            {
                MessageBox.Show("Chỉnh sửa lịch khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (controlNumber == 1)
                    TroVeKhamBenh();
                else
                    TroVeKhamBenh_LT();
            }

            else
                MessageBox.Show("Có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void TroVeKhamBenh()
        {
            User user = userBll.GetById(BenhNhan.MaUser);
            KhamBenh khamBenh = new KhamBenh(user, BenhNhan);
            var panelContent = this.FindForm().Controls["panelMain"] as Panel;

            if (panelContent != null)
            {
                // Xóa các control cũ trong panelContent
                panelContent.Controls.Clear();

                // Thêm UserControl mới vào panelContent
                khamBenh.Dock = DockStyle.Fill;
                panelContent.Controls.Add(khamBenh);
                panelContent.Refresh();
            }
        }

        private void TroVeKhamBenh_LT()
        {
            KhamBenh_LT khamBenhLT = new KhamBenh_LT(new NhanVien());
            var panelContent = this.FindForm().Controls["panelMain"] as Panel;

            if (panelContent != null)
            {
                // Xóa các control cũ trong panelContent
                panelContent.Controls.Clear();

                // Thêm UserControl mới vào panelContent
                khamBenhLT.Dock = DockStyle.Fill;
                panelContent.Controls.Add(khamBenhLT);
                panelContent.Refresh();
            }
        }
    }
}
