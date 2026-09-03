# Planner-Coder Todo — 132
**Requirement:** # Fix EF Core Database.Migrate() Error

The application fails during startup when executing `dbContext.Database.Migrate();` with the error: "There is no entity type mapped to the table 'Exams' which is used in a data operation. Either add the corresponding entity type to the model, or specify the column types in the data operation."

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_ApplicationProcess_Phase2\CertEasy.Data\CertEasyDbContext.cs: Role, Status, Address, Certification, User, Log, Application, Education, Account, Exam DbSets and OnModelCreating configurations.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_ApplicationProcess_Phase2\CertEasy.Web\Program.cs: Database initialization with Migrate().

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_ApplicationProcess_Phase2\CertEasy.Data\CertEasyDbContext.cs: Ensure `Exam` mapping matches `Exams` table and is consistent with migrations.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Fix EF Core Migration Error | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_ApplicationProcess_Phase2\CertEasy.Data\CertEasyDbContext.cs, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_ApplicationProcess_Phase2\CertEasy.Data\Migrations\20260902070615_AddExamsTable.Designer.cs, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_ApplicationProcess_Phase2\CertEasy.Data\Migrations\CertEasyDbContextModelSnapshot.cs | pending | — |
