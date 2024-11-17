using QLPhongMachTu_DOAN_.BLL;
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
    }
}
