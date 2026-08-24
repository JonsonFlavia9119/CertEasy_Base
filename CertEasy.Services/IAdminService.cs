using CertEasy.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertEasy.Services
{
    public interface IAdminService
    {
        Task<IEnumerable<Application>> GetApplicationsInReviewAsync();
        Task<bool> ApproveApplicationAsync(int id, string adminUser);
        Task<bool> RejectApplicationAsync(int id, string adminUser);

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
    }
}