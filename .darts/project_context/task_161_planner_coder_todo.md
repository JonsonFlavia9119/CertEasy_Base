# Planner-Coder Todo — 161
**Requirement:** As an admin user, I would like to have a check box in user registration page so during user registration if the checkbox is checked it will consider as a admin user. Set the RoleId =1 if the check box is enabled during registration.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Web/Models/LoginViewModel.cs: RegisterViewModel
- CertEasy.Web/Views/Account/Register.cshtml: Register form UI
- CertEasy.Web/Controllers/AccountController.cs: Register POST action mapping model to User
- CertEasy.Services/AccountService.cs: RegisterAsync setting RoleID = (int)UserRole.User

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Web/Models/LoginViewModel.cs: add IsAdmin property to RegisterViewModel
- CertEasy.Web/Views/Account/Register.cshtml: add IsAdmin checkbox UI element
- CertEasy.Web/Controllers/AccountController.cs: pass RoleID based on IsAdmin checkbox (1 if checked, UserRole.User otherwise)
- CertEasy.Services/AccountService.cs: preserve passed user.RoleID or check if RoleID != 0 in RegisterAsync

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Add IsAdmin checkbox to RegisterViewModel, Register.cshtml, AccountController, and AccountService | CertEasy.Web/Models/LoginViewModel.cs, CertEasy.Web/Views/Account/Register.cshtml, CertEasy.Web/Controllers/AccountController.cs, CertEasy.Services/AccountService.cs | pending | — |
