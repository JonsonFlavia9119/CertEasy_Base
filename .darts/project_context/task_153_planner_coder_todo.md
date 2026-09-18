# Planner-Coder Todo — 153
**Requirement:** Develop a dedicated UI page and backend logic for admins to assign badges to approved applications. The page displays application details alongside badge options, and assigning a badge transitions the application status to 'Completed' (statusId 200).

Acceptance Criteria:
- Verify that the badge assignment link is available only for approved applications.
- Verify that clicking the link opens a dedicated page showing application details and badge selection options.
- Verify that selecting and assigning a badge transitions the application status to completed (statusId 200).

Dependencies: Task Implement Resubmission for Rejected Applications

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Model/Status.cs: ApplicationStatus enum
- CertEasy.Data/CertEasyDbContext.cs: Statuses DbSet seed data
- CertEasy.Services/IAdminService.cs: IAdminService interface
- CertEasy.Services/AdminService.cs: AdminService implementation
- CertEasy.Web/Controllers/AdminController.cs: AdminController actions
- CertEasy.Web/Models/AdminViewModels.cs: Admin view models
- CertEasy.Web/Views/Admin/Index.cshtml: Admin dashboard view

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Model/Status.cs: Add Completed = 200 to ApplicationStatus enum
- CertEasy.Data/CertEasyDbContext.cs: Add Status record with Id 200 ("Completed")
- CertEasy.Services/IAdminService.cs: Add GetApplicationByIdAsync, AssignBadgeAsync
- CertEasy.Services/AdminService.cs: Implement GetApplicationByIdAsync, AssignBadgeAsync
- CertEasy.Web/Models/AdminViewModels.cs: Add AssignBadgeViewModel
- CertEasy.Web/Controllers/AdminController.cs: Add AssignBadge (HttpGet) and AssignBadge (HttpPost) actions
- CertEasy.Web/Views/Admin/AssignBadge.cshtml: Create AssignBadge view
- CertEasy.Web/Views/Admin/Index.cshtml: Add Assign Badge link for approved applications (StatusID == 7 or 112)

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend models, DbContext, and AdminService methods for Assign Badge | CertEasy.Model/Status.cs, CertEasy.Data/CertEasyDbContext.cs, CertEasy.Services/IAdminService.cs, CertEasy.Services/AdminService.cs, CertEasy.Web/Models/AdminViewModels.cs | pending | — |
| T-002 | AdminController Assign Badge endpoints and Views | CertEasy.Web/Controllers/AdminController.cs, CertEasy.Web/Views/Admin/AssignBadge.cshtml, CertEasy.Web/Views/Admin/Index.cshtml | pending | T-001 |
