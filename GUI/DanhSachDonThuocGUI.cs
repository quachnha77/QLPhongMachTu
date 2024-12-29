using QLPhongMachTu_DOAN_.DTO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class DanhSachDonThuocGUI : Form
    {
        private List<HoaDonThuoc> dsHoaDonThuoc;
        public DanhSachDonThuocGUI()
        {
            InitializeComponent();
            LoadData();
        }

        public DanhSachDonThuocGUI(List<HoaDonThuoc> dsHoaDonThuoc)
        {
            InitializeComponent();
            this.dsHoaDonThuoc = dsHoaDonThuoc;
            LoadData();
        }

        public void LoadData()
        {
            dgvHoaDonThuoc.Rows.Clear();

            int index = 1;
            foreach (var hoaDonThuoc in dsHoaDonThuoc)
            {
                AddRowToDataGridView(hoaDonThuoc, index);
                ++index;
            }
        }

        private void AddRowToDataGridView(HoaDonThuoc hoaDonThuoc, int index)
        {
            int rowIndex = dgvHoaDonThuoc.Rows.Add();

            dgvHoaDonThuoc.Rows[rowIndex].Cells["STT"].Value = index.ToString();
            dgvHoaDonThuoc.Rows[rowIndex].Cells["MaDT"].Value = hoaDonThuoc.MaDT.ToString();
            dgvHoaDonThuoc.Rows[rowIndex].Cells["NgayMua"].Value = hoaDonThuoc.NgayMua.ToString("dd/MM/yyyy");
            dgvHoaDonThuoc.Rows[rowIndex].Cells["TongTien"].Value = hoaDonThuoc.TongTien.ToString();
            dgvHoaDonThuoc.Rows[rowIndex].Cells["TrangThai"].Value = hoaDonThuoc.TrangThai;
        }

        private void AddRowToDataGridView_TEST(long MaDT, string NgayMua, string TongTien, int index)
        {
            int rowIndex = dgvHoaDonThuoc.Rows.Add();

            dgvHoaDonThuoc.Rows[rowIndex].Cells["STT"].Value = index.ToString();
            dgvHoaDonThuoc.Rows[rowIndex].Cells["MaDT"].Value = MaDT.ToString();
            dgvHoaDonThuoc.Rows[rowIndex].Cells["NgayMua"].Value = NgayMua;
            dgvHoaDonThuoc.Rows[rowIndex].Cells["TongTien"].Value = TongTien;
        }
    }
}
