namespace QLPhongMachTu_DOAN_.GUI
{
    partial class ToaThuocDonThuoc
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
            this.btnDSDonThuoc = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvToaThuoc = new System.Windows.Forms.DataGridView();
            this.btnChiTiet = new System.Windows.Forms.Button();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BacSi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayKeToa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayKham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoiDanBacSi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTienThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToaThuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDSDonThuoc);
            this.groupBox2.Controls.Add(this.btnLamMoi);
            this.groupBox2.Controls.Add(this.dgvToaThuoc);
            this.groupBox2.Controls.Add(this.btnChiTiet);
            this.groupBox2.Location = new System.Drawing.Point(15, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1042, 686);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách toa thuốc";
            // 
            // btnDSDonThuoc
            // 
            this.btnDSDonThuoc.BackColor = System.Drawing.Color.CadetBlue;
            this.btnDSDonThuoc.FlatAppearance.BorderSize = 0;
            this.btnDSDonThuoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDSDonThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDSDonThuoc.ForeColor = System.Drawing.Color.White;
            this.btnDSDonThuoc.Location = new System.Drawing.Point(433, 642);
            this.btnDSDonThuoc.Name = "btnDSDonThuoc";
            this.btnDSDonThuoc.Size = new System.Drawing.Size(158, 30);
            this.btnDSDonThuoc.TabIndex = 6;
            this.btnDSDonThuoc.Text = "Danh sách đơn thuốc";
            this.btnDSDonThuoc.UseVisualStyleBackColor = false;
            this.btnDSDonThuoc.Click += new System.EventHandler(this.btnDSDonThuoc_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.CadetBlue;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(680, 642);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(109, 30);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // dgvToaThuoc
            // 
            this.dgvToaThuoc.AllowDrop = true;
            this.dgvToaThuoc.AllowUserToAddRows = false;
            this.dgvToaThuoc.AllowUserToDeleteRows = false;
            this.dgvToaThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvToaThuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MaTT,
            this.BacSi,
            this.NgayKeToa,
            this.NgayKham,
            this.LoiDanBacSi,
            this.TongTienThuoc});
            this.dgvToaThuoc.Location = new System.Drawing.Point(18, 30);
            this.dgvToaThuoc.Margin = new System.Windows.Forms.Padding(2);
            this.dgvToaThuoc.Name = "dgvToaThuoc";
            this.dgvToaThuoc.ReadOnly = true;
            this.dgvToaThuoc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvToaThuoc.RowHeadersVisible = false;
            this.dgvToaThuoc.RowHeadersWidth = 51;
            this.dgvToaThuoc.RowTemplate.Height = 24;
            this.dgvToaThuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvToaThuoc.Size = new System.Drawing.Size(1007, 596);
            this.dgvToaThuoc.TabIndex = 0;
            this.dgvToaThuoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvToaThuoc_CellClick);
            // 
            // btnChiTiet
            // 
            this.btnChiTiet.BackColor = System.Drawing.Color.CadetBlue;
            this.btnChiTiet.FlatAppearance.BorderSize = 0;
            this.btnChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnChiTiet.Location = new System.Drawing.Point(233, 642);
            this.btnChiTiet.Name = "btnChiTiet";
            this.btnChiTiet.Size = new System.Drawing.Size(109, 30);
            this.btnChiTiet.TabIndex = 3;
            this.btnChiTiet.Text = "Chi tiết";
            this.btnChiTiet.UseVisualStyleBackColor = false;
            this.btnChiTiet.Click += new System.EventHandler(this.btnChiTiet_Click);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.Width = 50;
            // 
            // MaTT
            // 
            this.MaTT.HeaderText = "Mã toa thuốc";
            this.MaTT.MinimumWidth = 6;
            this.MaTT.Name = "MaTT";
            this.MaTT.Width = 125;
            // 
            // BacSi
            // 
            this.BacSi.HeaderText = "Bác sĩ kê toa";
            this.BacSi.MinimumWidth = 6;
            this.BacSi.Name = "BacSi";
            this.BacSi.Width = 180;
            // 
            // NgayKeToa
            // 
            this.NgayKeToa.HeaderText = "Ngày kê toa";
            this.NgayKeToa.Name = "NgayKeToa";
            this.NgayKeToa.Width = 140;
            // 
            // NgayKham
            // 
            this.NgayKham.HeaderText = "Ngày khám";
            this.NgayKham.Name = "NgayKham";
            this.NgayKham.Width = 140;
            // 
            // LoiDanBacSi
            // 
            this.LoiDanBacSi.HeaderText = "Lời dặn của bác sĩ";
            this.LoiDanBacSi.Name = "LoiDanBacSi";
            this.LoiDanBacSi.Width = 218;
            // 
            // TongTienThuoc
            // 
            this.TongTienThuoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TongTienThuoc.HeaderText = "Tổng tiền thuốc";
            this.TongTienThuoc.Name = "TongTienThuoc";
            // 
            // ToaThuocDonThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.Controls.Add(this.groupBox2);
            this.Name = "ToaThuocDonThuoc";
            this.Size = new System.Drawing.Size(1076, 725);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvToaThuoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnChiTiet;
        private System.Windows.Forms.Button btnDSDonThuoc;
        private System.Windows.Forms.DataGridView dgvToaThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn BacSi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayKeToa;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayKham;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoiDanBacSi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTienThuoc;
    }
}
