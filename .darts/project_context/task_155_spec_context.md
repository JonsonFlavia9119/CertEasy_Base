# Spec Context — Task 155
**Generated:** 2026-09-16  |  **Framework:** Empty Project  |  **Tasks:** 1

## Gap Analysis Summary
The project is a Brownfield ASP.NET Core MVC application requiring an admin workflow to assign badges to approved certification applications. The database context and Application model already contain the required badge fields (BadgeId, BadgeName, BadgeAssignedDate). This implementation adds an "Assign Badge" link on the Admin Dashboard for approved applications, creates a dedicated GET/POST route and view for badge assignment, and updates the service layer to save badge details and transition application status to Completed (200), automatically moving assigned applications to the Completed Applications grid.

## Task Plan

### Module: AdminManagement

#### Feature: BadgeAssignment

**T-001: Implement badge assignment workflow for approved applications — view model, service layer, controller actions, dedicated Razor view, and dashboard UI link**
- **Description:** Implement end-to-end badge assignment functionality for approved applications. Add AssignBadgeViewModel to AdminViewModels.cs, extend IAdminService and AdminService with GetApplicationByIdAsync and AssignBadgeAsync methods, implement GET and POST AssignBadge actions in AdminController with strict status verification (StatusID == 7 or StatusID == 112), create dedicated AssignBadge.cshtml Razor view with Bootstrap 5 form styling, and update Admin/Index.cshtml to render the "Assign Badge" link for approved applications.
- **Files to create:** CertEasy.Web/Views/Admin/AssignBadge.cshtml
- **Files to modify:** CertEasy.Web/Models/AdminViewModels.cs, CertEasy.Services/IAdminService.cs, CertEasy.Services/AdminService.cs, CertEasy.Web/Controllers/AdminController.cs, CertEasy.Web/Views/Admin/Index.cshtml
- **Depends on:** None
- **Acceptance criteria:**
  - "Assign Badge" link is displayed on the Admin Dashboard applications grid exclusively for applications with Approved status (StatusID == 7 or StatusID == 112).
  - Clicking "Assign Badge" navigates to /Admin/AssignBadge/{id}, opening a dedicated page displaying application summary details and badge entry fields.
  - Server-side validation restricts GET and POST AssignBadge actions to applications in Approved status, redirecting with an error message if an unapproved application is specified.
  - Submitting valid badge details updates BadgeName, BadgeId (auto-generating BDG-{id:D5} if blank), BadgeAssignedDate (DateTime.UtcNow), and updates StatusID to Completed (200).
  - Upon successful assignment, the application is moved to the Completed Applications tab, displaying the assigned badge badge name, badge ID, and assignment date.
  - Existing application approval and rejection workflows remain fully operational and unaffected.
- **Wiring:**
  - Imports from: CertEasy.Model.Application, CertEasy.Model.Status, CertEasy.Data.CertEasyDbContext, CertEasy.Services.IAdminService
  - Imported by: CertEasy.Web/Controllers/AdminController.cs, CertEasy.Web/Views/Admin/Index.cshtml, CertEasy.Web/Views/Admin/AssignBadge.cshtml
  - API routes: GET /Admin/AssignBadge/{id}, POST /Admin/AssignBadge
  - DB tables: Applications
  - Env vars: None

---

## Machine-Readable Task Plan

```json
{
  "modules": [
    {
      "module": "AdminManagement",
      "features": [
        {
          "feature": "BadgeAssignment",
          "tasks": [
            {
              "id": "T-001",
              "name": "Implement badge assignment workflow for approved applications — view model, service layer, controller actions, dedicated Razor view, and dashboard UI link",
              "description": "Implement end-to-end badge assignment functionality for approved applications. Add AssignBadgeViewModel to AdminViewModels.cs, extend IAdminService and AdminService with GetApplicationByIdAsync and AssignBadgeAsync methods, implement GET and POST AssignBadge actions in AdminController with strict status verification (StatusID == 7 or StatusID == 112), create dedicated AssignBadge.cshtml Razor view with Bootstrap 5 form styling, and update Admin/Index.cshtml to render the 'Assign Badge' link for approved applications.",
              "files_to_create": [
                "CertEasy.Web/Views/Admin/AssignBadge.cshtml"
              ],
              "files_to_modify": [
                "CertEasy.Web/Models/AdminViewModels.cs",
                "CertEasy.Services/IAdminService.cs",
                "CertEasy.Services/AdminService.cs",
                "CertEasy.Web/Controllers/AdminController.cs",
                "CertEasy.Web/Views/Admin/Index.cshtml"
              ],
              "depends_on": [],
              "acceptance_criteria": [
                "Assign Badge link is displayed on the Admin Dashboard applications grid exclusively for applications with Approved status (StatusID == 7 or StatusID == 112).",
                "Clicking Assign Badge navigates to /Admin/AssignBadge/{id}, opening a dedicated page displaying application summary details and badge entry fields.",
                "Server-side validation restricts GET and POST AssignBadge actions to applications in Approved status, redirecting with an error message if an unapproved application is specified.",
                "Submitting valid badge details updates BadgeName, BadgeId (auto-generating BDG-{id:D5} if blank), BadgeAssignedDate (DateTime.UtcNow), and updates StatusID to Completed (200).",
                "Upon successful assignment, the application is moved to the Completed Applications tab, displaying the assigned badge badge name, badge ID, and assignment date.",
                "Existing application approval and rejection workflows remain fully operational and unaffected."
              ],
              "status": "pending",
              "wiring": {
                "imports_from": [
                  "CertEasy.Model.Application",
                  "CertEasy.Model.Status",
                  "CertEasy.Data.CertEasyDbContext",
                  "CertEasy.Services.IAdminService"
                ],
                "imported_by": [
                  "CertEasy.Web/Controllers/AdminController.cs",
                  "CertEasy.Web/Views/Admin/Index.cshtml",
                  "CertEasy.Web/Views/Admin/AssignBadge.cshtml"
                ],
                "api_routes": [
                  "GET /Admin/AssignBadge/{id}",
                  "POST /Admin/AssignBadge"
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