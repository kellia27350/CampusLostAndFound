using CampusLostAndFound.Data;
using CampusLostAndFound.Models;

namespace CampusLostAndFound.Controllers
{
    /// <summary>
    /// Business logic for creating, browsing, and managing item reports.
    /// </summary>
    public class ItemController
    {
        private readonly ItemRepository     _itemRepo     = new();
        private readonly CategoryRepository _categoryRepo = new();

        // ── Categories ─────────────────────────────────────────────────────
        public List<Category> GetCategories() => _categoryRepo.GetAll();

        // ── Create Report ──────────────────────────────────────────────────
        /// <summary>
        /// Submits a new Lost or Found item report.
        /// Returns (ItemId > 0, "") on success or (0, errorMessage) on failure.
        /// </summary>
        public (int ItemId, string Error) SubmitReport(
            int userId, string itemName, string description,
            string location, DateTime reportDate, ReportType reportType,
            int categoryId, string? imagePath)
        {
            if (string.IsNullOrWhiteSpace(itemName))   return (0, "Item name is required.");
            if (string.IsNullOrWhiteSpace(description))return (0, "Description is required.");
            if (string.IsNullOrWhiteSpace(location))   return (0, "Location is required.");
            if (categoryId <= 0)                        return (0, "Please select a category.");
            if (reportDate > DateTime.Today)            return (0, "Report date cannot be in the future.");

            var item = new Item
            {
                UserId      = userId,
                CategoryId  = categoryId,
                ItemName    = itemName.Trim(),
                Description = description.Trim(),
                Location    = location.Trim(),
                ReportDate  = reportDate.Date,
                ReportType  = reportType,
                ImagePath   = imagePath,
                Status      = ItemStatus.Active
            };

            int newId = _itemRepo.Add(item);
            return (newId, string.Empty);
        }

        // ── Browse / Search ────────────────────────────────────────────────
        public List<Item> GetActiveItems() => _itemRepo.GetActive();

        /// <param name="reportTypeFilter">"All", "Lost", or "Found"</param>
        /// <param name="categoryFilter">0 means all categories</param>
        public List<Item> Search(string keyword, string reportTypeFilter, int categoryFilter)
            => _itemRepo.Search(keyword, reportTypeFilter, categoryFilter);

        public Item? GetById(int itemId) => _itemRepo.GetById(itemId);

        public List<Item> GetItemsByUser(int userId) => _itemRepo.GetByUser(userId);

        // ── Status Update ──────────────────────────────────────────────────
        /// <summary>
        /// Marks an item as Returned. Only the report owner or an admin may do this.
        /// </summary>
        public (bool Success, string Error) MarkReturned(int itemId, int requestingUserId, bool isAdmin)
        {
            var item = _itemRepo.GetById(itemId);
            if (item == null) return (false, "Item not found.");
            if (item.Status == ItemStatus.Returned) return (false, "Item is already marked as Returned.");
            if (!isAdmin && item.UserId != requestingUserId)
                return (false, "You are not authorised to update this item.");

            _itemRepo.UpdateStatus(itemId, ItemStatus.Returned);
            return (true, string.Empty);
        }

        // ── Admin delete ───────────────────────────────────────────────────
        public (bool Success, string Error) DeleteItem(int itemId, bool isAdmin)
        {
            if (!isAdmin) return (false, "Only administrators can delete reports.");
            var item = _itemRepo.GetById(itemId);
            if (item == null) return (false, "Item not found.");
            _itemRepo.Delete(itemId);
            return (true, string.Empty);
        }

        public List<Item> GetAll() => _itemRepo.GetAll();
    }
}
