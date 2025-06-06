using JobApplcationPortal.Data;
using JobApplicationPortal.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicationPortal.Services
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext _context;

        public JobService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobPosting>> GetAvailableJobPostingsAsync(string userId)
        {
            var appliedJobIds = await _context.JobApplications
                .Where(ja => ja.UserId == userId && ja.Status != ApplicationStatus.Rejected)
                .Select(ja => ja.JobPostingId)
                .ToListAsync();
            return await _context.JobPostings
                .Where(jp => !appliedJobIds.Contains(jp.Id))
                .ToListAsync();
        }

        public async Task<JobPosting> GetJobPostingAsync(int id)
        {
            return await _context.JobPostings.FindAsync(id);
        }

        public async Task CreateJobPostingAsync(JobPosting jobPosting, string recruiterId)
        {
            jobPosting.RecruiterId = recruiterId;
            _context.JobPostings.Add(jobPosting);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateJobPostingAsync(JobPosting jobPosting)
        {
            _context.JobPostings.Update(jobPosting);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJobPostingAsync(int id)
        {
            var jobPosting = await _context.JobPostings.FindAsync(id);
            if (jobPosting != null)
            {
                _context.JobPostings.Remove(jobPosting);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ApplyForJobAsync(int jobPostingId, string userId)
        {
            var application = new JobApplication
            {
                JobPostingId = jobPostingId,
                UserId = userId,
                Status = ApplicationStatus.Pending
            };
            _context.JobApplications.Add(application);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<JobApplication>> GetApplicationsForRecruiterAsync(string recruiterId)
        {
            return await _context.JobApplications
                .Include(ja => ja.JobPosting)
                .Include(ja => ja.User)
                .Where(ja => ja.JobPosting.RecruiterId == recruiterId && ja.Status != ApplicationStatus.Rejected)
                .ToListAsync();
        }

        public async Task UpdateApplicationStatusAsync(int applicationId, ApplicationStatus status)
        {
            var application = await _context.JobApplications.FindAsync(applicationId);
            if (application != null)
            {
                application.Status = status;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<JobApplication>> GetUserApplicationsAsync(string userId)
        {
            return await _context.JobApplications
                .Include(ja => ja.JobPosting)
                .Where(ja => ja.UserId == userId)
                .ToListAsync();
        }
    }
}