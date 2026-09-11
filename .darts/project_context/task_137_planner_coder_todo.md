# Planner-Coder Todo — 137
**Requirement:** Fix "Invalid column name 'EntityID'.\r\nInvalid column name 'EntityTypeID'." error during GetAllApplicationsAsync and ensure email config works.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Web/Program.cs: Serilog MSSQL sink configuration with additional columns.
- CertEasy.Data/CertEasyDbContext.cs: DbContext with model configurations.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Web/Program.cs: No changes needed to wiring, configuration is already there.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Fix Invalid Column Names Error | CertEasy.Web/Program.cs | pending | — |
| T-002 | Verify Email Configuration and AdminService | CertEasy.Services/AdminService.cs, CertEasy.Services/NotificationService.cs | pending | T-001 |
