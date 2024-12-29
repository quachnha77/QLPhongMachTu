using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class NhanVien_Add : Form
    {
        private PhanQuyenBLL pqBLL = new PhanQuyenBLL();
        private KhoaBLL pkBLL = new KhoaBLL();
        private NhanVienBLL nvBLL = new NhanVienBLL();
        private BacSiBLL bsBLL = new BacSiBLL();
        private UserBLL userBLL = new UserBLL();
        private NhanVienGUI nvGUI;

        public NhanVien_Add(NhanVienGUI gui)
        {
            InitializeComponent();
            this.nvGUI = gui;
            this.StartPosition = FormStartPosition.CenterScreen;
            radioButton1.Checked = true;
            LoadChucVu();
            LoadKhoa();
        }

        private void LoadChucVu()
        {
            List<string> dsTenQuyen = pqBLL.GetPhanQuyenByName();

            // Đổ danh sách vào ComboBox
            cbxChucVu.DataSource = dsTenQuyen;
            cbxChucVu.SelectedIndex = -1;
        }

        private void LoadKhoa()
        {
            List<string> dsTenKhoa = pkBLL.GetName();

            // Đổ danh sách vào ComboBox
            cbxKhoa.DataSource = dsTenKhoa;
            cbxKhoa.SelectedIndex = -1;
        }
        private void cbxChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxChucVu.SelectedItem != null && cbxChucVu.SelectedItem.ToString() == "Bác sĩ")
            {
                cbxKhoa.Enabled = true;
            }
            else
            {
                cbxKhoa.Enabled = false;
                cbxKhoa.SelectedIndex = -1;
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = sender == radioButton1;
            radioButton2.Checked = sender == radioButton2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!InputValidator()) return;

            string hoTen = txtTen.Text;
            string gioiTinh = radioButton1.Checked ? "Nam" : "Nữ";
            long cccd = long.Parse(txtCCCD.Text);
            string sdt = txtSDT.Text;
            DateTime ngaySinh = dateTimePicker1.Value;
            string diaChi = txtDiaChi.Text;
            string chucVu = cbxChucVu.SelectedItem?.ToString();
            string khoa = chucVu == "Bác sĩ" ? cbxKhoa.SelectedItem?.ToString() : null;
            string email = txtEmail.Text;

            User user = CreateUser(cccd, email, ngaySinh, chucVu);

            bool newUser = userBLL.CreateUser(user);
            if (newUser)
            {
                bool result = chucVu != "Bác sĩ"
                    ? AddNhanVien(user, hoTen, cccd, gioiTinh, ngaySinh, diaChi, sdt) :
                    AddBacSi(user, hoTen, cccd, gioiTinh, ngaySinh, diaChi, sdt, khoa);

                if (result)
                {
                    MessageBox.Show("Thêm thành công!");
                    this.Close();
                    nvGUI.LoadDataWithRoles();
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm!");
                }
            }
        }

        private User CreateUser(long cccd, string email, DateTime ngaySinh, string chucVu)
        {
            return new User
            {
                MaPQ = pqBLL.GetMaPQByName(chucVu),
                Username = cccd.ToString(),
                Password = ngaySinh.ToString("ddMMyyyy"),
                Email = email,
                TrangThai = true
            };
        }

        private bool AddNhanVien(User user, string hoTen, long cccd, string gioiTinh, DateTime ngaySinh, string diaChi, string sdt)
        {
            NhanVien nv = new NhanVien
            {
                HoTen = hoTen,
                ChucVu = cbxChucVu.SelectedItem?.ToString(),
                CCCD = cccd,
                NgaySinh = ngaySinh,
                GioiTinh = gioiTinh,
                DiaChi = diaChi,
                SDT = sdt,
                MaUser = user.MaUser
            };

            return nvBLL.AddNhanVien(nv);
        }

        private bool AddBacSi(User user, string hoTen, long cccd, string gioiTinh, DateTime ngaySinh, string diaChi, string sdt, string khoa)
        {
            if (string.IsNullOrEmpty(khoa))
            {
                MessageBox.Show("Vui lòng chọn khoa cho bác sĩ!");
                return false;
            }

            BacSi bs = new BacSi()
            {
                HoTen = hoTen,
                CCCD = cccd,
                NgaySinh = ngaySinh,
                GioiTinh = gioiTinh,
                DiaChi = diaChi,
                SDT = sdt,
                MaKhoa = pkBLL.GetMaKhoaByName(khoa),
                MaUser = user.MaUser
            };

            return bsBLL.AddBacSi(bs);
        }

        public bool InputValidator()
        {
            if (IsInputFieldsEmpty())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return false;
            }

            // Kiểm tra email hợp lệ
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng email (ví dụ: @gmail.com)!");
                return false;
            }

            if (userBLL.IsEmailExist(txtEmail.Text))
            {
                MessageBox.Show("Email đã tồn tại. Vui lòng kiểm tra lại!");
                return false;
            }

            // Kiểm tra CCCD hợp lệ và chưa tồn tại
            if (!IsValidCCCD(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng CCCD (12 chữ số)!");
                return false;
            }

            if (userBLL.IsCCCDExist(long.Parse(txtCCCD.Text)))
            {
                MessageBox.Show("CCCD đã tồn tại. Vui lòng kiểm tra lại!");
                return false;
            }

            if (!IsValidPhoneNumber(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số điện thoại (10 chữ số)!");
                return false;

            }

            return true;
        }

        // Phương thức kiểm tra các trường nhập liệu
        private bool IsInputFieldsEmpty()
        {
            return string.IsNullOrEmpty(txtTen.Text) ||
                   string.IsNullOrEmpty(txtCCCD.Text) ||
                   string.IsNullOrEmpty(txtSDT.Text) ||
                   string.IsNullOrEmpty(txtDiaChi.Text) ||
                   cbxChucVu.SelectedIndex == -1 ||
                   string.IsNullOrEmpty(txtEmail.Text);
        }

        // Kiểm tra tính hợp lệ của email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Kiểm tra tính hợp lệ của số điện thoại
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Biểu thức chính quy kiểm tra số điện thoại hợp lệ (10 chữ số)
            string pattern = @"^(03|05|07|08|09)([0-9]{8})$";
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, pattern);
        }

        // Kiểm tra tính hợp lệ của CCCD
        private bool IsValidCCCD(string cccd)
        {
            string pattern = @"^[0-9]{12}$";
            return System.Text.RegularExpressions.Regex.IsMatch(cccd, pattern);
        }
    }
}
