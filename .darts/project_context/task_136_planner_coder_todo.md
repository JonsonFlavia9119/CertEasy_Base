# Planner-Coder Todo — 136
**Requirement:** Implement the notification service that triggers after an application status update. For approvals, send an email with Subject "Application Approved" containing the application ID and [REDACTED] details. For rejections, send an email with Subject "Application Rejected" containing the same details. The recipient email address must be fetched from the emailId field in the users table.

Acceptance Criteria:
- Upon approval, an email is sent to the recipient's emailId (retrieved from the users table).
- The approval email has Subject: 'Application Approved' and includes the Application ID and [REDACTED] details in the body.
- Upon rejection, an email is sent to the recipient's emailId.
- The rejection email has Subject: 'Application Rejected' and includes the Application ID and [REDACTED] details in the body.

Dependencies: Task Admin Email Configuration Page, Task Update Application Status Logic

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Web/Program.cs: builder.Services.AddScoped<INotificationService, NotificationService>(); registered.
- CertEasy.Services/AdminService.cs: Calls _notificationService.SendApplicationStatusEmailAsync on approval/rejection.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- None (already wired in previous attempt, just need to ensure the implementation in NotificationService.cs is correct and uses "email" field if "emailId" is not available, or verify if I missed "emailId" field).

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Implement Notification Service | CertEasy.Services/NotificationService.cs | pending | — |
