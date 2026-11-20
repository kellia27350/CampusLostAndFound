using CampusLostAndFound.Models;
using Microsoft.Data.SqlClient;

namespace CampusLostAndFound.Data
{
    public class CategoryRepository
    {
        public List<Category> GetAll()
        {
            const string sql = "SELECT * FROM Categories ORDER BY CategoryName";
            var list = new List<Category>();
            using var conn   = DatabaseHelper.GetConnection();
            using var cmd    = new SqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Category
                {
                    CategoryId   = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                    CategoryName = reader.GetString(reader.GetOrdinal("CategoryName"))
                });
            }
            return list;
        }

        public Category? GetById(int id)
        {
            const string sql = "SELECT * FROM Categories WHERE CategoryId = @Id";
            using var conn   = DatabaseHelper.GetConnection();
            using var cmd    = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return new Category
            {
                CategoryId   = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                CategoryName = reader.GetString(reader.GetOrdinal("CategoryName"))
            };
        }
    }
}
