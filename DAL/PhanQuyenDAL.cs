using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class PhanQuyenDAL : DatabaseHelper
    {
        private readonly string _connectionString;
        public List<PhanQuyen> GetAllTenQuyen()
        {
            string query = "SELECT TenQuyen FROM PhanQuyens";

            DataTable result = ExecuteQuery(query);
            var list = new List<PhanQuyen>();

            foreach (DataRow row in result.Rows)
            {
                list.Add(new PhanQuyen
                {
                    TenQuyen = Convert.ToString(row[0]),
                });
            }
            return list;
        }
        public List<PhanQuyen> GetAll()
        {
            string query = "SELECT * FROM PhanQuyens";

            DataTable result = ExecuteQuery(query);
            var list = new List<PhanQuyen>();

            foreach (DataRow row in result.Rows)
            {
                list.Add(new PhanQuyen
                {
                    MaPQ = Convert.ToInt64(row[0]),
                    TenQuyen = Convert.ToString(row[1]),
                    ChucNang = Convert.ToString(row[2]),
                    MoTa = Convert.ToString(row[3]),
                });
            }
            return list;
        }
    }
}
