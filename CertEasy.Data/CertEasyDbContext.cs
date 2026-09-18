using CertEasy.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace CertEasy.Data
{
    public class CertEasyDbContext : DbContext
    {
        public CertEasyDbContext(DbContextOptions<CertEasyDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<EmailConfiguration> EmailConfigurations { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<FileUpload> FileUploads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmailConfiguration>(entity =>
            {
                entity.ToTable("EmailConfigurations");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.SenderEmail).IsRequired().HasMaxLength(255);
                entity.Property(e => e.SenderName).IsRequired().HasMaxLength(255);
            });

            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, StatusName = "New", CreatedBy = "System", CreatedDate = new DateTime(2023, 1, 1), UpdatedBy = "System", UpdatedDate = new DateTime(2023, 1, 1) },
                new Status { Id = 2, StatusName = "User Profile", CreatedBy = "System", CreatedDate = new DateTime(2023, 1, 1), UpdatedBy = "System", UpdatedDate = new DateTime(2023, 1, 1) },
                new Status { Id = 3, StatusName = "Certification Selection", CreatedBy = "System", CreatedDate = new DateTime(2023, 1, 1), UpdatedBy = "System", UpdatedDate = new DateTime(2023, 1, 1) },
                new Status { Id = 4, StatusName = "Educational Qualification", CreatedBy = "System", CreatedDate = new DateTime(2023, 1, 1), UpdatedBy = "System", UpdatedDate = new DateTime(2023, 1, 1) },
                new Status { Id = 5, StatusName = "Invoice", CreatedBy = "System", CreatedDate = new DateTime(2023, 1, 1), UpdatedBy = "System", UpdatedDate = new DateTime(2023, 1, 1) },
                new Status { Id = 6, StatusName = "Review", CreatedBy = "System", CreatedDate = new DateTime(2023, 1, 1), UpdatedBy = "System", UpdatedDate = new DateTime(2023, 1, 1) },
                new Status { Id = 7, StatusName = "Approved", CreatedBy = "System", CreatedDate = new DateTime(2023, 1, 1), UpdatedBy = "System", UpdatedDate = new DateTime(2023, 1, 1) },
                new Status { Id = 8, StatusName = "Rejection", CreatedBy = "System", CreatedDate = new DateTime(2023, 1, 1), UpdatedBy = "System", UpdatedDate = new DateTime(2023, 1, 1) },
                new Status { Id = 200, StatusName = "Completed", CreatedBy = "System", CreatedDate = new DateTime(2023, 1, 1), UpdatedBy = "System", UpdatedDate = new DateTime(2023, 1, 1) }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin", Description = "Administrator with full access", CreatedBy = "System", CreatedDate = new DateTime(2023, 1, 1), UpdatedBy = "System", UpdatedDate = new DateTime(2023, 1, 1) },
                new Role { Id = 2, RoleName = "User", Description = "Regular user with limited access", CreatedBy = "System", CreatedDate = new DateTime(2023, 1, 1), UpdatedBy = "System", UpdatedDate = new DateTime(2023, 1, 1) }
            );

            modelBuilder.Entity<Certification>().HasData(
                new Certification { Id = 1, Name = "Certified Safety Professional (CSP)", Description = "Leading safety certification", IsActive = true, CreatedBy = "System", CreatedDate = new DateTime(2023, 1, 1), UpdatedBy = "System", UpdatedDate = new DateTime(2023, 1, 1) },
                new Certification { Id = 2, Name = "Associate Safety Professional (ASP)", Description = "Entry-level safety certification", IsActive = true, CreatedBy = "System", CreatedDate = new DateTime(2023, 1, 1), UpdatedBy = "System", UpdatedDate = new DateTime(2023, 1, 1) }
            );

            modelBuilder.Entity<Education>().HasData(
                new Education { Id = 1, Name = "Bachelor's Degree", Description = "4-year undergraduate degree", IsActive = true, CreatedBy = "System", CreatedDate = new DateTime(2023, 1, 1), UpdatedBy = "System", UpdatedDate = new DateTime(2023, 1, 1) },
                new Education { Id = 2, Name = "Master's Degree", Description = "Graduate degree", IsActive = true, CreatedBy = "System", CreatedDate = new DateTime(2023, 1, 1), UpdatedBy = "System", UpdatedDate = new DateTime(2023, 1, 1) },
                new Education { Id = 3, Name = "Doctorate", Description = "Ph.D. or equivalent", IsActive = true, CreatedBy = "System", CreatedDate = new DateTime(2023, 1, 1), UpdatedBy = "System", UpdatedDate = new DateTime(2023, 1, 1) }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "System", LastName = "Admin", Email = "admin@certeasy.local", PasswordHash = "AQAAAAEAACcQAAAAEPvR3zU+YyW6n6Uf8n3H6J6V6L6X6n6X6n6X6n6X6n6X6n6X6n6X6n6X6n6X6n6X6n==", RoleID = 1, StatusID = 1, CreatedBy = "System", CreatedDate = new DateTime(2023, 1, 1), UpdatedBy = "System", UpdatedDate = new DateTime(2023, 1, 1) }
            );
        }
    }
}
