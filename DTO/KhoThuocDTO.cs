namespace DTO
{
    public class KhoThuocDTO
    {
        public long MaThuoc { get; set; } // Mã thuốc, khóa chính

        public string TenThuoc { get; set; } // Tên thuốc

        public double DonGia { get; set; } // Đơn giá của thuốc

        public string DonVi { get; set; } // Đơn vị tính của thuốc (viên, lọ, chai, v.v.)

        public string NhaCungCap { get; set; } // Nhà cung cấp của thuốc

        public DateTime NgayNhap { get; set; } // Ngày nhập thuốc vào kho

        public DateTime HSD { get; set; } // Hạn sử dụng của thuốc

        public int SoLuongTon { get; set; } // Số lượng tồn kho hiện tại của thuốc

        public bool IsExpired()
        {
            return DateTime.Now > HSD;
        }

        public override string ToString()
        {
            return $"Mã: {MaThuoc}, Tên: {TenThuoc}, Giá: {DonGia}, HSD: {HSD.ToShortDateString()}, Tồn kho: {SoLuongTon}";
        }
    }
}
