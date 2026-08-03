# Planner-Coder Todo — 46
**Requirement:** Implement a centralized logging system using Serilog. Log all errors, warnings, and critical business events (like status changes) into the database 'Logs' table.

Acceptance Criteria:
- Table 'Logs' created with fields: ID, LogLevel, Message, Exception, EntityType, EntityID, UserID, CreatedDate.
- Serilog configured to write to the Logs table.
- Critical actions (Submission, Approval, Rejection) are logged.

Dependencies: Task Project Structure Setup

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\CertEasyDbContext.cs: Roles, Statuses, Addresses, Certifications, EducationLevels, Users DbSets
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\Program.cs: Serilog (Console/File), DbContext, Auth, IAccountService, IAdminService, IPasswordService, IWorkflowService registered
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Services\WorkflowService.cs: GetUserWithWorkflowAsync, UpdateUserStatusAsync, SaveUserProfileAsync, SaveStepDataAsync

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\CertEasyDbContext.cs: add DbSet<Log> Logs
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\Program.cs: update Serilog config to include MSSqlServer sink
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Services\WorkflowService.cs: add logging for critical actions (Submission, Approval, Rejection)

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend — Log model and DbContext update | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\Log.cs, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\CertEasyDbContext.cs, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\CertEasy.Web.csproj, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Services\CertEasy.Services.csproj, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\CertEasy.Model.csproj | pending | — |
| T-002 | Entry points — Program.cs Serilog SQL Server configuration | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\Program.cs | pending | T-001 |
| T-003 | Business Logic — Log critical actions in WorkflowService | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Services\WorkflowService.cs, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Services\AdminService.cs | pending | T-002 |
