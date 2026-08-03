# Planner-Coder Todo — 49
**Requirement:** Observations
1.  CertEasy. Data Project haven't been added into the solution
2.  CertEasyDb haven't been created
3.  Application launched -> none of the links not working
4.  Login, Register links are not working
5.  Make sure the application process is added, if not, please do it.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\Program.cs: CookieAuthentication, Negotiate, DbContext, custom services registered.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\Views\Shared\_Layout.cshtml: Bootstrap, jQuery, Knockout, Navbar links.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\Views\Home\Index.cshtml: Add call-to-action buttons for Login/Register/Apply.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend & Data — Ensure DB creation and missing application process logic | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\Program.cs, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Services\WorkflowService.cs | pending | — |
| T-002 | Frontend UI fixes — Enhance Home page links and ensure Layout/Views wiring | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\Views\Home\Index.cshtml | pending | T-001 |
