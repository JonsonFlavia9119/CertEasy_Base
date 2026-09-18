# Gap Context — Requirements

As an user, I would like to modify the application process and add additional field in the 'Education & Remarks' & Certification sections

A new file upload control should be available and user should be able to choose and upload file.

* users are able to choose and upload their educational documents and the certificate documents
* A new table should be added to the database named "FileUploads"
* My goal is the FileUpload table is open for all modules. 
* EntityId should be ApplicationId and EntityTypeId should be EducationId 
* EntityId should be ApplicationId and EntityTypeId should be CertificationId
* Create a new folder namm=ed "FIleUploads" in the application directory and save the path in FileUploads table. 

Check

* Only specified changes has to be made
* Existing functionalities should not get affected
* File Upload should be working fine.
* Ensure file upload code changes are fine below areas
-> SQL DB
-> Migration applied correctly
-> Server side code changes
-> viewmodel.js changes
-> .cshtml controls are fine
-> Ensure nothing is breaking

**Date:** 2026-09-17  |  **Task ID:** 158  |  **Type:** Brownfield

## Project Overview

### Tech Stack
- .NET 8.0 / ASP.NET Core MVC
- Entity Framework Core 8.0 (SQL Server)
- Serilog for structured logging and exception handling
- Knockout.js, jQuery, Bootstrap 5, Razor Views for frontend UI
- Repository Pattern / Service Layer Architecture with Dependency Injection

### Existing Modules & Features
- **Workflow Controller & Application Wizard** (`CertEasy.Web/Controllers/WorkflowController.cs`, `CertEasy.Web/Views/Workflow/Apply.cshtml`, `CertEasy.Web/wwwroot/js/workflow-wizard.js`): Manages multi-step application wizard for certifications, exam slot selection, education levels, remarks, and application submission.
- **Workflow Service** (`CertEasy.Services/WorkflowService.cs`, `CertEasy.Services/IWorkflowService.cs`): Service implementation handling core user application workflows including retrieving active certifications, exams, education levels, application submissions, and resubmissions.
- **Domain Models & DB Context** (`CertEasy.Model/Application.cs`, `CertEasy.Model/BaseEntity.cs`, `CertEasy.Data/CertEasyDbContext.cs`): EF Core entity models for Application, Certification, Education, Exam, User, and DbContext configuration.
- **Admin Controller & Service** (`CertEasy.Web/Controllers/AdminController.cs`, `CertEasy.Services/AdminService.cs`): Manages admin dashboard, application approvals, badge assignments, and system lookup configurations.

### Prior Context
In previous tasks (such as Tasks 126, 155), application wizard workflow steps, exam scheduling, badge assignments, and admin management features were established. The database context and application entity support multi-step certification application processing.

## Requirements Analysis

### Extracted Requirements
1. **Generic FileUpload Entity & Database Table:** Add a generic `FileUpload` domain model (`FileUpload.cs`) inheriting from `BaseEntity` and configure `DbSet<FileUpload> FileUploads` in `CertEasyDbContext`. Create and apply an Entity Framework Core migration (`AddFileUploadsTable`) to generate the `FileUploads` table in the SQL database. The schema must support generic module usage with fields such as `EntityId`, `EntityTypeId` (or `Module`), `FileName`, `FilePath`, `ContentType`, `FileSize`, and audit fields.
2. **Physical Storage Folder:** Create a physical folder named `FileUploads` in the application root directory (e.g., `wwwroot/FileUploads` or application directory) to securely store uploaded educational and certification documents.
3. **Certification File Upload Control:** Add file upload control (`<input type="file">`) to the Certification selection step in the application wizard view (`Apply.cshtml`) enabling users to select and attach certification documents.
4. **Education File Upload Control:** Add file upload control (`<input type="file">`) to the Education & Remarks step in the application wizard view (`Apply.cshtml`) enabling users to select and attach educational documents.
5. **Knockout JS ViewModel Updates:** Update `workflow-wizard.js` (and view model logic) to handle file selection, bind file inputs, construct `FormData` payload for HTTP POST requests, and display file names/previews or selection statuses across wizard steps and review step.
6. **Server-Side File Persistence Logic:** Extend `WorkflowController` and `WorkflowService` to process multipart form upload requests, save files to the `FileUploads` folder, record metadata in the `FileUploads` database table setting `EntityId = ApplicationId` and `EntityTypeId = EducationId` for education documents, and `EntityId = ApplicationId` and `EntityTypeId = CertificationId` for certification documents.
7. **Preserve Existing Workflows:** Ensure existing application validation, exam selection, admin approval workflows, and database integrity remain completely unaffected.

### Requirements Mapping
| Requirement | Status | Location in Codebase | Notes |
|---|---|---|---|
| Generic FileUpload Model & DB Table | New Development | `CertEasy.Model/FileUpload.cs`, `CertEasy.Data/CertEasyDbContext.cs`, `CertEasy.Data/Migrations/` | Define `FileUpload` entity with generic `EntityId` and `EntityTypeId` columns and add `DbSet<FileUpload> FileUploads` to DbContext. |
| Physical `FileUploads` Directory | New Development | `CertEasy.Web/wwwroot/FileUploads` or `CertEasy.Web/FileUploads` | Ensure folder exists or is automatically created at runtime for saving uploaded files. |
| Certification File Upload UI Control | Needs Modification | `CertEasy.Web/Views/Workflow/Apply.cshtml` | Add `<input type="file">` for certificate documents in Step 3 (Select Certification). |
| Education File Upload UI Control | Needs Modification | `CertEasy.Web/Views/Workflow/Apply.cshtml` | Add `<input type="file">` for education documents in Step 4 (Education & Remarks). |
| Knockout JS ViewModel Updates | Needs Modification | `CertEasy.Web/wwwroot/js/workflow-wizard.js` | Add observables for uploaded files, update `submitApplication` to send `FormData` via AJAX. |
| Server-Side File Upload & Record Service | Needs Modification | `CertEasy.Web/Controllers/WorkflowController.cs`, `CertEasy.Services/IWorkflowService.cs`, `CertEasy.Services/WorkflowService.cs`, `CertEasy.Web/Models/ApplicationViewModel.cs` | Handle `IFormFile` inputs in POST action, save physical files to `FileUploads` folder, and insert `FileUpload` records into database with `EntityId = ApplicationId` and `EntityTypeId = EducationId` / `CertificationId`. |
| Preserve Existing Functionality | Already Exists | `CertEasy.Web/Controllers/WorkflowController.cs`, `CertEasy.Services/WorkflowService.cs` | Ensure application submission, status transitions, and admin reviews operate seamlessly without breaking existing capabilities. |

## Tech Stack & Implementation

### FileUpload Model, Database Migration & Storage — New Development
- **Approach:** Create a generic `FileUpload` domain model class inheriting from `BaseEntity` in `CertEasy.Model` containing properties `FileName`, `FilePath`, `ContentType`, `FileSize`, `EntityId`, `EntityTypeId`. Add `DbSet<FileUpload> FileUploads` in `CertEasyDbContext.cs`. Generate an EF Core migration to create the `FileUploads` table in SQL Server DB. Configure physical folder creation for `FileUploads` under the application directory (`wwwroot/FileUploads` or app context root).
- **Existing files to modify:** `CertEasy.Data/CertEasyDbContext.cs`
- **New dependencies:** None

### Razor View Controls & Knockout ViewModel (`workflow-wizard.js`) — Needs Modification
- **Approach:** Modify `Apply.cshtml` to add file upload controls (`<input type="file">`) under Certification Selection (Step 3) and Education Details (Step 4). Update `workflow-wizard.js` to define file observables, attach change event listeners to store selected files, update Review step (Step 5) to summarize attached document names, and update `submitApplication` to submit data via `FormData` (`multipart/form-data`) instead of plain JSON stringification.
- **Existing files to modify:** `CertEasy.Web/Views/Workflow/Apply.cshtml`, `CertEasy.Web/wwwroot/js/workflow-wizard.js`
- **New dependencies:** None

### Server-Side File Saving & Entity Association — Needs Modification
- **Approach:** Update `ApplicationViewModel` and `WorkflowController.SubmitApplication` to accept uploaded `IFormFile` instances (`CertificationDocument` and `EducationDocument`). In `WorkflowService.cs` (or via helper method), save files into `FileUploads` folder with unique filenames, create `FileUpload` entities mapping `EntityId = application.Id` and `EntityTypeId = EducationId` (for education files) and `EntityTypeId = CertificationId` (for certification files), and persist `FileUpload` records to the database. Wrap file saving and database persistence in transaction/exception handling with Serilog logging.
- **Existing files to modify:** `CertEasy.Web/Controllers/WorkflowController.cs`, `CertEasy.Web/Models/ApplicationViewModel.cs`, `CertEasy.Services/IWorkflowService.cs`, `CertEasy.Services/WorkflowService.cs`
- **New dependencies:** None

## Summary
The project is a Brownfield ASP.NET Core MVC application with Entity Framework Core and Knockout.js multi-step application wizard.

This task requires modifying the application wizard process by introducing file upload controls in both the Certification selection and Education & Remarks steps, allowing users to upload certification and education documents. A new generic `FileUploads` table will be added to the SQL database using Entity Framework Core migrations to store file metadata (`FileName`, `FilePath`, `EntityId`, `EntityTypeId`), with `EntityId` set to `ApplicationId` and `EntityTypeId` set to `EducationId` or `CertificationId` respectively. Physical files will be stored in a dedicated `FileUploads` folder in the application directory.

The implementation involves adding a new `FileUpload` domain model, adding `DbSet<FileUpload> FileUploads` in `CertEasyDbContext`, adding file input controls in `Apply.cshtml`, updating Knockout observables and AJAX `FormData` handling in `workflow-wizard.js`, and extending server-side service methods in `WorkflowService` and `WorkflowController` to handle file uploads safely without disrupting existing application submission and approval workflows.
