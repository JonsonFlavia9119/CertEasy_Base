# Planner-Coder Todo — 54
**Requirement:** The seed entity for entity type 'Role' cannot be added because no value was provided for the required property 'UpdatedBy'.

As I already said, do complete analysis on my requirements and fix the seed entity for all tables and fields. Do not repeat this type of error during DB creation. DO UNIT TESTING AND MAKE SURE SQL CONNECTION IS WORKING

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Model\CertEasyDbContext.cs: Roles, Statuses, Addresses, Certifications, EducationLevels, Users, Logs, Applications registered
- CertEasy.Web\Program.cs: DbContext, Services (IAccountService, IAdminService, IPasswordService, IWorkflowService) registered, Serilog configured

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Model\BaseEntity.cs: standardize properties (CreatedDate, CreatedBy, UpdatedDate, UpdatedBy)
- CertEasy.Model\*.cs: Inherit from BaseEntity and remove duplicate properties
- CertEasy.Model\CertEasyDbContext.cs: Update HasData for all entities to match new BaseEntity properties

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Standardize Models and BaseEntity | CertEasy.Model\BaseEntity.cs, CertEasy.Model\Role.cs, CertEasy.Model\Status.cs, CertEasy.Model\Address.cs, CertEasy.Model\Certification.cs, CertEasy.Model\EducationLevel.cs, CertEasy.Model\User.cs, CertEasy.Model\Application.cs | pending | — |
| T-002 | Fix Seed Data in DbContext | CertEasy.Model\CertEasyDbContext.cs | pending | T-001 |
| T-003 | Unit Testing SQL Connection | CertEasy.Tests\DatabaseTests.cs | pending | T-002 |
