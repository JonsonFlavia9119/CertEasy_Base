# Planner-Coder Todo — 73
**Requirement:** Remove Admin support page
Remove Education Entries page
Add Institute name in the education levels page. Add migration if needed

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Data\CertEasyDbContext.cs: DbSet<Role>, DbSet<Status>, DbSet<Address>, DbSet<Certification>, DbSet<EducationLevel>, DbSet<Education>, DbSet<User>, DbSet<Log>, DbSet<Application>
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Web\Views\Shared\_AdminLayout.cshtml: sidebar navigation links

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Web\Controllers\AdminController.cs: remove ManageEducationEntries, CreateEducation, EditEducation, DeleteEducation
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Web\Views\Shared\_AdminLayout.cshtml: ensure ManageEducationEntries is not linked (already seems absent or removed)

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Cleanup Controller and Logic | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Web\Controllers\AdminController.cs | pending | — |
| T-002 | Cleanup Views and Layout | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase1\CertEasy.Web\Views\Shared\_AdminLayout.cshtml | pending | T-001 |
