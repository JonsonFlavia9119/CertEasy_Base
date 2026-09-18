using CertEasy.Model;
using CertEasy.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CertEasy.Services
{
    public class WorkflowService : IWorkflowService
    {
        private readonly CertEasyDbContext _context;
        private readonly ILogger<WorkflowService>? _logger;

        public WorkflowService(CertEasyDbContext context, ILogger<WorkflowService>? logger = null)
        { 
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Certification>> GetActiveCertificationsAsync()
        {
            return await _context.Certifications.Where(c => c.IsActive).ToListAsync();
        }

        public async Task<bool> SubmitApplicationAsync(Application application)
        {
            return await SubmitApplicationAsync(application, null, null, null);
        }

        public async Task<bool> SubmitApplicationAsync(Application application, IFormFile? certificationDocument, IFormFile? educationDocument, string? uploadsFolder)
        {
            try
            {
                if (application == null) throw new ArgumentNullException(nameof(application));

                // Validation Logic: User can't have multiple pending applications for the same certification
                var existing = await _context.Applications
                    .AnyAsync(a => a.UserID == application.UserID &&
                                   a.CertificationID == application.CertificationID &&
                                   (a.StatusID == (int)ApplicationStatus.New || a.StatusID == (int)ApplicationStatus.Review));

                if (existing)
                {
                    _logger?.LogWarning("User {UserId} already has a pending application for certification {CertificationId}.", application.UserID, application.CertificationID);
                    return false;
                }

                _context.Applications.Add(application);
                await _context.SaveChangesAsync();

                // Process uploaded files if provided
                if (!string.IsNullOrEmpty(uploadsFolder))
                {
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    if (certificationDocument != null && certificationDocument.Length > 0)
                    {
                        await SaveFileUploadInternalAsync(certificationDocument, application.Id, application.CertificationID, uploadsFolder, application.CreatedBy);
                    }

                    if (educationDocument != null && educationDocument.Length > 0)
                    {
                        await SaveFileUploadInternalAsync(educationDocument, application.Id, application.EducationLevelID, uploadsFolder, application.CreatedBy);
                    }
                }

                _logger?.LogInformation("Application {ApplicationId} submitted successfully.", application.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error occurred while submitting application for user {UserId}.", application?.UserID);
                throw;
            }
        }

        private async Task SaveFileUploadInternalAsync(IFormFile file, long entityId, long entityTypeId, string uploadsFolder, string createdBy)
        {
            try
            {
                var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
                var fullPath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var fileUpload = new FileUpload
                {
                    FileName = Path.GetFileName(file.FileName),
                    FilePath = Path.Combine("FileUploads", uniqueFileName),
                    ContentType = file.ContentType ?? "application/octet-stream",
                    FileSize = file.Length,
                    EntityId = entityId,
                    EntityTypeId = entityTypeId,
                    CreatedBy = createdBy ?? "System",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = createdBy ?? "System",
                    UpdatedDate = DateTime.UtcNow
                };

                _context.FileUploads.Add(fileUpload);
                await _context.SaveChangesAsync();
                _logger?.LogInformation("Saved file {FileName} for entity {EntityId} and type {EntityTypeId}.", fileUpload.FileName, entityId, entityTypeId);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error saving file upload {FileName} for entity {EntityId}.", file.FileName, entityId);
                throw;
            }
        }

        public async Task<bool> ResubmitApplicationAsync(int id, int userId)
        {
            try
            {
                var application = await _context.Applications.FirstOrDefaultAsync(a => a.Id == id);
                if (application == null)
                {
                    return false;
                }

                // Verify the application belongs to the user (if userId > 0), and is in Rejected status
                if (userId > 0 && application.UserID != userId)
                {
                    return false;
                }

                if (application.StatusID != (int)ApplicationStatus.Rejection)
                {
                    return false;
                }

                // Update status to Review so admin users can re-evaluate and approve
                application.StatusID = (int)ApplicationStatus.Review;
                application.SubmittedDate = DateTime.UtcNow;
                application.UpdatedBy = userId > 0 ? userId.ToString() : "System";
                application.UpdatedDate = DateTime.UtcNow;

                _context.Applications.Update(application);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Application>> GetUserApplicationsAsync(int userId)
        {
            return await _context.Applications
                .Include(a => a.Certification)
                .Include(a => a.Status)
                .Include(a => a.Exam)
                .Include(a => a.User)
                .Where(a => a.UserID == userId)
                .OrderByDescending(a => a.SubmittedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Application>> GetAllApplicationsAsync()
        {
            try
            {
                return await _context.Applications
                    .Include(a => a.Certification)
                    .Include(a => a.Status)
                    .Include(a => a.Exam)
                    .Include(a => a.User)
                    .OrderByDescending(a => a.SubmittedDate)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Application?> GetApplicationByIdAsync(int id)
        {
            return await _context.Applications
                .Include(a => a.Certification)
                .Include(a => a.Status)
                .Include(a => a.Exam)
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Exam>> GetExamsAsync()
        {
            return await _context.Exams.ToListAsync();
        }

        public async Task<IEnumerable<Education>> GetAllEducationsAsync()
        {
            return await _context.Educations.Where(e => e.IsActive).ToListAsync();
        }
    }
}
