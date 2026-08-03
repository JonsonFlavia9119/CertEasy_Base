using CertEasy.Services;
using CertEasy.Web.Models;
using CertEasy.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CertEasy.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IAdminService adminService, ILogger<AdminController> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var applications = await _adminService.GetApplicationsInReviewAsync();
            var viewModel = new AdminDashboardViewModel
            {
                PendingApplications = applications
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            var result = await _adminService.ApproveApplicationAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Application approved successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to approve application.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            var result = await _adminService.RejectApplicationAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Application rejected successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to reject application.";
            }
            return RedirectToAction(nameof(Index));
        }

        // Master Data Actions
        public async Task<IActionResult> ManageCertifications()
        {
            var certifications = await _adminService.GetCertificationsAsync();
            return View(certifications);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCertification(Certification model)
        {
            if (ModelState.IsValid)
            {
                await _adminService.AddCertificationAsync(model);
            }
            return RedirectToAction(nameof(ManageCertifications));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleCertification(int id)
        {
            await _adminService.ToggleCertificationStatusAsync(id);
            return RedirectToAction(nameof(ManageCertifications));
        }

        public async Task<IActionResult> ManageEducation()
        {
            var levels = await _adminService.GetEducationLevelsAsync();
            return View(levels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEducation(EducationLevel model)
        {
            if (ModelState.IsValid)
            {
                await _adminService.AddEducationLevelAsync(model);
            }
            return RedirectToAction(nameof(ManageEducation));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleEducation(int id)
        {
            await _adminService.ToggleEducationLevelStatusAsync(id);
            return RedirectToAction(nameof(ManageEducation));
        }
    }
}