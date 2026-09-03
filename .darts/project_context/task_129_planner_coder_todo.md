# Planner-Coder Todo — 129
**Requirement:** Fix "Invalid column name 'ExamID'" and "Invalid object name 'Exams'" errors in Admin and Workflow areas.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: DbSet<Exam>, modelBuilder.Entity<Exam>().ToTable("Exams"), Application-Exam relationship.
- CertEasy.Services/AdminService.cs: GetAllExamsAsync, AddExamAsync, etc.
- CertEasy.Web/Controllers/AdminController.cs: Index calls _adminService.GetAllExamsAsync().

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Data/CertEasyDbContext.cs: Ensure Exam table mapping is correct and ExamID column is properly mapped in Application entity.
- CertEasy.Web/Views/Admin/Index.cshtml: Add "Exams" tab to display the data fetched by the controller.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend Fixes — Ensure DB context and migrations align | CertEasy.Data/CertEasyDbContext.cs | pending | — |
| T-002 | Frontend UI Update — Add missing Exams tab to Admin Dashboard | CertEasy.Web/Views/Admin/Index.cshtml | pending | T-001 |
