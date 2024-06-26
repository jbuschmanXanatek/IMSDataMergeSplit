using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IMSDataMergeSplit
{
    public class IMSDatabase : IDisposable
    {
        SqlConnection _connection;
        string _connectionString = "";
        public IMSDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Connect()
        {
            _connection = new SqlConnection(_connectionString);
            
            _connection.Open();
        }

        public void Disconnect()
        {
            _connection.Close();
            _connection.Dispose();
        }

        public int ExecuteSQL(string sql)
        {
            sql = sql.Replace("GO", "--GO");

            var scripts = sql.Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = _connection;
                command.CommandTimeout = 6000;

                int count = 0;
                command.CommandText = sql;
                count += command.ExecuteNonQuery();

                return count;
            }
        }

        public int ExecuteSQLByAgency(string sql, Guid agencyUID)
        {
            sql = sql.Replace("GO", "--GO");
            var scripts = sql.Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = _connection;
                command.CommandTimeout = 6000;
                if (agencyUID != Guid.Empty)
                    command.Parameters.Add(new SqlParameter("AgencyUID", agencyUID.ToString()));
                command.Parameters.Add(new SqlParameter("ProducerUID",""));

                int count = 0;
                command.CommandText = sql;
                count += command.ExecuteNonQuery();

                return count;
            }
        }

        public int ExecuteSQLByProducer(string sql, Guid producerUID)
        {
            sql = sql.Replace("GO", "--GO");
            var scripts = sql.Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = _connection;
                command.CommandTimeout = 6000;
                if (producerUID != Guid.Empty)
                {
                    command.Parameters.Add(new SqlParameter("ProducerUID", producerUID.ToString()));
                    command.Parameters.Add(new SqlParameter("AgencyUID", ""));
                }

                int count = 0;
                command.CommandText = sql;
                count += command.ExecuteNonQuery();

                return count;
            }
        }

        public DataTable GetAgencies()
        {
            var table = new DataTable();
            using (SqlCommand command = new SqlCommand("SELECT uid,displayname FROM Agencies", _connection))
            {
                command.CommandTimeout = 600;

                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {                    
                    da.Fill(table);
                }
            }
            return table;
        }
        public DataTable GetProducers()
        {
            var table = new DataTable();
            using (SqlCommand command = new SqlCommand("SELECT uid,displayname FROM Producers", _connection))
            {
                command.CommandTimeout = 600;

                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    da.Fill(table);
                }
            }
            return table;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_connection != null)
                        Disconnect();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~IMSDatabase() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
