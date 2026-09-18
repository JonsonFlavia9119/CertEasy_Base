# Planner-Coder Todo — 157
**Requirement:** As an user, I would like to modify the application process and add additional fields in 'Select Exam Session'
During exam selection, there is possibilities to have same exam with different location and exam date so these are all be selected during the application process. So there will be 3 dropdowns 
1. Exam name
2. Location
3. Exam Date

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Web/Views/Workflow/Apply.cshtml: knockout bindings for step 2 exam selection
- CertEasy.Web/wwwroot/js/workflow-wizard.js: WorkflowViewModel knockout logic

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Web/Views/Workflow/Apply.cshtml: update step 2 to display 3 dropdowns (Exam Name, Location, Exam Date)
- CertEasy.Web/wwwroot/js/workflow-wizard.js: update Knockout viewmodel to cascade Exam Name -> Location -> Exam Date/Slot

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Update Frontend UI and Knockout JS for 3 cascading dropdowns in Exam Selection | CertEasy.Web/Views/Workflow/Apply.cshtml, CertEasy.Web/wwwroot/js/workflow-wizard.js | pending | — |
