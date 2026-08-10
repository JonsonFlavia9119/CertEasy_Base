# Planner-Coder Todo — 75
**Requirement:** Still I am facing the same error, Education Levels link is not working. Getting InvalidOperationException: The view 'Error' was not found. Analyze root cause and fix.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Web/Program.cs: options.Filters.Add<CertEasy.Web.Filters.AdminExceptionFilter>();
- CertEasy.Web/Filters/AdminExceptionFilter.cs: ViewName = "~/Views/Shared/Error.cshtml"

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Web/Views/Admin/Error.cshtml: Create file to ensure Admin controller can find it
- CertEasy.Web/Views/Shared/Error.cshtml: Update to support both Filter and standard MVC error handling
- CertEasy.Web/Filters/AdminExceptionFilter.cs: Ensure it uses a robust path and correct ViewData handling

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Fix Error View and Filter | CertEasy.Web/Filters/AdminExceptionFilter.cs, CertEasy.Web/Views/Shared/Error.cshtml, CertEasy.Web/Views/Admin/Error.cshtml | pending | — |
| T-002 | Fix ManageEducation link potential issues | CertEasy.Web/Views/Shared/_AdminLayout.cshtml, CertEasy.Web/Controllers/AdminController.cs | pending | T-001 |
