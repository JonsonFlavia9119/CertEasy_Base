# Planner-Coder Todo — 64
**Requirement:** Define the data models and execute migrations for the three core administrative entities: Address, Education, and Certification. This includes all specified audit fields (CreatedDate, UpdatedDate, CreatedBy, UpdatedBy).

Acceptance Criteria:
- Database migrations are created for Address, Education, and Certification tables.
- Address table includes: Line1, Line2, City, State, ZipCode, Country, CreatedDate, UpdatedDate, CreatedBy, UpdatedBy.
- Education table includes: Name, Description, CreatedDate, UpdatedDate, CreatedBy, UpdatedBy.
- Certification table includes: Name, Description, CreatedDate, UpdatedDate, CreatedBy, UpdatedBy.

Technical Hints: Use Entity Framework Core migrations. Ensure audit fields have appropriate data types (DateTime for dates, string for users).

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data\CertEasyDbContext.cs: Roles, Statuses, Addresses, Certifications, EducationLevels, Users, Logs, Applications, SeedData (Role, Status, Certification, EducationLevel, User)
- CertEasy.Model\Address.cs: Line1, Line2, City, State, Pincode, Country, Phone, Users (Navigation)

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Model\Address.cs: Rename Pincode to ZipCode, remove Phone
- CertEasy.Model\Education.cs: New class with Name, Description
- CertEasy.Data\CertEasyDbContext.cs: add DbSet<Education> Educations

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend — ALL models + ALL controllers + DbContext updates | CertEasy.Model\Address.cs, CertEasy.Model\Education.cs, CertEasy.Model\Certification.cs, CertEasy.Data\CertEasyDbContext.cs | pending | — |
