using CertEasy.Model;
using CertEasy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CertEasy.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly CertEasyDbContext _context;
        private readonly IPasswordService _passwordService;

        public AccountService(CertEasyDbContext context, IPasswordService passwordService, ILogger<AccountService> logger) : base(logger)
        {
            _context = context;
            _passwordService = passwordService;
        }

        public async Task<User?> RegisterAsync(User user, string password)
        {
            try
            {
                if (await _context.Users.AnyAsync(u => u.Email == user.Email))
                {
                    _logger.LogWarning("Registration failed: Email {Email} already exists.", user.Email);
                    return null;
                }

                user.PasswordHash = _passwordService.HashPassword(password);
                user.RoleID = (int)UserRole.User;
                user.StatusID = (int)ApplicationStatus.New;
                user.CreatedDate = DateTime.UtcNow;
                user.CreatedBy = user.Email;
                user.UpdatedBy = user.Email;
                user.UpdatedDate = DateTime.UtcNow;

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user registration for {Email}", user.Email);
                throw;
            }
        }

        public async Task<User?> AuthenticateAsync(string email, string password)
        {
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);
            if (user == null || string.IsNullOrEmpty(user.PasswordHash))
            {
                return null;
            }

            if (_passwordService.VerifyPassword(user.PasswordHash, password))
            {
                return user;
            }

            return null;
        }

        public async Task<User?> GetUserByWindowsIdentityAsync(string windowsIdentifier)
        {
            if (string.IsNullOrEmpty(windowsIdentifier)) return null;

            var user = await _context.Users.Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == windowsIdentifier);

            if (user == null)
            {
                // Check if it's the specific seeded admin email
                if (windowsIdentifier.Equals("admin@certeasy.local", StringComparison.OrdinalIgnoreCase))
                {
                    user = await _context.Users.Include(u => u.Role)
                        .FirstOrDefaultAsync(u => u.Email == "admin@certeasy.local");
                }
                else
                {
                    // Auto-register Windows users if they don't exist
                    string fullName = windowsIdentifier;
                    if (windowsIdentifier.Contains('\\'))
                    {
                        fullName = windowsIdentifier.Split('\\').Last();
                    }

                    string firstName = fullName;
                    string lastName = "(Windows)";

                    if (fullName.Contains(' ')) 
                    {
                        var parts = fullName.Split(' ', 2);
                        firstName = parts[0];
                        lastName = parts[1];
                    }
                    else if (fullName.Contains('.'))
                    {
                        var parts = fullName.Split('.', 2);
                        firstName = parts[0];
                        lastName = parts[1];
                    }

                    user = new User
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Email = windowsIdentifier,
                        PasswordHash = "", // No password for Windows users
                        RoleID = (int)UserRole.User,
                        StatusID = (int)ApplicationStatus.New,
                        CreatedBy = "WindowsAuth",
                        CreatedDate = DateTime.UtcNow,
                        UpdatedBy = "WindowsAuth",
                        UpdatedDate = DateTime.UtcNow,
                    };
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                    
                    // Reload to get navigation properties
                    user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == user.Id);
                }
            }
            return user;
        }
    }
}
