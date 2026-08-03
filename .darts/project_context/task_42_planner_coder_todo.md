# Planner-Coder Todo — 42
**Requirement:** Create the StatusHistoryChanges table to audit application workflow transitions. Capture both IDs and Names for old/new statuses to maintain a readable history.

Acceptance Criteria:
- Table 'StatusHistoryChanges' created with ID, EntityID, OldStatusID, OldStatusName, NewStatusID, NewStatusName, ChangedBy, ChangedDate, CreatedDate, CreatedBy.
- Logic triggers on application status change to insert history records.

Dependencies: Task Core Tables and Seeding

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\CertEasyDbContext.cs: DbSet<Role>, DbSet<Status>, DbSet<Address>, DbSet<User>

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\CertEasyDbContext.cs: add DbSet<StatusHistoryChange>

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend — Audit Model and DbContext updates | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\StatusHistoryChange.cs, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\CertEasyDbContext.cs | pending | — |
| T-002 | Logic — Audit Service for status changes | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Service\IAuditService.cs, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Service\AuditService.cs, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\Program.cs | pending | T-001 |
