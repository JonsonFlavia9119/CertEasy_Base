# Planner-Coder Todo — 103
**Requirement:** # Fix EF Core Database.Migrate() Error

The application fails during startup when executing `dbContext.Database.Migrate();` with the error: "There is no entity type mapped to the table 'Accounts' which is used in a data operation. Either add the corresponding entity type to the model, or specify the column types in the data operation."

This error typically occurs when `HasData` is used for an entity that EF Core doesn't recognize as part of the model during the migration's execution context. In this case, the `AddAccountEntity.Designer.cs` file is missing the `BuildTargetModel` method which describes the model to EF Core for that specific migration.

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: Accounts DbSet and configuration already present.
- CertEasy.Web/Program.cs: Database.Migrate() called in scope.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Data/Migrations/20260821044635_AddAccountEntity.Designer.cs: Implement BuildTargetModel with Account entity and seed data.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Fix Migration Designer File | CertEasy.Data/Migrations/20260821044635_AddAccountEntity.Designer.cs | pending | — |
| T-002 | Verify and Report | (No files to write, only verification) | pending | T-001 |
