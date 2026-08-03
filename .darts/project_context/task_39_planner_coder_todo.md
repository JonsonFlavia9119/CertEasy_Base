# Planner-Coder Todo — 39
**Requirement:** Implement the Roles and Statuses tables as defined in the schema. Seed the Roles table with 'Admin' and 'User'. Seed Statuses with: New (101), User Profile (102), Certification Selection (103), Educational Qualification (104), Invoice (110), Review (111), Approved (112), Rejection (113).

Acceptance Criteria:
- Table 'Roles' created with ID, RoleName, Description, CreatedDate.
- Table 'Statuses' created with ID, StatusName, CreatedDate, CreatedBy.
- Initial data for Roles (Admin, User) and Statuses (101-113 range) seeded.

Dependencies: Task Project Structure Setup

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Model\CertEasyDbContext.cs: DbContext base class

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Model\CertEasyDbContext.cs: add DbSet<Role> Roles, DbSet<Status> Statuses, and seed data in OnModelCreating

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend — Create Role and Status models and update DbContext with seeding | CertEasy.Model/Role.cs, CertEasy.Model/Status.cs, CertEasy.Model/CertEasyDbContext.cs | pending | — |
