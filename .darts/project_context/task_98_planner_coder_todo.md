# Planner-Coder Todo — 98
**Requirement:** In Index.cshtml page

        function DashboardViewModel() {
            var self = this;
            
            self.addresses = ko.observableArray([
                @foreach (var addr in Model.Addresses)
                {
                    @: { street: '@addr.Line1', city: '@addr.City', state: '@addr.State', postalCode: '@addr.ZipCode' },
                }
            ]);


            self.certifications = ko.observableArray([
                @foreach (var cert in Model.Certifications)
                {
                    @: { name: '@cert.Name', description: '@cert.Description', isActive: @cert.IsActive.ToString().ToLower() },
                }
            ]);
        }

and 

AdminController.cs

        public async Task<IActionResult> Index()
        {
            var applications = await _adminService.GetApplicationsInReviewAsync();
            var addresses = await _adminService.GetAllAddressesAsync();
            var certifications = await _adminService.GetCertificationsAsync();

            var viewModel = new AdminDashboardViewModel
            { 
                PendingApplications = applications, 
                Addresses = addresses, 
                Certifications = certifications,                
            };
            return View(viewModel);
        }

I don't see any education related code piece in this area, without calling AllEucationAsync method how will the education data should get displayed like Certifications and Address

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase2\CertEasy.Web\Controllers\AdminController.cs: _adminService.GetApplicationsInReviewAsync(), _adminService.GetAllAddressesAsync(), _adminService.GetCertificationsAsync(), _adminService.GetAllEducationAsync()
- C:\DARTS-development-environment\sandbox\kjohnson\CertEasy_Admin_Phase2\CertEasy.Web\Views\Admin\Index.cshtml: DashboardViewModel with addresses, educations, certifications

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- No new wiring needed as the current state already implements the requirement (the requirement highlights the need for Education data which is already present).

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Verify and confirm existing implementation of Education in AdminController and Index.cshtml | CertEasy.Web/Controllers/AdminController.cs, CertEasy.Web/Views/Admin/Index.cshtml | pending | — |
