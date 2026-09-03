# Gap Context — Integrate the exam selection step into the application wizard flow. It must be positioned after person profile selection and before the certification page. The view must display available exams for user selection. Upon selection, the application record must be updated with the chosen ExamId and the application status must be set to 111.

Acceptance Criteria:
- The exam selection step appears immediately after 'Person Profile Selection'
- The 'Certification' page follows the 'Exam Selection' step
- Users can see a list of available exams populated from the database
- Selecting an exam updates the application status to 111 and saves the ExamId to the application record

Dependencies: Task Admin Exam Configuration Interface, Task Database Schema Update for Exams
**Date:** 2026-09-01  |  **Task ID:** 126  |  **Type:** Brownfield

## Project Overview

### Tech Stack
- **Backend:** .NET (ASP.NET Core)
- **Frontend:** MVC with Razor Views, Knockout.js for wizard state management, jQuery for AJAX
- **Database:** Entity Framework Core (SQL Server assumed based on Migrations)
- **Patterns:** Repository Pattern (implied via Services), ViewModel pattern, Dependency Injection

### Existing Modules & Features
- **Application Model** (`CertEasy.Model\Application.cs`): Defines the core application record with `ExamID` and `StatusID`.
- **Exam Model** (`CertEasy.Model\Exam.cs`): Defines exam properties.
- **Workflow Controller** (`CertEasy.Web\Controllers\WorkflowController.cs`): Handles workflow-related actions.
- **Workflow Service** (`CertEasy.Services\WorkflowService.cs`): Business logic for application submission.
- **Wizard View** (`CertEasy.Web\Views\Workflow\Apply.cshtml`): Multi-step application UI using Knockout.js.
- **Wizard JS** (`CertEasy.Web\wwwroot\js\workflow-wizard.js`): Client-side logic for the application flow.

### Prior Context
No prior analysis found for this project.

## Requirements Analysis

### Extracted Requirements
1. **Insert Exam Selection Step:** Insert a new step in the wizard flow.
2. **Step Positioning:** The sequence must be: Profile Selection -> Exam Selection -> Certification Page.
3. **Data Retrieval:** Display available exams fetched from the database.
4. **State Persistence:** Update the application record with `ExamID` and set `StatusID` to 111.
5. **Flow Integration:** Ensure the UI transition (Back/Next) respects the new order.

### Requirements Mapping
| Requirement | Status | Location in Codebase | Notes |
|---|---|---|---|
| Step Positioning | Needs Modification | `Apply.cshtml`, `workflow-wizard.js` | Current order in `Apply.cshtml` is Step 1 (Profile), Step 2 (Certification), Step 3 (Exam). This needs reordering to match requirements. |
| Display Available Exams | Needs Modification | `workflow-wizard.js`, `WorkflowController.cs` | Logic to load exams exists but needs to be correctly bound to the new sequence. |
| Update Status to 111 | Needs Modification | `WorkflowService.cs` | The application submission logic needs to ensure the status code 111 is applied upon exam selection/submission. |
| Save ExamId | Needs Modification | `WorkflowService.cs`, `WorkflowViewModels.cs` | Ensure `ExamID` is captured in the ViewModel and persisted in the `Application` record. |

## Tech Stack & Implementation

### Wizard Flow Reordering — Needs Modification
- **Approach:** Adjust the HTML sequence in the Razor view to move the Exam Selection section before the Certification Selection. Update the Knockout.js ViewModel logic to handle the transition (Next/Back) and ensure data is validated at each step. The Progress Bar calculation logic in the view will also need adjustment to reflect the new sequence.
- **Existing files to modify:** `CertEasy.Web\Views\Workflow\Apply.cshtml`, `CertEasy.Web\wwwroot\js\workflow-wizard.js`
- **New dependencies:** None

### Exam Selection Persistence & Status Update — Needs Modification
- **Approach:** Update the `WorkflowService.SubmitApplicationAsync` method (and potentially intermediate save methods if they exist) to set the `StatusID` to 111 when an exam is selected. The `ApplyViewModel` must be reviewed to ensure it correctly maps the `ExamID` from the client-side Knockout model to the service layer.
- **Existing files to modify:** `CertEasy.Services\WorkflowService.cs`, `CertEasy.Web\Models\WorkflowViewModels.cs`, `CertEasy.Web\Controllers\WorkflowController.cs`
- **New dependencies:** None

## Summary
The project is a Brownfield ASP.NET Core application with a functional multi-step wizard implemented using Knockout.js. While the scaffolding for Exam selection exists in the `Apply.cshtml` view and `workflow-wizard.js`, the current step order and status transition logic do not meet the user's specific flow requirements.

This task requires reordering the UI steps to place Exam Selection immediately after Profile Selection and before Certification. Additionally, the backend submission logic must be hardened to enforce the status code 111 and ensure the `ExamID` is correctly mapped to the database record. The implementation is primarily additive/modificative within existing UI and service components.