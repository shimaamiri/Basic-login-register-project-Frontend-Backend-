namespace UserAuthApi.Models
{
    // Represents a user entity for registration and login
    public class User
    {
        // Unique identifier for each user (auto-generated)
        public int Id { get; set; }

        // Username chosen by the user (must be unique)
        public required string Username { get; set; }

        // Email address of the user (must be unique)
        public required string Email { get; set; }

        // Hashed version of the user password (not stored as plain text)
        public required string PasswordHash { get; set; }
    }
}
