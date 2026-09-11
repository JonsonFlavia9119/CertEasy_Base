# Planner-Coder Todo — 147
**Requirement:** Getting the below error while clicking on Approve button

The UPDATE statement conflicted with the FOREIGN KEY constraint "FK_Applications_Statuses_StatusID". The conflict occurred in database "CertEasyDb", table "dbo.Statuses", column 'Id'.'

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Services/AdminService.cs: IAdminService implementation, DbContext, Notifications, Logger
- CertEasy.Model/Status.cs: ApplicationStatus enum (Approved = 7, Rejection = 8)

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Services/AdminService.cs: Change `app.StatusID = 112;` to `app.StatusID = (int)ApplicationStatus.Approved;` in ApproveApplicationAsync and `app.StatusID = 113;` to `app.StatusID = (int)ApplicationStatus.Rejection;` in RejectApplicationAsync.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Fix invalid Application StatusID FK values in AdminService to use valid Status IDs from ApplicationStatus enum | CertEasy.Services/AdminService.cs | pending | — |
