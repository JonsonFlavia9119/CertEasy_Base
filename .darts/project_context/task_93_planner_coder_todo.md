# Planner-Coder Todo — 93
**Requirement:** There is a mismatch between EF and SQL table. The migration code for `Education` table shows specific columns (`ID`, `EntityID`, `EntityTypeID`, `InstituteName`, `Qualification`, `DegreeName`, `CreatedDate`, `CreatedBy`), while the actual SQL table has a different structure (`Id`, `Name`, `Description`, `IsActive`, `CreatedDate`, `UpdatedDate`, `CreatedBy`, `UpdatedBy`, `InstituteName`). 

The requirement is to ensure the EF Model and Migration match the intended structure of the `Education` table as described in the migration snippet provided in the prompt (which seems to be the target structure), but reconciled with the "but the SQL table looks like this" observation which suggests a mix-up with maybe `Certification` or a different entity. 

Actually, the prompt says "the SQL table looks like this", listing columns that look like a mix of `BaseEntity` and `Education`. 
Target columns for `Education` (from migration snippet):
- ID (int, Identity)
- EntityID (int)
- EntityTypeID (int)
- InstituteName (nvarchar 100)
- Qualification (nvarchar 100)
- DegreeName (nvarchar 100)
- CreatedDate (datetime2)
- CreatedBy (int)

The observed SQL table has: `Id`, `Name`, `Description`, `IsActive`, `CreatedDate`, `UpdatedDate`, `CreatedBy`, `UpdatedBy`, `InstituteName`.

This mismatch indicates that the `Education` model might have been incorrectly defined or the migration was generated from a state where it inherited from a base class that it shouldn't have, or vice versa.

I will align the `Education` model and `Certification` model to match the project's `BaseEntity` pattern where appropriate, but strictly following the column requirements for `Education`.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: DbSet<Education> Educations, DbSet<Certification> Certifications registered.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Model/Education.cs: Align fields with requirement.
- CertEasy.Data/Migrations/20260818081632_AddEducationAndEditCertification.cs: Correct the migration definition to ensure it matches the Model.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Align Models and Re-generate Migration logic | CertEasy.Model/Education.cs, CertEasy.Data/Migrations/20260818081632_AddEducationAndEditCertification.cs | pending | — |
| T-002 | Update AdminController to handle corrected Model | CertEasy.Web/Controllers/AdminController.cs | pending | T-001 |
