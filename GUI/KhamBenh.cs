using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class KhamBenh : UserControl
    {
        public KhamBenh(User user, BenhNhan benhNhan)
        {
            InitializeComponent();
            
            hoTenTxt.Text = benhNhan.HoTen;
            CCCDTxt.Text = benhNhan.CCCD.ToString();
            SDTTxt.Text = benhNhan.SDT != null? benhNhan.SDT.ToString() : "";

            // Readonly
            hoTenTxt.Enabled = false;
            CCCDTxt.Enabled = false;
            SDTTxt.Enabled = false;
        }

        // Đăng ký phiếu khám
        private void button1_Click(object sender, EventArgs e)
        {// Test
            Console.WriteLine("Hello");
            PhieuKhamBLL bll = new PhieuKhamBLL();
            var list = bll.GetAll();
            foreach(var pt in list)
            {
                Console.WriteLine(pt.ChuanDoan);
            }
        }
    }
}
