namespace QLPhongMachTu_DOAN_.GUI
{
    partial class ThanhToan
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_XoaTimKiem = new System.Windows.Forms.Button();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.label_cbTimKiem = new System.Windows.Forms.Label();
            this.label_TrangThai = new System.Windows.Forms.Label();
            this.dateTimePicker_NgayTao = new System.Windows.Forms.DateTimePicker();
            this.tbTimKiem = new System.Windows.Forms.TextBox();
            this.label_NgayTao = new System.Windows.Forms.Label();
            this.cbTimKiem = new System.Windows.Forms.ComboBox();
            this.btnTimKiemTT = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXemChiTiet = new System.Windows.Forms.Button();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.btnLamMoi);
            this.groupBox2.Controls.Add(this.btnXemChiTiet);
            this.groupBox2.Controls.Add(this.dgvHoaDon);
            this.groupBox2.Location = new System.Drawing.Point(17, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1042, 682);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách hóa đơn";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_XoaTimKiem);
            this.groupBox1.Controls.Add(this.cbTrangThai);
            this.groupBox1.Controls.Add(this.label_cbTimKiem);
            this.groupBox1.Controls.Add(this.label_TrangThai);
            this.groupBox1.Controls.Add(this.dateTimePicker_NgayTao);
            this.groupBox1.Controls.Add(this.tbTimKiem);
            this.groupBox1.Controls.Add(this.label_NgayTao);
            this.groupBox1.Controls.Add(this.cbTimKiem);
            this.groupBox1.Controls.Add(this.btnTimKiemTT);
            this.groupBox1.Location = new System.Drawing.Point(818, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 266);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // btn_XoaTimKiem
            // 
            this.btn_XoaTimKiem.BackColor = System.Drawing.Color.CadetBlue;
            this.btn_XoaTimKiem.FlatAppearance.BorderSize = 0;
            this.btn_XoaTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_XoaTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XoaTimKiem.ForeColor = System.Drawing.Color.White;
            this.btn_XoaTimKiem.Location = new System.Drawing.Point(144, 224);
            this.btn_XoaTimKiem.Name = "btn_XoaTimKiem";
            this.btn_XoaTimKiem.Size = new System.Drawing.Size(65, 27);
            this.btn_XoaTimKiem.TabIndex = 18;
            this.btn_XoaTimKiem.Text = "Xóa";
            this.btn_XoaTimKiem.UseVisualStyleBackColor = false;
            this.btn_XoaTimKiem.Click += new System.EventHandler(this.btnXoa_click);
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Location = new System.Drawing.Point(10, 124);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(179, 21);
            this.cbTrangThai.TabIndex = 15;
            // 
            // label_cbTimKiem
            // 
            this.label_cbTimKiem.AutoSize = true;
            this.label_cbTimKiem.Location = new System.Drawing.Point(7, 16);
            this.label_cbTimKiem.Name = "label_cbTimKiem";
            this.label_cbTimKiem.Size = new System.Drawing.Size(76, 13);
            this.label_cbTimKiem.TabIndex = 14;
            this.label_cbTimKiem.Text = "Tìm kiếm theo:";
            // 
            // label_TrangThai
            // 
            this.label_TrangThai.AutoSize = true;
            this.label_TrangThai.Location = new System.Drawing.Point(7, 108);
            this.label_TrangThai.Name = "label_TrangThai";
            this.label_TrangThai.Size = new System.Drawing.Size(58, 13);
            this.label_TrangThai.TabIndex = 11;
            this.label_TrangThai.Text = "Trạng thái:";
            // 
            // dateTimePicker_NgayTao
            // 
            this.dateTimePicker_NgayTao.Checked = false;
            this.dateTimePicker_NgayTao.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker_NgayTao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_NgayTao.Location = new System.Drawing.Point(10, 177);
            this.dateTimePicker_NgayTao.Name = "dateTimePicker_NgayTao";
            this.dateTimePicker_NgayTao.Size = new System.Drawing.Size(179, 20);
            this.dateTimePicker_NgayTao.TabIndex = 10;
            // 
            // tbTimKiem
            // 
            this.tbTimKiem.Location = new System.Drawing.Point(10, 69);
            this.tbTimKiem.Name = "tbTimKiem";
            this.tbTimKiem.Size = new System.Drawing.Size(179, 20);
            this.tbTimKiem.TabIndex = 6;
            // 
            // label_NgayTao
            // 
            this.label_NgayTao.AutoSize = true;
            this.label_NgayTao.Location = new System.Drawing.Point(7, 161);
            this.label_NgayTao.Name = "label_NgayTao";
            this.label_NgayTao.Size = new System.Drawing.Size(53, 13);
            this.label_NgayTao.TabIndex = 9;
            this.label_NgayTao.Text = "Ngày tạo:";
            // 
            // cbTimKiem
            // 
            this.cbTimKiem.FormattingEnabled = true;
            this.cbTimKiem.Location = new System.Drawing.Point(10, 32);
            this.cbTimKiem.Name = "cbTimKiem";
            this.cbTimKiem.Size = new System.Drawing.Size(179, 21);
            this.cbTimKiem.TabIndex = 8;
            // 
            // btnTimKiemTT
            // 
            this.btnTimKiemTT.BackColor = System.Drawing.Color.CadetBlue;
            this.btnTimKiemTT.FlatAppearance.BorderSize = 0;
            this.btnTimKiemTT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemTT.ForeColor = System.Drawing.Color.White;
            this.btnTimKiemTT.Location = new System.Drawing.Point(10, 224);
            this.btnTimKiemTT.Name = "btnTimKiemTT";
            this.btnTimKiemTT.Size = new System.Drawing.Size(128, 27);
            this.btnTimKiemTT.TabIndex = 7;
            this.btnTimKiemTT.Text = "Tìm kiếm";
            this.btnTimKiemTT.UseVisualStyleBackColor = false;
            this.btnTimKiemTT.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.CadetBlue;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(533, 635);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(109, 30);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.BackColor = System.Drawing.Color.CadetBlue;
            this.btnXemChiTiet.FlatAppearance.BorderSize = 0;
            this.btnXemChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnXemChiTiet.Location = new System.Drawing.Point(354, 635);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(109, 30);
            this.btnXemChiTiet.TabIndex = 4;
            this.btnXemChiTiet.Text = "Xem chi tiết";
            this.btnXemChiTiet.UseVisualStyleBackColor = false;
            this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD,
            this.NgayTao,
            this.LoaiHD,
            this.MaPK,
            this.TongTien,
            this.TrangThai});
            this.dgvHoaDon.Location = new System.Drawing.Point(19, 31);
            this.dgvHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.RowTemplate.Height = 24;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(780, 588);
            this.dgvHoaDon.TabIndex = 0;
            this.dgvHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellClick);
            // 
            // MaHD
            // 
            this.MaHD.HeaderText = "Mã hóa đơn";
            this.MaHD.MinimumWidth = 6;
            this.MaHD.Name = "MaHD";
            this.MaHD.ReadOnly = true;
            this.MaHD.Width = 90;
            // 
            // NgayTao
            // 
            this.NgayTao.HeaderText = "Ngày tạo";
            this.NgayTao.MinimumWidth = 6;
            this.NgayTao.Name = "NgayTao";
            this.NgayTao.ReadOnly = true;
            this.NgayTao.Width = 125;
            // 
            // LoaiHD
            // 
            this.LoaiHD.HeaderText = "Loại hóa đơn";
            this.LoaiHD.Name = "LoaiHD";
            this.LoaiHD.ReadOnly = true;
            this.LoaiHD.Width = 120;
            // 
            // MaPK
            // 
            this.MaPK.HeaderText = "Mã phiếu khám";
            this.MaPK.Name = "MaPK";
            this.MaPK.ReadOnly = true;
            this.MaPK.Width = 150;
            // 
            // TongTien
            // 
            this.TongTien.HeaderText = "Tổng tiền";
            this.TongTien.Name = "TongTien";
            this.TongTien.ReadOnly = true;
            this.TongTien.Width = 150;
            // 
            // TrangThai
            // 
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            this.TrangThai.Width = 140;
            // 
            // ThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.Controls.Add(this.groupBox2);
            this.Name = "ThanhToan";
            this.Size = new System.Drawing.Size(1076, 725);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_XoaTimKiem;
        private System.Windows.Forms.ComboBox cbTrangThai;
        private System.Windows.Forms.Label label_cbTimKiem;
        private System.Windows.Forms.Label label_TrangThai;
        private System.Windows.Forms.DateTimePicker dateTimePicker_NgayTao;
        private System.Windows.Forms.Label label_NgayTao;
        private System.Windows.Forms.TextBox tbTimKiem;
        private System.Windows.Forms.ComboBox cbTimKiem;
        private System.Windows.Forms.Button btnTimKiemTT;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXemChiTiet;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPK;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
    }
}
