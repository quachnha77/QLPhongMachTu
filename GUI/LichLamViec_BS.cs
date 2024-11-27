using Microsoft.EntityFrameworkCore.Diagnostics;
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
    public partial class LichLamViec_BS : Form
    {
        private BacSi bacSi;

        private List<LichPhanCong> ds_lpc;
        private PhanCongBLL phanCongBLL;
        private BacSiBLL bacSiBLL;
        private PhongKhoaBLL phongKhoaBLL;

        public LichLamViec_BS(BacSi bacSi)
        {
            phanCongBLL = new PhanCongBLL();
            bacSiBLL = new BacSiBLL();
            phongKhoaBLL = new PhongKhoaBLL();
            this.bacSi = bacSi;

            InitializeComponent();
            radioButton2.Checked = true;

            LoadDataAll();
        }
        public void LoadDataAll()
        {
            dataGridView1.Rows.Clear();
            List<LichPhanCong> ds_lpc = phanCongBLL.GetAll();
            List<BacSi> ds_bs = bacSiBLL.GetAll();
            List<PhongKhoa> ds_pk = phongKhoaBLL.GetAll();
            int index = 1;

            foreach (var lpc in ds_lpc)
            {
                var bs = ds_bs.FirstOrDefault(_bs => _bs.MaSo == lpc.MaBS);
                var pk = ds_pk.FirstOrDefault(_pk => _pk.MaPK == bs.MaKhoa);
                if (bs != null && pk != null)
                {
                    int rowIndex = dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowIndex].Cells[0].Value = lpc.MaLPC;
                    dataGridView1.Rows [rowIndex].Cells[1].Value = bs.HoTen;
                    dataGridView1.Rows[rowIndex].Cells[2].Value = lpc.NgayThucHien.ToString("dd/MM/yyyy");
                    dataGridView1.Rows[rowIndex].Cells[3].Value = lpc.ThoiGian.ToString("HH:mm"); // CaLam
                    dataGridView1.Rows[rowIndex].Cells[4].Value = pk.ChuyenKhoa;    // ChuyenKhoa
                    dataGridView1.Rows[rowIndex].Cells[5].Value = lpc.GhiChu;
                    dataGridView1.Rows[rowIndex].Cells[6].Value = "Active";     // TrangThai
                    index++;
                }
            }
        }
        public void LoadDataSelf()
        {
            dataGridView1.Rows.Clear();
            List<LichPhanCong> ds_lpc = phanCongBLL.GetAllPhanCongByMaBacSi(LoggedInUser.CurrentUser.MaUser); // get all LPC = MaUser cua bs
            //BacSi bs = bacSiBLL.GetById(LoggedInUser.CurrentUser.MaUser); // get all thong tin cua User (bacsi)
            int index = 1;

            foreach (var lpc in ds_lpc)
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells[0].Value = index;
                dataGridView1.Rows[rowIndex].Cells[1].Value = lpc.NgayThucHien.ToString("dd/MM/yyyy");
                dataGridView1.Rows[rowIndex].Cells[2].Value = lpc.ThoiGian.ToString("HH:mm"); // CaLam
                dataGridView1.Rows[rowIndex].Cells[3].Value = bacSi.MaKhoa; // ChuyenKhoa, bacSi duoc truyen tu constructor vao
                dataGridView1.Rows[rowIndex].Cells[4].Value = lpc.GhiChu;
                dataGridView1.Rows[rowIndex].Cells[5].Value = "Active";     // TrangThai
                index++;
            }
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

        private void button1_Click(object sender, EventArgs e) // Yeu Cau Huy Lich
        {

        }

        private void button2_Click(object sender, EventArgs e) // Cham Cong
        {

        }
    }
}
