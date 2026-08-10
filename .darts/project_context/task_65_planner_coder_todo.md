# Planner-Coder Todo — 65
**Requirement:** Implement the Admin Dashboard page using the [REDACTED_LOCATION] control to display all administrative entries. This page acts as the central hub for viewing system configurations.

Acceptance Criteria:
- The dashboard page correctly implements the [REDACTED_LOCATION] control.
- All entries from Addresses, Education, and Certification tables are visible in the control.
- The dashboard is accessible via the Admin Support link.

Technical Hints: Bind the [REDACTED_LOCATION] control to a view model containing lists of all three entities.

Dependencies: Task admin_layout_implementation, Task admin_data_models_and_migrations

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Web/Program.cs: builder.Services.AddScoped<IAdminService, AdminService>(); already registered.
- CertEasy.Web/Controllers/AdminController.cs: Index action existing, needs update.
- CertEasy.Web/Models/AdminViewModels.cs: AdminDashboardViewModel existing, needs update.
- CertEasy.Services/IAdminService.cs: Interface existing, needs new methods for Address, Education (records), and Certification.
- CertEasy.Services/AdminService.cs: Implementation existing, needs new methods.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Web/Models/AdminViewModels.cs: update AdminDashboardViewModel with Addresses, Educations, and Certifications lists.
- CertEasy.Services/IAdminService.cs: add GetAllAddressesAsync, GetAllEducationsAsync, GetAllCertificationsAsync.
- CertEasy.Services/AdminService.cs: implement the new service methods.
- CertEasy.Web/Controllers/AdminController.cs: update Index action to populate the new VM fields.
- CertEasy.Web/Views/Admin/Index.cshtml: implement the Dashboard UI with KnockoutJS (since the project uses it) to act as the [REDACTED_LOCATION] (central hub) for administrative entries.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend — Models + Services + Controllers | CertEasy.Web/Models/AdminViewModels.cs, CertEasy.Services/IAdminService.cs, CertEasy.Services/AdminService.cs, CertEasy.Web/Controllers/AdminController.cs | pending | — |
| T-002 | Frontend UI — Dashboard View | CertEasy.Web/Views/Admin/Index.cshtml | pending | T-001 |
