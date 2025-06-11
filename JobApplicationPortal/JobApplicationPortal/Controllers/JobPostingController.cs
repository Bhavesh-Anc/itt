using JobApplicationPortal.Models;
using JobApplicationPortal.Services;
using JobApplicationPortal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobApplicationPortal.Controllers
{
    [Authorize(Roles = "Recruiter")]
    public class JobPostingController : Controller
    {
        private readonly IJobService _jobService;
        private readonly UserManager<ApplicationUser> _userManager;

        public JobPostingController(IJobService jobService, UserManager<ApplicationUser> userManager)
        {
            _jobService = jobService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var recruiterId = _userManager.GetUserId(User);
            var jobPostings = await _jobService.GetApplicationsForRecruiterAsync(recruiterId);
            return View(jobPostings);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobPostingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var jobPosting = new JobPosting
                {
                    Title = model.Title,
                    Description = model.Description,
                };
                var recruiterId = _userManager.GetUserId(User);
                await _jobService.CreateJobPostingAsync(jobPosting, recruiterId);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var jobPosting = await _jobService.GetJobPostingAsync(id);
            if (jobPosting == null)
            {
                return NotFound();
            }
            var model = new JobPostingViewModel
            {
                Id = jobPosting.Id,
                Title = jobPosting.Title,
                Description = jobPosting.Description
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, JobPostingViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var jobPosting = await _jobService.GetJobPostingAsync(id);
                if (jobPosting == null)
                {
                    return NotFound();
                }
                jobPosting.Title = model.Title;
                jobPosting.Description = model.Description;
                await _jobService.UpdateJobPostingAsync(jobPosting);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var jobPosting = await _jobService.GetJobPostingAsync(id);
            if (jobPosting == null)
            {
                return NotFound();
            }
            return View(jobPosting);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _jobService.DeleteJobPostingAsync(jobPosting);
            return RedirectToAction(nameof(Index));
        }
    }
}
