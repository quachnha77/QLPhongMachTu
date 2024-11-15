using QLPhongMachTu_DOAN_.DTO;
using QLPhongMachTu_DOAN_.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLPhongMachTu_DOAN_.DAL;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class ThanhToan : UserControl
    {
        public HoaDonKhamBenhBLL hoaDonKhamBenhBLL = new HoaDonKhamBenhBLL();
        public HoaDonThuocBLL hoaDonThuocBLL = new HoaDonThuocBLL();
        public ToaThuocBLL toaThuocBLL = new ToaThuocBLL();
        public PhieuKhamBLL phieuKhamBLL = new PhieuKhamBLL();
        private long MaBN;

        public ThanhToan()
        {
            InitializeComponent();
            LoadData();
        }

        public ThanhToan(User user, BenhNhan benhNhan)
        {
            InitializeComponent();
            MaBN = benhNhan.MaBN;
        }

        public void LoadData()
        {
            // DataGridView
            List<DTO.HoaDonKhamBenh> DSHoaDonKhamBenh = hoaDonKhamBenhBLL.GetByMaBN(MaBN);

            int index = 1;
            foreach (var hoaDon in DSHoaDonKhamBenh)
            {
                AddRowToDataGridView(hoaDon, index);
                ++index;
            }

            List<DTO.HoaDonThuoc> DSHoaDonThuoc = new List<DTO.HoaDonThuoc>();
            List<DTO.ToaThuoc> DSToaThuoc = toaThuocBLL.GetByMaBN(MaBN);
            foreach(var toaThuoc in DSToaThuoc)
            {
                List<DTO.HoaDonThuoc> dsHoaDonThuoc = hoaDonThuocBLL.GetByMaTT(toaThuoc.MaTT);
                DSHoaDonThuoc.AddRange(dsHoaDonThuoc);
            }

            index = 1;
            foreach (var hoaDon in DSHoaDonThuoc)
            {
                AddRowToDataGridView(hoaDon, index);
                ++index;
            }

            // Tìm kiếm Combobox
            // =================
            // Search by...
            cbTimKiem.Items.Add("Mã hóa đơn");
            cbTimKiem.Items.Add("Mã phiếu khám");
            // Trạng thái
            cbTrangThai.Items.Add("Đã thanh toán");
            cbTrangThai.Items.Add("Chưa thanh toán");
            cbTrangThai.Items.Add("Cả hai");
            cbTrangThai.SelectedIndex = 2;
            // Loại hóa đơn
            cbLoaiHoaDon.Items.Add("Hóa đơn khám bệnh");
            cbLoaiHoaDon.Items.Add("Hóa đơn thuốc");
            cbLoaiHoaDon.Items.Add("Cả hai");
            cbLoaiHoaDon.SelectedIndex = 2;
        }

        public void AddRowToDataGridView(DTO.HoaDonKhamBenh hoaDon, int index)
        {
            int rowIndex = dgvHoaDon.Rows.Add();

            dgvHoaDon.Rows[rowIndex].Cells["MaHD"].Value = hoaDon.MaHDKB.ToString();
            // Lấy đại ngày khám
            dgvHoaDon.Rows[rowIndex].Cells["NgayTao"].Value = phieuKhamBLL.GetByMaPK(hoaDon.MaPK).NgayKham.ToString("dd/MM/yyyy");
            dgvHoaDon.Rows[rowIndex].Cells["LoaiHD"].Value = "Hóa đơn khám bệnh";
            dgvHoaDon.Rows[rowIndex].Cells["MaPK"].Value = hoaDon.MaPK.ToString();
            dgvHoaDon.Rows[rowIndex].Cells["TongTien"].Value = hoaDon.TongTien.ToString("N0");
            dgvHoaDon.Rows[rowIndex].Cells["TrangThai"].Value = (hoaDon.TrangThai == true) ? "Đã thanh toán" : "Chưa Thanh Toán";
        }
        public void AddRowToDataGridView(DTO.HoaDonThuoc hoaDon, int index)
        {
            int rowIndex = dgvHoaDon.Rows.Add();

            dgvHoaDon.Rows[rowIndex].Cells["MaHD"].Value = hoaDon.MaDT.ToString();
            dgvHoaDon.Rows[rowIndex].Cells["NgayTao"].Value = hoaDon.NgayMua.ToString("dd/MM/yyyy");
            dgvHoaDon.Rows[rowIndex].Cells["LoaiHD"].Value = "Hóa đơn thuốc";
            dgvHoaDon.Rows[rowIndex].Cells["MaPK"].Value = toaThuocBLL.GetByMaTT(hoaDon.MaTT).MaPK.ToString();
            dgvHoaDon.Rows[rowIndex].Cells["TongTien"].Value = hoaDon.TongTien.ToString("N0");
            dgvHoaDon.Rows[rowIndex].Cells["TrangThai"].Value = (hoaDon.TrangThai == true) ? "Đã thanh toán" : "Chưa Thanh Toán";
        }

        private void btnTimKiemTT_Click(object sender, EventArgs e)
        {
            string searchStr = tbTimKiem.Text;
            // 0: Mã hóa đơn, 1: Mã phiếu khám
            int selectedSearchTerm = cbTimKiem.SelectedIndex;
            // 0: Đã thanh toán, 1: Chưa thanh toán, 2: Cả hai (default)
            int selectedTrangThai = cbTrangThai.SelectedIndex;
            // 0: Hóa đơn khám bệnh, 1: Hóa đơn thuốc, 2: Cả hai (default)
            int selectedLoaiHD = cbLoaiHoaDon.SelectedIndex;
            // Ngày tạo
            DateTime? ngayTao = dateTimePicker_NgayTao.Checked ? dateTimePicker_NgayTao.Value : (DateTime?)null;

            List<DTO.HoaDonKhamBenh> hoaDonKhamBenhResult = new List<DTO.HoaDonKhamBenh>();
            List<DTO.HoaDonThuoc> hoaDonThuocResult = new List<DTO.HoaDonThuoc>();
            if (selectedLoaiHD == 0 || selectedLoaiHD == 2) 
            {
                hoaDonKhamBenhResult = hoaDonKhamBenhBLL.TimKiemHoaDon(MaBN, selectedSearchTerm, searchStr, selectedTrangThai, ngayTao);
            }

            if (selectedLoaiHD == 1 || selectedLoaiHD == 2) 
            {
                hoaDonThuocResult = hoaDonThuocBLL.TimKiemHoaDon(MaBN, selectedSearchTerm, searchStr, selectedTrangThai, ngayTao);
            }

            // Cập nhật DataGridView
            List<object> results = new List<object>();
            if (hoaDonKhamBenhResult.Any())
            {
                results.AddRange(hoaDonKhamBenhResult);
            }
            else if (hoaDonThuocResult.Any())
            {
                results.AddRange(hoaDonThuocResult);
            }
            
            if(results.Any())
            {
                dgvHoaDon.DataSource = results;
            }    
            else
            {
                MessageBox.Show("Không có kết quả tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dateTimePicker_NgayTao_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
