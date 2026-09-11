# Planner-Coder Todo — 144
**Requirement:** Issue;

Getting the "Invalid column name 'ApiKey'.\r\nInvalid column name 'ProviderName'." 
while executing "var config = await _context.EmailConfigurations.FirstOrDefaultAsync();" 

Observations;

I have observed there is no field exists in EmailConfiguration table in SQL

Check;

* Ensure the EmailConfiguration entity is correctly synced with EmailConfigurations table in SQL DB
* Add a migration if needed
* Ensure an admin user can save EmailConfiguration
* Ensure the Test Email should be working fine

Desired output;

* EmailConfiguration page should be working
* Test Email functionality should send a test email
* Write a production ready code without any issues

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: DbSet<EmailConfiguration> EmailConfigurations registered, EmailConfiguration mapping in OnModelCreating.
- CertEasy.Web/Program.cs: DbContext migration applied on startup, AdminService/EmailService registered.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Data/Migrations/[Timestamp]_FixEmailConfigurationColumns.cs: add migration to ensure ApiKey and ProviderName columns exist in the database.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend — Database Migration | CertEasy.Data/Migrations/[Timestamp]_FixEmailConfigurationColumns.cs | pending | — |
| T-002 | Logic Verification — Ensure robust implementation | CertEasy.Services/AdminService.cs, CertEasy.Web/Controllers/AdminController.cs | pending | T-001 |
