using CertEasy.Services;
using CertEasy.Web.Models;
using CertEasy.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;

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
            var addresses = await _adminService.GetAllAddressesAsync();
            var certifications = await _adminService.GetCertificationsAsync();
            var educations = await _adminService.GetAllEducationAsync();

            var viewModel = new AdminDashboardViewModel
            { 
                PendingApplications = applications, 
                Addresses = addresses, 
                Certifications = certifications,
                Educations = educations
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            var result = await _adminService.ApproveApplicationAsync(id, User.Identity.Name ?? "Unknown");
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
            var result = await _adminService.RejectApplicationAsync(id, User.Identity.Name ?? "Unknown");
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

        public IActionResult CreateCertification()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCertification(Certification model)
        {
            if (ModelState.IsValid)
            {
                var result = await _adminService.AddCertificationAsync(model, User.Identity.Name ?? "Unknown");
                if (result)
                {
                    TempData["SuccessMessage"] = "Certification created successfully.";
                    return RedirectToAction(nameof(ManageCertifications));
                }
                ModelState.AddModelError("", "Failed to create certification.");
            }
            return View(model);
        }

        public async Task<IActionResult> EditCertification(int id)
        {
            var certification = await _adminService.GetCertificationByIdAsync(id);
            if (certification == null) return NotFound();
            return View(certification);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCertification(Certification model)
        {
            if (ModelState.IsValid)
            {
                var result = await _adminService.UpdateCertificationAsync(model, User.Identity.Name ?? "Unknown");
                if (result)
                {
                    TempData["SuccessMessage"] = "Certification updated successfully.";
                    return RedirectToAction(nameof(ManageCertifications));
                }
                ModelState.AddModelError("", "Failed to update certification.");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCertification(int id)
        {
            var result = await _adminService.DeleteCertificationAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Certification deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete certification.";
            }
            return RedirectToAction(nameof(ManageCertifications));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleCertification(int id)
        {
            await _adminService.ToggleCertificationStatusAsync(id, User.Identity.Name ?? "Unknown");
            return RedirectToAction(nameof(ManageCertifications));
        }

        // Address Management
        public async Task<IActionResult> ManageAddresses()
        {
            var addresses = await _adminService.GetAllAddressesAsync();
            return View(addresses);
        }

        public IActionResult CreateAddress()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAddress(Address model)
        {
            if (ModelState.IsValid)
            {
                var result = await _adminService.AddAddressAsync(model, User.Identity.Name ?? "Unknown");
                if (result)
                {
                    TempData["SuccessMessage"] = "Address created successfully.";
                    return RedirectToAction(nameof(ManageAddresses));
                }
                ModelState.AddModelError("", "Failed to create address.");
            }
            return View(model);
        }

        public async Task<IActionResult> EditAddress(int id)
        {
            var address = await _adminService.GetAddressByIdAsync(id);
            if (address == null) return NotFound();
            return View(address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAddress(Address model)
        {
            if (ModelState.IsValid)
            {
                var result = await _adminService.UpdateAddressAsync(model, User.Identity.Name ?? "Unknown");
                if (result)
                {
                    TempData["SuccessMessage"] = "Address updated successfully.";
                    return RedirectToAction(nameof(ManageAddresses));
                }
                ModelState.AddModelError("", "Failed to update address.");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var result = await _adminService.DeleteAddressAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Address deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete address.";
            }
            return RedirectToAction(nameof(ManageAddresses));
        }

        // Education Qualification Management
        public async Task<IActionResult> ManageEducation()
        {
            var education = await _adminService.GetAllEducationAsync();
            return View(education);
        }

        public IActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEducation(Education model)
        {
            if (ModelState.IsValid)
            {
                var result = await _adminService.AddEducationAsync(model, User.Identity.Name ?? "Unknown");
                if (result)
                {
                    TempData["SuccessMessage"] = "Education qualification created successfully.";
                    return RedirectToAction(nameof(ManageEducation));
                }
                ModelState.AddModelError("", "Failed to create education qualification.");
            }
            return View(model);
        }

        public async Task<IActionResult> EditEducation(int id)
        {
            var education = await _adminService.GetEducationByIdAsync(id);
            if (education == null) return NotFound();
            return View(education);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEducation(Education model)
        {
            if (ModelState.IsValid)
            {
                var result = await _adminService.UpdateEducationAsync(model, User.Identity.Name ?? "Unknown");
                if (result)
                {
                    TempData["SuccessMessage"] = "Education qualification updated successfully.";
                    return RedirectToAction(nameof(ManageEducation));
                }
                ModelState.AddModelError("", "Failed to update education qualification.");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            var result = await _adminService.DeleteEducationAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Education qualification deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete education qualification.";
            }
            return RedirectToAction(nameof(ManageEducation));
        }
    }
}