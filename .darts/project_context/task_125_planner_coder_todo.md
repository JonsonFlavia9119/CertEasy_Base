# Planner-Coder Todo — 125
**Requirement:** Develop a management interface within the admin area to allow administrators to configure available exams. This includes a grid view and a form with fields: exam_name, exam_center, and exam_slot.

Acceptance Criteria:
- Admin user can navigate to the Exam Configuration page
- Admin can create, read, update, and delete exam records
- Form includes fields for Name, Center, and Slot (Date/Time)

Dependencies: Task Database Schema Update for Exams

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: DbSet<Exam> Exams, Exam seed data
- CertEasy.Web/Controllers/AdminController.cs: Admin dashboard, Master data management (Certifications, Addresses, Educations)
- CertEasy.Web/Views/Shared/_AdminLayout.cshtml: Sidebar navigation with links to Certifications, Addresses, Education Quals
- CertEasy.Web/Models/AdminViewModels.cs: AdminDashboardViewModel

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Services/IAdminService.cs: add Exam management methods (GetAllExams, GetExamById, AddExam, UpdateExam, DeleteExam)
- CertEasy.Services/AdminService.cs: implement Exam management methods
- CertEasy.Web/Controllers/AdminController.cs: add ManageExams, CreateExam, EditExam, DeleteExam actions
- CertEasy.Web/Models/AdminViewModels.cs: add Exams to AdminDashboardViewModel
- CertEasy.Web/Views/Shared/_AdminLayout.cshtml: add "Exams" link to sidebar

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend — Service & Controller updates | CertEasy.Services/IAdminService.cs, CertEasy.Services/AdminService.cs, CertEasy.Web/Controllers/AdminController.cs, CertEasy.Web/Models/AdminViewModels.cs | pending | — |
| T-002 | Entry points — Layout & View wiring | CertEasy.Web/Views/Shared/_AdminLayout.cshtml | pending | T-001 |
| T-003 | Frontend UI — Exam CRUD Views | CertEasy.Web/Views/Admin/ManageExams.cshtml, CertEasy.Web/Views/Admin/CreateExam.cshtml, CertEasy.Web/Views/Admin/EditExam.cshtml | pending | T-002 |
