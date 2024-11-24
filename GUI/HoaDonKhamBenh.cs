using QLPhongMachTu_DOAN_.BLL;
using System;
using System.Collections.Generic;
using System.Drawing; // Sử dụng Font của System.Drawing
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class HoaDonKhamBenh : Form
    {
        private PhieuKhamBLL phieuKhamBLL;
        private BenhNhanBLL benhNhanBLL;
        private HoaDonKhamBenhBLL hoaDonKhamBenhBLL;
        private PhieuKhamDichVuBLL phieuKhamDVBLL;
        private DichVuBLL dichVuBLL;
        private long maPK;
        private long maBN;
        private long maBS;
        private long maHDKB;

        public HoaDonKhamBenh(long maPK, long maBS, long maBN)
        {
            InitializeComponent();

            phieuKhamBLL = new PhieuKhamBLL();
            benhNhanBLL = new BenhNhanBLL();
            hoaDonKhamBenhBLL = new HoaDonKhamBenhBLL();
            phieuKhamDVBLL = new PhieuKhamDichVuBLL();
            dichVuBLL = new DichVuBLL();

            this.maPK = maPK;
            this.maBN = maBN;
            this.maBS = maBS;

            LoadThongTinBN();
            LoadPhieuKham();
            TaoHoaDon();
        }

        private void TaoHoaDon()
        {
            var hoaDon = new HoaDonKhamBenhDTO
            {
                MaBN = maBN,
                MaBS = maBS,
                MaPK = maPK,
                TongTien = Convert.ToDecimal(txtTongTien.Text),
                TrangThai = "Chưa thanh toán"
            };

            maHDKB = hoaDonKhamBenhBLL.AddHoaDonKhamBenh(hoaDon);
        }

        private void LoadThongTinBN()
        {
            BenhNhan benhNhan = benhNhanBLL.GetBenhNhanByMaBN(maBN);
            txtHoTen.Text = benhNhan.HoTen;
            txtCCCD.Text = benhNhan.CCCD.ToString();
            txtNgaySinh.Text = benhNhan.NgaySinh.ToString("dd/MM/yyyy");
            txtGioiTinh.Text = benhNhan.GioiTinh;
            txtSDT.Text = benhNhan.SDT;
        }

        private void LoadPhieuKham()
        {
            PhieuKham phieuKham = phieuKhamBLL.GetByMaPK(maPK);
            if (phieuKham != null)
            {
                txtMaBN.Text = phieuKham.MaBN.ToString();
                txtMaPK.Text = phieuKham.MaPK.ToString();
                txtNgayKham.Text = phieuKham.NgayKham.ToString();
                txtTrieuChung.Text = phieuKham.TrieuChung;
                txtChuanDoan.Text = phieuKham.ChuanDoan;

                HienThiDichVuDaSuDung(phieuKham.MaPK);
            }
        }

        private void HienThiDichVuDaSuDung(long maPK)
        {
            try
            {
                List<PhieuKhamDichVu> danhSachMaDV = phieuKhamDVBLL.GetByMaPK(maPK);
                if (danhSachMaDV == null || danhSachMaDV.Count == 0)
                {
                    MessageBox.Show("Không có dịch vụ nào được sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                double tongTien = 0;
                tbDichVu.Rows.Clear();

                foreach (var phieuKhamDV in danhSachMaDV)
                {
                    DichVuDTO dichVu = dichVuBLL.GetByMaDV(phieuKhamDV.MaDV);
                    if (dichVu != null)
                    {
                        double thanhTien = dichVu.DonGia * phieuKhamDV.SoLuong;
                        tongTien += thanhTien;

                        tbDichVu.Rows.Add(
                            dichVu.TenDichVu,
                            dichVu.DonGia.ToString("N0"),
                            phieuKhamDV.SoLuong,
                            thanhTien.ToString("N0")
                        );
                    }
                }
                txtTongTien.Text = tongTien.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;

            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDocument
            };
            previewDialog.ShowDialog();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                System.Drawing.Graphics g = e.Graphics;
                System.Drawing.Font font = new System.Drawing.Font("Arial", 12);

                float lineHeight = font.GetHeight() + 5;
                float x = 50, y = 50;

                g.DrawString("HÓA ĐƠN KHÁM BỆNH", new System.Drawing.Font("Arial", 16, FontStyle.Bold), Brushes.Black, x, y);
                y += lineHeight * 2;

                g.DrawString($"Mã BN: {txtMaBN.Text}", font, Brushes.Black, x, y);
                y += lineHeight;
                g.DrawString($"Họ tên: {txtHoTen.Text}", font, Brushes.Black, x, y);
                y += lineHeight;
                g.DrawString($"Ngày khám: {txtNgayKham.Text}", font, Brushes.Black, x, y);
                y += lineHeight;
                g.DrawString($"Tổng tiền: {txtTongTien.Text}", font, Brushes.Black, x, y);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToPDF()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF file (*.pdf)|*.pdf",
                Title = "Save as PDF"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 50, 50, 50, 50);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);
                    pdfDoc.Open();

                    Paragraph title = new Paragraph("HÓA ĐƠN KHÁM BỆNH", FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD));
                    title.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(title);

                    pdfDoc.Add(new Paragraph($"Mã BN: {txtMaBN.Text}"));
                    pdfDoc.Add(new Paragraph($"Họ tên: {txtHoTen.Text}"));
                    pdfDoc.Add(new Paragraph($"Ngày khám: {txtNgayKham.Text}"));
                    pdfDoc.Add(new Paragraph($"Tổng tiền: {txtTongTien.Text}"));

                    PdfPTable table = new PdfPTable(4);
                    table.AddCell("Tên dịch vụ");
                    table.AddCell("Đơn giá");
                    table.AddCell("Số lượng");
                    table.AddCell("Thành tiền");

                    foreach (DataGridViewRow row in tbDichVu.Rows)
                    {
                        if (row.IsNewRow) continue;
                        table.AddCell(row.Cells[0].Value.ToString());
                        table.AddCell(row.Cells[1].Value.ToString());
                        table.AddCell(row.Cells[2].Value.ToString());
                        table.AddCell(row.Cells[3].Value.ToString());
                    }
                    pdfDoc.Add(table);
                    pdfDoc.Close();
                    writer.Close();
                }
                MessageBox.Show("Xuất hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
