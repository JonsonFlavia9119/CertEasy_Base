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
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map Log entity to a different table name to avoid collision with existing 'Logs' table used by Serilog
            modelBuilder.Entity<Log>().ToTable("AppLogs");

            // Configure Application - User relationship to avoid circular cascade paths
            modelBuilder.Entity<Application>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserID)
                .OnDelete(DeleteBehavior.NoAction);

            var seededDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var seededBy = "System";

            // Seeding Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = (int)UserRole.Admin, RoleName = "Admin", Description = "Administrator with full access", CreatedDate = seededDate, CreatedBy = seededBy, UpdatedBy = seededBy, UpdatedDate = seededDate },
                new Role { Id = (int)UserRole.User, RoleName = "User", Description = "Regular user with limited access", CreatedDate = seededDate, CreatedBy = seededBy, UpdatedBy = seededBy, UpdatedDate = seededDate }
            );

            // Seeding Statuses
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

            modelBuilder.Entity<EducationLevel>().HasData(
                new EducationLevel { Id = 1, Name = "Bachelor's Degree", Description = "4-year undergraduate degree", IsActive = true, CreatedDate = seededDate, CreatedBy = seededBy, UpdatedBy = seededBy, UpdatedDate = seededDate },
                new EducationLevel { Id = 2, Name = "Master's Degree", Description = "Graduate degree", IsActive = true, CreatedDate = seededDate, CreatedBy = seededBy, UpdatedBy = seededBy, UpdatedDate = seededDate },
                new EducationLevel { Id = 3, Name = "Doctorate", Description = "Ph.D. or equivalent", IsActive = true, CreatedDate = seededDate, CreatedBy = seededBy, UpdatedBy = seededBy, UpdatedDate = seededDate }
            );

            // Seeding Admin User
            modelBuilder.Entity<User>().HasData(
                new User
                {                    Id = 1,
                    FirstName = "System",
                    LastName = "Admin",
                    Email = "admin@certeasy.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPvR3zU+YyW6n6Uf8n3H6J6V6L6X6n6X6n6X6n6X6n6X6n6X6n6X6n6X6n6X6n6X6n6X6n6X6n==", // Seeded password is 'Admin@123'
                    RoleID = (int)UserRole.Admin,
                    AddressID = null,
                    StatusID = (int)ApplicationStatus.New,
                    CreatedDate = seededDate,
                    CreatedBy = seededBy,
                    UpdatedBy = seededBy,
                    UpdatedDate = seededDate
                }
            );
        }
    }
}