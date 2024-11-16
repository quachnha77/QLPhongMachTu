using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using QLPhongMachTu_DOAN_.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class KhamBenh_LT : UserControl
    {
        private LichKhamBLL lichKhamBll = new LichKhamBLL();
        private BacSiBLL bacSiBll = new BacSiBLL();
        private KhoaBLL khoaBll = new KhoaBLL();
        private BenhNhanBLL benhNhanBll = new BenhNhanBLL();

        public KhamBenh_LT()
        {
            InitializeComponent();
            Innit();
            tatCaRd.Checked = true;
        }

        private void Innit()
        {
            gridView.ClearSelection();
            InsertAllDataGridView();
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.MultiSelect = false;
            
        }

        private void InsertAllDataGridView()
        {
            List<LichKham> lkList = lichKhamBll.GetAll();
            insertHelper(lkList);
        }

        private void insertHelper(List<LichKham> lkList)
        {
            int STT = 1; // Để STT bắt đầu từ 1
            foreach (var lk in lkList)
            {
                var bacSi = bacSiBll.GetById(lk.MaBS);
                var khoa = khoaBll.GetById(bacSi.MaKhoa);
                var benhNhan = benhNhanBll.GetById(lk.MaBN);
                var index = gridView.Rows.Add();

                gridView.Rows[index].Cells[0].Value = STT;
                gridView.Rows[index].Cells[1].Value = benhNhan.HoTen;
                gridView.Rows[index].Cells[2].Value = khoa.ChuyenKhoa;
                gridView.Rows[index].Cells[3].Value = bacSi.HoTen;
                gridView.Rows[index].Cells[4].Value = lk.NgayKham.ToString("dd/MM/yyyy");
                //gridView.Rows[index].Cells[5].Value = lk.TrieuChung;
                gridView.Rows[index].Cells[6].Value = lk.TrangThai.ToString(); // Hiển thị tên của enum

                // Gán đối tượng vào Tag cho việc sử dụng sau này
                gridView.Rows[index].Cells[0].Tag = lk;
                gridView.Rows[index].Cells[1].Tag = benhNhan;
                gridView.Rows[index].Cells[2].Tag = khoa;
                gridView.Rows[index].Cells[3].Tag = bacSi;

                STT++;
            }
        }


        private void chinhSuaBtn_Click(object sender, System.EventArgs e)
        {
            if (gridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa.");
                return;
            }
            var selectedRow = gridView.SelectedRows[0];
            
            LichKham lk = (LichKham)selectedRow.Cells[0].Tag;
            BenhNhan benhNhan = (BenhNhan)selectedRow.Cells[1].Tag;
            PhongKhoa khoa = (PhongKhoa)selectedRow.Cells[2].Tag;
            BacSi bs = (BacSi)selectedRow.Cells[3].Tag;
            // Mã số, ngày khám, triệu chứng, trạng thái, BN, BS

            KhamBenh_Edit_LT chinhSuaPnl = new KhamBenh_Edit_LT(lk, benhNhan, bs);
            var panelMain = this.FindForm();
            panelMain.Controls.Clear();
            chinhSuaPnl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(chinhSuaPnl);
            panelMain.Refresh();

        }

        private void InsertChuaKhamGridView()
        {
            List<LichKham> lkList = lichKhamBll.GetByTrangThai(ETrangThaiKham.ChuaKham);
            insertHelper(lkList);
        }

        private void InsertDaKhamGridView()
        {
            List<LichKham> lkList = lichKhamBll.GetByTrangThai(ETrangThaiKham.DaKham);
            insertHelper(lkList);
        }

        private void chuaKhamRd_Click(object sender, System.EventArgs e)
        {
            gridView.Rows.Clear();
            InsertChuaKhamGridView();
        }

        private void daKhamRd_Click(object sender, System.EventArgs e)
        {
            gridView.Rows.Clear();
            InsertDaKhamGridView();
        }

        private void tatCaRd_Click(object sender, System.EventArgs e)
        {
            gridView.Rows.Clear();
            InsertAllDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        { // Tìm theo ngày
            DateTime from = dateTimePicker1.Value;
            DateTime to = dateTimePicker2.Value;

            // Gọi BLL để tìm kiếm lịch khám
            List<LichKham> resultList = lichKhamBll.TimKiemTheoNgay(from, to);
            gridView.Rows.Clear();
            insertHelper(resultList);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            if (string.IsNullOrEmpty(str)) return;
            var result = lichKhamBll.TimKiem(str);
            gridView.Rows.Clear();
            insertHelper(result);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Tìm theo kết hợp
            DateTime from = dateTimePicker1.Value;
            DateTime to = dateTimePicker2.Value;
            string str = textBox1.Text;
            if (string.IsNullOrEmpty(str)) return;

            List<LichKham> result = lichKhamBll.TimKiemTheoNgayVaText(from, to, str);
            gridView.Rows.Clear();
            insertHelper(result);
        }
    }
}
