using CertEasy.Model;

namespace CertEasy.Services
{
    public interface IAdminService
    {
        Task<IEnumerable<Application>> GetApplicationsInReviewAsync();
        Task<bool> ApproveApplicationAsync(int applicationId);
        Task<bool> RejectApplicationAsync(int applicationId);
        
        // Master Data
        Task<IEnumerable<Certification>> GetCertificationsAsync();
        Task<bool> AddCertificationAsync(Certification cert);
        Task<bool> ToggleCertificationStatusAsync(int id);

        Task<IEnumerable<EducationLevel>> GetEducationLevelsAsync();
        Task<bool> AddEducationLevelAsync(EducationLevel edu);
        Task<bool> ToggleEducationLevelStatusAsync(int id);
    }
}