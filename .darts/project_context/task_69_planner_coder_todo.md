# Planner-Coder Todo — 69
**Requirement:** Ensure that the new admin functionality is protected by appropriate authorization checks so only authorized administrators can access the configuration pages.

Acceptance Criteria:
- A secure 'Admin' area or policy is applied to all admin controllers.
- Non-admin users are redirected or denied access when attempting to reach the Admin Support link or dashboard.

Technical Hints: Apply [Authorize(Roles = "Admin")] or a custom Admin policy to the controllers.

Dependencies: Task admin_dashboard_summary_view

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Web\Program.cs: Cookie authentication with LoginPath and AccessDeniedPath configured, app.UseAuthentication() and app.UseAuthorization() called.
- CertEasy.Web\Controllers\AdminController.cs: [Authorize(Roles = "Admin")] attribute present on the class.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- No new wiring needed. Existing configuration already covers the requirements.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Verify and validate authorization implementation | CertEasy.Web\Controllers\AdminController.cs, CertEasy.Web\Program.cs, CertEasy.Web\Views\Account\AccessDenied.cshtml | pending | — |
