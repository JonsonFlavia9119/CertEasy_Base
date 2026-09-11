# Planner-Coder Todo — 143
**Requirement:** I want to implement transactional email sending in my ASP.NET Core application. Use Resend as the email service provider instead of SMTP.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Web/Program.cs: builder.Services.AddHttpClient<IResend, ResendClient>(), builder.Services.AddScoped<IEmailService, ResendEmailService>()
- CertEasy.Web/Controllers/AdminController.cs: AdminController(IAdminService adminService, ILogger<AdminController> logger)
- CertEasy.Services/AdminService.cs: AdminService(CertEasyDbContext context, ILogger<AdminService> logger, INotificationService notificationService, IEmailService emailService)
- CertEasy.Services/NotificationService.cs: NotificationService(CertEasyDbContext context, IEmailService emailService, ILogger<NotificationService> logger)

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Web/Program.cs: Update Resend options to use DB API key if possible, but the current DI setup is already functional.
- CertEasy.Web/Controllers/AdminController.cs: Add Remarks to Reject action to satisfy requirement 8-9 more fully (sending remarks in rejection email).

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend - Email Logic Refinement | CertEasy.Services/ResendEmailService.cs, CertEasy.Services/AdminService.cs, CertEasy.Services/NotificationService.cs | pending | — |
| T-002 | Entry points & API | CertEasy.Web/Program.cs, CertEasy.Web/Controllers/AdminController.cs | pending | T-001 |
| T-003 | Frontend UI | CertEasy.Web/Views/Admin/EmailConfiguration.cshtml | pending | T-002 |
