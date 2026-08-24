# Planner-Coder Todo — 100
**Requirement:** Add nullable int fields EntityID and EntityTypeID to the existing Certification and Education entity/table.

Use the project's existing EF Core patterns and migration approach.

Requirements:
- Update the entity/model.
- Add an EF Core migration for the existing Certification table.
- Update DTOs/view models only where required by the existing architecture.
- Build and validate the solution.
- Report the files changed and migration name.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase2\CertEasy.Data\CertEasyDbContext.cs: DbSet<Certification>, DbSet<Education>, HasData for Certification
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase2\CertEasy.Web\Program.cs: DbContext registration, Database migration application

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase2\CertEasy.Model\Certification.cs: add public int? EntityID { get; set; }; public int? EntityTypeID { get; set; };
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase2\CertEasy.Model\Education.cs: add public int? EntityID { get; set; }; public int? EntityTypeID { get; set; };
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase2\CertEasy.Data\CertEasyDbContext.cs: update Certification seed data to include nulls for new fields (optional, but good for completeness)

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend — Update Models and Migration | CertEasy.Model/Certification.cs, CertEasy.Model/Education.cs, CertEasy.Data/Migrations/20240822000000_AddEntityFieldsToCertificationAndEducation.cs, CertEasy.Data/Migrations/20240822000000_AddEntityFieldsToCertificationAndEducation.Designer.cs, CertEasy.Data/CertEasyDbContextModelSnapshot.cs | pending | — |
| T-002 | Entry points — Update DbContext Seed | CertEasy.Data/CertEasyDbContext.cs | pending | T-001 |
