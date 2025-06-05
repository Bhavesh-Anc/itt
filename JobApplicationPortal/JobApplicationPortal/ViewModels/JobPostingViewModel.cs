using system.ComponentModel.DataAnnotations;
namespace JobApplicationPortal.ViewModels
{
    public class JobPostingViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Job title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Job description is required.")]
        public string Description { get; set; }
    }
}