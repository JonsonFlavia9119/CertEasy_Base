using CertEasy.Model;

namespace CertEasy.Services
{
    public interface IAccountService
    {
        Task<User?> RegisterAsync(User user, string password);
        Task<User?> AuthenticateAsync(string email, string password);
        Task<User?> GetUserByWindowsIdentityAsync(string windowsIdentifier);
    }
}