using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class KhoThuocGUI : UserControl
    {
        private readonly KhoThuocBLL khoThuocBLL;

        public KhoThuocGUI()
        {
            InitializeComponent();

            khoThuocBLL = new KhoThuocBLL();

            LoadThuoc();
        }

        private void LoadThuoc()
        {
            try
            {
                // Lấy danh sách thuốc từ BLL
                var danhSachThuoc = khoThuocBLL.GetAll();

                // Xóa tất cả các hàng cũ (nếu cần)
                tableKhoThuoc.Rows.Clear();

                // Kiểm tra nếu danh sách rỗng
                if (danhSachThuoc == null || danhSachThuoc.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị!");
                    return;
                }

                // Duyệt qua danh sách thuốc và thêm từng hàng
                foreach (var thuoc in danhSachThuoc)
                {
                    tableKhoThuoc.Rows.Add(
                        thuoc.MaThuoc,         // Mã thuốc
                        thuoc.TenThuoc,        // Tên thuốc
                        thuoc.DonGia.ToString("N0"),  // Đơn giá (format số)
                        thuoc.DonVi,           // Đơn vị
                        thuoc.NhaCungCap,      // Nhà cung cấp
                        thuoc.NgayNhap.ToShortDateString(), // Ngày nhập (định dạng ngày)
                        thuoc.HSD.ToShortDateString(),      // Hạn sử dụng (định dạng ngày)
                        thuoc.SoLuongTon       // Số lượng tồn
                    );
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có
                MessageBox.Show($"Lỗi khi tải danh sách thuốc: {ex.Message}");
            }
        }

        private void TaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void KhoThuoc_Click(object sender, EventArgs e)
        {

        }

        private void ThanhToan_Click(object sender, EventArgs e)
        {

        }

        private void Nhap_button_Click(object sender, EventArgs e)
        {
            try
            {
                var thuoc = new KhoThuocDTO
                {
                    //MaThuoc = long.Parse(txtMaThuoc.Text),
                    TenThuoc = txtTenThuoc.Text,
                    DonGia = double.Parse(txtDonGia.Text),
                    DonVi = txtDonVi.Text,
                    NhaCungCap = txtNhaCungCap.Text,
                    NgayNhap = dateTimePickerNgayNhap.Value,
                    HSD = dateTimePickerHSD.Value,
                    SoLuongTon = int.Parse(txtSoLuong.Text)
                };

                if (khoThuocBLL.NhapThuoc(thuoc))
                {
                    MessageBox.Show("Nhập thuốc thành công!");
                    LoadThuoc();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có lỗi: {ex.Message}");
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                var ketQua = khoThuocBLL.SearchMedicines(keyword);
                //tableKhoThuoc.DataSource = ketQua;
                tableKhoThuoc.Rows.Clear();
                foreach (var thuoc in ketQua)
                {
                    tableKhoThuoc.Rows.Add(
                        thuoc.MaThuoc,         // Mã thuốc
                        thuoc.TenThuoc,        // Tên thuốc
                        thuoc.DonGia.ToString("N0"),  // Đơn giá (format số)
                        thuoc.DonVi,           // Đơn vị
                        thuoc.NhaCungCap,      // Nhà cung cấp
                        thuoc.NgayNhap.ToShortDateString(), // Ngày nhập (định dạng ngày)
                        thuoc.HSD.ToShortDateString(),      // Hạn sử dụng (định dạng ngày)
                        thuoc.SoLuongTon       // Số lượng tồn
                    );
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void dataGridViewKhoThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = tableKhoThuoc.Rows[e.RowIndex];
                txtMaThuoc.Text = selectedRow.Cells["MaThuoc"].Value.ToString();
                txtTenThuoc.Text = selectedRow.Cells["TenThuoc"].Value.ToString();
                txtDonGia.Text = selectedRow.Cells["DonGia"].Value.ToString();
                txtDonVi.Text = selectedRow.Cells["DonVi"].Value.ToString();
                txtNhaCungCap.Text = selectedRow.Cells["NhaCungCap"].Value.ToString();
                dateTimePickerNgayNhap.Value = Convert.ToDateTime(selectedRow.Cells["NgayNhap"].Value);
                dateTimePickerHSD.Value = Convert.ToDateTime(selectedRow.Cells["HanSuDung"].Value);
                txtSoLuong.Text = selectedRow.Cells["SoLuongTon"].Value.ToString();
            }
        }

        private void ChinhSua_click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem người dùng đã chọn dòng nào chưa
                if (string.IsNullOrWhiteSpace(txtMaThuoc.Text))
                {
                    MessageBox.Show("Vui lòng chọn thuốc để chỉnh sửa.");
                    return;
                }

                // Tạo đối tượng thuốc từ dữ liệu người dùng đã sửa đổi
                var thuoc = new KhoThuocDTO
                {
                    MaThuoc = long.Parse(txtMaThuoc.Text), // ID không thể sửa, dùng làm định danh
                    TenThuoc = txtTenThuoc.Text,
                    DonGia = double.Parse(txtDonGia.Text),
                    DonVi = txtDonVi.Text,
                    NhaCungCap = txtNhaCungCap.Text,
                    NgayNhap = dateTimePickerNgayNhap.Value,
                    HSD = dateTimePickerHSD.Value,
                    SoLuongTon = int.Parse(txtSoLuong.Text)
                };

                // Gọi BLL để cập nhật dữ liệu
                if (khoThuocBLL.UpdateThuoc(thuoc))
                {
                    MessageBox.Show("Chỉnh sửa thuốc thành công!");
                    LoadThuoc(); // Tải lại dữ liệu sau khi chỉnh sửa
                }
                else
                {
                    MessageBox.Show("Chỉnh sửa thất bại, vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có lỗi: {ex.Message}");
            }
        }

        private void XuatExel_click(object sender, EventArgs e)
        {
            try
            {
                // Tạo một Workbook mới
                using (var workbook = new ClosedXML.Excel.XLWorkbook())
                {
                    // Tạo một Worksheet
                    var worksheet = workbook.Worksheets.Add("Danh sách thuốc");

                    // Tạo tiêu đề cột
                    worksheet.Cell(1, 1).Value = "Mã Thuốc";
                    worksheet.Cell(1, 2).Value = "Tên Thuốc";
                    worksheet.Cell(1, 3).Value = "Đơn Giá";
                    worksheet.Cell(1, 4).Value = "Đơn Vị";
                    worksheet.Cell(1, 5).Value = "Nhà Cung Cấp";
                    worksheet.Cell(1, 6).Value = "Ngày Nhập";
                    worksheet.Cell(1, 7).Value = "Hạn Sử Dụng";
                    worksheet.Cell(1, 8).Value = "Số Lượng Tồn";

                    // Ghi dữ liệu từ DataGridView vào file Excel
                    for (int i = 0; i < tableKhoThuoc.Rows.Count; i++)
                    {
                        worksheet.Cell(i + 2, 1).Value = tableKhoThuoc.Rows[i].Cells["MaThuoc"].Value?.ToString(); // Mã Thuốc (chuỗi)
                        worksheet.Cell(i + 2, 2).Value = tableKhoThuoc.Rows[i].Cells["TenThuoc"].Value?.ToString(); // Tên Thuốc
                        worksheet.Cell(i + 2, 3).Value = Convert.ToDouble(tableKhoThuoc.Rows[i].Cells["DonGia"].Value).ToString("N0"); // Đơn Giá
                        worksheet.Cell(i + 2, 4).Value = tableKhoThuoc.Rows[i].Cells["DonVi"].Value?.ToString(); // Đơn Vị
                        worksheet.Cell(i + 2, 5).Value = tableKhoThuoc.Rows[i].Cells["NhaCungCap"].Value?.ToString(); // Nhà Cung Cấp
                        worksheet.Cell(i + 2, 6).Value = Convert.ToDateTime(tableKhoThuoc.Rows[i].Cells["NgayNhap"].Value).ToString("dd/MM/yyyy");   // Ngày Nhập
                        worksheet.Cell(i + 2, 7).Value = Convert.ToDateTime(tableKhoThuoc.Rows[i].Cells["HanSuDung"].Value).ToString("dd/MM/yyyy");  // Hạn Sử Dụng
                        worksheet.Cell(i + 2, 8).Value = Convert.ToInt32(tableKhoThuoc.Rows[i].Cells["SoLuongTon"].Value); // Số Lượng Tồn
                    }

                    // Hiển thị hộp thoại lưu file
                    using (var saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                        saveFileDialog.Title = "Lưu file Excel";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            workbook.SaveAs(saveFileDialog.FileName);
                            MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có lỗi khi xuất dữ liệu: {ex.Message}");
            }
        }

        private void NhapExcel_click(object sender, EventArgs e)
        {
            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    openFileDialog.Title = "Chọn file Excel";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Mở file Excel
                        using (var workbook = new ClosedXML.Excel.XLWorkbook(openFileDialog.FileName))
                        {
                            var worksheet = workbook.Worksheet(1); // Lấy Worksheet đầu tiên
                            tableKhoThuoc.Rows.Clear(); // Xóa dữ liệu cũ trong DataGridView

                            // Đọc dữ liệu từ file Excel
                            int row = 2; // Bắt đầu từ dòng thứ 2 (bỏ qua tiêu đề cột)
                            while (!worksheet.Cell(row, 1).IsEmpty())
                            {
                                // Đọc từng ô trong dòng
                                string tenThuoc = worksheet.Cell(row, 1).GetString();
                                string donGiaRaw = worksheet.Cell(row, 2).Value.ToString();
                                string donVi = worksheet.Cell(row, 3).GetString();
                                string nhaCungCap = worksheet.Cell(row, 4).GetString();
                                string ngayNhapRaw = worksheet.Cell(row, 5).Value.ToString();
                                string hanSuDungRaw = worksheet.Cell(row, 6).Value.ToString();
                                string soLuongTonRaw = worksheet.Cell(row, 7).Value.ToString();

                                // Xử lý định dạng
                                decimal donGia = decimal.TryParse(donGiaRaw, out var dGia) ? dGia : 0; // Đơn giá
                                DateTime ngayNhap = DateTime.TryParse(ngayNhapRaw, out var nNhap) ? nNhap : DateTime.MinValue; // Ngày nhập
                                DateTime hanSuDung = DateTime.TryParse(hanSuDungRaw, out var hSuDung) ? hSuDung : DateTime.MinValue; // Hạn sử dụng
                                int soLuongTon = int.TryParse(soLuongTonRaw, out var sLuong) ? sLuong : 0; // Số lượng tồn

                                // Thêm vào DataGridView
                                tableKhoThuoc.Rows.Add(
                                    "Mã thuốc",
                                    tenThuoc,                       // Tên thuốc
                                    donGia.ToString("N0"),          // Định dạng đơn giá (số nguyên có dấu phân cách)
                                    donVi,                          // Đơn vị
                                    nhaCungCap,                     // Nhà cung cấp
                                    ngayNhap.ToString("dd/MM/yyyy"),// Ngày nhập (định dạng ngày)
                                    hanSuDung.ToString("dd/MM/yyyy"),// Hạn sử dụng (định dạng ngày)
                                    soLuongTon                      // Số lượng tồn
                                );

                                row++; // Tiếp tục dòng tiếp theo
                            }
                        }

                        MessageBox.Show("Nhập dữ liệu từ Excel thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có lỗi khi nhập dữ liệu: {ex.Message}");
            }
        }

    }
}
