using System;
using QLPhongMachTu_DOAN_.BLL;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class ThongKe : UserControl
    {
        private ThongKeBLL thongKeBLL = new ThongKeBLL();

        public ThongKe()
        {
            InitializeComponent();
            InitializeUI();
        }

        // Cài đặt các giá trị mặc định cho giao diện
        private void InitializeUI()
        {
            comboBox1.SelectedIndex = 0; // Lọc trạng thái thuốc
            comboBox2.SelectedIndex = 0; // Lọc kiểu doanh thu
            SetDefaultDates(); // Thiết lập ngày mặc định
            LoadRevenueDataAndChart();
        }

        // Thiết lập ngày mặc định
        private void SetDefaultDates()
        {
            dtpDenNgayDT.Value = DateTime.Now;
            dtpTuNgayDT.Value = DateTime.Now.AddYears(-1); // Một năm trước
        }

        // Hiển thị thống kê thuốc tồn
        private void LoadInventoryDataAndChart(string status)
        {
            try
            {
                DataTable inventoryData = thongKeBLL.GetInventoryStatusAndExpiry(status);

                if (inventoryData != null && inventoryData.Rows.Count > 0)
                {
                    UpdateInventoryGrid(inventoryData);
                    UpdateInventoryChart(inventoryData);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu thuốc để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewTT.DataSource = null;
                    chartTT.Series.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu thuốc tồn: {ex.Message}");
            }
        }

        // Cập nhật DataGridView cho thuốc tồn
        private void UpdateInventoryGrid(DataTable inventoryData)
        {
            // Thêm cột số thứ tự
            if (!inventoryData.Columns.Contains("STT"))
            {
                inventoryData.Columns.Add("STT", typeof(int));
            }

            for (int i = 0; i < inventoryData.Rows.Count; i++)
            {
                inventoryData.Rows[i]["STT"] = i + 1;
            }

            // Đặt DataSource cho DataGridView
            dataGridViewTT.DataSource = inventoryData;

            // Đặt tên các cột hiển thị
            dataGridViewTT.Columns["STT"].HeaderText = "STT";
            dataGridViewTT.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
            dataGridViewTT.Columns["SoLuongTon"].HeaderText = "Số Lượng Tồn";
            dataGridViewTT.Columns["HSD"].HeaderText = "Hạn Sử Dụng";
            dataGridViewTT.Columns["TrangThai"].HeaderText = "Trạng Thái";

            // Đưa cột "Số Thứ Tự" lên đầu
            dataGridViewTT.Columns["STT"].DisplayIndex = 0;
        }

        // Cập nhật biểu đồ cho thuốc tồn
        private void UpdateInventoryChart(DataTable inventoryData)
        {
            chartTT.Series.Clear();
            var series = new Series("Thuốc Tồn Kho")
            {
                XValueMember = "TenThuoc",
                YValueMembers = "SoLuongTon",
                ChartType = SeriesChartType.Column
            };
            chartTT.Series.Add(series);
            chartTT.DataSource = inventoryData;
            chartTT.DataBind();

            // Màu sắc cho các trạng thái
            foreach (var point in chartTT.Series[0].Points)
            {
                var drugName = point.AxisLabel;
                DataRow row = inventoryData.Select($"TenThuoc = '{drugName}'").FirstOrDefault();

                if (row != null)
                {
                    string expiryStatus = row["TrangThai"].ToString();

                    if (expiryStatus == "Hết hạn")
                    {
                        point.Color = System.Drawing.Color.Red;
                    }
                    else if (expiryStatus == "Sắp hết hạn")
                    {
                        point.Color = System.Drawing.Color.Yellow;
                    }
                    else
                    {
                        point.Color = System.Drawing.Color.Green;
                    }
                }
            }
        }

        // Xuất dữ liệu thuốc tồn ra Excel
        private void ExportInventoryToExcel(DataGridView dataGridView)
        {
            try
            {
                // Tạo một DataTable từ DataGridView
                DataTable dt = new DataTable();

                // Thêm cột "STT" vào đầu DataTable
                dt.Columns.Add("STT");

                // Thêm các cột vào DataTable từ các cột của DataGridView (bỏ cột STT)
                foreach (DataGridViewColumn column in dataGridViewTT.Columns)
                {
                    // Không thêm cột "STT" vào DataTable nữa
                    if (column.HeaderText != "STT")
                    {
                        dt.Columns.Add(column.HeaderText);
                    }
                }

                // Thêm các dòng dữ liệu vào DataTable từ các dòng của DataGridView
                int rowIndex = 1;
                foreach (DataGridViewRow row in dataGridViewTT.Rows)
                {
                    if (!row.IsNewRow) // Kiểm tra nếu không phải dòng mới
                    {
                        DataRow dataRow = dt.NewRow();

                        // Điền số thứ tự vào cột "STT"
                        dataRow["STT"] = rowIndex++;

                        // Điền các giá trị của DataGridView vào các cột còn lại
                        int columnIndex = 0;
                        foreach (DataGridViewColumn column in dataGridViewTT.Columns)
                        {
                            if (column.HeaderText != "STT")
                            {
                                dataRow[columnIndex + 1] = row.Cells[column.Index].Value;
                                columnIndex++;
                            }
                        }

                        dt.Rows.Add(dataRow);
                    }
                }

                // Kiểm tra dữ liệu
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                // Lấy đường dẫn thư mục gốc của dự án
                string projectRootPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                // Lưu DataTable ra Excel
                string folderPath = Path.Combine(projectRootPath, "Excel", "Thống kê", "Thuốc tồn");

                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string fileName = $"Thống kê thuốc tồn {DateTime.Now:yyyy-MM-dd_HH-mm-ss}.xlsx";
                string filePath = Path.Combine(folderPath, fileName);

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.AddWorksheet("KhoThuoc");
                    worksheet.Cell(1, 1).InsertTable(dt); // Xuất toàn bộ bảng
                    workbook.SaveAs(filePath);
                }

                MessageBox.Show($"File đã được lưu tại: {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu file: {ex.Message}");
            }
        }

        // Sự kiện khi nhấn nút "Xuất Excel"
        private void btnXuatExcelTT_Click(object sender, EventArgs e)
        {
            string status = comboBox1.SelectedItem.ToString();
            var inventoryData = thongKeBLL.GetInventoryStatusAndExpiry(status);

            if (inventoryData != null && inventoryData.Rows.Count > 0)
            {
                ExportInventoryToExcel(dataGridViewTT);
            }
            else
            {
                // Nếu không có dữ liệu, thông báo cho người dùng
                MessageBox.Show("Không có dữ liệu phù hợp để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Sự kiện khi thay đổi trạng thái lọc thuốc
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = comboBox1.SelectedItem.ToString();
            LoadInventoryDataAndChart(status);
        }

        // Hiển thị thống kê doanh thu
        private void LoadRevenueDataAndChart()
        {
            try
            {
                string filterType = comboBox2.SelectedItem.ToString();
                DateTime fromDate = dtpTuNgayDT.Value;
                DateTime toDate = dtpDenNgayDT.Value;

                DataTable revenueData = thongKeBLL.GetRevenueDataByFilter(fromDate, toDate, filterType);

                if (revenueData == null && revenueData.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu doanh thu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewDT.DataSource = null;
                    chartDT.Series.Clear();
                    return;
                }

                UpdateRevenueGrid(revenueData);
                UpdateRevenueChart(revenueData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu doanh thu: {ex.Message}");
            }
        }

        // Cập nhật DataGridView cho doanh thu
        private void UpdateRevenueGrid(DataTable revenueData)
        {
            dataGridViewDT.DataSource = revenueData;

            // Kiểm tra và gán HeaderText
            if (dataGridViewDT.Columns["ThoiGian"] != null)
            {
                dataGridViewDT.Columns["ThoiGian"].HeaderText = comboBox2.SelectedItem.ToString();
            }

            if (dataGridViewDT.Columns["DoanhThuKhamBenh"] != null)
            {
                dataGridViewDT.Columns["DoanhThuKhamBenh"].HeaderText = "Doanh Thu Khám Bệnh";
            }

            if (dataGridViewDT.Columns["DoanhThuBanThuoc"] != null)
            {
                dataGridViewDT.Columns["DoanhThuBanThuoc"].HeaderText = "Doanh Thu Bán Thuốc";
            }

            if (dataGridViewDT.Columns["TongDoanhThu"] != null)
            {
                dataGridViewDT.Columns["TongDoanhThu"].HeaderText = "Tổng Doanh Thu";
            }
        }

        // Cập nhật biểu đồ doanh thu
        private void UpdateRevenueChart(DataTable revenueData)
        {
            chartDT.Series.Clear();

            // Thêm các series
            var seriesKhamBenh = new Series("Khám Bệnh") { ChartType = SeriesChartType.Column };
            var seriesBanThuoc = new Series("Bán Thuốc") { ChartType = SeriesChartType.Column };
            var seriesTongDoanhThu = new Series("Tổng Doanh Thu") { ChartType = SeriesChartType.Column };

            if (revenueData.Columns.Contains("DoanhThuKhamBenh") &&
                revenueData.Columns.Contains("DoanhThuBanThuoc") &&
                revenueData.Columns.Contains("TongDoanhThu"))
            {
                foreach (DataRow row in revenueData.Rows)
                {
                    string timeLabel = row["ThoiGian"].ToString();
                    seriesKhamBenh.Points.AddXY(timeLabel, row["DoanhThuKhamBenh"]);
                    seriesBanThuoc.Points.AddXY(timeLabel, row["DoanhThuBanThuoc"]);
                    seriesTongDoanhThu.Points.AddXY(timeLabel, row["TongDoanhThu"]);
                }

                chartDT.Series.Add(seriesKhamBenh);
                chartDT.Series.Add(seriesBanThuoc);
                chartDT.Series.Add(seriesTongDoanhThu);
            }
            else
            {
                MessageBox.Show("Một hoặc nhiều cột không tồn tại trong bảng dữ liệu.");
            }

        }


        private void btnApDungDT_Click(object sender, EventArgs e)
        {
            LoadRevenueDataAndChart();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo một DataTable từ DataGridView
                DataTable dt = new DataTable();

                // Thêm các cột vào DataTable
                foreach (DataGridViewColumn column in dataGridViewDT.Columns)
                {
                    dt.Columns.Add(column.HeaderText);
                }

                // Thêm các dòng dữ liệu vào DataTable
                foreach (DataGridViewRow row in dataGridViewDT.Rows)
                {
                    if (!row.IsNewRow) // Kiểm tra nếu không phải dòng mới
                    {
                        DataRow dataRow = dt.NewRow();

                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dataRow[i] = row.Cells[i].Value ?? DBNull.Value;
                        }

                        dt.Rows.Add(dataRow);
                    }
                }

                // Kiểm tra dữ liệu
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Lấy đường dẫn thư mục gốc của dự án
                string projectRootPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                // Lưu DataTable ra Excel
                string folderPath = Path.Combine(projectRootPath, "Excel", "Thống kê", "Doanh thu");

                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string fileName = $"Thống kê doanh thu {DateTime.Now:yyyy-MM-dd_HH-mm-ss}.xlsx";
                string filePath = Path.Combine(folderPath, fileName);

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.AddWorksheet("DoanhThu");
                    worksheet.Cell(1, 1).InsertTable(dt); // Xuất toàn bộ bảng
                    workbook.SaveAs(filePath);
                }

                MessageBox.Show($"File đã được lưu tại: {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu file: {ex.Message}");
            }
        }

        // Sự kiện khi thay đổi kiểu lọc doanh thu
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRevenueDataAndChart();
        }
    }
}
