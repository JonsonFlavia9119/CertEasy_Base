# Planner-Coder Todo — 97
**Requirement:** Agent Summary
I have explicitly mapped the Education entity to the Educations table in both the CertEasyDbContext and the Education model class. This dual-layer mapping (Fluent API and Data Annotations) ensures that Entity Framework correctly resolves the table name in the SQL Server database, effectively fixing the "Invalid object name 'Educations'" error encountered in the admin area.

Changes Summary:
Backend Implementation
CertEasy.Data\CertEasyDbContext.cs: Verified and reinforced the mapping in OnModelCreating using modelBuilder.Entity<Education>().ToTable("Educations");. This ensures the database provider explicitly looks for the pluralized table name.
CertEasy.Model\Education.cs: Added/Verified the [Table("Educations")] attribute to the Education class to provide metadata-level mapping consistency.
These changes provide a production-ready solution that prevents the database engine from failing to locate the table due to naming convention mismatches between the model and the actual schema.

csharp
Copy
// CertEasy.Data\CertEasyDbContext.cs
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);
    // ...
    modelBuilder.Entity<Education>().ToTable("Educations");
    // ...
}

// CertEasy.Model\Education.cs
[Table("Educations")]
public class Education
{
    // ...
}

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: modelBuilder.Entity<Log>().ToTable("AppLogs"), modelBuilder.Entity<Application>().HasOne(a => a.User), modelBuilder.Entity<Role>().HasData, modelBuilder.Entity<Status>().HasData, modelBuilder.Entity<Certification>().HasData, modelBuilder.Entity<User>().HasData
- CertEasy.Web/Program.cs: builder.Services.AddControllersWithViews, builder.Services.AddDbContext, builder.Services.AddAuthentication, builder.Services.AddScoped

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Data/CertEasyDbContext.cs: Ensure `modelBuilder.Entity<Education>().ToTable("Educations");` is present.
- CertEasy.Model/Education.cs: Ensure `[Table("Educations")]` attribute is present.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Verify and reinforcement mapping of Education entity to Educations table | CertEasy.Data/CertEasyDbContext.cs, CertEasy.Model/Education.cs | pending | — |
