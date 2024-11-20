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
        private List<LichPhanCong> ds_lpc;
        private PhanCongBLL phanCongBLL;
        private BacSiBLL bacSiBLL;

        public LichLamViec_BS()
        {
            phanCongBLL = new PhanCongBLL();
            bacSiBLL = new BacSiBLL();

            InitializeComponent();
            radioButton2.Checked = true;

            LoadDataAll();
        }
        public void LoadDataAll()
        {
            dataGridView1.Rows.Clear();
            List<LichPhanCong> ds_lpc = phanCongBLL.GetAll();
            List<BacSi> ds_bs = bacSiBLL.GetAll();
            int index = 1;

            foreach (var lpc in ds_lpc)
            {
                var bs = ds_bs.FirstOrDefault(_bs => _bs.MaSo == lpc.MaBS);
                if (bs != null)
                {
                    int rowIndex = dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowIndex].Cells[0].Value = index;
                    dataGridView1.Rows[rowIndex].Cells[1].Value = lpc.NgayThucHien;
                    dataGridView1.Rows[rowIndex].Cells[2].Value = lpc.ThoiGian; // CaLam
                    dataGridView1.Rows[rowIndex].Cells[3].Value = bs.MaKhoa;    // ChuyenKhoa
                    dataGridView1.Rows[rowIndex].Cells[4].Value = lpc.GhiChu;
                    dataGridView1.Rows[rowIndex].Cells[5].Value = "Active";     // TrangThai
                    index++;
                }
            }
        }
        public void LoadDataSelf(BacSi bs)
        {
            dataGridView1.Rows.Clear();
            

            
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataSelf();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataAll();
        }
    }
}
