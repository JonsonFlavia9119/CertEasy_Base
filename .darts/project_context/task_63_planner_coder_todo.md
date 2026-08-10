# Planner-Coder Todo — 63
**Requirement:** Create a dedicated layout for the Admin section of the application. This ensures that administrative pages have a distinct look and feel and specialized navigation menus compared to the standard user interface.

Acceptance Criteria:
- A new layout file exists specifically for Admin pages (e.g., _AdminLayout.cshtml).
- The Admin Support link uses this layout instead of the default user layout.
- The layout includes a navigation menu specific to administration tasks.

Technical Hints: Create the layout in the Views/Shared folder. Ensure it contains a @RenderBody() and references the necessary CSS/JS bundles.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Web\Views\_ViewStart.cshtml: Layout = "_Layout";

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Web\Views\Admin\_ViewStart.cshtml: add Layout = "_AdminLayout";
- CertEasy.Web\Views\Shared\_AdminLayout.cshtml: new file
- CertEasy.Web\Views\Shared\_Layout.cshtml: preserve existing structure

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Create Admin Layout and Wiring | CertEasy.Web\Views\Shared\_AdminLayout.cshtml, CertEasy.Web\Views\Admin\_ViewStart.cshtml | pending | — |
