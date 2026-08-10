# Planner-Coder Todo — 76
**Requirement:**  Administrative Error
An unexpected error occurred in the administrative area. Invalid column name 'InstituteName'.

Fix this issue and add migration if needed.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Data\CertEasyDbContext.cs: Roles, Statuses, Addresses, Certifications, EducationLevels, Educations, Users, Logs, Applications DbSets; OnModelCreating with seeding.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Web\Program.cs: Serilog, DbContext, Auth, Services, Migrations on startup.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Model\EducationLevel.cs: update `InstituteName` to `InstitutionName` for consistency or keep as is but ensure migration exists. (Decision: Standardize to `InstitutionName` to match `Education` model).
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Data\CertEasyDbContext.cs: Update seed data to use `InstitutionName`.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Data\Migrations\20240104000000_FixInstitutionName.cs: Create migration to rename column `InstituteName` to `InstitutionName` or add it if missing.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend — Update Models and DbContext seeding | CertEasy.Model/EducationLevel.cs, CertEasy.Data/CertEasyDbContext.cs | pending | — |
| T-002 | Database — Migration to fix column name | CertEasy.Data/Migrations/20240104000000_FixInstitutionName.cs, CertEasy.Data/Migrations/20240104000000_FixInstitutionName.Designer.cs, CertEasy.Data/Migrations/CertEasyDbContextModelSnapshot.cs | pending | T-001 |
