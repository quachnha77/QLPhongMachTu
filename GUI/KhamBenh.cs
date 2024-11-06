using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class KhamBenh : UserControl
    {
        private User user;
        private BenhNhan benhNhan;

        private PhanCongBLL phanCongBLL = new PhanCongBLL();
        private KhoaBLL khoaBLL = new KhoaBLL();
        private BacSiBLL bacSiBLL = new BacSiBLL();
        public KhamBenh(User user, BenhNhan benhNhan)
        {
            this.user = user; this.benhNhan = benhNhan;
            InitializeComponent();
            InserData();
            
            hoTenTxt.Text = benhNhan.HoTen;
            SDTTxt.Text = benhNhan.SDT != null? benhNhan.SDT.ToString() : "";

            // Readonly
            hoTenTxt.Enabled = false;
            SDTTxt.Enabled = false;
        }

        // Đăng ký phiếu khám
        private void button1_Click(object sender, EventArgs e)
        {
            //LichKham lichKham = new LichKham();
            //lichKham.MaBN = 1;
            //lichKham.MaBS = 7;
            //lichKham.MaNV = 1;
            //lichKham.
        }

        // Chọn các bác sĩ có trong chuyên khoa
        public void ShowAvailableDoctor(long khoaId)
        {
            List<BacSi> bacSiList = bacSiBLL.GetAllByChuyenKhoa(khoaId);
            ComboBox cmbTemp = new ComboBox();
            foreach(var bacsi in bacSiList)
            {
                cmbTemp.Items.Add(bacsi);
            }
            comboBox1 = cmbTemp;
        }

        // Chọn các ngày hẹn
        private void ShowAvailableDate(long khoaId)
        {

        }

        private void chuyenKhoaSlt_DropDownClosed(object sender, EventArgs e)
        {
            string chuyenKhoa = (string)chuyenKhoaSlt.SelectedItem;
            if (chuyenKhoa != null)
            {
                // Lấy phòng khoa theo chuyên khoa
                PhongKhoa khoa = khoaBLL.GetByChuyenKhoa(chuyenKhoa);
                ShowAvailableDoctor(khoa.MaPK);
                ShowAvailableDate(khoa.MaPK);
            }
        }

        // Đổ dữ liệu vào combobox
        private void InserData()
        {
            List<PhongKhoa> chuyenKhoaList = khoaBLL.GetAll();
            foreach(var khoa in chuyenKhoaList)
            {
                chuyenKhoaSlt.Items.Add(khoa.ChuyenKhoa);
            }
        }
    }
}
