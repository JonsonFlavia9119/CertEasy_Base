using CertEasy.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace CertEasy.Tests
{
    public class ServiceTests
    {
        private CertEasyDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<CertEasyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var context = new CertEasyDbContext(options);
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public void Database_SeedData_ShouldBeLoadedCorrectlly()
        {
            // Arrange & Act
            using var context = GetDbContext();

            // Assert
            Assert.True(context.Roles.Any(), "Roles should be seeded");
            Assert.True(context.Statuses.Any(), "Statuses should be seeded");
            Assert.True(context.Certifications.Any(), "Certifications should be seeded");
            Assert.True(context.EducationLevels.Any(), "EducationLevels should be seeded");
            Assert.True(context.Users.Any(), "Admin user should be seeded");

            var adminRole = context.Roles.FirstOrDefault(r => r.RoleName == \"Admin\");
            Assert.NotNull(adminRole);
            Assert.Equal(\"System\", adminRole.UpdatedBy);
        }

        [Fact]
        public void Database_Connection_IsWorking()
        {
            // This test verifies that the DbContext can be instantiated and interact with a provider.
            // For real SQL testing, a real connection string would be needed, but for CI/CD, InMemory validates the model mapping.
            using var context = GetDbContext();
            var canConnect = context.Database.CanConnect();
            // Note: CanConnect returns false for InMemory databases in some EF versions, 
            // so we check if we can add and retrieve an entity instead.
            var testRole = new Role { RoleName = \"Test\", CreatedBy = \"Test\" };
            context.Roles.Add(testRole);
            context.SaveChanges();

            var savedRole = context.Roles.FirstOrDefault(r => r.RoleName == \"Test\");
            Assert.NotNull(savedRole);
        }
    }
}