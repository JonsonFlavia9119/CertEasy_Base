# Planner-Coder Todo — 152
**Requirement:** Implement logic and UI support allowing users to resubmit previously rejected applications. Enable the resubmit link/action exclusively for rejected applications while disabling or hiding it for approved applications, allowing admin users to re-evaluate and approve resubmitted applications.

Acceptance Criteria:
- Verify that only applications with a rejected status display an active 'Resubmit' link or button.
- Verify that approved or in-progress applications do not display the 'Resubmit' link.
- Verify that submitting a rejected application updates its state appropriately so that admin users can re-review and re-approve it.
- Ensure existing application submission and approval workflows remain unaffected.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Web/Controllers/WorkflowController.cs: Resubmit action exists, WorkflowService injected
- CertEasy.Web/Views/Workflow/Index.cshtml: Resubmit button exists for rejected applications
- CertEasy.Services/WorkflowService.cs: ResubmitApplicationAsync implemented

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- None (All wiring and logic already fully present and matching requirements)

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Verify and confirm backend workflow resubmission logic and controller endpoints | CertEasy.Services/IWorkflowService.cs, CertEasy.Services/WorkflowService.cs, CertEasy.Web/Controllers/WorkflowController.cs | pending | — |
| T-002 | Verify and confirm frontend UI displaying Resubmit button strictly for rejected applications | CertEasy.Web/Views/Workflow/Index.cshtml | pending | T-001 |
