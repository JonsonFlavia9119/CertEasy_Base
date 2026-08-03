# Planner-Coder Todo — 55
**Requirement:** Could not load file or assembly 'CertEasy.Data, Culture=neutral, PublicKeyToken=null'. The system cannot find the file specified. Fix this issue and verify the DB created or not

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Web\CertEasy.Web.csproj: References CertEasy.Data, CertEasy.Model, CertEasy.Services
- CertEasy.Web\Program.cs: Configures CertEasyDbContext with MigrationsAssembly("CertEasy.Data")

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Data\CertEasyDbContext.cs: Move DbContext from CertEasy.Model to CertEasy.Data to align with Migrations assembly and fix assembly loading issues.
- CertEasy.Model\CertEasyDbContext.cs: Delete this file after moving it to CertEasy.Data.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Fix Assembly/Namespace Mismatch & Move DbContext | CertEasy.Data\CertEasyDbContext.cs, CertEasy.Model\CertEasyDbContext.cs | pending | — |
| T-002 | Verify Database Initialization & Logging | CertEasy.Web\Program.cs | pending | T-001 |
