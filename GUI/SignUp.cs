using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using QLPhongMachTu_DOAN_.Enums;
using System;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class SignUp : UserControl
    {
        private readonly UserBLL userBLL;
        private readonly BenhNhanBLL benhNhanBLL;
        private readonly PhanQuyenBLL phanQuyenBLL;

        public SignUp()
        {
            InitializeComponent();
            userBLL = new UserBLL();
            benhNhanBLL = new BenhNhanBLL();
            phanQuyenBLL = new PhanQuyenBLL();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.ShowLoginPanel();
        }

        private void ShowLoginPanel()
        {
            // Clear existing controls in panel1
            panel12.Controls.Clear();

            // Create a new instance of the LoginControl (UserControl)
            Login1 loginControl = new Login1();

            // Set the DockStyle to Fill so it takes up the entire panel
            loginControl.Dock = DockStyle.Fill;

            // Add the UserControl to panel1
            panel12.Controls.Add(loginControl);

            // Optionally refresh the panel to ensure everything is rendered
            panel12.Refresh();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }


        private void dangKyBtn_Click(object sender, EventArgs e)
        {
            string userName = userNameTxt.Text;
            string matKhau = passwordTxt.Text;
            string email = emailTxt.Text;
            string hoTen = hoTenTxt.Text;
            long cccd = long.Parse(CCCDTxt.Text);

            var maQuyen = (long) EQuyen.BENHNHAN;
            //var quyen = phanQuyenBLL.GetByMaPQ(maQuyen);

            User userTemp = new User()
            {
                Username = userName,
                Password = matKhau,
                Email = email,
                MaPQ = maQuyen
            };

            var newUser = userBLL.CreateUser(userTemp);

            BenhNhan benhNhan = new BenhNhan()
            {
                HoTen = hoTen,
                CCCD = cccd,
                MaUser = newUser.MaUser,
            };

            var result = benhNhanBLL.Create(benhNhan);
            if(result != null)
            { 
                MessageBox.Show("Tạo User thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ShowLoginPanel();
            }
            else
            {
                MessageBox.Show("Tạo User thất bại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
