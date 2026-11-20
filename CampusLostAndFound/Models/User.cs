using System;

namespace CampusLostAndFound.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string StudentId { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Student;
        public DateTime CreatedAt { get; set; }

        public bool IsAdmin => Role == UserRole.Admin;

        public override string ToString() => $"{FullName} ({Email})";
    }
}
