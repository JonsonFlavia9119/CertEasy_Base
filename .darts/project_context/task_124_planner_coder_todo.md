# Planner-Coder Todo — 124
**Requirement:** Create the Exam database table and update the Applications table to store the selected exam reference. Fields for Exam: id, exam_name (text), exam_center (text), exam_slot (datetime). Update Applications table with: exam_id (Foreign Key).

Acceptance Criteria:
- Exam table exists with columns: id, exam_name (text), exam_center (text), exam_slot (datetime)
- Applications table is updated to include 'exam_id' column

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:/DARTS-development-environment/sandbox/kjohnson/CertEasy_ApplicationProcess_Phase2/CertEasy.Data/CertEasyDbContext.cs: DbSet<Exam>, Application relationship, Exam seed data
- C:/DARTS-development-environment/sandbox/kjohnson/CertEasy_ApplicationProcess_Phase2/CertEasy.Model/Application.cs: ExamID property, Exam navigation property
- C:/DARTS-development-environment/sandbox/kjohnson/CertEasy_ApplicationProcess_Phase2/CertEasy.Model/Exam.cs: ExamName, ExamCenter, ExamSlot properties

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:/DARTS-development-environment/sandbox/kjohnson/CertEasy_ApplicationProcess_Phase2/CertEasy.Web/Models/ApplicationViewModel.cs: add [Required] public int ExamID { get; set; }
- C:/DARTS-development-environment/sandbox/kjohnson/CertEasy_ApplicationProcess_Phase2/CertEasy.Web/Controllers/WorkflowController.cs: update SubmitApplication to map model.ExamID to application.ExamID; update GetInitialData to include exams
- C:/DARTS-development-environment/sandbox/kjohnson/CertEasy_ApplicationProcess_Phase2/CertEasy.Web/Views/Workflow/Apply.cshtml: add Exam selection step to the wizard UI

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Update Backend Models and Controller | C:/DARTS-development-environment/sandbox/kjohnson/CertEasy_ApplicationProcess_Phase2/CertEasy.Web/Models/ApplicationViewModel.cs, C:/DARTS-development-environment/sandbox/kjohnson/CertEasy_ApplicationProcess_Phase2/CertEasy.Web/Controllers/WorkflowController.cs | pending | — |
| T-002 | Update Frontend UI for Exam Selection | C:/DARTS-development-environment/sandbox/kjohnson/CertEasy_ApplicationProcess_Phase2/CertEasy.Web/Views/Workflow/Apply.cshtml | pending | T-001 |
