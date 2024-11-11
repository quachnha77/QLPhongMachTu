using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
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
        private bool isClearingRows = false;

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
            int STT = 0;
            foreach (var lk in lkList)
            {
                var bacSi = bacSiBll.GetById(lk.MaBS);
                var khoa = khoaBll.GetById(bacSi.MaKhoa);
                var benhNhan = benhNhanBll.GetById(lk.MaBN);
                var index = gridView.Rows.Add();
                gridView.Rows[index].Cells[0].Value = STT;
                gridView.Rows[index].Cells[1].Value = benhNhan.HoTen;
                //gridView.Rows[index].Cells[2].Value = bacSi.HoTen;
                gridView.Rows[index].Cells[2].Value = khoa.ChuyenKhoa; // khoa theo bac si
                gridView.Rows[index].Cells[3].Value = lk.NgayKham;
                gridView.Rows[index].Cells[4].Value = lk.TrieuChung;
                gridView.Rows[index].Cells[5].Value = lk.TrangThai;

                gridView.Rows[index].Cells[0].Tag = lk;
                gridView.Rows[index].Cells[1].Tag = benhNhan;
                gridView.Rows[index].Cells[2].Tag = khoa;
            }
        }

        private void gridView_SelectionChanged(object sender, System.EventArgs e)
        {
            if (isClearingRows || gridView.SelectedRows.Count == 0) return;

            var selectedRow = gridView.SelectedRows[0];

            BenhNhan benhNhan = (BenhNhan)selectedRow.Cells[1].Tag;
            PhongKhoa khoa = (PhongKhoa)selectedRow.Cells[2].Tag;

            maBNTxt.Text = benhNhan.MaSo.ToString();
            CCCDTxt.Text = benhNhan.CCCD.ToString();
            hotTenTxt.Text = benhNhan.HoTen;
            ngaySinhTxt.Text = benhNhan.NgaySinh.ToString("dd/MM/yyyy");
            gioiTinhTxt.Text = benhNhan.GioiTinh;
            diaChiTxt.Text = benhNhan.DiaChi;
            sdtTxt.Text = benhNhan.SDT;
            chuyenKhoaTxt.Text = khoa.ChuyenKhoa;
            ngayHenTxt.Text = selectedRow.Cells[3].Value.ToString();
            yeuCauTxt.Text = selectedRow.Cells[4].Value.ToString();


        }

        private void chinhSuaBtn_Click(object sender, System.EventArgs e)
        {
            if (gridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa.");
                return;
            }

            var selectedRow = gridView.SelectedRows[0];
            var lichKham = (LichKham)selectedRow.Cells[0].Tag; // Dữ liệu LichKham từ Tag

            // Cập nhật thông tin lịch khám
            lichKham.NgayKham = DateTime.TryParse(ngayHenTxt.Text, out DateTime ngayHen) ? ngayHen : lichKham.NgayKham;
            lichKham.TrieuChung = yeuCauTxt.Text;

            // Gọi phương thức cập nhật BLL để lưu dữ liệu
            //lichKhamBll.SuaLichKham(lichKham.MaLK, );

            MessageBox.Show("Thông tin đã được cập nhật.");

            // Làm mới hiển thị dữ liệu trên lưới
            isClearingRows = true;
            gridView.Rows.Clear();
            InsertAllDataGridView();
            isClearingRows = false;
        }

            private void InsertChuaKhamGridView()
        {
            List<LichKham> lkList = lichKhamBll.GetByTrangThai("Chưa khám");
            insertHelper(lkList);
        }

        private void InsertDaKhamGridView()
        {
            List<LichKham> lkList = lichKhamBll.GetByTrangThai("Đã khám");
            insertHelper(lkList);
        }

        private void chuaKhamRd_Click(object sender, System.EventArgs e)
        {
            isClearingRows = true;
            gridView.Rows.Clear();
            InsertChuaKhamGridView();
            isClearingRows = false;
        }

        private void daKhamRd_Click(object sender, System.EventArgs e)
        {
            isClearingRows = true;
            gridView.Rows.Clear();
            InsertDaKhamGridView();
            isClearingRows = false;
        }

        private void tatCaRd_Click(object sender, System.EventArgs e)
        {
            isClearingRows = true;
            gridView.Rows.Clear();
            InsertAllDataGridView();
            isClearingRows = false;
            ClearData();
        }

        private void ClearData()
        {
            maBNTxt.Text = "";
            CCCDTxt.Text = "";
            hotTenTxt.Text = "";
            ngaySinhTxt.Text = "";
            gioiTinhTxt.Text = "";
            diaChiTxt.Text = "";
            sdtTxt.Text = "";
            chuyenKhoaTxt.Text = "";
            ngayHenTxt.Text = "";
            yeuCauTxt.Text = "";
        }
    }
}
