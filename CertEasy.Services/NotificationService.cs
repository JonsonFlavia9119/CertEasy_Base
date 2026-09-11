using CertEasy.Data;
using CertEasy.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CertEasy.Services
{
    public class NotificationService : INotificationService
    {        private readonly CertEasyDbContext _context;
        private readonly IEmailService _emailService;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(CertEasyDbContext context, IEmailService emailService, ILogger<NotificationService> logger)
        {
            _context = context;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task SendApplicationStatusEmailAsync(int applicationId, bool isApproved)
        {
            try
            {
                var application = await _context.Applications
                    .Include(a => a.User)
                    .Include(a => a.Certification)
                    .Include(a => a.Exam)
                    .FirstOrDefaultAsync(a => a.Id == applicationId);

                if (application == null)
                {
                    _logger.LogWarning("Cannot send status email: Application {Id} not found.", applicationId);
                    return;
                }

                // 1. Send Status Email to Applicant (Existing functionality)
                if (application.User != null && application.Certification != null)
                {
                    string recipientEmail = application.User.Email;
                    string applicantName = $"{application.User.FirstName} {application.User.LastName}";
                    string certName = application.Certification.Name;

                    if (isApproved)
                    {
                        string subject = "Application Approved - CertEasy";
                        string body = $"<h3>Congratulations {applicantName}!</h3><p>Your application for <strong>{certName}</strong> has been approved.</p>";
                        await _emailService.SendAsync(recipientEmail, subject, body);
                    }
                    else
                    {
                        await _emailService.SendApplicationRejectedEmailAsync(recipientEmail, applicantName, certName, application.Remarks ?? "");
                    }
                }

                // 2. Send Notification Email to Admin Recipient (New Requirement)
                // The body content should be UserName, ApplicationId, Exam Name and SubmittedDateTime
                string userName = application.User?.Email ?? "Unknown";
                string examName = application.Exam?.ExamName ?? "N/A";
                
                await _emailService.SendAdminNotificationEmailAsync(
                    userName, 
                    application.Id, 
                    examName, 
                    application.SubmittedDate, 
                    isApproved);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in SendApplicationStatusEmailAsync for Application {Id}", applicationId);
            }
        }
    }
}