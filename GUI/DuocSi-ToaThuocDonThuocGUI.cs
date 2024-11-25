using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class DuocSi_ToaDon : Form
    {

        private ToaThuocBLL toaThuocBLL;

        public DuocSi_ToaDon()
        {
            InitializeComponent();
            toaThuocBLL = new ToaThuocBLL();
        }

        private void DuocSi_ToaDon_Load(object sender, EventArgs e)
        {
            LoadToaThuoc();
        }

        private void LoadToaThuoc()
        {
            try
            {
                var toaThuocList = toaThuocBLL.GetAll();
                dataGridViewToaThuoc.DataSource = toaThuocList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void ThanhToan_Click(object sender, EventArgs e)
        {

        }

        private void ToaThuocDonThuoc_Click(object sender, EventArgs e)
        {

        }

        private void KhoThuoc_Click(object sender, EventArgs e)
        {
            DuocSi_KhoThuoc form1 = new DuocSi_KhoThuoc();
            form1.Show();

            this.Close();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtSearch = (TextBox)this.Controls.Find("txtSearchToaThuoc", true)[0];
                string keyword = txtSearch.Text.Trim();
                var searchResult = toaThuocBLL.SearchToaThuoc(keyword);

                DataGridView dgvToaThuoc = (DataGridView)this.Controls.Find("dgvToaThuoc", true)[0];
                dgvToaThuoc.DataSource = searchResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnChiTietToaThuoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewToaThuoc.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridViewToaThuoc.SelectedRows[0];
                    if (selectedRow.Cells["MaTT"].Value != null && long.TryParse(selectedRow.Cells["MaTT"].Value.ToString(), out long maToaThuoc))
                    {
                        var toaThuoc = toaThuocBLL.GetByMaToa(maToaThuoc);
                        if (toaThuoc != null)
                        {
                            MessageBox.Show($"Chi tiết toa thuốc:\nMã Toa: {toaThuoc.MaTT}\nMã BN: {toaThuoc.MaBN}\nNgày kê toa: {toaThuoc.NgayKeToa}",
                                            "Chi tiết toa thuốc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy chi tiết toa thuốc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu không hợp lệ hoặc không thể chuyển đổi mã toa thuốc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một toa thuốc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xem chi tiết toa thuốc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPhatThuoc_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgvToaThuoc = (DataGridView)this.Controls.Find("dgvToaThuoc", true)[0];
                if (dgvToaThuoc.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvToaThuoc.SelectedRows[0];
                    long maToaThuoc = Convert.ToInt64(selectedRow.Cells["MaTT"].Value);

                    bool result = toaThuocBLL.PhatThuoc(maToaThuoc);
                    if (result)
                    {
                        MessageBox.Show("Phát thuốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadToaThuoc(); 
                    }
                    else
                    {
                        MessageBox.Show("Phát thuốc không thành công. Kiểm tra lại trạng thái.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một toa thuốc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi phát thuốc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox txtMaBN = (TextBox)this.Controls.Find("txtMaBN", true)[0];
                TextBox txtTongTien = (TextBox)this.Controls.Find("txtTongTien", true)[0];

                long maBN = Convert.ToInt64(txtMaBN.Text);
                decimal tongTien = Convert.ToDecimal(txtTongTien.Text);

                bool result = toaThuocBLL.ThanhToan(maBN, tongTien);
                if (result)
                {
                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadToaThuoc(); 
                }
                else
                {
                    MessageBox.Show("Thanh toán không thành công. Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
