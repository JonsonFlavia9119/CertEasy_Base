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

        private async Task CreateAccountForUserAsync(User user, string createdBy)
        {
            var account = new Account
            {
                UserID = user.Id,
                UserName = user.Email,
                Email = user.Email,
                Status = 1, // Active
                CreatedDate = DateTime.UtcNow,
                CreatedBy = createdBy,
                UpdatedDate = DateTime.UtcNow,
                UpdatedBy = createdBy
            };
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
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

                await CreateAccountForUserAsync(user, user.Email);

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
            var user = await _context.Users.Include(u => u.Role).Include(u => u.Account).FirstOrDefaultAsync(u => u.Email == email);
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

            var user = await _context.Users.Include(u => u.Role).Include(u => u.Account)
                .FirstOrDefaultAsync(u => u.Email == windowsIdentifier);

            if (user == null)
            {
                if (windowsIdentifier.Equals("admin@certeasy.local", StringComparison.OrdinalIgnoreCase))
                {
                    user = await _context.Users.Include(u => u.Role).Include(u => u.Account)
                        .FirstOrDefaultAsync(u => u.Email == "admin@certeasy.local");
                }
                else
                {
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
                        PasswordHash = "",
                        RoleID = (int)UserRole.User,
                        StatusID = (int)ApplicationStatus.New,
                        CreatedBy = "WindowsAuth",
                        CreatedDate = DateTime.UtcNow,
                        UpdatedBy = "WindowsAuth",
                        UpdatedDate = DateTime.UtcNow,
                    };
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    await CreateAccountForUserAsync(user, "WindowsAuth");
                    
                    user = await _context.Users.Include(u => u.Role).Include(u => u.Account).FirstOrDefaultAsync(u => u.Id == user.Id);
                }
            }
            return user;
        }
    }
}
