using System.ComponentModel.DataAnnotations;

namespace JobApplicationPortal.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Roles")]
        public List<string> Roles { get; set; } = new List<string>();
    }
}