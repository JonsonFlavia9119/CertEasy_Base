# Planner-Coder Todo — 40
**Requirement:** Create the Addresses and Users tables. Ensure foreign key relationships for RoleID and AddressID. The Users table must support both ASP.NET Identity for standard users and Windows Authentication for Admins.

Acceptance Criteria:
- Table 'Addresses' created with fields: ID, Line1, Line2, City, State, Pincode, Country, Phone, CreatedDate, CreatedBy.
- Table 'Users' created with fields: ID, FirstName, LastName, Email, PasswordHash, RoleID, AddressID.
- System Admin user seeded with Windows Authentication support (null password).

Dependencies: Task Core Tables and Seeding

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\CertEasyDbContext.cs: Roles, Statuses DbSets; Role and Status seeding.
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\Program.cs: DbContext and Serilog registration.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\CertEasyDbContext.cs: add DbSet<Address> Addresses, DbSet<User> Users; add seeding for Admin user.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend — Models and DbContext | CertEasy.Model/Address.cs, CertEasy.Model/User.cs, CertEasy.Model/CertEasyDbContext.cs | pending | — |
