# Planner-Coder Todo — 67
**Requirement:** Develop the configuration interface for Education entries. Required fields: Name, Description, CreatedDate, UpdatedDate, CreatedBy, UpdatedBy.

Acceptance Criteria:
- CRUD operations are functional for the Education entity.
- Form includes: Name, Description.
- Audit fields are correctly handled during data persistence.

Technical Hints: Implement standard CRUD views using the Admin layout.

Dependencies: Task admin_data_models_and_migrations, Task admin_layout_implementation

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Data\CertEasyDbContext.cs: DbSet<Education> Educations registered.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Services\IAdminService.cs: GetAllEducationsAsync registered.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Services\AdminService.cs: GetAllEducationsAsync implemented.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Web\Controllers\AdminController.cs: Admin dashboard uses Educations.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Services\IAdminService.cs: add GetEducationByIdAsync, AddEducationAsync, UpdateEducationAsync, DeleteEducationAsync.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Services\AdminService.cs: implement GetEducationByIdAsync, AddEducationAsync, UpdateEducationAsync, DeleteEducationAsync.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Web\Controllers\AdminController.cs: add ManageEducationEntries, CreateEducation, EditEducation, DeleteEducation.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Web\Views\Shared\_AdminLayout.cshtml: add link to /Admin/ManageEducationEntries.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend — Services update | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Services\IAdminService.cs, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Services\AdminService.cs | pending | — |
| T-002 | Controller — AdminController update | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Web\Controllers\AdminController.cs | pending | T-001 |
| T-003 | Frontend UI — Views and Layout | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Web\Views\Admin\ManageEducationEntries.cshtml, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Web\Views\Admin\CreateEducation.cshtml, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Web\Views\Admin\EditEducation.cshtml, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Web\Views\Shared\_AdminLayout.cshtml | pending | T-002 |
