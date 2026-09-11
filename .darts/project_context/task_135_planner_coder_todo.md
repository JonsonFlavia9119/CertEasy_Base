# Planner-Coder Todo — 135
**Requirement:** Implement the backend logic to update the application status. When an admin clicks Approve, the StatusID in the [REDACTED]'s table must be set to 112. When Reject is clicked, the StatusID must be set to 113. Ensure the [REDACTED_LOCATION] field is updated accordingly.

Acceptance Criteria:
- Clicking 'Approve' updates the StatusID to 112 in the [REDACTED]'s table for the specific application.
- Clicking 'Reject' updates the StatusID to 113 in the [REDACTED]'s table for the specific application.
- The [REDACTED_LOCATION] field is correctly updated based on the status change.

Dependencies: Task Admin Approval Actions in Application Grid

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_AdminActions_Phase1\CertEasy.Web\Program.cs: builder.Services.AddScoped<IAdminService, AdminService>();

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- No new registrations needed; updating existing service implementation.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend Implementation — Update AdminService for Approve/Reject logic | CertEasy.Services/AdminService.cs | pending | — |
| T-002 | Controller and UI Check — Ensure AdminController and Index view are correctly wired | CertEasy.Web/Controllers/AdminController.cs, CertEasy.Web/Views/Admin/Index.cshtml | pending | T-001 |
