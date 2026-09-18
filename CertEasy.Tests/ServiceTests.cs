using CertEasy.Model;
using CertEasy.Data;
using CertEasy.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
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
            Assert.True(context.Educations.Any(), "Educations should be seeded");
            Assert.True(context.Users.Any(), "Admin user should be seeded");

            var adminRole = context.Roles.FirstOrDefault(r => r.RoleName == "Admin");
            Assert.NotNull(adminRole);
            Assert.Equal("System", adminRole.UpdatedBy);

            // Verify Completed status (Id 200)
            var completedStatus = context.Statuses.FirstOrDefault(s => s.Id == 200);
            Assert.NotNull(completedStatus);
            Assert.Equal("Completed", completedStatus.StatusName);
        }

        [Fact]
        public void Database_Connection_IsWorking()
        {
            using var context = GetDbContext();
            var testRole = new Role { RoleName = "Test", CreatedBy = "Test" };
            context.Roles.Add(testRole);
            context.SaveChanges();

            var savedRole = context.Roles.FirstOrDefault(r => r.RoleName == "Test");
            Assert.NotNull(savedRole);
        }

        [Fact]
        public async Task AssignBadgeAsync_WithApprovedStatus_SuccessfullyAssignsBadgeAndUpdatesStatusTo200()
        {
            // Arrange
            using var context = GetDbContext();
            var mockNotification = new Mock<INotificationService>();
            var mockEmail = new Mock<IEmailService>();
            var adminService = new AdminService(context, NullLogger<AdminService>.Instance, mockNotification.Object, mockEmail.Object);

            var app = new Application
            {
                UserID = 1,
                CertificationID = 1,
                EducationLevelID = 1,
                StatusID = 7, // Approved status
                SubmittedDate = DateTime.UtcNow
            };
            context.Applications.Add(app);
            await context.SaveChangesAsync();

            // Act
            var result = await adminService.AssignBadgeAsync(app.Id, "Gold Safety Badge", "BDG-10001", "AdminUser");

            // Assert
            Assert.True(result);
            var updatedApp = await context.Applications.FindAsync(app.Id);
            Assert.NotNull(updatedApp);
            Assert.Equal(200, updatedApp.StatusID);
            Assert.Equal("Gold Safety Badge", updatedApp.BadgeName);
            Assert.Equal("BDG-10001", updatedApp.BadgeId);
            Assert.NotNull(updatedApp.BadgeAssignedDate);
            Assert.Equal("AdminUser", updatedApp.UpdatedBy);
        }
    }
}
