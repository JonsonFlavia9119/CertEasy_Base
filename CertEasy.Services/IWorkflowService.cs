using CertEasy.Model;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertEasy.Services
{
    public interface IWorkflowService
    {
        Task<IEnumerable<Certification>> GetActiveCertificationsAsync();
        Task<bool> SubmitApplicationAsync(Application application);
        Task<bool> SubmitApplicationAsync(Application application, IFormFile? certificationDocument, IFormFile? educationDocument, string? uploadsFolder);
        Task<bool> ResubmitApplicationAsync(int id, int userId);
        Task<IEnumerable<Application>> GetUserApplicationsAsync(int userId);
        Task<IEnumerable<Application>> GetAllApplicationsAsync();
        Task<Application?> GetApplicationByIdAsync(int id);
        Task<IEnumerable<Exam>> GetExamsAsync();
        Task<IEnumerable<Education>> GetAllEducationsAsync();
    }
}
