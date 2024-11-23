using System;
using BLL;
using DTO;

namespace GUI
{
    public partial class DuocSi_KhoThuoc : Form
    {
        private readonly KhoThuocBLL khoThuocBLL;

        public DuocSi_KhoThuoc()
        {
            InitializeComponent();
            khoThuocBLL = new KhoThuocBLL();
        }

        private void DuocSi_KhoThuoc_Load(object sender, EventArgs e)
        {
            LoadThuoc();
        }

        private void LoadThuoc()
        {
            try
            {
                var danhSachThuoc = khoThuocBLL.GetAll();
                dataGridViewKhoThuoc.DataSource = danhSachThuoc;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i khi t?i danh sách thu?c: {ex.Message}");
            }
        }

        private void TaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void ToaThuocDonThuoc_Click(object sender, EventArgs e)
        {
            DuocSi_ToaDon form1 = new DuocSi_ToaDon();
            form1.Show();

            this.Hide();
        }

        private void KhoThuoc_Click(object sender, EventArgs e)
        {

        }

        private void ThanhToan_Click(object sender, EventArgs e)
        {

        }

        private void Nhap_button_Click(object sender, EventArgs e)
        {
            try
            {
                var thuoc = new KhoThuocDTO
                {
                    MaThuoc = long.Parse(txtMa.Text),
                    TenThuoc = txtTen.Text,
                    DonGia = double.Parse(txtDonGia.Text),
                    DonVi = txtDonVi.Text,
                    NhaCungCap = txtNhaCungCap.Text,
                    NgayNhap = dateTimePickerNgayNhap.Value,
                    HSD = dateTimePickerHSD.Value,
                    SoLuongTon = int.Parse(txtSoLuong.Text)
                };

                if (khoThuocBLL.AddOrUpdateThuoc(thuoc))
                {
                    MessageBox.Show("Thêm ho?c c?p nh?t thu?c thành công!");
                    LoadThuoc();
                }
                else
                {
                    MessageBox.Show("Không th? thêm ho?c c?p nh?t thu?c.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i khi thêm/c?p nh?t thu?c: {ex.Message}");
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                var ketQua = khoThuocBLL.SearchMedicines(keyword);
                dataGridViewKhoThuoc.DataSource = ketQua;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i khi tìm ki?m thu?c: {ex.Message}");
            }
        }

        private void dataGridViewKhoThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridViewKhoThuoc.Rows[e.RowIndex];
                txtMa.Text = selectedRow.Cells["MaThuoc"].Value.ToString();
                txtTen.Text = selectedRow.Cells["TenThuoc"].Value.ToString();
                txtDonGia.Text = selectedRow.Cells["DonGia"].Value.ToString();
                txtDonVi.Text = selectedRow.Cells["DonVi"].Value.ToString();
                txtNhaCungCap.Text = selectedRow.Cells["NhaCungCap"].Value.ToString();
                dateTimePickerNgayNhap.Value = Convert.ToDateTime(selectedRow.Cells["NgayNhap"].Value);
                dateTimePickerHSD.Value = Convert.ToDateTime(selectedRow.Cells["HSD"].Value);
                txtSoLuong.Text = selectedRow.Cells["SoLuongTon"].Value.ToString();
            }
        }

    }

}
