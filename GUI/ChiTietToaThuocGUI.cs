using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class ChiTietToaThuocGUI : Form
    {
        private KhoThuocBLL khoThuocBLL = new KhoThuocBLL();
        private List<ChiTietToaThuocDTO> dsChiTietToaThuoc;

        public ChiTietToaThuocGUI()
        {
            InitializeComponent();
            LoadData();
        }

        public ChiTietToaThuocGUI(List<ChiTietToaThuocDTO> dsChiTietToaThuoc)
        {
            InitializeComponent();
            this.dsChiTietToaThuoc = dsChiTietToaThuoc;
            LoadData();
        }

        public void LoadData()
        {
            dgvChiTietToaThuoc.Rows.Clear();

            int index = 1;
            foreach (var chiTietToaThuoc in dsChiTietToaThuoc)
            {
                AddRowToDataGridView(chiTietToaThuoc, index);
                ++index;
            }

            //AddRowToDataGridView_TEST(1, "ABC", 2, "ASD", 1);
            //AddRowToDataGridView_TEST(1, "ABC", 2, "ASD", 1);
            //AddRowToDataGridView_TEST(1, "ABC", 2, "ASD", 1);
            //AddRowToDataGridView_TEST(1, "ABC", 2, "ASD", 1);
        }

        private void AddRowToDataGridView(ChiTietToaThuocDTO chiTietToaThuoc, int index)
        {
            int rowIndex = dgvChiTietToaThuoc.Rows.Add();

            dgvChiTietToaThuoc.Rows[rowIndex].Cells["STT"].Value = index.ToString();
            dgvChiTietToaThuoc.Rows[rowIndex].Cells["MaTT"].Value = chiTietToaThuoc.MaTT.ToString();
            dgvChiTietToaThuoc.Rows[rowIndex].Cells["TenThuoc"].Value = khoThuocBLL.GetByMaThuoc(chiTietToaThuoc.MaThuoc).TenThuoc;
            dgvChiTietToaThuoc.Rows[rowIndex].Cells["SoLuong"].Value = chiTietToaThuoc.SoLuong.ToString();
            dgvChiTietToaThuoc.Rows[rowIndex].Cells["CachDung"].Value = chiTietToaThuoc.CachDung;

        }
    }
}
