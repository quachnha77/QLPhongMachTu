namespace QLPhongMachTu_DOAN_.GUI
{
    partial class ChiTietToaThuocGUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvChiTietToaThuoc = new System.Windows.Forms.DataGridView();
            this.CachDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietToaThuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(226, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "CHI TIẾT TOA THUỐC";
            // 
            // dgvChiTietToaThuoc
            // 
            this.dgvChiTietToaThuoc.AllowDrop = true;
            this.dgvChiTietToaThuoc.AllowUserToAddRows = false;
            this.dgvChiTietToaThuoc.AllowUserToDeleteRows = false;
            this.dgvChiTietToaThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietToaThuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MaTT,
            this.TenThuoc,
            this.SoLuong,
            this.CachDung});
            this.dgvChiTietToaThuoc.Location = new System.Drawing.Point(28, 103);
            this.dgvChiTietToaThuoc.Name = "dgvChiTietToaThuoc";
            this.dgvChiTietToaThuoc.ReadOnly = true;
            this.dgvChiTietToaThuoc.RowHeadersVisible = false;
            this.dgvChiTietToaThuoc.Size = new System.Drawing.Size(600, 410);
            this.dgvChiTietToaThuoc.TabIndex = 2;
            // 
            // CachDung
            // 
            this.CachDung.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CachDung.HeaderText = "Cách dùng";
            this.CachDung.Name = "CachDung";
            this.CachDung.ReadOnly = true;
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            this.SoLuong.Width = 75;
            // 
            // TenThuoc
            // 
            this.TenThuoc.HeaderText = "Tên thuốc";
            this.TenThuoc.Name = "TenThuoc";
            this.TenThuoc.ReadOnly = true;
            this.TenThuoc.Width = 170;
            // 
            // MaTT
            // 
            this.MaTT.HeaderText = "Mã toa thuốc";
            this.MaTT.MinimumWidth = 65;
            this.MaTT.Name = "MaTT";
            this.MaTT.ReadOnly = true;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 50;
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 53;
            // 
            // ChiTietToaThuocGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(654, 534);
            this.Controls.Add(this.dgvChiTietToaThuoc);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ChiTietToaThuocGUI";
            this.Text = "Chi Tiết Toa Thuốc";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietToaThuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvChiTietToaThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn CachDung;
    }
}