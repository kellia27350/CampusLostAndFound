using System.Configuration;
using Microsoft.Data.SqlClient;

namespace CampusLostAndFound.Data
{
    /// <summary>
    /// Central factory for SQL connections. Reads the connection string
    /// from App.config key "DefaultConnection".
    /// </summary>
    public static class DatabaseHelper
    {
        private static string _connectionString = string.Empty;

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = ConfigurationManager
                        .ConnectionStrings["DefaultConnection"]?.ConnectionString
                        ?? throw new InvalidOperationException(
                            "Connection string 'DefaultConnection' not found in App.config.");
                }
                return _connectionString;
            }
        }

        /// <summary>Returns an open SqlConnection.</summary>
        public static SqlConnection GetConnection()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// Verifies that the database is reachable.
        /// Returns true on success, false otherwise.
        /// </summary>
        public static bool TestConnection(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using var conn = GetConnection();
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
