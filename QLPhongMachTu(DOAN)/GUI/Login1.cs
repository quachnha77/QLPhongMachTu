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
    public partial class Login1 : UserControl
    {
        public Login1()
        {
            InitializeComponent();
        }

        private void lbBanChuaCoTaiKhoan_Click(object sender, EventArgs e)
        {
            // Clear existing controls in panel1
            panel1.Controls.Clear();

            // Create a new instance of the LoginControl (UserControl)
            SignUp signUpControl = new SignUp();

            // Set the DockStyle to Fill so it takes up the entire panel
            signUpControl.Dock = DockStyle.Fill;

            // Add the UserControl to panel1
            panel1.Controls.Add(signUpControl);

            // Optionally refresh the panel to ensure everything is rendered
            panel1.Refresh();
        }
    }
}
