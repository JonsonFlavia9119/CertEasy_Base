# Todo List — Task 158
**Generated:** 2026-09-17  |  **Total Tasks:** 3  |  **Framework:** ASP.NET Core 8.0 MVC / EF Core / Knockout.js

---

## Progress Summary

| Status | Count |
|---|---|
| pending | 2 |
| in_progress | 0 |
| completed | 1 |
| failed | 0 |
| **Total** | **3** |

---

## Module: FileUpload Infrastructure

### Feature: Generic FileUpload Data & Storage Layer

| ID | Task | Status | Files |
|---|---|---|---|
| T-001 | Implement FileUpload entity model, DbContext mapping, database migration, and storage directory initialization | completed | `CertEasy.Model/FileUpload.cs`, `CertEasy.Data/Migrations/[Timestamp]_AddFileUploadsTable.cs`, `CertEasy.Data/CertEasyDbContext.cs` |

---

## Module: Workflow Management

### Feature: Application Document Upload & Wizard Integration

| ID | Task | Status | Files |
|---|---|---|---|
| T-002 | Add document upload controls to Application Wizard Razor View and Knockout ViewModel | in_progress | `CertEasy.Web/Views/Workflow/Apply.cshtml`, `CertEasy.Web/wwwroot/js/workflow-wizard.js`, `CertEasy.Web/Models/ApplicationViewModel.cs` |
| T-003 | Implement server-side document persistence and FileUpload record generation in Workflow Service | pending | `CertEasy.Services/IWorkflowService.cs`, `CertEasy.Services/WorkflowService.cs`, `CertEasy.Web/Controllers/WorkflowController.cs` |

---

## All Tasks (flat list for coding agent)

| ID | Module | Feature | Task | Status | Depends On |
|---|---|---|---|---|---|
| T-001 | FileUpload Infrastructure | Generic FileUpload Data & Storage Layer | Implement FileUpload entity model, DbContext mapping, database migration, and storage directory initialization | completed | — |
| T-002 | Workflow Management | Application Document Upload & Wizard Integration | Add document upload controls to Application Wizard Razor View and Knockout ViewModel | in_progress | T-001 |
| T-003 | Workflow Management | Application Document Upload & Wizard Integration | Implement server-side document persistence and FileUpload record generation in Workflow Service | pending | T-001, T-002 |
