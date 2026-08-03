# Planner-Coder Todo — 62
**Requirement:** Registration is not working

Register button is throwing the below error

SqlException: The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Users_Statuses_StatusID". The conflict occurred in database "CertEasyDb", table "dbo.Statuses", column 'Id'. The statement has been terminated.

Analyze the root cause and fix it.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Data\CertEasyDbContext.cs: DbSet<User>, DbSet<Status>, OnModelCreating seeds Statuses
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Services\AccountService.cs: RegisterAsync, GetUserByWindowsIdentityAsync

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\Status.cs: change ApplicationStatus enum and Status seeding to include ID 0 if necessary, OR ensure New=1 is correctly handled.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Services\AccountService.cs: Fix StatusID assignment in RegisterAsync and GetUserByWindowsIdentityAsync to use (int)ApplicationStatus.New.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Fix Registration StatusID FK Conflict | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Services\AccountService.cs, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\User.cs | pending | — |
