using System;
using System.ComponentModel.DataAnnotations;
namespace JobApplicationPortal.Models
{
    public class JobApplication
    {
        public int Id { get; set; }

        [Required]

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        public int JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; }

        public DateTime ApplicationDate { get; set; } = DateTime.Now;

        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
    }

    public enum ApplicationStatus
    {
        Pending,
        Approved,
        Rejected
    }
}