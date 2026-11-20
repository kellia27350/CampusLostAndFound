using System;

namespace CampusLostAndFound.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public string Explanation { get; set; } = string.Empty;
        public DateTime ClaimDate { get; set; }
        public ClaimStatus ClaimStatus { get; set; } = ClaimStatus.Pending;

        // Navigation / display helpers (populated by JOIN queries)
        public string ClaimantName { get; set; } = string.Empty;
        public string ClaimantEmail { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
    }
}
