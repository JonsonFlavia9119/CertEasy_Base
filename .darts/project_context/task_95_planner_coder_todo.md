# Planner-Coder Todo — 95
**Requirement:** An unexpected error occurred in the administrative area. Invalid object name 'Educations'.

Getting this error in the Education Quals page in admin area. 

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase2\CertEasy.Data\CertEasyDbContext.cs: Roles, Statuses, Addresses, Certifications, Users, Logs, Applications, Educations
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase2\CertEasy.Model\Education.cs: Name, Description, IsActive, CreatedDate, UpdatedDate, CreatedBy, UpdatedBy, InstituteName

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase2\CertEasy.Data\CertEasyDbContext.cs: add `modelBuilder.Entity<Education>().ToTable("Educations");` or ensure EF uses plural name explicitly to match DB.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Fix Education table mapping in DbContext | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase2\CertEasy.Data\CertEasyDbContext.cs | pending | — |
