using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class PhanQuyenDAL : DatabaseHelper
    {
        //private readonly ApplicationDbContext context;

        public PhanQuyenDAL() : base()
        {
         
        }

        public PhanQuyen GetByMaPQ(long MaPQ)
        {
            string query = @"SELECT * 
                            FROM PhanQuyens
                            WHERE MaPQ = @MaPQ";
            SqlParameter[] parameter = { new SqlParameter("MAPQ", MaPQ) };

            DataTable result = ExecuteQuery(query, parameter);
            if(result.Rows.Count > 0)
            {
                PhanQuyen phanQuyen = new PhanQuyen()
                {
                    MaPQ = Convert.ToInt64(result.Rows[0][0]),
                    TenQuyen = Convert.ToString(result.Rows[0][1]),
                    ChucNang = Convert.ToString(result.Rows[0][2]),
                    MoTa = Convert.ToString(result.Rows[0][3])
                };
                return phanQuyen;
            }
            return null;
        }

        //public PhanQuyen GetByMaQP(long MaQP)
        //{
        //    var result = context.PhanQuyen.FirstOrDefault(pq => pq.MaPQ == MaQP);
        //    return result;
        //}

    }
}
