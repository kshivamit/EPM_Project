using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EPM.Implementation.Helper
{
    public class SqlHelper
    {
        public static async Task<Int32> ExecuteNonQuery(String connectionString, String commandText,
              CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    // There're three command types: StoredProcedure, Text, TableDirect. The TableDirect 
                    // type is only for OLE DB.  
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        internal static object ExecuteNonQuery(string connectionString, string createUser)
        {
            throw new NotImplementedException();
        }

        public static async Task<Object> ExecuteScalar(String connectionString, String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return await cmd.ExecuteScalarAsync();
                }
            }
        }

        internal static Task ExecuteScaler(string connectionString, string createUser, CommandType text, SqlParameter[] parameter)
        {
            throw new NotImplementedException();
        }

        public static async Task<SqlDataReader> ExecuteReader(String connectionString, String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                if (parameters != null)
                {
                    if (parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                }

                conn.Open();
                // When using CommandBehavior.CloseConnection, the connection will be closed when the 
                // IDataReader is closed.
                SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);

                return reader;
            }
        }
    }
}
