using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using QLPhongMachTu_DOAN_.Enums;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class KhamBenh_BS : UserControl
    {
        private LichKhamBLL lichKhamBLL;
        private BenhNhanBLL benhNhanBLL;
        private PhieuKhamBLL phieuKhamBLL;
        private PhieuKhamDichVuBLL phieuKhamDVBLL;
        private DichVuBLL dichVuBLL;
        private long maPK;
        private long maBN;
        private long maBS;

        public KhamBenh_BS()
        {
            InitializeComponent();

            lichKhamBLL = new LichKhamBLL();
            benhNhanBLL = new BenhNhanBLL();
            phieuKhamBLL = new PhieuKhamBLL();
            phieuKhamDVBLL = new PhieuKhamDichVuBLL();
            dichVuBLL = new DichVuBLL();

            //// Tắt AutoGenerateColumns nếu bạn đã định nghĩa cột trong DataGridView
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
            List<LichKhamDTO> danhSachLichKham = lichKhamBLL.GetAll();
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
                    .Where(lk => lk.TrangThai == ETrangThaiKham.ChuaKham)
                    .ToList();
            }
            else if (rbDaKham.Checked)
            {
                danhSachLichKham = danhSachLichKham
                    .Where(lk => lk.TrangThai == ETrangThaiKham.DaKham)
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
                        txtLoiDanBacSi.Text = phieuKham.LoiDanBacSi;

                        // Hiển thị các dịch vụ đã sử dụng cho phiếu khám
                        HienThiDichVuDaSuDung(phieuKham.MaPK);

                        maPK = phieuKham.MaPK;
                        maBS = phieuKham.MaBS;
                        maBN = phieuKham.MaBN;
                    }
                }
            }
        }

        private void KhamBenh_BS_Load(object sender, EventArgs e)
        {

        }

        private void XemToaThuoc_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = tableDanhSachKhamBenh.SelectedRows[0];
            long maBN = Convert.ToInt64(selectedRow.Cells["MaBN"].Value);
            long maLK = Convert.ToInt64(selectedRow.Cells["MaLK"].Value);
            XemToaThuocGUI xemtToaThuocForm = new XemToaThuocGUI(maBN, maLK);
            xemtToaThuocForm.StartPosition = FormStartPosition.CenterScreen;
            xemtToaThuocForm.Show();
        }

        private void KeToaThuoc_Click(object sender, EventArgs e)
        {
            // lấy ra mã BN
            DataGridViewRow selectedRow = tableDanhSachKhamBenh.SelectedRows[0];
            long maBN = Convert.ToInt64(selectedRow.Cells["MaBN"].Value);
            // Tạo và hiện thị TT
            KeToaThuocGUI toaThuocForm = new KeToaThuocGUI(maBN);
            toaThuocForm.StartPosition = FormStartPosition.CenterScreen;
            toaThuocForm.Show();
        }

        private void KhamBenh_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem dòng đang chọn có hợp lệ không
            if (tableDanhSachKhamBenh.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = tableDanhSachKhamBenh.SelectedRows[0];

                // Cập nhật trạng thái trong DataGridView mà không lưu vào cơ sở dữ liệu
                selectedRow.Cells["TrangThai"].Value = "Đã khám";

                // Thông báo cho người dùng biết trạng thái đã thay đổi trong bảng
                MessageBox.Show("Trạng thái đã được cập nhật trong bảng. Hãy nhấn 'Lưu thay đổi' để lưu lại trong cơ sở dữ liệu.");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bệnh nhân để cập nhật trạng thái.");
            }
        }

        private void HoaDonKhamBenh_Click(object sender, EventArgs e)
        {
            HoaDonKhamBenh hoaDonKBFrom = new HoaDonKhamBenh(maPK, maBS, maBN);
            hoaDonKBFrom.StartPosition = FormStartPosition.CenterScreen;
            hoaDonKBFrom.Show();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            LocTheoNgay();
        }

        private void txtTimTheoMaBN_TextChanged(object sender, EventArgs e)
        {
            string searchMaBN = txtTimTheoMaBN.Text.Trim();

            // Kiểm tra nếu người dùng chưa nhập gì trong TextBox
            if (string.IsNullOrEmpty(searchMaBN))
            {
                // Nếu không có tìm kiếm, load lại toàn bộ dữ liệu
                LoadDataToGrid();
            }
            else
            {
                // Nếu có nhập mã bệnh nhân, thực hiện lọc
                List<LichKhamDTO> danhSachLichKham = lichKhamBLL.GetAll();
                List<BenhNhan> danhSachBenhNhan = benhNhanBLL.GetAll();

                // Lọc danh sách LichKham theo MaBN của BenhNhan
                danhSachLichKham = danhSachLichKham
                    .Where(lk => danhSachBenhNhan
                                 .Any(bn => bn.MaSo == lk.MaBN && bn.MaSo.ToString().Contains(searchMaBN))
                    )
                    .ToList();

                // Tạo mới DataTable và ánh xạ dữ liệu
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

                // Lấy dữ liệu từ LichKham và BenhNhan và đưa vào DataTable
                foreach (var lichKham in danhSachLichKham)
                {
                    var benhNhan = danhSachBenhNhan.FirstOrDefault(bn => bn.MaSo == lichKham.MaBN);
                    if (benhNhan != null)
                    {
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
                        row["TrangThai"] = trangThaiKhamBenh(lichKham.TrangThai.ToString());
                        dataTable.Rows.Add(row);
                    }
                }

                // Gán lại DataTable vào DataGridView
                tableDanhSachKhamBenh.DataSource = dataTable;
            }
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
            List<LichKhamDTO> danhSachLichKham = lichKhamBLL.GetAll();

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
                    .Where(lk => lk.TrangThai == ETrangThaiKham.DaKham)
                    .ToList();
            }
            else if (rbChuaKham.Checked)
            {
                danhSachLichKham = danhSachLichKham
                    .Where(lk => lk.TrangThai == ETrangThaiKham.ChuaKham)
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

        private void HienThiDichVuDaSuDung(long maPK) // hiển thị Dịch vụ đã dùng
        {
            List<long> danhSachDichVuDaSuDung = phieuKhamDVBLL.GetDichVuByMaPK(maPK);

            // Đánh dấu các CheckBox dựa trên danh sách dịch vụ đã sử dụng
            cbKhamTongQuat.Checked = danhSachDichVuDaSuDung.Contains(1);
            cbKhamChuyenKhoa.Checked = danhSachDichVuDaSuDung.Contains(2);
            cbXetNghiemMau.Checked = danhSachDichVuDaSuDung.Contains(3);
            cbXetNghiemNuocTieu.Checked = danhSachDichVuDaSuDung.Contains(4);
            cbChuanDoanHinhAnh.Checked = danhSachDichVuDaSuDung.Contains(5);
            cbKhamThai.Checked = danhSachDichVuDaSuDung.Contains(6);
            cbTiemPhong.Checked = danhSachDichVuDaSuDung.Contains(7);
            cbNhaKhoa.Checked = danhSachDichVuDaSuDung.Contains(8);
        }

        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem dòng đang chọn có hợp lệ không
            if (tableDanhSachKhamBenh.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = tableDanhSachKhamBenh.SelectedRows[0];

                // Lấy MaLK từ dòng đang chọn
                if (selectedRow.Cells["MaLK"].Value != null)
                {
                    long maLK = Convert.ToInt64(selectedRow.Cells["MaLK"].Value);

                    // Tạo đối tượng LichKham để cập nhật trạng thái trong cơ sở dữ liệu
                    LichKhamDTO lichKham = new LichKhamDTO
                    {
                        MaLK = maLK,
                        TrangThai = ETrangThaiKham.DaKham // Cập nhật trạng thái thành "Đã khám"
                    };

                    // Cập nhật trạng thái vào cơ sở dữ liệu
                    bool success = lichKhamBLL.UpdateTrangThai(lichKham);

                    if (success)
                    {
                        // Cập nhật các thông tin khác của phiếu khám và dịch vụ đã sử dụng
                        PhieuKham phieuKham = phieuKhamBLL.GetByMaLK(maLK);
                        if (phieuKham != null)
                        {
                            // Cập nhật phiếu khám
                            CapNhatPhieuKham(phieuKham);
                            // Cập nhật dịch vụ đã sử dụng
                            LuuDichVuDaSuDung(phieuKham.MaPK);
                        }

                        // Thông báo thành công và làm mới dữ liệu dòng đã chọn
                        MessageBox.Show("Đã lưu thay đổi cho dòng được chọn thành công!");
                        LoadDataToGrid();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật trạng thái không thành công.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một dòng hợp lệ.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.");
            }
        }

        private void CapNhatPhieuKham(PhieuKham phieuKham)
        {
            // Lấy dữ liệu cần cập nhật từ các trường
            phieuKham.TrieuChung = txtTrieuChung.Text;
            phieuKham.TieuSuBenhLy = txtTienSuBenhLy.Text;
            phieuKham.ChuanDoan = txtChuanDoan.Text;
            phieuKham.LoiDanBacSi = txtLoiDanBacSi.Text;

            // Cập nhật phiếu khám vào cơ sở dữ liệu
            bool success = phieuKhamBLL.CapNhatPhieuKham(phieuKham);
            if (!success)
            {
                MessageBox.Show("Cập nhật phiếu khám không thành công.");
            }
        }

        private void LuuDichVuDaSuDung(long maPK)
        {
            List<long> danhSachDichVu = new List<long>();

            // Kiểm tra từng CheckBox và thêm mã dịch vụ tương ứng nếu được chọn
            if (cbKhamTongQuat.Checked) danhSachDichVu.Add(1); // Giả sử mã dịch vụ là 1 cho "Khám tổng quát"
            if (cbKhamChuyenKhoa.Checked) danhSachDichVu.Add(2); // Mã dịch vụ cho "Khám chuyên khoa"
            if (cbXetNghiemMau.Checked) danhSachDichVu.Add(3); // Mã dịch vụ cho "Xét nghiệm máu"
            if (cbXetNghiemNuocTieu.Checked) danhSachDichVu.Add(4); // Mã dịch vụ cho "Xét nghiệm nước tiểu"
            if (cbChuanDoanHinhAnh.Checked) danhSachDichVu.Add(5); // Mã dịch vụ cho "Chuẩn đoán hình ảnh"
            if (cbKhamThai.Checked) danhSachDichVu.Add(6); // Mã dịch vụ cho "Khám thai"
            if (cbTiemPhong.Checked) danhSachDichVu.Add(7); // Mã dịch vụ cho "Tiêm phòng"
            if (cbNhaKhoa.Checked) danhSachDichVu.Add(8); // Mã dịch vụ cho "Nha khoa"

            // Lưu danh sách dịch vụ đã chọn vào cơ sở dữ liệu
            foreach (var maDV in danhSachDichVu)
            {
                // Lấy đơn giá của dịch vụ
                double giaDichVu = dichVuBLL.LayDonGiaDichVu(maDV);

                // Kiểm tra nếu đơn giá hợp lệ (tránh trường hợp không tìm thấy dịch vụ)
                if (giaDichVu > 0)
                {
                    PhieuKhamDichVu phieuKhamDichVu = new PhieuKhamDichVu
                    {
                        MaPK = maPK,
                        MaDV = maDV,
                        Gia = giaDichVu  // Lấy đơn giá dịch vụ tại thời điểm sử dụng
                    };

                    // Lưu vào cơ sở dữ liệu thông qua lớp BLL
                    phieuKhamDVBLL.LuuDichVu(phieuKhamDichVu);
                }
                else
                {
                    // Xử lý nếu không tìm thấy dịch vụ hoặc dịch vụ không có đơn giá
                    Console.WriteLine($"Dịch vụ với MaDV {maDV} không tìm thấy hoặc không có đơn giá hợp lệ.");
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


    }
}
