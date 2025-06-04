using Microsoft.AspNetCore.Identity;

namespace JobApplicationPortal.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ResumePath { get; set; }
        public ICollection<JobApplication>Applications{ get; set; }
    }
}