using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class AddNhanVien : Form
    {
        private PhanQuyenBLL pqBLL = new PhanQuyenBLL();
        private PhongKhoaBLL pkBLL = new PhongKhoaBLL();
        private NhanVienBLL nvBLL = new NhanVienBLL();
        private BacSiBLL bsBLL = new BacSiBLL();
        private UserBLL userBLL = new UserBLL();
        private NhanVienGUI nvGUI;

        public AddNhanVien(NhanVienGUI gui)
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radioButton2.Checked = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioButton1.Checked = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string hoTen = txtTen.Text;
            string gioiTinh = radioButton1.Checked ? "Nam" : "Nữ";
            string cccdText = txtCCCD.Text;
            string sdt = txtSDT.Text;
            DateTime ngaySinh = dateTimePicker1.Value;
            string diaChi = txtDiaChi.Text;
            string chucVu = cbxChucVu.SelectedItem?.ToString();
            string khoa = chucVu == "Bác sĩ" ? cbxKhoa.SelectedItem?.ToString() : null;
            string email = txtEmail.Text;

            // Kiểm tra tính hợp lệ của dữ liệu
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(cccdText) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(chucVu) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng email(@gmail.com)!");
                return;
            }

            if (!IsValidCCCD(cccdText))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng CCCD (12 chữ số)!");
                return;
            }

            if (!IsValidPhoneNumber(sdt))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số điện thoại (10 chữ số)!");
                return;
            }

            // Chuyển đổi CCCD thành số nguyên
            long cccd = long.Parse(cccdText);

            // Tạo đối tượng người dùng và nhân viên hoặc bác sĩ
            User user = new User
            {
                MaPQ = pqBLL.GetMaPQByName(chucVu),
                Username = cccd.ToString(),
                Password = ngaySinh.ToString("yyyyMMdd"),
                Email = email,
                TrangThai = true
            };

            if (chucVu != "Bác sĩ")
            {
                NhanVien nv = new NhanVien
                {
                    HoTen = hoTen,
                    ChucVu = chucVu,
                    CCCD = cccd,
                    NgaySinh = ngaySinh,
                    GioiTinh = gioiTinh,
                    DiaChi = diaChi,
                    SDT = sdt,
                    MaUser = user.MaUser
                };

                try
                {
                    bool resultNhanVien = nvBLL.AddNhanVien(nv);
                    bool resultUser = userBLL.CreateUser(user);

                    if (resultNhanVien && resultUser)
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
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(khoa))
                {
                    MessageBox.Show("Vui lòng chọn khoa cho bác sĩ!");
                    return;
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

                try
                {
                    bool resultBacSi = bsBLL.AddBacSi(bs);
                    bool resultUser = userBLL.CreateUser(user);

                    if (resultBacSi && resultUser)
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
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi thêm: " + ex.Message);
                }
            }
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
            // Kiểm tra nếu CCCD có 12 chữ số
            string pattern = @"^[0-9]{12}$";
            return System.Text.RegularExpressions.Regex.IsMatch(cccd, pattern);
        }
    }
}
