using QLPhongMachTu_DOAN_.DTO;
using QLPhongMachTu_DOAN_.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class ThanhToan : UserControl
    {
        public HoaDonKhamBenhBLL hoaDonKhamBenhBLL = new HoaDonKhamBenhBLL();
        public ToaThuocBLL toaThuocBLL = new ToaThuocBLL();
        public PhieuKhamBLL phieuKhamBLL = new PhieuKhamBLL();
        private long MaBN;
        private string selectedMaHD;
        private int selectedTrangThai;
        private int controlNumber;

        //public ThanhToan()
        //{
        //    InitializeComponent();
        //}

        public ThanhToan(User user, BenhNhan benhNhan, int controlNumber)
        {
            InitializeComponent();
            this.MaBN = benhNhan.MaSo;
            this.controlNumber = controlNumber;
            LoadData();

            // Tìm kiếm 
            // ---------
            // Search by...
            cbTimKiem.Items.Add("Mã hóa đơn");
            cbTimKiem.Items.Add("Mã phiếu khám");
            // Trạng thái
            // SỬA
            cbTrangThai.Items.Add("Chờ xử lý");
            cbTrangThai.Items.Add("Chưa thanh toán");
            cbTrangThai.Items.Add("Đã thanh toán");
            cbTrangThai.Items.Add("Tất cả");
            cbTrangThai.SelectedIndex = 3;
            // Ngay Tao
            dateTimePicker_NgayTao.Checked = false;
        }

        public void LoadData()
        {
            List<HoaDonKhamBenhDTO> DSHoaDonKhamBenh = new List<HoaDonKhamBenhDTO>();
            if(controlNumber == 1)
            {
                DSHoaDonKhamBenh = hoaDonKhamBenhBLL.GetAll();
            }
            else
            {
                DSHoaDonKhamBenh = hoaDonKhamBenhBLL.GetByMaBN(MaBN);
            }

            int index = 1;
            foreach (var hoaDon in DSHoaDonKhamBenh)
            {
                AddRowToDataGridView(hoaDon, index);
                ++index;
            }
            if (DSHoaDonKhamBenh.Count <= 0)
            {
                MessageBox.Show("Chưa có hóa đơn nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        public void AddRowToDataGridView(HoaDonKhamBenhDTO hoaDon, int index)
        {
            int rowIndex = dgvHoaDon.Rows.Add();

            dgvHoaDon.Rows[rowIndex].Cells["MaHD"].Value = hoaDon.MaHDKB.ToString();
            // Lấy đại ngày khám
            // SỬA
            dgvHoaDon.Rows[rowIndex].Cells["NgayTao"].Value = hoaDon.NgayThanhToan.ToString("dd/MM/yyyy");
            dgvHoaDon.Rows[rowIndex].Cells["LoaiHD"].Value = "Hóa đơn khám bệnh";
            dgvHoaDon.Rows[rowIndex].Cells["MaPK"].Value = hoaDon.MaPK.ToString();
            dgvHoaDon.Rows[rowIndex].Cells["TongTien"].Value = hoaDon.TongTien.ToString();
            dgvHoaDon.Rows[rowIndex].Cells["TrangThai"].Value = hoaDon.TrangThai;
        }

        private void btnTimKiemTT_Click(object sender, EventArgs e)
        {
            string searchStr = tbTimKiem.Text;
            string selectedSearchTerm = cbTimKiem.SelectedItem != null ? cbTimKiem.SelectedItem.ToString() : string.Empty;
            // 0: Chờ xử lý, 1: Chưa thanh toán, 2: Đã thanh toán, 3: Tất cả (default)
            int selectedTrangThai = cbTrangThai.SelectedIndex;
            // Ngày tạo
            DateTime? ngayTao = dateTimePicker_NgayTao.Checked ? dateTimePicker_NgayTao.Value : (DateTime?)null;

            if (!string.IsNullOrEmpty(selectedSearchTerm) && !string.IsNullOrEmpty(searchStr))
            {
                if (!long.TryParse(searchStr, out long numericValue))
                {
                    MessageBox.Show("Vui lòng nhập chuỗi hóa đơn cần tìm ở dạng số.");
                    return;
                }
            }
            if (string.IsNullOrEmpty(selectedSearchTerm) && !string.IsNullOrEmpty(searchStr))
            {
                MessageBox.Show("Vui lòng chọn hình thức tìm kiếm.");
                return;
            }

            List<HoaDonKhamBenhDTO> hoaDonKhamBenhResult = new List<HoaDonKhamBenhDTO>();
            hoaDonKhamBenhResult = hoaDonKhamBenhBLL.TimKiemThanhToan(MaBN, searchStr, selectedSearchTerm, selectedTrangThai, ngayTao);

            if (hoaDonKhamBenhResult.Any())
            {
                dgvHoaDon.Rows.Clear();
                int index = 1;
                foreach (var hoaDon in hoaDonKhamBenhResult)
                {
                    AddRowToDataGridView(hoaDon, index);
                }
            }
            else
            {
                dgvHoaDon.Rows.Clear();
                MessageBox.Show("Không tồn tại kết quả tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaHD))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn trước khi xem chi tiết.");
                return;
            }

            long MaHDKB = Convert.ToInt64(selectedMaHD);
            HoaDonKhamBenhDTO hoaDonKhamBenh = hoaDonKhamBenhBLL.GetByMaHDKB(MaHDKB);

            try
            {
                using (HoaDonKhamBenh_BN hoaDonKhamBenhForm = new HoaDonKhamBenh_BN(hoaDonKhamBenh))
                {
                    hoaDonKhamBenhForm.Owner = this.FindForm();
                    hoaDonKhamBenhForm.StartPosition = FormStartPosition.CenterParent;
                    hoaDonKhamBenhForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvHoaDon.Rows.Clear();
            LoadData();
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var cellValue = dgvHoaDon.Rows[e.RowIndex].Cells["MaHD"].Value;
                selectedMaHD = cellValue?.ToString() ?? string.Empty; // Ensure it's not null

                cellValue = dgvHoaDon.Rows[e.RowIndex].Cells["TrangThai"].Value;
                if (cellValue != null)
                {
                    string trangThaiStr = cellValue.ToString().Trim();
                    selectedTrangThai = string.Equals(trangThaiStr, "Đã thanh toán", StringComparison.OrdinalIgnoreCase) ? 1 : 0;
                }
                else
                {
                    selectedTrangThai = -1; // Default value if TrangThai is null
                }
            }
        }


        private void btn_XoaTimKiem_Click(object sender, EventArgs e)
        {
            tbTimKiem.Text = "";
            // Search by...
            cbTimKiem.SelectedIndex = -1;
            // Trạng thái
            // SỬA
            cbTrangThai.SelectedIndex = 3;
            // Ngay Tao
            dateTimePicker_NgayTao.Value = DateTime.Now;
            dateTimePicker_NgayTao.Checked = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchStr = tbTimKiem.Text;
            string selectedSearchTerm = cbTimKiem.SelectedItem != null ? cbTimKiem.SelectedItem.ToString() : string.Empty;
            // 0: Chưa thanh toán, 1: Đã thanh toán, 2: Cả hai (default)
            int selectedTrangThai = cbTrangThai.SelectedIndex;
            // Ngày tạo
            DateTime? ngayTao = dateTimePicker_NgayTao.Checked ? dateTimePicker_NgayTao.Value : (DateTime?)null;

            if (!string.IsNullOrEmpty(selectedSearchTerm) && !string.IsNullOrEmpty(searchStr))
            {
                if (!long.TryParse(searchStr, out long numericValue))
                {
                    MessageBox.Show("Vui lòng nhập chuỗi hóa đơn cần tìm ở dạng số.");
                    return;
                }
            }
            if (string.IsNullOrEmpty(selectedSearchTerm) && !string.IsNullOrEmpty(searchStr))
            {
                MessageBox.Show("Vui lòng chọn hình thức tìm kiếm.");
                return;
            }

            List<HoaDonKhamBenhDTO> hoaDonKhamBenhResult = new List<HoaDonKhamBenhDTO>();
            hoaDonKhamBenhResult = hoaDonKhamBenhBLL.TimKiemThanhToan(MaBN, searchStr, selectedSearchTerm, selectedTrangThai, ngayTao);

            if (hoaDonKhamBenhResult.Any())
            {
                dgvHoaDon.Rows.Clear();
                int index = 1;
                foreach (var hoaDon in hoaDonKhamBenhResult)
                {
                    AddRowToDataGridView(hoaDon, index);
                }
            }
            else
            {
                dgvHoaDon.Rows.Clear();
                MessageBox.Show("Không tồn tại kết quả tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_click(object sender, EventArgs e)
        {
            tbTimKiem.Text = "";
            // Search by...
            cbTimKiem.SelectedIndex = -1;
            // Trạng thái
            // SỬA
            cbTrangThai.SelectedIndex = 3;
            // Ngay Tao
            dateTimePicker_NgayTao.Value = DateTime.Now;
            dateTimePicker_NgayTao.Checked = false;
        }
    }
}
