using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using QLPhongMachTu_DOAN_.Enums;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class ThanhToan : UserControl
    {
        private readonly BenhNhan benhNhan;
        private readonly User user;

        private readonly HoaDonKhamBenhBLL hoaDonBll = new HoaDonKhamBenhBLL();
        
        public ThanhToan(User user, BenhNhan benhNhan)
        {
            InitializeComponent();
            this.benhNhan = benhNhan;
            this.user = user;

            InitializeInfomation();
        }

        private void InitializeInfomation()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            insertHelper(hoaDonBll.GetAllByMaBN(benhNhan.MaSo));

            comboBox2.Items.Add("Tổng tiền");
            comboBox2.Items.Add("Trạng thái");
            comboBox2.SelectedIndex = 0;
        }

        private void insertHelper(List<DTO.HoaDonKhamBenh> hList)
        {
            foreach (DTO.HoaDonKhamBenh hoaDonKhamBenh in hList)
            { // MaHD, NgayTao, LoaiHoaDon, MaPK, TongTien, TrangThai
                int index = dataGridView1.Rows.Add();

                dataGridView1.Rows[index].Cells[0].Value = hoaDonKhamBenh.MaHDKB;
                dataGridView1.Rows[index].Cells[1].Value = "None";
                dataGridView1.Rows[index].Cells[2].Value = "None";
                dataGridView1.Rows[index].Cells[3].Value = hoaDonKhamBenh.MaPK;
                dataGridView1.Rows[index].Cells[4].Value = hoaDonKhamBenh.TongTien;
                dataGridView1.Rows[index].Cells[5].Value = hoaDonKhamBenh.TrangThai;
                
                dataGridView1.Rows[index].Cells[0].Tag = hoaDonKhamBenh;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        { // Thanh toans
            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn nào để thanh toán.", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];
            DTO.HoaDonKhamBenh hoaDon = (DTO.HoaDonKhamBenh)selectedRow.Cells[0].Tag;
            if (hoaDon.TrangThai == ETrangThaiHoaDon.DaThanhToan)
            {
                MessageBox.Show("Hóa đơn khám bệnh này đã được thanh toán.", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var xacNhanSoTien = MessageBox.Show("Số tiền thanh toán: " + hoaDon.TongTien, "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (xacNhanSoTien != DialogResult.Yes) return;
            
            var isSuccess = hoaDonBll.ThanhToanHoaDon(hoaDon.MaHDKB);
            if (isSuccess)
            {
                MessageBox.Show("Hóa đơn thanh toán thành công.", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                List<DTO.HoaDonKhamBenh> updatedList = hoaDonBll.GetAllByMaBN(benhNhan.MaSo);
                dataGridView1.Rows.Clear();
                insertHelper(updatedList);
            } 
            else
                MessageBox.Show("Đã có lỗi xẩy ra, vui lòng thanh toán lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button5_Click(object sender, EventArgs e)
        { // Làm mới
            List<DTO.HoaDonKhamBenh> updatedList = hoaDonBll.GetAllByMaBN(benhNhan.MaSo);
            dataGridView1.Rows.Clear();
            insertHelper(updatedList);
        }


        private void button4_Click(object sender, EventArgs e)
        { // Xem chi tiết hóa đơn
            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn nào.", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];
            DTO.HoaDonKhamBenh hoaDon = (DTO.HoaDonKhamBenh)selectedRow.Cells[0].Tag;
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        { // Tim kiêsm comboBox
            int selectedIndex = comboBox2.SelectedIndex;

            List<DTO.HoaDonKhamBenh> resultList = new List<DTO.HoaDonKhamBenh>();
            switch (selectedIndex)
            {
                case 0:
                    string tongSoTien = textBox1.Text;
                    resultList = hoaDonBll.TimKiemByTongTien(tongSoTien);
                    dataGridView1.Rows.Clear();
                    insertHelper(resultList);
                    return;
                case 1:
                    resultList = hoaDonBll.TimKiemByTrangThai("D");
                    dataGridView1.Rows.Clear();
                    insertHelper(resultList);
                    return;
            }
        }
    }
}
