using CampusLostAndFound.Models;
using Microsoft.Data.SqlClient;

namespace CampusLostAndFound.Data
{
    public class UserRepository
    {
        // ── Create ─────────────────────────────────────────────────────────
        public void Add(User user)
        {
            const string sql = @"
                INSERT INTO Users (FullName, Email, StudentId, PasswordHash, Role)
                VALUES (@FullName, @Email, @StudentId, @PasswordHash, @Role)";

            using var conn = DatabaseHelper.GetConnection();
            using var cmd  = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@FullName",     user.FullName);
            cmd.Parameters.AddWithValue("@Email",        user.Email);
            cmd.Parameters.AddWithValue("@StudentId",    user.StudentId);
            cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            cmd.Parameters.AddWithValue("@Role",         user.Role.ToString());
            cmd.ExecuteNonQuery();
        }

        // ── Read ───────────────────────────────────────────────────────────
        public User? GetByEmail(string email)
        {
            const string sql = "SELECT * FROM Users WHERE Email = @Email";
            using var conn = DatabaseHelper.GetConnection();
            using var cmd  = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Email", email);
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? MapUser(reader) : null;
        }

        public User? GetById(int userId)
        {
            const string sql = "SELECT * FROM Users WHERE UserId = @UserId";
            using var conn = DatabaseHelper.GetConnection();
            using var cmd  = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserId", userId);
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? MapUser(reader) : null;
        }

        public List<User> GetAll()
        {
            const string sql = "SELECT * FROM Users ORDER BY FullName";
            var users = new List<User>();
            using var conn = DatabaseHelper.GetConnection();
            using var cmd  = new SqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) users.Add(MapUser(reader));
            return users;
        }

        public bool EmailExists(string email)
        {
            const string sql = "SELECT COUNT(1) FROM Users WHERE Email = @Email";
            using var conn = DatabaseHelper.GetConnection();
            using var cmd  = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Email", email);
            return (int)cmd.ExecuteScalar()! > 0;
        }

        // ── Delete ─────────────────────────────────────────────────────────
        public void Delete(int userId)
        {
            const string sql = "DELETE FROM Users WHERE UserId = @UserId";
            using var conn = DatabaseHelper.GetConnection();
            using var cmd  = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.ExecuteNonQuery();
        }

        // ── Mapper ─────────────────────────────────────────────────────────
        private static User MapUser(SqlDataReader r) => new()
        {
            UserId       = r.GetInt32(r.GetOrdinal("UserId")),
            FullName     = r.GetString(r.GetOrdinal("FullName")),
            Email        = r.GetString(r.GetOrdinal("Email")),
            StudentId    = r.GetString(r.GetOrdinal("StudentId")),
            PasswordHash = r.GetString(r.GetOrdinal("PasswordHash")),
            Role         = Enum.Parse<UserRole>(r.GetString(r.GetOrdinal("Role"))),
            CreatedAt    = r.GetDateTime(r.GetOrdinal("CreatedAt"))
        };
    }
}
