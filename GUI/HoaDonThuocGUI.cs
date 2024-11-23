using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class HoaDonThuocGUI : Form
    {
        private long maBN;
        private DTO.HoaDonThuoc hoaDonThuoc;
        private ToaThuocBLL toaThuocBLL = new ToaThuocBLL();
        private BenhNhanBLL benhNhanBLL = new BenhNhanBLL();
        private PhieuKhamBLL phieuKhamBLL = new PhieuKhamBLL();
        private KhoThuocBLL khoThuocBLL = new KhoThuocBLL();
        private ChiTietToaThuocBLL chiTietToaThuocBLL = new ChiTietToaThuocBLL();

        public HoaDonThuocGUI()
        {
            InitializeComponent();
        }
        public HoaDonThuocGUI(long maBN, DTO.HoaDonThuoc hoaDonThuoc)
        {
            InitializeComponent();
            this.maBN = maBN;
            this.hoaDonThuoc = hoaDonThuoc;
            LoadData();
        }

        public void LoadData()
        {
            DTO.BenhNhan benhNhan = benhNhanBLL.GetBenhNhanByMaBN(maBN);
            DTO.ToaThuoc toaThuoc = toaThuocBLL.GetByMaTT(hoaDonThuoc.MaTT);
            DTO.PhieuKham phieuKham = phieuKhamBLL.GetByMaPK(toaThuoc.MaPK);

            MaBN.Text = benhNhan.MaSo.ToString();
            HoTen.Text = benhNhan.HoTen;
            CCCD.Text = benhNhan.CCCD.ToString();
            NgaySinh.Text = benhNhan.NgaySinh.ToString("dd/MM/yyyy");
            GioiTinh.Text = benhNhan.GioiTinh;
            SDT.Text = benhNhan.SDT;
            MaTT.Text = toaThuoc.MaTT.ToString();
            NgayKeToa.Text = toaThuoc.NgayKeToa.ToString("dd/MM/yyyy");
            ChuanDoan.Text = phieuKham.ChuanDoan;
            TongTien.Text = hoaDonThuoc.TongTien.ToString();

            List<DTO.ChiTietToaThuoc> chiTietToaThuocList = chiTietToaThuocBLL.GetByMaTT(toaThuoc.MaTT);
            int index = 1;
            foreach (var chiTiet in chiTietToaThuocList)
            {
                AddRowToDataGridView(chiTiet, index);
                ++index;
            }
        }

        public void AddRowToDataGridView(DTO.ChiTietToaThuoc chiTietToaThuoc, int index)
        {
            DTO.KhoThuoc thuoc = khoThuocBLL.GetByMaThuoc(chiTietToaThuoc.MaThuoc);
            int rowIndex = dgvHDThuoc.Rows.Add();

            dgvHDThuoc.Rows[rowIndex].Cells["TenThuoc"].Value = thuoc.TenThuoc;
            dgvHDThuoc.Rows[rowIndex].Cells["DonGia"].Value = thuoc.DonGia.ToString();
            dgvHDThuoc.Rows[rowIndex].Cells["SoLuong"].Value = chiTietToaThuoc.SoLuong.ToString();
            dgvHDThuoc.Rows[rowIndex].Cells["DonVi"].Value = thuoc.DonVi.ToString();
            dgvHDThuoc.Rows[rowIndex].Cells["CachDung"].Value = chiTietToaThuoc.CachDung;
            dgvHDThuoc.Rows[rowIndex].Cells["TongTienThuoc"].Value = hoaDonThuoc.TongTien.ToString();
        }
    }
}
