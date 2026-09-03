# Planner-Coder Todo — 127
**Requirement:** Implement a data grid to display submitted applications. This grid should be accessible to both normal users (filtered for their own data) and admins (viewing all data). Ensure the grid includes the exam details associated with each application.

Acceptance Criteria:
- Normal users can see a grid of their own submitted applications
- Admin users can see a grid of all submitted applications across the system
- The grid displays application details including the associated exam information

Dependencies: Task Application Flow Integration: Exam Selection Step

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Web/Controllers/WorkflowController.cs: Index method exists, calls _workflowService.GetAllApplicationsAsync() or GetUserApplicationsAsync(userId)
- CertEasy.Web/Views/Workflow/Index.cshtml: Displays a table of applications with basic columns

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Web/Views/Workflow/Index.cshtml: Enhance the grid to use a more production-ready style, ensure exam details (Name, Center, Slot) are clearly displayed, and use proper filtering based on user role as already implemented in controller.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Verify and Refine Data Grid | CertEasy.Web/Views/Workflow/Index.cshtml | pending | — |
