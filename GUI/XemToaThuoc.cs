using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class XemToaThuoc : Form
    {
        private ToaThuocBLL toaThuocBLL;
        private KhoThuocBLL khoThuocBLL;
        private ChiTietToaThuocBLL ctttBLL;
        private PhieuKhamBLL phieuKhamBLL;
        private long maBN;

        public XemToaThuoc(long maBN)
        {
            InitializeComponent();

            //// Tắt AutoGenerateColumns nếu bạn đã định nghĩa cột trong DataGridView
            tableChiTietToaThuoc.AutoGenerateColumns = false;
            tableKhoThuoc.AutoGenerateColumns = false;

            //// Ánh xạ cột trong DataGridView ChiTietToaThuoc
            tableChiTietToaThuoc.Columns["ID"].DataPropertyName = "ID";
            tableChiTietToaThuoc.Columns["TenThuoc"].DataPropertyName = "TenThuoc";
            tableChiTietToaThuoc.Columns["DonGia"].DataPropertyName = "DonGia";
            tableChiTietToaThuoc.Columns["SoLuong"].DataPropertyName = "SoLuong";
            tableChiTietToaThuoc.Columns["DonVi"].DataPropertyName = "DonVi";
            tableChiTietToaThuoc.Columns["CachDung"].DataPropertyName = "CachDung";
            tableChiTietToaThuoc.Columns["TongTien"].DataPropertyName = "TongTien";

            //// Ánh xạ cột trong DataGridView KhoThuoc
            tableKhoThuoc.Columns["ID1"].DataPropertyName = "ID";
            tableKhoThuoc.Columns["TenThuoc1"].DataPropertyName = "TenThuoc";
            tableKhoThuoc.Columns["DonGia1"].DataPropertyName = "DonGia";
            tableKhoThuoc.Columns["DonVi1"].DataPropertyName = "DonVi";
            tableKhoThuoc.Columns["NCC1"].DataPropertyName = "NhaCungCap";
            tableKhoThuoc.Columns["NgayNhap1"].DataPropertyName = "NgayNhap";
            tableKhoThuoc.Columns["HSD1"].DataPropertyName = "HanSuDung";
            tableKhoThuoc.Columns["SLT1"].DataPropertyName = "SoLuongTon";


            toaThuocBLL = new ToaThuocBLL();
            khoThuocBLL = new KhoThuocBLL();
            ctttBLL = new ChiTietToaThuocBLL();
            phieuKhamBLL = new PhieuKhamBLL();

            this.maBN = maBN; // Lưu lại MaBN để sử dụng
            LoadThongTinBenhNhan(maBN); // tải lên thông tin bệnh nhân

            LoadChiTietToaThuoc(maBN);
            LoadKhoThuoc(); // Load danh sách thuốc từ kho thuốc      

            lbNgayKeToa.Text = DateTime.Now.ToString(); // Ngày kê toa là ngày hiện tại
        }

        private void LoadThongTinBenhNhan(long maBN)
        {
            BenhNhanBLL benhNhanBLL = new BenhNhanBLL();
            BenhNhan benhNhan = benhNhanBLL.GetBenhNhanByMaBN(maBN);

            phieuKhamBLL.GetByMaBN(maBN);
            if (benhNhan != null)
            {
                lbMaBN.Text = benhNhan.MaSo.ToString();
                lbHoVaTen.Text = benhNhan.HoTen;
                lbNgaySinh.Text = benhNhan.NgaySinh.ToString("dd/MM/yyyy");
                lbGioiTinh.Text = benhNhan.GioiTinh;
                lbCCCD.Text = benhNhan.CCCD.ToString();

                PhieuKham phieuKham = phieuKhamBLL.GetByMaBN(maBN);
                lbNgayKeToa.Text = phieuKham.NgayKham.ToString("dd/MM/yyyy");
                lbChuanDoan.Text = phieuKham.ChuanDoan;

                ToaThuocBLL toaThuocBLL = new ToaThuocBLL();// ToaThuoc
                ToaThuocDTO toaThuocDTO = toaThuocBLL.GetByMaPK(phieuKham.MaPK);
                txtLoiDanBS.Text = toaThuocDTO.LoiDanBacSi;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin bệnh nhân.");
            }
        }

        private void LoadChiTietToaThuoc(long maBN)
        {
            // Tạo DataTable để lưu trữ dữ liệu chi tiết toa thuốc
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(long));
            dataTable.Columns.Add("TenThuoc", typeof(string));
            dataTable.Columns.Add("DonGia", typeof(double));
            dataTable.Columns.Add("SoLuong", typeof(int));
            dataTable.Columns.Add("DonVi", typeof(string));
            dataTable.Columns.Add("CachDung", typeof(string));
            dataTable.Columns.Add("TongTien", typeof(double));

            double tongTienThuoc = 0;

            // Khởi tạo các đối tượng BLL một lần bên ngoài vòng lặp
            ToaThuocBLL toaThuocBLL = new ToaThuocBLL();
            ChiTietToaThuocBLL chiTietToaThuocBLL = new ChiTietToaThuocBLL();
            KhoThuocBLL khoThuocBLL = new KhoThuocBLL();

            // Lấy danh sách toa thuốc theo mã bệnh nhân
            List<QLPhongMachTu_DOAN_.DTO.ToaThuocDTO> toaThuocList = toaThuocBLL.GetByMaBN(maBN);

            // Duyệt qua từng toa thuốc để lấy chi tiết
            foreach (var toaThuoc in toaThuocList)
            {
                long maTT = toaThuoc.MaTT;

                // Lấy danh sách chi tiết toa thuốc theo MaTT
                List<ChiTietToaThuocDTO> chiTietToaThuocList = chiTietToaThuocBLL.GetChiTietByMaTT(maTT);

                // Duyệt qua danh sách chi tiết toa thuốc
                foreach (var chiTiet in chiTietToaThuocList)
                {
                    // Lấy thông tin chi tiết thuốc
                    var thuoc = khoThuocBLL.GetByMaThuoc(chiTiet.MaThuoc);

                    if (thuoc != null)
                    {
                        // Tính tổng tiền cho từng loại thuốc trong toa
                        double tongTienThuocItem = thuoc.DonGia * chiTiet.SoLuong;

                        // Thêm dòng dữ liệu vào DataTable
                        dataTable.Rows.Add(
                            chiTiet.MaThuoc,
                            thuoc.TenThuoc,
                            thuoc.DonGia,
                            chiTiet.SoLuong,
                            thuoc.DonVi,
                            chiTiet.CachDung,
                            tongTienThuocItem
                        );

                        // Cộng dồn tổng tiền cho tất cả các loại thuốc
                        tongTienThuoc += tongTienThuocItem;
                    }
                }
            }

            // Hiển thị dữ liệu lên DataGridView
            tableChiTietToaThuoc.DataSource = dataTable; // tableChiTietToaThuoc là DataGridView cho chi tiết toa thuốc

            // Hiển thị tổng tiền thuốc
            lbTongTienThuoc.Text = $"{tongTienThuoc:N0} VND";            // Hiển thị tổng tiền thuốc với định dạng số
        }

        private void LoadKhoThuoc()
        {
            // Lấy danh sách thuốc từ kho thuốc
            List<KhoThuoc> khoThuocList = khoThuocBLL.GetAll();

            DataTable dataTable1 = new DataTable();
            dataTable1.Columns.Add("ID", typeof(long));
            dataTable1.Columns.Add("TenThuoc", typeof(string));
            dataTable1.Columns.Add("DonGia", typeof(double));
            dataTable1.Columns.Add("DonVi", typeof(string));
            dataTable1.Columns.Add("NhaCungCap", typeof(string));
            dataTable1.Columns.Add("NgayNhap", typeof(DateTime));
            dataTable1.Columns.Add("HanSuDung", typeof(DateTime));
            dataTable1.Columns.Add("SoLuongTon", typeof(int));

            foreach (var thuoc in khoThuocList)
            {
                dataTable1.Rows.Add(thuoc.MaThuoc, thuoc.TenThuoc, thuoc.DonGia, thuoc.DonVi, thuoc.NhaCungCap, thuoc.NgayNhap, thuoc.HSD, thuoc.SoLuongTon);
            }

            tableKhoThuoc.DataSource = dataTable1; // tableChiTietToaThuoc là DataGridView cho kho thuốc
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim(); // Lấy từ khóa từ TextBox
            TimKiemThuoc(keyword); // Tải danh sách thuốc từ kho
        }

        private void TimKiemThuoc(string keyword)
        {
            try
            {
                KhoThuocBLL khoThuocBLL = new KhoThuocBLL();

                // Gọi phương thức tìm kiếm trong BLL
                List<KhoThuoc> khoThuocList = khoThuocBLL.TimKiemThuoc(keyword);

                // Tạo DataTable để hiển thị dữ liệu
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ID", typeof(long));
                dataTable.Columns.Add("TenThuoc", typeof(string));
                dataTable.Columns.Add("DonGia", typeof(double));
                dataTable.Columns.Add("DonVi", typeof(string));
                dataTable.Columns.Add("NhaCungCap", typeof(string));
                dataTable.Columns.Add("NgayNhap", typeof(DateTime));
                dataTable.Columns.Add("HanSuDung", typeof(DateTime));
                dataTable.Columns.Add("SoLuongTon", typeof(int));

                foreach (var thuoc in khoThuocList)
                {
                    dataTable.Rows.Add(
                        thuoc.MaThuoc,
                        thuoc.TenThuoc,
                        thuoc.DonGia,
                        thuoc.DonVi,
                        thuoc.NhaCungCap,
                        thuoc.NgayNhap,
                        thuoc.HSD,
                        thuoc.SoLuongTon
                    );
                }

                // Gán dữ liệu vào DataGridView
                tableKhoThuoc.DataSource = dataTable; // dgvKhoThuoc là DataGridView trong phần "Kho thuốc"
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách kho thuốc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemThuocVaoToa_Click(object sender, EventArgs e)
        {
            if (tableKhoThuoc.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = tableKhoThuoc.SelectedRows[0];
                long id = Convert.ToInt64(selectedRow.Cells["ID1"].Value);
                string tenThuoc = selectedRow.Cells["TenThuoc1"].Value.ToString();
                double donGia = Convert.ToDouble(selectedRow.Cells["DonGia1"].Value);
                string donVi = selectedRow.Cells["DonVi1"].Value.ToString();
                int soLuongTon = Convert.ToInt32(selectedRow.Cells["SLT1"].Value);

                // Kiểm tra số lượng tồn kho
                if (soLuongTon <= 0)
                {
                    MessageBox.Show("Thuốc này đã hết hàng trong kho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị hộp thoại để nhập số lượng
                string input = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Nhập số lượng cho thuốc '{tenThuoc}' (tối đa {soLuongTon}):",
                    "Nhập số lượng",
                    "1");

                if (int.TryParse(input, out int soLuong) && soLuong > 0 && soLuong <= soLuongTon)
                {
                    // Tính tổng tiền
                    double tongTien = donGia * soLuong;

                    // Thêm vào DataTable đã gắn với DataSource
                    DataTable dt = (DataTable)tableChiTietToaThuoc.DataSource;
                    if (dt != null)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["ID"] = id;
                        newRow["TenThuoc"] = tenThuoc;
                        newRow["DonGia"] = donGia;
                        newRow["SoLuong"] = soLuong;
                        newRow["DonVi"] = donVi;
                        newRow["CachDung"] = "Uống theo hướng dẫn";
                        newRow["TongTien"] = tongTien;
                        dt.Rows.Add(newRow);
                    }

                    MessageBox.Show("Đã thêm thuốc vào toa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Số lượng không hợp lệ. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thuốc trong danh sách kho thuốc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e) // Lưu ở đây chính là tạo mới
        {
            //Luu ToaThuoc
            PhieuKham phieuKham = phieuKhamBLL.GetByMaBN(maBN);
            string tongTienText = lbTongTienThuoc.Text.Replace("VND", "").Trim();
            var toaThuoc = new ToaThuocDTO
            {
                //MaTT = 123
                //MaBS = phieuKham.MaBS,
                MaBN = maBN,
                MaBS = phieuKham.MaBS,
                MaLK = phieuKham.MaLK,
                MaPK = phieuKham.MaPK,
                NgayKeToa = DateTime.Now,
                LoiDanBacSi = txtLoiDanBS.Text,
                TongTienThuoc = double.Parse(tongTienText, CultureInfo.InvariantCulture)
            };
            // Thêm toa thuốc và lấy MaTT vừa tạo
            long maTT = toaThuocBLL.AddToaThuoc(toaThuoc);
            MessageBox.Show($"Thêm toa thuốc thành công! Mã Toa Thuốc: {maTT}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Luu ChiTietToaThuoc
            List<ChiTietToaThuocDTO> danhSachChiTiet = GetDataFromDataGridView(maTT);
            ctttBLL.AddChiTietToaThuoc(danhSachChiTiet);


        }
        private List<ChiTietToaThuocDTO> GetDataFromDataGridView(long maTT)
        {
            List<ChiTietToaThuocDTO> danhSachChiTiet = new List<ChiTietToaThuocDTO>();

            foreach (DataGridViewRow row in tableChiTietToaThuoc.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ qua dòng trống

                var chiTiet = new ChiTietToaThuocDTO
                {
                    MaThuoc = Convert.ToInt64(row.Cells["ID"].Value),
                    MaTT = maTT, // Sử dụng MaTT đã có
                    SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value),
                    CachDung = row.Cells["CachDung"].Value?.ToString(),
                    DonGia = row.Cells["DonGia"].Value != null ? Convert.ToDouble(row.Cells["DonGia"].Value) : 0 // Chuyển đổi DonGia
                };

                danhSachChiTiet.Add(chiTiet);
            }

            return danhSachChiTiet;
        }
    }
}
