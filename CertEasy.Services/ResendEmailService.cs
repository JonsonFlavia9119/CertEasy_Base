using CertEasy.Data;
using CertEasy.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Resend;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace CertEasy.Services
{
    public class ResendEmailService : IEmailService
    {
        private readonly HttpClient _httpClient;
        private readonly CertEasyDbContext _context;
        private readonly ILogger<ResendEmailService> _logger;

        public ResendEmailService(HttpClient httpClient, CertEasyDbContext context, ILogger<ResendEmailService> logger)
        {
            _httpClient = httpClient;
            _context = context;
            _logger = logger;
        }

        public async Task<bool> SendAsync(string recipientEmail, string subject, string htmlBody)
        {
            try
            {
                var config = await _context.EmailConfigurations.FirstOrDefaultAsync();
                if (config == null || string.IsNullOrEmpty(config.SenderEmail))
                {
                    _logger.LogError("Email configuration is missing or invalid in the database.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(config.ApiKey))
                {
                    _logger.LogError("Resend API key is missing in the database configuration.");
                    return false;
                }

                // Use the API key dynamically from the database for each request
                var resendOptions = new ResendClientOptions
                {
                    ApiToken = config.ApiKey
                };

                var optionsWrapper = Microsoft.Extensions.Options.Options.Create(resendOptions);
                var snapshotWrapper = new OptionsSnapshotWrapper(optionsWrapper.Value);
                var resend = new ResendClient(snapshotWrapper, _httpClient);

                var message = new EmailMessage();
                message.From = string.IsNullOrWhiteSpace(config.SenderName) 
                    ? config.SenderEmail 
                    : $"{config.SenderName} <{config.SenderEmail}>";
                message.To.Add(recipientEmail);
                message.Subject = subject;
                message.HtmlBody = htmlBody;

                await resend.EmailSendAsync(message);
                _logger.LogInformation("Email sent successfully to {Recipient}", recipientEmail);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email to {Recipient}", recipientEmail);
                return false;
            }
        }

        public async Task<bool> SendApplicationRejectedEmailAsync(string recipientEmail, string applicantName, string certificationName, string remarks)
        {
            string subject = "Application Status Update - CertEasy";
            string body = $"""
                <h3>Dear {applicantName},</h3>
                <p>We regret to inform you that your application for the <strong>{certificationName}</strong> certification has been rejected.</p>
                <p><strong>Remarks:</strong> {remarks ?? "No additional remarks provided."}</p>
                <p>If you have any questions, please contact our support team.</p>
                <br/>
                <p>Best regards,<br/>CertEasy Admin Team</p>
                """;

            return await SendAsync(recipientEmail, subject, body);
        }

        public async Task<bool> SendAdminNotificationEmailAsync(string userName, int applicationId, string examName, DateTime submittedDate, bool isApproved)
        {
            try
            {
                var config = await _context.EmailConfigurations.FirstOrDefaultAsync();
                if (config == null || string.IsNullOrWhiteSpace(config.ApiKey))
                {
                    _logger.LogError("Email configuration or API key is missing for admin notification.");
                    return false;
                }

                var resendOptions = new ResendClientOptions { ApiToken = config.ApiKey };
                var optionsWrapper = Microsoft.Extensions.Options.Options.Create(resendOptions);
                var snapshotWrapper = new OptionsSnapshotWrapper(optionsWrapper.Value);
                var resend = new ResendClient(snapshotWrapper, _httpClient);

                var message = new EmailMessage();
                // Requirement: Use from Email \"onboarding@resend.dev\"
                message.From = "onboarding@resend.dev";
                // Requirement: Use recipient email \"delivered@resend.dev\"
                message.To.Add("delivered@resend.dev");
                // Requirement: The Subject would be Application Reject or Application Approval based on action
                message.Subject = isApproved ? "Application Approval" : "Application Reject";
                
                // Requirement: The body content should be UserName, ApplicationId, Exam Name and SubmittedDateTime
                message.HtmlBody = $"""
                    <p><strong>UserName:</strong> {userName}</p>
                    <p><strong>ApplicationId:</strong> {applicationId}</p>
                    <p><strong>Exam Name:</strong> {examName ?? "N/A"}</p>
                    <p><strong>SubmittedDateTime:</strong> {submittedDate:f}</p>
                    """;

                await resend.EmailSendAsync(message);
                _logger.LogInformation("Admin notification email sent for Application ID {Id}", applicationId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send admin notification email for Application ID {Id}", applicationId);
                return false;
            }
        }

        private class OptionsSnapshotWrapper : IOptionsSnapshot<ResendClientOptions>
        {
            public OptionsSnapshotWrapper(ResendClientOptions value)
            {
                Value = value;
            }

            public ResendClientOptions Value { get; }

            public ResendClientOptions Get(string? name)
            {
                return Value;
            }
        }
    }
}