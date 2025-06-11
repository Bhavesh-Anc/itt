using JobApplicationPortal.Models;
using JobApplicationPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobApplicationPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobService _jobService;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(IJobService jobService, UserManager<ApplicationUser> userManager)
        {
            _jobService = jobService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                var userId = _userManager.GetUserId(User);
                var jobs = await _jobService.GetUserApplicationsAsync(userId);
                return View(jobs ?? new List<JobPosting>());
            }
            return View(new List<JobPosting>());
        }
    }
}
