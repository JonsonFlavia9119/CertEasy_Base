# Planner-Coder Todo — 142
**Requirement:** As an admin user I choose "Resend" email provider over SMTP so the SMTP setting are no longer needed.

TO DO
* Remove SMTP related fields in UI, ViewModels, backend code, Entity, SQL DB
* Fields: SMTP Server, SMTP Port, SMTP Username, SMTP Password

Check;
* Remove only specified columns and its related codes
* Do not remove unnecessary codes 
* Email configuration should work after removing the specified fields
* Add migration if needed

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Data/CertEasyDbContext.cs: EmailConfigurations DbSet, EmailConfiguration configuration in OnModelCreating.
- CertEasy.Web/Controllers/AdminController.cs: EmailConfiguration and TestEmail actions.
- CertEasy.Services/AdminService.cs: GetEmailConfigurationAsync, UpdateEmailConfigurationAsync, SendTestEmailAsync.
- CertEasy.Web/Models/AdminViewModels.cs: EmailConfigurationViewModel.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Model/EmailConfiguration.cs: Remove SmtpServer, SmtpPort, SmtpUsername, SmtpPassword.
- CertEasy.Web/Models/AdminViewModels.cs: Remove SmtpServer, SmtpPort, SmtpUsername, SmtpPassword from EmailConfigurationViewModel.
- CertEasy.Services/AdminService.cs: Update mapping logic to exclude SMTP fields.
- CertEasy.Web/Controllers/AdminController.cs: Update mapping logic to exclude SMTP fields.
- CertEasy.Web/Views/Admin/EmailConfiguration.cshtml: Remove SMTP form fields.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend — Remove SMTP fields from Entity, ViewModel and Update Service mapping | CertEasy.Model/EmailConfiguration.cs, CertEasy.Web/Models/AdminViewModels.cs, CertEasy.Services/AdminService.cs, CertEasy.Web/Controllers/AdminController.cs | pending | — |
| T-002 | Frontend UI — Remove SMTP fields from View | CertEasy.Web/Views/Admin/EmailConfiguration.cshtml | pending | T-001 |
