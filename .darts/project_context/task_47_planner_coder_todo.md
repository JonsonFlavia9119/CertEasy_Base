# Planner-Coder Todo — 47
**Requirement:** Set up an email notification system using a service like SendGrid. Create templates for Approval and Rejection. Logic must trigger emails and log them in the Notifications table when an Admin updates an application status to 112 or 113.

Acceptance Criteria:
- Tables 'NotificationTemplates' and 'Notifications' created.
- Email service sends notifications on Approval (112) and Rejection (113).
- Notification record is stored in the database with status 'Sent' or 'Failed'.

Dependencies: Task Admin Review and Configuration Dashboard

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\CertEasyDbContext.cs: Roles, Statuses, Addresses, Certifications, EducationLevels, Users, Logs
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\Program.cs: IAccountService, IAdminService, IPasswordService, IWorkflowService

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\CertEasyDbContext.cs: add DbSet<NotificationTemplate>, DbSet<Notification>, seed templates
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\Program.cs: add builder.Services.AddScoped<IEmailService, EmailService>()
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Services\AdminService.cs: inject IEmailService, call SendEmailNotificationAsync in Approve/Reject

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend Models and DbContext Update | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\NotificationTemplate.cs, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\Notification.cs, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Model\CertEasyDbContext.cs | pending | — |
| T-002 | Email Service Implementation | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Services\IEmailService.cs, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Services\EmailService.cs, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\appsettings.json | pending | T-001 |
| T-003 | Service Wiring and Logic Integration | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Web\Program.cs, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Phase1\CertEasy.Services\AdminService.cs | pending | T-002 |
