# Spec Context — Task 43
**Generated:** 2025-05-22  |  **Framework:** Empty Project  |  **Tasks:** 4

## Gap Analysis Summary
The project is a .NET 6 MVC application (Brownfield) with existing domain models and a DB context, but lacks authentication and registration functionality. The requirement is to implement a dual-authentication system: Identity (Email/Password) for standard users and Windows Integrated Security for Admins. Both user types will be managed in the existing `Users` table. The `User` model already supports this with a nullable `PasswordHash`. The task involves configuring multi-scheme authentication middleware, implementing password hashing utilities, and creating the registration/login vertical slices.

## Task Plan

### Module: Authentication

#### Feature: Dual-Authentication Infrastructure

**T-001: Configure Multi-Scheme Authentication and Password Hashing Service**
- **Description:** Install necessary NuGet packages and configure `Program.cs` to support both Cookie Authentication (for Identity users) and Negotiate Authentication (for Windows users). Register a password hashing utility using `IPasswordHasher<User>` to handle secure password storage.
- **Files to create:** `CertEasy.Services/Security/IPasswordService.cs`, `CertEasy.Services/Security/PasswordService.cs`
- **Files to modify:** `CertEasy.Web/CertEasy.Web.csproj`, `CertEasy.Web/Program.cs`, `CertEasy.Services/CertEasy.Services.csproj`
- **Depends on:** None
- **Acceptance criteria:**
  - `Microsoft.AspNetCore.Authentication.Negotiate` package is installed.
  - Authentication middleware is configured with both "Cookies" and "Negotiate" schemes.
  - `IPasswordService` is registered in DI and uses a cryptographically secure hashing algorithm (PBKDF2).
- **Wiring:**
  - Imports from: `CertEasy.Model`
  - Imported by: `AccountService`, `Program.cs`
  - API routes: None
  - DB tables: None
  - Env vars: None

#### Feature: User Registration

**T-002: Implement Standard User Registration — Service, Controller, and View**
- **Description:** Create the registration vertical slice for standard users. This includes the `AccountService` to handle DB persistence, an `AccountController` with Register actions, and the Registration view. Passwords must be hashed via `IPasswordService` before saving.
- **Files to create:** `CertEasy.Services/IAccountService.cs`, `CertEasy.Services/AccountService.cs`, `CertEasy.Web/Controllers/AccountController.cs`, `CertEasy.Web/Models/RegisterViewModel.cs`, `CertEasy.Web/Views/Account/Register.cshtml`
- **Files to modify:** `CertEasy.Web/Views/Shared/_Layout.cshtml`
- **Depends on:** T-001
- **Acceptance criteria:**
  - User can submit registration form with Email and Password.
  - User record is created in the `Users` table with RoleID 2 (User).
  - Password stored in `PasswordHash` is hashed and salted.
  - Basic validation (email format, password complexity) is implemented.
- **Wiring:**
  - Imports from: `CertEasy.Model`, `CertEasy.Services/Security`
  - Imported by: `CertEasy.Web/Program.cs` (for DI)
  - API routes: `GET /Account/Register`, `POST /Account/Register`
  - DB tables: `Users`
  - Env vars: None

#### Feature: Identity Authentication (Email/Password)

**T-003: Implement Standard Login — Login Logic and Session Management**
- **Description:** Implement the login functionality for standard users. The `AccountService` will verify the email and hash against the database. On success, a Cookie-based identity will be issued.
- **Files to create:** `CertEasy.Web/Models/LoginViewModel.cs`, `CertEasy.Web/Views/Account/Login.cshtml`
- **Files to modify:** `CertEasy.Services/IAccountService.cs`, `CertEasy.Services/AccountService.cs`, `CertEasy.Web/Controllers/AccountController.cs`
- **Depends on:** T-002
- **Acceptance criteria:**
  - User can log in with registered Email and Password.
  - System verifies hash using `IPasswordService`.
  - Authentication cookie is issued upon successful login.
  - `POST /Account/Logout` clears the session.
- **Wiring:**
  - Imports from: `CertEasy.Model`, `CertEasy.Services/Security`
  - Imported by: `AccountController`
  - API routes: `GET /Account/Login`, `POST /Account/Login`, `POST /Account/Logout`
  - DB tables: `Users`
  - Env vars: None

#### Feature: Admin Windows Authentication

**T-004: Implement Windows Authentication for Admins**
- **Description:** Implement logic in `AccountController` to handle Windows Authentication challenges. When an admin logs in via the Windows scheme, the system must map their `WindowsIdentity` name to an existing Admin record in the `Users` table (where `PasswordHash` is null).
- **Files to create:** None
- **Files to modify:** `CertEasy.Web/Controllers/AccountController.cs`, `CertEasy.Services/AccountService.cs`, `CertEasy.Services/IAccountService.cs`, `CertEasy.Web/Views/Account/Login.cshtml`
- **Depends on:** T-003
- **Acceptance criteria:**
  - "Login as Admin" button triggers a challenge to the "Negotiate" scheme.
  - Upon successful Windows Auth, the user's identity is checked against the `Users` table.
  - If a matching user with Admin role exists, an application session cookie is issued.
  - Serilog logs successful and failed admin login attempts.
- **Wiring:**
  - Imports from: `Microsoft.AspNetCore.Authentication`, `CertEasy.Model`
  - Imported by: None
  - API routes: `GET /Account/WindowsLogin`
  - DB tables: `Users`, `Roles`
  - Env vars: None

---

## Machine-Readable Task Plan

```json
{
  "modules": [
    {
      "module": "Authentication",
      "features": [
        {
          "feature": "Dual-Authentication Infrastructure",
          "tasks": [
            {
              "id": "T-001",
              "name": "Configure Multi-Scheme Authentication and Password Hashing Service",
              "description": "Install Negotiate package, configure Program.cs for Cookies and Windows auth, and implement PasswordService.",
              "files_to_create": [
                "CertEasy.Services/Security/IPasswordService.cs",
                "CertEasy.Services/Security/PasswordService.cs"
              ],
              "files_to_modify": [
                "CertEasy.Web/CertEasy.Web.csproj",
                "CertEasy.Web/Program.cs",
                "CertEasy.Services/CertEasy.Services.csproj"
              ],
              "depends_on": [],
              "acceptance_criteria": [
                "Negotiate auth package installed",
                "Program.cs configured for dual-auth",
                "PasswordService registered in DI"
              ],
              "status": "pending",
              "wiring": {
                "imports_from": ["CertEasy.Model"],
                "imported_by": ["AccountService", "Program.cs"],
                "api_routes": [],
                "db_tables": [],
                "env_vars": []
              }
            }
          ]
        },
        {
          "feature": "User Registration",
          "tasks": [
            {
              "id": "T-002",
              "name": "Implement Standard User Registration — Service, Controller, and View",
              "description": "Create AccountService, AccountController, and Register view to handle new user sign-ups with hashed passwords.",
              "files_to_create": [
                "CertEasy.Services/IAccountService.cs",
                "CertEasy.Services/AccountService.cs",
                "CertEasy.Web/Controllers/AccountController.cs",
                "CertEasy.Web/Models/RegisterViewModel.cs",
                "CertEasy.Web/Views/Account/Register.cshtml"
              ],
              "files_to_modify": [
                "CertEasy.Web/Views/Shared/_Layout.cshtml"
              ],
              "depends_on": ["T-001"],
              "acceptance_criteria": [
                "Registration form functional",
                "User record created in DB with RoleID 2",
                "Password stored as hash"
              ],
              "status": "pending",
              "wiring": {
                "imports_from": ["CertEasy.Model", "CertEasy.Services/Security"],
                "imported_by": ["CertEasy.Web/Program.cs"],
                "api_routes": ["GET /Account/Register", "POST /Account/Register"],
                "db_tables": ["Users"],
                "env_vars": []
              }
            }
          ]
        },
        {
          "feature": "Identity Authentication (Email/Password)",
          "tasks": [
            {
              "id": "T-003",
              "name": "Implement Standard Login — Login Logic and Session Management",
              "description": "Implement Login actions and views. Verify hashed passwords and issue auth cookies.",
              "files_to_create": [
                "CertEasy.Web/Models/LoginViewModel.cs",
                "CertEasy.Web/Views/Account/Login.cshtml"
              ],
              "files_to_modify": [
                "CertEasy.Services/IAccountService.cs",
                "CertEasy.Services/AccountService.cs",
                "CertEasy.Web/Controllers/AccountController.cs"
              ],
              "depends_on": ["T-002"],
              "acceptance_criteria": [
                "Login with valid credentials works",
                "Auth cookie issued",
                "Logout clears cookie"
              ],
              "status": "pending",
              "wiring": {
                "imports_from": ["CertEasy.Model", "CertEasy.Services/Security"],
                "imported_by": ["AccountController"],
                "api_routes": ["GET /Account/Login", "POST /Account/Login", "POST /Account/Logout"],
                "db_tables": ["Users"],
                "env_vars": []
              }
            }
          ]
        },
        {
          "feature": "Admin Windows Authentication",
          "tasks": [
            {
              "id": "T-004",
              "name": "Implement Windows Authentication for Admins",
              "description": "Add logic to AccountController to handle Windows Auth challenge and map Windows identity to DB Admin user.",
              "files_to_create": [],
              "files_to_modify": [
                "CertEasy.Web/Controllers/AccountController.cs",
                "CertEasy.Services/AccountService.cs",
                "CertEasy.Services/IAccountService.cs",
                "CertEasy.Web/Views/Account/Login.cshtml"
              ],
              "depends_on": ["T-003"],
              "acceptance_criteria": [
                "Windows challenge successful",
                "Windows user mapped to Admin in Users table",
                "App cookie issued for Windows user"
              ],
              "status": "pending",
              "wiring": {
                "imports_from": ["Microsoft.AspNetCore.Authentication", "CertEasy.Model"],
                "imported_by": [],
                "api_routes": ["GET /Account/WindowsLogin"],
                "db_tables": ["Users", "Roles"],
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