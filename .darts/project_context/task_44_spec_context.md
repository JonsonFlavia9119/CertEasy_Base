# Spec Context — Task 44
**Generated:** 2025-02-14  |  **Framework:** .NET 6.0 MVC + KnockoutJS  |  **Tasks:** 4

## Gap Analysis Summary
This task involves developing the user-facing application workflow for the CertEasy platform. The project is a brownfield ASP.NET Core MVC application that currently handles authentication but lacks the primary business workflow. The goal is to implement a multi-step wizard (Steps 102, 103, 104, 110) using Razor for the UI structure and KnockoutJS for client-side state, two-way binding, and dynamic validation. The workflow must persist progress by updating the user's status in the database at each step.

## Task Plan

### Module: Application Workflow

#### Feature: Multi-step Application Wizard

**T-001: Implement Workflow Infrastructure: Data Model updates and Workflow Service**
- **Description:** Extend the `User` model to track application progress and create a `WorkflowService` to handle status transitions (102, 103, 104, 110). This task provides the backend foundation for the wizard.
- **Files to create:** `CertEasy.Services/IWorkflowService.cs`, `CertEasy.Services/WorkflowService.cs`
- **Files to modify:** `CertEasy.Model/User.cs`, `CertEasy.Model/CertEasyDbContext.cs`, `CertEasy.Web/Program.cs`
- **Depends on:** None
- **Acceptance criteria:**
  - `User` entity has a `StatusID` field (linked to `Status` table).
  - `WorkflowService` can successfully update a user's status in the DB.
  - Dependency Injection for `IWorkflowService` is configured in `Program.cs`.
- **Wiring:**
  - Imports from: `CertEasy.Model`
  - Imported by: `WorkflowController` (T-002)
  - API routes: None
  - DB tables: `Users`, `Statuses`
  - Env vars: None

**T-002: Implement Wizard API: Controller and Data Transfer Objects**
- **Description:** Create a `WorkflowController` with API endpoints to fetch current progress and save data for each step (Profile, Certification, Education, Invoice). These endpoints will be consumed by the KnockoutJS frontend.
- **Files to create:** `CertEasy.Web/Controllers/WorkflowController.cs`, `CertEasy.Web/Models/WorkflowViewModels.cs`
- **Files to modify:** None
- **Depends on:** T-001
- **Acceptance criteria:**
  - `GET /Workflow/GetProgress` returns the current user's step and data.
  - `POST /Workflow/SaveStep` accepts data for specific steps and returns success/fail.
  - Server-side validation is performed using Data Annotations in ViewModels.
- **Wiring:**
  - Imports from: `CertEasy.Services`, `CertEasy.Model`
  - Imported by: `wizard.js` (T-003)
  - API routes: `GET /Workflow/GetProgress`, `POST /Workflow/SaveStep`
  - DB tables: `Users`, `Addresses`
  - Env vars: None

**T-003: Implement Wizard Frontend: KnockoutJS ViewModel and Validation**
- **Description:** Create the client-side logic using KnockoutJS. This includes a ViewModel to manage the multi-step state, two-way data binding for all steps, and dynamic validation logic to prevent moving forward if steps are incomplete.
- **Files to create:** `CertEasy.Web/wwwroot/js/workflow-wizard.js`
- **Files to modify:** None
- **Depends on:** T-002
- **Acceptance criteria:**
  - Knockout ViewModel correctly tracks `currentStep` (102, 103, 104, 110).
  - Validation logic correctly identifies empty fields for the current step.
  - `nextStep()` function only proceeds if the current step is valid.
  - Data is automatically saved to the server when moving between steps via AJAX.
- **Wiring:**
  - Imports from: KnockoutJS (CDN in Layout)
  - Imported by: `Apply.cshtml` (T-004)
  - API routes: Calls `GET /Workflow/GetProgress`, `POST /Workflow/SaveStep`
  - DB tables: None
  - Env vars: None

**T-004: Implement Wizard UI: Razor View and Layout Integration**
- **Description:** Create the `Apply` Razor view that defines the wizard UI structure. Use KnockoutJS bindings (`visible`, `value`, `click`, `enable`) to connect the HTML elements to the ViewModel.
- **Files to create:** `CertEasy.Web/Views/Workflow/Apply.cshtml`
- **Files to modify:** `CertEasy.Web/Views/Shared/_Layout.cshtml`
- **Depends on:** T-003
- **Acceptance criteria:**
  - `Apply` view is accessible at `/Workflow/Apply`.
  - UI shows only the current step's fields.
  - "Next" and "Previous" buttons navigate correctly.
  - Navigation link to "Start Application" is added to the Layout for authenticated users.
- **Wiring:**
  - Imports from: `workflow-wizard.js`, `_Layout.cshtml`
  - Imported by: None
  - API routes: None
  - DB tables: None
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
          "feature": "Multi-step Application Wizard",
          "tasks": [
            {
              "id": "T-001",
              "name": "Implement Workflow Infrastructure",
              "description": "Extend User model with StatusID and create WorkflowService for status transitions.",
              "files_to_create": [
                "CertEasy.Services/IWorkflowService.cs",
                "CertEasy.Services/WorkflowService.cs"
              ],
              "files_to_modify": [
                "CertEasy.Model/User.cs",
                "CertEasy.Model/CertEasyDbContext.cs",
                "CertEasy.Web/Program.cs"
              ],
              "depends_on": [],
              "acceptance_criteria": [
                "User entity has a StatusID field (linked to Status table).",
                "WorkflowService can successfully update a user's status in the DB.",
                "Dependency Injection for IWorkflowService is configured in Program.cs."
              ],
              "status": "pending",
              "wiring": {
                "imports_from": ["CertEasy.Model"],
                "imported_by": ["WorkflowController"],
                "api_routes": [],
                "db_tables": ["Users", "Statuses"],
                "env_vars": []
              }
            },
            {
              "id": "T-002",
              "name": "Implement Wizard API",
              "description": "Create WorkflowController and ViewModels for AJAX-based step saving and progress retrieval.",
              "files_to_create": [
                "CertEasy.Web/Controllers/WorkflowController.cs",
                "CertEasy.Web/Models/WorkflowViewModels.cs"
              ],
              "files_to_modify": [],
              "depends_on": ["T-001"],
              "acceptance_criteria": [
                "GET /Workflow/GetProgress returns current user's step and data.",
                "POST /Workflow/SaveStep accepts step data and returns success/fail.",
                "Server-side validation is enforced in ViewModels."
              ],
              "status": "pending",
              "wiring": {
                "imports_from": ["CertEasy.Services", "CertEasy.Model"],
                "imported_by": ["workflow-wizard.js"],
                "api_routes": ["GET /Workflow/GetProgress", "POST /Workflow/SaveStep"],
                "db_tables": ["Users", "Addresses"],
                "env_vars": []
              }
            },
            {
              "id": "T-003",
              "name": "Implement Wizard Frontend Logic",
              "description": "Create KnockoutJS ViewModel to manage multi-step state, validation, and AJAX persistence.",
              "files_to_create": [
                "CertEasy.Web/wwwroot/js/workflow-wizard.js"
              ],
              "files_to_modify": [],
              "depends_on": ["T-002"],
              "acceptance_criteria": [
                "Knockout ViewModel tracks currentStep (102-110).",
                "Dynamic validation prevents moving to next step if fields are empty.",
                "Data is saved via AJAX on step transition."
              ],
              "status": "pending",
              "wiring": {
                "imports_from": ["KnockoutJS"],
                "imported_by": ["Apply.cshtml"],
                "api_routes": ["GET /Workflow/GetProgress", "POST /Workflow/SaveStep"],
                "db_tables": [],
                "env_vars": []
              }
            },
            {
              "id": "T-004",
              "name": "Implement Wizard UI",
              "description": "Create Apply Razor view and integrate KnockoutJS bindings with the UI.",
              "files_to_create": [
                "CertEasy.Web/Views/Workflow/Apply.cshtml"
              ],
              "files_to_modify": [
                "CertEasy.Web/Views/Shared/_Layout.cshtml"
              ],
              "depends_on": ["T-003"],
              "acceptance_criteria": [
                "Apply view is accessible and renders wizard steps correctly.",
                "UI elements are bound to Knockout observables.",
                "Layout includes navigation to the application wizard."
              ],
              "status": "pending",
              "wiring": {
                "imports_from": ["workflow-wizard.js", "_Layout.cshtml"],
                "imported_by": [],
                "api_routes": [],
                "db_tables": [],
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