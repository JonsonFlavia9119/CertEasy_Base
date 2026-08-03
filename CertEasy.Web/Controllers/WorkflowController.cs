using CertEasy.Web.Models;
using CertEasy.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CertEasy.Model;

namespace CertEasy.Web.Controllers
{
    [Authorize]
    public class WorkflowController : Controller
    {
        private readonly IWorkflowService _workflowService;
        private readonly ILogger<WorkflowController> _logger;

        public WorkflowController(IWorkflowService workflowService, ILogger<WorkflowController> logger)
        {
            _workflowService = workflowService;
            _logger = logger;
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
            var eduLevels = await _workflowService.GetActiveEducationLevelsAsync();
            return Json(new { certifications = certs, educationLevels = eduLevels });
        }

        [HttpPost]
        public async Task<IActionResult> SaveStep([FromBody] dynamic stepData)
        {
            // Endpoint for wizard to save steps
            if (stepData == null) return BadRequest("Invalid data");
            _logger.LogInformation("Step saved");
            return Json(new { success = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                        EducationLevelID = model.EducationLevelID,
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
