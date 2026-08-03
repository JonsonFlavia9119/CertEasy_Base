using CertEasy.Model;
using CertEasy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CertEasy.Services
{
    public class AdminService : BaseService, IAdminService
    {
        private readonly CertEasyDbContext _context;

        public AdminService(CertEasyDbContext context, ILogger<AdminService> logger) : base(logger)
        {
            _context = context;
        }

        public async Task<IEnumerable<Application>> GetApplicationsInReviewAsync()
        {
            return await _context.Applications
                .Include(a => a.User)
                .Include(a => a.Certification)
                .Include(a => a.Status)
                .Where(a => a.StatusID == (int)ApplicationStatus.Review)
                .ToListAsync();
        }

        public async Task<bool> ApproveApplicationAsync(int applicationId)
        {
            try
            {
                var application = await _context.Applications.FindAsync(applicationId);
                if (application == null) return false;

                application.StatusID = (int)ApplicationStatus.Approved; // Approved
                application.UpdatedDate = DateTime.UtcNow;
                application.UpdatedBy = "Admin";
                await _context.SaveChangesAsync();

                // Critical Action Logging
                _logger.LogInformation("Application approved. EntityType: {EntityType}, EntityID: {EntityID}, UserID: {UserID}", "Application", applicationId, application.UserID);
                
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error approving application ID: {ApplicationId}", applicationId);
                return false;
            }
        }

        public async Task<bool> RejectApplicationAsync(int applicationId)
        {
            try
            {
                var application = await _context.Applications.FindAsync(applicationId);
                if (application == null) return false;

                application.StatusID = (int)ApplicationStatus.Rejection; // Rejection
                application.UpdatedBy = "Admin";
                await _context.SaveChangesAsync();

                // Critical Action Logging
                _logger.LogInformation("Application rejected. EntityType: {EntityType}, EntityID: {EntityID}, UserID: {UserID}", "Application", applicationId, application.UserID);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error rejecting application ID: {ApplicationId}", applicationId);
                return false;
            }
        }

        // Master Data Implementation
        public async Task<IEnumerable<Certification>> GetCertificationsAsync()
        {
            return await _context.Certifications.ToListAsync();
        }

        public async Task<bool> AddCertificationAsync(Certification cert)
        {
            try
            {
                _context.Certifications.Add(cert);
                await _context.SaveChangesAsync();
                _logger.LogInformation("New certification added: {CertName}", cert.Name);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding certification: {CertName}", cert.Name);
                return false;
            }
        }

        public async Task<bool> ToggleCertificationStatusAsync(int id)
        {
            var cert = await _context.Certifications.FindAsync(id);
            if (cert == null) return false;
            cert.IsActive = !cert.IsActive;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<EducationLevel>> GetEducationLevelsAsync()
        {
            return await _context.EducationLevels.ToListAsync();
        }

        public async Task<bool> AddEducationLevelAsync(EducationLevel edu)
        {
            try
            {
                _context.EducationLevels.Add(edu);
                await _context.SaveChangesAsync();
                _logger.LogInformation("New education level added: {EduName}", edu.Name);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding education level: {EduName}", edu.Name);
                return false;
            }
        }

        public async Task<bool> ToggleEducationLevelStatusAsync(int id)
        {
            var edu = await _context.EducationLevels.FindAsync(id);
            if (edu == null) return false;
            edu.IsActive = !edu.IsActive;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
