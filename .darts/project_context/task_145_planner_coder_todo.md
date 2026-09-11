# Planner-Coder Todo — 145
**Requirement:** Update the existing Resend email integration so that the **Resend API key is retrieved from the `EmailConfigurations.ApiKey` database field and used dynamically when sending each email**.

Do not move the API key to `appsettings.json`, User Secrets, environment variables, or any other configuration source.

Inspect the installed Resend NuGet package version and use the correct API for that version.

Update the existing `SendAsync()` implementation and dependency injection configuration as needed.

Ensure:

* `config.ApiKey` is actually passed to the Resend client.
* `config.SenderEmail` and `config.SenderName` continue to come from the database.
* No hard-coded API key is used.
* `"PLACEHOLDER"` is completely removed.
* Missing API key is handled with proper logging and returns `false`.
* The API key is never written to logs.
* Make only the necessary changes and do not modify unrelated code.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_AdminActions_Phase1\CertEasy.Web\Program.cs: builder.Services.AddHttpClient(); builder.Services.AddScoped<IEmailService, ResendEmailService>();

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- No new registrations needed; existing registrations in Program.cs are already correct for dynamic instantiation in the service.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend — Update ResendEmailService for dynamic API key | CertEasy.Services/ResendEmailService.cs | pending | — |
