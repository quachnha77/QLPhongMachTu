using System.Windows.Forms;

namespace GUI
{
    partial class DuocSi_KhoThuoc :Form
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePickerHSD = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.ChinhSua_button = new System.Windows.Forms.Button();
            this.Nhap_button = new System.Windows.Forms.Button();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtNhaCungCap = new System.Windows.Forms.TextBox();
            this.txtDonVi = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewKhoThuoc = new System.Windows.Forms.DataGridView();
            this.Mathuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhaCungCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.KhoThuoc = new System.Windows.Forms.Button();
            this.ToaThuocDonThuoc = new System.Windows.Forms.Button();
            this.ThanhToan = new System.Windows.Forms.Button();
            this.TaiKhoan = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKhoThuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePickerHSD);
            this.panel1.Controls.Add(this.dateTimePickerNgayNhap);
            this.panel1.Controls.Add(this.ChinhSua_button);
            this.panel1.Controls.Add(this.Nhap_button);
            this.panel1.Controls.Add(this.txtSoLuong);
            this.panel1.Controls.Add(this.txtNhaCungCap);
            this.panel1.Controls.Add(this.txtDonVi);
            this.panel1.Controls.Add(this.txtDonGia);
            this.panel1.Controls.Add(this.txtTen);
            this.panel1.Controls.Add(this.txtMa);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            // 
            // dateTimePickerHSD
            // 
            this.dateTimePickerHSD.Location = new System.Drawing.Point(0, 0);
            this.dateTimePickerHSD.Name = "dateTimePickerHSD";
            this.dateTimePickerHSD.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerHSD.TabIndex = 20;
            // 
            // dateTimePickerNgayNhap
            // 
            this.dateTimePickerNgayNhap.Location = new System.Drawing.Point(0, 0);
            this.dateTimePickerNgayNhap.Name = "dateTimePickerNgayNhap";
            this.dateTimePickerNgayNhap.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerNgayNhap.TabIndex = 19;
            // 
            // ChinhSua_button
            // 
            this.ChinhSua_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChinhSua_button.Location = new System.Drawing.Point(0, 0);
            this.ChinhSua_button.Name = "ChinhSua_button";
            this.ChinhSua_button.Size = new System.Drawing.Size(75, 23);
            this.ChinhSua_button.TabIndex = 18;
            this.ChinhSua_button.Text = "Chỉnh sửa";
            this.ChinhSua_button.UseVisualStyleBackColor = false;
            // 
            // Nhap_button
            // 
            this.Nhap_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Nhap_button.Location = new System.Drawing.Point(0, 0);
            this.Nhap_button.Name = "Nhap_button";
            this.Nhap_button.Size = new System.Drawing.Size(75, 23);
            this.Nhap_button.TabIndex = 17;
            this.Nhap_button.Text = "Nhập thuốc";
            this.Nhap_button.UseVisualStyleBackColor = false;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(0, 0);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(100, 20);
            this.txtSoLuong.TabIndex = 16;
            // 
            // txtNhaCungCap
            // 
            this.txtNhaCungCap.Location = new System.Drawing.Point(0, 0);
            this.txtNhaCungCap.Margin = new System.Windows.Forms.Padding(4);
            this.txtNhaCungCap.Name = "txtNhaCungCap";
            this.txtNhaCungCap.Size = new System.Drawing.Size(100, 20);
            this.txtNhaCungCap.TabIndex = 13;
            // 
            // txtDonVi
            // 
            this.txtDonVi.Location = new System.Drawing.Point(0, 0);
            this.txtDonVi.Margin = new System.Windows.Forms.Padding(4);
            this.txtDonVi.Name = "txtDonVi";
            this.txtDonVi.Size = new System.Drawing.Size(100, 20);
            this.txtDonVi.TabIndex = 12;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(0, 0);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(4);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(100, 20);
            this.txtDonGia.TabIndex = 11;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(0, 0);
            this.txtTen.Margin = new System.Windows.Forms.Padding(4);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(100, 20);
            this.txtTen.TabIndex = 10;
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(0, 0);
            this.txtMa.Margin = new System.Windows.Forms.Padding(4);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(100, 20);
            this.txtMa.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Số lượng ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Hạn sử dụng ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Ngày nhập ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nhà cung cấp ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Đơn vị ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewKhoThuoc);
            this.groupBox1.Controls.Add(this.txtTimKiem);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kho thuốc";
            // 
            // dataGridViewKhoThuoc
            // 
            this.dataGridViewKhoThuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewKhoThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKhoThuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mathuoc,
            this.TenThuoc,
            this.DonGia,
            this.DonVi,
            this.NhaCungCap,
            this.NgayNhap,
            this.HSD,
            this.SoLuong});
            this.dataGridViewKhoThuoc.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewKhoThuoc.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewKhoThuoc.Name = "dataGridViewKhoThuoc";
            this.dataGridViewKhoThuoc.ReadOnly = true;
            this.dataGridViewKhoThuoc.RowHeadersVisible = false;
            this.dataGridViewKhoThuoc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewKhoThuoc.Size = new System.Drawing.Size(240, 150);
            this.dataGridViewKhoThuoc.TabIndex = 14;
            // 
            // Mathuoc
            // 
            this.Mathuoc.HeaderText = "Mã thuốc";
            this.Mathuoc.Name = "Mathuoc";
            this.Mathuoc.ReadOnly = true;
            // 
            // TenThuoc
            // 
            this.TenThuoc.HeaderText = "Tên thuốc";
            this.TenThuoc.Name = "TenThuoc";
            this.TenThuoc.ReadOnly = true;
            // 
            // DonGia
            // 
            this.DonGia.HeaderText = "Đơn giá";
            this.DonGia.Name = "DonGia";
            this.DonGia.ReadOnly = true;
            // 
            // DonVi
            // 
            this.DonVi.HeaderText = "Đơn vị";
            this.DonVi.Name = "DonVi";
            this.DonVi.ReadOnly = true;
            // 
            // NhaCungCap
            // 
            this.NhaCungCap.HeaderText = "Nhà cung cấp ";
            this.NhaCungCap.Name = "NhaCungCap";
            this.NhaCungCap.ReadOnly = true;
            // 
            // NgayNhap
            // 
            this.NgayNhap.HeaderText = "Ngày nhập";
            this.NgayNhap.Name = "NgayNhap";
            this.NgayNhap.ReadOnly = true;
            // 
            // HSD
            // 
            this.HSD.HeaderText = "Hạn sử dụng";
            this.HSD.Name = "HSD";
            this.HSD.ReadOnly = true;
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số lượng tồn";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(0, 0);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(100, 20);
            this.txtTimKiem.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Tìm kiếm ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đơn giá ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên thuốc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã thuốc ";
            // 
            // KhoThuoc
            // 
            this.KhoThuoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KhoThuoc.Location = new System.Drawing.Point(0, 0);
            this.KhoThuoc.Margin = new System.Windows.Forms.Padding(4);
            this.KhoThuoc.Name = "KhoThuoc";
            this.KhoThuoc.Size = new System.Drawing.Size(75, 23);
            this.KhoThuoc.TabIndex = 17;
            this.KhoThuoc.Text = "KHO THUỐC";
            this.KhoThuoc.UseVisualStyleBackColor = false;
            // 
            // ToaThuocDonThuoc
            // 
            this.ToaThuocDonThuoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToaThuocDonThuoc.Location = new System.Drawing.Point(0, 0);
            this.ToaThuocDonThuoc.Margin = new System.Windows.Forms.Padding(4);
            this.ToaThuocDonThuoc.Name = "ToaThuocDonThuoc";
            this.ToaThuocDonThuoc.Size = new System.Drawing.Size(75, 23);
            this.ToaThuocDonThuoc.TabIndex = 18;
            this.ToaThuocDonThuoc.Text = "TOA THUỐC, ĐƠN THUỐC";
            this.ToaThuocDonThuoc.UseVisualStyleBackColor = false;
            // 
            // ThanhToan
            // 
            this.ThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThanhToan.Location = new System.Drawing.Point(0, 0);
            this.ThanhToan.Margin = new System.Windows.Forms.Padding(4);
            this.ThanhToan.Name = "ThanhToan";
            this.ThanhToan.Size = new System.Drawing.Size(75, 23);
            this.ThanhToan.TabIndex = 19;
            this.ThanhToan.Text = "THANH TOÁN ";
            this.ThanhToan.UseVisualStyleBackColor = false;
            // 
            // TaiKhoan
            // 
            this.TaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TaiKhoan.Location = new System.Drawing.Point(0, 0);
            this.TaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            this.TaiKhoan.Name = "TaiKhoan";
            this.TaiKhoan.Size = new System.Drawing.Size(75, 23);
            this.TaiKhoan.TabIndex = 20;
            this.TaiKhoan.Text = "TÀI KHOẢN ";
            this.TaiKhoan.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(0, 0);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 21;
            this.button5.Text = "ĐĂNG XUẤT ";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // textBox10
            // 
            this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox10.Location = new System.Drawing.Point(0, 0);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 13);
            this.textBox10.TabIndex = 22;
            this.textBox10.Text = "MACINE";
            // 
            // DuocSi_KhoThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.TaiKhoan);
            this.Controls.Add(this.ThanhToan);
            this.Controls.Add(this.ToaThuocDonThuoc);
            this.Controls.Add(this.KhoThuoc);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DuocSi_KhoThuoc";
            this.Text = "Dược Sĩ ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKhoThuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDonVi;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridViewKhoThuoc;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtNhaCungCap;
        private System.Windows.Forms.Button KhoThuoc;
        private System.Windows.Forms.Button ToaThuocDonThuoc;
        private System.Windows.Forms.Button ThanhToan;
        private System.Windows.Forms.Button TaiKhoan;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button Nhap_button;
        private System.Windows.Forms.Button ChinhSua_button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mathuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn HSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private DateTimePicker dateTimePickerHSD;
        private DateTimePicker dateTimePickerNgayNhap;
    }
}
