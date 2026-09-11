using System;
using System.Threading.Tasks;

namespace CertEasy.Services
{
    public interface IEmailService
    {
        Task<bool> SendAsync(string recipientEmail, string subject, string htmlBody);
        Task<bool> SendApplicationRejectedEmailAsync(string recipientEmail, string applicantName, string certificationName, string remarks);
        
        /// <summary>
        /// Sends an email notification to the admin recipient upon application approval or rejection.
        /// </summary>
        Task<bool> SendAdminNotificationEmailAsync(string userName, int applicationId, string examName, DateTime submittedDate, bool isApproved);
    }
}