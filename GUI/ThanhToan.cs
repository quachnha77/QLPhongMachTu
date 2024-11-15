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
    }
}
