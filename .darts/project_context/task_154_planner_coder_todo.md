# Planner-Coder Todo — 154
**Requirement:** Create a specialized grid on the admin dashboard that lists only completed applications (statusId 200). Ensure admin users can view the specific badges assigned to each application within this grid.

Acceptance Criteria:
- Verify that a distinct grid is added to the admin dashboard specifically for completed applications.
- Verify that only applications with 'Completed' status (statusId 200) are listed in this grid.
- Verify that the assigned badge details for each completed application are clearly visible in the grid.
- Ensure other admin dashboard grids and functionalities remain unaffected.

Dependencies: Task Badge Assignment Management for Approved Applications

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Model/Status.cs: ApplicationStatus enum
- CertEasy.Model/Application.cs: Application entity with properties UserID, CertificationID, StatusID, etc.
- CertEasy.Data/CertEasyDbContext.cs: Application DbSet, Status DbSet, etc.
- CertEasy.Services/IAdminService.cs: Registered in Program.cs
- CertEasy.Services/AdminService.cs: Implements IAdminService
- CertEasy.Web/Controllers/AdminController.cs: Authorize(Roles = "Admin"), Index action
- CertEasy.Web/Models/AdminViewModels.cs: AdminDashboardViewModel
- CertEasy.Web/Views/Admin/Index.cshtml: Admin Dashboard tabs & grids

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Model/Status.cs: add `Completed = 200` to ApplicationStatus enum
- CertEasy.Model/Application.cs: add `BadgeName` (string?), `BadgeAssignedDate` (DateTime?), `BadgeId` (string?) properties to Application model for badge assignment details
- CertEasy.Services/IAdminService.cs: add `Task<IEnumerable<Application>> GetCompletedApplicationsAsync();`
- CertEasy.Services/AdminService.cs: implement `GetCompletedApplicationsAsync()` returning completed applications (StatusID == 200) with includes (User, Certification, Status, Exam, Education)
- CertEasy.Web/Models/AdminViewModels.cs: add `CompletedApplications` property to `AdminDashboardViewModel`
- CertEasy.Web/Controllers/AdminController.cs: populate `CompletedApplications` in `Index()` action call using `GetCompletedApplicationsAsync()`
- CertEasy.Web/Views/Admin/Index.cshtml: add "Completed Applications" tab & distinct grid displaying completed applications and their assigned badge details (Badge Name, Badge ID, Assigned Date)

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Update Models, Admin Services, and ViewModels to support Completed Applications (StatusID 200) and assigned badge details | CertEasy.Model/Status.cs, CertEasy.Model/Application.cs, CertEasy.Services/IAdminService.cs, CertEasy.Services/AdminService.cs, CertEasy.Web/Models/AdminViewModels.cs | pending | — |
| T-002 | Update AdminController and Admin Dashboard View to add specialized completed applications grid displaying badge details | CertEasy.Web/Controllers/AdminController.cs, CertEasy.Web/Views/Admin/Index.cshtml | pending | T-001 |
