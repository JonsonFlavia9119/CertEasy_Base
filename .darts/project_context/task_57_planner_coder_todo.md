# Planner-Coder Todo — 57
**Requirement:** There is already an object named 'Logs' in the database.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: Logs DbSet already mapped to 'AppLogs' table to avoid collision with Serilog.
- CertEasy.Web/Program.cs: Serilog configured to write to 'Logs' table in SQL Server.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Data/CertEasyDbContext.cs: Ensure the collision is handled by explicitly mapping the Log entity to a different table name (DONE).
- CertEasy.Web/Program.cs: Verify Serilog configuration (DONE).

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Verify and document Log table mapping | CertEasy.Data/CertEasyDbContext.cs, CertEasy.Web/Program.cs | pending | — |
