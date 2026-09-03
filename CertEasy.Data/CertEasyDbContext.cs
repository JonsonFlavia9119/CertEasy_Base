using Microsoft.EntityFrameworkCore;
using System;
using CertEasy.Model;

namespace CertEasy.Data
{
    public class CertEasyDbContext : DbContext
    {
        public CertEasyDbContext(DbContextOptions<CertEasyDbContext> options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Exam> Exams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Log>().ToTable("AppLogs");
            modelBuilder.Entity<Education>().ToTable("Educations");
            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<Status>().ToTable("Statuses");
            modelBuilder.Entity<Exam>().ToTable("Exams");
            modelBuilder.Entity<Application>().ToTable("Applications");

            modelBuilder.Entity<Application>()
                .Property(a => a.ExamID)
                .HasColumnName("ExamID");

            modelBuilder.Entity<Application>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.Exam)
                .WithMany()
                .HasForeignKey(a => a.ExamID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Account>()
                .HasIndex(a => a.UserID)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasOne(u => u.Account)
                .WithOne(a => a.User)
                .HasForeignKey<Account>(a => a.UserID);

            var seededDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var seededBy = "System";

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = (int)UserRole.Admin, RoleName = "Admin", Description = "Administrator with full access", CreatedDate = seededDate, CreatedBy = seededBy, UpdatedBy = seededBy, UpdatedDate = seededDate },
                new Role { Id = (int)UserRole.User, RoleName = "User", Description = "Regular user with limited access", CreatedDate = seededDate, CreatedBy = seededBy, UpdatedBy = seededBy, UpdatedDate = seededDate }
            );

            modelBuilder.Entity<Status>().HasData(
                new Status { Id = (int)ApplicationStatus.New, StatusName = "New", CreatedDate = seededDate, CreatedBy = seededBy, UpdatedBy = seededBy, UpdatedDate = seededDate },
                new Status { Id = (int)ApplicationStatus.UserProfile, StatusName = "User Profile", CreatedDate = seededDate, CreatedBy = seededBy, UpdatedBy = seededBy, UpdatedDate = seededDate },
                new Status { Id = (int)ApplicationStatus.CertificationSelection, StatusName = "Certification Selection", CreatedDate = seededDate, CreatedBy = seededBy, UpdatedBy = seededBy, UpdatedDate = seededDate },
                new Status { Id = (int)ApplicationStatus.EducationalQualification, StatusName = "Educational Qualification", CreatedDate = seededDate, CreatedBy = seededBy, UpdatedBy = seededBy, UpdatedDate = seededDate },
                new Status { Id = (int)ApplicationStatus.Invoice, StatusName = "Invoice", CreatedDate = seededDate, CreatedBy = seededBy, UpdatedBy = seededBy, UpdatedDate = seededDate },
                new Status { Id = (int)ApplicationStatus.Review, StatusName = "Review", CreatedDate = seededDate, CreatedBy = seededBy, UpdatedBy = seededBy, UpdatedDate = seededDate },
                new Status { Id = (int)ApplicationStatus.Approved, StatusName = "Approved", CreatedDate = seededDate, CreatedBy = seededBy, UpdatedBy = seededBy, UpdatedDate = seededDate },
                new Status { Id = (int)ApplicationStatus.Rejection, StatusName = "Rejection", CreatedDate = seededDate, CreatedBy = seededBy, UpdatedBy = seededBy, UpdatedDate = seededDate }
            );

            modelBuilder.Entity<Certification>().HasData(
                new Certification { Id = 1, Name = "Certified Safety Professional (CSP)", Description = "Leading safety certification", IsActive = true, CreatedDate = seededDate, CreatedBy = seededBy, UpdatedBy = seededBy, UpdatedDate = seededDate },
                new Certification { Id = 2, Name = "Associate Safety Professional (ASP)", Description = "Entry-level safety certification", IsActive = true, CreatedDate = seededDate, CreatedBy = seededBy, UpdatedBy = seededBy, UpdatedDate = seededDate }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "System",
                    LastName = "Admin",
                    Email = "admin@certeasy.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPvH/9R7xK9n8x5...",
                    RoleID = (int)UserRole.Admin,
                    AddressID = null,
                    StatusID = (int)ApplicationStatus.New,
                    CreatedDate = seededDate,
                    CreatedBy = seededBy,
                    UpdatedBy = seededBy,
                    UpdatedDate = seededDate
                }
            );

            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = 1,
                    UserID = 1,
                    UserName = "admin@certeasy.local",
                    Email = "admin@certeasy.local",
                    Status = 1,
                    CreatedDate = seededDate,
                    CreatedBy = seededBy,
                    UpdatedBy = seededBy,
                    UpdatedDate = seededDate
                }
            );

            modelBuilder.Entity<Exam>().HasData(
                new Exam { Id = 1, ExamName = "Spring 2024 Exam Session", ExamCenter = "New York Testing Center", ExamSlot = new DateTime(2024, 4, 15, 10, 0, 0, DateTimeKind.Utc), CreatedDate = seededDate, CreatedBy = seededBy, UpdatedBy = seededBy, UpdatedDate = seededDate },
                new Exam { Id = 2, ExamName = "Spring 2024 Exam Session", ExamCenter = "Chicago Testing Center", ExamSlot = new DateTime(2024, 4, 16, 14, 0, 0, DateTimeKind.Utc), CreatedDate = seededDate, CreatedBy = seededBy, UpdatedBy = seededBy, UpdatedDate = seededDate }
            );
        }
    }
}
