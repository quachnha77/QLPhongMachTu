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
        public SignUp()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            //// Clear existing controls in panel12
            //panel12.Controls.Clear();

            //// Create a new instance of the Login Form
            //Login loginForm = new Login();

            //// Set it to non-top-level so it can be added to a panel
            //loginForm.TopLevel = false;
            //loginForm.FormBorderStyle = FormBorderStyle.None;
            //loginForm.Dock = DockStyle.Fill;

            //// Add the form to the panel
            //panel12.Controls.Add(loginForm);

            //// Show the form inside the panel
            //loginForm.Show();
            this.Hide();

            Login lg = new Login();
            lg.Show();
            
        }


        private void SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
