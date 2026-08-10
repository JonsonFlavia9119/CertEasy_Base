# Planner-Coder Todo — 78
**Requirement:** Still facing the migration related error. Find the root cause and fix it. Do not complete this task if this issue haven't been fixed

Error details
"ALTER TABLE ALTER COLUMN failed because column 'InstituteName' does not exist in table 'EducationLevels'."

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Data\CertEasyDbContext.cs: DbContext with EducationLevels DbSet and seeding.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Model\EducationLevel.cs: Entity model with InstituteName property.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Data\Migrations\20240103000000_FixEducationLevelColumnName.cs: Replace migration logic to ensure column exists before altering.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Data\Migrations\20240104000000_FixInstitutionName.cs: Clean up or unify naming to prevent confusion.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Data\Migrations\20240105000000_FixEducationLevelStructure.cs: Final safety check for column existence.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend — Fix Migration scripts and sync model naming | CertEasy.Data/Migrations/20240103000000_FixEducationLevelColumnName.cs, CertEasy.Data/Migrations/20240104000000_FixInstitutionName.cs, CertEasy.Data/Migrations/20240105000000_FixEducationLevelStructure.cs, CertEasy.Model/EducationLevel.cs, CertEasy.Data/CertEasyDbContext.cs | pending | — |
