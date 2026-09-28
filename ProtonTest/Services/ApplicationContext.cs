using Microsoft.EntityFrameworkCore;

namespace ProtonTest.Services
{
    public class ApplicationContext : DbContext
    {
        public DbSet<TestResult> TestResults { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=protontest.db");
        }
    }
}
