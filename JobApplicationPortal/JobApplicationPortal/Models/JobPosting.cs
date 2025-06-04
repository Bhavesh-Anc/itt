using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace JobApplicationPortal.Models
{
    public class JobPosting
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime PostedDate { get; set; } = DateTime.Now;
        [Required]
        public string RecruiterId { get; set; }
        public ApplicationUser Recruiter { get; set; }
        public ICollection<JobApplication>Applications{ get; set; }
    }
}