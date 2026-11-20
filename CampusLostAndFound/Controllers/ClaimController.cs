using CampusLostAndFound.Data;
using CampusLostAndFound.Models;

namespace CampusLostAndFound.Controllers
{
    /// <summary>
    /// Business logic for submitting and reviewing item claims.
    /// </summary>
    public class ClaimController
    {
        private readonly ClaimRepository _claimRepo = new();
        private readonly ItemRepository  _itemRepo  = new();

        // ── Submit Claim ───────────────────────────────────────────────────
        /// <summary>
        /// Submits a claim for a Found item.
        /// Returns (true, "") on success or (false, errorMessage) on failure.
        /// </summary>
        public (bool Success, string Error) SubmitClaim(int userId, int itemId, string explanation)
        {
            if (string.IsNullOrWhiteSpace(explanation))
                return (false, "An explanation is required to support your claim.");

            var item = _itemRepo.GetById(itemId);
            if (item == null)
                return (false, "Item not found.");
            if (item.ReportType != ReportType.Found)
                return (false, "Claims can only be submitted for Found items.");
            if (item.Status == ItemStatus.Returned)
                return (false, "This item has already been returned and is no longer claimable.");
            if (item.UserId == userId)
                return (false, "You cannot claim an item that you reported.");
            if (_claimRepo.UserHasActiveClaim(userId, itemId))
                return (false, "You have already submitted a claim for this item.");

            var claim = new Claim
            {
                ItemId      = itemId,
                UserId      = userId,
                Explanation = explanation.Trim(),
                ClaimStatus = ClaimStatus.Pending
            };

            _claimRepo.Add(claim);
            return (true, string.Empty);
        }

        // ── Read ───────────────────────────────────────────────────────────
        public List<Claim> GetClaimsForItem(int itemId)  => _claimRepo.GetByItem(itemId);
        public List<Claim> GetClaimsByUser(int userId)   => _claimRepo.GetByUser(userId);
        public List<Claim> GetAllClaims()                => _claimRepo.GetAll();

        // ── Update Claim Status ────────────────────────────────────────────
        public (bool Success, string Error) UpdateClaimStatus(
            int claimId, ClaimStatus newStatus, bool isAdmin)
        {
            if (!isAdmin) return (false, "Only administrators can update claim status.");
            _claimRepo.UpdateStatus(claimId, newStatus);
            return (true, string.Empty);
        }
    }
}
