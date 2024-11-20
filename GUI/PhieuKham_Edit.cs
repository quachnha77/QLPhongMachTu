using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class PhieuKham_Edit : UserControl
    {
        private LichKham lichKham;
        private BenhNhan benhNhan;
        private User user;
        private PhieuKham phieuKham;
        private List<PhieuKham> phieuKhamList;
        private PhieuKhamBLL phieuKhamBll = new PhieuKhamBLL();
        
        public PhieuKham_Edit(LichKham lichKham, BenhNhan benhNhan, User user)
        {
            InitializeComponent();
            this.lichKham = lichKham;
            this.benhNhan = benhNhan;
            this.user = user;
            phieuKham = phieuKhamBll.GetByMaLK(lichKham.MaLK);
            // Lấy tất cả phiếu khám theo mã bệnh nhân.
            phieuKhamList = phieuKhamBll.GetAllByMaBN(benhNhan.MaSo);
            InitializeInfomation();
        }

        private void InitializeInfomation()
        {
            txtMaBN.Text = benhNhan.MaSo.ToString();
            txtCCCD.Text = benhNhan.CCCD.ToString();
            txtHoTen.Text = benhNhan.HoTen;
            txtNgaySinh.Text = benhNhan.NgaySinh.ToString("dd/MM/yyyy");
            txtGioiTinh.Text = benhNhan.GioiTinh;
            txtDiaChi.Text = benhNhan.DiaChi;
            txtSoDienThoai.Text = benhNhan.SDT;

            txtMaPK.Text = phieuKham.MaPK.ToString();
            txtSTT.Text = phieuKham.SoThuTu.ToString();
            txtNgayKham.Text = phieuKham.NgayKham.ToString("dd/MM/yyyy");
            txtTrieuChung.Text = phieuKham.TrieuChung;
            txtChuanDoan.Text = phieuKham.ChuanDoan;
            txtTienSuBenhLy.Text = phieuKham.TieuSuBenhLy;
            // txtLoiDanBacSi.Text = phieuKham.LoiDanBacSi;

            // dataGridView1.DataSource = phieuKhamList;
            insertHelper(phieuKhamList);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = false;
            dataGridView1.MultiSelect = false;
            // int index = 0;
            // for (int i = 0; i < dataGridView1.Rows.Count; i++)
            // {
            //     if (Convert.ToInt64(dataGridView1.Rows[i].Cells[1].Value) == phieuKham.MaPK)
            //     {
            //         // Bỏ chọn tất cả các dòng
            //         dataGridView1.ClearSelection();
            //
            //         // Đặt dòng được chọn
            //         dataGridView1.Rows[i].Selected = true;
            //
            //         // Cuộn đến dòng đó (nếu cần)
            //         dataGridView1.FirstDisplayedScrollingRowIndex = i;
            //         return;
            //     }
            // }
            
        }
        
        private void insertHelper(List<PhieuKham> listPhieuKham)
        {
            int STT = 1;
            foreach (var pk in listPhieuKham)
            { // MaPK, NgayKham, TrieuChung, TienSuBenhLy, ChuanDoan, LoiDanBacSi
                // PhongKhoa khoa = khoaBLL.GetById(lk.BacSi.MaKhoa);
                int index = dataGridView1.Rows.Add();

                dataGridView1.Rows[index].Cells[0].Value = STT;
                dataGridView1.Rows[index].Cells[1].Value = pk.MaPK;
                dataGridView1.Rows[index].Cells[2].Value = pk.NgayKham.ToString("dd/MM/yyyy");
                dataGridView1.Rows[index].Cells[3].Value = pk.TrieuChung;
                dataGridView1.Rows[index].Cells[4].Value = pk.TieuSuBenhLy;
                dataGridView1.Rows[index].Cells[5].Value = pk.ChuanDoan;
                dataGridView1.Rows[index].Cells[6].Value = pk.LoiDanBacSi;
                
                dataGridView1.Rows[index].Cells[1].Tag = pk;
                STT += 1;
                if (Convert.ToInt64(dataGridView1.Rows[index].Cells[1].Value) == phieuKham.MaPK) ;
            }
        }

        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            KhamBenh khamBenhPnl = new KhamBenh(user ,benhNhan);
            var panelMain = this.FindForm();
            panelMain.Controls.Clear();
            khamBenhPnl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(khamBenhPnl);
            panelMain.Refresh();
        }
    }
}