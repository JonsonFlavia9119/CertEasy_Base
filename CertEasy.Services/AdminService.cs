using CertEasy.Data;
using CertEasy.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertEasy.Services
{
    public class AdminService : IAdminService
    {
        private readonly CertEasyDbContext _context;
        private readonly ILogger<AdminService> _logger;

        public AdminService(CertEasyDbContext context, ILogger<AdminService> logger)
        {
            _context = context;
            _logger = logger;
        }

        private async Task<int?> GetAccountIdForUserAsync(string userName)
        {
            var user = await _context.Users.Include(u => u.Account).FirstOrDefaultAsync(u => u.Email == userName);
            return user?.Account?.Id;
        }

        public async Task<IEnumerable<Application>> GetApplicationsInReviewAsync()
        {
            return await _context.Applications
                .Include(a => a.User)
                .Include(a => a.Status)
                .Where(a => a.StatusID == (int)ApplicationStatus.Review)
                .ToListAsync();
        }

        public async Task<bool> ApproveApplicationAsync(int id, string adminUser)
        {
            try
            {
                var app = await _context.Applications.FindAsync(id);
                if (app == null) return false;

                app.StatusID = (int)ApplicationStatus.Approved;
                app.UpdatedDate = DateTime.UtcNow;
                app.UpdatedBy = adminUser;
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error approving application {Id}", id);
                return false;
            }
        }

        public async Task<bool> RejectApplicationAsync(int id, string adminUser)
        {
            try
            {
                var app = await _context.Applications.FindAsync(id);
                if (app == null) return false;

                app.StatusID = (int)ApplicationStatus.Rejection;
                app.UpdatedDate = DateTime.UtcNow;
                app.UpdatedBy = adminUser;
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error rejecting application {Id}", id);
                return false;
            }
        }

        public async Task<IEnumerable<Certification>> GetCertificationsAsync()
        {
            return await _context.Certifications.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Certification?> GetCertificationByIdAsync(int id)
        {
            return await _context.Certifications.FindAsync(id);
        }

        public async Task<bool> AddCertificationAsync(Certification certification, string adminUser)
        {
            try
            {
                certification.CreatedDate = DateTime.UtcNow;
                certification.CreatedBy = adminUser;
                certification.UpdatedDate = DateTime.UtcNow;
                certification.UpdatedBy = adminUser;
                
                certification.EntityID = await GetAccountIdForUserAsync(adminUser);
                certification.EntityTypeID = 201; // Admin Area

                _context.Certifications.Add(certification);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding certification");
                return false;
            }
        }

        public async Task<bool> UpdateCertificationAsync(Certification certification, string adminUser)
        {
            try
            {
                var existing = await _context.Certifications.FindAsync(certification.Id);
                if (existing == null) return false;

                existing.Name = certification.Name;
                existing.Description = certification.Description;
                existing.ObtainedYear = certification.ObtainedYear;
                existing.IsActive = certification.IsActive;
                existing.UpdatedDate = DateTime.UtcNow;
                existing.UpdatedBy = adminUser;

                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating certification {Id}", certification.Id);
                return false;
            }
        }

        public async Task<bool> DeleteCertificationAsync(int id)
        {
            try
            {
                var certification = await _context.Certifications.FindAsync(id);
                if (certification == null) return false;

                _context.Certifications.Remove(certification);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting certification {Id}", id);
                return false;
            }
        }

        public async Task<bool> ToggleCertificationStatusAsync(int id, string adminUser)
        {
            try
            {
                var cert = await _context.Certifications.FindAsync(id);
                if (cert == null) return false;

                cert.IsActive = !cert.IsActive;
                cert.UpdatedDate = DateTime.UtcNow;
                cert.UpdatedBy = adminUser;
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error toggling certification status {Id}", id);
                return false;
            }
        }

        public async Task<IEnumerable<Address>> GetAllAddressesAsync() => await _context.Addresses.ToListAsync();
        public async Task<Address?> GetAddressByIdAsync(int id) => await _context.Addresses.FindAsync(id);
        public async Task<bool> AddAddressAsync(Address address, string adminUser)
        {
            try
            {
                address.CreatedDate = DateTime.UtcNow;
                address.CreatedBy = adminUser;
                address.UpdatedDate = DateTime.UtcNow;
                address.UpdatedBy = adminUser;
                _context.Addresses.Add(address);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding address");
                return false;
            }
        }
        public async Task<bool> UpdateAddressAsync(Address address, string adminUser)
        {
            try
            {
                var existing = await _context.Addresses.FindAsync(address.Id);
                if (existing == null) return false;

                _context.Entry(existing).CurrentValues.SetValues(address);
                existing.UpdatedDate = DateTime.UtcNow;
                existing.UpdatedBy = adminUser;
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating address {Id}", address.Id);
                return false;
            }
        }
        public async Task<bool> DeleteAddressAsync(int id)
        {
            try
            {
                var item = await _context.Addresses.FindAsync(id);
                if (item == null) return false;
                _context.Addresses.Remove(item);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting address {Id}", id);
                return false;
            }
        }

        public async Task<IEnumerable<Education>> GetAllEducationAsync()
        {
            return await _context.Educations.OrderByDescending(e => e.CreatedDate).ToListAsync();
        }

        public async Task<Education?> GetEducationByIdAsync(int id)
        {
            return await _context.Educations.FindAsync(id);
        }

        public async Task<bool> AddEducationAsync(Education education, string adminUser)
        {
            try
            {
                education.CreatedDate = DateTime.UtcNow;
                education.CreatedBy = adminUser;
                education.UpdatedDate = DateTime.UtcNow;
                education.UpdatedBy = adminUser;

                education.EntityID = await GetAccountIdForUserAsync(adminUser);
                education.EntityTypeID = 201; // Admin Area

                _context.Educations.Add(education);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding education qualification");
                return false;
            }
        }

        public async Task<bool> UpdateEducationAsync(Education education, string adminUser)
        {
            try
            {
                var existing = await _context.Educations.FindAsync(education.Id);
                if (existing == null) return false;

                existing.Name = education.Name;
                existing.Description = education.Description;
                existing.IsActive = education.IsActive;
                existing.InstituteName = education.InstituteName;
                existing.UpdatedDate = DateTime.UtcNow;
                existing.UpdatedBy = adminUser;

                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating education qualification {Id}", education.Id);
                return false;
            }
        }

        public async Task<bool> DeleteEducationAsync(int id)
        {
            try
            {
                var item = await _context.Educations.FindAsync(id);
                if (item == null) return false;
                _context.Educations.Remove(item);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting education qualification {Id}", id);
                return false;
            }
        }
    }
}
