using CampusLostAndFound.Models;
using Microsoft.Data.SqlClient;

namespace CampusLostAndFound.Data
{
    public class ItemRepository
    {
        // ── Create ─────────────────────────────────────────────────────────
        public int Add(Item item)
        {
            const string sql = @"
                INSERT INTO Items (UserId, CategoryId, ItemName, Description, Location,
                                   ReportDate, ReportType, ImagePath, Status)
                OUTPUT INSERTED.ItemId
                VALUES (@UserId, @CategoryId, @ItemName, @Description, @Location,
                        @ReportDate, @ReportType, @ImagePath, @Status)";

            using var conn = DatabaseHelper.GetConnection();
            using var cmd  = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserId",     item.UserId);
            cmd.Parameters.AddWithValue("@CategoryId", item.CategoryId);
            cmd.Parameters.AddWithValue("@ItemName",   item.ItemName);
            cmd.Parameters.AddWithValue("@Description",item.Description);
            cmd.Parameters.AddWithValue("@Location",   item.Location);
            cmd.Parameters.AddWithValue("@ReportDate", item.ReportDate);
            cmd.Parameters.AddWithValue("@ReportType", item.ReportType.ToString());
            cmd.Parameters.AddWithValue("@ImagePath",  (object?)item.ImagePath ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Status",     item.Status.ToString());
            return (int)cmd.ExecuteScalar()!;
        }

        // ── Read ───────────────────────────────────────────────────────────
        private const string SelectWithJoins = @"
            SELECT i.*, u.FullName AS ReporterName, u.Email AS ReporterEmail,
                   c.CategoryName
            FROM Items i
            JOIN Users      u ON u.UserId     = i.UserId
            JOIN Categories c ON c.CategoryId = i.CategoryId";

        public Item? GetById(int itemId)
        {
            string sql = SelectWithJoins + " WHERE i.ItemId = @ItemId";
            using var conn   = DatabaseHelper.GetConnection();
            using var cmd    = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ItemId", itemId);
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? MapItem(reader) : null;
        }

        public List<Item> GetAll()
        {
            string sql = SelectWithJoins + " ORDER BY i.CreatedAt DESC";
            return RunQuery(sql);
        }

        public List<Item> GetActive()
        {
            string sql = SelectWithJoins + " WHERE i.Status = 'Active' ORDER BY i.CreatedAt DESC";
            return RunQuery(sql);
        }

        public List<Item> GetByUser(int userId)
        {
            string sql = SelectWithJoins + " WHERE i.UserId = @UserId ORDER BY i.CreatedAt DESC";
            using var conn = DatabaseHelper.GetConnection();
            using var cmd  = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserId", userId);
            return ReadItems(cmd);
        }

        public List<Item> Search(string keyword, string reportTypeFilter, int categoryFilter)
        {
            var conditions = new List<string> { "i.Status = 'Active'" };

            if (!string.IsNullOrWhiteSpace(keyword))
                conditions.Add("(i.ItemName LIKE @Kw OR i.Description LIKE @Kw OR i.Location LIKE @Kw)");

            if (reportTypeFilter == "Lost" || reportTypeFilter == "Found")
                conditions.Add("i.ReportType = @ReportType");

            if (categoryFilter > 0)
                conditions.Add("i.CategoryId = @CategoryId");

            string where = "WHERE " + string.Join(" AND ", conditions);
            string sql   = $"{SelectWithJoins} {where} ORDER BY i.CreatedAt DESC";

            using var conn = DatabaseHelper.GetConnection();
            using var cmd  = new SqlCommand(sql, conn);

            if (!string.IsNullOrWhiteSpace(keyword))
                cmd.Parameters.AddWithValue("@Kw", $"%{keyword}%");
            if (reportTypeFilter == "Lost" || reportTypeFilter == "Found")
                cmd.Parameters.AddWithValue("@ReportType", reportTypeFilter);
            if (categoryFilter > 0)
                cmd.Parameters.AddWithValue("@CategoryId", categoryFilter);

            return ReadItems(cmd);
        }

        // ── Update ─────────────────────────────────────────────────────────
        public void UpdateStatus(int itemId, ItemStatus status)
        {
            const string sql = "UPDATE Items SET Status = @Status WHERE ItemId = @ItemId";
            using var conn = DatabaseHelper.GetConnection();
            using var cmd  = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Status", status.ToString());
            cmd.Parameters.AddWithValue("@ItemId", itemId);
            cmd.ExecuteNonQuery();
        }

        // ── Delete ─────────────────────────────────────────────────────────
        public void Delete(int itemId)
        {
            const string sql = "DELETE FROM Items WHERE ItemId = @ItemId";
            using var conn = DatabaseHelper.GetConnection();
            using var cmd  = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ItemId", itemId);
            cmd.ExecuteNonQuery();
        }

        // ── Helpers ────────────────────────────────────────────────────────
        private List<Item> RunQuery(string sql)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd  = new SqlCommand(sql, conn);
            return ReadItems(cmd);
        }

        private static List<Item> ReadItems(SqlCommand cmd)
        {
            var list = new List<Item>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) list.Add(MapItem(reader));
            return list;
        }

        private static Item MapItem(SqlDataReader r) => new()
        {
            ItemId        = r.GetInt32(r.GetOrdinal("ItemId")),
            UserId        = r.GetInt32(r.GetOrdinal("UserId")),
            CategoryId    = r.GetInt32(r.GetOrdinal("CategoryId")),
            ItemName      = r.GetString(r.GetOrdinal("ItemName")),
            Description   = r.GetString(r.GetOrdinal("Description")),
            Location      = r.GetString(r.GetOrdinal("Location")),
            ReportDate    = r.GetDateTime(r.GetOrdinal("ReportDate")),
            ReportType    = Enum.Parse<ReportType>(r.GetString(r.GetOrdinal("ReportType"))),
            ImagePath     = r.IsDBNull(r.GetOrdinal("ImagePath")) ? null : r.GetString(r.GetOrdinal("ImagePath")),
            Status        = Enum.Parse<ItemStatus>(r.GetString(r.GetOrdinal("Status"))),
            CreatedAt     = r.GetDateTime(r.GetOrdinal("CreatedAt")),
            ReporterName  = r.GetString(r.GetOrdinal("ReporterName")),
            ReporterEmail = r.GetString(r.GetOrdinal("ReporterEmail")),
            CategoryName  = r.GetString(r.GetOrdinal("CategoryName"))
        };
    }
}
