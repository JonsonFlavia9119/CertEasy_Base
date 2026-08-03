# Planner-Coder Todo — 56
**Requirement:** Introducing FOREIGN KEY constraint 'FK_Applications_Users_UserID' on table 'Applications' may cause cycles or multiple cascade paths. Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints.
Could not create constraint or index. See previous errors.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Data\CertEasyDbContext.cs: already contains modelBuilder.Entity<Application>().OnDelete(DeleteBehavior.NoAction)

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Data\Migrations\20240101000000_InitialCreate.cs: update ReferentialAction.Cascade to ReferentialAction.NoAction for FK_Applications_Users_UserID

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Update Initial Migration | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Data\Migrations\20240101000000_InitialCreate.cs | pending | — |
