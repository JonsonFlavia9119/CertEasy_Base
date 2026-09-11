# Planner-Coder Todo — 148
**Requirement:** Getting the below error while clicking on Approve button

The UPDATE statement conflicted with the FOREIGN KEY constraint "FK_Applications_Statuses_StatusID". The conflict occurred in database "CertEasyDb", table "dbo.Statuses", column 'Id'.'

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: Statuses, Applications DbSets and OnModelCreating configuration.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Data/CertEasyDbContext.cs: Add HasData seeding for Statuses (Ids 1 through 8) in OnModelCreating.
- CertEasy.Data/Migrations/20260911072740_SeedStatusesData.cs: Add migration to seed Statuses table in the database.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Seed Statuses master table data in DbContext and Migration | CertEasy.Data/CertEasyDbContext.cs, CertEasy.Data/Migrations/20260911072740_SeedStatusesData.cs | pending | — |
