# Planner-Coder Todo — 146
**Requirement:** Requirements,

* As an admin user, I need email notifications to be sent on Application Approval or Rejection. 
* Use the resend email send functionality to send emails 
* Use from Email "onboarding@resend.dev"
* Use recipient email "delivered@resend.dev" 
* The Subject would be Application Reject or Application Approval based on action in application grid
* The body content should be UserName, ApplicationId, Exam Name and SubmittedDateTime

Check;

* Ensure email notifications are being send every action performed in Application grid (Approval/Rejection)
* Ensure other functionalities should not get affected

Desired output;

An recipient should get email notifications upon every action performed by the Admin user

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_AdminActions_Phase1\CertEasy.Services\IEmailService.cs: SendAdminNotificationEmailAsync
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_AdminActions_Phase1\CertEasy.Services\ResendEmailService.cs: SendAdminNotificationEmailAsync
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_AdminActions_Phase1\CertEasy.Services\INotificationService.cs: SendApplicationStatusEmailAsync
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_AdminActions_Phase1\CertEasy.Services\NotificationService.cs: SendApplicationStatusEmailAsync
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_AdminActions_Phase1\CertEasy.Services\AdminService.cs: ApproveApplicationAsync, RejectApplicationAsync

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- None (Verified already implemented)

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Verify and Mark Already Implemented | C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_AdminActions_Phase1\CertEasy.Services\ResendEmailService.cs, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_AdminActions_Phase1\CertEasy.Services\NotificationService.cs, C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_AdminActions_Phase1\CertEasy.Services\AdminService.cs | pending | — |
