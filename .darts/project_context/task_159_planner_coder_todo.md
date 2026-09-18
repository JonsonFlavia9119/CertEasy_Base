# Planner-Coder Todo — 159
**Requirement:** An unhandled exception occurred while processing the request.
AmbiguousMatchException: The request matched multiple endpoints. Matches:

CertEasy.Web.Controllers.WorkflowController.Apply (CertEasy.Web)
CertEasy.Web.Controllers.WorkflowController.Index (CertEasy.Web)
Microsoft.AspNetCore.Routing.Matching.DefaultEndpointSelector.ReportAmbiguity(Span<CandidateState> candidateState)

---

## Wiring Manifest

### Existing (preserve every line when modifying these files)
- CertEasy.Web/Controllers/WorkflowController.cs: [Authorize], [ApiController], [Route("[controller]")] with actions Index, Apply, GetInitialData, SaveStep, SubmitApplication, Resubmit.

### Planned (add exactly these in STEP 3 — decided now, not during coding)
- CertEasy.Web/Controllers/WorkflowController.cs: Remove [ApiController] attribute and route template [Route("[controller]")] from WorkflowController to allow standard MVC route mapping and action-level routing without ambiguous match conflicts. Set explicit [HttpGet] action routes where necessary (e.g., [HttpGet], [HttpGet("Apply")]).

---

## All Tasks

| ID | Task | Files | Status | Depends On |
|---|---|---|---|---|
| T-001 | Fix WorkflowController ambiguous endpoint routing | CertEasy.Web/Controllers/WorkflowController.cs | pending | — |
