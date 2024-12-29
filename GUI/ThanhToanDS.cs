using QLPhongMachTu_DOAN_.DTO;
using QLPhongMachTu_DOAN_.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class ThanhToanDS : UserControl
    {
        private HoaDonThuocBLL hoaDonThuocBLL = new HoaDonThuocBLL();
        private HoaDonKhamBenhBLL hoaDonKhamBenhBLL = new HoaDonKhamBenhBLL();
        private ToaThuocBLL toaThuocBLL = new ToaThuocBLL();
        private PhieuKhamBLL phieuKhamBLL = new PhieuKhamBLL();
        private string selectedMaHD;
        private int selectedTrangThai;

        public ThanhToanDS()
        {
            InitializeComponent();
            LoadData();

            // Tìm kiếm Combobox
            // =================
            // Search by...
            cbTimKiem.Items.Add("Mã đơn thuốc");
            cbTimKiem.Items.Add("Mã toa thuốc");
            // Trạng thái
            cbTrangThai.Items.Add("Chưa thanh toán");
            cbTrangThai.Items.Add("Đã thanh toán");
            cbTrangThai.Items.Add("Cả hai");
            cbTrangThai.SelectedIndex = 2;
            // Ngay Tao
            dateTimePicker_NgayTao.Checked = false;
        }

        public void LoadData()
        {
            List<DTO.HoaDonThuoc> DSHoaDonThuoc = new List<DTO.HoaDonThuoc>();
            //List<DTO.ToaThuoc> DSToaThuoc = toaThuocBLL.GetByMaBN(MaBN);
            List<ToaThuocDTO> DSToaThuoc = toaThuocBLL.GetAll();
            foreach (var toaThuoc in DSToaThuoc)
            {
                List<DTO.HoaDonThuoc> dsHoaDonThuoc = hoaDonThuocBLL.GetByMaTT(toaThuoc.MaTT);
                DSHoaDonThuoc.AddRange(dsHoaDonThuoc);
            }

            int index = 1;
            foreach (var hoaDon in DSHoaDonThuoc)
            {
                AddRowToDataGridView(hoaDon, index);
                ++index;
            }
        }

        public void AddRowToDataGridView(DTO.HoaDonThuoc hoaDon, int index)
        {
            int rowIndex = dgvHoaDon.Rows.Add();

            dgvHoaDon.Rows[rowIndex].Cells["MaDT"].Value = hoaDon.MaDT.ToString();
            dgvHoaDon.Rows[rowIndex].Cells["NgayTao"].Value = hoaDon.NgayMua.ToString("dd/MM/yyyy");
            dgvHoaDon.Rows[rowIndex].Cells["LoaiHD"].Value = "Hóa đơn thuốc";
            dgvHoaDon.Rows[rowIndex].Cells["MaTT"].Value = toaThuocBLL.GetByMaTT(hoaDon.MaTT).MaPK.ToString();
            dgvHoaDon.Rows[rowIndex].Cells["TongTien"].Value = hoaDon.TongTien.ToString();
            dgvHoaDon.Rows[rowIndex].Cells["TrangThai"].Value = hoaDon.TrangThai;
        }

        private void btnTimKiemTT_Click(object sender, EventArgs e)
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

            List<DTO.HoaDonThuoc> hoaDonThuocResult = new List<DTO.HoaDonThuoc>();
            hoaDonThuocResult = hoaDonThuocBLL.TimKiemThanhToan(searchStr, selectedSearchTerm, selectedTrangThai, ngayTao);

            if (hoaDonThuocResult.Any())
            {
                dgvHoaDon.Rows.Clear();
                int index = 1;
                foreach (var hoaDon in hoaDonThuocResult)
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

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaHD))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn trước khi thanh toán.");
                return;
            }
            if (selectedTrangThai == 1)
            {
                MessageBox.Show("Hóa đơn này đã được thanh toán.");
                return;
            }
            else if (selectedTrangThai == -1)
            {
                Console.WriteLine("Trạng thái dgv lỗi.");
                return;
            }

            long selectedMaHDKB = Convert.ToInt64(selectedMaHD);
            bool success = hoaDonThuocBLL.SetThanhToan(selectedMaHDKB, "Đã thanh toán");
            if (success)
                MessageBox.Show("Thanh toán hóa đơn thành công!");
            else
                MessageBox.Show("Thanh toán hóa đơn không thành công.");

            selectedMaHD = string.Empty;
            dgvHoaDon.Rows.Clear();
            LoadData();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaHD))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn trước khi xem chi tiết.");
                return;
            }

            long MaDT = Convert.ToInt64(selectedMaHD);
            DTO.HoaDonThuoc hoaDonThuoc = hoaDonThuocBLL.GetByMaDT(MaDT);
            ToaThuocDTO toaThuoc = toaThuocBLL.GetByMaTT(hoaDonThuoc.MaTT);

            try
            {
                using (HoaDonThuocGUI hoaDonThuocForm = new HoaDonThuocGUI(toaThuoc.MaBN, hoaDonThuoc))
                {
                    hoaDonThuocForm.Owner = this.FindForm();
                    hoaDonThuocForm.StartPosition = FormStartPosition.CenterParent;
                    hoaDonThuocForm.ShowDialog();
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
                var cellValue = dgvHoaDon.Rows[e.RowIndex].Cells["MaDT"].Value;
                selectedMaHD = cellValue?.ToString() ?? string.Empty;

                cellValue = dgvHoaDon.Rows[e.RowIndex].Cells["TrangThai"].Value;
                if (cellValue != null)
                {
                    string trangThaiStr = cellValue.ToString().Trim();
                    selectedTrangThai = string.Equals(trangThaiStr, "Đã thanh toán", StringComparison.OrdinalIgnoreCase) ? 1 : 0;
                }
                else
                {
                    selectedTrangThai = -1;
                }
            }
        }

        private void btn_XoaTimKiem_Click(object sender, EventArgs e)
        {
            tbTimKiem.Text = "";
            // Search by...
            cbTimKiem.SelectedIndex = -1;
            // Trạng thái
            cbTrangThai.SelectedIndex = 2;
            // Ngay Tao
            dateTimePicker_NgayTao.Value = DateTime.Now;
            dateTimePicker_NgayTao.Checked = false;
        }
    }
}
