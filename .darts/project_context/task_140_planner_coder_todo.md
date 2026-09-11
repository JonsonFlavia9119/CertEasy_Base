# Planner-Coder Todo — 140
**Requirement:** Requirement;

As an internal user I would like to configure the email settings in admin area

Observations,
* Migration have been created in migration folder but table not created in SQL DB

Check,
* Migration is properly created and synced with SQL DB
* Verify pending migration changes and rewrite if anything pending
* Check the migration history
* Ensure migration correctly applied
* Ensure the email entity correctly mapped

Desired output,
* Email configuration should work without any issues
* Give me production ready code
* No migration related issue

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_AdminActions_Phase1\CertEasy.Data\CertEasyDbContext.cs: DbSet<EmailConfiguration> EmailConfigurations registered.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_AdminActions_Phase1\CertEasy.Web\Program.cs: dbContext.Database.Migrate() called on startup.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_AdminActions_Phase1\CertEasy.Web\Controllers\AdminController.cs: EmailConfiguration actions implemented.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_AdminActions_Phase1\CertEasy.Services\AdminService.cs: GetEmailConfigurationAsync and UpdateEmailConfigurationAsync implemented.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_AdminActions_Phase1\CertEasy.Data\Migrations\20260905000000_EnsureEmailConfigurationTable.cs: add new migration to explicitly create table with IF NOT EXISTS to guarantee DB sync.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Create explicit migration to ensure EmailConfigurations table exists | CertEasy.Data/Migrations/20260905000000_EnsureEmailConfigurationTable.cs, CertEasy.Data/Migrations/20260905000000_EnsureEmailConfigurationTable.Designer.cs | pending | — |
| T-002 | Verify and fix model mapping in DbContext | CertEasy.Data/CertEasyDbContext.cs | pending | T-001 |
