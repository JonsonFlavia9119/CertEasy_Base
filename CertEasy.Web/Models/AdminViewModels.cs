using CertEasy.Model;
using System.Collections.Generic;

namespace CertEasy.Web.Models
{
    public class AdminDashboardViewModel
    {
        public IEnumerable<Application> PendingApplications { get; set; } = new List<Application>();
        public IEnumerable<Address> Addresses { get; set; } = new List<Address>();
        public IEnumerable<Certification> Certifications { get; set; } = new List<Certification>();
        public IEnumerable<Education> Educations { get; set; } = new List<Education>();
    }
}