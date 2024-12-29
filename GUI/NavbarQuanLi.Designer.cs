namespace QLPhongMachTu_DOAN_.GUI
{
    partial class NavbarQuanLi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pnNhanVien = new System.Windows.Forms.Panel();
            this.txtNhanVien = new System.Windows.Forms.Label();
            this.txtLogo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnLichLamViec = new System.Windows.Forms.Panel();
            this.txtLichLamViec = new System.Windows.Forms.Label();
            this.pnThongKe = new System.Windows.Forms.Panel();
            this.txtThongKe = new System.Windows.Forms.Label();
            this.pnTaiKhoan = new System.Windows.Forms.Panel();
            this.txtTaiKhoan = new System.Windows.Forms.Label();
            this.pnDangXuat = new System.Windows.Forms.Panel();
            this.txtDangXuat = new System.Windows.Forms.Label();
            this.panel8.SuspendLayout();
            this.pnNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnLichLamViec.SuspendLayout();
            this.pnThongKe.SuspendLayout();
            this.pnTaiKhoan.SuspendLayout();
            this.pnDangXuat.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.LightCyan;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMain.Location = new System.Drawing.Point(220, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1076, 725);
            this.panelMain.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel8.Controls.Add(this.pnNhanVien);
            this.panel8.Controls.Add(this.txtLogo);
            this.panel8.Controls.Add(this.pictureBox1);
            this.panel8.Controls.Add(this.pnLichLamViec);
            this.panel8.Controls.Add(this.pnThongKe);
            this.panel8.Controls.Add(this.pnTaiKhoan);
            this.panel8.Controls.Add(this.pnDangXuat);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(219, 725);
            this.panel8.TabIndex = 2;
            // 
            // pnNhanVien
            // 
            this.pnNhanVien.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pnNhanVien.Controls.Add(this.txtNhanVien);
            this.pnNhanVien.Location = new System.Drawing.Point(0, 244);
            this.pnNhanVien.Margin = new System.Windows.Forms.Padding(2);
            this.pnNhanVien.Name = "pnNhanVien";
            this.pnNhanVien.Size = new System.Drawing.Size(219, 54);
            this.pnNhanVien.TabIndex = 2;
            this.pnNhanVien.Click += new System.EventHandler(this.NhanVien_Click);
            this.pnNhanVien.Paint += new System.Windows.Forms.PaintEventHandler(this.pnKhamBenh_Paint);
            // 
            // txtNhanVien
            // 
            this.txtNhanVien.AutoSize = true;
            this.txtNhanVien.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhanVien.ForeColor = System.Drawing.Color.DarkCyan;
            this.txtNhanVien.Location = new System.Drawing.Point(58, 16);
            this.txtNhanVien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtNhanVien.Name = "txtNhanVien";
            this.txtNhanVien.Size = new System.Drawing.Size(102, 23);
            this.txtNhanVien.TabIndex = 0;
            this.txtNhanVien.Text = "NHÂN VIÊN";
            this.txtNhanVien.Click += new System.EventHandler(this.NhanVien_Click);
            // 
            // txtLogo
            // 
            this.txtLogo.AutoSize = true;
            this.txtLogo.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogo.ForeColor = System.Drawing.Color.CadetBlue;
            this.txtLogo.Location = new System.Drawing.Point(77, 162);
            this.txtLogo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtLogo.Name = "txtLogo";
            this.txtLogo.Size = new System.Drawing.Size(79, 23);
            this.txtLogo.TabIndex = 3;
            this.txtLogo.Text = "MACINE";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QLPhongMachTu_DOAN_.Properties.Resources.duocthu;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(64, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pnLichLamViec
            // 
            this.pnLichLamViec.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pnLichLamViec.Controls.Add(this.txtLichLamViec);
            this.pnLichLamViec.Location = new System.Drawing.Point(0, 302);
            this.pnLichLamViec.Margin = new System.Windows.Forms.Padding(2);
            this.pnLichLamViec.Name = "pnLichLamViec";
            this.pnLichLamViec.Size = new System.Drawing.Size(219, 54);
            this.pnLichLamViec.TabIndex = 0;
            this.pnLichLamViec.Click += new System.EventHandler(this.LichLamViec_QL_Click);
            // 
            // txtLichLamViec
            // 
            this.txtLichLamViec.AutoSize = true;
            this.txtLichLamViec.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLichLamViec.ForeColor = System.Drawing.Color.DarkCyan;
            this.txtLichLamViec.Location = new System.Drawing.Point(47, 15);
            this.txtLichLamViec.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtLichLamViec.Name = "txtLichLamViec";
            this.txtLichLamViec.Size = new System.Drawing.Size(125, 23);
            this.txtLichLamViec.TabIndex = 1;
            this.txtLichLamViec.Text = "LỊCH LÀM VIỆC";
            this.txtLichLamViec.Click += new System.EventHandler(this.LichLamViec_QL_Click);
            // 
            // pnThongKe
            // 
            this.pnThongKe.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pnThongKe.Controls.Add(this.txtThongKe);
            this.pnThongKe.Location = new System.Drawing.Point(0, 360);
            this.pnThongKe.Margin = new System.Windows.Forms.Padding(2);
            this.pnThongKe.Name = "pnThongKe";
            this.pnThongKe.Size = new System.Drawing.Size(219, 54);
            this.pnThongKe.TabIndex = 1;
            this.pnThongKe.Click += new System.EventHandler(this.panel3_Click);
            // 
            // txtThongKe
            // 
            this.txtThongKe.AutoSize = true;
            this.txtThongKe.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThongKe.ForeColor = System.Drawing.Color.DarkCyan;
            this.txtThongKe.Location = new System.Drawing.Point(63, 15);
            this.txtThongKe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtThongKe.Name = "txtThongKe";
            this.txtThongKe.Size = new System.Drawing.Size(92, 23);
            this.txtThongKe.TabIndex = 3;
            this.txtThongKe.Text = "THỐNG KÊ";
            this.txtThongKe.Click += new System.EventHandler(this.panel3_Click);
            // 
            // pnTaiKhoan
            // 
            this.pnTaiKhoan.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pnTaiKhoan.Controls.Add(this.txtTaiKhoan);
            this.pnTaiKhoan.Location = new System.Drawing.Point(0, 418);
            this.pnTaiKhoan.Margin = new System.Windows.Forms.Padding(2);
            this.pnTaiKhoan.Name = "pnTaiKhoan";
            this.pnTaiKhoan.Size = new System.Drawing.Size(219, 54);
            this.pnTaiKhoan.TabIndex = 1;
            this.pnTaiKhoan.Click += new System.EventHandler(this.panel5_Click);
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.AutoSize = true;
            this.txtTaiKhoan.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaiKhoan.ForeColor = System.Drawing.Color.DarkCyan;
            this.txtTaiKhoan.Location = new System.Drawing.Point(60, 15);
            this.txtTaiKhoan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(99, 23);
            this.txtTaiKhoan.TabIndex = 4;
            this.txtTaiKhoan.Text = "TÀI KHOẢN";
            this.txtTaiKhoan.Click += new System.EventHandler(this.panel5_Click);
            // 
            // pnDangXuat
            // 
            this.pnDangXuat.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pnDangXuat.Controls.Add(this.txtDangXuat);
            this.pnDangXuat.Location = new System.Drawing.Point(0, 477);
            this.pnDangXuat.Margin = new System.Windows.Forms.Padding(2);
            this.pnDangXuat.Name = "pnDangXuat";
            this.pnDangXuat.Size = new System.Drawing.Size(219, 54);
            this.pnDangXuat.TabIndex = 1;
            this.pnDangXuat.Click += new System.EventHandler(this.DangXuat_Click);
            // 
            // txtDangXuat
            // 
            this.txtDangXuat.AutoSize = true;
            this.txtDangXuat.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDangXuat.ForeColor = System.Drawing.Color.DarkCyan;
            this.txtDangXuat.Location = new System.Drawing.Point(57, 15);
            this.txtDangXuat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtDangXuat.Name = "txtDangXuat";
            this.txtDangXuat.Size = new System.Drawing.Size(104, 23);
            this.txtDangXuat.TabIndex = 5;
            this.txtDangXuat.Text = "ĐĂNG XUẤT";
            this.txtDangXuat.Click += new System.EventHandler(this.DangXuat_Click);
            // 
            // NavbarQuanLi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 725);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panelMain);
            this.MaximizeBox = false;
            this.Name = "NavbarQuanLi";
            this.Text = "NavbarQuanLi";
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.pnNhanVien.ResumeLayout(false);
            this.pnNhanVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnLichLamViec.ResumeLayout(false);
            this.pnLichLamViec.PerformLayout();
            this.pnThongKe.ResumeLayout(false);
            this.pnThongKe.PerformLayout();
            this.pnTaiKhoan.ResumeLayout(false);
            this.pnTaiKhoan.PerformLayout();
            this.pnDangXuat.ResumeLayout(false);
            this.pnDangXuat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel pnNhanVien;
        private System.Windows.Forms.Label txtNhanVien;
        private System.Windows.Forms.Label txtLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnLichLamViec;
        private System.Windows.Forms.Label txtLichLamViec;
        private System.Windows.Forms.Panel pnThongKe;
        private System.Windows.Forms.Label txtThongKe;
        private System.Windows.Forms.Panel pnTaiKhoan;
        private System.Windows.Forms.Label txtTaiKhoan;
        private System.Windows.Forms.Panel pnDangXuat;
        private System.Windows.Forms.Label txtDangXuat;
    }
}