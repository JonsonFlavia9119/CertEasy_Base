# Planner-Coder Todo — 50
**Requirement:** Observations:
1. CertEasy.Data Project haven't been added into the solution 
2. CertEasyDb haven't been created 
3. Application launched -> none of the links not working 
4. Login, Register links are not working 
5. Make sure the application process is added

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\Program.cs: Services registered, Auth configured, Middleware pipeline.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\Views\Shared\_Layout.cshtml: Navigation links for Login, Register, Workflow.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\Program.cs: Ensure EnsureCreated() is called (already present).
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\Views\Account\Login.cshtml: Add form for login.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\Views\Account\Register.cshtml: Add form for registration.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\Views\Workflow\Apply.cshtml: Implementation of wizard.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Infrastructure and Data Layer | CertEasy.Data/CertEasy.Data.csproj, CertEasy.Model/CertEasyDbContext.cs, CertEasy.Web/appsettings.json | pending | — |
| T-002 | Authentication and Account UI | CertEasy.Web/Views/Account/Login.cshtml, CertEasy.Web/Views/Account/Register.cshtml, CertEasy.Web/Controllers/AccountController.cs | pending | T-001 |
| T-003 | Application Process (Workflow) UI | CertEasy.Web/Views/Workflow/Apply.cshtml, CertEasy.Web/wwwroot/js/workflow-wizard.js, CertEasy.Web/Controllers/WorkflowController.cs | pending | T-002 |
