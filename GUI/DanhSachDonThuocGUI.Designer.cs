namespace QLPhongMachTu_DOAN_.GUI
{
    partial class DanhSachDonThuocGUI
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
            this.dgvHoaDonThuoc = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayMua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonThuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHoaDonThuoc
            // 
            this.dgvHoaDonThuoc.AllowDrop = true;
            this.dgvHoaDonThuoc.AllowUserToAddRows = false;
            this.dgvHoaDonThuoc.AllowUserToDeleteRows = false;
            this.dgvHoaDonThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDonThuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MaDT,
            this.NgayMua,
            this.TongTien,
            this.TrangThai});
            this.dgvHoaDonThuoc.Location = new System.Drawing.Point(28, 103);
            this.dgvHoaDonThuoc.Name = "dgvHoaDonThuoc";
            this.dgvHoaDonThuoc.ReadOnly = true;
            this.dgvHoaDonThuoc.RowHeadersVisible = false;
            this.dgvHoaDonThuoc.Size = new System.Drawing.Size(600, 410);
            this.dgvHoaDonThuoc.TabIndex = 2;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 50;
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 53;
            // 
            // MaDT
            // 
            this.MaDT.HeaderText = "Mã đơn thuốc";
            this.MaDT.MinimumWidth = 65;
            this.MaDT.Name = "MaDT";
            this.MaDT.ReadOnly = true;
            this.MaDT.Width = 125;
            // 
            // NgayMua
            // 
            this.NgayMua.HeaderText = "Ngày mua";
            this.NgayMua.Name = "NgayMua";
            this.NgayMua.ReadOnly = true;
            this.NgayMua.Width = 150;
            // 
            // TongTien
            // 
            this.TongTien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TongTien.HeaderText = "Tổng tiền";
            this.TongTien.Name = "TongTien";
            this.TongTien.ReadOnly = true;
            this.TongTien.Width = 150;
            // 
            // TrangThai
            // 
            this.TrangThai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(213, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "DANH SÁCH ĐƠN THUỐC";
            // 
            // DanhSachDonThuocGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(654, 534);
            this.Controls.Add(this.dgvHoaDonThuoc);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DanhSachDonThuocGUI";
            this.Text = "Danh sách đơn thuốc";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonThuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvHoaDonThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayMua;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.Label label1;
    }
}