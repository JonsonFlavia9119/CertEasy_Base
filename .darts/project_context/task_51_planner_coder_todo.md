# Planner-Coder Todo — 51
**Requirement:** Observations:

1. CertEasy.Data Project have been added but Migration folder is not there, please add it
2. CertEasyDb haven't been created, it is mandatory
3. Login, Register links are not working. In order to use this solution, we need to login
5. Make sure the application process is added

Make sure the login and register likes are working

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Web/Program.cs: Serilog, DbContext (CertEasyDbContext), Cookie Auth, Service injections (IAccountService, IWorkflowService, etc.), EnsureCreated()
- CertEasy.Web/Views/Shared/_Layout.cshtml: Navbar with Login/Register links and Apply link
- CertEasy.Web/Controllers/AccountController.cs: Login (GET/POST), Register (GET/POST) actions
- CertEasy.Web/Controllers/WorkflowController.cs: Apply (GET), SubmitApplication (POST) actions

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Data/Migrations: Add initial migration files to support EF Core Migrations
- CertEasy.Web/Program.cs: Replace `dbContext.Database.EnsureCreated()` with `dbContext.Database.Migrate()` to use migrations

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend - Migrations & DB Setup | CertEasy.Data/Migrations/20240101000000_InitialCreate.cs, CertEasy.Data/Migrations/20240101000000_InitialCreate.Designer.cs, CertEasy.Data/Migrations/CertEasyDbContextModelSnapshot.cs, CertEasy.Web/Program.cs | pending | — |
| T-002 | Frontend - Verify Login/Register & Application Process | CertEasy.Web/Views/Account/Login.cshtml, CertEasy.Web/Views/Account/Register.cshtml, CertEasy.Web/Views/Workflow/Apply.cshtml, CertEasy.Web/wwwroot/js/workflow-wizard.js | pending | T-001 |
