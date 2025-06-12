using JobApplicationPortal.Models;
using JobApplicationPortal.ViewModels;
using JobApplicationPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobApplicationPortal.Controllers
{
    [Authorize]
    public class JobApplicationController : Controller
    {
        private readonly IJobService _jobService;
        private readonly UserManager<ApplicationUser> _userManager;

        public JobApplicationController(IJobService jobService, UserManager<ApplicationUser> userManager)
        {
            _jobService = jobService;
            _userManager = userManager;
        }

        [Authorize(Roles = "Recruiter,Admin")]
        public async Task<IActionResult> Applications(int jobId)
        {
            var applications = await _jobService.GetApplicationsForRecruiterAsync(_userManager.GetUserId(User));
            return View(applications);
        }

        [HttpPost]
        [Authorize(Roles = "Recruiter,Admin")]
        public async Task<IActionResult> UpdateStatus(int applicationId, ApplicationStatus status)
        {
            await _jobService.UpdateApplicationStatusAsync(applicationId, status);
            return RedirectToAction(nameof(Applications));
        }

        public async Task<IActionResult> MyApplications()
        {
            var userId = _userManager.GetUserId(User);
            var applications = await _jobService.GetUserApplicationsAsync(userId);
            return View(applications);
        }

        [HttpPost]
        [Authorize(Roles = "Employee,Admin")]
        public async Task<IActionResult> Apply(int jobId)
        {
            var userId = _userManager.GetUserId(User);
            await _jobService.ApplyForJobAsync(jobId, userId);
            return RedirectToAction(nameof(MyApplications));
        }
    }
}
