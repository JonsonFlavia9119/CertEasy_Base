# Planner-Coder Todo — 53
**Requirement:** The DB creation error `System.InvalidOperationException: The seed entity for entity type 'User' cannot be added because no value was provided for the required property` was caused by seeding data in `CertEasyDbContext.cs` that didn't provide all required properties for certain entities (specifically, `CreatedDate` was required in `Certification` and `EducationLevel` models but missing in the seed data). I updated `CertEasyDbContext.cs` to include the `CreatedDate` property for the seeded `Certification` and `EducationLevel` entities, ensuring they match the schema requirements. ```csharp // CertEasy.Model\CertEasyDbContext.cs modelBuilder.Entity<Certification>().HasData( new Certification { Id = 1, Name = "Certified Safety Professional (CSP)", Description = "Leading safety certification", IsActive = true, CreatedDate = new DateTime(2023, 1, 1) }, new Certification { Id = 2, Name = "Associate Safety Professional (ASP)", Description = "Entry-level safety certification", IsActive = true, CreatedDate = new DateTime(2023, 1, 1) } ); modelBuilder.Entity<EducationLevel>().HasData( new EducationLevel { Id = 1, Name = "Bachelor's Degree", Description = "4-year undergraduate degree", IsActive = true, CreatedDate = new DateTime(2023, 1, 1) }, new EducationLevel { Id = 2, Name = "Master's Degree", Description = "Graduate degree", IsActive = true, CreatedDate = new DateTime(2023, 1, 1) }, new EducationLevel { Id = 3, Name = "Doctorate", Description = "Ph.D. or equivalent", IsActive = true, CreatedDate = new DateTime(2023, 1, 1) } ); ``` The `User` seed already had all required properties defined in the `User.cs` model provided. The wiring check also confirmed the system is correctly connected.

Analyze my project requirement again and fix if any issues because still the DB is not created. Remember, the DB is mandatory to run the application. Do not complete this task if DB creation failed.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Model\CertEasyDbContext.cs: Roles, Statuses, Certifications, EducationLevels, Users seeding.
- CertEasy.Web\Program.cs: DbContext registration, Database.Migrate() call.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Model\CertEasyDbContext.cs: Update Role seed to include CreatedBy.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Update DbContext Seed Data | CertEasy.Model\CertEasyDbContext.cs | pending | — |
