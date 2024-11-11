using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DAL;
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
    public partial class ToaThuocDonThuoc : UserControl
    {
        private ToaThuocBLL toaThuocBLL = new ToaThuocBLL();
        private ChiTietToaThuocBLL chiTietToaThuocBLL = new ChiTietToaThuocBLL();
        private HoaDonThuocBLL hoaDonThuocBLL = new HoaDonThuocBLL();
        private BacSiBLL bacSiBLL = new BacSiBLL();
        private PhieuKhamBLL phieuKhamBLL = new PhieuKhamBLL();
        private long MaBN;

        private string selectedMaTT;

        public ToaThuocDonThuoc()
        {
            InitializeComponent();
            LoadData();
        }        
        public ToaThuocDonThuoc(User user, BenhNhan benhNhan)
        {
            InitializeComponent();
            this.MaBN = benhNhan.MaBN;
            LoadData();
        }

        public void LoadData()
        {
            List<DTO.ToaThuoc> DSToaThuoc = toaThuocBLL.GetByMaBN(MaBN);

            int index = 1;
            foreach (var toaThuoc in DSToaThuoc)
            {
                AddRowToDataGridView(toaThuoc, index);
                ++index;
            }

            //AddRowToDataGridView_TEST(1, "ASD", "1/1/2024", "1/1/2024", "8:00", "asd");
            //AddRowToDataGridView_TEST(2, "ASD", "1/1/2024", "1/1/2024", "8:00", "asd");
            //AddRowToDataGridView_TEST(3, "ASD", "1/1/2024", "1/1/2024", "8:00", "asd");
        }

        private void AddRowToDataGridView(DTO.ToaThuoc toaThuoc, int index)
        {
            int rowIndex = dgvToaThuoc.Rows.Add();

            dgvToaThuoc.Rows[rowIndex].Cells["STT"].Value = index.ToString();
            dgvToaThuoc.Rows[rowIndex].Cells["MaTT"].Value = toaThuoc.MaTT.ToString();
            dgvToaThuoc.Rows[rowIndex].Cells["BacSi"].Value = bacSiBLL.GetByMaBS(toaThuoc.MaBS).HoTen;
            dgvToaThuoc.Rows[rowIndex].Cells["NgayKeToa"].Value = toaThuoc.NgayKeToa.ToString("dd/MM/yyyy"); ;
            dgvToaThuoc.Rows[rowIndex].Cells["NgayKham"].Value = phieuKhamBLL.GetByMaPK(toaThuoc.MaPK).NgayKham.ToString("dd/MM/yyyy");
            dgvToaThuoc.Rows[rowIndex].Cells["ThoiGianDungThuoc"].Value = "?";
            dgvToaThuoc.Rows[rowIndex].Cells["LoiDan"].Value = "?";

        }
        private void AddRowToDataGridView_TEST(long MaTT, string HoTen, string NgayKeToa, string NgayKham, string ThoiGian, string LoiDan)
        {
            int rowIndex = dgvToaThuoc.Rows.Add();

            dgvToaThuoc.Rows[rowIndex].Cells["MaTT"].Value = MaTT.ToString();
            dgvToaThuoc.Rows[rowIndex].Cells["BacSi"].Value = HoTen;
            dgvToaThuoc.Rows[rowIndex].Cells["NgayKeToa"].Value = NgayKeToa;
            dgvToaThuoc.Rows[rowIndex].Cells["NgayKham"].Value = NgayKham;
            dgvToaThuoc.Rows[rowIndex].Cells["ThoiGianDungThuoc"].Value = ThoiGian;
            dgvToaThuoc.Rows[rowIndex].Cells["LoiDan"].Value = LoiDan;

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvToaThuoc.Rows.Clear();
            LoadData();
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaTT))
            {
                MessageBox.Show("Vui lòng chọn toa thuốc trước để xem chi tiết toa.");
                return;
            }

            List<ChiTietToaThuoc> dsChiTietToaThuoc = chiTietToaThuocBLL.GetByMaTT((long)Convert.ToDouble(selectedMaTT));

            if (dsChiTietToaThuoc == null || dsChiTietToaThuoc.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin chi tiết toa thuốc.");
                return;
            }

            try
            {
                using (ChiTietToaThuocGUI ctToaThuocForm = new ChiTietToaThuocGUI(dsChiTietToaThuoc))
                {
                    ctToaThuocForm.Owner = this.FindForm();
                    ctToaThuocForm.StartPosition = FormStartPosition.CenterParent;
                    ctToaThuocForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDSDonThuoc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaTT))
            {
                MessageBox.Show("Vui lòng chọn toa thuốc trước để xem danh sách đơn thuốc.");
                return;
            }

            List<HoaDonThuoc> dsHoaDonThuoc = hoaDonThuocBLL.GetByMaTT((long)Convert.ToDouble(selectedMaTT));

            if (dsHoaDonThuoc == null || dsHoaDonThuoc.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin danh sách đơn thuốc.");
                return;
            }

            try
            {
                using (DanhSachDonThuocGUI ctToaThuocForm = new DanhSachDonThuocGUI(dsHoaDonThuoc))
                {
                    ctToaThuocForm.Owner = this.FindForm();
                    ctToaThuocForm.StartPosition = FormStartPosition.CenterParent;
                    ctToaThuocForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvToaThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string MaTT = dgvToaThuoc.Rows[e.RowIndex].Cells["MaTT"].Value.ToString();
                selectedMaTT = MaTT;
            }
        }
    }
}
