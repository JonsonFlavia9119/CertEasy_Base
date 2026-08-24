# Planner-Coder Todo — 94
**Requirement:** Fix "Invalid column name 'EntityID'" and "Invalid column name 'EntityTypeID'" errors by aligning Education and Certification models with the actual SQL schema.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: DbSet<Education>, DbSet<Certification>
- CertEasy.Web/Controllers/AdminController.cs: Admin dashboard, Certification and Education management actions

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Model/Education.cs: Remove EntityID and EntityTypeID to match SQL schema.
- CertEasy.Model/Certification.cs: Ensure no hidden EntityID/EntityTypeID fields.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Align Models with SQL Schema | CertEasy.Model/Education.cs, CertEasy.Model/Certification.cs | pending | — |
| T-002 | Update Migration and DbContext | CertEasy.Data/Migrations/20260818081632_AddEducationAndEditCertification.cs | pending | T-001 |
