using CampusLostAndFound.Data;
using CampusLostAndFound.Models;
using System.Security.Cryptography;
using System.Text;

namespace CampusLostAndFound.Controllers
{
    /// <summary>
    /// Handles registration, login, logout, and the current session user.
    /// Password hashing uses SHA-256 + a per-user salt stored as "salt:hash".
    /// </summary>
    public class AccountController
    {
        private readonly UserRepository _userRepo = new();

        // ���─ Session ────────────────────────────────────────────────────────
        /// <summary>The user currently logged in; null when no session is active.</summary>
        public User? CurrentUser { get; private set; }

        public bool IsLoggedIn  => CurrentUser != null;
        public bool IsAdmin     => CurrentUser?.IsAdmin == true;

        // ── Register ───────────────────────────────────────────────────────
        /// <summary>
        /// Registers a new student account.
        /// Returns (true, "") on success or (false, errorMessage) on failure.
        /// </summary>
        public (bool Success, string Error) Register(
            string fullName, string email, string studentId, string password)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(fullName))   return (false, "Full name is required.");
            if (string.IsNullOrWhiteSpace(email))      return (false, "Email is required.");
            if (!email.Contains('@'))                   return (false, "Email format is invalid.");
            if (string.IsNullOrWhiteSpace(studentId))  return (false, "Student ID is required.");
            if (string.IsNullOrWhiteSpace(password))   return (false, "Password is required.");
            if (password.Length < 6)                   return (false, "Password must be at least 6 characters.");

            if (_userRepo.EmailExists(email))
                return (false, "An account with this email already exists.");

            string hash = HashPassword(password);

            var user = new User
            {
                FullName     = fullName.Trim(),
                Email        = email.Trim().ToLower(),
                StudentId    = studentId.Trim(),
                PasswordHash = hash,
                Role         = UserRole.Student
            };

            _userRepo.Add(user);
            return (true, string.Empty);
        }

        // ── Login ──────────────────────────────────────────────────────────
        /// <summary>
        /// Verifies credentials and sets CurrentUser on success.
        /// Returns (true, "") or (false, errorMessage).
        /// </summary>
        public (bool Success, string Error) Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))    return (false, "Email is required.");
            if (string.IsNullOrWhiteSpace(password)) return (false, "Password is required.");

            var user = _userRepo.GetByEmail(email.Trim().ToLower());
            if (user == null) return (false, "Invalid email or password.");

            if (!VerifyPassword(password, user.PasswordHash))
                return (false, "Invalid email or password.");

            CurrentUser = user;
            return (true, string.Empty);
        }

        // ── Logout ─────────────────────────────────────────────────────────
        public void Logout() => CurrentUser = null;

        // ── Password Hashing (SHA-256 + salt) ─────────────────────────────
        private static string HashPassword(string password)
        {
            // Generate a random 16-byte salt
            byte[] saltBytes = RandomNumberGenerator.GetBytes(16);
            string salt      = Convert.ToBase64String(saltBytes);

            string combined = salt + password;
            byte[] hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(combined));
            string hash      = Convert.ToBase64String(hashBytes);

            return $"{salt}:{hash}";
        }

        private static bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split(':', 2);
            if (parts.Length != 2) return false;

            string salt    = parts[0];
            string stored  = parts[1];
            string combined = salt + password;
            byte[] hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(combined));
            string computed  = Convert.ToBase64String(hashBytes);

            return computed == stored;
        }
    }
}
