namespace QLPhongMachTu_DOAN_.DTO
{
    public class HoaDonKhamBenhDTO
    {
        public long MaHDKB { get; set; }    // Mã hóa đơn khám bệnh
        public long MaBN { get; set; }      // Mã bệnh nhân
        public long MaBS { get; set; }      // Mã bác sĩ
        public long MaPK { get; set; }      // Mã phiếu khám
        public decimal TongTien { get; set; } // Tổng tiền
        public string TrangThai { get; set; }  // Trạng thái
    }

}
