using System;

namespace CampusLostAndFound.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime ReportDate { get; set; }
        public ReportType ReportType { get; set; }
        public string? ImagePath { get; set; }
        public ItemStatus Status { get; set; } = ItemStatus.Active;
        public DateTime CreatedAt { get; set; }

        // Navigation / display helpers (populated by JOIN queries)
        public string ReporterName { get; set; } = string.Empty;
        public string ReporterEmail { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;

        public string ReportTypeLabel => ReportType.ToString();
        public string StatusLabel => Status.ToString();
    }
}
