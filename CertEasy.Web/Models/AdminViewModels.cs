using CertEasy.Model;

namespace CertEasy.Web.Models
{
    public class AdminDashboardViewModel
    {
        public IEnumerable<Application> PendingApplications { get; set; } = new List<Application>();
    }
}