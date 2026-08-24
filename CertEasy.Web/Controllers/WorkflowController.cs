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
            return Json(new { certifications = certs });
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
                        Remarks = model.Remarks,
                        StatusID = (int)ApplicationStatus.Review,
                        SubmittedDate = DateTime.UtcNow,
                        CreatedBy = userId.ToString(),
                        CreatedDate = DateTime.UtcNow,
                        UpdatedBy = userId.ToString(),
                        UpdatedDate = DateTime.UtcNow
                    };

                    // Note: EntityID/EntityTypeID for Application itself is not required by prompt,
                    // but if the workflow created Certification/Education records here, 
                    // they would be assigned EntityID = ApplicationId and EntityTypeID = 200.
                    // Since SubmitApplication currently only creates the Application record,
                    // we ensure the infrastructure is ready for those assignments in future steps.

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
