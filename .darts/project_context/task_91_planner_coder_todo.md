# Planner-Coder Todo — 91
**Requirement:** I would like to remove the educationlevel page from the admin dashboard. I will add it in the future
Please make the changes in the code and database as well

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: Roles, Statuses, Addresses, Certifications, EducationLevels, Educations, Users, Logs, Applications
- CertEasy.Services/IAdminService.cs: GetApplicationsInReviewAsync, ApproveApplicationAsync, RejectApplicationAsync, GetCertificationsAsync, GetCertificationByIdAsync, AddCertificationAsync, UpdateCertificationAsync, DeleteCertificationAsync, ToggleCertificationStatusAsync, GetEducationLevelsAsync, GetEducationLevelByIdAsync, AddEducationLevelAsync, UpdateEducationLevelAsync, DeleteEducationLevelAsync, ToggleEducationLevelStatusAsync, GetAllAddressesAsync, GetAddressByIdAsync, AddAddressAsync, UpdateAddressAsync, DeleteAddressAsync, GetAllEducationsAsync, GetEducationByIdAsync, AddEducationAsync, UpdateEducationAsync, DeleteEducationAsync
- CertEasy.Web/Controllers/AdminController.cs: Index, Approve, Reject, ManageCertifications, CreateCertification, EditCertification, DeleteCertification, ToggleCertification, ManageEducation, AddEducationLevel, EditEducationLevel, DeleteEducationLevel, ToggleEducation, ManageAddresses, CreateAddress, EditAddress, DeleteAddress

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Data/CertEasyDbContext.cs: remove DbSet<EducationLevel>, remove modelBuilder.Entity<EducationLevel>().HasData(...)
- CertEasy.Services/IAdminService.cs: remove EducationLevel related methods
- CertEasy.Services/AdminService.cs: remove EducationLevel related method implementations
- CertEasy.Web/Controllers/AdminController.cs: remove EducationLevel related actions
- CertEasy.Web/Views/Shared/_AdminLayout.cshtml: remove Education Levels nav link

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend Cleanup — Remove EducationLevel from DbContext, Services and Controller | CertEasy.Data/CertEasyDbContext.cs, CertEasy.Services/IAdminService.cs, CertEasy.Services/AdminService.cs, CertEasy.Web/Controllers/AdminController.cs | pending | — |
| T-002 | UI Cleanup — Remove EducationLevel link from Layout | CertEasy.Web/Views/Shared/_AdminLayout.cshtml | pending | T-001 |
| T-003 | Database Cleanup — Remove EducationLevel model file and view | CertEasy.Model/EducationLevel.cs, CertEasy.Web/Views/Admin/ManageEducation.cshtml | pending | T-002 |
