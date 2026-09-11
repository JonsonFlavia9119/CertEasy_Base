using System.Threading.Tasks;

namespace CertEasy.Services
{
    public interface INotificationService
    {
        Task SendApplicationStatusEmailAsync(int applicationId, bool approved);
    }
}