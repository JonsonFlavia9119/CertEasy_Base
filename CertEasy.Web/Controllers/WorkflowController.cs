using CertEasy.Web.Models;
using CertEasy.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CertEasy.Model;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace CertEasy.Web.Controllers
{
    [Authorize]
    public class WorkflowController : Controller
    {
        private readonly IWorkflowService _workflowService;
        private readonly IAdminService _adminService;
        private readonly ILogger<WorkflowController> _logger;

        public WorkflowController(IWorkflowService workflowService, IAdminService adminService, ILogger<WorkflowController> logger)
        {
            _workflowService = workflowService;
            _adminService = adminService;
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
        public async Task<IActionResult> SubmitApplication([FromBody] ApplicationViewModel model)
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

                    var success = await _workflowService.SubmitApplicationAsync(application);
                    if (success)
                    {
                        return Json(new { success = true, message = "Application submitted successfully!" });
                    }
                    return Json(new { success = false, message = "You already have a pending application for this certification." });
                }
                return Unauthorized();
            }
            return BadRequest(ModelState);
        }
    }
}