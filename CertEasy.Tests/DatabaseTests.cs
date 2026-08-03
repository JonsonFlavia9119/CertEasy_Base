using CertEasy.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;
using System;
using System.Linq;

namespace CertEasy.Tests
{
    public class DatabaseTests
    {
        private readonly string _connectionString;

        public DatabaseTests()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            _connectionString = config.GetConnectionString("DefaultConnection") 
                               ?? "Server=(localdb)\\mssqllocaldb;Database=CertEasyDb;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        [Fact]
        public void CanConnectToDatabaseAndSeedDataExists()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CertEasyDbContext>()
                .UseSqlServer(_connectionString)
                .Options;

            using var context = new CertEasyDbContext(options);

            // Act & Assert
            try
            {
                // Ensure database is created and migrations applied
                context.Database.Migrate();

                var adminRole = context.Roles.FirstOrDefault(r => r.RoleName == "Admin");
                
                Assert.NotNull(adminRole);
                Assert.Equal("System", adminRole.CreatedBy);
                Assert.Equal("System", adminRole.UpdatedBy);

                var adminUser = context.Users.FirstOrDefault(u => u.Email == "admin@certeasy.local");
                Assert.NotNull(adminUser);
                Assert.Equal(1, adminUser.RoleID);
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Database connection or seed validation failed: {ex.Message}");
            }
        }

        [Fact]
        public void Models_ShouldInheritFromBaseEntity()
        {
            Assert.True(typeof(BaseEntity).IsAssignableFrom(typeof(Role)));
            Assert.True(typeof(BaseEntity).IsAssignableFrom(typeof(User)));
            Assert.True(typeof(BaseEntity).IsAssignableFrom(typeof(Status)));
            Assert.True(typeof(BaseEntity).IsAssignableFrom(typeof(Certification)));
            Assert.True(typeof(BaseEntity).IsAssignableFrom(typeof(EducationLevel)));
            Assert.True(typeof(BaseEntity).IsAssignableFrom(typeof(Address)));
            Assert.True(typeof(BaseEntity).IsAssignableFrom(typeof(Application)));
        }
    }
}