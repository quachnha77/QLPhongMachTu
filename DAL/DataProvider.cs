using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class DataProvider
    {
        private SqlConnection conn = null;

        public DataProvider()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QLBHConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }

        protected void Connect()
        {
            try
            {
                if (conn != null && conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ConfigurationErrorsException ex)
            {
                throw ex;
            }
        }

        protected void DisConnect()
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        protected SqlDataReader ExecuteNonQuery(string sql)
        {
            SqlDataReader dr = null;

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return dr;
        }
    }
}
