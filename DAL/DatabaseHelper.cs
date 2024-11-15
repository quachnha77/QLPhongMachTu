using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class DatabaseHelper : IDisposable
    {
        private readonly SqlConnection _connection;

        public DatabaseHelper()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString);
        }

        public void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
                _connection.Close();
        }

        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                OpenConnection();
                int rowsAffected = command.ExecuteNonQuery();
                CloseConnection();
                return rowsAffected;
            }
        }

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public void Dispose()
        {
            CloseConnection();
            _connection.Dispose();
        }

        public bool TestConnection()
        {
            try
            {
                OpenConnection();
                Console.WriteLine("Kết nối thành công!");
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Kết nối thất bại: " + ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

    }
}