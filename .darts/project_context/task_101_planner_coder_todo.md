# Planner-Coder Todo — 101
**Requirement:** Title: Add Account entity and assign EntityId/EntityTypeId to Certification and Education

Use the project's existing EF Core, entity, relationship, service, DTO, and migration patterns.

Requirements:

1. Account
- Create a new Account table/entity with:
  Id
  UserName
  Email
  UserId
  Status
  CreatedOn
  UpdatedOn
  CreatedBy
  UpdatedBy
- Establish a one-to-one relationship: User -> Account.
- Each User must have exactly one Account. Do not allow duplicate Accounts for the same User.
- When a new User is created, automatically create the corresponding Account using the existing User creation workflow.
- Add the required EF Core migration.
- Follow the project's existing conventions for keys, data types, nullability, indexes, timestamps, and relationships.

2. Certification and Education
- When created from the Admin area:
  EntityId = AccountId
  EntityTypeId = 201
- When created from the Application process:
  EntityId = ApplicationId
  EntityTypeId = 200
- Do not implement Application-process changes if that workflow does not currently exist; prepare the model/database structure without changing unrelated functionality.
- Preserve existing data and behavior.

3. Code changes
- Update DTOs/view models/services only where required by the existing architecture.
- Reuse existing patterns; do not introduce a new architectural pattern.
- Do not make unrelated changes.

4. Validation
- Build the solution.
- Validate EF Core relationships and migration.
- Verify that existing User, Certification, and Education functionality is not broken.
- Check that duplicate Accounts cannot be created for the same User.

Output:
- List all files changed.
- Provide migration name(s).
- Briefly explain the User -> Account relationship.
- Briefly explain how EntityId/EntityTypeId are assigned.
- Report any assumptions or issues found.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: DbSet<Account>, User-Account relationship, seeded data
- CertEasy.Services/AccountService.cs: CreateAccountForUserAsync calls during registration/auth
- CertEasy.Services/AdminService.cs: GetAccountIdForUserAsync and assignment of EntityID/EntityTypeID

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Web/Controllers/WorkflowController.cs: assign EntityID and EntityTypeID when creating Application/related records (if applicable in SubmitApplication)

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Verify existing implementation and fix gaps | CertEasy.Model/Account.cs, CertEasy.Model/Certification.cs, CertEasy.Model/Education.cs, CertEasy.Data/CertEasyDbContext.cs, CertEasy.Services/AccountService.cs, CertEasy.Services/AdminService.cs, CertEasy.Web/Controllers/WorkflowController.cs | pending | — |
