using CertEasy.Model;

namespace CertEasy.Services
{
    public interface IWorkflowService
    {
        Task<IEnumerable<Certification>> GetActiveCertificationsAsync();
        Task<bool> SubmitApplicationAsync(Application application);
        Task<IEnumerable<Application>> GetUserApplicationsAsync(int userId);
        Task<Application> GetApplicationByIdAsync(int id);
    }
}