# Planner-Coder Todo — 99
**Requirement:** Add a migration to rename 'EducationLevels' table to 'Educations' and ensure AdminService is correctly implemented.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: DbSet<Education> Educations registered, ToTable("Educations") configured.
- CertEasy.Services/AdminService.cs: GetAllEducationAsync implemented.
- CertEasy.Model/Education.cs: [Table("Educations")] attribute applied.
- CertEasy.Data/Migrations/20260820070811_RenameEducationLevelsToEducations.cs: Migration already exists.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- None (All items already implemented in the codebase)

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Verify and confirm implementation of Table Rename and AdminService | CertEasy.Data/CertEasyDbContext.cs, CertEasy.Services/AdminService.cs, CertEasy.Data/Migrations/20260820070811_RenameEducationLevelsToEducations.cs | pending | — |
