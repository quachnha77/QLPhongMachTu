using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class HoaDonKhamBenhBLL
    {
        private readonly HoaDonKhamBenhDAL _hoaDonKhamBenhDAL;

        public HoaDonKhamBenhBLL()
        {
            _hoaDonKhamBenhDAL = new HoaDonKhamBenhDAL();
        }

        // Thêm mới hóa đơn khám bệnh
        public long AddHoaDonKhamBenh(HoaDonKhamBenhDTO hoaDon)
        {
            // Thêm hóa đơn vào cơ sở dữ liệu
            return _hoaDonKhamBenhDAL.AddHoaDonKhamBenh(hoaDon);
        }

        public bool CapNhatTrangThaiHoaDon(long maHDKB, string trangThai)
        {
            return _hoaDonKhamBenhDAL.UpdateTrangThaiHoaDon(maHDKB, trangThai);
        }

    }
}
