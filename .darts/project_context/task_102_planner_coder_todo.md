# Planner-Coder Todo — 102
**Requirement:** There is no entity type mapped to the table 'Accounts' which is used in a data operation. Either add the corresponding entity type to the model, or specify the column types in the data operation.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase2\CertEasy.Data\CertEasyDbContext.cs: DbSet<Account> Accounts already exists, OnModelCreating has modelBuilder.Entity<Account>().ToTable("Accounts")
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase2\CertEasy.Model\Account.cs: Account class already exists
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase2\CertEasy.Web\Program.cs: builder.Services.AddScoped<IAccountService, AccountService>() already exists

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- None: Investigation shows all required entities and wiring are already present.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Verify Backend Entities | CertEasy.Data/CertEasyDbContext.cs, CertEasy.Model/Account.cs | pending | — |
| T-002 | Verify Entry points | CertEasy.Web/Program.cs | pending | T-001 |
