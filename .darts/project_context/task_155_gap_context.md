# Gap Context — As an admin user, I would like to assign badges to the approved applications.

Follow,

* Place a new link to the approved applications
* A new page should get open when the link is clicked
* Once admin uses assigns badge to the application then it will be moved to completed application's grid

Check

* Ensure the existing logic should not get affected
* Assign badge only enabled for approved applications

**Date:** 2026-09-16  |  **Task ID:** 155  |  **Type:** Brownfield

## Project Overview

### Tech Stack
- .NET 8.0 / ASP.NET Core MVC
- Entity Framework Core 8.0 (SQL Server)
- Serilog for structured logging and exception handling
- Bootstrap 5, Razor Views, jQuery, Knockout.js for frontend UI
- Repository Pattern / Service Layer Architecture with Dependency Injection

### Existing Modules & Features
- **Admin Controller** (`CertEasy.Web/Controllers/AdminController.cs`): Manages admin dashboard, application approvals, rejections, email configurations, and entity administration.
- **Admin Service** (`CertEasy.Services/AdminService.cs`): Service implementation handling core admin workflows including retrieving applications, approving/rejecting applications, and managing certifications, addresses, education, exams, and email configurations.
- **Application Model** (`CertEasy.Model/Application.cs`): Domain entity representing certification applications, containing fields for status, user, certification, exam, education, and badge properties (`BadgeId`, `BadgeName`, `BadgeAssignedDate`).
- **Status Model & Enums** (`CertEasy.Model/Status.cs`): Defines status entity and `ApplicationStatus` enum values (`Approved = 7`, `Completed = 200`, etc.).
- **Admin Dashboard View** (`CertEasy.Web/Views/Admin/Index.cshtml`): Multi-tab dashboard rendering pending applications, completed applications grid, and system entities.
- **Admin View Models** (`CertEasy.Web/Models/AdminViewModels.cs`): Defines ViewModels for the admin dashboard and configuration screens.

### Prior Context
In previous tasks (such as Task 126), application wizard workflow steps and entity configurations were established. The database context and `Application` entity were recently updated with badge fields (`BadgeId`, `BadgeName`, `BadgeAssignedDate`) via Entity Framework Core migration (`20260916081328_AddBadgeFieldsToApplication.cs`), creating the necessary data model foundation for badge assignment functionality.

## Requirements Analysis

### Extracted Requirements
1. **Approved Application Badge Link:** Add a new link/action button specifically for approved applications on the Admin Dashboard applications table to navigate to the badge assignment page.
2. **Dedicated Assign Badge Page:** Create a dedicated view/page for assigning badges to an approved application, displaying application details and input fields for badge information.
3. **Badge Assignment & Completed Grid Migration:** Implement backend logic to save badge details (`BadgeName`, `BadgeId`, `BadgeAssignedDate`), update application status to Completed (`StatusID = 200`), and automatically move the application to the Completed Applications grid.
4. **Enforce Status Restriction:** Restrict badge assignment strictly to applications in Approved status (`StatusID == 7` / `112`), disabling or hiding links for other statuses and validating status in the service layer.
5. **Preserve Existing Functionality:** Ensure existing application workflows, approval/rejection logic, and dashboard tabs operate without disruption or regression.

### Requirements Mapping
| Requirement | Status | Location in Codebase | Notes |
|---|---|---|---|
| Approved Application Badge Link | Needs Modification | `CertEasy.Web/Views/Admin/Index.cshtml` | Add "Assign Badge" link/button in the actions column, enabled only when application status is Approved. |
| Dedicated Assign Badge Page | Needs Modification | `CertEasy.Web/Controllers/AdminController.cs`, `CertEasy.Web/Models/AdminViewModels.cs` | Add `AssignBadge` GET action and `AssignBadgeViewModel` to serve the new page. |
| Badge Assignment & Completed Grid Migration | Needs Modification | `CertEasy.Services/IAdminService.cs`, `CertEasy.Services/AdminService.cs`, `CertEasy.Web/Controllers/AdminController.cs` | Implement `AssignBadgeAsync` service method to record badge details and update status to `Completed` (200). |
| Enforce Status Restriction | Needs Modification | `CertEasy.Services/AdminService.cs`, `CertEasy.Web/Controllers/AdminController.cs` | Validate application status is Approved before allowing badge assignment or loading the page. |
| Preserve Existing Functionality | Already Exists | `CertEasy.Web/Controllers/AdminController.cs`, `CertEasy.Services/AdminService.cs` | Maintain current approval, rejection, and navigation logic without altering non-badge workflows. |

## Tech Stack & Implementation

### Approved Application Link & Assign Badge Page UI — Needs Modification
- **Approach:** Update the Admin Dashboard applications grid (`Index.cshtml`) to include an "Assign Badge" link for applications with Approved status (`StatusID == 7` or `112`). Add a GET action method `AssignBadge(int id)` in `AdminController.cs` that validates the application existence and status, returning a view model populated with application details. Add an `AssignBadgeViewModel` in `AdminViewModels.cs` to handle form binding and validation rules.
- **Existing files to modify:** `CertEasy.Web/Views/Admin/Index.cshtml`, `CertEasy.Web/Controllers/AdminController.cs`, `CertEasy.Web/Models/AdminViewModels.cs`
- **New dependencies:** None

### Badge Assignment Service Logic & Application State Transition — Needs Modification
- **Approach:** Add `AssignBadgeAsync(int id, string badgeName, string badgeId, string adminUser)` to `IAdminService` and implement it in `AdminService.cs`. The service method verifies that the application exists and is in `Approved` status (`StatusID == 7` or `112`). It populates `BadgeName`, `BadgeId` (generating a default format if empty), sets `BadgeAssignedDate` to `DateTime.UtcNow`, transitions `StatusID` to `Completed` (`200`), updates audit fields (`UpdatedBy`, `UpdatedDate`), and saves changes to the database. Add a POST action `AssignBadge` in `AdminController.cs` that calls this service and redirects to the Admin Dashboard upon success.
- **Existing files to modify:** `CertEasy.Services/IAdminService.cs`, `CertEasy.Services/AdminService.cs`, `CertEasy.Web/Controllers/AdminController.cs`
- **New dependencies:** None

## Summary
The project is a Brownfield ASP.NET Core MVC application with clean multi-layer separation (Model, Data, Services, Web). Recent database updates have already added the necessary domain properties (`BadgeId`, `BadgeName`, `BadgeAssignedDate`) to the `Application` entity.

This task requires completing the badge assignment feature by placing a new "Assign Badge" link on approved applications in the Admin Dashboard, introducing a dedicated GET/POST route and view for assigning badges, and enforcing state transitions to move assigned applications to status `Completed` (200), which automatically displays them in the Completed Applications grid.

The implementation is purely additive and modificative across existing service interfaces, admin controllers, view models, and Razor templates. Existing application approval, rejection, and dashboard logic will remain completely unaffected, and robust server-side status validation will ensure badge assignment is strictly restricted to approved applications.
