using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class NhanVienDAL : DatabaseHelper
    {
        private readonly string _connectionString;
        public List<NhanVien> GetAll()
        {
            string query = "SELECT * FROM NhanViens";

            DataTable result = ExecuteQuery(query);
            var list = new List<NhanVien>();

            foreach (DataRow row in result.Rows)
            {
                list.Add(new NhanVien
                {
                    MaSo = Convert.ToInt64(row[0]),
                    CCCD = Convert.ToInt64(row[1]),
                    HoTen = Convert.ToString(row[2]),
                    NgaySinh = Convert.ToDateTime(row[3]),
                    GioiTinh = Convert.ToString(row[4]),
                    DiaChi = Convert.ToString(row[5]),
                    SDT = Convert.ToString(row[6]),
                    MaUser = Convert.ToInt64(row[7]),
                });
            }
            return list;
        }
    }
}
