using QLPhongMachTu_DOAN_.BLL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class ToaThuocDonThuoc_DS : UserControl
    {
        // Khởi tạo các lớp BLL
        private readonly ToaThuocBLL toaThuocBLL = new ToaThuocBLL();
        private readonly ChiTietToaThuocBLL chiTietToaThuocBLL = new ChiTietToaThuocBLL();
        private readonly HoaDonThuocBLL hoaDonThuocBLL = new HoaDonThuocBLL();
        private readonly BacSiBLL bacSiBLL = new BacSiBLL();
        private readonly BenhNhanBLL benhNhanBLL = new BenhNhanBLL();
        private readonly PhieuKhamBLL phieuKhamBLL = new PhieuKhamBLL();
        private readonly KhoThuocBLL khoThuocBLL = new KhoThuocBLL();

        public ToaThuocDonThuoc_DS()
        {
            InitializeComponent();
            LoadDanhSachToaThuoc();
        }

        // Phương thức tải danh sách toa thuốc
        private void LoadDanhSachToaThuoc()
        {
            try
            {
                var dsToaThuoc = toaThuocBLL.GetAll();

                // Xóa tất cả các hàng cũ (nếu cần)
                tableToaThuoc.Rows.Clear();

                // Kiểm tra nếu danh sách rỗng
                if (dsToaThuoc == null || dsToaThuoc.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị!");
                    return;
                }

                int STT = 0;
                // Duyệt qua danh sách thuốc và thêm từng hàng
                foreach (var toa in dsToaThuoc)
                {
                    STT++;
                    tableToaThuoc.Rows.Add(
                        STT.ToString(),       // Số
                        toa.MaTT.ToString(),       // Mã toa thuộcs
                        benhNhanBLL.GetBenhNhanByMaBN(toa.MaBN).HoTen.ToString(),
                        bacSiBLL.GetById(toa.MaBS).HoTen.ToString(),
                        toa.NgayKeToa.ToString("dd/MM/yyyy"),
                        toa.TinhTrang.ToString()
                    );
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có
                MessageBox.Show($"Lỗi khi tải danh sách thuốc: {ex.Message}");
            }
        }

        // Sự kiện tìm kiếm trong danh sách toa thuốc
        //private void txtTimKiem_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string keyword = txtTimKiem.Text.Trim();
        //        var danhSachToaThuoc = toaThuocBLL.GetAll();
        //        var filteredList = danhSachToaThuoc.Where(t => t.BenhNhan.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        //        tableToaThuoc.DataSource = filteredList;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        // Sự kiện chọn toa thuốc trong DataGridView
        private void tableToaThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    if (tableToaThuoc.SelectedRows.Count > 0) // Kiểm tra có hàng được chọn
                    {
                        var selectedRow = tableToaThuoc.SelectedRows[0];

                        // Kiểm tra giá trị "MaToa" và chuyển đổi sang kiểu long
                        if (selectedRow.Cells["MaTT"].Value != null &&
                            long.TryParse(selectedRow.Cells["MaTT"].Value.ToString(), out long maToa))
                        {
                            // Load chi tiết toa thuốc với giá trị MaToa
                            LoadChiTietToaThuoc(maToa);
                        }
                        else
                        {
                            MessageBox.Show("Mã toa thuốc không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi chọn toa thuốc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // Phương thức tải danh sách thuốc trong toa thuốc
        private void LoadChiTietToaThuoc(long maToa)
        {
            try
            {
                // Lấy danh sách chi tiết toa thuốc
                var danhCTTT = chiTietToaThuocBLL.GetChiTietByMaTT(maToa);

                // Xóa tất cả các hàng trong bảng tableChiTiet
                tableChiTiet.Rows.Clear();

                // Kiểm tra nếu danh sách rỗng
                if (danhCTTT == null || !danhCTTT.Any())
                {
                    MessageBox.Show("Không có chi tiết toa thuốc nào cho mã toa thuốc này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Thêm từng hàng vào tableChiTiet
                foreach (var t in danhCTTT)
                {
                    var thuoc = khoThuocBLL.GetByMaThuoc(t.MaThuoc);

                    if (thuoc != null)
                    {
                        tableChiTiet.Rows.Add(
                            t.MaTT,
                            thuoc.MaThuoc,
                            thuoc.TenThuoc,
                            thuoc.DonGia,
                            t.SoLuong,
                            thuoc.DonVi,
                            t.CachDung,
                            t.SoLuong * thuoc.DonGia // Tính tổng tiền
                        );
                    }
                    else
                    {
                        MessageBox.Show($"Không tìm thấy thông tin thuốc cho mã thuốc: {t.MaThuoc}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách thuốc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Sự kiện phát thuốc
        private void btnPhatThuoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (tableToaThuoc.SelectedRows.Count > 0)
                {
                    // Lấy giá trị Mã Toa từ dòng đã chọn
                    var maToaValue = tableToaThuoc.SelectedRows[0].Cells["MaTT"].Value;

                    // Kiểm tra và chuyển đổi maToaValue thành long
                    if (maToaValue != null && long.TryParse(maToaValue.ToString(), out long maToa))
                    {
                        PhatThuoc(maToa);
                        LoadDanhSachToaThuoc();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn toa thuốc để phát.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi phát thuốc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Phương thức phát thuốc
        private bool PhatThuoc(long maToa)
        {
            try
            {
                // Gọi BLL để cập nhật trạng thái toa thuốc
                var result = toaThuocBLL.PhatThuoc(maToa);

                if (result) // Nếu kết quả là true
                {
                    MessageBox.Show("Cập nhật tình trạng toa thuốc thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật tình trạng toa thuốc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu xảy ra ngoại lệ
                MessageBox.Show($"Lỗi khi phát thuốc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        
    }
}
