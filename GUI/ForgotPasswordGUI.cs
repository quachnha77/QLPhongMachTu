using QLPhongMachTu_DOAN_.BLL;
using System;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class ForgotPasswordGUI : Form
    {
        private readonly UserBLL userBLL;
        private string otp;

        public ForgotPasswordGUI()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            txtOTP.Enabled = false;
            userBLL = new UserBLL();
        }

        private void btnOTP_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (userBLL.IsEmailExist2(email))
            {
                GenerateAndSendOTP(email);
                MessageBox.Show("Mã OTP đã được gửi đến email của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOTP.Enabled = true;
            }
            else
            {
                MessageBox.Show("Email không tồn tại trong hệ thống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (VerifyOTP(otp))
            {
                ResetPassword resetPassword = new ResetPassword();
                resetPassword.SetData(txtEmail.Text.Trim());
                resetPassword.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Mã OTP không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức tạo và gửi OTP
        public void GenerateAndSendOTP(string email)
        {
            otp = GenerateOTP();
            SendEmail(email, otp);
        }

        // Phương thức tạo OTP ngẫu nhiên
        private string GenerateOTP()
        {
            Random rand = new Random();
            int otp = rand.Next(100000, 999999); // Tạo OTP ngẫu nhiên
            return otp.ToString();
        }

        // Phương thức gửi email với OTP
        private void SendEmail(string email, string otp)
        {
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string emailFrom = "builebichnhung123@gmail.com";
            string emailPassword = "lzqk bdhu zsvj rimc";

            try
            {
                // Tạo đối tượng SmtpClient để gửi email
                using (SmtpClient smtpClient = new SmtpClient(smtpServer))
                {
                    smtpClient.Port = smtpPort;
                    smtpClient.Credentials = new NetworkCredential(emailFrom, emailPassword);
                    smtpClient.EnableSsl = true;

                    // Tạo email
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(emailFrom);
                    message.To.Add(new MailAddress(email));
                    message.Subject = "Mã OTP";
                    message.Body = $"Mã OTP của bạn là: {otp}";

                    // Gửi email
                    smtpClient.Send(message);
                    Console.WriteLine($"Gửi OTP {otp} tới email {email}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi gửi email: {ex.Message}");
            }
        }

        // Phương thức xác nhận OTP
        public bool VerifyOTP(string otp)
        {
            string OTP = txtOTP.Text.Trim();
            // Kiểm tra nếu OTP tồn tại trong bộ nhớ và so sánh với OTP người dùng nhập vào
            if (OTP == otp)
            {
                return true;
            }

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
