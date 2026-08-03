# Gap Context — Implement a dual-authentication system. Standard Users authenticate via email/password (Identity), while Admin users are authenticated via Windows Integrated Security. Use the Users table to manage roles and identities for both.

Acceptance Criteria:
- User can register with Email and Password using Identity.
- Passwords are hashed and salted before storage.
- Admins can log in via Windows Authentication.

Dependencies: Task User and Address Data Models
**Date:** 2024-05-22  |  **Task ID:** 43  |  **Type:** Brownfield

## Project Overview

### Tech Stack
- .NET 6.0 (ASP.NET Core MVC)
- Entity Framework Core
- SQL Server (via `CertEasyDbContext`)
- Serilog (configured in `Program.cs`)

### Existing Modules & Features
- **CertEasy.Model** (`CertEasy.Model/`): Contains the core domain entities including `User`, `Role`, `Address`, and `Status`.
- **CertEasyDbContext** (`CertEasy.Model/CertEasyDbContext.cs`): EF Core context with initial seeding for Roles and a system Admin user.
- **CertEasy.Services** (`CertEasy.Services/`): Contains base service abstractions.
- **CertEasy.Web** (`CertEasy.Web/`): ASP.NET Core MVC project with basic layout and Serilog integration.

### Prior Context
No prior analysis found for this project.

## Requirements Analysis

### Extracted Requirements
1. **Dual-Authentication Support**: The system must handle both Email/Password (Standard Users) and Windows Authentication (Admin Users).
2. **Standard User Registration**: Users must be able to sign up with Email and Password.
3. **Password Security**: Passwords must be hashed and salted before storage in the `Users` table.
4. **Admin Windows Authentication**: Admins must be able to authenticate using Windows Integrated Security.
5. **Unified Identity Management**: Both types of users must be managed via the existing `Users` table, linked to the `Roles` table.
6. **Authentication State Management**: Implicitly requires the setup of Authentication and Authorization middleware to handle different schemes.

### Requirements Mapping
| Requirement | Status | Location in Codebase | Notes |
|---|---|---|---|
| User Registration (Email/Password) | New Development | — | Requires new Controller/Service logic. |
| Password Hashing & Salting | New Development | — | No hashing utility currently exists. |
| Admin Windows Authentication | Needs Modification | `Program.cs`, `CertEasy.Web.csproj` | Requires enabling Windows Auth in IIS/Kestrel and middleware config. |
| Unified User Table Management | Already Exists | `CertEasy.Model/User.cs` | `User` entity already has `PasswordHash` (nullable) and `RoleID`. |
| Role Management | Already Exists | `CertEasy.Model/CertEasyDbContext.cs` | Roles (Admin/User) are already seeded. |

## Tech Stack & Implementation

### Dual-Authentication Configuration — Needs Modification
- **Approach:** Configure the application to support multiple authentication schemes (Cookies for Identity and Negotiate/Kerberos for Windows Auth). Update the Auth middleware to challenge the correct scheme based on the user's role or access path.
- **Existing files to modify:** `CertEasy.Web/Program.cs`, `CertEasy.Web/appsettings.json`
- **New dependencies:** `Microsoft.AspNetCore.Authentication.Negotiate`

### Identity Registration & Password Hashing — New Development
- **Approach:** Implement a registration workflow that captures user details, hashes the password using a cryptographically secure algorithm (e.g., PBKDF2 via ASP.NET Core Identity's `IPasswordHasher`), and persists the record to the `Users` table.
- **Existing files to modify:** None (Requires new Controllers/Services/Views)
- **New dependencies:** `Microsoft.AspNetCore.Identity.EntityFrameworkCore` (optional, for standard Identity integration) or manual implementation using `Microsoft.AspNetCore.Cryptography.KeyDerivation`.

### Windows Authentication Integration — Needs Modification
- **Approach:** Enable Windows Authentication in the web server settings. In the login logic, identify if the incoming request is authenticated via the Windows scheme and map the `WindowsPrincipal` identity to the corresponding record in the `Users` table.
- **Existing files to modify:** `CertEasy.Web/Program.cs`
- **New dependencies:** None (Standard in .NET 6 Web SDK)

## Summary
The project is currently a foundational Brownfield environment. It has the core data structures defined (User, Role, Address) but lacks any functional authentication or authorization logic. The `User` model is already prepared for this dual-approach, featuring a nullable `PasswordHash` field specifically designed to accommodate Windows-authenticated Admins who won't have a stored password.

The task requires setting up a multi-scheme authentication system. This is additive in nature, building upon the existing Entity Framework models to provide a secure registration process for standard users and a seamless Windows login for admins. The implementation will follow the Repository pattern and Clean Architecture principles already established in the solution structure.