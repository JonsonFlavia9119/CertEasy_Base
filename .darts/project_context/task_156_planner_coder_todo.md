# Planner-Coder Todo — 156
**Requirement:** Getting exception while clicking "Assign Badge & Complete Application"

* Assign badge throwing error "The UPDATE statement conflicted with the FOREIGN KEY constraint "FK_Applications_Statuses_StatusID". The conflict occurred in database "CertEasyDb", table "dbo.Statuses", column 'Id'."
* Fix this issue, if needed, you can add/edit migration
* Do unit testing and ensure badge assign is working fine
* Ensure existing functionality is not breaking

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: Statuses DbSet, OnModelCreating Status HasData (1..8)
- CertEasy.Tests/ServiceTests.cs: GetDbContext, Database_SeedData_ShouldBeLoadedCorrectlly, Database_Connection_IsWorking

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Data/CertEasyDbContext.cs: Add Status Id = 200 ("Completed") in OnModelCreating HasData
- CertEasy.Data/Migrations/20260917090000_AddCompletedStatus.cs: Add migration inserting Status Id 200 ("Completed") into Statuses table
- CertEasy.Data/Migrations/20260917090000_AddCompletedStatus.Designer.cs: Migration designer file
- CertEasy.Data/Migrations/CertEasyDbContextModelSnapshot.cs: Update model snapshot with Status Id 200
- CertEasy.Tests/ServiceTests.cs: Add unit tests for AssignBadgeAsync and verifying Status 200

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Seed Completed status (Id 200) in DbContext & Migrations | CertEasy.Data/CertEasyDbContext.cs, CertEasy.Data/Migrations/20260917090000_AddCompletedStatus.cs, CertEasy.Data/Migrations/20260917090000_AddCompletedStatus.Designer.cs, CertEasy.Data/Migrations/CertEasyDbContextModelSnapshot.cs | pending | — |
| T-002 | Add unit testing for AssignBadgeAsync and status verification | CertEasy.Tests/ServiceTests.cs | pending | T-001 |
