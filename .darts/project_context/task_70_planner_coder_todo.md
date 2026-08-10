# Planner-Coder Todo — 70
**Requirement:** There are 9 errors occurring during build, please fix the compile issues and make sure the admin configuration functionalities are working fine. 

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Web/Program.cs: registers CertEasyDbContext, IAccountService, IAdminService, IPasswordService, IWorkflowService, AdminExceptionFilter, Authentication, Authorization.
- CertEasy.Data/CertEasyDbContext.cs: defines DbSets for Role, Status, Address, Certification, EducationLevel, Education, User, Log, Application.
- CertEasy.Web/Controllers/AdminController.cs: uses IAdminService for dashboard and master data management.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Services/AccountService.cs: ensure using CertEasy.Data and CertEasy.Model.
- CertEasy.Services/AdminService.cs: ensure correct namespace and references.
- CertEasy.Services/WorkflowService.cs: ensure correct namespace and references.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Fix Compile Errors - Projects & References | CertEasy.Web/CertEasy.Web.csproj, CertEasy.Services/CertEasy.Services.csproj, CertEasy.Data/CertEasy.Data.csproj, CertEasy.Model/CertEasy.Model.csproj | pending | — |
| T-002 | Fix Compile Errors - Code Cleanup | CertEasy.Service/AdminService.cs, CertEasy.Service/IAdminService.cs, CertEasy.Web/Controllers/AdminController.cs, CertEasy.Web/Program.cs | pending | T-001 |
| T-003 | Fix Compile Errors - Logic & Infrastructure | CertEasy.Services/AdminService.cs, CertEasy.Services/AccountService.cs, CertEasy.Services/PasswordService.cs, CertEasy.Services/WorkflowService.cs | pending | T-002 |
| T-004 | Admin Configuration Functionality Check | CertEasy.Web/Models/AdminViewModels.cs, CertEasy.Web/Controllers/AdminController.cs | pending | T-003 |
