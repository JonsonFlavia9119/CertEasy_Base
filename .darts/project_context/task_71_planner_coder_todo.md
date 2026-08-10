# Planner-Coder Todo — 71
**Requirement:** After successful login, I don't see any admin configuration links available. Please create a separate admin section.
The user should be able to configure the address, education and certification. These 3 pages should have CRUD operation so the user can modify or delete the entries from the admin level.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Web/Views/Shared/_Layout.cshtml: Navbar links for Admin already registered.
- CertEasy.Web/Program.cs: IAdminService registered.
- CertEasy.Web/Controllers/AdminController.cs: All CRUD actions (Manage, Create, Edit, Delete) for Address, Education, and Certification already registered.
- CertEasy.Services/AdminService.cs: All CRUD logic already implemented.
- CertEasy.Data/CertEasyDbContext.cs: All DbSets and seeding already present.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- None (All wiring and features already present and correctly linked).

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Verify and Finalize Admin CRUD Implementation | CertEasy.Web/Controllers/AdminController.cs, CertEasy.Services/AdminService.cs, CertEasy.Web/Views/Shared/_Layout.cshtml, CertEasy.Web/Views/Admin/ManageCertifications.cshtml, CertEasy.Web/Views/Admin/ManageEducation.cshtml, CertEasy.Web/Views/Admin/ManageAddresses.cshtml | pending | — |
