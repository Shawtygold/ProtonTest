using Microsoft.EntityFrameworkCore;
using ProtonTest.Models;

namespace ProtonTest.Services
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Test> Tests { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Option> Options { get; set; } = null!;
        public DbSet<TestResult> TestResults { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=protontest.db");
            optionsBuilder.UseMySql("server=localhost;user=root;password=;database=protontestdb;",
            new MySqlServerVersion(new Version(8, 0, 30)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id).HasColumnName("id");
                entity.Property(u => u.RoleId).HasColumnName("role_id");
                entity.Property(u => u.DepartmentId).HasColumnName("department_id");
                entity.Property(u => u.Username).HasColumnName("username");
                entity.Property(u => u.FullName).HasColumnName("fullname");
                entity.Property(u => u.PasswordHash).HasColumnName("password_hash");

                entity.HasOne(u => u.Role)
                      .WithMany(r => r.Users)
                      .HasForeignKey(u => u.RoleId)
                      .HasConstraintName("fk_users_roles")
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(u => u.Department)
                      .WithMany(d => d.Users)
                      .HasForeignKey(u => u.DepartmentId)
                      .HasConstraintName("fk_users_departments")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Id).HasColumnName("id");
                entity.Property(r => r.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("tests");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).HasColumnName("id");
                entity.Property(t => t.DepartmentId).HasColumnName("department_id");
                entity.Property(t => t.Title).HasColumnName("title");
                entity.Property(t => t.Description).HasColumnName("description");

                entity.HasOne(t => t.Department)
                      .WithMany()
                      .HasForeignKey(t => t.DepartmentId)
                      .HasConstraintName("fk_tests_departments")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("questions");
                entity.HasKey(q => q.Id);
                entity.Property(q => q.Id).HasColumnName("id");
                entity.Property(q => q.TestId).HasColumnName("test_id");
                entity.Property(q => q.QuestionText).HasColumnName("question_text");

                entity.HasOne(q => q.Test)
                      .WithMany(t => t.Questions)
                      .HasForeignKey(q => q.TestId)
                      .HasConstraintName("fk_questions_tests")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.ToTable("options");
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Id).HasColumnName("id");
                entity.Property(o => o.QuestionId).HasColumnName("question_id");
                entity.Property(o => o.OptionText).HasColumnName("option_text");
                entity.Property(o => o.IsCorrect).HasColumnName("is_correct");

                entity.HasOne(o => o.Question)
                      .WithMany(q => q.Options)
                      .HasForeignKey(o => o.QuestionId)
                      .HasConstraintName("fk_options_questions")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("departments");
                entity.HasKey(d => d.Id);
                entity.Property(d => d.Id).HasColumnName("id");
                entity.Property(d => d.Name).HasColumnName("name");
            });

            modelBuilder.Entity<TestResult>(entity =>
            {
                entity.ToTable("test_results");
                entity.HasKey(tr => tr.Id);
                entity.Property(tr => tr.Id).HasColumnName("id");
                entity.Property(tr => tr.UserId).HasColumnName("user_id");
                entity.Property(tr => tr.TestId).HasColumnName("test_id");
                entity.Property(tr => tr.TotalQuestions).HasColumnName("total_questions");
                entity.Property(tr => tr.CorrectAnswers).HasColumnName("correct_answers");
                entity.Property(tr => tr.DatePassed).HasColumnName("date_passed");

                entity.HasOne(tr => tr.User)
                      .WithMany(u => u.TestResults)
                      .HasForeignKey(tr => tr.UserId)
                      .HasConstraintName("fk_testresults_users")
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(tr => tr.Test)
                      .WithMany(t => t.TestResults)
                      .HasForeignKey(tr => tr.TestId)
                      .HasConstraintName("fk_testresults_tests")
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
