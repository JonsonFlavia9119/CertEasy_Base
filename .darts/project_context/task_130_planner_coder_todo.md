# Planner-Coder Todo — 130
**Requirement:** "There is no entity type mapped to the table 'Exams' which is used in a data operation. Either add the corresponding entity type to the model, or specify the column types in the data operation."}

I have checked there is no migration have been added for exams, could you verify the code snipped and create a migration if needed probably new table(exam) , foreign key (examId) reference in applications table  . As a user I need this exam entity should be available in admin area as well as application process. Provide me a production ready code.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: DbSet<Exam>, modelBuilder.Entity<Exam>().ToTable("Exams"), Application relationship with Exam.
- CertEasy.Web/Controllers/AdminController.cs: Admin management actions for Exams (ManageExams, CreateExam, EditExam, DeleteExam).
- CertEasy.Web/Controllers/WorkflowController.cs: API for wizard to get exams (GetInitialData) and SubmitApplication.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Data/Migrations/20260902070615_AddExamsTable.cs: Add migration for Exams table and Application foreign key.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Database Migration | CertEasy.Data/Migrations/20260902070615_AddExamsTable.cs, CertEasy.Data/Migrations/CertEasyDbContextModelSnapshot.cs | pending | — |
| T-002 | UI and Wiring Verification | CertEasy.Web/Views/Admin/ManageExams.cshtml, CertEasy.Web/Views/Admin/CreateExam.cshtml, CertEasy.Web/Views/Admin/EditExam.cshtml | pending | T-001 |
