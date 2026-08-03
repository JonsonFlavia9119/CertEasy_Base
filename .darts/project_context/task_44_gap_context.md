# Gap Context — Develop the user-facing application workflow. This includes the Profile step (102), Certification selection (103), Education details (104), and Invoice submission (110). Use KnockoutJS for two-way binding and dynamic validation.

Acceptance Criteria:
- Multi-step wizard UI implemented using Razor and KnockoutJS.
- Validation prevents moving to next step if fields are empty.
- Workflow statuses (101-110) updated correctly at each step.

Dependencies: Task Certification and Education Models, Task Dual Authentication System
**Date:** 2025-02-14  |  **Task ID:** 44  |  **Type:** Brownfield

## Project Overview

### Tech Stack
- .NET 6.0 (ASP.NET Core MVC)
- Entity Framework Core
- Razor Pages / Views
- KnockoutJS (Requested for this task)
- Serilog (Used for logging)

### Existing Modules & Features
- **CertEasy.Model** (`CertEasy.Model/`): Contains core entities including `User`, `Role`, `Address`, and `Status`. `CertEasyDbContext` includes seed data for workflow statuses (101-113).
- **CertEasy.Services** (`CertEasy.Services/`): Contains `AccountService` and `PasswordService` for authentication logic.
- **CertEasy.Web** (`CertEasy.Web/`): Contains `AccountController` and `HomeController` with basic Razor views for Login and Registration.

### Prior Context
No prior analysis found for this project in `.darts/project_context/`.

## Requirements Analysis

### Extracted Requirements
1. **Multi-step Wizard UI**: A wizard-style interface using Razor for the structure and KnockoutJS for client-side state management and navigation.
2. **Profile Step (102)**: Collect/update user profile information.
3. **Certification Selection (103)**: Interface for users to select certifications.
4. **Education Details (104)**: Interface for users to provide educational background (referenced as "[REDACTED] details" in user requirement but clarified by context).
5. **Invoice Submission (110)**: Final step for invoice handling before submission.
6. **Two-way Binding & Dynamic Validation**: Use KnockoutJS to bind UI elements to a view model and enforce field-level validation before proceeding to the next step.
7. **Workflow Status Updates**: Update the user's status in the database to match the current step (101-110).
8. **Dual Authentication Integration**: Ensure the workflow respects the dual-auth system (Windows Auth for Admins, Forms Auth for Users).

### Requirements Mapping
| Requirement | Status | Location in Codebase | Notes |
|---|---|---|---|
| Multi-step Wizard UI | New Development | `CertEasy.Web/Views/` | Requires new Razor view and KnockoutJS script. |
| Profile Step (102) | Needs Modification | `CertEasy.Web/Controllers/AccountController.cs` | Logic to save profile data and update status to 102. |
| Certification Selection (103) | New Development | `CertEasy.Model/`, `CertEasy.Services/` | Depends on "Certification Models" (Task dependency). |
| Education Details (104) | New Development | `CertEasy.Model/`, `CertEasy.Services/` | Depends on "Education Models" (Task dependency). |
| Invoice Submission (110) | New Development | `CertEasy.Web/Controllers/` | New controller action/service for invoice handling. |
| KnockoutJS Binding | New Development | `CertEasy.Web/wwwroot/js/` | ViewModels for the wizard state. |
| Status Updates (101-110) | Needs Modification | `CertEasy.Model/CertEasyDbContext.cs` | Status codes 101-110 are already seeded in the DB. |

## Tech Stack & Implementation

### Multi-step Wizard UI — New Development
- **Approach:** Implement a single-page wizard interface within a Razor View. Use KnockoutJS `observables` to track the current step and `visible` bindings to toggle step visibility. The wizard will communicate with the backend via AJAX to save progress and fetch model data.
- **Existing files to modify:** `CertEasy.Web/Views/Shared/_Layout.cshtml` (to include KnockoutJS CDN/local script).
- **New dependencies:** KnockoutJS (lib), Seri logger (for backend error tracking).

### Workflow Status Updates — Needs Modification
- **Approach:** Extend the `AccountService` or a new `WorkflowService` to handle status transitions. The system must update the `User` or a related `Application` entity's status field using the seeded `Status` IDs (102, 103, 104, 110).
- **Existing files to modify:** `CertEasy.Services/IAccountService.cs`, `CertEasy.Services/AccountService.cs`, `CertEasy.Model/User.cs`.
- **New dependencies:** None.

### Validation & Binding — New Development
- **Approach:** Use KnockoutJS validation plugins or custom computed observables to verify that all required fields for the current step are populated before allowing the "Next" transition. Implement client-side validation that mirrors server-side models.
- **Existing files to modify:** `CertEasy.Web/Views/Shared/_ValidationScriptsPartial.cshtml`.
- **New dependencies:** knockout.validation (optional but recommended).

## Summary
The project is a Brownfield ASP.NET Core MVC application with a solid foundational architecture (Clean Architecture/Repository Pattern). The current codebase already defines the necessary workflow statuses (101-110) in the database seed logic, but the user-facing implementation is entirely missing.

This task asks for the creation of a sophisticated multi-step wizard. The implementation will be primarily additive, requiring a new KnockoutJS-driven frontend layer integrated into Razor views. It will bridge the gap between the existing Authentication system and the soon-to-be-implemented Certification/Education models. The primary challenge will be ensuring the two-way binding correctly handles complex validation across multiple wizard steps while maintaining the correct workflow status in the backend. Status updates must be persisted at each step to allow users to resume their progress.
