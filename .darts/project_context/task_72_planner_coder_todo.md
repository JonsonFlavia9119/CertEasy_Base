# Planner-Coder Todo — 72
**Requirement:** I would like to add ObtainedYear filed in the certifications table also it should reflect in the certification page in admin area. 
Please add migration to achieve this.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: DbSet<Certification> Certifications
- CertEasy.Web/Controllers/AdminController.cs: AdminController actions (ManageCertifications, CreateCertification, EditCertification)
- CertEasy.Services/AdminService.cs: AdminService methods (AddCertificationAsync, UpdateCertificationAsync)

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Data/Migrations/[Timestamp]_AddObtainedYearToCertification.cs: New migration file for the database field.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend — Certification Model and Migration | CertEasy.Model/Certification.cs, CertEasy.Data/Migrations/20240102000000_AddObtainedYearToCertification.cs | pending | — |
| T-002 | Backend — Service Update | CertEasy.Services/AdminService.cs | pending | T-001 |
| T-003 | Frontend UI — Views Update | CertEasy.Web/Views/Admin/ManageCertifications.cshtml, CertEasy.Web/Views/Admin/CreateCertification.cshtml, CertEasy.Web/Views/Admin/EditCertification.cshtml | pending | T-002 |
