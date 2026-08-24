# Planner-Coder Todo — 96
**Requirement:** Agent Summary
The issue was caused by a mismatch between the entity configuration in the CertEasyDbContext and the actual table name in the database. The Education entity was previously commented out for explicit table mapping, leading to potential inconsistency or failure if the database expected 'Educations' specifically. I have explicitly mapped the Education entity to the Educations table in the OnModelCreating method to ensure it correctly resolves.

Changes Made:
Backend Implementation
CertEasy.Data\CertEasyDbContext.cs:
Explicitly mapped the Education entity to the Educations table using modelBuilder.Entity<Education>().ToTable("Educations");. This ensures that Entity Framework looks for the correct table name in the SQL Server database, resolving the "Invalid object name 'Educations'" error.
No changes were required in the AdminController or frontend views as they were already correctly referencing the service and model; the root cause was the database mapping.

This issue still exists. I could see the An unexpected error occurred in the administrative area. Invalid object name 'Educations'. in the Education Quals page in admin area. Please do the needed changes and fix this issue as like production ready solution.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: DbSet<Education> Educations, modelBuilder.Entity<Education>().ToTable("Educations")
- CertEasy.Model/Education.cs: [Table("Educations")]

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Data/CertEasyDbContext.cs: ensure ToTable("Educations") is correctly placed and NOT commented out.
- CertEasy.Model/Education.cs: ensure [Table("Educations")] attribute is present.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Fix Table Mapping Inconsistency | CertEasy.Data/CertEasyDbContext.cs, CertEasy.Model/Education.cs | pending | — |
