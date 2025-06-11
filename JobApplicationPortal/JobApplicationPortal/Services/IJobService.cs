using JobApplicationPortal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationPortal.Services
{
    public interface IJobService
    {
        Task<IEnumerable<JobPosting>> GetAvailableJobPostingsAsync(string userId);
        Task<JobPosting> GetJobPostingAsync(int id);
        Task CreateJobPostingAsync(JobPosting jobPosting, string recruiterId);
        Task UpdateJobPostingAsync(JobPosting jobPosting);
        Task DeleteJobPostingAsync(int id);

        Task ApplyForJobAsync(int jobPostingId, string userId);
        Task<IEnumerable<JobApplication>> GetApplicationsForRecruiterAsync(string recruiterId);
        Task UpdateApplicationStatusAsync(int applicationId, ApplicationStatus status);
        Task<IEnumerable<JobApplication>> GetUserApplicationsAsync(string userId);
    } 
}
