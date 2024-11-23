using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class PhongKhoaDAL : DatabaseHelper
    {
        private readonly string _connectionString;
        public List<PhongKhoa> GetAll()
        {
            string query = "SELECT * FROM PhongKhoas";

            DataTable result = ExecuteQuery(query);
            var list = new List<PhongKhoa>();

            foreach (DataRow row in result.Rows)
            {
                list.Add(new PhongKhoa
                {
                    MaPK = Convert.ToInt64(row[0]),
                    TenPhongBan = Convert.ToString(row[1]),
                    ChuyenKhoa = Convert.ToString(row[2]),
                });
            }
            return list;
        }
    }
}
