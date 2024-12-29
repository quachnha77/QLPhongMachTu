using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class XemToaThuocGUI : Form
    {
        private ToaThuocBLL toaThuocBLL;
        private KhoThuocBLL khoThuocBLL;
        private ChiTietToaThuocBLL ctttBLL;
        private PhieuKhamBLL phieuKhamBLL;
        private long maBN;
        private long maLK;

        public XemToaThuocGUI(long maBN, long maLK)
        {
            InitializeComponent();

            //// Tắt AutoGenerateColumns nếu bạn đã định nghĩa cột trong DataGridView
            tableChiTietToaThuoc.AutoGenerateColumns = false;

            //// Ánh xạ cột trong DataGridView ChiTietToaThuoc
            tableChiTietToaThuoc.Columns["ID"].DataPropertyName = "ID";
            tableChiTietToaThuoc.Columns["TenThuoc"].DataPropertyName = "TenThuoc";
            tableChiTietToaThuoc.Columns["DonGia"].DataPropertyName = "DonGia";
            tableChiTietToaThuoc.Columns["SoLuong"].DataPropertyName = "SoLuong";
            tableChiTietToaThuoc.Columns["DonVi"].DataPropertyName = "DonVi";
            tableChiTietToaThuoc.Columns["CachDung"].DataPropertyName = "CachDung";
            tableChiTietToaThuoc.Columns["TongTien"].DataPropertyName = "TongTien";

            toaThuocBLL = new ToaThuocBLL();
            khoThuocBLL = new KhoThuocBLL();
            ctttBLL = new ChiTietToaThuocBLL();
            phieuKhamBLL = new PhieuKhamBLL();

            this.maBN = maBN; // Lưu lại MaBN để sử dụng
            this.maLK = maLK;

            LoadThongTinBenhNhan(maBN); // tải lên thông tin bệnh nhân

            LoadChiTietToaThuoc(maBN, maLK);

            lbNgayKeToa.Text = DateTime.Now.ToString(); // Ngày kê toa là ngày hiện tại
            this.maLK = maLK;
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

        private void LoadChiTietToaThuoc(long maBN, long maLK)
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
            List<ToaThuocDTO> toaThuocList = toaThuocBLL.GetByMaBNAndMaLK(maBN, maLK);

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

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
