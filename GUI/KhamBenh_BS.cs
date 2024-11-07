using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class KhamBenh_BS : UserControl
    {
        private LichKhamBLL lichKhamBLL;
        private BenhNhanBLL benhNhanBLL;
        private PhieuKhamBLL phieuKhamBLL;

        public KhamBenh_BS()
        {
            InitializeComponent();

            lichKhamBLL = new LichKhamBLL(); 
            benhNhanBLL = new BenhNhanBLL();
            phieuKhamBLL = new PhieuKhamBLL();

            //// Tắt AutoGenerateColumns nếu bạn đã định nghĩa cột trong DataGridView
            tableDanhSachKhamBenh.AutoGenerateColumns = false;
            tableDanhSachKhamBenh.AutoGenerateColumns = false;

            //// Ánh xạ cột trong DataGridView BenhNhan
            tableDanhSachKhamBenh.Columns["MaLK"].DataPropertyName = "MaLK";
            tableDanhSachKhamBenh.Columns["MaBN"].DataPropertyName = "MaBN";
            tableDanhSachKhamBenh.Columns["CCCD"].DataPropertyName = "CCCD";
            tableDanhSachKhamBenh.Columns["HoTen"].DataPropertyName = "HoTen";
            tableDanhSachKhamBenh.Columns["NgaySinh"].DataPropertyName = "NgaySinh";
            tableDanhSachKhamBenh.Columns["GioiTinh"].DataPropertyName = "GioiTinh";
            tableDanhSachKhamBenh.Columns["DiaChi"].DataPropertyName = "DiaChi";
            tableDanhSachKhamBenh.Columns["SDT"].DataPropertyName = "SDT";

            //// Ánh xạ cột trong DataGridView LichKham
            tableDanhSachKhamBenh.Columns["NgayKham"].DataPropertyName = "NgayKham";
            tableDanhSachKhamBenh.Columns["TrangThai"].DataPropertyName = "TrangThai";

            rbTatCa.Checked = true;

            LoadDataToGrid();
        }

        private void LoadDataToGrid()
        {
            // Lấy tất cả lịch khám và bệnh nhân từ BLL
            List<LichKham> danhSachLichKham = lichKhamBLL.GetAll();
            List<BenhNhan> danhSachBenhNhan = benhNhanBLL.GetAll();

            // Kiểm tra nếu CheckBox lọc theo ngày được chọn
            if (cbLocTheoNgay.Checked)
            {
                // Lấy ngày từ DateTimePicker
                DateTime selectedDate = dateTimePicker.Value.Date;

                // Lọc danh sách dựa trên ngày khám
                danhSachLichKham = danhSachLichKham
                    .Where(lk => lk.NgayKham.Date == selectedDate)
                    .ToList();
            }

            // Lọc danh sách lịch khám dựa trên trạng thái từ RadioButton
            if (rbChuaKham.Checked)
            {
                danhSachLichKham = danhSachLichKham
                    .Where(lk => lk.TrangThai == LichKham.TrangThaiKham.ChuaKham)
                    .ToList();
            }
            else if (rbDaKham.Checked)
            {
                danhSachLichKham = danhSachLichKham
                    .Where(lk => lk.TrangThai == LichKham.TrangThaiKham.DaKham)
                    .ToList();
            }
            // Nếu rbTatCa.Checked thì giữ nguyên danh sách mà không lọc theo trạng thái

            // Tạo mới DataTable và thêm các cột cần thiết
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MaLK", typeof(long));
            dataTable.Columns.Add("MaBN", typeof(long));
            dataTable.Columns.Add("CCCD", typeof(long));
            dataTable.Columns.Add("HoTen", typeof(string));
            dataTable.Columns.Add("NgaySinh", typeof(DateTime));
            dataTable.Columns.Add("GioiTinh", typeof(string));
            dataTable.Columns.Add("DiaChi", typeof(string));
            dataTable.Columns.Add("SDT", typeof(string));
            dataTable.Columns.Add("NgayKham", typeof(DateTime));
            dataTable.Columns.Add("TrangThai", typeof(string));

            // Kết hợp dữ liệu từ danh sách LichKham và BenhNhan
            foreach (var lichKham in danhSachLichKham)
            {
                var benhNhan = danhSachBenhNhan.FirstOrDefault(bn => bn.MaSo == lichKham.MaBN);
                if (benhNhan != null)
                {
                    // Tạo hàng mới và gán dữ liệu
                    DataRow row = dataTable.NewRow();
                    row["MaLK"] = lichKham.MaLK;
                    row["MaBN"] = benhNhan.MaSo;
                    row["CCCD"] = benhNhan.CCCD;
                    row["HoTen"] = benhNhan.HoTen;
                    row["NgaySinh"] = benhNhan.NgaySinh;
                    row["GioiTinh"] = benhNhan.GioiTinh;
                    row["DiaChi"] = benhNhan.DiaChi;
                    row["SDT"] = benhNhan.SDT;
                    row["NgayKham"] = lichKham.NgayKham;
                    row["TrangThai"] = trangThaiKhamBenh(lichKham.TrangThai.ToString()); // Chuyển trạng thái sang chuỗi
                    dataTable.Rows.Add(row);
                }
            }

            // Gán DataTable vào DataGridView
            tableDanhSachKhamBenh.DataSource = dataTable;
        }


        private void CapNhatBang() { 
        }

        private string trangThaiKhamBenh(string lk)
        {
            if (lk == "DaKham")
            {
                return "Đã khám";
            }
            else if (lk == "ChuaKham")
            {
                return "Chưa khám";
            }
            else if (lk == "HuyKham")
            {
                return "Hủy khám";
            }
            else
            {
                return "Không xác định"; // Giá trị mặc định nếu không khớp với bất kỳ điều kiện nào
            }
        }

        private void rb_Click(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        private void tableDanhSachKhamBenh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            KhiClickVaoMotDong(e);
        }

        private void KhiClickVaoMotDong(DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem dòng được chọn có hợp lệ không (tránh lỗi khi click vào tiêu đề cột)
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = tableDanhSachKhamBenh.Rows[e.RowIndex];

                // Gán dữ liệu từ các ô trong dòng vào các TextBox tương ứng
                txtMaBN.Text = selectedRow.Cells["MaBN"].Value?.ToString();
                txtCCCD.Text = selectedRow.Cells["CCCD"].Value?.ToString();
                txtHoTen.Text = selectedRow.Cells["HoTen"].Value?.ToString();
                txtNgaySinh.Text = selectedRow.Cells["NgaySinh"].Value?.ToString();
                txtGioiTinh.Text = selectedRow.Cells["GioiTinh"].Value?.ToString();
                txtDiaChi.Text = selectedRow.Cells["DiaChi"].Value?.ToString();
                txtSoDienThoai.Text = selectedRow.Cells["SDT"].Value?.ToString();

                long maLK;
                if (long.TryParse(selectedRow.Cells["MaLK"].Value?.ToString(), out maLK))
                {
                    // Gọi phương thức GetByMaLK từ PhieuKhamBLL
                    PhieuKham phieuKham = phieuKhamBLL.GetByMaLK(maLK);
                    if (phieuKham != null)
                    {
                        txtSTT.Text = phieuKham.SoThuTu.ToString();
                        txtMaPK.Text = phieuKham.MaPK.ToString();
                        txtNgayKham.Text = phieuKham.NgayKham.ToString();
                        txtTrieuChung.Text = phieuKham.TrieuChung;
                        txtTienSuBenhLy.Text = phieuKham.TieuSuBenhLy;
                        txtChuanDoan.Text = phieuKham.ChuanDoan;
                    }
                }
            }
        }

        private void KhamBenh_BS_Load(object sender, EventArgs e)
        {

        }

        private void KeToaThuoc_Click(object sender, EventArgs e)
        {
            ToaThuoc toaThuocFrom = new ToaThuoc();
            toaThuocFrom.StartPosition = FormStartPosition.CenterScreen;
            toaThuocFrom.Show();
        }

        private void KhamBenh_Click(object sender, EventArgs e)
        {

        }

        private void HoaDonKhamBenh_Click(object sender, EventArgs e)
        {
            HoaDonKhamBenh hoaDonKBFrom = new HoaDonKhamBenh();
            hoaDonKBFrom.StartPosition = FormStartPosition.CenterScreen;
            hoaDonKBFrom.Show();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            LocTheoNgay();
        }

        private void txtTimTheoMaBN_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbLocTheoNgay_CheckedChanged(object sender, EventArgs e)
        {
            LocTheoNgay();
        }

        private void LocTheoNgay()
        {
            // Lấy danh sách lịch khám từ BLL
            List<LichKham> danhSachLichKham = lichKhamBLL.GetAll();

            // Kiểm tra nếu CheckBox lọc theo ngày được chọn
            if (cbLocTheoNgay.Checked)
            {
                // Lấy ngày từ DateTimePicker
                DateTime selectedDate = dateTimePicker.Value.Date;

                // Lọc danh sách dựa trên ngày khám
                danhSachLichKham = danhSachLichKham
                    .Where(lk => lk.NgayKham.Date == selectedDate)
                    .ToList();
            }

            // Lọc theo trạng thái dựa trên các RadioButton
            if (rbDaKham.Checked)
            {
                danhSachLichKham = danhSachLichKham
                    .Where(lk => lk.TrangThai == LichKham.TrangThaiKham.DaKham)
                    .ToList();
            }
            else if (rbChuaKham.Checked)
            {
                danhSachLichKham = danhSachLichKham
                    .Where(lk => lk.TrangThai == LichKham.TrangThaiKham.ChuaKham)
                    .ToList();
            }
            // Nếu rbTatCa.Checked thì không cần lọc theo trạng thái

            // Tạo mới DataTable và thêm các cột cần thiết
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MaLK", typeof(long));
            dataTable.Columns.Add("MaBN", typeof(long));
            dataTable.Columns.Add("CCCD", typeof(long));
            dataTable.Columns.Add("HoTen", typeof(string));
            dataTable.Columns.Add("NgaySinh", typeof(DateTime));
            dataTable.Columns.Add("GioiTinh", typeof(string));
            dataTable.Columns.Add("DiaChi", typeof(string));
            dataTable.Columns.Add("SDT", typeof(string));
            dataTable.Columns.Add("NgayKham", typeof(DateTime));
            dataTable.Columns.Add("TrangThai", typeof(string));

            // Giả sử bạn đã có danh sách bệnh nhân để tham chiếu
            List<BenhNhan> danhSachBenhNhan = benhNhanBLL.GetAll();

            // Kết hợp dữ liệu từ danh sách LichKham và BenhNhan
            foreach (var lichKham in danhSachLichKham)
            {
                var benhNhan = danhSachBenhNhan.FirstOrDefault(bn => bn.MaSo == lichKham.MaBN);
                if (benhNhan != null)
                {
                    // Tạo hàng mới và gán dữ liệu
                    DataRow row = dataTable.NewRow();
                    row["MaLK"] = lichKham.MaLK;
                    row["MaBN"] = benhNhan.MaSo;
                    row["CCCD"] = benhNhan.CCCD;
                    row["HoTen"] = benhNhan.HoTen;
                    row["NgaySinh"] = benhNhan.NgaySinh;
                    row["GioiTinh"] = benhNhan.GioiTinh;
                    row["DiaChi"] = benhNhan.DiaChi;
                    row["SDT"] = benhNhan.SDT;
                    row["NgayKham"] = lichKham.NgayKham;
                    row["TrangThai"] = trangThaiKhamBenh(lichKham.TrangThai.ToString()); // Chuyển trạng thái sang chuỗi
                    dataTable.Rows.Add(row);
                }
            }

            // Gán DataTable đã định dạng vào DataGridView
            tableDanhSachKhamBenh.DataSource = dataTable;
        }




    }
}
