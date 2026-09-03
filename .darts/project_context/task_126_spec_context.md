# Spec Context — Task 126
**Generated:** 2025-05-15  |  **Framework:** ASP.NET Core MVC (Brownfield)  |  **Tasks:** 1

## Gap Analysis Summary
This task involves reordering the multi-step application wizard to place "Exam Selection" immediately after "Person Profile Selection" and before "Certification Selection". The existing implementation already has the "Exam Selection" step but at a different sequence (Step 3). Additionally, the application submission logic must be updated to set the application `StatusID` to 111 upon submission. The project uses Knockout.js for client-side wizard state and ASP.NET Core for the backend.

## Task Plan

### Module: Application Workflow

#### Feature: Exam Selection Reordering

**T-001: Reorder Wizard steps and update application submission status**
- **Description:** Adjust the sequence of steps in the application wizard flow within the Razor view and Knockout.js model. Move Exam Selection to Step 2, and Certification to Step 3. Update the backend submission logic in `WorkflowController` to set the `StatusID` to 111 (as per requirement, despite the existing enum values). Ensure the frontend progress bar reflects the new step logic.
- **Files to create:** None
- **Files to modify:** CertEasy.Web/Views/Workflow/Apply.cshtml, CertEasy.Web/wwwroot/js/workflow-wizard.js, CertEasy.Web/Controllers/WorkflowController.cs
- **Depends on:** None
- **Acceptance criteria:**
  - "Exam Selection" step appears immediately after "Profile Confirmation" (Step 1).
  - "Certification Selection" step follows "Exam Selection".
  - The progress bar in the UI updates correctly based on the new step positions.
  - Successfully submitting an application creates a record with `StatusID = 111`.
  - Selecting an exam persists the `ExamID` correctly in the database.
- **Wiring:**
  - Imports from: CertEasy.Web.Models.ApplicationViewModel, CertEasy.Model.Application, CertEasy.Services.IWorkflowService
  - Imported by: None (Main application flow)
  - API routes: POST /Workflow/SubmitApplication
  - DB tables: Applications
  - Env vars: None

---

## Machine-Readable Task Plan

```json
{
  "modules": [
    {
      "module": "Application Workflow",
      "features": [
        {
          "feature": "Exam Selection Reordering",
          "tasks": [
            {
              "id": "T-001",
              "name": "Reorder Wizard steps and update application submission status",
              "description": "Adjust the sequence of steps in the application wizard flow within the Razor view and Knockout.js model. Move Exam Selection to Step 2, and Certification to Step 3. Update the backend submission logic in WorkflowController to set the StatusID to 111. Ensure the frontend progress bar reflects the new step logic.",
              "files_to_create": [],
              "files_to_modify": [
                "CertEasy.Web/Views/Workflow/Apply.cshtml",
                "CertEasy.Web/wwwroot/js/workflow-wizard.js",
                "CertEasy.Web/Controllers/WorkflowController.cs"
              ],
              "depends_on": [],
              "acceptance_criteria": [
                "Exam Selection step appears immediately after Profile Confirmation (Step 1).",
                "Certification Selection step follows Exam Selection.",
                "The progress bar in the UI updates correctly based on the new step positions.",
                "Successfully submitting an application creates a record with StatusID = 111.",
                "Selecting an exam persists the ExamID correctly in the database."
              ],
              "status": "pending",
              "wiring": {
                "imports_from": [
                  "CertEasy.Web.Models.ApplicationViewModel",
                  "CertEasy.Model.Application",
                  "CertEasy.Services.IWorkflowService"
                ],
                "imported_by": [],
                "api_routes": [
                  "POST /Workflow/SubmitApplication"
                ],
                "db_tables": [
                  "Applications"
                ],
                "env_vars": []
              }
            }
          ]
        }
      ]
    }
  ]
}
```
