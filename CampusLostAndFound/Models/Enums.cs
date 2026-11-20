namespace CampusLostAndFound.Models
{
    public enum UserRole
    {
        Student,
        Admin
    }

    public enum ReportType
    {
        Lost,
        Found
    }

    public enum ItemStatus
    {
        Active,
        Returned
    }

    public enum ClaimStatus
    {
        Pending,
        Reviewed,
        Accepted,
        Rejected
    }
}
