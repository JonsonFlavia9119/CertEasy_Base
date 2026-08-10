# Planner-Coder Todo — 74
**Requirement:** 1. Education Levels page not working - Analyze the root cause and fix the issue like production ready

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Web\Program.cs: IAdminService registered with AdminService
- CertEasy.Web\Controllers\AdminController.cs: AdminService injected, ManageEducation action exists
- CertEasy.Data\CertEasyDbContext.cs: EducationLevels DbSet and seed data exist

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Web\Views\Admin\ManageEducation.cshtml: Correct form field names and validation
- CertEasy.Services\AdminService.cs: Add robust error handling and logging for Education Level operations

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Fix Backend Service and Controller logic for Education Levels | CertEasy.Services\AdminService.cs, CertEasy.Web\Controllers\AdminController.cs | pending | — |
| T-002 | Fix Frontend View for Education Levels | CertEasy.Web\Views\Admin\ManageEducation.cshtml | pending | T-001 |
