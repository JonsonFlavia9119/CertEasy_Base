# Planner-Coder Todo — 52
**Requirement:** DB Creation Issue - System.InvalidOperationException: The seed entity for entity type 'User' cannot be added because no value was provided for the required property.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\CertEasyDbContext.cs: Seeding Roles, Statuses, Certifications, EducationLevels, User.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\CertEasyDbContext.cs: Provide missing properties (Username/CreatedDate/etc if they exist in DB but not in User.cs, or fix existing seed data mismatch). Actually, User.cs doesn't inherit from BaseEntity. I will check User.cs again and update CertEasyDbContext.cs seed data for User.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Fix DB Seed Error | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\CertEasyDbContext.cs | pending | — |
