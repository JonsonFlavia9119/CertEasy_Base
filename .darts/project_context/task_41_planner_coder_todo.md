# Planner-Coder Todo — 41
**Requirement:** Implement the Certification and Education tables. Both tables use EntityID and EntityTypeID to distinguish between Application (200) and Account (201) levels as per requirement.

Acceptance Criteria:
- Table 'Certification' created with fields: ID, EntityID, EntityTypeID, CertificationId, CertificationName, CertificationDescription, CreatedDate, CreatedBy.
- Table 'Education' created with fields: ID, EntityID, EntityTypeID, InstituteName, Qualification, DegreeName, CreatedDate, CreatedBy.

Dependencies: Task User and Address Data Models

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Model/CertEasyDbContext.cs: DbSet<Role>, DbSet<Status>, DbSet<Address>, DbSet<User>

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Model/CertEasyDbContext.cs: add DbSet<Certification>, DbSet<Education>
- CertEasy.Web/Program.cs: add builder.Services.AddScoped<ICertificationService, CertificationService>(), builder.Services.AddScoped<IEducationService, EducationService>()

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend — Certification and Education Models + DbContext updates | CertEasy.Model/Certification.cs, CertEasy.Model/Education.cs, CertEasy.Model/CertEasyDbContext.cs | pending | — |
| T-002 | Services — Certification and Education Services | CertEasy.Services/ICertificationService.cs, CertEasy.Services/CertificationService.cs, CertEasy.Services/IEducationService.cs, CertEasy.Services/EducationService.cs, CertEasy.Web/Program.cs | pending | T-001 |
| T-003 | Controllers — Certification and Education API Controllers | CertEasy.Web/Controllers/CertificationController.cs, CertEasy.Web/Controllers/EducationController.cs | pending | T-002 |
