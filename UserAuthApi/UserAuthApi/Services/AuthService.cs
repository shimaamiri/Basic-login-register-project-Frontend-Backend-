using System.Text;
using System.Security.Cryptography;
using UserAuthApi.Data;
using UserAuthApi.Models;
using Microsoft.Extensions.Logging;

namespace UserAuthApi.Services
{
    // Handles all business logic related to user authentication
    public class AuthService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AuthService> _logger;

        // Constructor to inject database context and logger
        public AuthService(AppDbContext context, ILogger<AuthService> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Create a new user account
        public bool CreateAccount(string username, string email, string password)
        {
            try
            {
                // Check if username or email already exists
                if (_context.Users.Any(u => u.Username == username || u.Email == email))
                    return false;

                // Hash the password before storing
                string passwordHash = HashPassword(password);

                var user = new User
                {
                    Username = username,
                    Email = email,
                    PasswordHash = passwordHash
                };

                // Save new user to the database
                _context.Users.Add(user);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CreateAccount for user: {Username}", username);
                return false;
            }
        }

        // Authenticate an existing user
        public bool AuthenticateAccount(string username, string password)
        {
            try
            {
                // Find user by username
                var user = _context.Users.FirstOrDefault(u => u.Username == username);
                if (user == null) return false;

                // Compare hashed password
                return VerifyPassword(password, user.PasswordHash);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in AuthenticateAccount for user: {Username}", username);
                return false;
            }
        }

        // Helper method to hash a password using SHA256
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        // Check if provided password matches stored hash
        private bool VerifyPassword(string password, string storedHash)
        {
            string hash = HashPassword(password);
            return hash == storedHash;
        }
    }
}
