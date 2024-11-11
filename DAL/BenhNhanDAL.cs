using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class BenhNhanDAL : DatabaseHelper
    {
        public List<BenhNhan> GetAll()
        {
            string query = "SELECT * FROM BenhNhans";
            DataTable result = ExecuteQuery(query);

            return (from DataRow row in result.Rows
                    select new BenhNhan
                    {
                        MaSo = Convert.ToInt64(row[0]),
                        CCCD = (string)row[1],
                        HoTen = (string)row[2],
                        NgaySinh = (DateTime)row[3],
                        GioiTinh = (string)row[4],
                        DiaChi = (string)row[5],
                        MaUser = Convert.ToInt64(row[6]),
                      
                    }).ToList();
        }

        public BenhNhan Create(BenhNhan newBenhNhan)
        {
            //string query = "INSERT INTO BenhNhan (MaUser, Ten) OUTPUT INSERTED.Id VALUES (@MaUser, @Ten)";
            //SqlParameter[] parameters = {
            //    new SqlParameter("@MaUser", newBenhNhan.MaUser),
            //    new SqlParameter("@Ten", newBenhNhan.Ten)
            //    // Add other parameters as needed
            //};

            //using (DataTable result = ExecuteQuery(query, parameters))
            //{
            //    if (result.Rows.Count > 0)
            //    {
            //        newBenhNhan.Id = Convert.ToInt64(result.Rows[0]["Id"]);
            //    }
            //    return newBenhNhan;
            //}
            return null;
        }

        public BenhNhan GetByUserID(long userID)
        {
            string query = "SELECT * FROM BenhNhans WHERE MaUser = @MaUser";
            SqlParameter[] parameters = {
                new SqlParameter("@MaUser", userID)
            };

            DataTable result = ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                var bn = new BenhNhan()
                {
                    MaSo = Convert.ToInt64(row[0]),
                    CCCD = Convert.ToString(row[1]),
                    HoTen = (string)row[2],
                    NgaySinh = (DateTime)row[3],
                    GioiTinh = (string)row[4],
                    DiaChi = (string)row[5],
                    MaUser = Convert.ToInt64(row[6]),
                };
                return bn;
            }
            return null;
        }

        public BenhNhan GetById(long id)
        {
            string query = "SELECT * FROM BenhNhans WHERE Id = @Id";
            SqlParameter[] parameters = {
                new SqlParameter("@Id", id)
            };

            DataTable result = ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                return new BenhNhan
                {
                    MaSo = Convert.ToInt64(row[0]),
                    CCCD = (string)row[1],
                    HoTen = (string)row[2],
                    NgaySinh = (DateTime)row[3],
                    GioiTinh = (string)row[4],
                    DiaChi = (string)row[5],
                    MaUser = Convert.ToInt64(row[6]),

                };
            }
            return null;
        }
    }
}
