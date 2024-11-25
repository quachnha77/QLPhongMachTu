using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class NhanVien_Edit : Form
    {
        // Khai báo các đối tượng cho các lớp BLL
        private PhanQuyenBLL pqBLL = new PhanQuyenBLL();
        private KhoaBLL pkBLL = new KhoaBLL();
        private NhanVienBLL nvBLL = new NhanVienBLL();
        private BacSiBLL bsBLL = new BacSiBLL();
        private UserBLL userBLL = new UserBLL();

        private string oldChucVu;
        private long MaUser;

        public NhanVien_Edit()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            LoadChucVu();
            LoadKhoa();
            txtMaNV.Enabled = false;
            txtCCCD.Enabled = false;
        }

        // Tải danh sách chức vụ
        private void LoadChucVu()
        {
            cbxChucVu.DataSource = pqBLL.GetPhanQuyenByName();
            cbxChucVu.SelectedIndex = -1;
        }

        // Tải danh sách khoa
        private void LoadKhoa()
        {
            cbxKhoa.DataSource = pkBLL.GetName();
            cbxKhoa.SelectedIndex = -1;
        }

        // Xử lý khi thay đổi lựa chọn trong ComboBox chức vụ
        private void cbxChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isBacSi = cbxChucVu.SelectedItem?.ToString() == "Bác sĩ";
            cbxKhoa.Enabled = isBacSi;

            if (!isBacSi)
            {
                cbxKhoa.SelectedIndex = -1;
            }
        }

        // Xử lý khi chọn giới tính
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = sender == radioButton1;
            radioButton2.Checked = sender == radioButton2;
        }

        // Xử lý khi nhấn nút "Cập nhật"
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra tính hợp lệ của các trường dữ liệu
                if (ValidateInputs())
                {
                    long CCCD = long.Parse(txtCCCD.Text);
                    string ocv = oldChucVu;
                    bool result = false;

                    if (ocv != "Bác sĩ")// Nếu nhân viên hiện tại không phải bác sĩ
                    {
                        if (cbxChucVu.SelectedItem.ToString() != "Bác sĩ") // Không chuyển đổi sang bác sĩ
                        {
                            NhanVien nv = CreateNhanVienFromInputs();
                            result = nvBLL.UpdateNhanVien(nv);
                            userBLL.UpdateEmailandMaPQ(nv.MaSo, txtEmail.Text);
                        }
                        else // Chuyển đổi sang bác sĩ
                        {
                            (bool exists, long maUser) = bsBLL.IsCCCDExistAndGetMaUser(CCCD);

                            if (!exists)
                            {
                                if (cbxKhoa.SelectedIndex == -1)
                                {
                                    MessageBox.Show("Vui lòng chọn khoa cho Bác sĩ.");
                                    return;
                                }
                                result = ConvertNhanVienToBacSi(long.Parse(txtMaNV.Text));
                            }
                            else
                            {
                                BacSi bs = CreateBacSiFromInputs();
                                userBLL.UpdateTrangThaiAndQuyen(maUser, "Bác sĩ", true);
                                userBLL.UpdateTrangThaiAndQuyen(MaUser, "Vô hiệu hóa", false);

                                result = true;
                            }
                        }
                    }
                    else // Nếu nhân viên hiện tại là bác sĩ
                    {
                        if (cbxChucVu.SelectedItem.ToString() != "Bác sĩ") // Chuyển đổi sang chức vụ khác
                        {
                            (bool exists, long maUser) = nvBLL.IsCCCDExistAndGetMaUser(CCCD);
                            if (!exists)
                            {
                                result = ConvertBacSiToNhanVien(long.Parse(txtMaNV.Text));
                            }
                            else
                            {
                                NhanVien nv = CreateNhanVienFromInputs();
                                nvBLL.UpdateNhanVienByCCCD(nv);
                                userBLL.UpdateTrangThaiAndQuyen(maUser, cbxChucVu.SelectedItem.ToString(), true);
                                userBLL.UpdateTrangThaiAndQuyen(MaUser, "Vô hiệu hóa", false);

                                result = true;
                            }
                        }
                        else // Cập nhật thông tin bác sĩ
                        {
                            BacSi bs = CreateBacSiFromInputs();
                            result = bsBLL.UpdateBacSi(bs);
                            userBLL.UpdateEmailandMaPQ(bs.MaSo, txtEmail.Text);
                        }
                    }
                    if (result)
                    {
                        MessageBox.Show("Cập nhật thông tin nhân viên thành công.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin nhân viên thất bại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private bool ConvertNhanVienToBacSi(long maNV)
        {
            NhanVien nv = nvBLL.GetNhanVienByMa(maNV);
            User older = userBLL.GetById(nv.MaUser);

            // Tạo người dùng mới cho bác sĩ
            User user = new User
            {
                MaPQ = pqBLL.GetMaPQByName("Bác sĩ"),  // Quyền Bác sĩ
                Email = txtEmail.Text,
                Password = older.Password,
                Username = older.Username,
                TrangThai = true
            };

            long newMaUser = userBLL.AddUserAndGetId(user);
            userBLL.UpdateTrangThaiAndQuyen(nv.MaUser, "Vô hiệu hóa", false);

            BacSi bs = new BacSi
            {
                MaSo = nv.MaSo,
                HoTen = nv.HoTen,
                CCCD = nv.CCCD,
                SDT = nv.SDT,
                DiaChi = nv.DiaChi,
                NgaySinh = nv.NgaySinh,
                GioiTinh = nv.GioiTinh,
                MaKhoa = pkBLL.GetMaKhoaByName(cbxKhoa.SelectedItem.ToString()), // Thêm khoa
                MaUser = newMaUser
            };

            bool result = bsBLL.AddBacSi(bs);

            return result;
        }

        private bool ConvertBacSiToNhanVien(long maNV)
        {
            BacSi bs = bsBLL.GetBacSiByMa(maNV);
            User older = userBLL.GetById(bs.MaUser);

            // Tạo người dùng mới cho bác sĩ
            User user = new User
            {
                MaUser = MaUser,
                MaPQ = pqBLL.GetMaPQByName(cbxChucVu.SelectedItem.ToString()),
                Email = txtEmail.Text,
                Password = older.Password,
                Username = older.Username,
                TrangThai = true
            };

            long newMaUser = userBLL.AddUserAndGetId(user);

            // Vô hiệu hóa bác sĩ cũ
            userBLL.UpdateTrangThaiAndQuyen(bs.MaUser, "Vô hiệu hóa", false);

            NhanVien nv = new NhanVien
            {
                MaSo = bs.MaSo,
                HoTen = bs.HoTen,
                CCCD = bs.CCCD,
                SDT = bs.SDT,
                DiaChi = bs.DiaChi,
                NgaySinh = bs.NgaySinh,
                ChucVu = cbxChucVu.SelectedItem.ToString(),
                GioiTinh = bs.GioiTinh,
                MaUser = newMaUser
            };

            bool result = nvBLL.AddNhanVien(nv);
            return result;
        }

        private NhanVien CreateNhanVienFromInputs()
        {
            return new NhanVien
            {
                MaSo = long.Parse(txtMaNV.Text),
                HoTen = txtTen.Text,
                CCCD = long.Parse(txtCCCD.Text),
                SDT = txtSDT.Text,
                DiaChi = txtDiaChi.Text,
                NgaySinh = dateTimePicker1.Value,
                ChucVu = cbxChucVu.SelectedItem.ToString(),
                GioiTinh = radioButton1.Checked ? "Nam" : "Nữ",
            };
        }

        private BacSi CreateBacSiFromInputs()
        {
            return new BacSi
            {
                MaSo = long.Parse(txtMaNV.Text),
                HoTen = txtTen.Text,
                CCCD = long.Parse(txtCCCD.Text),
                SDT = txtSDT.Text,
                DiaChi = txtDiaChi.Text,
                NgaySinh = dateTimePicker1.Value,
                GioiTinh = radioButton1.Checked ? "Nam" : "Nữ",
                MaKhoa = pkBLL.GetMaKhoaByName(cbxKhoa.SelectedItem.ToString())
            };
        }

        private bool ValidateInputs()
        {
            // Kiểm tra tính hợp lệ của các trường dữ liệu
            if (string.IsNullOrEmpty(txtTen.Text))
            {
                txtTen.Focus();
                MessageBox.Show("Vui lòng điền đầy đủ tên.");
                return false;
            }

            if (string.IsNullOrEmpty(txtCCCD.Text) || !IsValidCCCD(txtCCCD.Text))
            {
                txtCCCD.Focus();
                MessageBox.Show("CCCD không hợp lệ.");
                return false;
            }

            if (string.IsNullOrEmpty(txtSDT.Text) || !IsValidPhoneNumber(txtSDT.Text))
            {
                txtSDT.Focus();
                MessageBox.Show("Số điện thoại không hợp lệ.");
                return false;
            }

            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                txtDiaChi.Focus();
                MessageBox.Show("Vui lòng điền đầy đủ địa chỉ.");
                return false;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                txtEmail.Focus();
                MessageBox.Show("Email không hợp lệ.");
                return false;
            }

            return true;
        }

        public void LoadData(string maNV, string ten, string cccd, string sdt, string diaChi, DateTime ngaySinh, string chucVu, string gioiTinh)
        {
            // Hiển thị dữ liệu vào các trường
            txtMaNV.Text = maNV;
            txtTen.Text = ten;
            txtCCCD.Text = cccd;
            txtSDT.Text = sdt;
            txtDiaChi.Text = diaChi;
            dateTimePicker1.Value = ngaySinh;
            cbxChucVu.SelectedItem = chucVu;

            if (chucVu != "Bác sĩ")
            {
                txtEmail.Text = userBLL.GetEmailByMa(long.Parse(maNV), "NhanVien");
            }
            else
            {
                txtEmail.Text = userBLL.GetEmailByMa(long.Parse(maNV), "BacSi");
                cbxKhoa.SelectedItem = bsBLL.GetKhoaByMa(long.Parse(maNV));
            }

            // Thiết lập RadioButton giới tính
            if (gioiTinh == "Nam")
            {
                radioButton1.Checked = true;
            }
            else if (gioiTinh == "Nữ")
            {
                radioButton2.Checked = true;
            }
        }

        public void SetData(string chucVu, long maUser)
        {
            oldChucVu = chucVu;
            MaUser = maUser;
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
