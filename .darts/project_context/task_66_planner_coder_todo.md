# Planner-Coder Todo — 66
**Requirement:** Develop the configuration interface for Address entries, allowing administrators to manage location data. Required fields: Line1, Line2, City, State, ZipCode, Country, CreatedDate, UpdatedDate, CreatedBy, UpdatedBy.

Acceptance Criteria:
- CRUD operations (Create, Read, Update, Delete) are functional for the Address entity.
- Form includes all fields: Line1, Line2, City, State, ZipCode, Country.
- Audit fields (Created/Updated) are populated automatically on save.

Technical Hints: Use a standard MVC Controller with Create and Edit views. Ensure server-side validation for mandatory fields.

Dependencies: Task admin_data_models_and_migrations, Task admin_layout_implementation

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Services\IAdminService.cs: IAdminService interface
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Services\AdminService.cs: AdminService implementation
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Web\Controllers\AdminController.cs: AdminController

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Services\IAdminService.cs: add GetAddressByIdAsync, UpdateAddressAsync, DeleteAddressAsync
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Services\AdminService.cs: implement GetAddressByIdAsync, UpdateAddressAsync, DeleteAddressAsync, and modify AddAddressAsync (if needed, though I'll add a new one for completeness)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Web\Controllers\AdminController.cs: add ManageAddresses, CreateAddress, EditAddress, DeleteAddress actions

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend — Service & Controller Updates | CertEasy.Services/IAdminService.cs, CertEasy.Services/AdminService.cs, CertEasy.Web/Controllers/AdminController.cs | pending | — |
| T-002 | Frontend UI — Address Management Views | CertEasy.Web/Views/Admin/ManageAddresses.cshtml, CertEasy.Web/Views/Admin/CreateAddress.cshtml, CertEasy.Web/Views/Admin/EditAddress.cshtml | pending | T-001 |
