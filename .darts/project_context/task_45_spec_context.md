# Spec Context — Task 45
**Generated:** 2025-05-24  |  **Framework:** .NET 6.0 (ASP.NET Core MVC)  |  **Tasks:** 4

## Gap Analysis Summary
The project is a brownfield .NET 6.0 MVC application with a functional user registration and application submission workflow. The goal of Task 45 is to implement the administrative side of the application. This includes an Admin Dashboard for reviewing user submissions (Status 111: Review), enabling approval (Status 112) or rejection (Status 113), and creating management interfaces for master data configuration (Address, Certification, and Education). The system uses Entity Framework Core with SQL Server and Serilog for logging. The implementation will require extending the data model, adding a new administrative service, and creating an authorized admin area in the web project.

## Task Plan

### Module: Admin

#### Feature: Application Review Management

**T-001: Implement Admin Dashboard and Review Workflow — Model, Service, and UI**
- **Description:** Create the administrative interface to manage user applications. This includes adding an `IAdminService` to fetch applications in 'Review' status, updating `WorkflowService` if necessary to handle admin-specific transitions, and creating the `AdminController` with views to list, approve, and reject submissions. Access will be restricted to the "Admin" role.
- **Files to create:** `CertEasy.Services/IAdminService.cs`, `CertEasy.Services/AdminService.cs`, `CertEasy.Web/Controllers/AdminController.cs`, `CertEasy.Web/Views/Admin/Index.cshtml`, `CertEasy.Web/Models/AdminViewModels.cs`
- **Files to modify:** `CertEasy.Web/Views/Shared/_Layout.cshtml`
- **Depends on:** None
- **Acceptance criteria:**
  - `AdminController` actions are protected with `[Authorize(Roles = "Admin")]`.
  - Admin Dashboard (`/Admin/Index`) lists all users with `StatusID = 111`.
  - Clicking "Approve" updates user status to 112 (Approved) and logs the action via Serilog.
  - Clicking "Reject" updates user status to 113 (Rejection) and logs the action via Serilog.
  - Dashboard UI is responsive and uses the existing layout.
- **Wiring:**
  - Imports from: `CertEasy.Model`, `CertEasy.Services`
  - Imported by: `CertEasy.Web/Program.cs` (Service Registration)
  - API routes: `GET /Admin`, `POST /Admin/Approve/{id}`, `POST /Admin/Reject/{id}`
  - DB tables: `Users`, `Statuses`
  - Env vars: None

#### Feature: Master Data Management

**T-002: Implement Certification and Education Metadata — Schema and Entities**
- **Description:** Extend the database schema to include metadata for Certifications and Education levels. Currently, these exist only as conceptual requirements. This task involves creating the entity classes, updating `CertEasyDbContext`, and adding initial seed data for common certifications and degrees.
- **Files to create:** `CertEasy.Model/Certification.cs`, `CertEasy.Model/EducationLevel.cs`
- **Files to modify:** `CertEasy.Model/CertEasyDbContext.cs`, `CertEasy.Model/User.cs`
- **Depends on:** None
- **Acceptance criteria:**
  - `Certification` and `EducationLevel` entities are created with standard fields (Id, Name, Description, IsActive).
  - `CertEasyDbContext` includes `DbSet` for both.
  - EF Migration is generated and applied (or seeding is verified via context).
  - `User` entity is updated with nullable foreign keys to these new tables if required for future reporting.
- **Wiring:**
  - Imports from: `CertEasy.Model`
  - Imported by: `CertEasy.Services/AdminService.cs`
  - API routes: None
  - DB tables: `Certifications`, `EducationLevels`
  - Env vars: None

**T-003: Implement Master Data Configuration Views — Service and UI**
- **Description:** Provide the UI for admins to manage (CRUD) the system parameters for Addresses (States/Countries), Certifications, and Education levels. This will build upon the entities created in T-002.
- **Files to create:** `CertEasy.Web/Views/Admin/Settings.cshtml`, `CertEasy.Web/Views/Admin/ManageCertifications.cshtml`, `CertEasy.Web/Views/Admin/ManageEducation.cshtml`
- **Files to modify:** `CertEasy.Services/IAdminService.cs`, `CertEasy.Services/AdminService.cs`, `CertEasy.Web/Controllers/AdminController.cs`
- **Depends on:** T-001, T-002
- **Acceptance criteria:**
  - Admin can view a list of available Certifications and Education levels.
  - Admin can add new entries or toggle the `IsActive` status of existing ones.
  - Forms include server-side validation.
  - Audit logs are generated for changes to master data.
- **Wiring:**
  - Imports from: `CertEasy.Model`, `CertEasy.Services`
  - Imported by: `CertEasy.Web/Controllers/AdminController.cs`
  - API routes: `GET /Admin/Settings`, `POST /Admin/AddCertification`, `POST /Admin/AddEducation`
  - DB tables: `Certifications`, `EducationLevels`, `Addresses`
  - Env vars: None

**T-004: Enhance Global Logging and Error Handling**
- **Description:** Ensure Serilog is correctly configured in `Program.cs` to capture all administrative actions and exceptions. Implement a global exception filter or middleware if missing to provide a clean UX for admin errors.
- **Files to create:** `CertEasy.Web/Filters/AdminExceptionFilter.cs`
- **Files to modify:** `CertEasy.Web/Program.cs`, `CertEasy.Web/appsettings.json`
- **Depends on:** T-001
- **Acceptance criteria:**
  - Serilog is configured to write to a file sink (e.g., `logs/admin-audit.txt`).
  - All "Approve/Reject" actions in `AdminService` are logged with the acting Admin's identity.
  - Unhandled exceptions in the Admin area redirect to a friendly error page.
- **Wiring:**
  - Imports from: `Serilog`
  - Imported by: `CertEasy.Web/Program.cs`
  - API routes: None
  - DB tables: None
  - Env vars: None

---

## Machine-Readable Task Plan

```json
{
  "modules": [
    {
      "module": "Admin",
      "features": [
        {
          "feature": "Application Review Management",
          "tasks": [
            {
              "id": "T-001",
              "name": "Implement Admin Dashboard and Review Workflow",
              "description": "Create IAdminService, AdminController, and Dashboard views to list applications in Review status and perform Approve/Reject actions.",
              "files_to_create": [
                "CertEasy.Services/IAdminService.cs",
                "CertEasy.Services/AdminService.cs",
                "CertEasy.Web/Controllers/AdminController.cs",
                "CertEasy.Web/Views/Admin/Index.cshtml",
                "CertEasy.Web/Models/AdminViewModels.cs"
              ],
              "files_to_modify": [
                "CertEasy.Web/Views/Shared/_Layout.cshtml"
              ],
              "depends_on": [],
              "acceptance_criteria": [
                "AdminController actions are protected with [Authorize(Roles = 'Admin')].",
                "Dashboard lists users with StatusID 111.",
                "Approve/Reject actions update status to 112/113.",
                "Actions are logged via Serilog."
              ],
              "status": "pending",
              "wiring": {
                "imports_from": ["CertEasy.Model", "CertEasy.Services"],
                "imported_by": ["CertEasy.Web/Program.cs"],
                "api_routes": ["GET /Admin", "POST /Admin/Approve/{id}", "POST /Admin/Reject/{id}"],
                "db_tables": ["Users", "Statuses"],
                "env_vars": []
              }
            }
          ]
        },
        {
          "feature": "Master Data Management",
          "tasks": [
            {
              "id": "T-002",
              "name": "Implement Certification and Education Metadata Schema",
              "description": "Create entity classes and update DbContext for Certification and Education metadata including seed data.",
              "files_to_create": [
                "CertEasy.Model/Certification.cs",
                "CertEasy.Model/EducationLevel.cs"
              ],
              "files_to_modify": [
                "CertEasy.Model/CertEasyDbContext.cs",
                "CertEasy.Model/User.cs"
              ],
              "depends_on": [],
              "acceptance_criteria": [
                "Certification and EducationLevel entities exist.",
                "DbContext includes corresponding DbSets.",
                "Seed data is present in OnModelCreating."
              ],
              "status": "pending",
              "wiring": {
                "imports_from": ["CertEasy.Model"],
                "imported_by": ["CertEasy.Services/AdminService.cs"],
                "api_routes": [],
                "db_tables": ["Certifications", "EducationLevels"],
                "env_vars": []
              }
            },
            {
              "id": "T-003",
              "name": "Implement Master Data Configuration Views",
              "description": "Create UI and Service methods for Admin to manage system parameters (Address, Cert, Edu).",
              "files_to_create": [
                "CertEasy.Web/Views/Admin/Settings.cshtml",
                "CertEasy.Web/Views/Admin/ManageCertifications.cshtml",
                "CertEasy.Web/Views/Admin/ManageEducation.cshtml"
              ],
              "files_to_modify": [
                "CertEasy.Services/IAdminService.cs",
                "CertEasy.Services/AdminService.cs",
                "CertEasy.Web/Controllers/AdminController.cs"
              ],
              "depends_on": ["T-001", "T-002"],
              "acceptance_criteria": [
                "Admin can CRUD Certifications and Education levels.",
                "Forms include validation.",
                "Changes are audit-logged."
              ],
              "status": "pending",
              "wiring": {
                "imports_from": ["CertEasy.Model", "CertEasy.Services"],
                "imported_by": ["CertEasy.Web/Controllers/AdminController.cs"],
                "api_routes": ["GET /Admin/Settings", "POST /Admin/AddCertification", "POST /Admin/AddEducation"],
                "db_tables": ["Certifications", "EducationLevels", "Addresses"],
                "env_vars": []
              }
            },
            {
              "id": "T-004",
              "name": "Enhance Global Logging and Error Handling",
              "description": "Configure Serilog file sinks and implement global exception handling for the admin area.",
              "files_to_create": [
                "CertEasy.Web/Filters/AdminExceptionFilter.cs"
              ],
              "files_to_modify": [
                "CertEasy.Web/Program.cs",
                "CertEasy.Web/appsettings.json"
              ],
              "depends_on": ["T-001"],
              "acceptance_criteria": [
                "Serilog writes to file sink.",
                "Admin audit logs include identity.",
                "Friendly error pages for admin exceptions."
              ],
              "status": "pending",
              "wiring": {
                "imports_from": ["Serilog"],
                "imported_by": ["CertEasy.Web/Program.cs"],
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