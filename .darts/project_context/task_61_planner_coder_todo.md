# Planner-Coder Todo — 61
**Requirement:** The Registration / Login buttons are not working, there is no backend calls triggered from the from end, verified in the network section in the browser. in .cshtml page I could see the below code but still its not working a asp-controller="Account" asp-action="Login" class="btn btn-primary btn-lg px-4 gap-3">Login</a> in AccountController I could see the below code but its not triggering [HttpGet] public IActionResult Login() { if (User.Identity?.IsAuthenticated == true) return RedirectToAction("Index", "Home"); return View(); } Analyze my project level requirements if needed. I need to register or login functionality to be worked now.

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Web\Program.cs: Authentication (Cookie, Negotiate), ControllersWithViews, DbContext, Custom Services.
- CertEasy.Web\Views\_ViewImports.cshtml: TagHelper registration.
- CertEasy.Web\Views\Shared\_Layout.cshtml: Navigation links, scripts (jQuery, Bootstrap).

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Web\Program.cs: No changes needed to wiring, but verified.
- CertEasy.Web\Views\Home\Index.cshtml: Standardize anchor tags.

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Backend & Infrastructure Audit | CertEasy.Web/Controllers/AccountController.cs, CertEasy.Web/Program.cs | pending | — |
| T-002 | UI Fixes - Login/Register Link Restoration | CertEasy.Web/Views/Home/Index.cshtml, CertEasy.Web/Views/Shared/_Layout.cshtml, CertEasy.Web/Views/Account/Login.cshtml, CertEasy.Web/Views/Account/Register.cshtml | pending | T-001 |
