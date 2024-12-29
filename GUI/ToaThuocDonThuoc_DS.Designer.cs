namespace QLPhongMachTu_DOAN_.GUI
{
    partial class ToaThuocDonThuoc_DS
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
            this.tableToaThuoc = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenBS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayKeToa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPhatThuoc = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableChiTiet = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CachDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableToaThuoc)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableToaThuoc);
            this.groupBox2.Location = new System.Drawing.Point(17, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(828, 338);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách toa thuốc";
            // 
            // tableToaThuoc
            // 
            this.tableToaThuoc.AllowDrop = true;
            this.tableToaThuoc.AllowUserToResizeColumns = false;
            this.tableToaThuoc.AllowUserToResizeRows = false;
            this.tableToaThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableToaThuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MaTT,
            this.TenBN,
            this.TenBS,
            this.NgayKeToa,
            this.TinhTrang});
            this.tableToaThuoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableToaThuoc.Location = new System.Drawing.Point(8, 18);
            this.tableToaThuoc.Margin = new System.Windows.Forms.Padding(2);
            this.tableToaThuoc.Name = "tableToaThuoc";
            this.tableToaThuoc.ReadOnly = true;
            this.tableToaThuoc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tableToaThuoc.RowHeadersVisible = false;
            this.tableToaThuoc.RowHeadersWidth = 51;
            this.tableToaThuoc.RowTemplate.Height = 24;
            this.tableToaThuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableToaThuoc.Size = new System.Drawing.Size(803, 300);
            this.tableToaThuoc.TabIndex = 0;
            this.tableToaThuoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableToaThuoc_CellClick);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 50;
            // 
            // MaTT
            // 
            this.MaTT.HeaderText = "Mã toa thuốc";
            this.MaTT.MinimumWidth = 6;
            this.MaTT.Name = "MaTT";
            this.MaTT.ReadOnly = true;
            // 
            // TenBN
            // 
            this.TenBN.HeaderText = "Bệnh nhân";
            this.TenBN.MinimumWidth = 6;
            this.TenBN.Name = "TenBN";
            this.TenBN.ReadOnly = true;
            this.TenBN.Width = 180;
            // 
            // TenBS
            // 
            this.TenBS.HeaderText = "Bác sĩ kê toa";
            this.TenBS.Name = "TenBS";
            this.TenBS.ReadOnly = true;
            this.TenBS.Width = 180;
            // 
            // NgayKeToa
            // 
            this.NgayKeToa.HeaderText = "Ngày kê toa";
            this.NgayKeToa.Name = "NgayKeToa";
            this.NgayKeToa.ReadOnly = true;
            this.NgayKeToa.Width = 140;
            // 
            // TinhTrang
            // 
            this.TinhTrang.HeaderText = "Tình trạng";
            this.TinhTrang.Name = "TinhTrang";
            this.TinhTrang.ReadOnly = true;
            this.TinhTrang.Width = 150;
            // 
            // btnPhatThuoc
            // 
            this.btnPhatThuoc.BackColor = System.Drawing.Color.CadetBlue;
            this.btnPhatThuoc.FlatAppearance.BorderSize = 0;
            this.btnPhatThuoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhatThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhatThuoc.ForeColor = System.Drawing.Color.White;
            this.btnPhatThuoc.Location = new System.Drawing.Point(878, 37);
            this.btnPhatThuoc.Name = "btnPhatThuoc";
            this.btnPhatThuoc.Size = new System.Drawing.Size(158, 30);
            this.btnPhatThuoc.TabIndex = 9;
            this.btnPhatThuoc.Text = "Phát thuốc";
            this.btnPhatThuoc.UseVisualStyleBackColor = false;
            this.btnPhatThuoc.Click += new System.EventHandler(this.btnPhatThuoc_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableChiTiet);
            this.groupBox1.Location = new System.Drawing.Point(17, 363);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1045, 338);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết toa thuốc";
            // 
            // tableChiTiet
            // 
            this.tableChiTiet.AllowUserToAddRows = false;
            this.tableChiTiet.AllowUserToDeleteRows = false;
            this.tableChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.MaThuoc,
            this.TenThuoc,
            this.DonGia,
            this.SoLuong,
            this.DonVi,
            this.CachDung,
            this.TongTien});
            this.tableChiTiet.Location = new System.Drawing.Point(16, 29);
            this.tableChiTiet.Margin = new System.Windows.Forms.Padding(2);
            this.tableChiTiet.Name = "tableChiTiet";
            this.tableChiTiet.ReadOnly = true;
            this.tableChiTiet.RowHeadersVisible = false;
            this.tableChiTiet.RowHeadersWidth = 51;
            this.tableChiTiet.RowTemplate.Height = 24;
            this.tableChiTiet.Size = new System.Drawing.Size(1012, 294);
            this.tableChiTiet.TabIndex = 38;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ID.Width = 50;
            // 
            // MaThuoc
            // 
            this.MaThuoc.HeaderText = "Mã thuốc";
            this.MaThuoc.MinimumWidth = 6;
            this.MaThuoc.Name = "MaThuoc";
            this.MaThuoc.ReadOnly = true;
            this.MaThuoc.Width = 130;
            // 
            // TenThuoc
            // 
            this.TenThuoc.HeaderText = "Tên thuốc";
            this.TenThuoc.Name = "TenThuoc";
            this.TenThuoc.ReadOnly = true;
            this.TenThuoc.Width = 180;
            // 
            // DonGia
            // 
            this.DonGia.HeaderText = "Đơn giá";
            this.DonGia.MinimumWidth = 6;
            this.DonGia.Name = "DonGia";
            this.DonGia.ReadOnly = true;
            this.DonGia.Width = 110;
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            this.SoLuong.Width = 80;
            // 
            // DonVi
            // 
            this.DonVi.HeaderText = "Đơn vị";
            this.DonVi.Name = "DonVi";
            this.DonVi.ReadOnly = true;
            // 
            // CachDung
            // 
            this.CachDung.HeaderText = "Cách dùng";
            this.CachDung.Name = "CachDung";
            this.CachDung.ReadOnly = true;
            this.CachDung.Width = 210;
            // 
            // TongTien
            // 
            this.TongTien.HeaderText = "Tổng tiền";
            this.TongTien.Name = "TongTien";
            this.TongTien.ReadOnly = true;
            this.TongTien.Width = 150;
            // 
            // ToaThuocDonThuoc_DS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnPhatThuoc);
            this.Name = "ToaThuocDonThuoc_DS";
            this.Size = new System.Drawing.Size(1076, 725);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableToaThuoc)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableChiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView tableToaThuoc;
        private System.Windows.Forms.Button btnPhatThuoc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView tableChiTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenBS;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayKeToa;
        private System.Windows.Forms.DataGridViewTextBoxColumn TinhTrang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn CachDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
    }
}
