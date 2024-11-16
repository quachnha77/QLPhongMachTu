using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class ToaThuoc : Form
    {
        private ToaThuocBLL toaThuocBLL;
        private KhoThuocBLL khoThuocBLL;
        private ChiTietToaThuocBLL ctttBLL;

        public ToaThuoc()
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

            LoadBenhNhanInfo(2);

            LoadChiTietToaThuoc();
            LoadKhoThuoc(); // Load danh sách thuốc từ kho thuốc      
        }

        private void LoadBenhNhanInfo(long maBN)
        {
            BenhNhanBLL benhNhanBLL = new BenhNhanBLL();
            BenhNhan benhNhan = benhNhanBLL.GetBenhNhanByMaBN(maBN);
            PhieuKhamBLL phieuKhamBLL = new PhieuKhamBLL();
            PhieuKham phieuKham = phieuKhamBLL.GetByMaBN(maBN);
            if (benhNhan != null)
            {
                lbMaBN.Text = benhNhan.MaSo.ToString();
                lbHoVaTen.Text = benhNhan.HoTen;
                lbNgaySinh.Text = benhNhan.NgaySinh.ToString("dd/MM/yyyy");
                lbGioiTinh.Text = benhNhan.GioiTinh;
                lbCCCD.Text = benhNhan.CCCD.ToString();
                

                lbNgayKeToa.Text = phieuKham.NgayKham.ToString("dd/MM/yyyy");
                lbLoiDanBS.Text = phieuKham.LoiDanBacSi;
                lbChuanDoan.Text = phieuKham.ChuanDoan;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin bệnh nhân.");
            }
        }

        private void LoadChiTietToaThuoc()
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

            // Khởi tạo đối tượng BLL để lấy danh sách chi tiết toa thuốc
            ChiTietToaThuocBLL chiTietToaThuocBLL = new ChiTietToaThuocBLL();
            List<ChiTietToaThuoc> chiTietToaThuocList = chiTietToaThuocBLL.GetAll();

            // Duyệt qua danh sách chi tiết toa thuốc
            foreach (var chiTiet in chiTietToaThuocList)
            {
                // Khởi tạo đối tượng BLL để lấy thông tin chi tiết thuốc
                KhoThuocBLL khoThuocBLL = new KhoThuocBLL();
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

            // Hiển thị dữ liệu lên DataGridView
            tableChiTietToaThuoc.DataSource = dataTable; // dgvChiTietToa là DataGridView cho chi tiết toa thuốc

            // Hiển thị tổng tiền thuốc
            lbTongTienThuoc.Text = $"{tongTienThuoc:N0} VND"; // Hiển thị tổng tiền thuốc với định dạng số
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

        

        //private void btnThemThuocVaoToa_Click(object sender, EventArgs e)
        //{
        //    if (tableChiTietToaThuoc.SelectedRows.Count > 0)
        //    {
        //        DataGridViewRow selectedRow = tableChiTietToaThuoc.SelectedRows[0];
        //        long maThuoc = Convert.ToInt64(selectedRow.Cells["ID"].Value);
        //        string tenThuoc = selectedRow.Cells["Tên thuốc"].Value.ToString();
        //        double donGia = Convert.ToDouble(selectedRow.Cells["Đơn giá"].Value);
        //        string donVi = selectedRow.Cells["Đơn vị"].Value.ToString();

        //        int soLuong = 1; // Giả sử số lượng ban đầu là 1 (có thể thay đổi theo yêu cầu)
        //        double tongTien = donGia * soLuong;

        //        // Tạo chi tiết toa thuốc
        //        ChiTietToaThuoc chiTietToaThuoc = new ChiTietToaThuoc
        //        {
        //            MaThuoc = maThuoc,
        //            TenThuoc = tenThuoc,
        //            DonGia = donGia,
        //            SoLuong = soLuong,
        //            DonVi = donVi,
        //            TongTien = tongTien,
        //            CachDung = "Uống 2 lần/ngày" // Có thể thay đổi tùy theo yêu cầu
        //        };

        //        chiTietToaThuocList.Add(chiTietToaThuoc);
        //        LoadChiTietToaThuoc();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Vui lòng chọn thuốc từ kho thuốc.");
        //    }
        //}



        //private void btnLuu_Click(object sender, EventArgs e)
        //{
        //    // Tạo mới đối tượng ToaThuoc và lưu vào CSDL
        //    ToaThuoc toaThuoc = new ToaThuoc
        //    {
        //        MaBN = Convert.ToInt64(txtMaBN.Text),
        //        MaBS = Convert.ToInt64(txtMaBS.Text), // Giả sử bạn đã có mã bác sĩ
        //        MaLK = Convert.ToInt64(txtMaLK.Text), // Giả sử bạn đã có mã lịch khám
        //        MaPK = Convert.ToInt64(txtMaPK.Text), // Giả sử bạn đã có mã phiếu khám
        //        NgayKeToa = DateTime.Now,
        //    };

        //    toaThuocBLL.LuuToaThuoc(toaThuoc, chiTietToaThuocList);

        //    MessageBox.Show("Đã lưu toa thuốc thành công.");
        //    Close();
        //}
    }
}
