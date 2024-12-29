using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class NhanVienGUI : UserControl
    {
        private PhanQuyenBLL pqBLL = new PhanQuyenBLL();
        private KhoaBLL khoaBLL = new KhoaBLL();
        private NhanVienBLL nvBLL = new NhanVienBLL();
        private UserBLL userBLL = new UserBLL();
        private BacSiBLL bsBLL = new BacSiBLL();
        int selectedRowIndex = -1;

        public NhanVienGUI()
        {
            InitializeComponent();
            checkBox5.Checked = true;
            LoadDataWithRoles();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                // Khi "Tất cả" được chọn, bỏ chọn các checkbox khác
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
            // Tải dữ liệu với các vai trò đã chọn
            LoadDataWithRoles();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked)
            {
                // Nếu bất kỳ checkbox nào khác được chọn, bỏ chọn "Tất cả"
                checkBox5.Checked = false;
            }
            // Tải dữ liệu với các vai trò đã chọn
            LoadDataWithRoles();
        }

        public void LoadDataWithRoles(string timKiem = "")
        {
            // Tạo danh sách chức vụ từ các checkbox đã chọn
            var selectedRoles = new List<string>();

            // Kiểm tra nếu không có checkbox nào được chọn, tự động chọn "Tất cả"
            if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked)
            {
                // Chọn checkbox "Tất cả" khi không có checkbox nào được chọn
                checkBox5.Checked = true;
                selectedRoles.Add("Tất cả");
            }
            else
            {
                // Nếu có checkbox nào được chọn, bỏ chọn "Tất cả"
                checkBox5.Checked = false;

                if (checkBox1.Checked) selectedRoles.Add("Bác sĩ");
                if (checkBox2.Checked) selectedRoles.Add("Dược sĩ");
                if (checkBox3.Checked) selectedRoles.Add("Lễ tân");
                if (checkBox4.Checked) selectedRoles.Add("Y tá");
            }

            // Gọi hàm LoadData với danh sách chức vụ
            LoadData(selectedRoles, timKiem);
        }

        public void LoadData(List<string> roles, string timKiem = "")
        {
            try
            {
                var dsnv = nvBLL.GetAllNhanVien();
                var dsuser = userBLL.GetAll();
                var dsbs = bsBLL.GetAllBacSi();

                // Tạo Dictionary để lưu trữ thông tin người dùng
                var userDictionary = dsuser.ToDictionary(u => u.MaUser, u => u.TrangThai);
                dataGridView1.Rows.Clear();

                foreach (var nv in dsnv)
                {
                    // Kiểm tra xem nhân viên có thỏa mãn điều kiện tìm kiếm hay không
                    if ((roles.Contains("Tất cả") || roles.Contains(nv.ChucVu)) &&
                        (string.IsNullOrEmpty(timKiem) ||
                        nv.HoTen.ToLower().Contains(timKiem) ||
                        nv.SDT.ToLower().Contains(timKiem) ||
                        nv.MaSo.ToString().Contains(timKiem)))
                    {
                        AddRowToDataGridView(nv.MaSo, nv.HoTen, nv.ChucVu, nv.CCCD, nv.NgaySinh, nv.GioiTinh, nv.DiaChi, nv.SDT, userDictionary, nv.MaUser);
                    }
                }

                foreach (var bs in dsbs)
                {
                    // Kiểm tra bác sĩ có thỏa mãn điều kiện tìm kiếm hay không
                    if ((roles.Contains("Tất cả") || roles.Contains("Bác sĩ")) &&
                        (string.IsNullOrEmpty(timKiem) ||
                        bs.HoTen.ToLower().Contains(timKiem) ||
                        bs.SDT.ToLower().Contains(timKiem) ||
                        bs.MaSo.ToString().Contains(timKiem)))
                    {
                        AddRowToDataGridView(bs.MaSo, bs.HoTen, "Bác sĩ", bs.CCCD, bs.NgaySinh, bs.GioiTinh, bs.DiaChi, bs.SDT, userDictionary, bs.MaUser);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddRowToDataGridView(long ma, string hoTen, string chucVu, long cccd, DateTime ngaySinh, string gioiTinh, string diaChi, string sdt, Dictionary<long, bool> userDictionary, long maUser)
        {
            // Tạo một hàng mới cho DataGridView
            int rowIndex = dataGridView1.Rows.Add();
            // Gán dữ liệu cho các cột
            DataGridViewRow row = dataGridView1.Rows[rowIndex];

            row.Cells["Column1"].Value = ma;
            row.Cells["Column2"].Value = hoTen;
            row.Cells["Column3"].Value = chucVu;
            row.Cells["Column9"].Value = cccd;
            row.Cells["Column4"].Value = ngaySinh.ToString("dd/MM/yyyy");
            row.Cells["Column5"].Value = gioiTinh;
            row.Cells["Column6"].Value = diaChi;
            row.Cells["Column7"].Value = sdt;
            row.Cells["Column10"].Value = maUser;


            // Lấy trạng thái tài khoản từ Dictionary
            if (userDictionary.TryGetValue(maUser, out bool trangThai))
            {
                row.Cells["Column8"].Value = trangThai ? "Hoạt động" : "Bị khóa";
            }
            else
            {
                row.Cells["Column8"].Value = "Không có thông tin";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NhanVien_Add addNhanVien = new NhanVien_Add(this);
            addNhanVien.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra để chắc chắn click vào một hàng hợp lệ
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0 || selectedRowIndex >= dataGridView1.Rows.Count)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy thông tin từ hàng đã chọn
            var row = dataGridView1.Rows[selectedRowIndex];
            string maNV = row.Cells["Column1"].Value.ToString();
            string hoTen = row.Cells["Column2"].Value.ToString();
            string chucVu = row.Cells["Column3"].Value.ToString();
            string cccd = row.Cells["Column9"].Value.ToString();
            DateTime ngaySinh = DateTime.ParseExact(row.Cells["Column4"].Value.ToString(), "dd/MM/yyyy", null);
            string gioiTinh = row.Cells["Column5"].Value.ToString();
            string diaChi = row.Cells["Column6"].Value.ToString();
            string sdt = row.Cells["Column7"].Value.ToString();
            long maUser = Convert.ToInt64(row.Cells["Column10"].Value);

            // Mở form EditNhanVien và truyền dữ liệu sang
            NhanVien_Edit editForm = new NhanVien_Edit();
            editForm.SetData(chucVu, maUser);
            editForm.LoadData(maNV, hoTen, cccd, sdt, diaChi, ngaySinh, chucVu, gioiTinh);
            editForm.ShowDialog();
            // Tải lại dữ liệu sau khi chỉnh sửa
            LoadDataWithRoles();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0 || selectedRowIndex >= dataGridView1.Rows.Count)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên hoặc bác sĩ để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DeleteNhanVien();
            }
        }

        public void DeleteNhanVien()
        {
            // Lấy thông tin từ hàng được chọn
            var row = dataGridView1.Rows[selectedRowIndex];
            long ma = long.Parse(row.Cells["Column1"].Value.ToString());
            string chucVu = row.Cells["Column3"].Value.ToString();
            string hoTen = row.Cells["Column2"].Value.ToString();

            // Hiển thị xác nhận xóa
            var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa {chucVu} {hoTen} không?",
                                                "Xác nhận xóa",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                if (chucVu == "Bác sĩ")
                {
                    if (bsBLL.DeleteBacSi(ma))
                    {
                        MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (nvBLL.DeleteNhanVien(ma))
                    {
                        MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            LoadDataWithRoles();
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0 || selectedRowIndex >= dataGridView1.Rows.Count)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên hoặc bác sĩ để khóa trạng thái.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dataGridView1.Rows[selectedRowIndex];
            long ma = long.Parse(row.Cells["Column1"].Value.ToString());

            if (userBLL.LockAccount(ma))
            {
                MessageBox.Show("Khóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataWithRoles();
            }
            else
            {
                MessageBox.Show("Khóa thất bại!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            // Kiểm tra chỉ mục dòng được chọn
            if (selectedRowIndex < 0 || selectedRowIndex >= dataGridView1.Rows.Count - (dataGridView1.AllowUserToAddRows ? 1 : 0))
            {
                MessageBox.Show("Vui lòng chọn một nhân viên hoặc bác sĩ để mở khóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dataGridView1.Rows[selectedRowIndex];
            long ma = long.Parse(row.Cells["Column1"].Value.ToString());

            if (userBLL.ActivateAccount(ma))
            {
                MessageBox.Show("Mở khóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataWithRoles();
            }
            else
            {
                MessageBox.Show("Mở khóa thất bại!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.ToLower();

            LoadDataWithRoles(searchText);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy đường dẫn gốc của dự án
                string projectRootPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;

                // Tạo đường dẫn thư mục "Excel/Nhân viên"
                string folderPath = Path.Combine(projectRootPath, "Excel", "Nhân viên");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath); // Tạo thư mục nếu chưa tồn tại
                }

                // Đường dẫn đầy đủ để lưu file
                string fileName = $"Danh sách nhân viên {DateTime.Now:yyyy-MM-dd_HH-mm-ss}.xlsx";
                string filePath = Path.Combine(folderPath, fileName);

                // Tạo Workbook
                using (var workbook = new ClosedXML.Excel.XLWorkbook())
                {
                    // Tạo Worksheet
                    var worksheet = workbook.Worksheets.Add("Danh sách nhân viên");

                    // Loại bỏ cột "Mã nhân viên" và cột cuối
                    string excludedColumnName = "Mã NV";  // Tên cột cần loại bỏ
                    List<int> excludedColumnIndexes = new List<int>();

                    // Tìm các cột cần loại bỏ theo tiêu đề
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        if (dataGridView1.Columns[i].HeaderText == excludedColumnName)
                        {
                            excludedColumnIndexes.Add(i);
                        }
                    }

                    // Loại bỏ cột cuối cùng
                    excludedColumnIndexes.Add(dataGridView1.Columns.Count - 1);

                    // Thêm tiêu đề cột vào hàng đầu tiên (bỏ cột "Mã nhân viên", cột cuối và thêm "STT")
                    worksheet.Cell(1, 1).Value = "STT"; // Cột STT
                    int columnIndexInExcel = 2; // Cột bắt đầu từ Excel
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        // Kiểm tra nếu cột không bị loại bỏ
                        if (!excludedColumnIndexes.Contains(i))
                        {
                            // Thêm tiêu đề cột vào dòng đầu tiên
                            worksheet.Cell(1, columnIndexInExcel).Value = dataGridView1.Columns[i].HeaderText;
                            columnIndexInExcel++;
                        }
                    }

                    // Thêm dữ liệu vào từ DataGridView (bỏ cột "Mã nhân viên", cột "Trạng thái" và cột cuối cùng, và thêm "STT")
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        columnIndexInExcel = 2;
                        worksheet.Cell(i + 2, 1).Value = i + 1; // Thêm số thứ tự vào cột "STT"
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (!excludedColumnIndexes.Contains(j))
                            {
                                worksheet.Cell(i + 2, columnIndexInExcel).Value = dataGridView1.Rows[i].Cells[j].Value?.ToString();
                                columnIndexInExcel++;
                            }
                        }
                    }

                    // Định dạng tự động kích thước cột
                    worksheet.Columns().AdjustToContents();

                    // Lưu file
                    workbook.SaveAs(filePath);
                    MessageBox.Show($"Xuất dữ liệu thành công!\nFile đã được lưu tại: {filePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool AddNhanVien(User user, string hoTen, string chucvu, long cccd, string gioiTinh, DateTime ngaySinh, string diaChi, string sdt)
        {
            NhanVien nv = new NhanVien
            {
                HoTen = hoTen,
                ChucVu = chucvu,
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
                MaKhoa = khoaBLL.GetMaKhoaByName(khoa),
                MaUser = user.MaUser
            };

            return bsBLL.AddBacSi(bs);
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
