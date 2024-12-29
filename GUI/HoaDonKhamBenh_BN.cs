using QLPhongMachTu_DOAN_.BLL;
using System.Collections.Generic;
using System.Windows.Forms;
using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class HoaDonKhamBenh_BN : Form
    {
        private HoaDonKhamBenhDTO hoaDonKhamBenh;
        private PhieuKhamBLL phieuKhamBLL = new PhieuKhamBLL();
        private PhieuKhamDichVuBLL phieuKhamDichVuBLL = new PhieuKhamDichVuBLL();
        private DichVuBLL dichVuBLL = new DichVuBLL();
        private BenhNhanBLL benhNhanBLL = new BenhNhanBLL();

        public HoaDonKhamBenh_BN()
        {
            InitializeComponent();
        }
        public HoaDonKhamBenh_BN(HoaDonKhamBenhDTO hoaDonKhamBenh)
        {
            InitializeComponent();
            this.hoaDonKhamBenh = hoaDonKhamBenh;
            LoadData();
        }

        public void LoadData()
        {
            DTO.BenhNhan benhNhan = benhNhanBLL.GetBenhNhanByMaBN(hoaDonKhamBenh.MaBN);
            DTO.PhieuKham phieuKham = phieuKhamBLL.GetByMaPK(hoaDonKhamBenh.MaPK);

            MaBN.Text = benhNhan.MaSo.ToString();
            HoTen.Text = benhNhan.HoTen;
            CCCD.Text = benhNhan.CCCD.ToString();
            NgaySinh.Text = benhNhan.NgaySinh.ToString("dd/MM/yyyy");
            GioiTinh.Text = benhNhan.GioiTinh;
            SDT.Text = benhNhan.SDT;
            MaPK.Text = phieuKham.MaPK.ToString();
            NgayKham.Text = phieuKham.NgayKham.ToString("dd/MM/yyyy");
            TrieuChung.Text = phieuKham.TrieuChung;
            ChuanDoan.Text = phieuKham.ChuanDoan;
            TongTien.Text = hoaDonKhamBenh.TongTien.ToString();

            List<long> dsMaDichVu = phieuKhamDichVuBLL.GetDichVuByMaPK(hoaDonKhamBenh.MaPK);
            List<DichVuDTO> dsDichVu = new List<DichVuDTO>();
            foreach (long maDV in dsMaDichVu)
            {
                dsDichVu.Add(dichVuBLL.GetByMaDV(maDV));
            }
            int index = 1;
            foreach (var dichVu in dsDichVu)
            {
                AddRowToDataGridView(dichVu, index);
                ++index;
            }
        }

        public void AddRowToDataGridView(DichVuDTO dichVu, int index)
        {
            int rowIndex = dgvHDKhamBenh.Rows.Add();

            dgvHDKhamBenh.Rows[rowIndex].Cells["TenDichVu"].Value = dichVu.TenDichVu;
            dgvHDKhamBenh.Rows[rowIndex].Cells["DonGia"].Value = dichVu.DonGia.ToString();
            dgvHDKhamBenh.Rows[rowIndex].Cells["MoTa"].Value = dichVu.MoTa;
        }
    }
}
