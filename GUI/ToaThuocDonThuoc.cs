using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
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
        private long maBN;
        private string selectedMaTT;

        //public ToaThuocDonThuoc()
        //{
        //    InitializeComponent();
        //    LoadData();
        //}

        public ToaThuocDonThuoc(User user, BenhNhan benhNhan)
        {
            InitializeComponent();
            this.maBN = benhNhan.MaSo;
            LoadData();
        }

        public void LoadData()
        {
            List<ToaThuocDTO> DSToaThuoc = toaThuocBLL.GetByMaBN(maBN);

            int index = 1;
            foreach (var toaThuoc in DSToaThuoc)
            {
                AddRowToDataGridView(toaThuoc, index);
                ++index;
            }
        }

        private void AddRowToDataGridView(ToaThuocDTO toaThuoc, int index)
        {
            int rowIndex = dgvToaThuoc.Rows.Add();

            dgvToaThuoc.Rows[rowIndex].Cells["STT"].Value = index.ToString();
            dgvToaThuoc.Rows[rowIndex].Cells["MaTT"].Value = toaThuoc.MaTT.ToString();
            dgvToaThuoc.Rows[rowIndex].Cells["BacSi"].Value = bacSiBLL.GetById(toaThuoc.MaBS).HoTen;
            dgvToaThuoc.Rows[rowIndex].Cells["NgayKeToa"].Value = toaThuoc.NgayKeToa.ToString("dd/MM/yyyy"); ;
            dgvToaThuoc.Rows[rowIndex].Cells["NgayKham"].Value = phieuKhamBLL.GetByMaPK(toaThuoc.MaPK)?.NgayKham.ToString("dd/MM/yyyy") ?? "N/A";
            dgvToaThuoc.Rows[rowIndex].Cells["LoiDanBacSi"].Value = toaThuoc.LoiDanBacSi;
            dgvToaThuoc.Rows[rowIndex].Cells["TongTienThuoc"].Value = toaThuoc.TongTienThuoc.ToString();
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

            List<ChiTietToaThuocDTO> dsChiTietToaThuoc = chiTietToaThuocBLL.GetChiTietByMaTT((long)Convert.ToDouble(selectedMaTT));

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
                Console.WriteLine(ex.Message);
            }
        }

        private void dgvToaThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var cellValue = dgvToaThuoc.Rows[e.RowIndex].Cells["MaTT"].Value;
                if (cellValue != null)
                    selectedMaTT = cellValue.ToString();
                else
                    selectedMaTT = string.Empty;
            }
        }
    }
}

