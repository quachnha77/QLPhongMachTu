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
    }
}
