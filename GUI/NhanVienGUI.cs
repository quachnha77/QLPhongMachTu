using QLPhongMachTu_DOAN_.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class NhanVienGUI : UserControl
    {
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

        public void LoadDataWithRoles()
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
            LoadData(selectedRoles);
        }

        public void LoadData(List<string> roles)
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
                    if (roles.Contains("Tất cả") || roles.Contains(nv.ChucVu))
                    {
                        AddRowToDataGridView(nv.MaSo, nv.HoTen, nv.ChucVu, nv.CCCD, nv.NgaySinh, nv.GioiTinh, nv.DiaChi, nv.SDT, userDictionary, nv.MaUser);
                    }
                }

                foreach (var bs in dsbs)
                {
                    if (roles.Contains("Tất cả") || roles.Contains("Bác sĩ"))
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
    }
}
