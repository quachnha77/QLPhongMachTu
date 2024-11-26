namespace QLPhongMachTu_DOAN_.GUI
{
    partial class ThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewTT = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chartTT = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnXuatExcelTT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewDT = new System.Windows.Forms.DataGridView();
            this.bieudo = new System.Windows.Forms.Panel();
            this.chartDT = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXuatExcelDT = new System.Windows.Forms.Button();
            this.btnApDungDT = new System.Windows.Forms.Button();
            this.dtpDenNgayDT = new System.Windows.Forms.DateTimePicker();
            this.dtpTuNgayDT = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTT)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTT)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDT)).BeginInit();
            this.bieudo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDT)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1073, 722);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightCyan;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1065, 696);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thống kê thuốc tồn";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewTT);
            this.panel1.Location = new System.Drawing.Point(497, 164);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 419);
            this.panel1.TabIndex = 9;
            // 
            // dataGridViewTT
            // 
            this.dataGridViewTT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTT.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewTT.Name = "dataGridViewTT";
            this.dataGridViewTT.Size = new System.Drawing.Size(539, 413);
            this.dataGridViewTT.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chartTT);
            this.panel3.Location = new System.Drawing.Point(20, 164);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(430, 419);
            this.panel3.TabIndex = 8;
            // 
            // chartTT
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTT.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTT.Legends.Add(legend1);
            this.chartTT.Location = new System.Drawing.Point(3, 3);
            this.chartTT.Name = "chartTT";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTT.Series.Add(series1);
            this.chartTT.Size = new System.Drawing.Size(424, 413);
            this.chartTT.TabIndex = 0;
            this.chartTT.Text = "chart2";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.MintCream;
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.btnXuatExcelTT);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(20, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1020, 88);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thống kê theo ngày";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Tất cả",
            "Hết hạn",
            "Còn hạn",
            "Sắp hết hạn"});
            this.comboBox1.Location = new System.Drawing.Point(122, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(198, 28);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnXuatExcelTT
            // 
            this.btnXuatExcelTT.BackColor = System.Drawing.Color.CadetBlue;
            this.btnXuatExcelTT.FlatAppearance.BorderSize = 0;
            this.btnXuatExcelTT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcelTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcelTT.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcelTT.Location = new System.Drawing.Point(899, 35);
            this.btnXuatExcelTT.Name = "btnXuatExcelTT";
            this.btnXuatExcelTT.Size = new System.Drawing.Size(100, 27);
            this.btnXuatExcelTT.TabIndex = 10;
            this.btnXuatExcelTT.Text = "Xuất Excel";
            this.btnXuatExcelTT.UseVisualStyleBackColor = false;
            this.btnXuatExcelTT.Click += new System.EventHandler(this.btnXuatExcelTT_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(20, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Trạng thái";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightCyan;
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.bieudo);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1065, 696);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Thống kê doanh thu";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Ngày",
            "Tháng",
            "Năm"});
            this.comboBox2.Location = new System.Drawing.Point(919, 155);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 28);
            this.comboBox2.TabIndex = 7;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewDT);
            this.panel2.Location = new System.Drawing.Point(564, 189);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(476, 406);
            this.panel2.TabIndex = 6;
            // 
            // dataGridViewDT
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDT.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewDT.Name = "dataGridViewDT";
            this.dataGridViewDT.Size = new System.Drawing.Size(470, 400);
            this.dataGridViewDT.TabIndex = 0;
            // 
            // bieudo
            // 
            this.bieudo.Controls.Add(this.chartDT);
            this.bieudo.Location = new System.Drawing.Point(20, 189);
            this.bieudo.Name = "bieudo";
            this.bieudo.Size = new System.Drawing.Size(497, 403);
            this.bieudo.TabIndex = 5;
            // 
            // chartDT
            // 
            chartArea2.Name = "ChartArea1";
            this.chartDT.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartDT.Legends.Add(legend2);
            this.chartDT.Location = new System.Drawing.Point(3, 3);
            this.chartDT.Name = "chartDT";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartDT.Series.Add(series2);
            this.chartDT.Size = new System.Drawing.Size(491, 397);
            this.chartDT.TabIndex = 0;
            this.chartDT.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MintCream;
            this.groupBox1.Controls.Add(this.btnXuatExcelDT);
            this.groupBox1.Controls.Add(this.btnApDungDT);
            this.groupBox1.Controls.Add(this.dtpDenNgayDT);
            this.groupBox1.Controls.Add(this.dtpTuNgayDT);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1020, 95);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống kê theo ngày";
            // 
            // btnXuatExcelDT
            // 
            this.btnXuatExcelDT.BackColor = System.Drawing.Color.CadetBlue;
            this.btnXuatExcelDT.FlatAppearance.BorderSize = 0;
            this.btnXuatExcelDT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcelDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcelDT.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcelDT.Location = new System.Drawing.Point(900, 35);
            this.btnXuatExcelDT.Name = "btnXuatExcelDT";
            this.btnXuatExcelDT.Size = new System.Drawing.Size(100, 27);
            this.btnXuatExcelDT.TabIndex = 10;
            this.btnXuatExcelDT.Text = "Xuất Excel";
            this.btnXuatExcelDT.UseVisualStyleBackColor = false;
            this.btnXuatExcelDT.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnApDungDT
            // 
            this.btnApDungDT.BackColor = System.Drawing.Color.CadetBlue;
            this.btnApDungDT.FlatAppearance.BorderSize = 0;
            this.btnApDungDT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApDungDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApDungDT.ForeColor = System.Drawing.Color.White;
            this.btnApDungDT.Location = new System.Drawing.Point(725, 35);
            this.btnApDungDT.Name = "btnApDungDT";
            this.btnApDungDT.Size = new System.Drawing.Size(100, 27);
            this.btnApDungDT.TabIndex = 8;
            this.btnApDungDT.Text = "Áp dụng";
            this.btnApDungDT.UseVisualStyleBackColor = false;
            this.btnApDungDT.Click += new System.EventHandler(this.btnApDungDT_Click);
            // 
            // dtpDenNgayDT
            // 
            this.dtpDenNgayDT.Location = new System.Drawing.Point(470, 35);
            this.dtpDenNgayDT.Name = "dtpDenNgayDT";
            this.dtpDenNgayDT.Size = new System.Drawing.Size(229, 26);
            this.dtpDenNgayDT.TabIndex = 5;
            // 
            // dtpTuNgayDT
            // 
            this.dtpTuNgayDT.Location = new System.Drawing.Point(95, 35);
            this.dtpTuNgayDT.Name = "dtpTuNgayDT";
            this.dtpTuNgayDT.Size = new System.Drawing.Size(229, 26);
            this.dtpTuNgayDT.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(20, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Từ ngày:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(380, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đến ngày:";
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.Controls.Add(this.tabControl1);
            this.Name = "ThongKe";
            this.Size = new System.Drawing.Size(1076, 725);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTT)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTT)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDT)).EndInit();
            this.bieudo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDT)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpTuNgayDT;
        private System.Windows.Forms.DateTimePicker dtpDenNgayDT;
        private System.Windows.Forms.Button btnXuatExcelDT;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel bieudo;
        private System.Windows.Forms.DataGridView dataGridViewDT;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewTT;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnXuatExcelTT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnApDungDT;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}
