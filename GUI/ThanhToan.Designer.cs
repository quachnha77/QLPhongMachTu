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
            this.cbLoaiHoaDon = new System.Windows.Forms.ComboBox();
            this.lb_LoaiHoaDon = new System.Windows.Forms.Label();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.label_cbTimKiem = new System.Windows.Forms.Label();
            this.label_TrangThai = new System.Windows.Forms.Label();
            this.tbTimKiem = new System.Windows.Forms.TextBox();
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
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.dateTimePicker_NgayTao = new System.Windows.Forms.DateTimePicker();
            this.label_NgayTao = new System.Windows.Forms.Label();
            this.btn_XoaTimKiem = new System.Windows.Forms.Button();
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
            this.groupBox2.Controls.Add(this.btnThanhToan);
            this.groupBox2.Location = new System.Drawing.Point(17, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1042, 682);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách hóa đơn";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_XoaTimKiem);
            this.groupBox1.Controls.Add(this.cbLoaiHoaDon);
            this.groupBox1.Controls.Add(this.lb_LoaiHoaDon);
            this.groupBox1.Controls.Add(this.cbTrangThai);
            this.groupBox1.Controls.Add(this.label_cbTimKiem);
            this.groupBox1.Controls.Add(this.label_TrangThai);
            this.groupBox1.Controls.Add(this.dateTimePicker_NgayTao);
            this.groupBox1.Controls.Add(this.label_NgayTao);
            this.groupBox1.Controls.Add(this.tbTimKiem);
            this.groupBox1.Controls.Add(this.cbTimKiem);
            this.groupBox1.Controls.Add(this.btnTimKiemTT);
            this.groupBox1.Location = new System.Drawing.Point(818, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 346);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // cbLoaiHoaDon
            // 
            this.cbLoaiHoaDon.FormattingEnabled = true;
            this.cbLoaiHoaDon.Location = new System.Drawing.Point(10, 163);
            this.cbLoaiHoaDon.Name = "cbLoaiHoaDon";
            this.cbLoaiHoaDon.Size = new System.Drawing.Size(179, 21);
            this.cbLoaiHoaDon.TabIndex = 17;
            // 
            // lb_LoaiHoaDon
            // 
            this.lb_LoaiHoaDon.AutoSize = true;
            this.lb_LoaiHoaDon.Location = new System.Drawing.Point(7, 147);
            this.lb_LoaiHoaDon.Name = "lb_LoaiHoaDon";
            this.lb_LoaiHoaDon.Size = new System.Drawing.Size(73, 13);
            this.lb_LoaiHoaDon.TabIndex = 16;
            this.lb_LoaiHoaDon.Text = "Loại hóa đơn:";
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Location = new System.Drawing.Point(10, 216);
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
            this.label_TrangThai.Location = new System.Drawing.Point(7, 200);
            this.label_TrangThai.Name = "label_TrangThai";
            this.label_TrangThai.Size = new System.Drawing.Size(58, 13);
            this.label_TrangThai.TabIndex = 11;
            this.label_TrangThai.Text = "Trạng thái:";
            // 
            // tbTimKiem
            // 
            this.tbTimKiem.Location = new System.Drawing.Point(10, 69);
            this.tbTimKiem.Name = "tbTimKiem";
            this.tbTimKiem.Size = new System.Drawing.Size(179, 20);
            this.tbTimKiem.TabIndex = 6;
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
            this.btnTimKiemTT.Location = new System.Drawing.Point(55, 104);
            this.btnTimKiemTT.Name = "btnTimKiemTT";
            this.btnTimKiemTT.Size = new System.Drawing.Size(134, 27);
            this.btnTimKiemTT.TabIndex = 7;
            this.btnTimKiemTT.Text = "Tìm kiếm";
            this.btnTimKiemTT.UseVisualStyleBackColor = false;
            this.btnTimKiemTT.Click += new System.EventHandler(this.btnTimKiemTT_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.CadetBlue;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(531, 634);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(109, 30);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.BackColor = System.Drawing.Color.CadetBlue;
            this.btnXemChiTiet.FlatAppearance.BorderSize = 0;
            this.btnXemChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnXemChiTiet.Location = new System.Drawing.Point(352, 634);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(109, 30);
            this.btnXemChiTiet.TabIndex = 4;
            this.btnXemChiTiet.Text = "Xem chi tiết";
            this.btnXemChiTiet.UseVisualStyleBackColor = false;
            // 
            // dgvHoaDon
            // 
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
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.RowTemplate.Height = 24;
            this.dgvHoaDon.Size = new System.Drawing.Size(780, 588);
            this.dgvHoaDon.TabIndex = 0;
            // 
            // MaHD
            // 
            this.MaHD.HeaderText = "Mã hóa đơn";
            this.MaHD.MinimumWidth = 6;
            this.MaHD.Name = "MaHD";
            this.MaHD.Width = 90;
            // 
            // NgayTao
            // 
            this.NgayTao.HeaderText = "Ngày tạo";
            this.NgayTao.MinimumWidth = 6;
            this.NgayTao.Name = "NgayTao";
            this.NgayTao.Width = 125;
            // 
            // LoaiHD
            // 
            this.LoaiHD.HeaderText = "Loại hóa đơn";
            this.LoaiHD.Name = "LoaiHD";
            this.LoaiHD.Width = 120;
            // 
            // MaPK
            // 
            this.MaPK.HeaderText = "Mã phiếu khám";
            this.MaPK.Name = "MaPK";
            this.MaPK.Width = 150;
            // 
            // TongTien
            // 
            this.TongTien.HeaderText = "Tổng tiền";
            this.TongTien.Name = "TongTien";
            this.TongTien.Width = 150;
            // 
            // TrangThai
            // 
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Width = 140;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.CadetBlue;
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(172, 634);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(109, 30);
            this.btnThanhToan.TabIndex = 3;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker_NgayTao
            // 
            this.dateTimePicker_NgayTao.Location = new System.Drawing.Point(10, 268);
            this.dateTimePicker_NgayTao.Name = "dateTimePicker_NgayTao";
            this.dateTimePicker_NgayTao.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_NgayTao.TabIndex = 10;
            this.dateTimePicker_NgayTao.ValueChanged += new System.EventHandler(this.dateTimePicker_NgayTao_ValueChanged);
            // 
            // label_NgayTao
            // 
            this.label_NgayTao.AutoSize = true;
            this.label_NgayTao.Location = new System.Drawing.Point(7, 252);
            this.label_NgayTao.Name = "label_NgayTao";
            this.label_NgayTao.Size = new System.Drawing.Size(53, 13);
            this.label_NgayTao.TabIndex = 9;
            this.label_NgayTao.Text = "Ngày tạo:";
            // 
            // btn_XoaTimKiem
            // 
            this.btn_XoaTimKiem.BackColor = System.Drawing.Color.CadetBlue;
            this.btn_XoaTimKiem.FlatAppearance.BorderSize = 0;
            this.btn_XoaTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_XoaTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XoaTimKiem.ForeColor = System.Drawing.Color.White;
            this.btn_XoaTimKiem.Location = new System.Drawing.Point(102, 303);
            this.btn_XoaTimKiem.Name = "btn_XoaTimKiem";
            this.btn_XoaTimKiem.Size = new System.Drawing.Size(87, 27);
            this.btn_XoaTimKiem.TabIndex = 18;
            this.btn_XoaTimKiem.Text = "Xóa";
            this.btn_XoaTimKiem.UseVisualStyleBackColor = false;
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
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXemChiTiet;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbTimKiem;
        private System.Windows.Forms.Button btnTimKiemTT;
        private System.Windows.Forms.TextBox tbTimKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPK;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.Label label_TrangThai;
        private System.Windows.Forms.DateTimePicker dateTimePicker_NgayTao;
        private System.Windows.Forms.Label label_NgayTao;
        private System.Windows.Forms.Label label_cbTimKiem;
        private System.Windows.Forms.ComboBox cbLoaiHoaDon;
        private System.Windows.Forms.Label lb_LoaiHoaDon;
        private System.Windows.Forms.ComboBox cbTrangThai;
        private System.Windows.Forms.Button btn_XoaTimKiem;
    }
}
