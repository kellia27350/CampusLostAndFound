using CampusLostAndFound.Data;
using CampusLostAndFound.Models;

namespace CampusLostAndFound.Controllers
{
    /// <summary>
    /// Administrator-only operations: viewing all reports, users, and removing content.
    /// All public methods guard against non-admin callers.
    /// </summary>
    public class AdminController
    {
        private readonly ItemRepository  _itemRepo  = new();
        private readonly UserRepository  _userRepo  = new();
        private readonly ClaimRepository _claimRepo = new();

        // ── Guard helper ───────────────────────────────────────────────────
        private static void EnsureAdmin(bool isAdmin)
        {
            if (!isAdmin)
                throw new UnauthorizedAccessException("Administrator privileges are required.");
        }

        // ── Items ──────────────────────────────────────────────────────────
        public List<Item> GetAllItems(bool isAdmin)
        {
            EnsureAdmin(isAdmin);
            return _itemRepo.GetAll();
        }

        public (bool Success, string Error) RemoveItem(int itemId, bool isAdmin)
        {
            EnsureAdmin(isAdmin);
            var item = _itemRepo.GetById(itemId);
            if (item == null) return (false, "Item not found.");
            _itemRepo.Delete(itemId);
            return (true, string.Empty);
        }

        public (bool Success, string Error) MarkItemReturned(int itemId, bool isAdmin)
        {
            EnsureAdmin(isAdmin);
            var item = _itemRepo.GetById(itemId);
            if (item == null) return (false, "Item not found.");
            if (item.Status == ItemStatus.Returned)
                return (false, "Item is already marked Returned.");
            _itemRepo.UpdateStatus(itemId, ItemStatus.Returned);
            return (true, string.Empty);
        }

        // ── Users ──────────────────────────────────────────────────────────
        public List<User> GetAllUsers(bool isAdmin)
        {
            EnsureAdmin(isAdmin);
            return _userRepo.GetAll();
        }

        public (bool Success, string Error) RemoveUser(int userId, int adminUserId, bool isAdmin)
        {
            EnsureAdmin(isAdmin);
            if (userId == adminUserId)
                return (false, "You cannot remove your own account.");
            var user = _userRepo.GetById(userId);
            if (user == null) return (false, "User not found.");
            _userRepo.Delete(userId);
            return (true, string.Empty);
        }

        // ── Claims ─────────────────────────────────────────────────────────
        public List<Claim> GetAllClaims(bool isAdmin)
        {
            EnsureAdmin(isAdmin);
            return _claimRepo.GetAll();
        }

        public (bool Success, string Error) UpdateClaimStatus(
            int claimId, ClaimStatus status, bool isAdmin)
        {
            EnsureAdmin(isAdmin);
            _claimRepo.UpdateStatus(claimId, status);
            return (true, string.Empty);
        }

        // ── Dashboard stats ────────────────────────────────────────────────
        public (int TotalItems, int ActiveItems, int ReturnedItems,
                int TotalUsers, int TotalClaims) GetStats(bool isAdmin)
        {
            EnsureAdmin(isAdmin);
            var items  = _itemRepo.GetAll();
            var users  = _userRepo.GetAll();
            var claims = _claimRepo.GetAll();

            return (
                items.Count,
                items.Count(i => i.Status == ItemStatus.Active),
                items.Count(i => i.Status == ItemStatus.Returned),
                users.Count,
                claims.Count
            );
        }
    }
}
