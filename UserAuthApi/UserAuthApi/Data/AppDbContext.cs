using Microsoft.EntityFrameworkCore;
using UserAuthApi.Models;

namespace UserAuthApi.Data
{
    // Database context class for Entity Framework Core
    public class AppDbContext : DbContext
    {
        // Constructor to pass database options to the base class
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Represents the Users table in the database
        public DbSet<User> Users { get; set; }
    }
}
