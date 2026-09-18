using CertEasy.Web.Models;
using CertEasy.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using CertEasy.Model;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System;

namespace CertEasy.Web.Controllers
{
    [Authorize]
    public class WorkflowController : Controller
    {
        private readonly IWorkflowService _workflowService;
        private readonly IAdminService _adminService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<WorkflowController> _logger;

        public WorkflowController(
            IWorkflowService workflowService, 
            IAdminService adminService, 
            IWebHostEnvironment webHostEnvironment, 
            ILogger<WorkflowController> logger)
        {
            _workflowService = workflowService;
            _adminService = adminService;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            IEnumerable<CertEasy.Model.Application> applications;

            if (userRole == "Admin")
            {
                applications = await _workflowService.GetAllApplicationsAsync();
            }
            else
            {
                var userIdStr = User.FindFirst("UserId")?.Value;
                if (int.TryParse(userIdStr, out int userId))
                {
                    applications = await _workflowService.GetUserApplicationsAsync(userId);
                }
                else
                {
                    applications = new List<CertEasy.Model.Application>();
                }
            }

            return View(applications);
        }

        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetInitialData()
        {
            var certs = await _workflowService.GetActiveCertificationsAsync();
            var exams = await _workflowService.GetExamsAsync();
            var educations = await _workflowService.GetAllEducationsAsync();
            return Json(new { certifications = certs, exams = exams, educations = educations });
        }

        [HttpPost]
        public async Task<IActionResult> SaveStep([FromBody] dynamic stepData)
        {
            if (stepData == null) return BadRequest("Invalid data");
            _logger.LogInformation("Step saved");
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> SubmitApplication([FromForm] ApplicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userIdStr = User.FindFirst("UserId")?.Value;
                if (int.TryParse(userIdStr, out int userId))
                {
                    var application = new CertEasy.Model.Application
                    {
                        UserID = userId,
                        CertificationID = model.CertificationID,
                        ExamID = model.ExamID,
                        EducationLevelID = model.EducationLevelID.Value,
                        Remarks = model.Remarks,
                        StatusID = (int)ApplicationStatus.Review,
                        SubmittedDate = DateTime.UtcNow,
                        CreatedBy = userId.ToString(),
                        CreatedDate = DateTime.UtcNow,
                        UpdatedBy = userId.ToString(),
                        UpdatedDate = DateTime.UtcNow
                    };

                    string webRoot = _webHostEnvironment.WebRootPath ?? Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot");
                    string uploadsFolder = Path.Combine(webRoot, "FileUploads");

                    var success = await _workflowService.SubmitApplicationAsync(
                        application,
                        model.CertificationDocument,
                        model.EducationDocument,
                        uploadsFolder
                    );

                    if (success)
                    {
                        _logger.LogInformation("Application submitted successfully for user {UserId}", userId);
                        return Json(new { success = true, message = "Application submitted successfully!" });
                    }
                    _logger.LogWarning("Duplicate application attempt by user {UserId}", userId);
                    return Json(new { success = false, message = "You already have a pending application for this certification." });
                }
                return Unauthorized();
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Resubmit(int id)
        {
            var userIdStr = User.FindFirst("UserId")?.Value;
            int userId = 0;
            int.TryParse(userIdStr, out userId);

            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            int checkUserId = userRole == "Admin" ? 0 : userId;

            var result = await _workflowService.ResubmitApplicationAsync(id, checkUserId);
            if (result)
            {
                TempData["SuccessMessage"] = "Application resubmitted successfully for review.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to resubmit application or application is not in rejected status.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
