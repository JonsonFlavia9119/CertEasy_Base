using CertEasy.Web.Models;
using CertEasy.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Negotiate;
using CertEasy.Model;

namespace CertEasy.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            _logger.LogInformation("Login GET requested.");
            if (User.Identity?.IsAuthenticated == true) 
            {
                _logger.LogInformation("User {User} already authenticated, redirecting to Home.", User.Identity.Name);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            _logger.LogInformation("Login POST requested for {Email}.", model.Email);
            if (ModelState.IsValid)
            {
                var user = await _accountService.AuthenticateAsync(model.Email, model.Password);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.RoleID == (int)UserRole.Admin ? "Admin" : "User"),
                        new Claim("UserId", user.Id.ToString())
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    
                    _logger.LogInformation("User {Email} logged in successfully.", model.Email);
                    return RedirectToAction("Index", "Home");
                }
                _logger.LogWarning("Invalid login attempt for {Email}.", model.Email);
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            _logger.LogInformation("Register GET requested.");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            _logger.LogInformation("Register POST requested for {Email}.", model.Email);
            if (ModelState.IsValid)
            {
                var result = await _accountService.RegisterAsync(new Model.User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    RoleID = (int)UserRole.User
                }, model.Password);

                if (result != null)
                {
                    _logger.LogInformation("User {Email} registered successfully.", model.Email);
                    return RedirectToAction(nameof(Login));
                }
                _logger.LogWarning("Registration failed for {Email} (user might exist).", model.Email);
                ModelState.AddModelError(string.Empty, "Email already exists or registration failed.");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            _logger.LogInformation("Logout requested for {User}.", User.Identity?.Name);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = NegotiateDefaults.AuthenticationScheme)]
        public async Task<IActionResult> WindowsLogin()
        {
            if (User.Identity?.IsAuthenticated == true)
            { 
                var windowsIdentifier = User.Identity.Name;
                _logger.LogInformation("Windows Login for {WindowsUser}.", windowsIdentifier);
                var user = await _accountService.GetUserByWindowsIdentityAsync(windowsIdentifier);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.RoleID == (int)UserRole.Admin ? "Admin" : "User"),
                        new Claim("UserId", user.Id.ToString())
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    _logger.LogInformation("Windows user mapped to application user {Email}.", user.Email);
                }
                else
                {
                    _logger.LogWarning("Windows user {WindowsUser} not found in database.", windowsIdentifier);
                }

                return RedirectToAction("Index", "Home");
            }
            return Challenge(NegotiateDefaults.AuthenticationScheme);
        }
    }
}