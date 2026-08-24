# Planner-Coder Todo — 92
**Requirement:** I have 2 requirements,

1. I would like to add a new page called EducationQualification in admin dashboard

The table should be like this fields 
CREATE TABLE Education (
    ID INT PRIMARY KEY IDENTITY,
    EntityID INT NOT NULL, -- ApplicationID/AccountID 
    EntityTypeID INT NOT NULL, -- ApplicationID(200)/AccountID(201)
    InstituteName NVARCHAR(100),
    Qualification NVARCHAR(100),
    DegreeName NVARCHAR(100),
    CreatedDate DATETIME DEFAULT GETDATE(),
    CreatedBy INT FOREIGN KEY REFERENCES Users(ID)
);

2. I would like to edit Certification table and add the below two fields 

EntityID INT NOT NULL, -- ApplicationID/AccountID 
EntityTypeID INT NOT NULL, -- ApplicationID(200)/AccountID(201)

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: DbSet<Role>, DbSet<Status>, DbSet<Address>, DbSet<Certification>, DbSet<User>, DbSet<Log>, DbSet<Application>, DbSet<Education>
- CertEasy.Web/Program.cs: builder.Services.AddScoped<IAdminService, AdminService>
- CertEasy.Web/Controllers/AdminController.cs: Index, ManageCertifications, ManageAddresses, ManageEducation
- CertEasy.Web/Views/Shared/_AdminLayout.cshtml: Navigation links for Certifications, Addresses, Education Quals

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Data/CertEasyDbContext.cs: Ensure Education and Certification fields are mapped (already partially there but will ensure full sync with requirement)
- CertEasy.Web/Controllers/AdminController.cs: Ensure full CRUD for Education and updated Certification fields
- CertEasy.Web/Views/Admin/ManageEducation.cshtml: UI for listing education
- CertEasy.Web/Views/Admin/CreateEducation.cshtml: Form for adding education
- CertEasy.Web/Views/Admin/EditEducation.cshtml: Form for editing education

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend — Update Models, DbContext, and AdminService | CertEasy.Model/Certification.cs, CertEasy.Model/Education.cs, CertEasy.Data/CertEasyDbContext.cs, CertEasy.Services/IAdminService.cs, CertEasy.Services/AdminService.cs | pending | — |
| T-002 | Frontend — Admin Controller and Views for Education | CertEasy.Web/Controllers/AdminController.cs, CertEasy.Web/Views/Admin/ManageEducation.cshtml, CertEasy.Web/Views/Admin/CreateEducation.cshtml, CertEasy.Web/Views/Admin/EditEducation.cshtml, CertEasy.Web/Views/Admin/CreateCertification.cshtml, CertEasy.Web/Views/Admin/EditCertification.cshtml | pending | T-001 |
