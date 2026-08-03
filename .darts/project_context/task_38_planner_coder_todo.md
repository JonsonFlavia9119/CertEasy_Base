# Planner-Coder Todo — 38
**Requirement:** Initialize the multi-project solution structure for CertEasy. Project CertEasy.Model will contain migrations and entities. Project CertEasy.Services will handle the logic. Project CertEasy.Web will host the Razor views and Controllers.

Acceptance Criteria:
- Solution folder named 'CertEasy' created.
- Projects CertEasy.Model (Class Library), CertEasy.Services (Class Library), and CertEasy.Web (ASP.NET Core MVC) initialized.
- References established between projects (Web -> Services -> Model).

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- None (Empty Project)

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.sln: include CertEasy.Model.csproj, CertEasy.Services.csproj, CertEasy.Web.csproj
- CertEasy.Web.csproj: add reference to CertEasy.Services.csproj
- CertEasy.Services.csproj: add reference to CertEasy.Model.csproj

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Create Solution and Projects | CertEasy.sln, CertEasy.Model/CertEasy.Model.csproj, CertEasy.Services/CertEasy.Services.csproj, CertEasy.Web/CertEasy.Web.csproj | pending | — |
| T-002 | Initialize Model and Services Layers | CertEasy.Model/BaseEntity.cs, CertEasy.Model/CertEasyDbContext.cs, CertEasy.Services/IBaseService.cs, CertEasy.Services/BaseService.cs | pending | T-001 |
| T-003 | Initialize Web Layer (MVC Entry Points) | CertEasy.Web/Program.cs, CertEasy.Web/appsettings.json, CertEasy.Web/Controllers/HomeController.cs, CertEasy.Web/Views/Home/Index.cshtml, CertEasy.Web/Views/_ViewStart.cshtml, CertEasy.Web/Views/Shared/_Layout.cshtml | pending | T-002 |
