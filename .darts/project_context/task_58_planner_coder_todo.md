# Planner-Coder Todo — 58
**Requirement:** Database created successfully, there is only two tables has been created (____EFMigrationsHistory, Logs). Rest of the tables not created. Please create all tables and make sure the login/register functionality working fine.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: DbSet<Role>, DbSet<Status>, DbSet<Address>, DbSet<Certification>, DbSet<EducationLevel>, DbSet<User>, DbSet<Log>, DbSet<Application> registered.
- CertEasy.Web/Program.cs: dbContext.Database.Migrate() called in a scope during startup.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Web/Program.cs: Ensure the migration logic is robust and logs success/failure clearly.
- CertEasy.Data/Migrations: Will be updated via a fresh migration to ensure all tables are included in the schema.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Database Schema & Migrations — Regenerate migration to ensure all tables are included. | CertEasy.Data/Migrations/*.cs | pending | — |
| T-002 | Entry Point Update — Ensure Program.cs robustly applies migrations and initialize seed data. | CertEasy.Web/Program.cs | pending | T-001 |
| T-003 | Backend — Validate AccountService logic for Register/Login to ensure compatibility with schema. | CertEasy.Services/AccountService.cs | pending | T-002 |
