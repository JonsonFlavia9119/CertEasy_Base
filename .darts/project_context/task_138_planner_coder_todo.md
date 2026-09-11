# Planner-Coder Todo — 138
**Requirement:** I noticed something has changed in the application process, before there is an review page along with Submit button, not the review page is not showing, instead the "SubmitAppliction" button is showing in the education page.

Getting this below error during application submission. 

"Cannot insert the value NULL into column 'EducationLevelID', table 'CertEasyDb.dbo.Applications'; column does not allow nulls. INSERT fails.The statement has been terminated."

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Services/IWorkflowService.cs: already contains GetActiveCertificationsAsync, SubmitApplicationAsync, etc.
- CertEasy.Services/WorkflowService.cs: implements IWorkflowService.
- CertEasy.Web/Controllers/WorkflowController.cs: handles workflow actions.
- CertEasy.Web/Models/ApplicationViewModel.cs: DTO for application submission.
- CertEasy.Web/wwwroot/js/workflow-wizard.js: Knockout.js logic for the wizard.
- CertEasy.Web/Views/Workflow/Apply.cshtml: Wizard UI.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Services/IWorkflowService.cs: add Task<IEnumerable<Education>> GetAllEducationsAsync()
- CertEasy.Services/WorkflowService.cs: implement GetAllEducationsAsync using _context.Educations
- CertEasy.Web/Controllers/WorkflowController.cs: update GetInitialData to include educations; update SubmitApplication to use [Required] validation correctly and map EducationLevelID without defaulting to 0 if null (fix NULL error by ensuring it's provided).
- CertEasy.Web/Models/ApplicationViewModel.cs: make EducationLevelID [Required].
- CertEasy.Web/wwwroot/js/workflow-wizard.js: ensure educationLevels are loaded from server; ensure step 5 (Review) is reached before submission.
- CertEasy.Web/Views/Workflow/Apply.cshtml: verify step 5 visibility and data binding.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend — Fix Service and ViewModel | CertEasy.Services/IWorkflowService.cs, CertEasy.Services/WorkflowService.cs, CertEasy.Web/Models/ApplicationViewModel.cs, CertEasy.Web/Controllers/WorkflowController.cs | pending | — |
| T-002 | Frontend — Fix Wizard Logic and UI | CertEasy.Web/wwwroot/js/workflow-wizard.js, CertEasy.Web/Views/Workflow/Apply.cshtml | pending | T-001 |
