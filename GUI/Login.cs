using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            // Clear existing controls in panel1
            panel1.Controls.Clear();

            // Create a new instance of the LoginControl (UserControl)
            Login1 loginControl = new Login1();

            // Set the DockStyle to Fill so it takes up the entire panel
            loginControl.Dock = DockStyle.Fill;

            // Add the UserControl to panel1
            panel1.Controls.Add(loginControl);

            // Optionally refresh the panel to ensure everything is rendered
            panel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lbBanChuaCoTaiKhoan_Click(object sender, EventArgs e)
        {
            // Remove the current login control
            this.Controls.Clear();

            // Load the SignUpControl
            SignUp signUp = new SignUp();
            signUp.Dock = DockStyle.Fill; // Optional, to make it fill the container
            this.Controls.Add(signUp);
        }
    }
}
