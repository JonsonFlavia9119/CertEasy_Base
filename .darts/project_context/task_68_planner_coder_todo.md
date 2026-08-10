# Planner-Coder Todo — 68
**Requirement:** Develop the configuration interface for Certification entries. Required fields: Name, Description, CreatedDate, UpdatedDate, CreatedBy, UpdatedBy.

Acceptance Criteria:
- CRUD operations are functional for the Certification entity.
- Form includes: Name, Description.
- Entries are persisted with full audit trail metadata.

Technical Hints: Implement standard CRUD views using the Admin layout.

Dependencies: Task admin_data_models_and_migrations, Task admin_layout_implementation

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Web\Program.cs: builder.Services.AddScoped<IAdminService, AdminService>();

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Web\Controllers\AdminController.cs: Add CreateCertification, EditCertification, DeleteCertification GET/POST actions.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend — IAdminService and AdminService updates | CertEasy.Service/IAdminService.cs, CertEasy.Service/AdminService.cs | pending | — |
| T-002 | Controller and UI — AdminController updates and Views | CertEasy.Web/Controllers/AdminController.cs, CertEasy.Web/Views/Admin/ManageCertifications.cshtml, CertEasy.Web/Views/Admin/CreateCertification.cshtml, CertEasy.Web/Views/Admin/EditCertification.cshtml | pending | T-001 |
