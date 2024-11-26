using System.Data.SqlClient;
using System.Data;
using System;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class ThongKeDAL : DatabaseHelper
    {
        public ThongKeDAL() : base() { }

        //Thống thuốc tồn
        public DataTable GetInventoryStatusAndExpiry(string trangThai)
        {
            string query = @"
                SELECT TenThuoc, 
                       SoLuongTon, 
                       HSD,
                       CASE 
                           WHEN HSD < GETDATE() THEN N'Hết hạn'
                           WHEN HSD BETWEEN GETDATE() AND DATEADD(DAY, 30, GETDATE()) THEN N'Sắp hết hạn'
                           ELSE N'Còn hạn'
                       END AS TrangThai
                FROM KhoThuocs";

            if (trangThai != "Tất cả")
            {
                query += @"
                    WHERE
                        (CASE
                            WHEN HSD < GETDATE() THEN N'Hết hạn'
                            WHEN HSD <= DATEADD(DAY, 30, GETDATE()) THEN N'Sắp hết hạn'
                            ELSE N'Còn hạn'
                        END) = @TrangThai";
            }

            SqlParameter[] parameters = null;

            if (trangThai != "Tất cả")
            {
                parameters = new SqlParameter[]
                {
            new SqlParameter("@TrangThai", SqlDbType.NVarChar) { Value = trangThai }
                };
            }

            return ExecuteQuery(query, parameters);
        }

        // Thống kê doanh thu tổng hợp từ khám bệnh và bán thuốc theo ngày, tháng hoặc năm
        public DataTable GetRevenueDataByFilter(DateTime fromDate, DateTime toDate, string filterType)
        {
            string query = string.Empty;

            switch (filterType)
            {
                case "Ngày":
                    query = @"
                        SELECT 
                            CONVERT(VARCHAR, pk.NgayKham, 103) AS ThoiGian, 
                            SUM(hdkb.TongTien) AS DoanhThuKhamBenh,
                            ISNULL(SUM(hdt.TongTien), 0) AS DoanhThuBanThuoc,
                            SUM(hdkb.TongTien) + ISNULL(SUM(hdt.TongTien), 0) AS TongDoanhThu
                        FROM HoaDonKhamBenhs hdkb
                        LEFT JOIN PhieuKhams pk ON hdkb.MaPK = pk.MaPK
                        LEFT JOIN HoaDonThuocs hdt ON hdkb.MaBN = hdt.MaTT
                        WHERE pk.NgayKham >= @FromDate AND pk.NgayKham <= @ToDate
                        GROUP BY CONVERT(VARCHAR, pk.NgayKham, 103)
                        ORDER BY CONVERT(VARCHAR, pk.NgayKham, 103);";
                    break;

                case "Tháng":
                    query = @"
                        SELECT 
                            MONTH(pk.NgayKham) AS ThoiGian,
                            SUM(hdkb.TongTien) AS DoanhThuKhamBenh,
                            ISNULL(SUM(hdt.TongTien), 0) AS DoanhThuBanThuoc,
                            SUM(hdkb.TongTien) + ISNULL(SUM(hdt.TongTien), 0) AS TongDoanhThu
                        FROM HoaDonKhamBenhs hdkb
                        LEFT JOIN PhieuKhams pk ON hdkb.MaPK = pk.MaPK
                        LEFT JOIN HoaDonThuocs hdt ON hdkb.MaBN = hdt.MaTT
                        WHERE pk.NgayKham BETWEEN @FromDate AND @ToDate
                        GROUP BY MONTH(pk.NgayKham)
                        ORDER BY MONTH(pk.NgayKham)";
                    break;

                case "Năm":
                    query = @"
                        SELECT 
                            YEAR(pk.NgayKham) AS ThoiGian, 
                            SUM(hdkb.TongTien) AS DoanhThuKhamBenh,
                            ISNULL(SUM(hdt.TongTien), 0) AS DoanhThuBanThuoc,
                            SUM(hdkb.TongTien) + ISNULL(SUM(hdt.TongTien), 0) AS TongDoanhThu
                        FROM HoaDonKhamBenhs hdkb
                        LEFT JOIN PhieuKhams pk ON hdkb.MaPK = pk.MaPK
                        LEFT JOIN HoaDonThuocs hdt ON hdkb.MaBN = hdt.MaTT
                        WHERE YEAR(pk.NgayKham) = @Year
                        GROUP BY YEAR(pk.NgayKham)
                        ORDER BY YEAR(pk.NgayKham)";
                    break;
            }

            SqlParameter[] parameters;

            if (filterType == "Năm")
            {
                parameters = new SqlParameter[]
                {
            new SqlParameter("@Year", SqlDbType.Int) { Value = fromDate.Year }  // Chỉ cần tham số cho Năm
                };
            }
            else
            {
                parameters = new SqlParameter[]
                {
            new SqlParameter("@FromDate", SqlDbType.DateTime) { Value = fromDate },
            new SqlParameter("@ToDate", SqlDbType.DateTime) { Value = toDate }
                };
            }

            return ExecuteQuery(query, parameters);
        }

    }
}
