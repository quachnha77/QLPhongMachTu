using QLPhongMachTu_DOAN_.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class NhanVienGUI : UserControl
    {
        private NhanVienBLL nvBLL = new NhanVienBLL();
        private UserBLL userBLL = new UserBLL();
        private BacSiBLL bsBLL = new BacSiBLL();
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
                        AddRowToDataGridView(nv.MaNV, nv.HoTen, nv.ChucVu, nv.CCCD, nv.NgaySinh, nv.GioiTinh, nv.DiaChi, nv.SDT, userDictionary, nv.MaUser);
                    }
                }

                foreach (var bs in dsbs)
                {
                    if (roles.Contains("Tất cả") || roles.Contains("Bác sĩ"))
                    {
                        AddRowToDataGridView(bs.MaBS, bs.HoTen, "Bác sĩ", bs.CCCD, bs.NgaySinh, bs.GioiTinh, bs.DiaChi, bs.SDT, userDictionary, bs.MaUser);
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
            AddNhanVien addNhanVien = new AddNhanVien(this);
            addNhanVien.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //EditNhanVien 
        }
    }
}
