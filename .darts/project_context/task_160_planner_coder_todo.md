# Planner-Coder Todo — 160
**Requirement:** As an admin user, I would like to view badge for completed applications.

Change the label to link for completed applications grid
My Idea if when the link is clicked then a new window should open and show their badges
My vision is the badge is like Accredible badge provider
Use any badge provider to show this badge in new window

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Web/Controllers/AdminController.cs: ViewBadge(int id) [HttpGet, AllowAnonymous], Index()
- CertEasy.Web/Views/Admin/Index.cshtml: completedApplicationsGrid rendering ViewBadge link with target="_blank"
- CertEasy.Web/Views/Admin/ViewBadge.cshtml: Accredible-style badge provider view template

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- N/A - all views and routes already fully wired and verified.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Verify and confirm complete implementation of completed applications badge link and Accredible-style badge page in new window | CertEasy.Web/Controllers/AdminController.cs, CertEasy.Web/Views/Admin/Index.cshtml, CertEasy.Web/Views/Admin/ViewBadge.cshtml | completed | — |
