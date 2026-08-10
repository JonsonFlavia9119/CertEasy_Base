# Planner-Coder Todo — 79
**Requirement:** Getting Invalid column name 'InstitutionName'. error from the code dbContext.Database.Migrate();
Fix this issue and make sure EducationLevels working good (Add, Edit, Delete)

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: DbSet<EducationLevel>, OnModelCreating seeds EducationLevel with InstitutionName.
- CertEasy.Model/EducationLevel.cs: Has InstitutionName property.
- CertEasy.Web/Controllers/AdminController.cs: AdminController uses IAdminService for EducationLevel CRUD.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Data/CertEasyDbContext.cs: Remove InstitutionName from EducationLevel seed data and modelBuilder configurations if any (though it's in the model, the DB doesn't have it yet, and we need to fix migration error).
- CertEasy.Model/EducationLevel.cs: Remove InstitutionName property to align with current DB schema if that's the source of truth, OR keep it and ensure migration adds it.
- **Decision:** The requirement says "Invalid column name 'InstitutionName'". This usually happens when EF tries to query/insert a column that doesn't exist in the DB. Given the context of "Fix this issue", I will remove the property from `EducationLevel` model and seed data because `InstitutionName` belongs in the `Education` (the actual entry), not the `EducationLevel` (the category like "Bachelor's Degree").

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Fix EducationLevel model and seed data | CertEasy.Model/EducationLevel.cs, CertEasy.Data/CertEasyDbContext.cs | pending | — |
| T-002 | Update AdminController and View to ensure EducationLevel CRUD works | CertEasy.Web/Controllers/AdminController.cs, CertEasy.Web/Views/Admin/ManageEducation.cshtml | pending | T-001 |
