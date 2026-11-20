using CampusLostAndFound.Models;
using Microsoft.Data.SqlClient;

namespace CampusLostAndFound.Data
{
    public class ClaimRepository
    {
        // ── Create ─────────────────────────────────────────────────────────
        public void Add(Claim claim)
        {
            const string sql = @"
                INSERT INTO Claims (ItemId, UserId, Explanation, ClaimStatus)
                VALUES (@ItemId, @UserId, @Explanation, @ClaimStatus)";

            using var conn = DatabaseHelper.GetConnection();
            using var cmd  = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ItemId",      claim.ItemId);
            cmd.Parameters.AddWithValue("@UserId",      claim.UserId);
            cmd.Parameters.AddWithValue("@Explanation", claim.Explanation);
            cmd.Parameters.AddWithValue("@ClaimStatus", claim.ClaimStatus.ToString());
            cmd.ExecuteNonQuery();
        }

        // ── Read ───────────────────────────────────────────────────────────
        private const string SelectWithJoins = @"
            SELECT cl.*, u.FullName AS ClaimantName, u.Email AS ClaimantEmail,
                   i.ItemName
            FROM Claims cl
            JOIN Users u ON u.UserId = cl.UserId
            JOIN Items i ON i.ItemId = cl.ItemId";

        public List<Claim> GetByItem(int itemId)
        {
            string sql = SelectWithJoins + " WHERE cl.ItemId = @ItemId ORDER BY cl.ClaimDate DESC";
            using var conn = DatabaseHelper.GetConnection();
            using var cmd  = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ItemId", itemId);
            return ReadClaims(cmd);
        }

        public List<Claim> GetByUser(int userId)
        {
            string sql = SelectWithJoins + " WHERE cl.UserId = @UserId ORDER BY cl.ClaimDate DESC";
            using var conn = DatabaseHelper.GetConnection();
            using var cmd  = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserId", userId);
            return ReadClaims(cmd);
        }

        public bool UserHasActiveClaim(int userId, int itemId)
        {
            const string sql = @"
                SELECT COUNT(1) FROM Claims
                WHERE UserId = @UserId AND ItemId = @ItemId
                  AND ClaimStatus NOT IN ('Rejected')";
            using var conn = DatabaseHelper.GetConnection();
            using var cmd  = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@ItemId", itemId);
            return (int)cmd.ExecuteScalar()! > 0;
        }

        public List<Claim> GetAll()
        {
            string sql = SelectWithJoins + " ORDER BY cl.ClaimDate DESC";
            using var conn = DatabaseHelper.GetConnection();
            using var cmd  = new SqlCommand(sql, conn);
            return ReadClaims(cmd);
        }

        // ── Update ─────────────────────────────────────────────────────────
        public void UpdateStatus(int claimId, ClaimStatus status)
        {
            const string sql = "UPDATE Claims SET ClaimStatus = @Status WHERE ClaimId = @ClaimId";
            using var conn = DatabaseHelper.GetConnection();
            using var cmd  = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Status",  status.ToString());
            cmd.Parameters.AddWithValue("@ClaimId", claimId);
            cmd.ExecuteNonQuery();
        }

        // ── Helpers ────────────────────────────────────────────────────────
        private static List<Claim> ReadClaims(SqlCommand cmd)
        {
            var list = new List<Claim>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) list.Add(MapClaim(reader));
            return list;
        }

        private static Claim MapClaim(SqlDataReader r) => new()
        {
            ClaimId       = r.GetInt32(r.GetOrdinal("ClaimId")),
            ItemId        = r.GetInt32(r.GetOrdinal("ItemId")),
            UserId        = r.GetInt32(r.GetOrdinal("UserId")),
            Explanation   = r.GetString(r.GetOrdinal("Explanation")),
            ClaimDate     = r.GetDateTime(r.GetOrdinal("ClaimDate")),
            ClaimStatus   = Enum.Parse<ClaimStatus>(r.GetString(r.GetOrdinal("ClaimStatus"))),
            ClaimantName  = r.GetString(r.GetOrdinal("ClaimantName")),
            ClaimantEmail = r.GetString(r.GetOrdinal("ClaimantEmail")),
            ItemName      = r.GetString(r.GetOrdinal("ItemName"))
        };
    }
}
