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
    public partial class ChiTietToaThuocGUI : Form
    {
        private List<ChiTietToaThuoc> dsChiTietToaThuoc;
        public ChiTietToaThuocGUI()
        {
            InitializeComponent();
            //LoadData();
        }

        public ChiTietToaThuocGUI(List<ChiTietToaThuoc> dsChiTietToaThuoc)
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

        private void AddRowToDataGridView(ChiTietToaThuoc chiTietToaThuoc, int index)
        {
            int rowIndex = dgvChiTietToaThuoc.Rows.Add();

            dgvChiTietToaThuoc.Rows[rowIndex].Cells["STT"].Value = index.ToString();
            dgvChiTietToaThuoc.Rows[rowIndex].Cells["MaTT"].Value = chiTietToaThuoc.MaTT.ToString();
            dgvChiTietToaThuoc.Rows[rowIndex].Cells["TenThuoc"].Value = chiTietToaThuoc.Thuoc.TenThuoc;
            dgvChiTietToaThuoc.Rows[rowIndex].Cells["SoLuong"].Value = chiTietToaThuoc.SoLuong.ToString();
            dgvChiTietToaThuoc.Rows[rowIndex].Cells["CachDung"].Value = chiTietToaThuoc.CachDung;

        }

        //private void AddRowToDataGridView_TEST(long MaTT, string TenThuoc, int SoLuong, string CachDung, int index)
        //{
        //    int rowIndex = dgvChiTietToaThuoc.Rows.Add();

        //    dgvChiTietToaThuoc.Rows[rowIndex].Cells["STT"].Value = index.ToString();
        //    dgvChiTietToaThuoc.Rows[rowIndex].Cells["MaTT"].Value = MaTT.ToString();
        //    dgvChiTietToaThuoc.Rows[rowIndex].Cells["TenThuoc"].Value = TenThuoc;
        //    dgvChiTietToaThuoc.Rows[rowIndex].Cells["SoLuong"].Value = SoLuong.ToString();
        //    dgvChiTietToaThuoc.Rows[rowIndex].Cells["CachDung"].Value = CachDung;
        //}

    }
}
