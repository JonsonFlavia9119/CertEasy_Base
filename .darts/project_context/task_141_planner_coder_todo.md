# Planner-Coder Todo — 141
**Requirement:** Requirement;

As a admin user, I would like to configure Email service provider in admin area

input;

* Create a new page for email service provider configuration in Admin area
*  Fields should be
 -> Email provider name
 -> Sender Email
 -> Sender Name 
 -> API Key
 -> Test Email button

check;

* Add migration if needed
* Ensure its sync with appropriate entity and SQL DB
* Avoid migration error

Desired output
* Clean and production ready code
* Follow existing code flow

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_AdminActions_Phase1\CertEasy.Data\CertEasyDbContext.cs: DbSet<EmailConfiguration> EmailConfigurations already registered.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_AdminActions_Phase1\CertEasy.Web\Program.cs: Services registered, migrations applied on startup.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_AdminActions_Phase1\CertEasy.Web\Controllers\AdminController.cs: EmailConfiguration actions already exist.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- None (Functionality is already implemented).

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Verify and validate existing implementation | CertEasy.Model/EmailConfiguration.cs, CertEasy.Data/CertEasyDbContext.cs, CertEasy.Services/IAdminService.cs, CertEasy.Services/AdminService.cs, CertEasy.Web/Controllers/AdminController.cs, CertEasy.Web/Models/AdminViewModels.cs, CertEasy.Web/Views/Admin/EmailConfiguration.cshtml | already_implemented | — |
