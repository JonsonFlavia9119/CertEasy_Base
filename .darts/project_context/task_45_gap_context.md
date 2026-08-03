# Gap Context — Create the Admin interface for application management. Admins must be able to review, approve, and reject submissions. Additionally, provide management views to configure Address, Certification, and Education parameters.

Acceptance Criteria:
- Admin dashboard lists all submitted applications.
- Admin can Approve (112) or Reject (113) an application.
- Admin can configure Address, Certification, and Education settings.

Dependencies: Task Application Submission Workflow
**Date:** 2025-05-24 | **Task ID:** 45 | **Type:** Brownfield

## Project Overview

### Tech Stack
- **Framework:** .NET 6.0 (ASP.NET Core MVC)
- **Database:** Entity Framework Core with SQL Server
- **Logging:** Serilog
- **Authentication:** Cookie-based Authentication with Windows Auth support (Negotiate)
- **Architecture:** Multi-project solution (Web, Services, Model) using Repository-like pattern via BaseService and specific service interfaces.

### Existing Modules & Features
- **CertEasy.Model** (`CertEasy.Model/`): Contains entities (`User`, `Role`, `Status`, `Address`) and `CertEasyDbContext` with initial seeding for Admin role and workflow statuses (101-113).
- **CertEasy.Services** (`CertEasy.Services/`): Contains `AccountService`, `WorkflowService`, and `PasswordService`. `WorkflowService` handles status updates.
- **CertEasy.Web** (`CertEasy.Web/`): Contains `AccountController` for auth, `WorkflowController` for the user application process, and corresponding views.

### Prior Context
No prior analysis found for this project. This is a continuation of the application submission workflow (Phase 1).

## Requirements Analysis

### Extracted Requirements
1. **Admin Dashboard:** A view for admins to see a list of all applications submitted for review (Status 111).
2. **Review Actions:** Ability to Approve (transition to Status 112) or Reject (transition to Status 113) a specific application.
3. **Master Data Configuration:** CRUD/Management views for Address-related parameters, Certifications, and Education parameters.
4. **Access Control:** Implicit requirement that these views are restricted to users with the "Admin" role (RoleId 1).
5. **Logging:** Explicit requirement to use Serilog for exception handling and audit trails of approvals/rejections.

### Requirements Mapping
| Requirement | Status | Location in Codebase | Notes |
|---|---|---|---|
| Admin Dashboard Listing | New Development | `CertEasy.Web/Controllers`, `CertEasy.Web/Views` | List users/applications in "Review" status. |
| Approve/Reject Actions | Needs Modification | `CertEasy.Services/IWorkflowService.cs` | Logic exists in `UpdateUserStatusAsync` but needs specific admin triggers. |
| Address Management | Needs Modification | `CertEasy.Model/Address.cs` | Entity exists; need UI/Service to manage parameters (e.g. valid States/Countries). |
| Certification Management | New Development | `CertEasy.Model/` | Entity for "Certification" metadata is missing in the current schema. |
| Education Management | New Development | `CertEasy.Model/` | Entity for "Education" parameters (e.g. Degree types) is missing. |
| Admin Authorization | Needs Modification | `CertEasy.Web/Controllers` | Ensure `[Authorize(Roles = "Admin")]` is applied. |

## Tech Stack & Implementation

### Admin Application Management — New Development
- **Approach:** Create an `AdminController` with an `Index` action that queries the database for users in the `Review` (111) status. Implement `Approve` and `Reject` actions that call `IWorkflowService.UpdateUserStatusAsync`.
- **Existing files to modify:** `CertEasy.Services/IWorkflowService.cs`, `CertEasy.Services/WorkflowService.cs`
- **New dependencies:** None

### Master Data Configuration (Address, Certification, Education) — New Development
- **Approach:** Extend `CertEasyDbContext` with new entities for `Certification` and `Education` parameters. Implement generic or specific CRUD views within the Admin area. Use the Repository pattern via a new or existing service to manage these lookups.
- **Existing files to modify:** `CertEasy.Model/CertEasyDbContext.cs`, `CertEasy.Model/Address.cs`
- **New dependencies:** None

### Logging & Validation — Needs Modification
- **Approach:** Inject `ILogger` (Serilog) into the new Admin services/controllers. Implement `FluentValidation` or DataAnnotations for the configuration forms.
- **Existing files to modify:** `CertEasy.Web/Program.cs` (to ensure Serilog is fully configured for file sinks if needed)
- **New dependencies:** `Serilog.Sinks.File` (optional but recommended for persistent audit logs)

## Summary
The project is currently a functional brownfield application with a basic user workflow and authentication system in place. The core data structures for Users, Roles, and Statuses are established, and the `WorkflowService` already possesses the capability to transition user statuses.

This task asks for the "Admin" side of the application. It involves creating a management interface to process user submissions and a configuration suite for the system's lookup data (Addresses, Certifications, and Education). While the workflow logic exists, the Admin UI and the specific metadata entities for Certifications and Education are currently absent. The implementation will be largely additive, building on top of the existing Service/Controller pattern while enforcing role-based access control.