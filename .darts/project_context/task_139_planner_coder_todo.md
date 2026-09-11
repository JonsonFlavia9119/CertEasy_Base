# Planner-Coder Todo — 139
**Requirement:** As per my requirements

* Approve and Reject buttons should be visible on all invoices in the grid. 
* Email configurations page should get displayed in the admin area

Result:
the result is negative.

Checks:

* Analyze the project requirements and make the changes 
* Verify the migrations and alter if needed
* Verify the data binding
* Verify the migrations and SQL DB schema and it should be perfectly synced
* Verify the migration folder
* Verify the viewmodel and binding
* Make sure the project requirements are fully covered

Lists
* let me know the list of files modified
* list out the root cause and fixes

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:/DARTS-development-environment/sandbox/kjohnson/CertEasy_AdminActions_Phase1/CertEasy.Web/Program.cs: builder.Services.AddScoped<IAdminService, AdminService>();
- C:/DARTS-development-environment/sandbox/kjohnson/CertEasy_AdminActions_Phase1/CertEasy.Web/Views/Shared/_AdminLayout.cshtml: Email Config link in sidebar

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:/DARTS-development-environment/sandbox/kjohnson/CertEasy_AdminActions_Phase1/CertEasy.Web/Views/Admin/Index.cshtml: Ensure buttons visible for all rows

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Update Admin Dashboard View to show Approve/Reject buttons for all applications | CertEasy.Web/Views/Admin/Index.cshtml | pending | — |
| T-002 | Verify Email Configuration integration and UI | CertEasy.Web/Views/Shared/_AdminLayout.cshtml, CertEasy.Web/Views/Admin/EmailConfiguration.cshtml | pending | T-001 |
