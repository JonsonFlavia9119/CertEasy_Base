# Planner-Coder Todo — 77
**Requirement:** ALTER TABLE ALTER COLUMN failed because column 'InstituteName' does not exist in table 'EducationLevels'

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: DbSet<EducationLevel>, HasData(EducationLevel)

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Model/EducationLevel.cs: rename InstitutionName to InstituteName
- CertEasy.Data/CertEasyDbContext.cs: update seed data to use InstituteName

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Fix EducationLevel property name and update seed data | CertEasy.Model/EducationLevel.cs, CertEasy.Data/CertEasyDbContext.cs | pending | — |
