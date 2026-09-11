# Planner-Coder Todo — 134
**Requirement:** Modify the existing applications grid to include Approve and Reject action buttons. Implement role-based access control (RBAC) to ensure these buttons are only visible and accessible to admin users.

Acceptance Criteria:
- The Application grid includes distinct "Approve" and "Reject" buttons for each row.
- The buttons are only visible to users with 'Admin' privileges.
- Non-admin users cannot see or access these action buttons.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Web/Controllers/AdminController.cs: Authorize(Roles = "Admin") already present.
- CertEasy.Web/Views/Admin/Index.cshtml: Layout = "_AdminLayout" already present.
- CertEasy.Services/AdminService.cs: ApproveApplicationAsync and RejectApplicationAsync already implemented.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Web/Views/Admin/Index.cshtml: Ensure buttons are wrapped in User.IsInRole("Admin") for additional security context if needed, though the whole controller/view is admin-restricted.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Verify and Refine Admin Grid | CertEasy.Web/Views/Admin/Index.cshtml, CertEasy.Web/Controllers/AdminController.cs, CertEasy.Services/AdminService.cs | pending | — |
