using CertEasy.Model;
using CertEasy.Data;
using Microsoft.EntityFrameworkCore;

namespace CertEasy.Services
{
    public class WorkflowService : IWorkflowService
    {
        private readonly CertEasyDbContext _context;

        public WorkflowService(CertEasyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Certification>> GetActiveCertificationsAsync()
        {
            return await _context.Certifications.Where(c => c.IsActive).ToListAsync();
        }

        public async Task<bool> SubmitApplicationAsync(Application application)
        {
            if (application == null) throw new ArgumentNullException(nameof(application));

            // Validation Logic: User can't have multiple pending applications for the same certification
            var existing = await _context.Applications
                .AnyAsync(a => a.UserID == application.UserID &&
                               a.CertificationID == application.CertificationID &&
                               (a.StatusID == (int)ApplicationStatus.New || a.StatusID == (int)ApplicationStatus.Review));

            if (existing) return false;

            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Application>> GetUserApplicationsAsync(int userId)
        {
            return await _context.Applications
                .Include(a => a.Certification)
                .Include(a => a.Status)
                .Include(a => a.Exam)
                .Include(a => a.User)
                .Where(a => a.UserID == userId)
                .OrderByDescending(a => a.SubmittedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Application>> GetAllApplicationsAsync()
        {
            return await _context.Applications
                .Include(a => a.Certification)
                .Include(a => a.Status)
                .Include(a => a.Exam)
                .Include(a => a.User)
                .OrderByDescending(a => a.SubmittedDate)
                .ToListAsync();
        }

        public async Task<Application?> GetApplicationByIdAsync(int id)
        {
            return await _context.Applications
                .Include(a => a.Certification)
                .Include(a => a.Status)
                .Include(a => a.Exam)
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Exam>> GetExamsAsync()
        {
            return await _context.Exams.ToListAsync();
        }
    }
}
