using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class LichLamViec_BS : UserControl
    {
        private BacSi bacSi;

        private List<LichPhanCong> ds_lpc;
        private PhanCongBLL phanCongBLL;
        private BacSiBLL bacSiBLL;
        private LichKhamBLL lichKhamBLL;
        private KhoaBLL khoaBLL;

        public LichLamViec_BS(BacSi bacSi)
        {
            phanCongBLL = new PhanCongBLL();
            bacSiBLL = new BacSiBLL();
            lichKhamBLL = new LichKhamBLL();
            khoaBLL = new KhoaBLL();
            this.bacSi = bacSi;

            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            radioButton2.Checked = true;

            SetDefaultView();
        }


        private void SetDefaultView()
        {
            if (radioButton2.Checked)
            {
                LoadDataSelf();
            }
            else if (radioButton3.Checked)
            {
                LoadDataAll();
            }
        }

        private void LoadDataAll()
        {
            dataGridView1.Rows.Clear();
            var dsLPC = phanCongBLL.GetAll();
            var dsBS = bacSiBLL.GetAll();
            var dsPK = khoaBLL.GetAll();
            int index = 1;

            foreach (var lpc in dsLPC)
            {
                //var bs = dsBS.Find(_bs => _bs.MaSo == lpc.MaBS);
                //var pk = dsPK.Find(_pk => _pk.MaPK == bacSi.MaKhoa);

                //if (bs != null && pk != null)
                //{
                    AddRowToGrid(lpc, khoaBLL.GetChuyenKhoaByMaBS(bacSi.MaSo), index++);
                //}
            }
        }

        public void LoadDataSelf()
        {
            dataGridView1.Rows.Clear();
            var dsLPC = phanCongBLL.GetAllPhanCongByMaBacSi(bacSi.MaSo);
            var chuyenKhoa = khoaBLL.GetChuyenKhoaByMaBS(bacSi.MaSo);
            int index = 1;

            foreach (var lpc in dsLPC)
            {
                AddRowToGrid(lpc, chuyenKhoa, index++);
            }
        }

        private void AddRowToGrid(LichPhanCong lpc, string chuyenKhoa, int index)
        {
            int rowIndex = dataGridView1.Rows.Add();
            dataGridView1.Rows[rowIndex].Cells[0].Value = index; // Index
            dataGridView1.Rows[rowIndex].Cells[1].Value = lpc.NgayThucHien.ToString("dd/MM/yyyy"); // Ngày Thực Hiện
            dataGridView1.Rows[rowIndex].Cells[2].Value = chuyenKhoa; // Chuyên Khoa
            dataGridView1.Rows[rowIndex].Cells[3].Value = lpc.GhiChu; // Ghi Chú
            //dataGridView1.Rows[rowIndex].Cells[4].Value = "Active"; // Trạng Thái

            //dataGridView1.Rows[rowIndex].Cells[3].Value = lpc.ThoiGian.ToString("HH:mm"); // Ca Làm
            //dataGridView1.Rows[rowIndex].Cells[0].Tag = lpc;
            //dataGridView1.Rows[rowIndex].Cells[1].Value = bs.HoTen; // Họ Tên

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                LoadDataSelf();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                LoadDataAll();
            }
        }

        //private void button1_Click(object sender, EventArgs e) // Yeu Cau Huy Lich
        //{
        //    if (dataGridView1.Rows.Count == 0)
        //    {
        //        MessageBox.Show("Vui lòng chọn một lịch hẹn để hủy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    // Lấy lịch phân công từ dòng đã chọn trong dataGridView
        //    LichPhanCong lichPhanCong = (LichPhanCong)dataGridView1.SelectedRows[0].Cells[0].Tag;

        //    // Lấy lịch khám liên kết với lịch phân công.
        //    LichKhamDTO lichKham = lichKhamBLL.GetByMaLK(lichPhanCong.MaLK);
        //    if (lichKham == null)
        //    {
        //        MessageBox.Show("Không tìm thấy lịch khám liên kết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    //if (lichKham.TrangThai == Enums.ETrangThaiKham.HuyKham)
        //    //{
        //    //    MessageBox.Show("Lịch khám này đã bị hủy trước đó.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //    return;
        //    //}

        //    //// Xác nhận hủy lịch
        //    //DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy lịch khám này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    //if (result == DialogResult.Yes)
        //    //{
        //    //    lichKham.TrangThai = Enums.ETrangThaiKham.HuyKham;

        //    //    bool updateResult = lichKhamBLL.UpdateTrangThai(lichKham);
        //    //    if (updateResult)
        //    //    {
        //    //        MessageBox.Show("Hủy lịch khám thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //        LoadDataSelf(); // Tải lại dữ liệu sau khi hủy thành công
        //    //    }
        //    //    else
        //    //    {
        //    //        MessageBox.Show("Hủy lịch khám thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //    }
        //    //}
        //}

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void LichLamViec_BS_Load(object sender, EventArgs e)
        {

        }
    }
}
