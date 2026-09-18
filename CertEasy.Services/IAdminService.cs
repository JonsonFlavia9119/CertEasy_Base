using CertEasy.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertEasy.Services
{
    public interface IAdminService
    {
        Task<IEnumerable<Application>> GetAllApplicationsAsync();
        Task<IEnumerable<Application>> GetApplicationsInReviewAsync();
        Task<IEnumerable<Application>> GetCompletedApplicationsAsync();
        Task<Application?> GetApplicationByIdAsync(int id);
        Task<bool> ApproveApplicationAsync(int id, string adminUser);
        Task<bool> RejectApplicationAsync(int id, string adminUser);
        Task<bool> AssignBadgeAsync(int applicationId, string badgeName, string? badgeId, string adminUser);

        // Certification Management
        Task<IEnumerable<Certification>> GetCertificationsAsync();
        Task<Certification?> GetCertificationByIdAsync(int id);
        Task<bool> AddCertificationAsync(Certification certification, string adminUser);
        Task<bool> UpdateCertificationAsync(Certification certification, string adminUser);
        Task<bool> DeleteCertificationAsync(int id);
        Task<bool> ToggleCertificationStatusAsync(int id, string adminUser);

        // Address Management
        Task<IEnumerable<Address>> GetAllAddressesAsync();
        Task<Address?> GetAddressByIdAsync(int id);
        Task<bool> AddAddressAsync(Address address, string adminUser);
        Task<bool> UpdateAddressAsync(Address address, string adminUser);
        Task<bool> DeleteAddressAsync(int id);

        // Education Management
        Task<IEnumerable<Education>> GetAllEducationAsync();
        Task<Education?> GetEducationByIdAsync(int id);
        Task<bool> AddEducationAsync(Education education, string adminUser);
        Task<bool> UpdateEducationAsync(Education education, string adminUser);
        Task<bool> DeleteEducationAsync(int id);

        // Exam Management
        Task<IEnumerable<Exam>> GetAllExamsAsync();
        Task<Exam?> GetExamByIdAsync(int id);
        Task<bool> AddExamAsync(Exam exam, string adminUser);
        Task<bool> UpdateExamAsync(Exam exam, string adminUser);
        Task<bool> DeleteExamAsync(int id);

        // Email Configuration
        Task<EmailConfiguration> GetEmailConfigurationAsync();
        Task<bool> UpdateEmailConfigurationAsync(EmailConfiguration model, string adminUser);
        Task<bool> SendTestEmailAsync(string targetEmail);
    }
}
