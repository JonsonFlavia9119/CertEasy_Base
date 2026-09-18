# Spec Context — Task 158
**Generated:** 2026-09-17  |  **Framework:** ASP.NET Core 8.0 MVC / EF Core / Knockout.js  |  **Tasks:** 3

## Gap Analysis Summary
The requirement is to extend the existing certification application workflow to support document uploads in the 'Education & Remarks' and 'Certification' sections of the application process. A generic `FileUpload` model and database table (`FileUploads`) must be introduced to store file metadata (`FileName`, `FilePath`, `ContentType`, `FileSize`, `EntityId`, `EntityTypeId`), designed for open use across modules. For education documents, `EntityId` must be set to `ApplicationId` and `EntityTypeId` to `EducationId`; for certification documents, `EntityId` must be set to `ApplicationId` and `EntityTypeId` to `CertificationId`. Physical files must be saved in a dedicated `FileUploads` directory within the application directory.

## Task Plan

### Module: File Upload Infrastructure

#### Feature: Generic FileUpload Data & Storage Layer

**T-001: Implement FileUpload entity model, DbContext mapping, database migration, and storage directory initialization**
- **Description:** Define the generic `FileUpload` domain model in `CertEasy.Model/FileUpload.cs` extending `BaseEntity` with generic properties `FileName`, `FilePath`, `ContentType`, `FileSize`, `EntityId` (long), and `EntityTypeId` (long). Register `DbSet<FileUpload> FileUploads` in `CertEasy.Data/CertEasyDbContext.cs`. Create and apply an EF Core migration (`AddFileUploadsTable`) to generate the `FileUploads` SQL table. Ensure physical `FileUploads` folder creation logic exists under application directory / web root (`wwwroot/FileUploads`).
- **Files to create:** CertEasy.Model/FileUpload.cs, CertEasy.Data/Migrations/[Timestamp]_AddFileUploadsTable.cs
- **Files to modify:** CertEasy.Data/CertEasyDbContext.cs
- **Depends on:** None
- **Acceptance criteria:**
  - `FileUpload` entity is created inheriting from `BaseEntity` with `EntityId`, `EntityTypeId`, `FileName`, `FilePath`, `ContentType`, and `FileSize`.
  - `CertEasyDbContext` includes `DbSet<FileUpload> FileUploads`.
  - EF Core Migration for `FileUploads` table is generated and builds cleanly.
  - Storage path `wwwroot/FileUploads` (or application root directory `FileUploads`) is created automatically if it does not exist.
- **Wiring:**
  - Imports from: CertEasy.Model/BaseEntity.cs
  - Imported by: CertEasy.Data/CertEasyDbContext.cs, CertEasy.Services/WorkflowService.cs
  - API routes: None
  - DB tables: FileUploads
  - Env vars: None

---

### Module: Workflow Management

#### Feature: Application Document Upload & Wizard Integration

**T-002: Add document upload controls to Application Wizard Razor View and Knockout ViewModel**
- **Description:** Update `CertEasy.Web/Views/Workflow/Apply.cshtml` to add file upload controls (`<input type="file">`) under Certification step and Education & Remarks step. Update `CertEasy.Web/wwwroot/js/workflow-wizard.js` to add Knockout observables for file inputs, capture file selections, display file details/summaries in the Review step, and send application data as `FormData` (`multipart/form-data`) during AJAX submission. Update `CertEasy.Web/Models/ApplicationViewModel.cs` to handle uploaded files (`IFormFile` properties `CertificationDocument` and `EducationDocument`).
- **Files to create:** None
- **Files to modify:** CertEasy.Web/Views/Workflow/Apply.cshtml, CertEasy.Web/wwwroot/js/workflow-wizard.js, CertEasy.Web/Models/ApplicationViewModel.cs
- **Depends on:** T-001
- **Acceptance criteria:**
  - Razor view `Apply.cshtml` renders file upload inputs in both Certification selection and Education & Remarks sections.
  - Knockout ViewModel binds file selection events, retains selected files across wizard step transitions, and shows selected file names in the review step.
  - Form submission posts data via `FormData` containing `CertificationDocument` and `EducationDocument` files alongside form fields.
  - `ApplicationViewModel` properly receives file objects from multipart POST request.
- **Wiring:**
  - Imports from: CertEasy.Web/wwwroot/js/workflow-wizard.js, CertEasy.Web/Models/ApplicationViewModel.cs
  - Imported by: CertEasy.Web/Views/Workflow/Apply.cshtml
  - API routes: POST /Workflow/Apply or /Workflow/SubmitApplication
  - DB tables: None
  - Env vars: None

**T-003: Implement server-side document persistence and FileUpload record generation in Workflow Service**
- **Description:** Update `WorkflowController` and `WorkflowService` (`IWorkflowService.cs`, `WorkflowService.cs`) to process uploaded `IFormFile` inputs. Save uploaded certification and education files to the `FileUploads` directory with unique file names. Save `FileUpload` entity records to database table `FileUploads` setting `EntityId = ApplicationId` and `EntityTypeId = CertificationId` for certification documents, and `EntityId = ApplicationId` and `EntityTypeId = EducationId` for education documents. Maintain robust exception handling and Serilog logging to ensure existing application workflows and existing database functions are preserved.
- **Files to create:** None
- **Files to modify:** CertEasy.Services/IWorkflowService.cs, CertEasy.Services/WorkflowService.cs, CertEasy.Web/Controllers/WorkflowController.cs
- **Depends on:** T-001, T-002
- **Acceptance criteria:**
  - Uploaded files are securely written to the `FileUploads` physical directory.
  - `FileUpload` table records are created in SQL database for uploaded education and certification documents.
  - For certification document: `EntityId` = `Application.Id`, `EntityTypeId` = `CertificationId`.
  - For education document: `EntityId` = `Application.Id`, `EntityTypeId` = `EducationId`.
  - Application submission completes successfully and handles optional/mandatory file upload scenarios cleanly with Serilog logging.
  - Existing workflow steps, application approvals, and database operations function without error or breakage.
- **Wiring:**
  - Imports from: CertEasy.Model/FileUpload.cs, CertEasy.Data/CertEasyDbContext.cs, CertEasy.Services/IWorkflowService.cs, CertEasy.Web/Models/ApplicationViewModel.cs
  - Imported by: CertEasy.Web/Controllers/WorkflowController.cs
  - API routes: POST /Workflow/Apply or /Workflow/SubmitApplication
  - DB tables: Applications, FileUploads, Educations, Certifications
  - Env vars: None

---

## Machine-Readable Task Plan

```json
{
  "modules": [
    {
      "module": "FileUpload Infrastructure",
      "features": [
        {
          "feature": "Generic FileUpload Data & Storage Layer",
          "tasks": [
            {
              "id": "T-001",
              "name": "Implement FileUpload entity model, DbContext mapping, database migration, and storage directory initialization",
              "description": "Define the generic FileUpload domain model in CertEasy.Model/FileUpload.cs extending BaseEntity with generic properties FileName, FilePath, ContentType, FileSize, EntityId (long), and EntityTypeId (long). Register DbSet<FileUpload> FileUploads in CertEasy.Data/CertEasyDbContext.cs. Create and apply an EF Core migration (AddFileUploadsTable) to generate the FileUploads SQL table. Ensure physical FileUploads folder creation logic exists under application directory / web root (wwwroot/FileUploads).",
              "files_to_create": [
                "CertEasy.Model/FileUpload.cs",
                "CertEasy.Data/Migrations/[Timestamp]_AddFileUploadsTable.cs"
              ],
              "files_to_modify": [
                "CertEasy.Data/CertEasyDbContext.cs"
              ],
              "depends_on": [],
              "acceptance_criteria": [
                "FileUpload entity is created inheriting from BaseEntity with EntityId, EntityTypeId, FileName, FilePath, ContentType, and FileSize.",
                "CertEasyDbContext includes DbSet<FileUpload> FileUploads.",
                "EF Core Migration for FileUploads table is generated and builds cleanly.",
                "Storage path wwwroot/FileUploads (or application root directory FileUploads) is created automatically if it does not exist."
              ],
              "status": "pending",
              "wiring": {
                "imports_from": [
                  "CertEasy.Model/BaseEntity.cs"
                ],
                "imported_by": [
                  "CertEasy.Data/CertEasyDbContext.cs",
                  "CertEasy.Services/WorkflowService.cs"
                ],
                "api_routes": [],
                "db_tables": [
                  "FileUploads"
                ],
                "env_vars": []
              }
            }
          ]
        }
      ]
    },
    {
      "module": "Workflow Management",
      "features": [
        {
          "feature": "Application Document Upload & Wizard Integration",
          "tasks": [
            {
              "id": "T-002",
              "name": "Add document upload controls to Application Wizard Razor View and Knockout ViewModel",
              "description": "Update CertEasy.Web/Views/Workflow/Apply.cshtml to add file upload controls (<input type=\"file\">) under Certification step and Education & Remarks step. Update CertEasy.Web/wwwroot/js/workflow-wizard.js to add Knockout observables for file inputs, capture file selections, display file details/summaries in the Review step, and send application data as FormData (multipart/form-data) during AJAX submission. Update CertEasy.Web/Models/ApplicationViewModel.cs to handle uploaded files (IFormFile properties CertificationDocument and EducationDocument).",
              "files_to_create": [],
              "files_to_modify": [
                "CertEasy.Web/Views/Workflow/Apply.cshtml",
                "CertEasy.Web/wwwroot/js/workflow-wizard.js",
                "CertEasy.Web/Models/ApplicationViewModel.cs"
              ],
              "depends_on": [
                "T-001"
              ],
              "acceptance_criteria": [
                "Razor view Apply.cshtml renders file upload inputs in both Certification selection and Education & Remarks sections.",
                "Knockout ViewModel binds file selection events, retains selected files across wizard step transitions, and shows selected file names in the review step.",
                "Form submission posts data via FormData containing CertificationDocument and EducationDocument files alongside form fields.",
                "ApplicationViewModel properly receives file objects from multipart POST request."
              ],
              "status": "pending",
              "wiring": {
                "imports_from": [
                  "CertEasy.Web/wwwroot/js/workflow-wizard.js",
                  "CertEasy.Web/Models/ApplicationViewModel.cs"
                ],
                "imported_by": [
                  "CertEasy.Web/Views/Workflow/Apply.cshtml"
                ],
                "api_routes": [
                  "POST /Workflow/Apply",
                  "POST /Workflow/SubmitApplication"
                ],
                "db_tables": [],
                "env_vars": []
              }
            },
            {
              "id": "T-003",
              "name": "Implement server-side document persistence and FileUpload record generation in Workflow Service",
              "description": "Update WorkflowController and WorkflowService (IWorkflowService.cs, WorkflowService.cs) to process uploaded IFormFile inputs. Save uploaded certification and education files to the FileUploads directory with unique file names. Save FileUpload entity records to database table FileUploads setting EntityId = ApplicationId and EntityTypeId = CertificationId for certification documents, and EntityId = ApplicationId and EntityTypeId = EducationId for education documents. Maintain robust exception handling and Serilog logging to ensure existing application workflows and existing database functions are preserved.",
              "files_to_create": [],
              "files_to_modify": [
                "CertEasy.Services/IWorkflowService.cs",
                "CertEasy.Services/WorkflowService.cs",
                "CertEasy.Web/Controllers/WorkflowController.cs"
              ],
              "depends_on": [
                "T-001",
                "T-002"
              ],
              "acceptance_criteria": [
                "Uploaded files are securely written to the FileUploads physical directory.",
                "FileUpload table records are created in SQL database for uploaded education and certification documents.",
                "For certification document: EntityId = Application.Id, EntityTypeId = CertificationId.",
                "For education document: EntityId = Application.Id, EntityTypeId = EducationId.",
                "Application submission completes successfully and handles optional/mandatory file upload scenarios cleanly with Serilog logging.",
                "Existing workflow steps, application approvals, and database operations function without error or breakage."
              ],
              "status": "pending",
              "wiring": {
                "imports_from": [
                  "CertEasy.Model/FileUpload.cs",
                  "CertEasy.Data/CertEasyDbContext.cs",
                  "CertEasy.Services/IWorkflowService.cs",
                  "CertEasy.Web/Models/ApplicationViewModel.cs"
                ],
                "imported_by": [
                  "CertEasy.Web/Controllers/WorkflowController.cs"
                ],
                "api_routes": [
                  "POST /Workflow/Apply",
                  "POST /Workflow/SubmitApplication"
                ],
                "db_tables": [
                  "Applications",
                  "FileUploads",
                  "Educations",
                  "Certifications"
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
